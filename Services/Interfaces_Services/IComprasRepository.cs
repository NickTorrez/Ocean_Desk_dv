using Ocean_Desk_dv.Models.DTOs;

namespace Ocean_Desk_dv.Services.Interfaces_Services;

public interface IComprasRepository : IDisposable
{
    IReadOnlyList<ProveedorCompraDto> ObtenerProveedoresActivos();
    IReadOnlyList<ProductoCompraDto> ObtenerIngredientesActivos();
    IReadOnlyList<UnidadMedidaDto> ObtenerUnidadesMedidaActivas();
    IReadOnlyList<CompraResumenDto> ObtenerCompras(FiltroComprasDto filtro);
    CompraResumenDto? ObtenerCompra(int purchaseId);
    IReadOnlyList<CompraDetalleDto> ObtenerDetalles(int purchaseId);
    ResultadoCompraDto RegistrarCompra(SolicitudCompraDto solicitud);
    ResultadoCompraDto RegistrarRecepcion(int purchaseId);
    ResultadoCompraDto CancelarCompra(int purchaseId);
}
