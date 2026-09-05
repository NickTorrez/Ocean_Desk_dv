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
    public class FacturacionPresenter
    {
        private readonly IFacturacionView _view;
        private readonly OceanDeskDbContext _context;

        public FacturacionPresenter(IFacturacionView view, OceanDeskDbContext context)
        {
            _view = view;
            _context = context;

            _view.FacturarOrden += FacturarVenta;

            CargarVentasPendientes();
        }

        public void CargarVentasPendientes()
        {
            var pendientes = _context.Sales
                                     .Where(s => s.Status == "PendienteFacturacion")
                                     .ToList();

            _view.MostrarOrdenesPendientes(pendientes);
        }

        private void FacturarVenta(object sender, int saleId)
        {
            var venta = _context.Sales.Find(saleId);
            if (venta != null)
            {
                // Generar la Entidad Factura
                var factura = new Invoice
                {
                    SaleId = saleId,
                    IssueDateTime = DateTime.Now,
                    InvoiceNumber = "FAC-" + DateTime.Now.Ticks.ToString().Substring(0, 8),
                    Total = venta.Total
                };

                venta.Status = "Facturado"; // Actualizamos estado de la venta
                _context.Invoices.Add(factura);

                _context.SaveChanges();

                _view.MostrarFacturaGenerada(factura);
                CargarVentasPendientes(); // Refrescar la lista de la vista
            }
        }
    }
}
