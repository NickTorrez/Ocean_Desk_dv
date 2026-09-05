using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocean_Desk_dv.UI.Models
{
    public class MovimientoCajaPrueba
    {
        public DateTime Fecha { get; set; }

        public string Tipo { get; set; }

        public string Concepto { get; set; }

        public string MetodoPago { get; set; }

        public decimal Monto { get; set; }

        public string Usuario { get; set; }

    }
}
