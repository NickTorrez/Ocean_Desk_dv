using Ocean_Desk_dv.Models.DTOs;

namespace Ocean_Desk_dv.Services.Interfaces_Services;

public interface IReportesRepository : IDisposable
{
    ReporteIndicadoresDto ObtenerIndicadores(DateTime desde, DateTime hastaExclusivo);
    IReadOnlyList<EvolucionVentaDto> ObtenerEvolucionVentas(DateTime desde, DateTime hastaExclusivo);
    IReadOnlyList<ProductoVendidoDto> ObtenerProductosMasVendidos(DateTime desde, DateTime hastaExclusivo, int cantidad = 5);
}
