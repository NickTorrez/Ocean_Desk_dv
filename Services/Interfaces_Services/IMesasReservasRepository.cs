using Ocean_Desk_dv.Models.DTOs;

namespace Ocean_Desk_dv.Services.Interfaces_Services;

public interface IMesasReservasRepository : IDisposable
{
    IReadOnlyList<MesaDto> ObtenerMesasActivas();
    IReadOnlyList<MesaDto> ObtenerMesasDisponibles(int? mesaActualNumero = null);
    IReadOnlyList<ReservaDto> ObtenerReservas();
    ReservaOperacionDto? ObtenerReserva(int reservaId);
    ResultadoOperacionDto CrearReserva(ReservaGuardarDto solicitud);
    ResultadoOperacionDto ActualizarReserva(ReservaGuardarDto solicitud);
    ResultadoOperacionDto CancelarReserva(int reservaId);
    ResultadoOperacionDto AsignarMesa(int reservaId, int numeroMesa);
    ResultadoOperacionDto CambiarEstadoReserva(int reservaId, string nuevoEstado);
    ResultadoOperacionDto LiberarMesa(int numeroMesa);
}
