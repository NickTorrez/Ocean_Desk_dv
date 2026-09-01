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

            dgvReservas.AutoGenerateColumns = false;

            ConfigurarColumnasReservas();

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
        private ReservaPrueba _reservaEditando;

        private void ConfigurarColumnasReservas()
        {
            dgvReservas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            colReservaCliente.DisplayIndex = 0;
            colReservaFecha.DisplayIndex = 1;
            colReservaHora.DisplayIndex = 2;
            colReservaPersonas.DisplayIndex = 3;
            colReservaMesa.DisplayIndex = 4;
            colReservaEstado.DisplayIndex = 5;
        }
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

        private void ActualizarEstadoMesa(int numeroMesa, EstadoMesa nuevoEstado)
        {
            foreach (Control control in flpMesas.Controls)
            {
                if (control is UcMesaCard mesa &&
                    mesa.NumeroMesa == numeroMesa)
                {
                    mesa.Estado = nuevoEstado;
                    return;
                }
            }
        }
        #endregion

        #region Metodos para Panel de Nueva Reserva
        /// <summary>
        /// Centra el panel de nueva reserva dentro del contenedor.
        /// </summary>
        private void CentrarNuevaReserva()
        {
            pnlNuevaReserva.Left =
                (pnlNuevaReservaContainer.Width -
                 pnlNuevaReserva.Width) / 2;

            pnlNuevaReserva.Top =
                (pnlNuevaReservaContainer.Height -
                 pnlNuevaReserva.Height) / 2;
        }

        /// <summary>
        /// Carga las mesas disponibles en el ComboBox de selección de mesa para la nueva reserva.
        /// </summary>
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

        /// <summary>
        /// Muestra el panel de nueva reserva y oculta el panel de reservas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNuevaReserva_Click(object sender, EventArgs e)
        {
            _reservaEditando = null;

            CargarMesasParaReserva();

            LimpiarFormularioNuevaReserva();

            pnlReservas.Visible = false;
            pnlNuevaReservaContainer.Visible = true;

            pnlNuevaReserva.Visible = true;
            pnlNuevaReserva.BringToFront();

            CentrarNuevaReserva();

            lblTituloNuevaReserva.Text = "Nueva reserva";

            btnGuardarNuevaReserva.Text = "GUARDAR RESERVA";
        }

        /// <summary>
        /// Limpia los campos del formulario de nueva reserva y establece valores predeterminados.
        /// </summary>
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

        /// <summary>
        /// Maneja el evento de clic del botón de guardar nueva reserva, creando una nueva reserva o guardando los cambios en una reserva existente según corresponda.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardarNuevaReserva_Click(object sender, EventArgs e)
        {
            if (_reservaEditando == null)
            {
                CrearNuevaReserva();
            }
            else
            {
                GuardarCambiosReserva();
            }

        }

        /// <summary>
        /// Crea una nueva reserva o guarda los cambios en una reserva existente.
        /// </summary>
        public void CrearNuevaReserva()
        {
            string cliente = txtClienteReserva.Text.Trim();

            //Validar Cliente
            if (string.IsNullOrWhiteSpace(cliente))
            {
                FrmMessageBox.Show(
                    "Ingrese el nombre del cliente.",
                    "Cliente requerido",
                    MessageType.Warning);

                txtClienteReserva.Focus();

                return;
            }

            //Validar Fecha
            if (dtpFechaNuevaReserva.Value.Date < DateTime.Today)
            {
                FrmMessageBox.Show(
                    "La fecha de la reserva no puede ser anterior a la fecha actual.",
                    "Fecha inválida",
                    MessageType.Warning);

                return;
            }

            //Obtener Mesa Seleccionada
            string mesaSeleccionada = cmbMesaReserva.SelectedItem?.ToString() ?? "Sin asignar";

            int? mesa = ObtenerNumeroMesaSeleccionada(mesaSeleccionada);

            if (mesa.HasValue)
            {
                UcMesaCard mesaCard =
                    flpMesas.Controls
                        .OfType<UcMesaCard>()
                        .FirstOrDefault(
                            m => m.NumeroMesa == mesa.Value);

                if (mesaCard == null || mesaCard.Estado != EstadoMesa.Disponible)
                {
                    FrmMessageBox.Show(
                        "La mesa seleccionada ya no se encuentra disponible.",
                        "Mesa no disponible",
                        MessageType.Warning);

                    return;
                }
            }

            //Crear Nueva Reserva
            ReservaPrueba nuevaReserva = new ReservaPrueba
            {
                ReservaId = _reservas.Count == 0 ? 1 : _reservas.Max(r => r.ReservaId) + 1,

                Cliente = cliente,

                Fecha = dtpFechaNuevaReserva.Value.Date,

                Hora = dtpHoraNuevaReserva.Value.TimeOfDay,

                Personas = (int)nudPersonas.Value,

                Mesa = mesa,

                Estado = "Pendiente"
            };

            //Agregar Reserva a la Lista y Actualizar Estado de la Mesa si es necesario
            _reservas.Add(nuevaReserva);

            if (mesa.HasValue)
            {
                ActualizarEstadoMesa(mesa.Value,EstadoMesa.Reservada);
            }

            //Actualizar DGV
            MostrarReservas();

            //Regresar a las Reservas y Mostrar Mensaje de Éxito
            pnlNuevaReservaContainer.Visible = false;
            pnlReservas.Visible = true;

            FrmMessageBox.Show(
                "La reserva ha sido registrada correctamente.",
                "Reserva registrada",
                MessageType.Information);
        }

        /// <summary>
        /// Cancela la creación o edición de una reserva y regresa al panel de reservas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelarNuevaReserva_Click(object sender, EventArgs e)
        {
            pnlNuevaReservaContainer.Visible = false;
            pnlReservas.Visible = true;
        }

        /// <summary>
        /// Permite editar una reserva seleccionada en el DataGridView de reservas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditarReserva_Click(object sender, EventArgs e)
        {
            if (dgvReservas.SelectedRows.Count == 0)
            {
                FrmMessageBox.Show(
                    "Seleccione una reserva para editar.",
                    "Reserva no seleccionada",
                    MessageType.Warning);

                return;
            }

            DataGridViewRow fila =
                dgvReservas.SelectedRows[0];

            ReservaPrueba reserva =
                fila.DataBoundItem as ReservaPrueba;

            if (reserva == null)
            {
                FrmMessageBox.Show(
                    "No fue posible obtener la información de la reserva seleccionada.",
                    "Error",
                    MessageType.Error);

                return;
            }

            _reservaEditando = reserva;

            CargarMesasParaReserva(reserva.Mesa);
            CargarDatosReserva(reserva);

            pnlReservas.Visible = false;
            pnlNuevaReservaContainer.Visible = true;

            pnlNuevaReserva.BringToFront();

            CentrarNuevaReserva();

            lblTituloNuevaReserva.Text = "Editar reserva";
            btnGuardarNuevaReserva.Text = "GUARDAR CAMBIOS";
        }

        /// <summary>
        /// Carga los datos de la reserva seleccionada en los controles del formulario de edición.
        /// </summary>
        /// <param name="reserva"></param>
        private void CargarDatosReserva(ReservaPrueba reserva)
        {
            txtClienteReserva.Text = reserva.Cliente;

            dtpFechaNuevaReserva.Value = reserva.Fecha;

            dtpHoraNuevaReserva.Value = DateTime.Today.Add(reserva.Hora);

            nudPersonas.Value = reserva.Personas;

            if (reserva.Mesa.HasValue)
            {
                string mesaTexto = $"Mesa {reserva.Mesa.Value:00}";

                int indice = cmbMesaReserva.Items.IndexOf(mesaTexto);

                if (indice >= 0)
                {
                    cmbMesaReserva.SelectedIndex = indice;
                }
                else
                {
                    cmbMesaReserva.SelectedIndex = 0;
                }
            }
            else
            {
                cmbMesaReserva.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Carga las mesas disponibles en el ComboBox de selección de mesa para la reserva, incluyendo la mesa actual si se está editando una reserva.
        /// </summary>
        /// <param name="mesaActual"></param>
        private void CargarMesasParaReserva(int? mesaActual = null)
        {
            cmbMesaReserva.Items.Clear();

            cmbMesaReserva.Items.Add("Sin asignar");

            foreach (Control control in flpMesas.Controls)
            {
                if (control is not UcMesaCard mesa)
                    continue;

                bool disponible = mesa.Estado == EstadoMesa.Disponible;

                bool esMesaActual =
                    mesaActual.HasValue &&
                    mesa.NumeroMesa == mesaActual.Value;

                if (disponible || esMesaActual)
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

        /// <summary>
        /// Obtiene el número de la mesa seleccionada a partir de su texto representativo.
        /// </summary>
        /// <param name="mesaSeleccionada"></param>
        /// <returns></returns>
        private int? ObtenerNumeroMesaSeleccionada(string mesaSeleccionada)
        {
            if (mesaSeleccionada == "Sin asignar")
                return null;

            string numeroTexto = mesaSeleccionada.Replace("Mesa","");

            if (int.TryParse(numeroTexto, out int numeroMesa))
            {
                return numeroMesa;
            }

            return null;
        }

        /// <summary>
        /// Cierra el panel de nueva reserva y regresa al panel de reservas, restableciendo los valores predeterminados.
        /// </summary>
        private void CerrarPanelReserva()
        {
            pnlNuevaReserva.Visible = false;
            pnlNuevaReservaContainer.Visible = false;

            pnlReservas.Visible = true;

            _reservaEditando = null;

            lblTituloNuevaReserva.Text =
                "Nueva reserva";

            btnGuardarNuevaReserva.Text =
                "GUARDAR RESERVA";
        }

        /// <summary>
        /// Guarda los cambios realizados en una reserva existente, validando los datos y actualizando el estado de la mesa si es necesario.
        /// </summary>
        private void GuardarCambiosReserva()
        {
            if (_reservaEditando == null)
                return;

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

            int? nuevaMesa = ObtenerNumeroMesaSeleccionada(mesaSeleccionada);

            int? mesaAnterior = _reservaEditando.Mesa;

            if (nuevaMesa.HasValue && nuevaMesa != mesaAnterior)
            {
                UcMesaCard mesaCard =
                    flpMesas.Controls
                        .OfType<UcMesaCard>()
                        .FirstOrDefault(
                            m => m.NumeroMesa == nuevaMesa.Value);

                if (mesaCard == null || mesaCard.Estado != EstadoMesa.Disponible)
                {
                    FrmMessageBox.Show(
                        "La nueva mesa seleccionada no se encuentra disponible.",
                        "Mesa no disponible",
                        MessageType.Warning);

                    return;
                }
            }

            _reservaEditando.Cliente = cliente;

            _reservaEditando.Fecha = dtpFechaNuevaReserva.Value.Date;

            _reservaEditando.Hora = dtpHoraNuevaReserva.Value.TimeOfDay;

            _reservaEditando.Personas = (int)nudPersonas.Value;

            _reservaEditando.Mesa = nuevaMesa;

            if (mesaAnterior.HasValue &&
                mesaAnterior != nuevaMesa)
            {
                ActualizarEstadoMesa(
                    mesaAnterior.Value,
                    EstadoMesa.Disponible);
            }

            if (nuevaMesa.HasValue &&
                mesaAnterior != nuevaMesa)
            {
                ActualizarEstadoMesa(
                    nuevaMesa.Value,
                    EstadoMesa.Reservada);
            }

            MostrarReservas();

            CerrarPanelReserva();

            FrmMessageBox.Show(
                "La reserva ha sido actualizada correctamente.",
                "Reserva actualizada",
                MessageType.Information);
        }
        #endregion
    }
}
