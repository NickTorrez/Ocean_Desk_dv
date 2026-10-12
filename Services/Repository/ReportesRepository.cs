using Microsoft.EntityFrameworkCore;
using Ocean_Desk_dv.Data;
using Ocean_Desk_dv.Models.DTOs;
using Ocean_Desk_dv.Services.Interfaces_Services;

namespace Ocean_Desk_dv.Services.Repository;

public sealed class ReportesRepository : IReportesRepository
{
    private readonly OceanDeskDbContext _context;

    public ReportesRepository(OceanDeskDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public ReporteIndicadoresDto ObtenerIndicadores(DateTime desde, DateTime hastaExclusivo)
    {
        var db = _context;
        var ventas = db.Sales.AsNoTracking().Where(s => s.Status == "Completed" && s.SaleDateTime >= desde && s.SaleDateTime < hastaExclusivo);
        return new ReporteIndicadoresDto
        {
            CantidadVentas = ventas.Count(),
            Ingresos = ventas.Sum(s => (decimal?)s.Total) ?? 0m,
            ProductosRegistrados = db.Products.AsNoTracking().Count(p => p.IsActive)
        };
    }

    public IReadOnlyList<EvolucionVentaDto> ObtenerEvolucionVentas(DateTime desde, DateTime hastaExclusivo)
    {
        var db = _context;
        return db.Sales.AsNoTracking()
            .Where(s => s.Status == "Completed" && s.SaleDateTime >= desde && s.SaleDateTime < hastaExclusivo)
            .GroupBy(s => s.SaleDateTime.Date)
            .Select(g => new EvolucionVentaDto { Fecha = g.Key, Total = g.Sum(s => s.Total) })
            .OrderBy(x => x.Fecha).ToList();
    }

    public IReadOnlyList<ProductoVendidoDto> ObtenerProductosMasVendidos(DateTime desde, DateTime hastaExclusivo, int cantidad = 5)
    {
        var db = _context;
        return db.SaleDetails.AsNoTracking()
            .Where(d => d.Sale.Status == "Completed" && d.Sale.SaleDateTime >= desde && d.Sale.SaleDateTime < hastaExclusivo)
            .GroupBy(d => new { d.ProductId, d.Product.ProductName })
            .Select(g => new ProductoVendidoDto { Producto = g.Key.ProductName, Cantidad = g.Sum(d => d.Quantity) })
            .OrderByDescending(x => x.Cantidad).ThenBy(x => x.Producto).Take(cantidad).ToList();
    }
    public void Dispose() => _context.Dispose();

}
