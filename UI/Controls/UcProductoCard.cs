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
    public partial class UcProductoCard : UserControl
    {
        public event EventHandler ProductoAgregado; //Evento Reutilizable

        #region Campos y Propiedades de Tarjeta
        private int _productoId;
        private string _nombreProducto = string.Empty;
        private decimal _precio;
        private bool _disponible = true;
        private decimal _stock;
        private readonly Color _colorNormal = Color.White;
        private readonly Color _colorHover = Color.FromArgb(245, 249, 252);
        private readonly Color _colorBotonNormal = Color.FromArgb(8, 126, 164);
        private readonly Color _colorBotonHover = Color.FromArgb(6, 105, 138);

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

        public decimal Precio
        {
            get => _precio;
            set
            {
                _precio = value;
                lblPrecio.Text = value.ToString(
                    "C",
                    CultureInfo.GetCultureInfo("es-NI"));
            }
        }

        public Image ImagenProducto
        {
            get => picProducto.Image;
            set
            {
                if (value == null)
                {
                    picProducto.Image = Properties.Resources.producto_default;
                }
                else
                {
                    picProducto.Image = value;
                }
            }
        }

        public bool Disponible
        {
            get => _disponible;

            set
            {
                _disponible = value;
                ActualizarEstadoDisponibilidad();
            }
        }

        public decimal Stock
        {
            get => _stock;

            set
            {
                _stock = value;

                if (_stock <= 0)
                {
                    Disponible = false;
                }
            }
        }
        #endregion

        #region Constructor
        public UcProductoCard()
        {
            InitializeComponent();

            ConfigurarEventos();

            Cursor = Cursors.Hand;
        }
        #endregion

        #region Configurar Eventos
        private void ConfigurarEventos()
        {
            // Click
            btnAgregar.Click += ControlProducto_Click;
            picProducto.Click += ControlProducto_Click;
            lblNombreProducto.Click += ControlProducto_Click;
            lblPrecio.Click += ControlProducto_Click;

            // Hover de toda la tarjeta
            MouseEnter += Control_MouseEnter;
            MouseLeave += Control_MouseLeave;

            picProducto.MouseEnter += Control_MouseEnter;
            picProducto.MouseLeave += Control_MouseLeave;

            lblNombreProducto.MouseEnter += Control_MouseEnter;
            lblNombreProducto.MouseLeave += Control_MouseLeave;

            lblPrecio.MouseEnter += Control_MouseEnter;
            lblPrecio.MouseLeave += Control_MouseLeave;

            btnAgregar.MouseEnter += Control_MouseEnter;
            btnAgregar.MouseLeave += Control_MouseLeave;
        }
        #endregion

        #region Evento General del Producto
        private void ControlProducto_Click(object sender, EventArgs e)
        {
            if (!_disponible)
                return;

            ProductoAgregado?.Invoke(this, EventArgs.Empty);
        }
        #endregion

        #region Ajustes en la Apariencia
        private void Control_MouseEnter(object sender, EventArgs e)
        {
            if (!_disponible)
                return;

            BackColor = _colorHover;
            btnAgregar.BackColor = _colorBotonHover;
        }

        private void Control_MouseLeave(object sender, EventArgs e)
        {
            if (!_disponible)
                return;

            BackColor = _colorNormal;
            btnAgregar.BackColor = _colorBotonNormal;
        }
        #endregion

        #region Metodo de Agotamiento
        private void ActualizarEstadoDisponibilidad()
        {
            if (_disponible)
            {
                BackColor = _colorNormal;

                btnAgregar.Enabled = true;
                btnAgregar.Text = "AGREGAR";
                btnAgregar.BackColor = _colorBotonNormal;
                btnAgregar.ForeColor = Color.White;

                lblNombreProducto.ForeColor = Color.FromArgb(8, 31, 63);
                lblPrecio.ForeColor = Color.FromArgb(11, 120, 166);

                picProducto.Enabled = true;

                Cursor = Cursors.Hand;
            }
            else
            {
                BackColor = Color.FromArgb(248, 248, 248);

                btnAgregar.Enabled = false;
                btnAgregar.Text = "AGOTADO";
                btnAgregar.BackColor = Color.FromArgb(190, 196, 201);
                btnAgregar.ForeColor = Color.FromArgb(90, 95, 100);

                lblNombreProducto.ForeColor = Color.FromArgb(130, 135, 140);
                lblPrecio.ForeColor = Color.FromArgb(150, 155, 160);

                picProducto.Enabled = false;

                Cursor = Cursors.Default;
            }
        }
        #endregion

    }
}
