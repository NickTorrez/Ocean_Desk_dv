using Ocean_Desk_dv.Models.DTOs;

namespace Ocean_Desk_dv.Services.Interfaces_Services;

public interface IFacturacionRepository : IDisposable
{
    IReadOnlyList<FacturaDto> ObtenerFacturas();
    FacturaDto? ObtenerFactura(string numeroFactura);
    ResultadoOperacionDto AnularFactura(string numeroFactura, int usuarioId, DateTime fechaAnulacion);
}
