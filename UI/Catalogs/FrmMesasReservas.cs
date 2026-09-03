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

            cmbEstadoReserva.Items.Clear();

            cmbEstadoReserva.Items.Add("Todos");
            cmbEstadoReserva.Items.Add("Pendiente");
            cmbEstadoReserva.Items.Add("Confirmada");
            cmbEstadoReserva.Items.Add("Atendida");
            cmbEstadoReserva.Items.Add("Cancelada");

            cmbEstadoReserva.SelectedIndex = 0;

            CargarMesasPrueba();

            CargarReservasPrueba();

            MostrarReservas();

            SincronizarMesasConReservas();
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

            mesa.MesaSeleccionada += Mesa_MesaSeleccionada;

            flpMesas.Controls.Add(mesa);
        }

        private void Mesa_MesaSeleccionada(object sender, EventArgs e)
        {
            if (sender is not UcMesaCard mesa)
                return;

            // Si la mesa no está disponible, no se puede seleccionar
            if (mesa.Estado != EstadoMesa.Disponible)
            {
                FrmMessageBox.Show(
                    "Solo puede seleccionar una mesa disponible.",
                    "Mesa no disponible",
                    MessageType.Warning);

                return;
            }

            // Quitar selección anterior
            if (_mesaSeleccionada != null &&
                _mesaSeleccionada != mesa)
            {
                _mesaSeleccionada.Seleccionada = false;
            }

            _mesaSeleccionada = mesa;
            _mesaSeleccionada.Seleccionada = true;
        }

        private UcMesaCard ObtenerMesaCard(int? numeroMesa)
        {
            if (!numeroMesa.HasValue)
                return null;

            return flpMesas.Controls
                .OfType<UcMesaCard>()
                .FirstOrDefault(
                    m => m.NumeroMesa == numeroMesa.Value);
        }

        private void ActualizarPersonasSegunMesa()
        {
            string mesaSeleccionada = cmbMesaReserva.SelectedItem?.ToString() ?? "Sin asignar";

            int? numeroMesa = ObtenerNumeroMesaSeleccionada(mesaSeleccionada);

            // Si no hay mesa asignada
            if (!numeroMesa.HasValue)
            {
                nudPersonas.Minimum = 1;
                nudPersonas.Maximum = 20;
                nudPersonas.Value = 1;

                return;
            }

            UcMesaCard mesa = ObtenerMesaCard(numeroMesa);

            if (mesa == null)
                return;

            nudPersonas.Minimum = 1;
            nudPersonas.Maximum = mesa.Capacidad;

            // Solo en una nueva reserva usamos la capacidad
            // como cantidad inicial de personas.
            if (_reservaEditando == null)
            {
                nudPersonas.Value = mesa.Capacidad;
            }
            else if (nudPersonas.Value > mesa.Capacidad)
            {
                nudPersonas.Value = mesa.Capacidad;
            }
        }

        private void cmbMesaReserva_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarPersonasSegunMesa();
        }

        private bool ValidarPersonasSegunMesa(int? numeroMesa)
        {
            if (!numeroMesa.HasValue)
                return true;

            UcMesaCard mesa = ObtenerMesaCard(numeroMesa);

            if (mesa == null)
                return false;

            if (nudPersonas.Value > mesa.Capacidad)
            {
                FrmMessageBox.Show(
                    $"La Mesa {mesa.NumeroMesa:00} tiene una capacidad máxima " +
                    $"de {mesa.Capacidad} personas.",
                    "Capacidad excedida",
                    MessageType.Warning);

                return false;
            }

            return true;
        }

        #endregion

        #region Metodos para Carga de Datos en dgvReservas y apariencia de celdas/botones
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
            btnAsignarMesa.Enabled = false;
            btnCambiarEstadoReserva.Enabled = false;

            if (!haySeleccion)
                return;

            DataGridViewRow fila = dgvReservas.SelectedRows[0];
            ReservaPrueba reserva = fila.DataBoundItem as ReservaPrueba;

            if (reserva == null)
                return;

            if (reserva.Estado == "Atendida" || reserva.Estado == "Cancelada")
            {
                FrmMessageBox.Show(
                    "Esta reserva no puede ser modificada porque ya fue atendida o cancelada.",
                    "Reserva no editable",
                    MessageType.Warning);

                return;
            }

            // Estados que permiten modificar la reserva
            bool reservaActiva = reserva.Estado == "Pendiente" || reserva.Estado == "Confirmada";

            // Editar y cancelar solamente están disponibles
            // para reservas activas.
            btnEditarReserva.Enabled = reservaActiva;
            btnCancelarReserva.Enabled = reservaActiva;

            // Asignar mesa solamente si la reserva activa
            // todavía no tiene una mesa.
            btnAsignarMesa.Enabled = reservaActiva && !reserva.Mesa.HasValue;
            btnCambiarEstadoReserva.Enabled = reservaActiva;
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

        #region Metodos para Panel de Reservas y Nuevas Reservas    
        private void SincronizarMesasConReservas()
        {
            // Primero quitamos las reservas anteriores de las tarjetas.
            foreach (Control control in flpMesas.Controls)
            {
                if (control is UcMesaCard mesa &&
                    mesa.Estado == EstadoMesa.Reservada)
                {
                    mesa.Estado = EstadoMesa.Disponible;
                }
            }

            // Volvemos a aplicar las reservas activas.
            foreach (ReservaPrueba reserva in _reservas)
            {
                if (reserva.Estado == "Cancelada" ||
                    reserva.Estado == "Atendida")
                {
                    continue;
                }

                if (!reserva.Mesa.HasValue)
                    continue;

                UcMesaCard mesaCard =
                    flpMesas.Controls
                        .OfType<UcMesaCard>()
                        .FirstOrDefault(
                            m => m.NumeroMesa == reserva.Mesa.Value);

                if (mesaCard != null)
                {
                    mesaCard.Estado = EstadoMesa.Reservada;
                }
            }
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
        /// Abre el panel de nueva reserva.
        /// </summary>
        private void AbrirPanelNuevaReserva()
        {
            pnlReservas.Visible = false;

            pnlNuevaReservaContainer.Visible = true;
            pnlNuevaReserva.Visible = true;

            pnlNuevaReserva.BringToFront();

            CentrarNuevaReserva();
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
        /// Limpia los campos del formulario de nueva reserva y establece valores predeterminados.
        /// </summary>
        private void LimpiarFormularioNuevaReserva()
        {
            txtClienteReserva.Clear();

            dtpFechaNuevaReserva.Value = DateTime.Today;

            dtpHoraNuevaReserva.Value =  DateTime.Today.AddHours(19);

            nudPersonas.Minimum = 1;
            nudPersonas.Maximum = 20;
            nudPersonas.Value = 1;

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
        /// Muestra el panel de nueva reserva y oculta el panel de reservas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNuevaReserva_Click(object sender, EventArgs e)
        {
            _reservaEditando = null;

            lblTituloNuevaReserva.Text = "Nueva reserva";
            btnGuardarNuevaReserva.Text = "GUARDAR RESERVA";

            CargarMesasParaReserva();
            LimpiarFormularioNuevaReserva();

            AbrirPanelNuevaReserva();
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

            string numeroTexto = mesaSeleccionada.Replace("Mesa", "");

            if (int.TryParse(numeroTexto, out int numeroMesa))
            {
                return numeroMesa;
            }

            return null;
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

            if (!ValidarPersonasSegunMesa(mesa))
                return;

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

            //Actualizar DGV
            MostrarReservas();

            //Actualizar Estado de la Mesa si es necesario
            SincronizarMesasConReservas();

            // Cerrar Panel de Nueva Reserva
            CerrarPanelReserva();

            FrmMessageBox.Show(
                "La reserva ha sido registrada correctamente.",
                "Reserva registrada",
                MessageType.Information);
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

            if (!ValidarPersonasSegunMesa(nuevaMesa))
                return;

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

            MostrarReservas(); // Actualiza el DataGridView con los cambios realizados en la reserva

            SincronizarMesasConReservas(); // Actualiza el estado de las mesas según la nueva asignación de la reserva

            CerrarPanelReserva();

            FrmMessageBox.Show(
                "La reserva ha sido actualizada correctamente.",
                "Reserva actualizada",
                MessageType.Information);
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
        /// Cancela la creación o edición de una reserva y regresa al panel de reservas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelarNuevaReserva_Click(object sender, EventArgs e)
        {
            CerrarPanelReserva();
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

            DataGridViewRow fila = dgvReservas.SelectedRows[0];

            ReservaPrueba reserva = fila.DataBoundItem as ReservaPrueba;

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

            lblTituloNuevaReserva.Text = "Editar reserva";
            btnGuardarNuevaReserva.Text = "GUARDAR CAMBIOS";

            AbrirPanelNuevaReserva();
        }

        /// <summary>
        /// Cancela la reserva seleccionada en el DataGridView de reservas, actualizando el estado de la mesa si es necesario y mostrando un mensaje de confirmación.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelarReserva_Click(object sender, EventArgs e)
        {
            if (dgvReservas.SelectedRows.Count == 0)
            {
                FrmMessageBox.Show(
                    "Seleccione una reserva para cancelar.",
                    "Reserva no seleccionada",
                    MessageType.Warning);

                return;
            }

            DataGridViewRow fila = dgvReservas.SelectedRows[0];

            ReservaPrueba reserva = fila.DataBoundItem as ReservaPrueba;

            if (reserva == null)
            {
                FrmMessageBox.Show(
                    "No fue posible obtener la información de la reserva seleccionada.",
                    "Error",
                    MessageType.Error);

                return;
            }

            if (reserva.Estado == "Cancelada")
            {
                FrmMessageBox.Show(
                    "La reserva seleccionada ya se encuentra cancelada.",
                    "Reserva cancelada",
                    MessageType.Warning);

                return;
            }

            if (reserva.Estado == "Atendida")
            {
                FrmMessageBox.Show(
                    "No se puede cancelar una reserva que ya fue atendida.",
                    "Reserva atendida",
                    MessageType.Warning);

                return;
            }

            DialogResult resultado =
                FrmMessageBox.Show(
                    $"¿Desea cancelar la reserva de {reserva.Cliente}?",
                    "Cancelar reserva",
                    MessageType.Confirmation);

            if (resultado != DialogResult.Yes)
                return;

            reserva.Estado = "Cancelada";

            MostrarReservas();

            SincronizarMesasConReservas();

            FrmMessageBox.Show(
                $"La reserva de {reserva.Cliente} ha sido cancelada correctamente.",
                "Reserva cancelada",
                MessageType.Information);
        }

        /// <summary>
        /// Asigna la mesa seleccionada en el panel de mesas a la reserva seleccionada en el DataGridView de reservas, validando el estado de la reserva y la disponibilidad de la mesa, y actualizando la información visual y los datos de la reserva.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAsignarMesa_Click(object sender, EventArgs e)
        {
            //Verificar reserva seleccionada
            if (dgvReservas.SelectedRows.Count == 0)
            {
                FrmMessageBox.Show(
                    "Seleccione una reserva para asignarle una mesa.",
                    "Reserva no seleccionada",
                    MessageType.Warning);

                return;
            }

            DataGridViewRow fila = dgvReservas.SelectedRows[0];

            ReservaPrueba reserva = fila.DataBoundItem as ReservaPrueba;

            if (reserva == null)
            {
                FrmMessageBox.Show(
                    "No fue posible obtener la información de la reserva seleccionada.",
                    "Error",
                    MessageType.Error);

                return;
            }

            //Verificar estado de la reserva
            if (reserva.Estado == "Cancelada")
            {
                FrmMessageBox.Show(
                    "No se puede asignar una mesa a una reserva cancelada.",
                    "Reserva cancelada",
                    MessageType.Warning);

                return;
            }

            if (reserva.Estado == "Atendida")
            {
                FrmMessageBox.Show(
                    "No se puede asignar una mesa a una reserva que ya fue atendida.",
                    "Reserva atendida",
                    MessageType.Warning);

                return;
            }

            //Verificar si ya tiene mesa
            if (reserva.Mesa.HasValue)
            {
                FrmMessageBox.Show(
                    $"La reserva de {reserva.Cliente} ya tiene asignada la Mesa {reserva.Mesa.Value:00}.",
                    "Mesa ya asignada",
                    MessageType.Information);

                return;
            }

            //Verificar que se haya seleccionado una tarjeta
            if (_mesaSeleccionada == null)
            {
                FrmMessageBox.Show(
                    "Seleccione una mesa disponible en las tarjetas.",
                    "Mesa no seleccionada",
                    MessageType.Warning);

                return;
            }

            //Verificar que la tarjeta siga disponible
            if (_mesaSeleccionada.Estado != EstadoMesa.Disponible)
            {
                FrmMessageBox.Show(
                    "La mesa seleccionada ya no se encuentra disponible.",
                    "Mesa no disponible",
                    MessageType.Warning);

                _mesaSeleccionada.Seleccionada = false;
                _mesaSeleccionada = null;

                return;
            }

            //Confirmar asignación
            DialogResult resultado =
                FrmMessageBox.Show(
                    $"¿Desea asignar la Mesa {_mesaSeleccionada.NumeroMesa:00} " +
                    $"a la reserva de {reserva.Cliente}?",
                    "Asignar mesa",
                    MessageType.Confirmation);

            if (resultado != DialogResult.Yes)
                return;

            //Guardar mesa en la reserva
            reserva.Mesa = _mesaSeleccionada.NumeroMesa;

            //Actualizar la información visual
            MostrarReservas();
            SincronizarMesasConReservas();

            //Limpiar selección
            _mesaSeleccionada.Seleccionada = false;
            _mesaSeleccionada = null;

            ActualizarEstadoBotonesReserva();

            //Confirmación
            FrmMessageBox.Show(
                $"La Mesa {reserva.Mesa:00} fue asignada correctamente " +
                $"a la reserva de {reserva.Cliente}.",
                "Mesa asignada",
                MessageType.Information);
        }
        #endregion

        #region Funcionalidad de Filtros

        /// <summary>
        /// Filtra las reservas según los criterios de búsqueda.
        /// </summary>
        private void FiltrarReservas()
        {
            string textoBusqueda = txtBuscarReserva.Text.Trim().ToLower();

            DateTime fechaSeleccionada = dtpFechaReserva.Value.Date;

            string estadoSeleccionado = cmbEstadoReserva.Text;

            IEnumerable<ReservaPrueba> reservasFiltradas = _reservas;

            // Buscar por cliente
            if (!string.IsNullOrWhiteSpace(textoBusqueda))
            {
                reservasFiltradas = reservasFiltradas.Where(r => r.Cliente.ToLower().Contains(textoBusqueda));
            }

            // Filtrar por fecha
            reservasFiltradas = reservasFiltradas.Where(r => r.Fecha.Date == fechaSeleccionada);

            // Filtrar por estado
            if (!string.IsNullOrWhiteSpace(estadoSeleccionado) && estadoSeleccionado != "Todos")
            {
                reservasFiltradas = reservasFiltradas.Where(r => r.Estado == estadoSeleccionado);
            }

            dgvReservas.DataSource = null;
            dgvReservas.DataSource = reservasFiltradas.ToList();

            dgvReservas.CurrentCell = null;
            dgvReservas.ClearSelection();

            ActualizarEstadoBotonesReserva();
        }

        private void txtBuscarReserva_TextChanged(object sender, EventArgs e)
        {
            FiltrarReservas();
        }

        private void dtpFechaReservaFiltro_ValueChanged(object sender, EventArgs e)
        {
            FiltrarReservas();
        }

        private void cmbEstadoReserva_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarReservas();
        }

        private void btnCambiarEstadoReserva_Click(object sender, EventArgs e)
        {
            // Pendiente -> Confirmada -> Atendida
            // Atendida o Cancelada no puede cambiar de estado

            if (dgvReservas.SelectedRows.Count == 0)
            {
                FrmMessageBox.Show(
                    "Seleccione una reserva para cambiar su estado.",
                    "Reserva no seleccionada",
                    MessageType.Warning);

                return;
            }

            DataGridViewRow fila = dgvReservas.SelectedRows[0];

            ReservaPrueba reserva = fila.DataBoundItem as ReservaPrueba;

            if (reserva == null)
            {
                FrmMessageBox.Show(
                    "No fue posible obtener la información de la reserva seleccionada.",
                    "Error",
                    MessageType.Error);

                return;
            }

            if (reserva.Estado == "Cancelada")
            {
                FrmMessageBox.Show(
                    "Una reserva cancelada no puede cambiar de estado.",
                    "Reserva cancelada",
                    MessageType.Warning);

                return;
            }

            if (reserva.Estado == "Atendida")
            {
                FrmMessageBox.Show(
                    "Una reserva atendida no puede cambiar nuevamente de estado.",
                    "Reserva atendida",
                    MessageType.Warning);

                return;
            }

            string nuevoEstado;

            if (reserva.Estado == "Pendiente")
            {
                nuevoEstado = "Confirmada";
            }
            else
            {
                nuevoEstado = "Atendida";
            }

            DialogResult resultado =
                FrmMessageBox.Show(
                    $"¿Desea cambiar la reserva de {reserva.Cliente} " +
                    $"de '{reserva.Estado}' a '{nuevoEstado}'?",
                    "Cambiar estado",
                    MessageType.Confirmation);

            if (resultado != DialogResult.Yes)
                return;

            reserva.Estado = nuevoEstado;

            MostrarReservas();
            SincronizarMesasConReservas();

            FrmMessageBox.Show(
                $"La reserva de {reserva.Cliente} ahora se encuentra en estado '{nuevoEstado}'.",
                "Estado actualizado",
                MessageType.Information);
        }
        #endregion

     
    }

}
