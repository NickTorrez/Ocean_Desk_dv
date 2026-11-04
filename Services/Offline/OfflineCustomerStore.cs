using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Ocean_Desk_dv.Data.SQLite;
using Ocean_Desk_dv.Data.SQLite.Entities;
using Ocean_Desk_dv.Models.DTOs;

namespace Ocean_Desk_dv.Services.Offline;

/// <summary>
/// Administra la copia local de clientes y su cola de sincronización.
/// Cada cliente y su operación pendiente se guardan en una misma
/// transacción SQLite.
/// </summary>
public sealed class OfflineCustomerStore
{
    public OfflineCustomerStore()
    {
        LocalDatabaseInitializer.Initialize();
    }

    /// <summary>
    /// Comprueba si existe un cliente activo con el teléfono indicado
    /// dentro de la base de datos local.
    /// </summary>
    public bool ExisteTelefonoActivoLocal(string telefono)
    {
        if (string.IsNullOrWhiteSpace(telefono))
            return false;

        string telefonoNormalizado = telefono.Trim();

        using var context =
            OceanDeskLocalDbContextFactory.CreateContext();

        return context.LocalCustomers
            .AsNoTracking()
            .Any(customer =>
                customer.IsActive &&
                customer.Phone == telefonoNormalizado);
    }

    /// <summary>
    /// Guarda un cliente local y devuelve un identificador temporal negativo.
    /// Los identificadores SQL Server son positivos; así evitamos colisiones.
    /// </summary>
    public int RegistrarClienteLocal(
        string nombre,
        string apellido,
        string telefono)
    {
        string nombreNormalizado = nombre.Trim();
        string apellidoNormalizado = apellido.Trim();
        string telefonoNormalizado = telefono.Trim();

        if (nombreNormalizado.Length == 0 ||
            apellidoNormalizado.Length == 0 ||
            telefonoNormalizado.Length == 0)
        {
            throw new ArgumentException(
                "Nombre, apellido y teléfono son obligatorios.");
        }

        using var context =
            OceanDeskLocalDbContextFactory.CreateContext();

        using var transaction = context.Database.BeginTransaction();

        bool telefonoDuplicado = context.LocalCustomers.Any(customer =>
            customer.IsActive &&
            customer.Phone == telefonoNormalizado);

        if (telefonoDuplicado)
        {
            throw new InvalidOperationException(
                "Ya existe un cliente local activo con ese teléfono.");
        }

        DateTime ahoraUtc = DateTime.UtcNow;

        var clienteLocal = new LocalCustomer
        {
            FirstName = nombreNormalizado,
            LastName = apellidoNormalizado,
            Phone = telefonoNormalizado,
            IsActive = true,
            CreatedAtUtc = ahoraUtc,
            SyncStatus = LocalCustomerSyncStatus.Pending
        };

        context.LocalCustomers.Add(clienteLocal);
        context.SaveChanges();

        var payload = new CustomerCreatePayload
        {
            FirstName = clienteLocal.FirstName,
            LastName = clienteLocal.LastName,
            Phone = clienteLocal.Phone!,
            CreatedAtUtc = ahoraUtc
        };

        var operacion = new OfflineOperation
        {
            OperationId = Guid.NewGuid(),
            EntityType = "Customer",
            Action = "Create",
            LocalRecordId = clienteLocal.LocalCustomerId,
            PayloadJson = JsonSerializer.Serialize(payload),
            Status = OfflineOperationStatus.Pending,
            AttemptCount = 0,
            CreatedAtUtc = ahoraUtc,
            NextAttemptAtUtc = ahoraUtc
        };

        context.OfflineOperations.Add(operacion);
        context.SaveChanges();

        transaction.Commit();

        return checked(-clienteLocal.LocalCustomerId);
    }

    /// <summary>
    /// Actualiza la caché de clientes que llegó desde SQL Server.
    /// No sobrescribe registros locales todavía pendientes.
    /// </summary>
    public void ActualizarCacheDesdeServidor(
        IReadOnlyCollection<ClienteVentaDto> clientes)
    {
        if (clientes is null)
            return;

        using var context =
            OceanDeskLocalDbContextFactory.CreateContext();

        // La consulta de SQL Server devuelve todos los clientes activos.
        // Si uno ya no aparece, se marca inactivo en la caché para no
        // ofrecerlo durante una futura interrupción de conexión.
        HashSet<int> idsActivosServidor = clientes
            .Select(cliente => cliente.CustomerId)
            .ToHashSet();

        List<LocalCustomer> clientesCacheActivos =
            context.LocalCustomers
                .Where(local =>
                    local.ServerCustomerId != null &&
                    local.IsActive)
                .ToList();

        foreach (LocalCustomer clienteCache in clientesCacheActivos)
        {
            if (!idsActivosServidor.Contains(
                    clienteCache.ServerCustomerId!.Value))
            {
                clienteCache.IsActive = false;
                clienteCache.CachedAtUtc = DateTime.UtcNow;
                clienteCache.SyncStatus = LocalCustomerSyncStatus.Synchronized;
                clienteCache.LastSyncError = null;
            }
        }

        foreach (ClienteVentaDto cliente in clientes)
        {
            LocalCustomer? copia = context.LocalCustomers
                .SingleOrDefault(local =>
                    local.ServerCustomerId == cliente.CustomerId);

            if (copia is null)
            {
                copia = new LocalCustomer
                {
                    ServerCustomerId = cliente.CustomerId,
                    CreatedAtUtc = DateTime.UtcNow,
                    SyncStatus = LocalCustomerSyncStatus.Synchronized
                };

                context.LocalCustomers.Add(copia);
            }

            // Una fila pendiente local nunca debe ser sobrescrita por la caché.
            if (copia.SyncStatus == LocalCustomerSyncStatus.Pending)
                continue;

            copia.FirstName = cliente.FirstName;
            copia.LastName = cliente.LastName;
            copia.Phone = cliente.Phone;
            copia.IsActive = true;
            copia.CachedAtUtc = DateTime.UtcNow;
            copia.SyncStatus = LocalCustomerSyncStatus.Synchronized;
        }

        context.SaveChanges();
    }

    /// <summary>
    /// Devuelve la caché local completa. Los clientes nuevos reciben
    /// un ID temporal negativo; los que ya existen en SQL conservan su ID.
    /// </summary>
    public IReadOnlyList<ClienteVentaDto> ObtenerClientesLocales()
    {
        using var context =
            OceanDeskLocalDbContextFactory.CreateContext();

        return context.LocalCustomers
            .AsNoTracking()
            .Where(customer => customer.IsActive)
            .OrderBy(customer => customer.FirstName)
            .ThenBy(customer => customer.LastName)
            .ToList()
            .Select(customer => new ClienteVentaDto
            {
                CustomerId = customer.ServerCustomerId ??
                             checked(-customer.LocalCustomerId),
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Phone = customer.Phone,
                PendienteSincronizacion =
                    customer.ServerCustomerId is null,
                TieneConflictoSincronizacion =
                    customer.SyncStatus is LocalCustomerSyncStatus.Conflict or
                        LocalCustomerSyncStatus.PermanentError
            })
            .ToList();
    }

    /// <summary>
    /// Devuelve únicamente los clientes que todavía no existen en SQL Server.
    /// </summary>
    public IReadOnlyList<ClienteVentaDto> ObtenerClientesPendientes()
    {
        using var context =
            OceanDeskLocalDbContextFactory.CreateContext();

        return context.LocalCustomers
            .AsNoTracking()
            .Where(customer =>
                customer.IsActive &&
                customer.ServerCustomerId == null)
            .OrderBy(customer => customer.FirstName)
            .ThenBy(customer => customer.LastName)
            .Select(customer => new ClienteVentaDto
            {
                CustomerId = -customer.LocalCustomerId,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Phone = customer.Phone,
                PendienteSincronizacion = true,
                TieneConflictoSincronizacion =
                    customer.SyncStatus == LocalCustomerSyncStatus.Conflict ||
                    customer.SyncStatus == LocalCustomerSyncStatus.PermanentError
            })
            .ToList();
    }

    /// <summary>
    /// Convierte un ID temporal negativo en el ID real de SQL Server.
    /// Devuelve null mientras el registro siga pendiente o en conflicto.
    /// </summary>
    public int? ObtenerIdServidor(int identificadorCliente)
    {
        if (identificadorCliente >= 0)
            return identificadorCliente;

        long idLocal = -(long)identificadorCliente;

        if (idLocal <= 0 || idLocal > int.MaxValue)
            return null;

        using var context =
            OceanDeskLocalDbContextFactory.CreateContext();

        return context.LocalCustomers
            .AsNoTracking()
            .Where(customer => customer.LocalCustomerId == (int)idLocal)
            .Select(customer => customer.ServerCustomerId)
            .SingleOrDefault();
    }

    internal sealed class CustomerCreatePayload
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public DateTime CreatedAtUtc { get; set; }
    }
}
