using Microsoft.EntityFrameworkCore;
using Ocean_Desk_dv.Data;
using Ocean_Desk_dv.Models.DTOs;
using Ocean_Desk_dv.Models.Entities;
using Ocean_Desk_dv.Services.Interfaces_Services;

namespace Ocean_Desk_dv.Services.Repository;

public sealed class PuntoVentaRepository : IPuntoVentaRepository
{
    private readonly OceanDeskDbContext _context;

    public PuntoVentaRepository(OceanDeskDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public IReadOnlyList<ProductoVentaDto> ObtenerCatalogoDisponible()
    {
        var db = _context;
        return db.Products.AsNoTracking().Include(p => p.ProductCategory)
            .Where(p => p.IsActive && p.IsAvailable)
            .OrderBy(p => p.ProductCategory.CategoryName).ThenBy(p => p.ProductName)
            .Select(p => new ProductoVentaDto
            {
                ProductId = p.ProductId,
                ProductCode = p.ProductCode,
                ProductName = p.ProductName,
                UnitPrice = p.UnitPrice,
                IsAvailable = p.IsAvailable,
                IsActive = p.IsActive,
                CategoryName = p.ProductCategory.CategoryName
            }).ToList();
    }

    public IReadOnlyList<ClienteVentaDto> ObtenerClientesActivos()
    {
        var db = _context;
        return db.Customers.AsNoTracking().Where(c => c.IsActive)
            .OrderBy(c => c.FirstName).ThenBy(c => c.LastName)
            .Select(c => new ClienteVentaDto { CustomerId = c.CustomerId, FirstName = c.FirstName, LastName = c.LastName, Phone = c.Phone })
            .ToList();
    }

    public IReadOnlyList<MesaDto> ObtenerMesasDisponibles()
    {
        var db = _context;
        return db.TableRestaurants.AsNoTracking().Where(t => t.IsActive && t.Status == "Available")
            .OrderBy(t => t.TableNumber)
            .Select(t => new MesaDto { TableId = t.TableId, TableNumber = t.TableNumber, Capacity = t.Capacity, Status = t.Status, IsActive = t.IsActive })
            .ToList();
    }

    public ReservaOperacionDto? ObtenerReservaAtendidaCliente(int clienteId, DateOnly fecha)
    {
        var db = _context;
        return (from r in db.Reservations.AsNoTracking()
                join c in db.Customers.AsNoTracking() on r.CustomerId equals c.CustomerId
                join table in db.TableRestaurants.AsNoTracking() on r.TableId equals table.TableId into tablas
                from t in tablas.Where(x => x.IsActive).DefaultIfEmpty()
                where r.CustomerId == clienteId && r.ReservationDate == fecha && r.Status == "Attended" && r.TableId.HasValue
                orderby r.ReservationTime
                select new ReservaOperacionDto
                {
                    ReservationId = r.ReservationId,
                    CustomerId = r.CustomerId,
                    TableId = r.TableId,
                    ReservationDate = r.ReservationDate,
                    ReservationTime = r.ReservationTime,
                    GuestCount = r.GuestCount,
                    Status = r.Status,
                    CustomerName = (c.FirstName + " " + c.LastName).Trim(),
                    TableNumber = t != null ? (int?)t.TableNumber : null
                }).FirstOrDefault();
    }

    public bool ExisteTelefonoClienteActivo(string telefono)
    {
        var db = _context;
        return db.Customers.Any(c => c.IsActive && c.Phone != null && c.Phone == telefono);
    }

    public ResultadoOperacionDto RegistrarCliente(string nombre, string apellido, string telefono, out int clienteId)
    {
        clienteId = 0;
        var db = _context;
        if (db.Customers.Any(c => c.IsActive && c.Phone != null && c.Phone == telefono))
            return ResultadoOperacionDto.Fallido("Ya existe un cliente activo registrado con ese teléfono.");
        var cliente = new Customer
        {
            FirstName = nombre.Trim(),
            LastName = apellido.Trim(),
            Phone = telefono.Trim(),
            IsActive = true,
            CreatedAt = DateTime.Now
        };
        db.Customers.Add(cliente);
        db.SaveChanges();
        clienteId = cliente.CustomerId;
        return ResultadoOperacionDto.Correcto($"El cliente {cliente.FirstName} {cliente.LastName} fue registrado correctamente.");
    }

    public bool TieneCajaAbierta(int usuarioId)
    {
        var db = _context;
        return db.CashRegisters.Any(c => c.OpeningUserId == usuarioId && c.Status == "Open");
    }

    public ResultadoVentaDto RegistrarVenta(SolicitudVentaDto solicitud)
    {
        var db = _context;
        if (solicitud.UsuarioId <= 0) return ResultadoVentaDto.Fallido("No se ha identificado un usuario válido para registrar la venta.", "Usuario inválido");
        if (!db.CashRegisters.Any(c => c.OpeningUserId == solicitud.UsuarioId && c.Status == "Open"))
            return ResultadoVentaDto.Fallido("No puede registrar la venta porque no existe una caja abierta para el usuario actual.\n\nRealice la apertura de caja antes de continuar.", "Caja requerida");
        if (solicitud.Detalles.Count == 0) return ResultadoVentaDto.Fallido("El pedido está vacío.", "Venta vacía");
        if (solicitud.TipoOrden is not ("Local" or "Delivery")) return ResultadoVentaDto.Fallido("Seleccione un tipo de orden válido.", "Tipo de orden inválido");
        if (solicitud.TipoOrden == "Local" && !solicitud.MesaId.HasValue) return ResultadoVentaDto.Fallido("Seleccione una mesa para una orden local.", "Mesa requerida");
        if (solicitud.MetodoPago is not ("Cash" or "Card" or "Transfer")) return ResultadoVentaDto.Fallido("Seleccione un método de pago válido.", "Método de pago inválido");
        if (solicitud.Detalles.Any(d => d.ProductoId <= 0 || d.Cantidad <= 0)) return ResultadoVentaDto.Fallido("El pedido contiene productos o cantidades inválidas.", "Datos inválidos");
        if (solicitud.Detalles.Any(d => (d.Observacion?.Length ?? 0) > 255)) return ResultadoVentaDto.Fallido("Cada observación de producto debe tener 255 caracteres como máximo.", "Observación demasiado larga");

        var productoIds = solicitud.Detalles.Select(d => d.ProductoId).Distinct().ToList();
        var productos = db.Products.Include(p => p.ProductCategory).Where(p => productoIds.Contains(p.ProductId)).ToDictionary(p => p.ProductId);
        if (productos.Count != productoIds.Count) return ResultadoVentaDto.Fallido("Uno o más productos del pedido ya no existen en la base de datos.", "Producto no disponible");
        var productosNoDisponibles = productos.Values.Where(p => !p.IsActive || !p.IsAvailable).Select(p => p.ProductName).ToList();
        if (productosNoDisponibles.Count > 0)
            return ResultadoVentaDto.Fallido("Los siguientes productos ya no están disponibles:\n\n" + string.Join("\n", productosNoDisponibles), "Producto no disponible");
        if (solicitud.ClienteId.HasValue && !db.Customers.Any(c => c.CustomerId == solicitud.ClienteId.Value && c.IsActive))
            return ResultadoVentaDto.Fallido("El cliente seleccionado no está disponible.", "Cliente inválido");

        int? mesaId = solicitud.TipoOrden == "Delivery" ? null : solicitud.MesaId;
        TableRestaurant? mesa = null;
        if (mesaId.HasValue)
        {
            mesa = db.TableRestaurants.FirstOrDefault(t => t.TableId == mesaId.Value && t.IsActive);
            if (mesa is null) return ResultadoVentaDto.Fallido("La mesa seleccionada no existe o está inactiva.", "Mesa inválida");
            bool mesaPerteneceAReserva = solicitud.ClienteId.HasValue && db.Reservations.Any(r =>
                r.CustomerId == solicitud.ClienteId.Value && r.TableId == mesaId.Value &&
                r.ReservationDate == DateOnly.FromDateTime(DateTime.Today) && r.Status == "Attended");
            if (mesa.Status != "Available" && !mesaPerteneceAReserva)
                return ResultadoVentaDto.Fallido("La mesa seleccionada ya no está disponible.", "Mesa ocupada");
        }

        decimal subtotal = 0m;
        var saleDetails = new List<SaleDetail>();
        foreach (var detalle in solicitud.Detalles)
        {
            Product producto = productos[detalle.ProductoId];
            decimal subtotalLinea = producto.UnitPrice * detalle.Cantidad;
            saleDetails.Add(new SaleDetail
            {
                ProductId = producto.ProductId,
                Quantity = detalle.Cantidad,
                UnitPrice = producto.UnitPrice,
                Discount = 0m,
                Subtotal = subtotalLinea,
                Notes = string.IsNullOrWhiteSpace(detalle.Observacion) ? null : detalle.Observacion.Trim()
            });
            subtotal += subtotalLinea;
        }
        decimal descuento = 0m;
        decimal total = subtotal - descuento;
        if (total <= 0m) return ResultadoVentaDto.Fallido("El total de la venta debe ser mayor que cero.", "Total inválido");

        using var transaction = db.Database.BeginTransaction();
        var venta = new Sale
        {
            SaleDateTime = DateTime.Now,
            UserId = solicitud.UsuarioId,
            CustomerId = solicitud.ClienteId,
            OrderType = solicitud.TipoOrden,
            TableId = mesaId,
            Subtotal = subtotal,
            Discount = descuento,
            Total = total,
            Status = "Completed",
            Notes = null,
            SaleDetails = saleDetails
        };
        var pago = new SalePayment
        {
            Sale = venta,
            PaymentMethod = solicitud.MetodoPago,
            Amount = total,
            PaymentDateTime = DateTime.Now
        };
        var ordenCocina = new KitchenOrder
        {
            Sale = venta,
            ReceptionDateTime = DateTime.Now,
            PreparationStartDateTime = null,
            ReadyDateTime = null,
            DeliveredDateTime = null,
            Status = "Pending",
            Priority = solicitud.Prioridad == "Alta" ? "High" : "Normal",
            Notes = "Orden enviada desde Punto de Venta"
        };
        foreach (var saleDetail in saleDetails)
        {
            ordenCocina.KitchenOrderDetails.Add(new KitchenOrderDetail
            {
                KitchenOrder = ordenCocina,
                SaleDetail = saleDetail,
                ProductId = saleDetail.ProductId,
                Quantity = saleDetail.Quantity,
                Notes = saleDetail.Notes
            });
        }
        db.Sales.Add(venta);
        db.SalePayments.Add(pago);
        db.KitchenOrders.Add(ordenCocina);
        if (mesa != null) mesa.Status = "Occupied";
        db.SaveChanges();
        transaction.Commit();
        string metodoVista = solicitud.MetodoPago switch { "Cash" => "Efectivo", "Card" => "Tarjeta", "Transfer" => "Transferencia", _ => solicitud.MetodoPago };
        return ResultadoVentaDto.Correcto(total, metodoVista, venta.SaleId);
    }
    public void Dispose() => _context.Dispose();

}
