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

        #region Propiedades de Tarjetas
        private int _productoId;
        private string _nombreProducto = string.Empty;
        private decimal _precio;

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
                _nombreProducto = value ?? string.Empty;
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
            set => picProducto.Image = value;
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
            btnAgregar.Click += ControlProducto_Click;
            picProducto.Click += ControlProducto_Click;
            lblNombreProducto.Click += ControlProducto_Click;
            lblPrecio.Click += ControlProducto_Click;
        }
        #endregion

        #region Evento General del Producto
        private void ControlProducto_Click(object sender, EventArgs e)
        {
            ProductoAgregado?.Invoke(this, EventArgs.Empty);
        }
        #endregion

        #region Ajustes en la Apariencia
        private void UcProductoCard_MouseEnter(object sender, EventArgs e)
        {
            BackColor = Color.FromArgb(245, 249, 252);
        }

        private void UcProductoCard_MouseLeave(object sender, EventArgs e)
        {
            BackColor = Color.White;
        }
        #endregion

    }
}
