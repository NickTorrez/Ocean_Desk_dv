using Microsoft.EntityFrameworkCore;
using Ocean_Desk_dv.Data;
using Ocean_Desk_dv.Models.DTOs;
using Ocean_Desk_dv.Models.Entities;
using Ocean_Desk_dv.Services.Interfaces_Services;
using Ocean_Desk_dv.Services.Offline;

namespace Ocean_Desk_dv.Services.Repository;

public sealed class PuntoVentaRepository : IPuntoVentaRepository
{
    private readonly OceanDeskDbContext _context;
    private readonly OfflineCustomerStore _offlineCustomerStore;
    private readonly OfflinePosReferenceStore _offlinePosReferenceStore;
    private readonly OfflineCashRegisterStore _offlineCashRegisterStore;
    private readonly OfflinePosSalesStore _offlinePosSalesStore;

    public PuntoVentaRepository(
        OceanDeskDbContext context,
        OfflineCustomerStore? offlineCustomerStore = null,
        OfflinePosReferenceStore? offlinePosReferenceStore = null,
        OfflineCashRegisterStore? offlineCashRegisterStore = null,
        OfflinePosSalesStore? offlinePosSalesStore = null)
    {
        _context = context ??
            throw new ArgumentNullException(nameof(context));

        _offlineCustomerStore = offlineCustomerStore ??
            new OfflineCustomerStore();

        _offlinePosReferenceStore = offlinePosReferenceStore ??
            new OfflinePosReferenceStore();

        _offlineCashRegisterStore = offlineCashRegisterStore ??
            new OfflineCashRegisterStore();

        _offlinePosSalesStore = offlinePosSalesStore ??
            new OfflinePosSalesStore();
    }

    public IReadOnlyList<ProductoVentaDto> ObtenerCatalogoDisponible()
    {
        try
        {
            List<ProductoVentaDto> productosServidor = _context.Products
                .AsNoTracking()
                .Include(product => product.ProductCategory)
                .Where(product =>
                    product.IsActive &&
                    product.ProductType == "FinishedProduct")
                .OrderBy(product => product.ProductCategory.CategoryName)
                .ThenBy(product => product.ProductName)
                .Select(product => new ProductoVentaDto
                {
                    ProductId = product.ProductId,
                    ProductCode = product.ProductCode,
                    ProductName = product.ProductName,
                    UnitPrice = product.UnitPrice,
                    IsAvailable = product.IsAvailable,
                    IsActive = product.IsActive,
                    CategoryName = product.ProductCategory.CategoryName
                })
                .ToList();

            try
            {
                _offlinePosReferenceStore.ActualizarCatalogoDesdeServidor(
                    productosServidor);

                return _offlinePosReferenceStore.ObtenerCatalogoLocal();
            }
            catch (Exception cacheException)
            {
                System.Diagnostics.Debug.WriteLine(
                    $"No fue posible actualizar la caché de productos: {cacheException}");

                return productosServidor;
            }
        }
        catch (Exception ex) when (
            SqlServerConnectionFailureDetector.IsConnectionFailure(ex))
        {
            _context.ChangeTracker.Clear();
            return _offlinePosReferenceStore.ObtenerCatalogoLocal();
        }
    }

    public IReadOnlyList<ClienteVentaDto> ObtenerClientesActivos()
    {
        try
        {
            List<ClienteVentaDto> clientesServidor = _context.Customers
                .AsNoTracking()
                .Where(customer => customer.IsActive)
                .OrderBy(customer => customer.FirstName)
                .ThenBy(customer => customer.LastName)
                .Select(customer => new ClienteVentaDto
                {
                    CustomerId = customer.CustomerId,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Phone = customer.Phone
                })
                .ToList();

            try
            {
                _offlineCustomerStore.ActualizarCacheDesdeServidor(
                    clientesServidor);

                return _offlineCustomerStore.ObtenerClientesLocales();
            }
            catch (Exception cacheException)
            {
                System.Diagnostics.Debug.WriteLine(
                    $"No fue posible actualizar la caché local de clientes: {cacheException}");

                return clientesServidor;
            }
        }
        catch (Exception ex) when (
            SqlServerConnectionFailureDetector.IsConnectionFailure(ex))
        {
            _context.ChangeTracker.Clear();
            return _offlineCustomerStore.ObtenerClientesLocales();
        }
    }

    public IReadOnlyList<MesaDto> ObtenerMesasDisponibles()
    {
        try
        {
            List<MesaDto> mesasServidor = _context.TableRestaurants
                .AsNoTracking()
                .Where(table => table.IsActive)
                .OrderBy(table => table.TableNumber)
                .Select(table => new MesaDto
                {
                    TableId = table.TableId,
                    TableNumber = table.TableNumber,
                    Capacity = table.Capacity,
                    Status = table.Status,
                    IsActive = table.IsActive
                })
                .ToList();

            try
            {
                _offlinePosReferenceStore.ActualizarMesasDesdeServidor(
                    mesasServidor);

                return FiltrarMesasConVentasPendientes(
                    _offlinePosReferenceStore.ObtenerMesasDisponiblesLocales());
            }
            catch (Exception cacheException)
            {
                System.Diagnostics.Debug.WriteLine(
                    $"No fue posible actualizar la caché de mesas: {cacheException}");

                return FiltrarMesasConVentasPendientes(
                    mesasServidor
                        .Where(table => table.Status == "Available")
                        .ToList());
            }
        }
        catch (Exception ex) when (
            SqlServerConnectionFailureDetector.IsConnectionFailure(ex))
        {
            _context.ChangeTracker.Clear();

            return FiltrarMesasConVentasPendientes(
                _offlinePosReferenceStore.ObtenerMesasDisponiblesLocales());
        }
    }

    public ReservaOperacionDto? ObtenerReservaAtendidaCliente(
        int clienteId,
        DateOnly fecha)
    {
        // Los clientes locales tienen IDs negativos y no pueden tener una
        // reserva consultable en SQL Server hasta que se sincronicen.
        if (clienteId <= 0)
            return null;

        try
        {
            var db = _context;

            return (from reservation in db.Reservations.AsNoTracking()
                    join customer in db.Customers.AsNoTracking()
                        on reservation.CustomerId equals customer.CustomerId
                    join table in db.TableRestaurants.AsNoTracking()
                        on reservation.TableId equals table.TableId into tables
                    from currentTable in tables
                        .Where(item => item.IsActive)
                        .DefaultIfEmpty()
                    where reservation.CustomerId == clienteId &&
                          reservation.ReservationDate == fecha &&
                          reservation.Status == "Attended" &&
                          reservation.TableId.HasValue
                    orderby reservation.ReservationTime
                    select new ReservaOperacionDto
                    {
                        ReservationId = reservation.ReservationId,
                        CustomerId = reservation.CustomerId,
                        TableId = reservation.TableId,
                        ReservationDate = reservation.ReservationDate,
                        ReservationTime = reservation.ReservationTime,
                        GuestCount = reservation.GuestCount,
                        Status = reservation.Status,
                        CustomerName = (customer.FirstName + " " + customer.LastName).Trim(),
                        TableNumber = currentTable != null
                            ? (int?)currentTable.TableNumber
                            : null
                    }).FirstOrDefault();
        }
        catch (Exception ex) when (
            SqlServerConnectionFailureDetector.IsConnectionFailure(ex))
        {
            _context.ChangeTracker.Clear();
            // No existe caché local de reservas. Sin conexión no se asigna
            // una mesa automáticamente; el usuario deberá elegir una mesa
            // que figure disponible en la última caché.
            return null;
        }
    }

    public bool ExisteTelefonoClienteActivo(string telefono)
    {
        try
        {
            return _context.Customers.Any(customer =>
                customer.IsActive &&
                customer.Phone != null &&
                customer.Phone == telefono);
        }
        catch (Exception ex) when (
            SqlServerConnectionFailureDetector.IsConnectionFailure(ex))
        {
            _context.ChangeTracker.Clear();
            return _offlineCustomerStore.ExisteTelefonoActivoLocal(telefono);
        }
    }

    public ResultadoOperacionDto RegistrarCliente(
        string nombre,
        string apellido,
        string telefono,
        out int clienteId)
    {
        clienteId = 0;

        try
        {
            bool existeCliente = _context.Customers.Any(customer =>
                customer.IsActive &&
                customer.Phone != null &&
                customer.Phone == telefono);

            if (existeCliente)
            {
                return ResultadoOperacionDto.Fallido(
                    "Ya existe un cliente activo registrado con ese teléfono.");
            }

            var customer = new Customer
            {
                FirstName = nombre.Trim(),
                LastName = apellido.Trim(),
                Phone = telefono.Trim(),
                IsActive = true,
                CreatedAt = DateTime.Now
            };

            _context.Customers.Add(customer);
            _context.SaveChanges();

            clienteId = customer.CustomerId;

            return ResultadoOperacionDto.Correcto(
                $"El cliente {customer.FirstName} {customer.LastName} " +
                "fue registrado correctamente.");
        }
        catch (Exception ex) when (
            SqlServerConnectionFailureDetector.IsConnectionFailure(ex))
        {
            _context.ChangeTracker.Clear();

            try
            {
                clienteId = _offlineCustomerStore.RegistrarClienteLocal(
                    nombre,
                    apellido,
                    telefono);

                return ResultadoOperacionDto.Correcto(
                    $"El cliente {nombre} {apellido} fue guardado localmente. " +
                    "Su información queda pendiente de sincronización con SQL Server.");
            }
            catch (InvalidOperationException localException)
            {
                return ResultadoOperacionDto.Fallido(localException.Message);
            }
        }
    }

    public bool TieneCajaAbierta(int usuarioId)
    {
        try
        {
            CashRegister? cajaServidor = _context.CashRegisters
                .AsNoTracking()
                .Where(register => register.Status == "Open")
                .OrderByDescending(register => register.OpeningDateTime)
                .FirstOrDefault();

            if (cajaServidor is null)
            {
                _offlineCashRegisterStore.MarcarCajasServidorCerradas();
                return _offlineCashRegisterStore.TieneCajaAbiertaParaUsuario(
                    usuarioId);
            }

            if (cajaServidor.OpeningUserId != usuarioId)
                return false;

            GuardarSnapshotCaja(cajaServidor);
            return true;
        }
        catch (Exception ex) when (
            SqlServerConnectionFailureDetector.IsConnectionFailure(ex))
        {
            _context.ChangeTracker.Clear();
            return _offlineCashRegisterStore.TieneCajaAbiertaParaUsuario(
                usuarioId);
        }
    }

    public ResultadoVentaDto RegistrarVenta(SolicitudVentaDto solicitud)
    {
        ArgumentNullException.ThrowIfNull(solicitud);

        if (solicitud.UsuarioId <= 0)
        {
            return ResultadoVentaDto.Fallido(
                "No se ha identificado un usuario válido para registrar la venta.",
                "Usuario inválido");
        }

        try
        {
            CashRegister? cajaServidor = _context.CashRegisters
                .AsNoTracking()
                .Where(register => register.Status == "Open")
                .OrderByDescending(register => register.OpeningDateTime)
                .FirstOrDefault();

            if (cajaServidor is null)
            {
                _offlineCashRegisterStore.MarcarCajasServidorCerradas();

                // Si el servidor está disponible pero la caja es provisional,
                // la venta debe permanecer local junto con esa caja.
                if (_offlinePosSalesStore.TieneCajaProvisionalAbierta(
                        solicitud.UsuarioId))
                {
                    return _offlinePosSalesStore.RegistrarVentaLocal(solicitud);
                }

                return ResultadoVentaDto.Fallido(
                    "No puede registrar la venta porque no existe una caja abierta " +
                    "para el usuario actual. Realice la apertura de caja antes de continuar.",
                    "Caja requerida");
            }

            if (cajaServidor.OpeningUserId != solicitud.UsuarioId)
            {
                return ResultadoVentaDto.Fallido(
                    "La caja abierta pertenece a otro usuario. No es posible registrar " +
                    "la venta con esta sesión.",
                    "Caja de otro usuario");
            }

            GuardarSnapshotCaja(cajaServidor);

            // Un cliente creado localmente todavía no tiene FK real en SQL
            // Server. La venta permanece local para sincronizarse después
            // de que el cliente obtenga su identificador definitivo.
            if (solicitud.ClienteId.HasValue && solicitud.ClienteId.Value < 0)
                return _offlinePosSalesStore.RegistrarVentaLocal(solicitud);

            return RegistrarVentaEnServidor(solicitud, cajaServidor.CashRegisterId);
        }
        catch (Exception ex) when (
            SqlServerConnectionFailureDetector.IsConnectionFailure(ex))
        {
            // La excepción sucede antes de confirmar el COMMIT. El método
            // RegistrarVentaEnServidor captura por separado una pérdida de
            // conexión durante Commit porque su resultado sería incierto.
            _context.ChangeTracker.Clear();
            return _offlinePosSalesStore.RegistrarVentaLocal(solicitud);
        }
    }

    private ResultadoVentaDto RegistrarVentaEnServidor(
        SolicitudVentaDto solicitud,
        int cashRegisterId)
    {
        var db = _context;

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

        bool cajaContinuaAbierta = db.CashRegisters.Any(register =>
            register.CashRegisterId == cashRegisterId &&
            register.OpeningUserId == solicitud.UsuarioId &&
            register.Status == "Open");

        if (!cajaContinuaAbierta)
        {
            return ResultadoVentaDto.Fallido(
                "La caja dejó de estar abierta. Verifique su estado antes de registrar la venta.",
                "Caja requerida");
        }

        List<int> productIds = solicitud.Detalles
            .Select(detail => detail.ProductoId)
            .Distinct()
            .ToList();

        Dictionary<int, Product> products = db.Products
            .Include(product => product.ProductCategory)
            .Where(product => productIds.Contains(product.ProductId))
            .ToDictionary(product => product.ProductId);

        if (products.Count != productIds.Count)
        {
            return ResultadoVentaDto.Fallido(
                "Uno o más productos del pedido ya no existen en la base de datos.",
                "Producto no disponible");
        }

        List<string> unavailableProducts = products.Values
            .Where(product => !product.IsActive || !product.IsAvailable)
            .Select(product => product.ProductName)
            .ToList();

        if (unavailableProducts.Count > 0)
        {
            return ResultadoVentaDto.Fallido(
                "Los siguientes productos ya no están disponibles:\n\n" +
                string.Join("\n", unavailableProducts),
                "Producto no disponible");
        }

        if (solicitud.ClienteId.HasValue &&
            !db.Customers.Any(customer =>
                customer.CustomerId == solicitud.ClienteId.Value &&
                customer.IsActive))
        {
            return ResultadoVentaDto.Fallido(
                "El cliente seleccionado no está disponible.",
                "Cliente inválido");
        }

        int? tableId = solicitud.TipoOrden == "Delivery"
            ? null
            : solicitud.MesaId;

        TableRestaurant? table = null;
        if (tableId.HasValue)
        {
            table = db.TableRestaurants.FirstOrDefault(item =>
                item.TableId == tableId.Value && item.IsActive);

            if (table is null)
            {
                return ResultadoVentaDto.Fallido(
                    "La mesa seleccionada no existe o está inactiva.",
                    "Mesa inválida");
            }

            bool tableBelongsToAttendedReservation =
                solicitud.ClienteId.HasValue &&
                db.Reservations.Any(reservation =>
                    reservation.CustomerId == solicitud.ClienteId.Value &&
                    reservation.TableId == tableId.Value &&
                    reservation.ReservationDate == DateOnly.FromDateTime(DateTime.Today) &&
                    reservation.Status == "Attended");

            if (table.Status != "Available" && !tableBelongsToAttendedReservation)
            {
                return ResultadoVentaDto.Fallido(
                    "La mesa seleccionada ya no está disponible.",
                    "Mesa ocupada");
            }
        }

        decimal subtotal = 0m;
        var saleDetails = new List<SaleDetail>();

        foreach (PuntoVentaDetalleDto requestedDetail in solicitud.Detalles)
        {
            Product product = products[requestedDetail.ProductoId];
            decimal lineSubtotal = product.UnitPrice * requestedDetail.Cantidad;

            saleDetails.Add(new SaleDetail
            {
                ProductId = product.ProductId,
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

        using var transaction = db.Database.BeginTransaction();

        CashRegister? currentCashRegister = db.CashRegisters.FirstOrDefault(register =>
            register.CashRegisterId == cashRegisterId &&
            register.OpeningUserId == solicitud.UsuarioId &&
            register.Status == "Open");

        if (currentCashRegister is null)
        {
            return ResultadoVentaDto.Fallido(
                "La caja dejó de estar abierta. No se registró la venta.",
                "Caja requerida");
        }

        DateTime saleDateTime = DateTime.Now;
        var sale = new Sale
        {
            SaleDateTime = saleDateTime,
            UserId = solicitud.UsuarioId,
            CustomerId = solicitud.ClienteId,
            OrderType = solicitud.TipoOrden,
            TableId = tableId,
            Subtotal = subtotal,
            Discount = discount,
            Total = total,
            Status = "Completed",
            Notes = null,
            SaleDetails = saleDetails
        };

        var payment = new SalePayment
        {
            Sale = sale,
            PaymentMethod = solicitud.MetodoPago,
            Amount = total,
            PaymentDateTime = saleDateTime
        };

        var kitchenOrder = new KitchenOrder
        {
            Sale = sale,
            ReceptionDateTime = saleDateTime,
            PreparationStartDateTime = null,
            ReadyDateTime = null,
            DeliveredDateTime = null,
            Status = "Pending",
            Priority = solicitud.Prioridad == "Alta" ? "Urgent" : "Normal",
            Notes = "Orden enviada desde Punto de Venta"
        };

        foreach (SaleDetail saleDetail in saleDetails)
        {
            kitchenOrder.KitchenOrderDetails.Add(new KitchenOrderDetail
            {
                KitchenOrder = kitchenOrder,
                SaleDetail = saleDetail,
                ProductId = saleDetail.ProductId,
                Quantity = saleDetail.Quantity,
                Notes = saleDetail.Notes
            });
        }

        // El movimiento de caja se registra en la misma transacción de la
        // venta para que un corte posterior de conectividad no deje el ingreso
        // fuera del resumen local de Caja. CajaRepository evita duplicarlo al
        // sincronizar ventas completadas.
        var cashMovement = new CashMovement
        {
            CashRegisterId = currentCashRegister.CashRegisterId,
            Sale = sale,
            UserId = solicitud.UsuarioId,
            MovementType = "Sale",
            PaymentMethod = solicitud.MetodoPago,
            Concept = "Venta registrada desde Punto de Venta",
            Amount = total,
            MovementDateTime = saleDateTime,
            Notes = "Movimiento generado junto con la venta."
        };

        db.Sales.Add(sale);
        db.SalePayments.Add(payment);
        db.KitchenOrders.Add(kitchenOrder);
        db.CashMovements.Add(cashMovement);

        if (table is not null)
            table.Status = "Occupied";

        db.SaveChanges();

        try
        {
            transaction.Commit();
        }
        catch (Exception ex) when (
            SqlServerConnectionFailureDetector.IsConnectionFailure(ex))
        {
            // El servidor pudo haber confirmado el COMMIT sin que el cliente
            // recibiera la respuesta. No se crea una segunda venta local aquí:
            // el usuario debe verificar el resultado antes de volver a intentar.
            db.ChangeTracker.Clear();

            return ResultadoVentaDto.Fallido(
                "Se perdió la conexión mientras se confirmaba la venta. " +
                "No es posible determinar desde este equipo si SQL Server la confirmó. " +
                "No vuelva a registrar el pedido hasta verificarlo cuando se recupere la conexión.",
                "Confirmación de venta pendiente");
        }

        GuardarSnapshotCaja(currentCashRegister);

        string paymentMethodView = solicitud.MetodoPago switch
        {
            "Cash" => "Efectivo",
            "Card" => "Tarjeta",
            "Transfer" => "Transferencia",
            _ => solicitud.MetodoPago
        };

        return ResultadoVentaDto.Correcto(
            total,
            paymentMethodView,
            sale.SaleId);
    }

    private IReadOnlyList<MesaDto> FiltrarMesasConVentasPendientes(
        IReadOnlyList<MesaDto> mesas)
    {
        IReadOnlySet<int> mesasBloqueadas =
            _offlinePosSalesStore.ObtenerMesasConVentasPendientes();

        if (mesasBloqueadas.Count == 0)
            return mesas;

        return mesas
            .Where(table => !mesasBloqueadas.Contains(table.TableId))
            .ToList();
    }

    private void GuardarSnapshotCaja(CashRegister caja)
    {
        try
        {
            List<CashMovement> movements = _context.CashMovements
                .AsNoTracking()
                .Where(movement =>
                    movement.CashRegisterId == caja.CashRegisterId)
                .OrderBy(movement => movement.MovementDateTime)
                .ToList();

            _offlineCashRegisterStore.GuardarSnapshotServidor(
                caja,
                movements);
        }
        catch (Exception cacheException)
        {
            // Una falla de caché no interrumpe el funcionamiento online.
            System.Diagnostics.Debug.WriteLine(
                $"No fue posible actualizar el snapshot local de Caja: {cacheException}");
        }
    }

    public void Dispose() => _context.Dispose();
}
