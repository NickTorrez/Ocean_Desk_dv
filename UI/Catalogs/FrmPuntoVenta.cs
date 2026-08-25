using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ocean_Desk_dv.UI.MessageBox;
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

            ConfigurarTipoOrden(); //Relacion entre cmbTipoOrden y cmbMesa

            CargarProductosPrueba(); //Prueba de Productos

            ActualizarResumenPedido(); //Prueba de Orden a Cobrar

            ConfigurarBotonesCategorias(); //Colores y Efectos de las Categorias

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

        #region Metodo de configuración y coordinacion entre el Tipo de Orden y la Mesa
        private void ConfigurarTipoOrden()
        {
            cmbTipoOrden.Items.Clear();

            cmbTipoOrden.Items.Add("Local");
            cmbTipoOrden.Items.Add("Delivery");

            cmbTipoOrden.SelectedIndex = 0;

            CargarMesasPrueba();
        }

        private void CargarMesasPrueba()
        {
            cmbMesa.Items.Clear();

            for (int i = 1; i <= 8; i++)
            {
                cmbMesa.Items.Add(
                    $"{i:00}");
            }

            if (cmbMesa.Items.Count > 0)
                cmbMesa.SelectedIndex = 0;
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

            decimal descuento = 0;

            decimal total = subtotal - descuento;

            lblSubtotal.Text = subtotal.ToString(
                "C",
                System.Globalization.CultureInfo.GetCultureInfo("es-NI"));

            lblDescuento.Text = descuento.ToString(
                "C",
                System.Globalization.CultureInfo.GetCultureInfo("es-NI"));

            lblTotal.Text = total.ToString(
                "C",
                System.Globalization.CultureInfo.GetCultureInfo("es-NI"));

            btnCobrar.Text = $"COBRAR {total.ToString("C",
                System.Globalization.CultureInfo.GetCultureInfo("es-NI"))}";
            btnCobrar.Enabled = _orderItems.Count > 0;

            if (_orderItems.Count > 0)
            {
                btnCobrar.Enabled = true;
                btnCobrar.BackColor = Color.FromArgb(8, 126, 164);
            }
            else
            {
                btnCobrar.Enabled = false;
                btnCobrar.BackColor = Color.FromArgb(190, 196, 201);
            }
        }

        private void OrderItem_ProductoEliminado(object sender, EventArgs e)
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

        #region Apariencia y Funcion de Botones de OrederFooter
        private void btnCobrar_MouseEnter(object sender, EventArgs e)
        {
            btnCobrar.BackColor = Color.FromArgb(6, 105, 138);
        }

        private void btnCobrar_MouseLeave(object sender, EventArgs e)
        {
            btnCobrar.BackColor = Color.FromArgb(8, 126, 164);
        }

        private void btnCancelarVenta_MouseEnter(object sender, EventArgs e)
        {
            btnCancelarVenta.BackColor = Color.FromArgb(224, 234, 240);
        }

        private void btnCancelarVenta_MouseLeave(object sender, EventArgs e)
        {
            btnCancelarVenta.BackColor = Color.FromArgb(238, 243, 247);
        }

        private void btnCancelarVenta_Click(object sender, EventArgs e)
        {

            if (_orderItems.Count == 0)
                return;

            DialogResult resultado =
                FrmMessageBox.Show(
                    "¿Desea cancelar la venta actual?",
                    "Cancelar venta",
                    MessageType.Confirmation);


            if (resultado != DialogResult.Yes)
                return;

            _orderItems.Clear();

            flpOrderItems.Controls.Clear();

            ActualizarResumenPedido();
        }
        #endregion

        #region Relación entre la tipo de orden y disponibilidad de mesa
        private void cmbTipoOrden_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool esLocal = cmbTipoOrden.SelectedItem?.ToString() == "Local";

            cmbMesa.Enabled = esLocal;

            if (!esLocal)
            {
                cmbMesa.SelectedIndex = -1;
            }
            else if (cmbMesa.Items.Count > 0)
            {
                cmbMesa.SelectedIndex = 0;
            }
        }
        #endregion

        // Estado normal
        private readonly Color _colorNormal = Color.FromArgb(8, 31, 63);

        // Hover
        private readonly Color _colorHover = Color.FromArgb(20, 52, 90);

        // Activo
        private readonly Color _colorActivo = Color.FromArgb(8, 126, 164);

        // Texto normal
        private readonly Color _colorTextoNormal = Color.White;

        // Texto activo
        private readonly Color _colorTextoActivo = Color.White;

        private Button _categoriaActiva;

        private void ActivarCategoria(Button boton)
        {
            // Restaurar botón anteriormente activo
            if (_categoriaActiva != null)
            {
                _categoriaActiva.BackColor = _colorNormal;
                _categoriaActiva.ForeColor = _colorTextoNormal;
            }

            // Activar nuevo botón
            _categoriaActiva = boton;

            _categoriaActiva.BackColor = _colorActivo;
            _categoriaActiva.ForeColor = _colorTextoActivo;
        }

        private void Categoria_MouseEnter(object sender, EventArgs e)
        {
            if (sender is not Button boton)
                return;

            // Si ya está activo, no modificarlo
            if (boton == _categoriaActiva)
                return;

            boton.BackColor = _colorHover;
        }

        private void Categoria_MouseLeave(object sender, EventArgs e)
        {
            if (sender is not Button boton)
                return;

            // Si está activo, conservar su estado
            if (boton == _categoriaActiva)
                return;

            boton.BackColor = _colorNormal;
        }

        private void Categoria_Click(object sender, EventArgs e)
        {
            if (sender is not Button boton)
                return;

            ActivarCategoria(boton);
        }

        private void ConfigurarBotonesCategorias()
        {
            Button[] botones =
            {
                btnCatCeviche,
                btnCatMariscos,
                btnCatEntradas,
                btnCatBebidas,
                btnCatExtras,
                btnCatPostres
            };

            foreach (Button boton in botones)
            {
                boton.BackColor = _colorNormal;
                boton.ForeColor = _colorTextoNormal;

                boton.FlatStyle = FlatStyle.Flat;
                boton.FlatAppearance.BorderSize = 0;
                boton.Cursor = Cursors.Hand;
                boton.UseVisualStyleBackColor = false;

                boton.MouseEnter += Categoria_MouseEnter;
                boton.MouseLeave += Categoria_MouseLeave;
                boton.Click += Categoria_Click;
            }

            ActivarCategoria(btnCatCeviche);
        }
    }
}
