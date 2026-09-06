using Ocean_Desk_dv.Models.Entities;
using Ocean_Desk_dv.UI.Catalogs;
using Ocean_Desk_dv.UI.MessageBox;
using Ocean_Desk_dv.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocean_Desk_dv.View.Interfaces
{
    public interface IMesasReservasView
    {
        int? ReservaIdSeleccionada { get; }
        int? NumeroMesaSeleccionada { get; }
        int? NumeroMesaSeleccionadaParaAsignar { get; }

        string ClienteReserva { get; }
        DateTime FechaReserva { get; }
        TimeSpan HoraReserva { get; }
        int PersonasReserva { get; }

        void MostrarMesas(List<TableRestaurant> mesas);
        void MostrarMesasParaReserva(List<TableRestaurant> mesas, int? mesaActualNumero);
        void MostrarReservas(List<ReservaPrueba> reservas);
        void CargarDatosReserva(ReservaPrueba reserva);
        void MostrarMensaje(string mensaje, MessageType tipo);
        void AbrirPanelNuevaReserva(bool edicion);
        void CerrarPanelNuevaReserva();
        void LimpiarFormularioNuevaReserva();

        event EventHandler NuevaReservaClicked;
        event EventHandler GuardarReservaClicked;
        event EventHandler EditarReservaClicked;
        event EventHandler CancelarReservaClicked;
        event EventHandler AsignarMesaClicked;
        event EventHandler CambiarEstadoReservaClicked;
    }
}
