using Ocean_Desk_dv.Data;
using Ocean_Desk_dv.View.Interfaces;
using Ocean_Desk_dv.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocean_Desk_dv.Presenters
{
    public class CocinaPresenter
    {
        private readonly ICocinaView _view;
        private readonly OceanDeskDbContext _context;

        public CocinaPresenter(ICocinaView view, OceanDeskDbContext context)
        {
            _view = view;
            _context = context;

            _view.CambiarEstadoPedido += CambiarEstadoPedido;

            CargarPedidos();
        }

        public void CargarPedidos()
        {
            // Consultar órdenes que no estén ni completadas ni canceladas
            var pendientes = _context.KitchenOrders
                                     .Where(k => k.Status != "Completado" && k.Status != "Cancelado")
                                     .ToList();

            _view.MostrarPedidosPendientes(pendientes);
        }

        private void CambiarEstadoPedido(object sender, int pedidoId)
        {
            var pedido = _context.KitchenOrders.Find(pedidoId);
            if (pedido != null)
            {
                // Lógica simple de transición de estados
                if (pedido.Status == "Pendiente")
                    pedido.Status = "Preparando";
                else if (pedido.Status == "Preparando")
                    pedido.Status = "Listo";
                else if (pedido.Status == "Listo")
                    pedido.Status = "Entregado"; // O el estado final que manejes

                _context.SaveChanges();
                CargarPedidos(); // Refrescar la vista
            }
        }
    }
}
