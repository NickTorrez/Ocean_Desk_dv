using Ocean_Desk_dv.Models.DTOs;

namespace Ocean_Desk_dv.Services.Interfaces_Services;

public interface IPuntoVentaRepository : IDisposable
{
    IReadOnlyList<ProductoVentaDto> ObtenerCatalogoDisponible();
    IReadOnlyList<ClienteVentaDto> ObtenerClientesActivos();
    IReadOnlyList<MesaDto> ObtenerMesasDisponibles();
    ReservaOperacionDto? ObtenerReservaAtendidaCliente(int clienteId, DateOnly fecha);
    bool ExisteTelefonoClienteActivo(string telefono);
    ResultadoOperacionDto RegistrarCliente(string nombre, string apellido, string telefono, out int clienteId);
    bool TieneCajaAbierta(int usuarioId);
    ResultadoVentaDto RegistrarVenta(SolicitudVentaDto solicitud);
}
