using System.Data;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Ocean_Desk_dv.Data;
using Ocean_Desk_dv.Data.SQLite;
using Ocean_Desk_dv.Data.SQLite.Entities;
using Ocean_Desk_dv.Models.Entities;

namespace Ocean_Desk_dv.Services.Offline;

/// <summary>
/// Procesa las operaciones financieras offline en orden de dependencia:
/// apertura de caja, movimientos, ventas y cierre de caja.
/// Cada escritura remota y su OfflineSyncReceipt se confirman en una sola
/// transacción SQL Server para que un reintento no duplique registros.
/// </summary>
public sealed class OfflineFinancialSyncProcessor
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public static bool EsOperacionSoportada(OfflineOperation operation)
    {
        return (operation.EntityType, operation.Action) switch
        {
            ("CashRegister", "Create") => true,
            ("CashRegister", "Close") => true,
            ("CashMovement", "Create") => true,
            ("Sale", "Create") => true,
            _ => false
        };
    }

    /// <summary>
    /// Materializa en la cola las aperturas, movimientos manuales y cierres
    /// almacenados en SQLite. Se hace aquí para mantener compatibles las cajas
    /// offline creadas antes de incorporar esta etapa de sincronización.
    /// </summary>
    public void PrepararOperacionesPendientes()
    {
        using var context = OceanDeskLocalDbContextFactory.CreateContext();
        using var transaction = context.Database.BeginTransaction();

        List<LocalCashRegister> cajas = context.LocalCashRegisters
            .Where(register =>
                register.SyncStatus == LocalCashSyncStatus.Pending ||
                register.SyncStatus == LocalCashSyncStatus.Conflict ||
                register.SyncStatus == LocalCashSyncStatus.PermanentError)
            .ToList();

        foreach (LocalCashRegister caja in cajas)
        {
            if (caja.Origin == LocalCashRegisterOrigin.OfflineCreated &&
                !caja.ServerCashRegisterId.HasValue)
            {
                AsegurarOperacion(
                    context,
                    "CashRegister",
                    "Create",
                    caja.LocalCashRegisterId,
                    new CashRegisterCreatePayload
                    {
                        LocalCashRegisterId = caja.LocalCashRegisterId,
                        OpeningUserId = caja.OpeningUserId,
                        OpeningDateTime = caja.OpeningDateTime,
                        OpeningAmount = caja.OpeningAmount
                    },
                    ConvertirAUtc(caja.OpeningDateTime));
            }

            if (caja.Status == "Closed" && caja.ClosingDateTime.HasValue)
            {
                AsegurarOperacion(
                    context,
                    "CashRegister",
                    "Close",
                    caja.LocalCashRegisterId,
                    new CashRegisterClosePayload
                    {
                        LocalCashRegisterId = caja.LocalCashRegisterId,
                        ClosingUserId = caja.ClosingUserId ?? caja.OpeningUserId,
                        ClosingDateTime = caja.ClosingDateTime.Value,
                        ExpectedCash = caja.ExpectedCash ?? 0m,
                        ActualCash = caja.ActualCash ?? 0m,
                        Difference = caja.Difference ?? 0m
                    },
                    ConvertirAUtc(caja.ClosingDateTime.Value));
            }
        }

        List<LocalCashMovement> movimientos = context.LocalCashMovements
            .Where(movement =>
                movement.SyncStatus == LocalCashSyncStatus.Pending &&
                movement.MovementType != "Sale")
            .ToList();

        foreach (LocalCashMovement movimiento in movimientos)
        {
            AsegurarOperacion(
                context,
                "CashMovement",
                "Create",
                movimiento.LocalCashMovementId,
                new CashMovementCreatePayload
                {
                    LocalCashMovementId = movimiento.LocalCashMovementId,
                    LocalCashRegisterId = movimiento.LocalCashRegisterId,
                    UserId = movimiento.UserId,
                    MovementType = movimiento.MovementType,
                    PaymentMethod = movimiento.PaymentMethod,
                    Concept = movimiento.Concept,
                    Amount = movimiento.Amount,
                    MovementDateTime = movimiento.MovementDateTime,
                    Reference = movimiento.Reference,
                    Notes = movimiento.Notes
                },
                ConvertirAUtc(movimiento.MovementDateTime));
        }

        context.SaveChanges();
        transaction.Commit();
    }

    private static void AsegurarOperacion<TPayload>(
        OceanDeskLocalDbContext context,
        string entityType,
        string action,
        int localRecordId,
        TPayload payload,
        DateTime createdAtUtc)
    {
        bool yaExiste = context.OfflineOperations.Any(operation =>
            operation.EntityType == entityType &&
            operation.Action == action &&
            operation.LocalRecordId == localRecordId);

        if (yaExiste)
            return;

        DateTime ahoraUtc = DateTime.UtcNow;

        context.OfflineOperations.Add(new OfflineOperation
        {
            OperationId = Guid.NewGuid(),
            EntityType = entityType,
            Action = action,
            LocalRecordId = localRecordId,
            PayloadJson = JsonSerializer.Serialize(payload),
            Status = OfflineOperationStatus.Pending,
            AttemptCount = 0,
            CreatedAtUtc = createdAtUtc,
            NextAttemptAtUtc = ahoraUtc
        });
    }

    public async Task ProcesarAsync(
        OceanDeskLocalDbContext localContext,
        OfflineOperation operation,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(localContext);
        ArgumentNullException.ThrowIfNull(operation);

        switch (operation.EntityType, operation.Action)
        {
            case ("CashRegister", "Create"):
                await SincronizarAperturaAsync(
                    localContext, operation, cancellationToken);
                break;

            case ("CashMovement", "Create"):
                await SincronizarMovimientoAsync(
                    localContext, operation, cancellationToken);
                break;

            case ("Sale", "Create"):
                await SincronizarVentaAsync(
                    localContext, operation, cancellationToken);
                break;

            case ("CashRegister", "Close"):
                await SincronizarCierreAsync(
                    localContext, operation, cancellationToken);
                break;

            default:
                throw new NotSupportedException(
                    $"La operación financiera '{operation.EntityType}/{operation.Action}' no está soportada.");
        }
    }

    private static async Task SincronizarAperturaAsync(
        OceanDeskLocalDbContext localContext,
        OfflineOperation operation,
        CancellationToken cancellationToken)
    {
        CashRegisterCreatePayload payload = Deserializar<CashRegisterCreatePayload>(operation);
        if (payload.LocalCashRegisterId <= 0 ||
            payload.LocalCashRegisterId != operation.LocalRecordId ||
            payload.OpeningUserId <= 0 || payload.OpeningAmount < 0)
            throw new InvalidOperationException("La operación de apertura contiene datos inválidos.");

        using var serverContext = new OceanDeskDbContext();
        await using var transaction = await serverContext.Database.BeginTransactionAsync(
            IsolationLevel.Serializable, cancellationToken);

        OfflineSyncReceipt? receipt = await ObtenerComprobanteAsync(
            serverContext, operation, cancellationToken);

        string serverRecordId;
        if (receipt is not null)
        {
            serverRecordId = ValidarComprobante(receipt, operation);
        }
        else
        {
            bool existeCajaAbierta = await serverContext.CashRegisters
                .AnyAsync(register => register.Status == "Open", cancellationToken);

            if (existeCajaAbierta)
            {
                throw new OfflineSyncDeferredException(
                    "SQL Server tiene otra caja abierta. " +
                    "La apertura local se reintentará cuando esté disponible.");
            }

            var cajaServidor = new CashRegister
            {
                OpeningUserId = payload.OpeningUserId,
                OpeningDateTime = payload.OpeningDateTime,
                OpeningAmount = payload.OpeningAmount,
                Status = "Open"
            };

            serverContext.CashRegisters.Add(cajaServidor);
            await serverContext.SaveChangesAsync(cancellationToken);

            serverRecordId = cajaServidor.CashRegisterId.ToString(CultureInfo.InvariantCulture);
            AgregarComprobante(serverContext, operation, serverRecordId);
            await serverContext.SaveChangesAsync(cancellationToken);
        }

        await transaction.CommitAsync(cancellationToken);

        if (!int.TryParse(serverRecordId, NumberStyles.None, CultureInfo.InvariantCulture, out int serverCashRegisterId) ||
            serverCashRegisterId <= 0)
        {
            throw new InvalidOperationException("El comprobante de apertura contiene un identificador de caja inválido.");
        }

        LocalCashRegister? cajaLocal = await localContext.LocalCashRegisters
            .SingleOrDefaultAsync(register =>
                register.LocalCashRegisterId == payload.LocalCashRegisterId,
                cancellationToken);

        if (cajaLocal is null)
            throw new InvalidOperationException("No se encontró la caja local asociada a la apertura.");

        if (cajaLocal.ServerCashRegisterId.HasValue &&
            cajaLocal.ServerCashRegisterId.Value != serverCashRegisterId)
        {
            throw new OfflineSyncConflictException(
                "La caja local ya está vinculada a un identificador diferente de SQL Server.");
        }

        cajaLocal.ServerCashRegisterId = serverCashRegisterId;
        cajaLocal.SynchronizedAtUtc = DateTime.UtcNow;
        cajaLocal.LastSyncError = null;
        cajaLocal.SyncStatus = cajaLocal.Status == "Closed" ||
                               await TieneMovimientosPendientesAsync(
                                   localContext, cajaLocal.LocalCashRegisterId, cancellationToken)
            ? LocalCashSyncStatus.Pending
            : LocalCashSyncStatus.Synchronized;
    }

    private static async Task SincronizarMovimientoAsync(
        OceanDeskLocalDbContext localContext,
        OfflineOperation operation,
        CancellationToken cancellationToken)
    {
        CashMovementCreatePayload payload = Deserializar<CashMovementCreatePayload>(operation);
        if (payload.LocalCashMovementId <= 0 ||
            payload.LocalCashMovementId != operation.LocalRecordId ||
            payload.LocalCashRegisterId <= 0 ||
            payload.UserId <= 0 || payload.Amount <= 0 ||
            string.IsNullOrWhiteSpace(payload.MovementType) ||
            string.IsNullOrWhiteSpace(payload.PaymentMethod) ||
            string.IsNullOrWhiteSpace(payload.Concept))
        {
            throw new InvalidOperationException("La operación de movimiento contiene datos inválidos.");
        }

        LocalCashRegister cajaLocal = await ObtenerCajaLocalAsync(
            localContext, payload.LocalCashRegisterId, cancellationToken);

        if (!cajaLocal.ServerCashRegisterId.HasValue)
        {
            if (cajaLocal.SyncStatus is LocalCashSyncStatus.Conflict or LocalCashSyncStatus.PermanentError)
                throw new OfflineSyncConflictException("La caja asociada al movimiento no pudo sincronizarse.");

            throw new OfflineSyncDeferredException("El movimiento espera a que se sincronice la apertura de su caja.");
        }

        using var serverContext = new OceanDeskDbContext();
        await using var transaction = await serverContext.Database.BeginTransactionAsync(
            IsolationLevel.Serializable, cancellationToken);

        OfflineSyncReceipt? receipt = await ObtenerComprobanteAsync(
            serverContext, operation, cancellationToken);

        string serverRecordId;
        if (receipt is not null)
        {
            serverRecordId = ValidarComprobante(receipt, operation);
        }
        else
        {
            CashRegister? cajaServidor = await serverContext.CashRegisters
                .SingleOrDefaultAsync(register =>
                    register.CashRegisterId == cajaLocal.ServerCashRegisterId.Value,
                    cancellationToken);

            if (cajaServidor is null || cajaServidor.Status != "Open")
            {
                throw new OfflineSyncConflictException(
                    "La caja vinculada al movimiento ya no existe o está cerrada en SQL Server.");
            }

            var movimiento = new CashMovement
            {
                CashRegisterId = cajaServidor.CashRegisterId,
                UserId = payload.UserId,
                MovementType = payload.MovementType,
                PaymentMethod = payload.PaymentMethod,
                Concept = payload.Concept,
                Amount = payload.Amount,
                MovementDateTime = payload.MovementDateTime,
                Reference = payload.Reference,
                Notes = payload.Notes
            };

            serverContext.CashMovements.Add(movimiento);
            await serverContext.SaveChangesAsync(cancellationToken);

            serverRecordId = movimiento.CashMovementId.ToString(CultureInfo.InvariantCulture);
            AgregarComprobante(serverContext, operation, serverRecordId);
            await serverContext.SaveChangesAsync(cancellationToken);
        }

        await transaction.CommitAsync(cancellationToken);

        if (!int.TryParse(serverRecordId, NumberStyles.None, CultureInfo.InvariantCulture, out int serverMovementId) ||
            serverMovementId <= 0)
        {
            throw new InvalidOperationException("El comprobante del movimiento contiene un identificador inválido.");
        }

        LocalCashMovement? movimientoLocal = await localContext.LocalCashMovements
            .SingleOrDefaultAsync(movement =>
                movement.LocalCashMovementId == payload.LocalCashMovementId,
                cancellationToken);

        if (movimientoLocal is null)
            throw new InvalidOperationException("No se encontró el movimiento local que se está sincronizando.");

        movimientoLocal.ServerCashMovementId = serverMovementId;
        movimientoLocal.SyncStatus = LocalCashSyncStatus.Synchronized;
        movimientoLocal.SynchronizedAtUtc = DateTime.UtcNow;
        movimientoLocal.LastSyncError = null;

        if (cajaLocal.Status == "Open" &&
            !await TieneMovimientosPendientesAsync(localContext, cajaLocal.LocalCashRegisterId, cancellationToken))
        {
            cajaLocal.SyncStatus = LocalCashSyncStatus.Synchronized;
            cajaLocal.SynchronizedAtUtc = DateTime.UtcNow;
            cajaLocal.LastSyncError = null;
        }
    }

    private static async Task SincronizarCierreAsync(
        OceanDeskLocalDbContext localContext,
        OfflineOperation operation,
        CancellationToken cancellationToken)
    {
        CashRegisterClosePayload payload = Deserializar<CashRegisterClosePayload>(operation);
        if (payload.LocalCashRegisterId <= 0 ||
            payload.LocalCashRegisterId != operation.LocalRecordId ||
            payload.ClosingUserId <= 0)
            throw new InvalidOperationException("La operación de cierre contiene datos inválidos.");

        LocalCashRegister cajaLocal = await ObtenerCajaLocalAsync(
            localContext, payload.LocalCashRegisterId, cancellationToken);

        if (!cajaLocal.ServerCashRegisterId.HasValue)
        {
            if (cajaLocal.SyncStatus is LocalCashSyncStatus.Conflict or LocalCashSyncStatus.PermanentError)
                throw new OfflineSyncConflictException("La caja provisional no pudo sincronizar su apertura; el cierre requiere revisión.");

            throw new OfflineSyncDeferredException("El cierre espera a que la apertura de la caja llegue a SQL Server.");
        }

        bool hayMovimientosPendientes = await localContext.LocalCashMovements
            .AnyAsync(movement =>
                movement.LocalCashRegisterId == cajaLocal.LocalCashRegisterId &&
                (movement.SyncStatus == LocalCashSyncStatus.Pending ||
                 movement.SyncStatus == LocalCashSyncStatus.Conflict ||
                 movement.SyncStatus == LocalCashSyncStatus.PermanentError),
                cancellationToken);

        if (hayMovimientosPendientes)
        {
            bool hayConflicto = await localContext.LocalCashMovements
                .AnyAsync(movement =>
                    movement.LocalCashRegisterId == cajaLocal.LocalCashRegisterId &&
                    (movement.SyncStatus == LocalCashSyncStatus.Conflict ||
                     movement.SyncStatus == LocalCashSyncStatus.PermanentError),
                    cancellationToken);

            if (hayConflicto)
                throw new OfflineSyncConflictException("El cierre no puede aplicarse porque hay movimientos de caja sin resolver.");

            throw new OfflineSyncDeferredException("El cierre espera a que todos los movimientos de la caja se sincronicen.");
        }

        using var serverContext = new OceanDeskDbContext();
        await using var transaction = await serverContext.Database.BeginTransactionAsync(
            IsolationLevel.Serializable, cancellationToken);

        OfflineSyncReceipt? receipt = await ObtenerComprobanteAsync(
            serverContext, operation, cancellationToken);

        string serverRecordId;
        if (receipt is not null)
        {
            serverRecordId = ValidarComprobante(receipt, operation);
        }
        else
        {
            CashRegister? cajaServidor = await serverContext.CashRegisters
                .SingleOrDefaultAsync(register =>
                    register.CashRegisterId == cajaLocal.ServerCashRegisterId.Value,
                    cancellationToken);

            if (cajaServidor is null || cajaServidor.Status != "Open")
            {
                throw new OfflineSyncConflictException(
                    "La caja ya fue cerrada o dejó de existir en SQL Server antes de sincronizar el cierre local.");
            }

            cajaServidor.ClosingDateTime = payload.ClosingDateTime;
            cajaServidor.ExpectedCash = payload.ExpectedCash;
            cajaServidor.ActualCash = payload.ActualCash;
            cajaServidor.Difference = payload.Difference;
            cajaServidor.ClosingUserId = payload.ClosingUserId;
            cajaServidor.Status = "Closed";

            await serverContext.SaveChangesAsync(cancellationToken);

            serverRecordId = cajaServidor.CashRegisterId.ToString(CultureInfo.InvariantCulture);
            AgregarComprobante(serverContext, operation, serverRecordId);
            await serverContext.SaveChangesAsync(cancellationToken);
        }

        await transaction.CommitAsync(cancellationToken);

        if (!int.TryParse(serverRecordId, NumberStyles.None, CultureInfo.InvariantCulture, out int serverCashRegisterId) ||
            serverCashRegisterId != cajaLocal.ServerCashRegisterId.Value)
        {
            throw new InvalidOperationException("El comprobante del cierre no coincide con la caja local.");
        }

        cajaLocal.SyncStatus = LocalCashSyncStatus.Synchronized;
        cajaLocal.SynchronizedAtUtc = DateTime.UtcNow;
        cajaLocal.LastSyncError = null;
    }

    private static async Task SincronizarVentaAsync(
        OceanDeskLocalDbContext localContext,
        OfflineOperation operation,
        CancellationToken cancellationToken)
    {
        SaleCreatePayload payload = Deserializar<SaleCreatePayload>(operation);
        if (payload.OperationId != operation.OperationId ||
            payload.LocalSaleId >= 0 ||
            payload.LocalSaleId != operation.LocalRecordId ||
            payload.LocalCashRegisterId <= 0 ||
            payload.UserId <= 0 ||
            payload.Details is null || payload.Details.Count == 0 ||
            payload.Total <= 0 ||
            payload.OrderType is not ("Local" or "Delivery") ||
            payload.PaymentMethod is not ("Cash" or "Card" or "Transfer") ||
            payload.PaymentAmount != payload.Total ||
            payload.Details.Any(detail => detail.ProductId <= 0 || detail.Quantity <= 0 ||
                detail.UnitPrice < 0 || detail.Subtotal < 0))
        {
            throw new InvalidOperationException("El contenido de la venta offline está incompleto o no coincide con su operación.");
        }

        LocalCashRegister cajaLocal = await ObtenerCajaLocalAsync(
            localContext, payload.LocalCashRegisterId, cancellationToken);

        using var serverContext = new OceanDeskDbContext();
        await using var transaction = await serverContext.Database.BeginTransactionAsync(
            IsolationLevel.Serializable, cancellationToken);

        OfflineSyncReceipt? receipt = await ObtenerComprobanteAsync(
            serverContext, operation, cancellationToken);

        string serverRecordId;
        if (receipt is not null)
        {
            serverRecordId = ValidarComprobante(receipt, operation);
        }
        else
        {
            if (!cajaLocal.ServerCashRegisterId.HasValue)
            {
                if (cajaLocal.SyncStatus is LocalCashSyncStatus.Conflict or LocalCashSyncStatus.PermanentError)
                    throw new OfflineSyncConflictException("La caja asociada a la venta no pudo sincronizarse.");

                throw new OfflineSyncDeferredException("La venta espera a que se sincronice la apertura de la caja.");
            }

            CashRegister? cajaServidor = await serverContext.CashRegisters
                .SingleOrDefaultAsync(register =>
                    register.CashRegisterId == cajaLocal.ServerCashRegisterId.Value,
                    cancellationToken);

            if (cajaServidor is null || cajaServidor.Status != "Open")
            {
                throw new OfflineSyncConflictException(
                    "La caja asociada a la venta ya no está abierta en SQL Server.");
            }

            int? customerId = await ResolverClienteServidorAsync(
                localContext, payload.CustomerId, cancellationToken);

            if (customerId.HasValue &&
                !await serverContext.Customers.AnyAsync(customer =>
                    customer.CustomerId == customerId.Value && customer.IsActive,
                    cancellationToken))
            {
                throw new OfflineSyncConflictException("El cliente de la venta ya no existe o está inactivo en SQL Server.");
            }

            List<int> productIds = payload.Details
                .Select(detail => detail.ProductId)
                .Distinct()
                .ToList();

            List<Product> productos = await serverContext.Products
                .Where(product => productIds.Contains(product.ProductId))
                .ToListAsync(cancellationToken);

            if (productos.Count != productIds.Count)
                throw new OfflineSyncConflictException("Uno o más productos de la venta ya no existen en SQL Server.");

            List<string> productosInactivos = productos
                .Where(product => !product.IsActive || !product.IsAvailable)
                .Select(product => product.ProductName)
                .ToList();

            if (productosInactivos.Count > 0)
            {
                throw new OfflineSyncConflictException(
                    "Hay productos de la venta que dejaron de estar disponibles: " +
                    string.Join(", ", productosInactivos));
            }

            TableRestaurant? mesa = null;
            if (payload.OrderType == "Local")
            {
                if (!payload.TableId.HasValue)
                    throw new OfflineSyncConflictException("La venta local no contiene una mesa válida.");

                mesa = await serverContext.TableRestaurants
                    .SingleOrDefaultAsync(table =>
                        table.TableId == payload.TableId.Value && table.IsActive,
                        cancellationToken);

                if (mesa is null || mesa.Status != "Available")
                    throw new OfflineSyncConflictException("La mesa de la venta ya no está disponible en SQL Server.");
            }

            var detallesVenta = payload.Details.Select(detail => new SaleDetail
            {
                ProductId = detail.ProductId,
                Quantity = detail.Quantity,
                UnitPrice = detail.UnitPrice,
                Discount = detail.Discount,
                Subtotal = detail.Subtotal,
                Notes = detail.Notes
            }).ToList();

            var venta = new Sale
            {
                SaleDateTime = payload.SaleDateTime,
                UserId = payload.UserId,
                CustomerId = customerId,
                OrderType = payload.OrderType,
                TableId = payload.OrderType == "Delivery" ? null : payload.TableId,
                Subtotal = payload.Subtotal,
                Discount = payload.Discount,
                Total = payload.Total,
                Status = payload.Status,
                Notes = "Venta sincronizada desde una operación offline.",
                SaleDetails = detallesVenta
            };

            var pago = new SalePayment
            {
                Sale = venta,
                PaymentMethod = payload.PaymentMethod,
                Amount = payload.PaymentAmount,
                PaymentDateTime = payload.PaymentDateTime
            };

            var ordenCocina = new KitchenOrder
            {
                Sale = venta,
                ReceptionDateTime = payload.KitchenReceptionDateTime,
                PreparationStartDateTime = null,
                ReadyDateTime = null,
                DeliveredDateTime = null,
                Status = payload.KitchenStatus,
                Priority = payload.KitchenPriority,
                Notes = payload.KitchenNotes
            };

            foreach (SaleDetail detalle in detallesVenta)
            {
                ordenCocina.KitchenOrderDetails.Add(new KitchenOrderDetail
                {
                    KitchenOrder = ordenCocina,
                    SaleDetail = detalle,
                    ProductId = detalle.ProductId,
                    Quantity = detalle.Quantity,
                    Notes = detalle.Notes
                });
            }

            serverContext.Sales.Add(venta);
            serverContext.SalePayments.Add(pago);
            serverContext.KitchenOrders.Add(ordenCocina);

            if (mesa is not null)
                mesa.Status = "Occupied";

            await serverContext.SaveChangesAsync(cancellationToken);

            var movimientoVenta = new CashMovement
            {
                CashRegisterId = cajaServidor.CashRegisterId,
                SaleId = venta.SaleId,
                UserId = payload.UserId,
                MovementType = "Sale",
                PaymentMethod = payload.PaymentMethod,
                Concept = $"Venta #{venta.SaleId:0000}",
                Amount = payload.Total,
                MovementDateTime = payload.PaymentDateTime,
                Notes = "Movimiento generado al sincronizar una venta offline."
            };

            serverContext.CashMovements.Add(movimientoVenta);
            await serverContext.SaveChangesAsync(cancellationToken);

            serverRecordId = string.Concat(
                venta.SaleId.ToString(CultureInfo.InvariantCulture),
                ":",
                movimientoVenta.CashMovementId.ToString(CultureInfo.InvariantCulture));

            AgregarComprobante(serverContext, operation, serverRecordId);
            await serverContext.SaveChangesAsync(cancellationToken);
        }

        await transaction.CommitAsync(cancellationToken);

        string[] ids = serverRecordId.Split(':');
        if (ids.Length != 2 ||
            !int.TryParse(ids[0], NumberStyles.None, CultureInfo.InvariantCulture, out int serverSaleId) ||
            !int.TryParse(ids[1], NumberStyles.None, CultureInfo.InvariantCulture, out int serverMovementId) ||
            serverSaleId <= 0 || serverMovementId <= 0)
        {
            throw new InvalidOperationException("El comprobante de la venta contiene identificadores inválidos.");
        }

        if (operation.LocalRecordId >= 0 || operation.LocalRecordId == int.MinValue)
            throw new InvalidOperationException("El identificador local de la venta no tiene el formato esperado.");

        int localMovementId = checked(-operation.LocalRecordId);
        LocalCashMovement? movimientoLocal = await localContext.LocalCashMovements
            .SingleOrDefaultAsync(movement =>
                movement.LocalCashMovementId == localMovementId,
                cancellationToken);

        if (movimientoLocal is null)
            throw new InvalidOperationException("No se encontró el movimiento local asociado a la venta offline.");

        movimientoLocal.ServerCashMovementId = serverMovementId;
        movimientoLocal.SyncStatus = LocalCashSyncStatus.Synchronized;
        movimientoLocal.SynchronizedAtUtc = DateTime.UtcNow;
        movimientoLocal.LastSyncError = null;

        if (cajaLocal.Status == "Open" &&
            !await TieneMovimientosPendientesAsync(localContext, cajaLocal.LocalCashRegisterId, cancellationToken))
        {
            cajaLocal.SyncStatus = LocalCashSyncStatus.Synchronized;
            cajaLocal.SynchronizedAtUtc = DateTime.UtcNow;
            cajaLocal.LastSyncError = null;
        }
    }

    private static async Task<int?> ResolverClienteServidorAsync(
        OceanDeskLocalDbContext localContext,
        int? customerId,
        CancellationToken cancellationToken)
    {
        if (!customerId.HasValue || customerId.Value > 0)
            return customerId;

        if (customerId.Value == int.MinValue)
            throw new OfflineSyncConflictException("El identificador temporal del cliente es inválido.");

        int localCustomerId = -customerId.Value;
        LocalCustomer? cliente = await localContext.LocalCustomers
            .AsNoTracking()
            .SingleOrDefaultAsync(customer =>
                customer.LocalCustomerId == localCustomerId,
                cancellationToken);

        if (cliente is null || !cliente.IsActive)
            throw new OfflineSyncConflictException("El cliente temporal vinculado a la venta no existe o está inactivo localmente.");

        if (cliente.SyncStatus is LocalCustomerSyncStatus.Conflict or LocalCustomerSyncStatus.PermanentError)
            throw new OfflineSyncConflictException("El cliente temporal de la venta tiene un conflicto de sincronización.");

        if (!cliente.ServerCustomerId.HasValue)
            throw new OfflineSyncDeferredException("La venta espera a que se sincronice primero el cliente nuevo.");

        return cliente.ServerCustomerId.Value;
    }

    private static async Task<LocalCashRegister> ObtenerCajaLocalAsync(
        OceanDeskLocalDbContext localContext,
        int localCashRegisterId,
        CancellationToken cancellationToken)
    {
        LocalCashRegister? caja = await localContext.LocalCashRegisters
            .SingleOrDefaultAsync(register =>
                register.LocalCashRegisterId == localCashRegisterId,
                cancellationToken);

        return caja ?? throw new OfflineSyncConflictException(
            "La caja local asociada a la operación ya no existe.");
    }

    private static async Task<bool> TieneMovimientosPendientesAsync(
        OceanDeskLocalDbContext localContext,
        int localCashRegisterId,
        CancellationToken cancellationToken)
    {
        return await localContext.LocalCashMovements.AnyAsync(movement =>
            movement.LocalCashRegisterId == localCashRegisterId &&
            (movement.SyncStatus == LocalCashSyncStatus.Pending ||
             movement.SyncStatus == LocalCashSyncStatus.Conflict ||
             movement.SyncStatus == LocalCashSyncStatus.PermanentError),
            cancellationToken);
    }

    private static async Task<OfflineSyncReceipt?> ObtenerComprobanteAsync(
        OceanDeskDbContext serverContext,
        OfflineOperation operation,
        CancellationToken cancellationToken)
    {
        OfflineSyncReceipt? receipt = await serverContext.OfflineSyncReceipts
            .SingleOrDefaultAsync(item =>
                item.OperationId == operation.OperationId,
                cancellationToken);

        if (receipt is not null)
            _ = ValidarComprobante(receipt, operation);

        return receipt;
    }

    private static string ValidarComprobante(
        OfflineSyncReceipt receipt,
        OfflineOperation operation)
    {
        string expectedHash = CalcularHash(operation.PayloadJson);

        if (!string.Equals(receipt.EntityType, operation.EntityType, StringComparison.Ordinal) ||
            !string.Equals(receipt.PayloadHash, expectedHash, StringComparison.OrdinalIgnoreCase))
        {
            throw new OfflineSyncConflictException(
                "El identificador de operación ya existe en SQL Server, pero el tipo o contenido no coincide con la operación local.");
        }

        return receipt.ServerRecordId;
    }

    private static void AgregarComprobante(
        OceanDeskDbContext serverContext,
        OfflineOperation operation,
        string serverRecordId)
    {
        serverContext.OfflineSyncReceipts.Add(new OfflineSyncReceipt
        {
            OperationId = operation.OperationId,
            EntityType = operation.EntityType,
            ServerRecordId = serverRecordId,
            PayloadHash = CalcularHash(operation.PayloadJson),
            ProcessedAtUtc = DateTime.UtcNow
        });
    }

    private static TPayload Deserializar<TPayload>(OfflineOperation operation)
        where TPayload : class
    {
        TPayload? payload;
        try
        {
            payload = JsonSerializer.Deserialize<TPayload>(operation.PayloadJson, JsonOptions);
        }
        catch (JsonException exception)
        {
            throw new InvalidOperationException(
                $"El contenido de la operación '{operation.EntityType}/{operation.Action}' no es un JSON válido.",
                exception);
        }

        return payload ?? throw new InvalidOperationException(
            $"La operación '{operation.EntityType}/{operation.Action}' no contiene datos.");
    }

    private static string CalcularHash(string payload)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(payload);
        byte[] hash = SHA256.HashData(bytes);
        return Convert.ToHexString(hash);
    }

    private static DateTime ConvertirAUtc(DateTime value)
    {
        return value.Kind switch
        {
            DateTimeKind.Utc => value,
            DateTimeKind.Local => value.ToUniversalTime(),
            _ => DateTime.SpecifyKind(value, DateTimeKind.Local).ToUniversalTime()
        };
    }

    public static void MarcarRegistroLocalConError(
        OceanDeskLocalDbContext context,
        OfflineOperation operation,
        string error,
        bool conflicto)
    {
        string mensaje = error.Length <= 2000 ? error : error[..2000];
        LocalCashSyncStatus estado = conflicto
            ? LocalCashSyncStatus.Conflict
            : LocalCashSyncStatus.PermanentError;

        if (operation.EntityType == "CashRegister")
        {
            LocalCashRegister? caja = context.LocalCashRegisters
                .SingleOrDefault(register => register.LocalCashRegisterId == operation.LocalRecordId);

            if (caja is not null)
            {
                caja.SyncStatus = estado;
                caja.LastSyncError = mensaje;
            }

            return;
        }

        int localMovementId = operation.EntityType == "Sale"
            ? operation.LocalRecordId == int.MinValue ? 0 : -operation.LocalRecordId
            : operation.LocalRecordId;

        if (localMovementId <= 0)
            return;

        LocalCashMovement? movimiento = context.LocalCashMovements
            .SingleOrDefault(item => item.LocalCashMovementId == localMovementId);

        if (movimiento is null)
            return;

        movimiento.SyncStatus = estado;
        movimiento.LastSyncError = mensaje;

        LocalCashRegister? cajaPadre = context.LocalCashRegisters
            .SingleOrDefault(register => register.LocalCashRegisterId == movimiento.LocalCashRegisterId);

        if (cajaPadre is not null)
        {
            cajaPadre.SyncStatus = estado;
            cajaPadre.LastSyncError = mensaje;
        }
    }

    private sealed class CashRegisterCreatePayload
    {
        public CashRegisterCreatePayload() { }
        public int LocalCashRegisterId { get; set; }
        public int OpeningUserId { get; set; }
        public DateTime OpeningDateTime { get; set; }
        public decimal OpeningAmount { get; set; }
    }

    private sealed class CashRegisterClosePayload
    {
        public CashRegisterClosePayload() { }
        public int LocalCashRegisterId { get; set; }
        public int ClosingUserId { get; set; }
        public DateTime ClosingDateTime { get; set; }
        public decimal ExpectedCash { get; set; }
        public decimal ActualCash { get; set; }
        public decimal Difference { get; set; }
    }

    private sealed class CashMovementCreatePayload
    {
        public CashMovementCreatePayload() { }
        public int LocalCashMovementId { get; set; }
        public int LocalCashRegisterId { get; set; }
        public int UserId { get; set; }
        public string MovementType { get; set; } = string.Empty;
        public string PaymentMethod { get; set; } = string.Empty;
        public string Concept { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public DateTime MovementDateTime { get; set; }
        public string? Reference { get; set; }
        public string? Notes { get; set; }
    }

    private sealed class SaleCreatePayload
    {
        public SaleCreatePayload() { }
        public Guid OperationId { get; set; }
        public int LocalSaleId { get; set; }
        public int LocalCashRegisterId { get; set; }
        public int? ServerCashRegisterId { get; set; }
        public DateTime SaleDateTime { get; set; }
        public int UserId { get; set; }
        public int? CustomerId { get; set; }
        public string OrderType { get; set; } = string.Empty;
        public int? TableId { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
        public string Status { get; set; } = "Completed";
        public string PaymentMethod { get; set; } = string.Empty;
        public decimal PaymentAmount { get; set; }
        public DateTime PaymentDateTime { get; set; }
        public DateTime KitchenReceptionDateTime { get; set; }
        public string KitchenStatus { get; set; } = "Pending";
        public string KitchenPriority { get; set; } = "Normal";
        public string? KitchenNotes { get; set; }
        public List<SaleDetailCreatePayload> Details { get; set; } = new();
    }

    private sealed class SaleDetailCreatePayload
    {
        public SaleDetailCreatePayload() { }
        public int ProductId { get; set; }
        public string ProductCode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal Subtotal { get; set; }
        public string? Notes { get; set; }
    }
}

/// <summary>
/// Indica que una operación depende de otra que todavía no ha terminado.
/// Se programa un reintento; no se convierte en conflicto ni error permanente.
/// </summary>
public sealed class OfflineSyncDeferredException : Exception
{
    public OfflineSyncDeferredException(string message) : base(message)
    {
    }
}
