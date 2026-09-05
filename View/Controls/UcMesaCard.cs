using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ocean_Desk_dv.UI.Controls
{
    public enum EstadoMesa //Declarar propiedades de Estado de las Mesas para mandarlos a llamar
    {
        Disponible,
        Ocupada,
        Reservada,
        Mantenimiento
    }

    public partial class UcMesaCard : UserControl
    {
        #region Campos, propiedades y encapsulamiento
        private int _mesaId;
        private int _numeroMesa;
        private int _capacidad;
        private EstadoMesa _estado = EstadoMesa.Disponible;

        //Campos para comportamientos de Selección y Colores
        public event EventHandler MesaSeleccionada;
        private bool _seleccionada;

        public int MesaId
        {
            get => _mesaId;
            set => _mesaId = value;
        }

        public int NumeroMesa
        {
            get => _numeroMesa;
            set
            {
                _numeroMesa = value;
                lblNumeroMesa.Text = $"MESA {value:00}";
            }
        }

        public int Capacidad
        {
            get => _capacidad;
            set
            {
                _capacidad = value;
                lblCapacidad.Text =
                    $"{value} personas";
            }
        }

        public EstadoMesa Estado
        {
            get => _estado;
            set
            {
                _estado = value;
                ActualizarEstadoVisual();
            }
        }
        #endregion

        #region Constructor
        public UcMesaCard()
        {
            InitializeComponent();

            ConfigurarEventos();

            Cursor = Cursors.Hand;

            ActualizarEstadoVisual();
        }
        #endregion

        #region Metodos de Comportamiento de la Tarjeta
        private void ActualizarEstadoVisual()
        {
            switch (_estado)
            {
                case EstadoMesa.Disponible:

                    lblEstado.Text = "DISPONIBLE";

                    pnlEstado.BackColor = Color.FromArgb(232, 244, 238);

                    lblEstado.ForeColor = Color.FromArgb(42, 122, 82);

                    break;

                case EstadoMesa.Ocupada:

                    lblEstado.Text = "OCUPADA";

                    pnlEstado.BackColor = Color.FromArgb(255, 244, 229);

                    lblEstado.ForeColor = Color.FromArgb(181, 119, 23);

                    break;

                case EstadoMesa.Reservada:

                    lblEstado.Text = "RESERVADA";

                    pnlEstado.BackColor = Color.FromArgb(232, 241, 248);

                    lblEstado.ForeColor = Color.FromArgb(8, 126, 164);

                    break;

                case EstadoMesa.Mantenimiento:

                    lblEstado.Text = "MANTENIMIENTO";

                    pnlEstado.BackColor = Color.FromArgb(240, 242, 244);

                    lblEstado.ForeColor = Color.FromArgb(111, 119, 128);

                    break;
            }
        }

        private void ConfigurarEventos()
        {
            Control[] controles =
           {
                this,
                lblNumeroMesa,
                lblCapacidad,
                pnlEstado,
                lblEstado
            };

            foreach (Control control in controles)
            {
                control.Click += ControlMesa_Click;
                control.MouseEnter += ControlMesa_MouseEnter;
                control.MouseLeave += ControlMesa_MouseLeave;
            }
        }

        private void ControlMesa_Click(object sender,EventArgs e)
        {
            MesaSeleccionada?.Invoke(this,EventArgs.Empty);
        }

        private void ControlMesa_MouseEnter(object sender,EventArgs e)
        {
            BackColor = Color.FromArgb(245, 249, 252);
        }

        private void ControlMesa_MouseLeave(object sender,EventArgs e)
        {
            BackColor = Color.White;
        }

        public bool Seleccionada
        {
            get => _seleccionada;
            set
            {
                _seleccionada = value;
                ActualizarSeleccionVisual();
            }
        }

        private void ActualizarSeleccionVisual()
        {
            if (_seleccionada)
            {
                Padding = new Padding(2);

                pnlEstado.Padding = new Padding(6, 2, 6, 6);

                BackColor = Color.FromArgb(175,238,238);
            }
            else
            {
                Padding = new Padding(0);

                pnlEstado.Padding = new Padding(8, 2, 8, 8);

                BackColor = Color.White;
            }
        }

        #endregion
    }
}
