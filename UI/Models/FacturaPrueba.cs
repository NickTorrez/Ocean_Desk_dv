using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocean_Desk_dv.UI.Models
{
    public class FacturaPrueba
    {
        //Solamente se esta utilizando como prueba
        public string NumeroFactura { get; set; }
        public DateTime Fecha { get; set; }
        public string Cliente { get; set; }
        public string TipoOrden { get; set; }
        public decimal Total { get; set; }
        public string Estado { get; set; }
    }
}
