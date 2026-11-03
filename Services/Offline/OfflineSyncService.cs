using System.Data;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using Ocean_Desk_dv.Data;
using Ocean_Desk_dv.Data.SQLite;
using Ocean_Desk_dv.Data.SQLite.Entities;
using Ocean_Desk_dv.Models.Entities;

namespace Ocean_Desk_dv.Services.Offline;

/// <summary>
/// Procesa la cola local. En esta primera etapa solo sincroniza
/// la creación de clientes. Las demás operaciones se agregan mediante
/// handlers específicos para cada agregado de negocio.
/// </summary>
public sealed class OfflineSyncService : IOfflineSyncService
{
    private const int LoteMaximo = 20;
    private static readonly TimeSpan TiempoMaximoEnProceso =
        TimeSpan.FromMinutes(5);

    private readonly SemaphoreSlim _gate = new(1, 1);
    private bool _disposed;

    public async Task<OfflineSyncResult> SincronizarPendientesAsync(
        CancellationToken cancellationToken = default)
    {
        ThrowIfDisposed();

        if (!await _gate.WaitAsync(0, cancellationToken))
        {
            return new OfflineSyncResult
            {
                AlreadyRunning = true
            };
        }

        int synchronized = 0;
        int conflicts = 0;
        int failed = 0;

        try
        {
            LocalDatabaseInitializer.Initialize();

            await RecuperarOperacionesAbandonadasAsync(cancellationToken);

            List<Guid> operationIds;

            using (var context =
                   OceanDeskLocalDbContextFactory.CreateContext())
            {
                DateTime ahoraUtc = DateTime.UtcNow;

                operationIds = await context.OfflineOperations
                    .AsNoTracking()
                    .Where(operation =>
                        (operation.Status == OfflineOperationStatus.Pending ||
                         operation.Status == OfflineOperationStatus.Retry) &&
                        (!operation.NextAttemptAtUtc.HasValue ||
                         operation.NextAttemptAtUtc <= ahoraUtc))
                    .OrderBy(operation => operation.CreatedAtUtc)
                    .Select(operation => operation.OperationId)
                    .Take(LoteMaximo)
                    .ToListAsync(cancellationToken);
            }

            foreach (Guid operationId in operationIds)
            {
                cancellationToken.ThrowIfCancellationRequested();

                ProcessResult result =
                    await ProcesarOperacionAsync(
                        operationId,
                        cancellationToken);

                switch (result)
                {
                    case ProcessResult.Synchronized:
                        synchronized++;
                        break;

                    case ProcessResult.Conflict:
                        conflicts++;
                        break;

                    case ProcessResult.Failed:
                        failed++;
                        break;
                }
            }

            int pending;

            using (var context =
                   OceanDeskLocalDbContextFactory.CreateContext())
            {
                pending = await context.OfflineOperations.CountAsync(
                    operation =>
                        operation.Status == OfflineOperationStatus.Pending ||
                        operation.Status == OfflineOperationStatus.Processing ||
                        operation.Status == OfflineOperationStatus.Retry ||
                        operation.Status == OfflineOperationStatus.Conflict ||
                        operation.Status == OfflineOperationStatus.PermanentError,
                    cancellationToken);
            }

            return new OfflineSyncResult
            {
                Synchronized = synchronized,
                Conflicts = conflicts,
                Failed = failed,
                Pending = pending
            };
        }
        finally
        {
            _gate.Release();
        }
    }

    private async Task<ProcessResult> ProcesarOperacionAsync(
        Guid operationId,
        CancellationToken cancellationToken)
    {
        using var localContext =
            OceanDeskLocalDbContextFactory.CreateContext();

        DateTime inicioIntentoUtc = DateTime.UtcNow;

        // Reclamo atómico: dos instancias de Ocean Desk no deben procesar
        // simultáneamente la misma operación local.
        int operacionesReclamadas =
            await localContext.OfflineOperations
                .Where(item =>
                    item.OperationId == operationId &&
                    (item.Status == OfflineOperationStatus.Pending ||
                     item.Status == OfflineOperationStatus.Retry))
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(
                        item => item.Status,
                        OfflineOperationStatus.Processing)
                    .SetProperty(
                        item => item.AttemptCount,
                        item => item.AttemptCount + 1)
                    .SetProperty(
                        item => item.LastAttemptAtUtc,
                        inicioIntentoUtc)
                    .SetProperty(
                        item => item.NextAttemptAtUtc,
                        (DateTime?)null)
                    .SetProperty(
                        item => item.LastError,
                        (string?)null),
                    cancellationToken);

        if (operacionesReclamadas == 0)
            return ProcessResult.Skipped;

        OfflineOperation? operation =
            await localContext.OfflineOperations
                .SingleOrDefaultAsync(
                    item => item.OperationId == operationId,
                    cancellationToken);

        if (operation is null)
            return ProcessResult.Failed;

        try
        {
            if (!string.Equals(
                    operation.EntityType,
                    "Customer",
                    StringComparison.OrdinalIgnoreCase) ||
                !string.Equals(
                    operation.Action,
                    "Create",
                    StringComparison.OrdinalIgnoreCase))
            {
                throw new NotSupportedException(
                    $"La operación '{operation.EntityType}/{operation.Action}' " +
                    "todavía no tiene un proceso de sincronización implementado.");
            }

            int serverCustomerId =
                await SincronizarClienteEnServidorAsync(
                    operation,
                    cancellationToken);

            await using var localTransaction =
                await localContext.Database.BeginTransactionAsync(
                    cancellationToken);

            LocalCustomer? localCustomer =
                await localContext.LocalCustomers.SingleOrDefaultAsync(
                    customer =>
                        customer.LocalCustomerId == operation.LocalRecordId,
                    cancellationToken);

            if (localCustomer is null)
            {
                throw new InvalidOperationException(
                    "La operación existe, pero no se encontró el cliente local asociado.");
            }

            localCustomer.ServerCustomerId = serverCustomerId;
            localCustomer.SyncStatus = LocalCustomerSyncStatus.Synchronized;
            localCustomer.SynchronizedAtUtc = DateTime.UtcNow;
            localCustomer.LastSyncError = null;

            operation.Status = OfflineOperationStatus.Synchronized;
            operation.SynchronizedAtUtc = DateTime.UtcNow;
            operation.LastError = null;

            await localContext.SaveChangesAsync(cancellationToken);
            await localTransaction.CommitAsync(cancellationToken);

            return ProcessResult.Synchronized;
        }
        catch (OfflineSyncConflictException ex)
        {
            await MarcarConflictoAsync(
                localContext,
                operation,
                ex.Message,
                cancellationToken);

            return ProcessResult.Conflict;
        }
        catch (Exception ex) when (
            SqlServerConnectionFailureDetector.IsConnectionFailure(ex) ||
            SqlServerConnectionFailureDetector.IsMissingReceiptTable(ex) ||
            EsErrorSQLiteReintentable(ex))
        {
            await ProgramarReintentoAsync(
                localContext,
                operation,
                ex.Message,
                cancellationToken);

            return ProcessResult.Failed;
        }
        catch (Exception ex)
        {
            await MarcarErrorPermanenteAsync(
                localContext,
                operation,
                ex.Message,
                cancellationToken);

            return ProcessResult.Failed;
        }
    }

    private static async Task<int> SincronizarClienteEnServidorAsync(
        OfflineOperation operation,
        CancellationToken cancellationToken)
    {
        OfflineCustomerStore.CustomerCreatePayload? payload;

        try
        {
            payload = JsonSerializer.Deserialize<
                OfflineCustomerStore.CustomerCreatePayload>(
                operation.PayloadJson);
        }
        catch (JsonException ex)
        {
            throw new InvalidOperationException(
                "El contenido local de la operación no es un JSON válido.",
                ex);
        }

        if (payload is null ||
            string.IsNullOrWhiteSpace(payload.FirstName) ||
            string.IsNullOrWhiteSpace(payload.LastName) ||
            string.IsNullOrWhiteSpace(payload.Phone))
        {
            throw new InvalidOperationException(
                "La operación local no contiene los datos requeridos del cliente.");
        }

        string payloadHash = CalcularHash(operation.PayloadJson);

        using var serverContext = new OceanDeskDbContext();

        await using var transaction =
            await serverContext.Database.BeginTransactionAsync(
                IsolationLevel.Serializable,
                cancellationToken);

        OfflineSyncReceipt? receipt =
            await serverContext.OfflineSyncReceipts
                .SingleOrDefaultAsync(
                    item => item.OperationId == operation.OperationId,
                    cancellationToken);

        if (receipt is not null)
        {
            if (!string.Equals(
                    receipt.EntityType,
                    "Customer",
                    StringComparison.Ordinal) ||
                !string.Equals(
                    receipt.PayloadHash,
                    payloadHash,
                    StringComparison.OrdinalIgnoreCase))
            {
                throw new OfflineSyncConflictException(
                    "El identificador de operación ya existe en el servidor, " +
                    "pero su contenido no coincide con el registro local.");
            }

            if (!int.TryParse(
                    receipt.ServerRecordId,
                    NumberStyles.None,
                    CultureInfo.InvariantCulture,
                    out int idExistente) ||
                idExistente <= 0)
            {
                throw new InvalidOperationException(
                    "El comprobante de sincronización contiene un ID de cliente inválido.");
            }

            await transaction.CommitAsync(cancellationToken);
            return idExistente;
        }

        bool telefonoYaRegistrado =
            await serverContext.Customers.AnyAsync(
                customer =>
                    customer.IsActive &&
                    customer.Phone == payload.Phone,
                cancellationToken);

        if (telefonoYaRegistrado)
        {
            throw new OfflineSyncConflictException(
                "No se sincronizó el cliente porque ese teléfono ya existe " +
                "en SQL Server. Revise el registro antes de continuar.");
        }

        var customer = new Customer
        {
            FirstName = payload.FirstName.Trim(),
            LastName = payload.LastName.Trim(),
            Phone = payload.Phone.Trim(),
            IsActive = true,
            CreatedAt = DateTime.SpecifyKind(
                payload.CreatedAtUtc,
                DateTimeKind.Utc).ToLocalTime()
        };

        serverContext.Customers.Add(customer);
        await serverContext.SaveChangesAsync(cancellationToken);

        serverContext.OfflineSyncReceipts.Add(new OfflineSyncReceipt
        {
            OperationId = operation.OperationId,
            EntityType = "Customer",
            ServerRecordId = customer.CustomerId.ToString(
                CultureInfo.InvariantCulture),
            PayloadHash = payloadHash,
            ProcessedAtUtc = DateTime.UtcNow
        });

        // El cliente y su comprobante se confirman en la misma transacción.
        // Si la aplicación se cierra después del COMMIT y antes de actualizar
        // SQLite, el siguiente intento encontrará el comprobante y no duplicará.
        await serverContext.SaveChangesAsync(cancellationToken);
        await transaction.CommitAsync(cancellationToken);

        return customer.CustomerId;
    }

    private static async Task RecuperarOperacionesAbandonadasAsync(
        CancellationToken cancellationToken)
    {
        using var context =
            OceanDeskLocalDbContextFactory.CreateContext();

        DateTime limite = DateTime.UtcNow - TiempoMaximoEnProceso;

        List<OfflineOperation> abandonadas =
            await context.OfflineOperations
                .Where(operation =>
                    operation.Status == OfflineOperationStatus.Processing &&
                    operation.LastAttemptAtUtc.HasValue &&
                    operation.LastAttemptAtUtc < limite)
                .ToListAsync(cancellationToken);

        foreach (OfflineOperation operation in abandonadas)
        {
            operation.Status = OfflineOperationStatus.Retry;
            operation.NextAttemptAtUtc = DateTime.UtcNow;
            operation.LastError =
                "La operación se recuperó después de una interrupción inesperada.";
        }

        if (abandonadas.Count > 0)
            await context.SaveChangesAsync(cancellationToken);
    }

    private static async Task MarcarConflictoAsync(
        OceanDeskLocalDbContext context,
        OfflineOperation operation,
        string error,
        CancellationToken cancellationToken)
    {
        operation.Status = OfflineOperationStatus.Conflict;
        operation.LastError = LimitarError(error);

        LocalCustomer? customer =
            await context.LocalCustomers.SingleOrDefaultAsync(
                item => item.LocalCustomerId == operation.LocalRecordId,
                cancellationToken);

        if (customer is not null)
        {
            customer.SyncStatus = LocalCustomerSyncStatus.Conflict;
            customer.LastSyncError = LimitarError(error);
        }

        await context.SaveChangesAsync(cancellationToken);
    }

    private static async Task ProgramarReintentoAsync(
        OceanDeskLocalDbContext context,
        OfflineOperation operation,
        string error,
        CancellationToken cancellationToken)
    {
        int exponente = Math.Min(operation.AttemptCount, 8);
        double segundos = Math.Min(900, 5 * Math.Pow(2, exponente));

        operation.Status = OfflineOperationStatus.Retry;
        operation.NextAttemptAtUtc =
            DateTime.UtcNow.AddSeconds(segundos);
        operation.LastError = LimitarError(error);

        await context.SaveChangesAsync(cancellationToken);
    }

    private static async Task MarcarErrorPermanenteAsync(
        OceanDeskLocalDbContext context,
        OfflineOperation operation,
        string error,
        CancellationToken cancellationToken)
    {
        operation.Status = OfflineOperationStatus.PermanentError;
        operation.LastError = LimitarError(error);

        LocalCustomer? customer =
            await context.LocalCustomers.SingleOrDefaultAsync(
                item => item.LocalCustomerId == operation.LocalRecordId,
                cancellationToken);

        if (customer is not null)
        {
            customer.SyncStatus = LocalCustomerSyncStatus.PermanentError;
            customer.LastSyncError = LimitarError(error);
        }

        await context.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// Los bloqueos de SQLite y algunos errores temporales de E/S pueden
    /// ocurrir mientras otra operación usa el archivo local. Se reintentan:
    /// el comprobante remoto hace segura la repetición si SQL Server ya confirmó.
    /// </summary>
    private static bool EsErrorSQLiteReintentable(Exception exception)
    {
        for (Exception? current = exception;
             current is not null;
             current = current.InnerException)
        {
            if (current is SqliteException sqliteException &&
                sqliteException.SqliteErrorCode is 5 or 6 or 10 or 13)
            {
                return true;
            }
        }

        return false;
    }

    private static string CalcularHash(string payload)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(payload);
        byte[] hash = SHA256.HashData(bytes);
        return Convert.ToHexString(hash);
    }

    private static string LimitarError(string error)
    {
        if (string.IsNullOrWhiteSpace(error))
            return "Error sin descripción.";

        return error.Length <= 2000
            ? error
            : error[..2000];
    }

    private void ThrowIfDisposed()
    {
        if (_disposed)
            throw new ObjectDisposedException(nameof(OfflineSyncService));
    }

    public void Dispose()
    {
        if (_disposed)
            return;

        // No se elimina el semáforo aquí: el formulario puede cerrarse
        // mientras una sincronización asíncrona todavía lo está utilizando.
        // El objeto será liberado por el GC cuando termine esa operación.
        _disposed = true;
        GC.SuppressFinalize(this);
    }

    private enum ProcessResult
    {
        Skipped,
        Synchronized,
        Conflict,
        Failed
    }
}
