using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocean_Desk_dv.UI.Models
{
    public class CierreCajaPrueba
    {
        public DateTime FechaCierre { get; set; }

        public decimal EfectivoEsperado { get; set; }

        public decimal EfectivoReal { get; set; }

        public decimal Diferencia { get; set; }

        public string Usuario { get; set; }
    }
}
