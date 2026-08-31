using Ocean_Desk_dv.UI.Controls;
using Ocean_Desk_dv.UI.MessageBox;
using Ocean_Desk_dv.UI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ocean_Desk_dv.UI.Catalogs
{
    public partial class FrmMesasReservas : Form
    {
        private readonly List<ReservaPrueba> _reservas = new List<ReservaPrueba>(); //Datos de Prueba dgvReservas

        #region Constructor
        public FrmMesasReservas()
        {
            InitializeComponent();

            CargarMesasPrueba();

            CargarReservasPrueba();

            MostrarReservas();
        }
        #endregion

        #region Metodos para Carga de Controles en flpMesas
        private UcMesaCard _mesaSeleccionada;

        private void CargarMesasPrueba()
        {
            flpMesas.Controls.Clear();

            AgregarMesaPrueba(
                1,
                1,
                4,
                EstadoMesa.Disponible);

            AgregarMesaPrueba(
                2,
                2,
                4,
                EstadoMesa.Ocupada);

            AgregarMesaPrueba(
                3,
                3,
                6,
                EstadoMesa.Reservada);

            AgregarMesaPrueba(
                4,
                4,
                2,
                EstadoMesa.Mantenimiento);

            AgregarMesaPrueba(
                5,
                5,
                4,
                EstadoMesa.Disponible);

            AgregarMesaPrueba(
                6,
                6,
                6,
                EstadoMesa.Disponible);
        }

        private void AgregarMesaPrueba(int mesaId, int numero, int capacidad, EstadoMesa estado)
        {
            UcMesaCard mesa =
                new UcMesaCard();

            mesa.MesaId = mesaId;
            mesa.NumeroMesa = numero;
            mesa.Capacidad = capacidad;
            mesa.Estado = estado;

            mesa.MesaSeleccionada +=
                Mesa_MesaSeleccionada;

            flpMesas.Controls.Add(mesa);
        }

        private void Mesa_MesaSeleccionada(object sender, EventArgs e)
        {
            if (sender is not UcMesaCard mesa)
                return;

            if (_mesaSeleccionada != null)
            {
                _mesaSeleccionada.Seleccionada =
                    false;
            }

            _mesaSeleccionada = mesa;

            _mesaSeleccionada.Seleccionada =
                true;
        }
        #endregion

        #region Metodos para Carga de Datos en dgvReservas
        private void CargarReservasPrueba()
        {
            _reservas.Clear();

            _reservas.Add(new ReservaPrueba
            {
                ReservaId = 1,
                Cliente = "Juan Pérez",
                Fecha = DateTime.Today,
                Hora = new TimeSpan(19, 0, 0),
                Personas = 4,
                Mesa = 5,
                Estado = "Confirmada"
            });

            _reservas.Add(new ReservaPrueba
            {
                ReservaId = 2,
                Cliente = "María López",
                Fecha = DateTime.Today,
                Hora = new TimeSpan(20, 0, 0),
                Personas = 2,
                Mesa = 2,
                Estado = "Pendiente"
            });

            _reservas.Add(new ReservaPrueba
            {
                ReservaId = 3,
                Cliente = "Carlos Rodríguez",
                Fecha = DateTime.Today.AddDays(1),
                Hora = new TimeSpan(19, 30, 0),
                Personas = 6,
                Mesa = null,
                Estado = "Pendiente"
            });

            _reservas.Add(new ReservaPrueba
            {
                ReservaId = 4,
                Cliente = "Ana Martínez",
                Fecha = DateTime.Today.AddDays(1),
                Hora = new TimeSpan(21, 0, 0),
                Personas = 3,
                Mesa = 4,
                Estado = "Confirmada"
            });

            _reservas.Add(new ReservaPrueba
            {
                ReservaId = 5,
                Cliente = "Pedro Gómez",
                Fecha = DateTime.Today.AddDays(-1),
                Hora = new TimeSpan(18, 30, 0),
                Personas = 2,
                Mesa = 1,
                Estado = "Atendida"
            });

            _reservas.Add(new ReservaPrueba
            {
                ReservaId = 6,
                Cliente = "Laura Sánchez",
                Fecha = DateTime.Today.AddDays(-2),
                Hora = new TimeSpan(20, 0, 0),
                Personas = 5,
                Mesa = null,
                Estado = "Cancelada"
            });
        }

        private void MostrarReservas()
        {
            dgvReservas.DataSource = null;
            dgvReservas.DataSource = _reservas;

            dgvReservas.CurrentCell = null;
            dgvReservas.ClearSelection();

            ActualizarEstadoBotonesReserva();
        }

        private void ActualizarEstadoBotonesReserva()
        {
            bool haySeleccion = dgvReservas.SelectedRows.Count > 0;

            btnEditarReserva.Enabled = haySeleccion;
            btnCancelarReserva.Enabled = haySeleccion;

            if (!haySeleccion)
            {
                btnAsignarMesa.Enabled = false;
                return;
            }

            DataGridViewRow fila = dgvReservas.SelectedRows[0];

            ReservaPrueba reserva = fila.DataBoundItem as ReservaPrueba;

            if (reserva == null)
            {
                btnAsignarMesa.Enabled = false;
                return;
            }

            bool puedeAsignar =
                reserva.Estado == "Pendiente" ||
                reserva.Estado == "Confirmada";

            btnAsignarMesa.Enabled = puedeAsignar;
        }

        private void dgvReservas_SelectionChanged(object sender, EventArgs e)
        {
            ActualizarEstadoBotonesReserva();
        }

        private void dgvReservas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == colReservaMesa.Index)
            {
                if (e.Value == null ||
                    e.Value == DBNull.Value)
                {
                    e.Value = "-";
                    e.FormattingApplied = true;
                }
            }

            if (e.ColumnIndex == colReservaEstado.Index)
            {
                if (e.Value == null)
                    return;

                string estado = e.Value.ToString();

                if (estado == "Pendiente")
                {
                    e.CellStyle.ForeColor = Color.FromArgb(181, 119, 23);

                    e.CellStyle.Font =
                        new Font(
                            dgvReservas.Font,
                            FontStyle.Bold);
                }
                else if (estado == "Confirmada")
                {
                    e.CellStyle.ForeColor = Color.FromArgb(8, 126, 164);

                    e.CellStyle.Font =
                        new Font(
                            dgvReservas.Font,
                            FontStyle.Bold);
                }
                else if (estado == "Atendida")
                {
                    e.CellStyle.ForeColor = Color.FromArgb(42, 122, 82);

                    e.CellStyle.Font =
                        new Font(
                            dgvReservas.Font,
                            FontStyle.Bold);
                }
                else if (estado == "Cancelada")
                {
                    e.CellStyle.ForeColor = Color.FromArgb(163, 61, 61);

                    e.CellStyle.Font =
                        new Font(
                            dgvReservas.Font,
                            FontStyle.Bold);
                }
            }
        }
        #endregion

        #region Metodos para Panel de Nueva Reserva
        private void CargarMesasParaReserva()
        {
            cmbMesaReserva.Items.Clear();

            cmbMesaReserva.Items.Add("Sin asignar");

            foreach (Control control in flpMesas.Controls)
            {
                if (control is UcMesaCard mesa &&
                    mesa.Estado == EstadoMesa.Disponible)
                {
                    cmbMesaReserva.Items.Add(
                        $"Mesa {mesa.NumeroMesa:00}");  
                }
            }

            if (cmbMesaReserva.Items.Count > 0)
            {
                cmbMesaReserva.SelectedIndex = 0;
            }
        }

        private void btnNuevaReserva_Click(object sender, EventArgs e)
        {
            CargarMesasParaReserva();

            LimpiarFormularioNuevaReserva();

            pnlReservas.Visible = false;
            pnlNuevaReserva.Visible = true;
        }

        private void LimpiarFormularioNuevaReserva()
        {
            txtClienteReserva.Clear();

            dtpFechaNuevaReserva.Value =
                DateTime.Today;

            dtpHoraNuevaReserva.Value =
                DateTime.Today.AddHours(19);

            nudPersonas.Value = 2;

            if (cmbMesaReserva.Items.Count > 0)
            {
                cmbMesaReserva.SelectedIndex = 0;
            }
            else
            {
                cmbMesaReserva.SelectedIndex = -1;
            }
        }

        private void btnGuardarNuevaReserva_Click(object sender, EventArgs e)
        {
            string cliente = txtClienteReserva.Text.Trim();

            if (string.IsNullOrWhiteSpace(cliente))
            {
                FrmMessageBox.Show(
                    "Ingrese el nombre del cliente.",
                    "Cliente requerido",
                    MessageType.Warning);

                txtClienteReserva.Focus();

                return;
            }

            if (dtpFechaNuevaReserva.Value.Date < DateTime.Today)
            {
                FrmMessageBox.Show(
                    "La fecha de la reserva no puede ser anterior a la fecha actual.",
                    "Fecha inválida",
                    MessageType.Warning);

                return;
            }

            string mesaSeleccionada = cmbMesaReserva.SelectedItem?.ToString() ?? "Sin asignar";

            int? mesa = null;

            if (mesaSeleccionada != "Sin asignar")
            {
                string numeroTexto =
                    mesaSeleccionada.Replace("Mesa ", "");

                if (int.TryParse(
                    numeroTexto,
                    out int numeroMesa))
                {
                    mesa = numeroMesa;
                }
            }

            ReservaPrueba nuevaReserva = new ReservaPrueba
            {
                ReservaId = _reservas.Count == 0 ? 1 : _reservas.Max(r => r.ReservaId) + 1,

                Cliente = cliente,

                Fecha =
                        dtpFechaNuevaReserva.Value.Date,

                Hora =
                        dtpHoraNuevaReserva.Value.TimeOfDay,

                Personas =
                        (int)nudPersonas.Value,

                Mesa = mesa,

                Estado = "Pendiente"
            };

            _reservas.Add(nuevaReserva);

            MostrarReservas();

            pnlNuevaReserva.Visible = false;
            pnlReservas.Visible = true;

            FrmMessageBox.Show(
                "La reserva ha sido registrada correctamente.",
                "Reserva registrada",
                MessageType.Information);
        }

        private void btnCancelarNuevaReserva_Click(object sender, EventArgs e)
        {
            pnlNuevaReserva.Visible = false;
            pnlReservas.Visible = true;
        }
        #endregion
    }
}
