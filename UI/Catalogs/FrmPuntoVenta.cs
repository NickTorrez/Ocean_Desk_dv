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
        private readonly List<UcOrderItem> _orderItems = new List<UcOrderItem>();

        #region Constructor
        public FrmPuntoVenta()
        {
            InitializeComponent();

            CargarProductosPrueba(); //Prueba de Productos
        }
        #endregion

        #region Adicion de Productos (Prueba)
        private void CargarProductosPrueba()
        {
            flpProducts.Controls.Clear();
            AgregarProductoCard(
                1,
                "Ceviche Mixto",
                120.50m,
                Properties.Resources.Primer_Ceviche,
                true);

            AgregarProductoCard(
                2,
                "Camarones al Ajillo",
                100.00m,
                Properties.Resources.Coctel_Ceviche,
                true);

            AgregarProductoCard(
                3,
                "Pargo Frito Especial de la Casa con Salsa de Mariscos",
                150.00m,
                null,
                true);

            AgregarProductoCard(
                4,
                "Tostones",
                80.00m,
                null,
                false);
        }
        #endregion

        #region Metodo de instancia con los campos de UcProductoCard
        private void AgregarProductoCard(
        int productoId,
        string nombre,
        decimal precio,
        Image imagen = null,
        bool disponible = true)
        {
            UcProductoCard card = new UcProductoCard();

            card.ProductoId = productoId;
            card.NombreProducto = nombre;
            card.Precio = precio;
            card.ImagenProducto = imagen;
            card.Disponible = disponible;

            card.ProductoAgregado += Card_ProductoAgregado;

            flpProducts.Controls.Add(card);
        }
        #endregion

        #region Metodo de instancia con los campos de UcOrderItem
        private void Card_ProductoAgregado(object sender, EventArgs e)
        {
            if (sender is UcProductoCard card)
            {
                AgregarProductoAlPedido(card);
            }
        }

        private void AgregarProductoAlPedido(UcProductoCard card)
        {
            UcOrderItem itemExistente = _orderItems.Find(item => item.ProductoId == card.ProductoId);

            if (itemExistente != null)
            {
                itemExistente.Cantidad++;

                ActualizarResumenPedido();

                return;
            }

            UcOrderItem nuevoItem = new UcOrderItem();

            nuevoItem.ProductoId = card.ProductoId;

            nuevoItem.NombreProducto = card.NombreProducto;

            nuevoItem.PrecioUnitario = card.Precio;

            nuevoItem.Cantidad = 1;

            nuevoItem.CantidadCambiada += OrderItem_CantidadCambiada;

            nuevoItem.ProductoEliminado += OrderItem_ProductoEliminado;

            _orderItems.Add(nuevoItem);

            flpOrderItems.Controls.Add(nuevoItem);

            ActualizarResumenPedido();
        }

        private void OrderItem_CantidadCambiada(object sender, EventArgs e)
        {
            ActualizarResumenPedido();
        }

        private void ActualizarResumenPedido()
        {
            decimal subtotal = 0;

            foreach (UcOrderItem item in _orderItems)
            {
                subtotal += item.Subtotal;
            }

            // Temporal
            this.Text =
                $"Punto de Venta - Total: " +
                subtotal.ToString(
                    "C",
                    System.Globalization.CultureInfo.GetCultureInfo("es-NI"));
        }

        private void OrderItem_ProductoEliminado(object sender,EventArgs e)
        {
            if (sender is UcOrderItem item)
            {
                _orderItems.Remove(item);

                flpOrderItems.Controls.Remove(item);

                item.Dispose();

                ActualizarResumenPedido();
            }
        }
        #endregion

    }
}
