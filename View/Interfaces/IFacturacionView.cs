using Ocean_Desk_dv.Models.Entities;
using Ocean_Desk_dv.UI.Catalogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocean_Desk_dv.View.Interfaces
{
    public interface IFacturacionView
    {
        void MostrarOrdenesPendientes(List<Sale> ventasPendientes);
        void CargarDetallesVenta(Sale venta, List<SaleDetail> detalles);
        void MostrarFacturaGenerada(Invoice factura);

        event EventHandler<int> FacturarOrden; // Pasa el SaleId
    }
}
