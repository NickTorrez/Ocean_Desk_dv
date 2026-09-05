using Ocean_Desk_dv.Models.Entities;
using Ocean_Desk_dv.UI.Catalogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocean_Desk_dv.View.Interfaces
{
    public interface ICocinaView
    {
        void MostrarPedidosPendientes(List<KitchenOrder> pedidos);
        void ActualizarTiempoPedido(int kitchenOrderId, TimeSpan tiempoTranscurrido);

        event EventHandler<int> CambiarEstadoPedido; // Ej: De "Pendiente" a "Preparando" o "Listo"
    }
}
