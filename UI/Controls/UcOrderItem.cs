using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ocean_Desk_dv.UI.Controls
{
    public partial class UcOrderItem : UserControl
    {
        #region Eventos Matematicos
        public event EventHandler CantidadCambiada;
        public event EventHandler ProductoEliminado;
        #endregion

        #region Colores para Btones
        private readonly Color _colorNormal = Color.White;
        private readonly Color _colorHover = Color.FromArgb(248, 251, 253);
        private readonly Color _colorControlNormal = Color.FromArgb(238, 243, 247);
        private readonly Color _colorControlHover = Color.FromArgb(224, 234, 240);
        #endregion

        #region Constructor
        public UcOrderItem()
        {
            InitializeComponent();

            ConfigurarEventos(); //Metodo para eventos matematicos 
        }
        #endregion


        #region Campos y Propiedades de Tarjeta
        private int _productoId;
        private string _nombreProducto = string.Empty;
        private decimal _precioUnitario;
        private int _cantidad = 1;

        public int ProductoId
        {
            get => _productoId;
            set => _productoId = value;
        }

        public string NombreProducto
        {
            get => _nombreProducto;
            set
            {
                _nombreProducto = value?.Trim() ?? string.Empty;
                lblNombreProducto.Text = _nombreProducto;
            }
        }

        public decimal PrecioUnitario
        {
            get => _precioUnitario;
            set
            {
                _precioUnitario = value;

                lblPrecioUnitario.Text =
                    value.ToString(
                        "C",
                        CultureInfo.GetCultureInfo("es-NI"));

                ActualizarSubtotal();
            }
        }

        public int Cantidad
        {
            get => _cantidad;
            set
            {
                if (value < 1)
                    value = 1;

                _cantidad = value;

                lblCantidad.Text = _cantidad.ToString();

                ActualizarSubtotal();
            }
        }

        public decimal Subtotal
        {
            get => _precioUnitario * _cantidad;
        }
        #endregion

        #region Metodos para Controles 
        private void ActualizarSubtotal()
        {
            decimal subtotal = _precioUnitario * _cantidad;

            lblSubtotal.Text = subtotal.ToString(
                "C",
                CultureInfo.GetCultureInfo("es-NI"));
        }

        private void ConfigurarEventos()
        {
            btnAumentar.Click += BtnAumentar_Click;
            btnDisminuir.Click += BtnDisminuir_Click;
            btnEliminar.Click += BtnEliminar_Click;

            MouseEnter += Control_MouseEnter;
            MouseLeave += Control_MouseLeave;

            lblNombreProducto.MouseEnter += Control_MouseEnter;
            lblNombreProducto.MouseLeave += Control_MouseLeave;

            lblPrecioUnitario.MouseEnter += Control_MouseEnter;
            lblPrecioUnitario.MouseLeave += Control_MouseLeave;

            pnlBottom.MouseEnter += Control_MouseEnter;
            pnlBottom.MouseLeave += Control_MouseLeave;

            pnlBottom.MouseEnter += Control_MouseEnter;
            pnlBottom.MouseLeave += Control_MouseLeave;

            btnDisminuir.MouseEnter += Control_MouseEnter;
            btnDisminuir.MouseLeave += Control_MouseLeave;

            btnAumentar.MouseEnter += Control_MouseEnter;
            btnAumentar.MouseLeave += Control_MouseLeave;

            btnEliminar.MouseEnter += BtnEliminar_MouseEnter;
            btnEliminar.MouseLeave += BtnEliminar_MouseLeave;
        }

        private void BtnAumentar_Click(object sender, EventArgs e)
        {
            Cantidad++;

            CantidadCambiada?.Invoke(
                this,
                EventArgs.Empty);
        }

        private void BtnDisminuir_Click(object sender, EventArgs e)
        {
            if (Cantidad <= 1)
                return;

            Cantidad--;

            CantidadCambiada?.Invoke(
                this,
                EventArgs.Empty);
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            ProductoEliminado?.Invoke(
                this,
                EventArgs.Empty);
        }

        private void Control_MouseEnter(object sender, EventArgs e)
        {
            BackColor = _colorHover;

            btnDisminuir.BackColor = _colorControlHover;
            btnAumentar.BackColor = _colorControlHover;
        }

        private void Control_MouseLeave(object sender, EventArgs e)
        {
            BackColor = _colorNormal;

            btnDisminuir.BackColor = _colorControlNormal;
            btnAumentar.BackColor = _colorControlNormal;
        }

        private void BtnEliminar_MouseEnter(
        object sender,
        EventArgs e)
        {
            btnEliminar.ForeColor =
                Color.FromArgb(8, 31, 63);
        }

        private void BtnEliminar_MouseLeave(
        object sender,
        EventArgs e)
        {
            btnEliminar.ForeColor =
                Color.FromArgb(111, 119, 128);
        }
        #endregion

    }
}
