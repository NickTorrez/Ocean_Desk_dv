using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Ocean_Desk_dv.Data.SQLite;
using Ocean_Desk_dv.Data.SQLite.Entities;
using Ocean_Desk_dv.Models.DTOs;

namespace Ocean_Desk_dv.Services.Offline;

/// <summary>
/// Persiste ventas completas del Punto de Venta cuando SQL Server no está
/// disponible. La venta, su pago, la orden de cocina, el movimiento de caja,
/// la ocupación de la mesa y la operación pendiente se guardan en una sola
/// transacción SQLite.
///
/// El agregado de la venta se conserva como JSON en OfflineOperation para no
/// crear tablas duplicadas de Sale/SaleDetail/KitchenOrder en el esquema local.
/// </summary>
public sealed class OfflinePosSalesStore
{
    public OfflinePosSalesStore()
    {
        LocalDatabaseInitializer.Initialize();
    }

    /// <summary>
    /// Indica si el usuario tiene abierta una caja provisional creada offline.
    /// Se consulta aparte de la caja global de SQL Server para que una caja
    /// provisional no se trate como una caja abierta en el servidor.
    /// </summary>
    public bool TieneCajaProvisionalAbierta(int usuarioId)
    {
        using var context = OceanDeskLocalDbContextFactory.CreateContext();

        return context.LocalCashRegisters.Any(register =>
            register.OpeningUserId == usuarioId &&
            register.Status == "Open" &&
            register.Origin == LocalCashRegisterOrigin.OfflineCreated);
    }

    /// <summary>
    /// Registra una venta provisional local. El ID retornado es negativo para
    /// distinguirlo de los identificadores reales de SQL Server.
    /// </summary>
    public ResultadoVentaDto RegistrarVentaLocal(SolicitudVentaDto solicitud)
    {
        ArgumentNullException.ThrowIfNull(solicitud);

        if (solicitud.UsuarioId <= 0)
        {
            return ResultadoVentaDto.Fallido(
                "No se ha identificado un usuario válido para registrar la venta.",
                "Usuario inválido");
        }

        if (solicitud.Detalles is null || solicitud.Detalles.Count == 0)
        {
            return ResultadoVentaDto.Fallido(
                "El pedido está vacío.",
                "Venta vacía");
        }

        if (solicitud.TipoOrden is not ("Local" or "Delivery"))
        {
            return ResultadoVentaDto.Fallido(
                "Seleccione un tipo de orden válido.",
                "Tipo de orden inválido");
        }

        if (solicitud.TipoOrden == "Local" && !solicitud.MesaId.HasValue)
        {
            return ResultadoVentaDto.Fallido(
                "Seleccione una mesa para una orden local.",
                "Mesa requerida");
        }

        if (solicitud.MetodoPago is not ("Cash" or "Card" or "Transfer"))
        {
            return ResultadoVentaDto.Fallido(
                "Seleccione un método de pago válido.",
                "Método de pago inválido");
        }

        if (solicitud.Detalles.Any(detail =>
                detail.ProductoId <= 0 ||
                detail.Cantidad <= 0 ||
                (detail.Observacion?.Length ?? 0) > 255))
        {
            return ResultadoVentaDto.Fallido(
                "El pedido contiene productos, cantidades u observaciones inválidas.",
                "Datos inválidos");
        }

        using var context = OceanDeskLocalDbContextFactory.CreateContext();
        using var transaction = context.Database.BeginTransaction();

        LocalCashRegister? caja = context.LocalCashRegisters
            .FirstOrDefault(register =>
                register.OpeningUserId == solicitud.UsuarioId &&
                register.Status == "Open");

        if (caja is null)
        {
            return ResultadoVentaDto.Fallido(
                "No existe una caja abierta local para el usuario actual. " +
                "Abra o recupere una caja antes de registrar ventas.",
                "Caja requerida");
        }

        List<int> productIds = solicitud.Detalles
            .Select(detail => detail.ProductoId)
            .Distinct()
            .ToList();

        Dictionary<int, LocalProduct> products = context.LocalProducts
            .Where(product => productIds.Contains(product.ServerProductId))
            .ToDictionary(product => product.ServerProductId);

        if (products.Count != productIds.Count)
        {
            return ResultadoVentaDto.Fallido(
                "Uno o más productos no están disponibles en la caché local. " +
                "Conéctese a SQL Server para actualizar el catálogo.",
                "Producto no disponible");
        }

        List<string> unavailableProducts = products.Values
            .Where(product => !product.IsActive || !product.IsAvailable)
            .Select(product => product.ProductName)
            .ToList();

        if (unavailableProducts.Count > 0)
        {
            return ResultadoVentaDto.Fallido(
                "Los siguientes productos no están disponibles:\n\n" +
                string.Join("\n", unavailableProducts),
                "Producto no disponible");
        }

        LocalCustomer? customer = null;
        if (solicitud.ClienteId.HasValue)
        {
            int customerId = solicitud.ClienteId.Value;

            customer = customerId < 0
                ? context.LocalCustomers.FirstOrDefault(item =>
                    item.LocalCustomerId == checked(-customerId))
                : context.LocalCustomers.FirstOrDefault(item =>
                    item.ServerCustomerId == customerId);

            if (customer is null || !customer.IsActive)
            {
                return ResultadoVentaDto.Fallido(
                    "El cliente seleccionado no se encuentra disponible en la caché local.",
                    "Cliente inválido");
            }
        }

        LocalRestaurantTable? table = null;
        int? tableId = solicitud.TipoOrden == "Delivery"
            ? null
            : solicitud.MesaId;

        if (tableId.HasValue)
        {
            table = context.LocalRestaurantTables.FirstOrDefault(item =>
                item.ServerTableId == tableId.Value && item.IsActive);

            if (table is null)
            {
                return ResultadoVentaDto.Fallido(
                    "La mesa seleccionada no existe o no está activa en la caché local.",
                    "Mesa inválida");
            }

            // Las reservas no se almacenan localmente. Sin conexión no se puede
            // confirmar una reserva atendida; por seguridad solo se asignan
            // mesas que figuraban disponibles en la última caché.
            if (!string.Equals(table.Status, "Available", StringComparison.OrdinalIgnoreCase))
            {
                return ResultadoVentaDto.Fallido(
                    "La mesa seleccionada no figura como disponible en la última " +
                    "información local. Actualice las mesas cuando vuelva la conexión.",
                    "Mesa ocupada");
            }
        }

        decimal subtotal = 0m;
        var details = new List<OfflineSaleDetailPayload>();

        foreach (PuntoVentaDetalleDto requestedDetail in solicitud.Detalles)
        {
            LocalProduct product = products[requestedDetail.ProductoId];
            decimal lineSubtotal = product.UnitPrice * requestedDetail.Cantidad;

            details.Add(new OfflineSaleDetailPayload
            {
                ProductId = product.ServerProductId,
                ProductCode = product.ProductCode,
                ProductName = product.ProductName,
                Quantity = requestedDetail.Cantidad,
                UnitPrice = product.UnitPrice,
                Discount = 0m,
                Subtotal = lineSubtotal,
                Notes = string.IsNullOrWhiteSpace(requestedDetail.Observacion)
                    ? null
                    : requestedDetail.Observacion.Trim()
            });

            subtotal += lineSubtotal;
        }

        const decimal discount = 0m;
        decimal total = subtotal - discount;

        if (total <= 0m)
        {
            return ResultadoVentaDto.Fallido(
                "El total de la venta debe ser mayor que cero.",
                "Total inválido");
        }

        DateTime saleDateTime = DateTime.Now;
        Guid operationId = Guid.NewGuid();
        var movement = new LocalCashMovement
        {
            LocalCashRegisterId = caja.LocalCashRegisterId,
            UserId = solicitud.UsuarioId,
            MovementType = "Sale",
            PaymentMethod = solicitud.MetodoPago,
            Concept = "Venta pendiente de asignar identificador local",
            Amount = total,
            MovementDateTime = saleDateTime,
            Notes = "Venta registrada localmente desde Punto de Venta.",
            SyncStatus = LocalCashSyncStatus.Pending
        };

        context.LocalCashMovements.Add(movement);
        context.SaveChanges();

        // Se utiliza el ID autogenerado del movimiento como base para un ID
        // de venta temporal negativo. No colisiona con IDs positivos del servidor.
        int localSaleId = checked(-movement.LocalCashMovementId);
        movement.Concept = $"Venta local #{Math.Abs((long)localSaleId):0000}";

        var payload = new OfflineSaleCreatePayload
        {
            OperationId = operationId,
            LocalSaleId = localSaleId,
            LocalCashRegisterId = caja.LocalCashRegisterId,
            ServerCashRegisterId = caja.ServerCashRegisterId,
            SaleDateTime = saleDateTime,
            UserId = solicitud.UsuarioId,
            CustomerId = solicitud.ClienteId,
            OrderType = solicitud.TipoOrden,
            TableId = tableId,
            Subtotal = subtotal,
            Discount = discount,
            Total = total,
            Status = "Completed",
            PaymentMethod = solicitud.MetodoPago,
            PaymentAmount = total,
            PaymentDateTime = saleDateTime,
            KitchenReceptionDateTime = saleDateTime,
            KitchenStatus = "Pending",
            KitchenPriority = solicitud.Prioridad == "Alta" ? "Urgent" : "Normal",
            KitchenNotes = "Orden enviada desde Punto de Venta offline.",
            Details = details
        };

        context.OfflineOperations.Add(new OfflineOperation
        {
            OperationId = operationId,
            EntityType = "Sale",
            Action = "Create",
            LocalRecordId = localSaleId,
            PayloadJson = JsonSerializer.Serialize(payload),
            Status = OfflineOperationStatus.Pending,
            AttemptCount = 0,
            CreatedAtUtc = DateTime.UtcNow,
            NextAttemptAtUtc = DateTime.UtcNow
        });

        caja.SyncStatus = LocalCashSyncStatus.Pending;
        caja.CachedAtUtc = DateTime.UtcNow;
        caja.LastSyncError = null;

        if (table is not null)
        {
            table.Status = "Occupied";
            table.CachedAtUtc = DateTime.UtcNow;
        }

        context.SaveChanges();
        transaction.Commit();

        string paymentMethodView = solicitud.MetodoPago switch
        {
            "Cash" => "Efectivo",
            "Card" => "Tarjeta",
            "Transfer" => "Transferencia",
            _ => solicitud.MetodoPago
        };

        return new ResultadoVentaDto
        {
            Exito = true,
            Mensaje = "La venta fue guardada en este dispositivo y queda pendiente " +
                      "de sincronización con SQL Server.",
            Titulo = "Venta guardada localmente",
            EsError = false,
            Total = total,
            MetodoPago = paymentMethodView,
            SaleId = localSaleId
        };
    }

    /// <summary>
    /// Obtiene las mesas que deben seguir bloqueadas porque existe una venta
    /// local pendiente que todavía no ha llegado a SQL Server.
    /// </summary>
    public IReadOnlySet<int> ObtenerMesasConVentasPendientes()
    {
        using var context = OceanDeskLocalDbContextFactory.CreateContext();

        List<string> payloads = context.OfflineOperations
            .AsNoTracking()
            .Where(operation =>
                operation.EntityType == "Sale" &&
                operation.Action == "Create" &&
                (operation.Status == OfflineOperationStatus.Pending ||
                 operation.Status == OfflineOperationStatus.Processing ||
                 operation.Status == OfflineOperationStatus.Retry ||
                 operation.Status == OfflineOperationStatus.Conflict ||
                 operation.Status == OfflineOperationStatus.PermanentError))
            .Select(operation => operation.PayloadJson)
            .ToList();

        var tableIds = new HashSet<int>();

        foreach (string json in payloads)
        {
            try
            {
                using JsonDocument document = JsonDocument.Parse(json);
                JsonElement root = document.RootElement;

                if (root.TryGetProperty(nameof(OfflineSaleCreatePayload.TableId), out JsonElement tableElement) &&
                    tableElement.ValueKind == JsonValueKind.Number &&
                    tableElement.TryGetInt32(out int tableId))
                {
                    tableIds.Add(tableId);
                }
            }
            catch (JsonException)
            {
                // Un payload corrupto no debe impedir que se muestren
                // las demás mesas pendientes.
            }
        }

        return tableIds;
    }
}

/// <summary>
/// Contrato persistido en OfflineOperation para reconstruir en una única
/// transacción SQL Server la venta, el pago, la orden de cocina y su relación
/// con la caja. Se mantiene público para que OfflineSyncService pueda procesarlo.
/// </summary>
public sealed class OfflineSaleCreatePayload
{
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
    public List<OfflineSaleDetailPayload> Details { get; set; } = new();
}

public sealed class OfflineSaleDetailPayload
{
    public int ProductId { get; set; }
    public string ProductCode { get; set; } = string.Empty;
    public string ProductName { get; set; } = string.Empty;
    public decimal Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Discount { get; set; }
    public decimal Subtotal { get; set; }
    public string? Notes { get; set; }
}
