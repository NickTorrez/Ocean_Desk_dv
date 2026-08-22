using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ocean_Desk_dv.UI.Controls;


namespace Ocean_Desk_dv.UI.Catalogs
{
    public partial class FrmPuntoVenta : Form
    {
        public FrmPuntoVenta()
        {
            InitializeComponent();

            CargarProductosPrueba(); //Prueba de Productos
        }

        private void CargarProductosPrueba()
        {
            flpProducts.Controls.Clear();

            AgregarProductoCard(
                1,
                "Ceviche Mixto",
                120.50m,
                 Properties.Resources.Primer_Ceviche);

            AgregarProductoCard(
                2,
                "Camarones al Ajillo",
                100.00m,
                Properties.Resources.Coctel_Ceviche);

            AgregarProductoCard(
                3,
                "Pargo Frito",
                150.00m);

            AgregarProductoCard(
                4,
                "Tostones",
                80.00m);

            AgregarProductoCard(
                5,
                "Coca Cola",
                18.50m);

            AgregarProductoCard(
                6,
                "Limonada",
                28.00m);
        }

        private void AgregarProductoCard(
        int productoId,
        string nombre,
        decimal precio,
        Image imagen = null)
        {
            UcProductoCard card = new UcProductoCard();

            card.ProductoId = productoId;
            card.NombreProducto = nombre;
            card.Precio = precio;
            card.ImagenProducto = imagen;

            card.ProductoAgregado += Card_ProductoAgregado;

            flpProducts.Controls.Add(card);
        }

        private void Card_ProductoAgregado(object sender, EventArgs e)
        {
            if (sender is UcProductoCard card)
            {
                MessageBox.Show(
                    $"Producto seleccionado:\n\n" +
                    $"ID: {card.ProductoId}\n" +
                    $"Producto: {card.NombreProducto}\n" +
                   $"Precio: {card.Precio.ToString(
                             "C",
                             System.Globalization.CultureInfo.GetCultureInfo("es-NI"))}",
                    "Ocean Desk",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

    }
}
