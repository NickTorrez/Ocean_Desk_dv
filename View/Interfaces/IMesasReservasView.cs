using Ocean_Desk_dv.Models.Entities;
using Ocean_Desk_dv.UI.Catalogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocean_Desk_dv.View.Interfaces
{
    public interface IMesasReservasView
    {
        void MostrarMesas(List<TableRestaurant> mesas);
        void MostrarReservas(List<Reservation> reservas);
        void MostrarMensaje(string mensaje);

        event EventHandler<int> CambiarEstadoMesa;
        event EventHandler<Reservation> CrearReserva;
    }
}
