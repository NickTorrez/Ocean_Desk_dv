using Ocean_Desk_dv.Models.DTOs;

namespace Ocean_Desk_dv.Services.Interfaces_Services;

public interface ICocinaRepository : IDisposable
{
    IReadOnlyList<CocinaPedidoResumenDto> ObtenerPedidosActivos();
    CocinaPedidoCompletoDto? ObtenerPedido(int pedidoId);
    string? ObtenerEstadoPedido(int pedidoId);
    ResultadoOperacionDto CambiarEstado(int pedidoId, string estadoEsperado, string nuevoEstado, DateTime fechaCambio);
    ResultadoOperacionDto CancelarPedido(int pedidoId, string motivo, string estadoEsperado);
}
