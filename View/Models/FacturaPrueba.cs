using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ocean_Desk_dv.UI.Catalogs;

namespace Ocean_Desk_dv.UI.Models
{
    public class FacturaPrueba
    {
        public string NumeroFactura { get; set; }
        public DateTime Fecha { get; set; }
        public string Cliente { get; set; }
        public string TipoOrden { get; set; }
        public int? Mesa { get; set; }

        public decimal Subtotal { get; set; }
        public decimal Descuento { get; set; }
        public decimal Total { get; set; }

        public string MetodoPago { get; set; }
        public string Estado { get; set; }

        public List<DetalleFacturaPrueba> Detalles { get; set; }
            = new List<DetalleFacturaPrueba>();
    }
}
