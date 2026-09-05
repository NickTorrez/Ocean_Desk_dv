using Ocean_Desk_dv.Models.Entities;
using Ocean_Desk_dv.UI.Catalogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocean_Desk_dv.View.Interfaces
{
    public interface IPuntoVentaView
    {
        // Propiedades de la vista
        int MesaIdSeleccionada { get; }
        string TipoOrden { get; } // Ejemplo: "Para Comer Aquí", "Llevar"
        List<SaleDetail> DetallesVenta { get; }

        // Métodos de la vista
        void MostrarProductos(List<Product> productos);
        void MostrarMensaje(string mensaje);
        void LimpiarCarrito();

        // Eventos
        event EventHandler PagarYRegistrarOrden;
    }
}
