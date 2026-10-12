using Microsoft.EntityFrameworkCore;
using Ocean_Desk_dv.Data;
using Ocean_Desk_dv.Models.DTOs;
using Ocean_Desk_dv.Models.Entities;
using Ocean_Desk_dv.Services.Interfaces_Services;

namespace Ocean_Desk_dv.Services.Repository;

public sealed class FacturacionRepository : IFacturacionRepository
{
    private readonly OceanDeskDbContext _context;

    public FacturacionRepository(OceanDeskDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public IReadOnlyList<FacturaDto> ObtenerFacturas()
    {
        var db = _context;
        GenerarFacturasPendientes(db);
        return db.Invoices.AsNoTracking()
            .Include(i => i.Sale).ThenInclude(s => s.Customer)
            .Include(i => i.Sale).ThenInclude(s => s.Table)
            .Include(i => i.Sale).ThenInclude(s => s.SalePayments)
            .Include(i => i.Sale).ThenInclude(s => s.SaleDetails).ThenInclude(d => d.Product)
            .OrderByDescending(i => i.IssueDateTime).ToList().Select(MapearFactura).ToList();
    }

    public FacturaDto? ObtenerFactura(string numeroFactura)
    {
        var db = _context;
        var factura = db.Invoices.AsNoTracking()
            .Include(i => i.Sale).ThenInclude(s => s.Customer)
            .Include(i => i.Sale).ThenInclude(s => s.Table)
            .Include(i => i.Sale).ThenInclude(s => s.SalePayments)
            .Include(i => i.Sale).ThenInclude(s => s.SaleDetails).ThenInclude(d => d.Product)
            .FirstOrDefault(i => i.InvoiceNumber == numeroFactura);
        return factura is null ? null : MapearFactura(factura);
    }

    public ResultadoOperacionDto AnularFactura(string numeroFactura, int usuarioId, DateTime fechaAnulacion)
    {
        var db = _context;
        var factura = db.Invoices.FirstOrDefault(i => i.InvoiceNumber == numeroFactura);
        if (factura is null) return ResultadoOperacionDto.Fallido("No se encontró la factura seleccionada en la base de datos.");
        if (factura.Status == "Voided") return ResultadoOperacionDto.Fallido("La factura seleccionada ya se encuentra anulada.");
        factura.Status = "Voided";
        factura.CancellationDateTime = fechaAnulacion;
        factura.CancellationReason = "Anulación realizada desde el módulo de Facturación.";
        factura.CancellationUserId = usuarioId;
        db.SaveChanges();
        return ResultadoOperacionDto.Correcto($"La factura {factura.InvoiceNumber} ha sido anulada correctamente.");
    }

    private static void GenerarFacturasPendientes(OceanDeskDbContext db)
    {
        var ventas = db.Sales.Where(s => s.Status == "Completed" && !db.Invoices.Any(i => i.SaleId == s.SaleId))
            .OrderBy(s => s.SaleId).ToList();
        if (ventas.Count == 0) return;
        int siguiente = ObtenerSiguienteNumeroFactura(db);
        foreach (var venta in ventas)
        {
            db.Invoices.Add(new Invoice
            {
                SaleId = venta.SaleId,
                InvoiceNumber = $"F001-{siguiente++:0000}",
                IssueDateTime = DateTime.Now,
                CustomerId = venta.CustomerId,
                Subtotal = venta.Subtotal,
                Discount = venta.Discount,
                Total = venta.Total,
                Status = "Issued"
            });
        }
        db.SaveChanges();
    }

    private static int ObtenerSiguienteNumeroFactura(OceanDeskDbContext db)
    {
        int maximo = 0;
        foreach (string numero in db.Invoices.AsNoTracking().Select(i => i.InvoiceNumber).ToList())
        {
            if (string.IsNullOrWhiteSpace(numero)) continue;
            string sufijo = new string(numero.Reverse().TakeWhile(char.IsDigit).Reverse().ToArray());
            if (int.TryParse(sufijo, out int valor) && valor > maximo) maximo = valor;
        }
        return maximo + 1;
    }

    private static FacturaDto MapearFactura(Invoice factura)
    {
        var venta = factura.Sale;
        string cliente = venta.Customer == null ? "Consumidor Final" : $"{venta.Customer.FirstName} {venta.Customer.LastName}".Trim();
        string metodoPago = venta.SalePayments.OrderByDescending(p => p.PaymentDateTime).Select(p => TraducirMetodoPago(p.PaymentMethod)).FirstOrDefault() ?? "No registrado";
        return new FacturaDto
        {
            NumeroFactura = factura.InvoiceNumber,
            Fecha = factura.IssueDateTime,
            Cliente = cliente,
            TipoOrden = venta.OrderType,
            Mesa = venta.Table?.TableNumber,
            Subtotal = factura.Subtotal,
            Descuento = factura.Discount,
            Total = factura.Total,
            MetodoPago = metodoPago,
            Estado = factura.Status == "Voided" ? "Anulada" : "Pagada",
            Detalles = venta.SaleDetails.OrderBy(d => d.SaleDetailId).Select(d => new DetalleFacturaDto
            {
                Producto = d.Product?.ProductName ?? "Producto no disponible",
                Cantidad = ConvertirCantidad(d.Quantity),
                Precio = d.UnitPrice
            }).ToList()
        };
    }

    private static int ConvertirCantidad(decimal cantidad) => cantidad <= 0 ? 0 : decimal.ToInt32(decimal.Round(cantidad, 0, MidpointRounding.AwayFromZero));
    private static string TraducirMetodoPago(string metodo) => metodo switch { "Cash" => "Efectivo", "Card" => "Tarjeta", "Transfer" => "Transferencia", _ => metodo };
    public void Dispose() => _context.Dispose();

}
