using Ocean_Desk_dv.Models.Entities;
using Ocean_Desk_dv.Presenters;
using Ocean_Desk_dv.UI.Controls;
using Ocean_Desk_dv.UI.MessageBox;
using Ocean_Desk_dv.UI.Models;
using Ocean_Desk_dv.View.Interfaces;
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
    public partial class FrmMesasReservas : Form, IMesasReservasView
    {
        private readonly MesasReservasPresenter _presenter;
        private readonly List<ReservaPrueba> _reservas = new();

        private UcMesaCard? _mesaSeleccionada;
        private ReservaPrueba? _reservaEditando;

        #region Elementos para ComboBox de Mesas
        private sealed class MesaItem
        {
            public int MesaId { get; }
            public int Numero { get; }

            public MesaItem(int mesaId, int numero)
            {
                MesaId = mesaId;
                Numero = numero;
            }

            public override string ToString() => $"Mesa {Numero:00}";
        }
        #endregion

        #region Propiedades de la Interfaz IMesasReservasView
        public int? ReservaIdSeleccionada
        {
            get
            {
                if (dgvReservas.SelectedRows.Count == 0)
                    return null;

                return dgvReservas.SelectedRows[0].DataBoundItem is ReservaPrueba reserva
                    ? reserva.ReservaId
                    : null;
            }
        }

        public int? NumeroMesaSeleccionada
        {
            get
            {
                return cmbMesaReserva.SelectedItem is MesaItem mesa
                    ? mesa.Numero
                    : null;
            }
        }

        public int? NumeroMesaSeleccionadaParaAsignar
        {
            get => _mesaSeleccionada?.NumeroMesa;
        }

        public string ClienteReserva => txtClienteReserva.Text.Trim();

        public DateTime FechaReserva => dtpFechaNuevaReserva.Value.Date;

        public TimeSpan HoraReserva => dtpHoraNuevaReserva.Value.TimeOfDay;

        public int PersonasReserva => (int)nudPersonas.Value;
        #endregion

        #region Eventos de la Interfaz IMesasReservasView
        public event EventHandler NuevaReservaClicked = delegate { };
        public event EventHandler GuardarReservaClicked = delegate { };
        public event EventHandler EditarReservaClicked = delegate { };
        public event EventHandler CancelarReservaClicked = delegate { };
        public event EventHandler AsignarMesaClicked = delegate { };
        public event EventHandler CambiarEstadoReservaClicked = delegate { };
        #endregion

        #region Constructor
        public FrmMesasReservas()
        {
            InitializeComponent();

            dgvReservas.AutoGenerateColumns = false;

            ConfigurarColumnasReservas();
            ConfigurarFiltroEstado();

            _presenter = new MesasReservasPresenter(this);

            _presenter.Inicializar();
        }
        #endregion

        #region Configuración de Columnas y Filtros
        /// <summary>
        /// Configura el orden de las columnas en el DataGridView de reservas para que se muestren en el orden deseado.
        /// </summary>
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

        /// <summary>
        /// Configura el ComboBox de filtro de estado de reservas con las opciones disponibles y establece la opción predeterminada en "Todos".
        /// </summary>
        private void ConfigurarFiltroEstado()
        {
            cmbEstadoReserva.Items.Clear();

            cmbEstadoReserva.Items.Add("Todos");
            cmbEstadoReserva.Items.Add("Pendiente");
            cmbEstadoReserva.Items.Add("Confirmada");
            cmbEstadoReserva.Items.Add("Atendida");
            cmbEstadoReserva.Items.Add("Cancelada");

            cmbEstadoReserva.SelectedIndex = 0;
        }
        #endregion

        #region Visualización de Mesas
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mesas"></param>
        public void MostrarMesas(List<TableRestaurant> mesas)
        {
            flpMesas.SuspendLayout();
            flpMesas.Controls.Clear();
            _mesaSeleccionada = null;

            foreach (TableRestaurant mesaDb in mesas)
            {
                var mesa = new UcMesaCard
                {
                    MesaId = mesaDb.TableId,
                    NumeroMesa = mesaDb.TableNumber,
                    Capacidad = mesaDb.Capacity,
                    Estado = ConvertirEstadoMesa(mesaDb.Status)
                };

                mesa.MesaSeleccionada += Mesa_MesaSeleccionada;

                flpMesas.Controls.Add(mesa);
            }

            flpMesas.ResumeLayout();
            ActualizarEstadoBotonesReserva();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mesas"></param>
        /// <param name="mesaActualNumero"></param>
        public void MostrarMesasParaReserva(List<TableRestaurant> mesas, int? mesaActualNumero)
        {
            cmbMesaReserva.Items.Clear();

            cmbMesaReserva.Items.Add("Sin asignar");

            foreach (TableRestaurant mesa in mesas)
            {
                bool esMesaActual =
                    mesaActualNumero.HasValue &&
                    mesa.TableNumber == mesaActualNumero.Value;

                if (mesa.Status == "Available" || esMesaActual)
                {
                    cmbMesaReserva.Items.Add(
                        new MesaItem(
                            mesa.TableId,
                            mesa.TableNumber));
                }
            }

            cmbMesaReserva.SelectedIndex = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Mesa_MesaSeleccionada(object? sender, EventArgs e)
        {
            if (sender is not UcMesaCard mesa)
                return;

            if (mesa.Estado != EstadoMesa.Disponible)
            {
                MostrarMensaje(
                    "Solo puede seleccionar una mesa disponible.",
                    MessageType.Warning);
                return;
            }

            if (_mesaSeleccionada != null &&
                _mesaSeleccionada != mesa)
            {
                _mesaSeleccionada.Seleccionada = false;
            }

            _mesaSeleccionada = mesa;
            _mesaSeleccionada.Seleccionada = true;

            ActualizarEstadoBotonesReserva();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="estado"></param>
        /// <returns></returns>
        private static EstadoMesa ConvertirEstadoMesa(string estado)
        {
            return estado switch
            {
                "Available" => EstadoMesa.Disponible,
                "Occupied" => EstadoMesa.Ocupada,
                "Reserved" => EstadoMesa.Reservada,
                "Maintenance" => EstadoMesa.Mantenimiento,
                _ => EstadoMesa.Disponible
            };
        }
        #endregion

        #region Visualización de Reservas
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reservas"></param>
        public void MostrarReservas(List<ReservaPrueba> reservas)
        {
            _reservas.Clear();
            _reservas.AddRange(reservas);

            AplicarFiltros();
        }

        /// <summary>
        /// 
        /// </summary>
        private void AplicarFiltros()
        {
            string textoBusqueda = txtBuscarReserva.Text.Trim();

            DateTime fechaSeleccionada = dtpFechaReserva.Value.Date;

            string estadoSeleccionado =
                cmbEstadoReserva.SelectedItem?.ToString() ?? "Todos";

            IEnumerable<ReservaPrueba> reservasFiltradas = _reservas;

            if (!string.IsNullOrWhiteSpace(textoBusqueda))
            {
                reservasFiltradas = reservasFiltradas.Where(r =>
                    r.Cliente.Contains(
                        textoBusqueda,
                        StringComparison.OrdinalIgnoreCase));
            }

            reservasFiltradas = reservasFiltradas.Where(r =>
                r.Fecha.Date == fechaSeleccionada);

            if (estadoSeleccionado != "Todos")
            {
                reservasFiltradas = reservasFiltradas.Where(r =>
                    r.Estado.Equals(
                        estadoSeleccionado,
                        StringComparison.OrdinalIgnoreCase));
            }

            dgvReservas.DataSource = null;
            dgvReservas.DataSource = reservasFiltradas.ToList();

            dgvReservas.CurrentCell = null;
            dgvReservas.ClearSelection();

            ActualizarEstadoBotonesReserva();
        }
        #endregion

        #region Panel Nueva Reserva
        /// <summary>
        /// Limpia los campos del formulario de nueva reserva y establece valores predeterminados.
        /// </summary>
        public void LimpiarFormularioNuevaReserva()
        {
            _reservaEditando = null;

            txtClienteReserva.Clear();
            dtpFechaNuevaReserva.Value = DateTime.Today;
            dtpHoraNuevaReserva.Value = DateTime.Today.AddHours(19);

            nudPersonas.Minimum = 1;
            nudPersonas.Maximum = 20;
            nudPersonas.Value = 1;

            if (cmbMesaReserva.Items.Count > 0)
                cmbMesaReserva.SelectedIndex = 0;
            else
                cmbMesaReserva.SelectedIndex = -1;
        }

        /// <summary>
        /// Carga los datos de la reserva seleccionada en los controles del formulario de edición.
        /// </summary>
        /// <param name="reserva"></param>
        public void CargarDatosReserva(ReservaPrueba reserva)
        {
            _reservaEditando = reserva;

            txtClienteReserva.Text = reserva.Cliente;
            dtpFechaNuevaReserva.Value = reserva.Fecha;
            dtpHoraNuevaReserva.Value = DateTime.Today.Add(reserva.Hora);

            nudPersonas.Minimum = 1;
            nudPersonas.Maximum = 20;
            nudPersonas.Value = Math.Max(1, reserva.Personas);

            if (reserva.Mesa.HasValue)
            {
                for (int i = 0; i < cmbMesaReserva.Items.Count; i++)
                {
                    if (cmbMesaReserva.Items[i] is MesaItem mesa &&
                        mesa.Numero == reserva.Mesa.Value)
                    {
                        cmbMesaReserva.SelectedIndex = i;
                        break;
                    }
                }
            }
            else
            {
                cmbMesaReserva.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Abre el panel de nueva reserva.
        /// </summary>
        public void AbrirPanelNuevaReserva(bool edicion)
        {
            pnlReservas.Visible = false;
            pnlNuevaReservaContainer.Visible = true;
            pnlNuevaReserva.Visible = true;

            lblTituloNuevaReserva.Text = edicion ? "Editar reserva" : "Nueva reserva";

            btnGuardarNuevaReserva.Text = edicion ? "GUARDAR CAMBIOS" : "GUARDAR RESERVA";

            pnlNuevaReserva.BringToFront();
            CentrarNuevaReserva();
        }

        /// <summary>
        /// 
        /// </summary>
        public void CerrarPanelNuevaReserva()
        {
            pnlNuevaReserva.Visible = false;
            pnlNuevaReservaContainer.Visible = false;
            pnlReservas.Visible = true;

            _reservaEditando = null;

            lblTituloNuevaReserva.Text = "Nueva reserva";
            btnGuardarNuevaReserva.Text = "GUARDAR RESERVA";
        }

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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbMesaReserva_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarPersonasSegunMesa();
        }

        /// <summary>
        /// 
        /// </summary>
        private void ActualizarPersonasSegunMesa()
        {
            if (cmbMesaReserva.SelectedItem is not MesaItem mesa)
            {
                nudPersonas.Minimum = 1;
                nudPersonas.Maximum = 20;
                return;
            }

            UcMesaCard? tarjeta =
                flpMesas.Controls
                    .OfType<UcMesaCard>()
                    .FirstOrDefault(m =>
                        m.NumeroMesa == mesa.Numero);

            if (tarjeta == null)
                return;

            nudPersonas.Minimum = 1;
            nudPersonas.Maximum = tarjeta.Capacidad;

            if (_reservaEditando == null)
            {
                nudPersonas.Value = tarjeta.Capacidad;
            }
            else if (nudPersonas.Value > tarjeta.Capacidad)
            {
                nudPersonas.Value = tarjeta.Capacidad;
            }
        }
        #endregion

        #region Botones 
        /// <summary>
        /// Muestra el panel de nueva reserva y oculta el panel de reservas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNuevaReserva_Click(object sender, EventArgs e)
        {
            NuevaReservaClicked.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Maneja el evento de clic del botón de guardar nueva reserva, creando una nueva reserva o guardando los cambios en una reserva existente según corresponda.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardarNuevaReserva_Click(object sender, EventArgs e)
        {
            GuardarReservaClicked.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Cancela la creación o edición de una reserva y regresa al panel de reservas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelarNuevaReserva_Click(object sender, EventArgs e)
        {
            CerrarPanelNuevaReserva();
        }

        /// <summary>
        /// Permite editar una reserva seleccionada en el DataGridView de reservas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditarReserva_Click(object sender, EventArgs e)
        {
            EditarReservaClicked.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Cancela la reserva seleccionada en el DataGridView de reservas, actualizando el estado de la mesa si es necesario y mostrando un mensaje de confirmación.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelarReserva_Click(object sender, EventArgs e)
        {
            CancelarReservaClicked.Invoke(this, EventArgs.Empty);
        }


        /// <summary>
        /// Asigna la mesa seleccionada en el panel de mesas a la reserva seleccionada en el DataGridView de reservas, validando el estado de la reserva y la disponibilidad de la mesa, y actualizando la información visual y los datos de la reserva.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAsignarMesa_Click(object sender, EventArgs e)
        {
            AsignarMesaClicked.Invoke(this, EventArgs.Empty);
        }

        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCambiarEstadoReserva_Click(object sender, EventArgs e)
        {
            CambiarEstadoReservaClicked.Invoke(this, EventArgs.Empty);
        }
        #endregion

        #region Selección y Estado de Botones
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvReservas_SelectionChanged(object sender, EventArgs e)
        {
            ActualizarEstadoBotonesReserva();
        }

        /// <summary>
        /// 
        /// </summary>
        private void ActualizarEstadoBotonesReserva()
        {
            bool haySeleccion = dgvReservas.SelectedRows.Count > 0;

            btnEditarReserva.Enabled = haySeleccion;
            btnCancelarReserva.Enabled = haySeleccion;
            btnAsignarMesa.Enabled = false;
            btnCambiarEstadoReserva.Enabled = false;

            if (!haySeleccion)
                return;

            if (dgvReservas.SelectedRows[0].DataBoundItem is not ReservaPrueba reserva)
                return;

            bool activa =
                reserva.Estado == "Pendiente" ||
                reserva.Estado == "Confirmada";

            btnEditarReserva.Enabled = activa;
            btnCancelarReserva.Enabled = activa;

            btnAsignarMesa.Enabled =
                activa &&
                !reserva.Mesa.HasValue &&
                _mesaSeleccionada != null &&
                _mesaSeleccionada.Estado == EstadoMesa.Disponible;

            btnCambiarEstadoReserva.Enabled = activa;
        }
        #endregion

        #region Filtros
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBuscarReserva_TextChanged(object sender, EventArgs e)
        {
           AplicarFiltros();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpFechaReservaFiltro_ValueChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbEstadoReserva_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }
        #endregion

        #region Formato Visual Reservas
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvReservas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == colReservaMesa.Index)
            {
                if (e.Value == null || e.Value == DBNull.Value)
                {
                    e.Value = "-";
                    e.FormattingApplied = true;
                }
            }

            if (e.ColumnIndex != colReservaEstado.Index || e.Value == null)
                return;

            string estado = e.Value.ToString() ?? string.Empty;

            if (estado == "Pendiente")
            {
                e.CellStyle.ForeColor = Color.FromArgb(181, 119, 23);
                e.CellStyle.Font = new Font(dgvReservas.Font, FontStyle.Bold);
            }
            else if (estado == "Confirmada")
            {
                e.CellStyle.ForeColor = Color.FromArgb(8, 126, 164);
                e.CellStyle.Font = new Font(dgvReservas.Font, FontStyle.Bold);
            }
            else if (estado == "Atendida")
            {
                e.CellStyle.ForeColor = Color.FromArgb(42, 122, 82);
                e.CellStyle.Font = new Font(dgvReservas.Font, FontStyle.Bold);
            }
            else if (estado == "Cancelada")
            {
                e.CellStyle.ForeColor = Color.FromArgb(163, 61, 61);
                e.CellStyle.Font = new Font(dgvReservas.Font, FontStyle.Bold);
            }
        }
        #endregion

        #region Mensajes
        public void MostrarMensaje(string mensaje, MessageType tipo)
        {
            FrmMessageBox.Show(
                mensaje,
                tipo switch
                {
                    MessageType.Warning => "Advertencia",
                    MessageType.Error => "Error",
                    MessageType.Confirmation => "Confirmación",
                    _ => "Información"
                },
                tipo);
        }
        #endregion
    }
}
