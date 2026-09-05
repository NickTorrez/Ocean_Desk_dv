using Ocean_Desk_dv.Data;
using Ocean_Desk_dv.Models.Entities;
using Ocean_Desk_dv.View.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocean_Desk_dv.Presenters
{
    public class PuntoVentaPresenter
    {
        private readonly IPuntoVentaView _view;
        private readonly OceanDeskDbContext _context;

        public PuntoVentaPresenter(IPuntoVentaView view, OceanDeskDbContext context)
        {
            _view = view;
            _context = context;

            // Suscribir los eventos de la vista
            _view.PagarYRegistrarOrden += RegistrarOrden;

            CargarCatalogo();
        }

        private void CargarCatalogo()
        {
            // Cargar productos activos directo de la BD
            var productos = _context.Products.Where(p => p.IsActive).ToList();
            _view.MostrarProductos(productos);
        }

        private void RegistrarOrden(object sender, EventArgs e)
        {
            if (!_view.DetallesVenta.Any())
            {
                _view.MostrarMensaje("El carrito está vacío.");
                return;
            }

            try
            {
                // 1. Crear la Venta (Sale)
                var nuevaVenta = new Sale
                {
                    SaleDateTime = DateTime.Now,
                    Total = _view.DetallesVenta.Sum(d => d.Subtotal),
                    Status = "PendienteFacturacion",
                    OrderType = _view.TipoOrden, // "Local" o "Llevar"
                    TableId = _view.TipoOrden == "Local" ? _view.MesaIdSeleccionada : (int?)null,
                    SaleDetails = _view.DetallesVenta // Entity Framework guardará los detalles en cascada
                };

                _context.Sales.Add(nuevaVenta);

                // 2. Crear Orden de Cocina vinculada
                var ordenCocina = new KitchenOrder
                {
                    Sale = nuevaVenta, // Relacionamos la orden con la venta actual
                    ReceptionDateTime = DateTime.Now,
                    Status = "Pendiente",
                    PreparationStartDateTime = DateTime.Now.AddMinutes(25),
                    Notes = "Orden enviada desde caja"
                };

                _context.KitchenOrders.Add(ordenCocina);

                // 3. Cambiar estado de la mesa (si aplica)
                if (nuevaVenta.TableId.HasValue)
                {
                    var mesa = _context.TableRestaurants.Find(nuevaVenta.TableId.Value);
                    if (mesa != null) mesa.Status = "Ocupada";
                }

                // 4. Guardar todos los cambios en la BD de una sola vez
                _context.SaveChanges();

                _view.MostrarMensaje("Orden registrada con éxito. Enviada a Cocina y Facturación.");
                _view.LimpiarCarrito();
            }
            catch (Exception ex)
            {
                _view.MostrarMensaje($"Error al registrar orden: {ex.Message}");
            }
        }
    }
}
