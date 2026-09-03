using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocean_Desk_dv.UI.Models
{
    public class DetalleFacturaPrueba
    {
        public string Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }

        public decimal Subtotal
        {
            get
            {
                return Cantidad * Precio;
            }
        }
    }
}
