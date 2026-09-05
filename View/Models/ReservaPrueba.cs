using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocean_Desk_dv.UI.Models
{
    public class ReservaPrueba
    {
        public int ReservaId { get; set; }

        public string Cliente { get; set; }

        public DateTime Fecha { get; set; }

        public TimeSpan Hora { get; set; }

        public int Personas { get; set; }

        public int? Mesa { get; set; }

        public string Estado { get; set; }
    }
}
