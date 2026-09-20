using Ocean_Desk_dv.Data;
using Ocean_Desk_dv.Presenters;
using Ocean_Desk_dv.UI.MessageBox;
using Ocean_Desk_dv.View.Interfaces;
using Ocean_Desk_dv.View.MessageBox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ocean_Desk_dv.View.Catalogs
{
    /// <summary>
    /// Vista principal del módulo de Control de Cocina y Seguimiento de Pedidos.
    ///
    /// La clase implementa ICocinaView y se limita a:
    /// - Capturar eventos de los controles visuales.
    /// - Mostrar la información enviada por CocinaPresenter.
    /// - Gestionar la selección de pedidos.
    /// - Mostrar mensajes y diálogos reutilizables del proyecto.
    ///
    /// La lógica de negocio y el acceso a SQL Server permanecen en CocinaPresenter.
    /// </summary>
    public partial class FrmCocinaPedidos : Form, ICocinaView
    {
        private readonly CocinaPresenter _presenter;
        //private readonly System.Windows.Forms.Timer _timerActualizacion;
        private bool _cargandoPedidos;

        /// <summary>
        /// Constructor utilizado mientras el sistema de autenticación todavía no entrega
        /// el usuario y rol reales. Las acciones que requieren autorización quedan protegidas
        /// hasta que se proporcione el rol mediante el constructor principal.
        /// </summary>
        public FrmCocinaPedidos()
            : this(null, null)
        {
        }

        /// <summary>
        /// Constructor principal que recibe el usuario y rol del sistema de autenticación.
        /// </summary>
        /// <param name="usuarioId"></param>
        /// <param name="rolUsuario"></param>
        public FrmCocinaPedidos(int? usuarioId, string? rolUsuario)
        {
            InitializeComponent();

            // El diseñador ya define las columnas manualmente.
            // Se desactiva la generación automática para conservar ese diseño.
            dgvPedido.AutoGenerateColumns = false;
            dgvDetallePedido.AutoGenerateColumns = false;

            ConfigurarEventos();

            // El Presenter crea y administra su propio contexto de datos.
            _presenter = new CocinaPresenter(
                this,
                new OceanDeskDbContext(),
                usuarioId,
                rolUsuario);

            // Actualización periódica para mantener Cocina sincronizada con las órdenes
            // creadas desde Punto de Venta. La base de datos continúa siendo la fuente
            // persistente; el Timer solamente solicita una nueva consulta.

            /*_timerActualizacion = new System.Windows.Forms.Timer
            {
                Interval = 1500
            };
            _timerActualizacion.Tick += TimerActualizacion_Tick;
            _timerActualizacion.Start();*/

            FormClosed += FrmCocinaPedidos_FormClosed;

            _presenter.Inicializar();
        }

        #region Propiedades y eventos de ICocinaView

        /// <summary>
        /// Obtiene el identificador de la fila seleccionada en dgvPedido.
        /// </summary>
        public int? PedidoIdSeleccionado
        {
            get
            {
                DataGridViewRow? fila = dgvPedido.CurrentRow;

                if (fila == null)
                    return null;

                object? value = fila.Cells[nameof(colOrden)].Value;

                if (value == null || value == DBNull.Value)
                    return null;

                return int.TryParse(value.ToString(), out int pedidoId)
                    ? pedidoId
                    : null;
            }
        }

        public event EventHandler<int> PedidoSeleccionado = delegate { };
        public event EventHandler ActualizarPedidosClicked = delegate { };
        public event EventHandler IniciarPreparacionClicked = delegate { };
        public event EventHandler MarcarListoClicked = delegate { };
        public event EventHandler EntregarPedidoClicked = delegate { };
        public event EventHandler CancelarPedidoClicked = delegate { };
        public event EventHandler LimpiarClicked = delegate { };

        #endregion

        #region Configuración de eventos
        /// <summary>
        /// Conecta los botones y la selección del DataGridView con los eventos de la interfaz.
        /// </summary>
        private void ConfigurarEventos()
        {
            dgvPedido.SelectionChanged += dgvPedido_SelectionChanged;
            btnActualizar.Click += btnActualizar_Click;
            btnIniciarPreparacion.Click += btnIniciarPreparacion_Click;
            btnMarcarListo.Click += btnMarcarListo_Click;
            btnEntregarPedido.Click += btnEntregarPedido_Click;
            btnCancelar.Click += btnCancelar_Click;
            btnLimpiar.Click += btnLimpiar_Click;
        }

        private void dgvPedido_SelectionChanged(object sender, EventArgs e)
        {
            if (_cargandoPedidos)
                return;

            int? pedidoId = PedidoIdSeleccionado;

            if (pedidoId.HasValue)
                PedidoSeleccionado(this, pedidoId.Value);
            else
                LimpiarVistaDetalle();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarPedidosClicked(this, EventArgs.Empty);
        }

        private void btnIniciarPreparacion_Click(object sender, EventArgs e)
        {
            IniciarPreparacionClicked(this, EventArgs.Empty);
        }

        private void btnMarcarListo_Click(object sender, EventArgs e)
        {
            MarcarListoClicked(this, EventArgs.Empty);
        }

        private void btnEntregarPedido_Click(object sender, EventArgs e)
        {
            EntregarPedidoClicked(this, EventArgs.Empty);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            CancelarPedidoClicked(this, EventArgs.Empty);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarClicked(this, EventArgs.Empty);
        }

        private void TimerActualizacion_Tick(object sender, EventArgs e)
        {
            ActualizarPedidosClicked(this, EventArgs.Empty);
        }
        #endregion

        #region Métodos de presentación

        /// <summary>
        /// Llena dgvPedido con las órdenes activas recibidas desde el Presenter.
        /// </summary>
        public void MostrarPedidos(IReadOnlyList<CocinaPedidoResumen> pedidos)
        {
            _cargandoPedidos = true;

            try
            {
                dgvPedido.Rows.Clear();

                foreach (CocinaPedidoResumen pedido in pedidos)
                {
                    int rowIndex = dgvPedido.Rows.Add(
                        pedido.KitchenOrderId,
                        pedido.Mesa,
                        pedido.TipoOrden,
                        pedido.Hora.ToString("HH:mm"),
                        ObtenerTextoPrioridad(pedido.Prioridad),
                        ObtenerTextoEstado(pedido.Estado));

                    DataGridViewRow row = dgvPedido.Rows[rowIndex];

                    row.Tag = pedido.KitchenOrderId;

                    AplicarEstiloEstado(row, pedido.Estado);
                    AplicarEstiloPrioridad(dgvPedido.Rows[rowIndex],pedido.Prioridad);
                }
            }
            finally
            {
                _cargandoPedidos = false;
            }
        }

        /// <summary>
        /// Muestra los datos de cabecera y las líneas del pedido seleccionado.
        /// </summary>
        public void MostrarDetallePedido(
            CocinaPedidoSeleccionado? pedido,
            IReadOnlyList<CocinaPedidoDetalle> detalles)
        {
            dgvDetallePedido.Rows.Clear();

            if (pedido == null)
            {
                LimpiarVistaDetalle();
                return;
            }

            lblOrden.Text = $"Orden: #{pedido.KitchenOrderId:000}";
            lblHora.Text = $"Hora: {pedido.Hora:HH:mm}";
            lblTipoOrden.Text = $"Tipo: {pedido.TipoOrden}";
            lblMesa.Text = $"Mesa: {pedido.Mesa}";
            lblEstado.Text = $"Estado: {ObtenerTextoEstado(pedido.Estado).ToUpperInvariant()}";
            lblPrioridad.Text = $"Prioridad: {ObtenerTextoPrioridad(pedido.Prioridad)}";

            AplicarEstiloEstadoDetalle(pedido.Estado);
            AplicarEstiloPrioridadDetalle(pedido.Prioridad);

            foreach (CocinaPedidoDetalle detalle in detalles)
            {
                dgvDetallePedido.Rows.Add(
                    detalle.Cantidad.ToString("0.##"),
                    detalle.Producto,
                    detalle.Observaciones);
            }
        }

        /// <summary>
        /// Actualiza los tres indicadores superiores del formulario.
        /// </summary>
        public void MostrarIndicadores(int pendientes, int enPreparacion, int listos)
        {
            lblNumeroPendientes.Text = pendientes.ToString();
            lblNumeroPreparacion.Text = enPreparacion.ToString();
            lblNumeroListos.Text = listos.ToString();
        }

        /// <summary>
        /// Habilita únicamente las acciones que corresponden al estado actual.
        /// </summary>
        public void ActualizarBotones(string estado, bool puedeCancelar)
        {
            btnIniciarPreparacion.Enabled = false;
            btnMarcarListo.Enabled = false;
            btnEntregarPedido.Enabled = false;
            btnCancelar.Enabled = false;

            switch (estado)
            {
                case "Pending":
                    btnIniciarPreparacion.Enabled = true;
                    break;

                case "InPreparation":
                    btnMarcarListo.Enabled = true;
                    break;

                case "Ready":
                    btnEntregarPedido.Enabled = true;
                    break;

                case "Cancelled":
                    // No hay acciones disponibles.
                    break;
            }

            btnCancelar.Enabled = puedeCancelar;
        }

        /// <summary>
        /// Selecciona la fila correspondiente a una orden después de actualizar el listado.
        /// </summary>
        public void SeleccionarPedido(int pedidoId)
        {
            foreach (DataGridViewRow row in dgvPedido.Rows)
            {
                if (row.Cells[nameof(colOrden)].Value?.ToString() != pedidoId.ToString())
                    continue;

                _cargandoPedidos = true;

                try
                {
                    row.Selected = true;
                    dgvPedido.CurrentCell = row.Cells[nameof(colOrden)];
                }
                finally
                {
                    _cargandoPedidos = false;
                }

                PedidoSeleccionado(this, pedidoId);
                return;
            }
        }

        /// <summary>
        /// Limpia la selección y restaura el detalle a su estado inicial.
        /// </summary>
        public void LimpiarSeleccion()
        {
            dgvPedido.ClearSelection();
            LimpiarVistaDetalle();
        }

        #endregion

        #region Diálogos reutilizables

        /// <summary>
        /// Solicita el motivo obligatorio de cancelación utilizando el diálogo reutilizable del proyecto.
        /// </summary>
        public string? SolicitarMotivoCancelacion()
        {
            return FrmTextInput.SolicitarTexto(
                this,
                "Motivo de cancelación",
                "Ingrese el motivo por el cual se cancelará el pedido:");
        }

        /// <summary>
        /// Muestra una confirmación utilizando FrmMessageBox.
        /// </summary>
        public DialogResult ConfirmarAccion(string titulo, string mensaje)
        {
            return FrmMessageBox.Show(
                mensaje,
                titulo,
                MessageType.Confirmation);
        }

        /// <summary>
        /// Muestra mensajes mediante el componente reutilizable de OceanDesk.
        /// </summary>
        public void MostrarMensaje(
            string mensaje,
            string titulo = "Cocina",
            bool esError = false)
        {
            FrmMessageBox.Show(
                mensaje,
                titulo,
                esError ? MessageType.Error : MessageType.Information);
        }

        #endregion

        #region Estilos dinámicos

        /// <summary>
        /// Aplica color visual al estado de la fila sin modificar el valor almacenado en SQL Server.
        /// </summary>
        private static void AplicarEstiloEstado(DataGridViewRow row, string estado)
        {
            Color colorFondo;
            Color colorTexto;

            switch (estado)
            {
                case "Pending":
                    colorFondo = Color.FromArgb(255, 247, 232);
                    colorTexto = Color.FromArgb(146, 82, 16);
                    break;

                case "InPreparation":
                    colorFondo = Color.FromArgb(255, 243, 224);
                    colorTexto = Color.FromArgb(180, 83, 9);
                    break;

                case "Ready":
                    colorFondo = Color.FromArgb(232, 244, 238);
                    colorTexto = Color.FromArgb(21, 128, 61);
                    break;

                default:
                    colorFondo = Color.White;
                    colorTexto = Color.FromArgb(51, 51, 51);
                    break;
            }

            row.Cells[nameof(colEstado)].Style.BackColor = colorFondo;
            row.Cells[nameof(colEstado)].Style.ForeColor = colorTexto;
            row.Cells[nameof(colEstado)].Style.Font = new Font(
                "Century Gothic",
                10.2F,
                FontStyle.Bold);
        }

        /// <summary>
        /// Aplica el estilo visual correspondiente a la prioridad del pedido.
        /// Normal utiliza el color institucional y Urgent se representa como Alta.
        /// </summary>
        private static void AplicarEstiloPrioridad(DataGridViewRow row, string prioridad)
        {
            DataGridViewCellStyle estilo = row.Cells[nameof(colPrioridad)].Style;

            switch (prioridad)
            {
                case "Normal":
                    estilo.BackColor = Color.FromArgb(232, 244, 248);
                    estilo.ForeColor = Color.FromArgb(8, 126, 164);
                    estilo.Font = new Font(
                        "Century Gothic",
                        10.2F,
                        FontStyle.Bold);
                    break;

                case "Urgent":
                    estilo.BackColor = Color.FromArgb(254, 226, 226);
                    estilo.ForeColor = Color.FromArgb(185, 28, 28);
                    estilo.Font = new Font(
                        "Century Gothic",
                        10.2F,
                        FontStyle.Bold);
                    break;

                default:
                    estilo.BackColor = Color.White;
                    estilo.ForeColor = Color.FromArgb(51, 51, 51);
                    estilo.Font = new Font(
                        "Century Gothic",
                        10.2F,
                        FontStyle.Regular);
                    break;
            }
        }

        private void AplicarEstiloEstadoDetalle(string estado)
        {
            lblEstado.ForeColor = estado switch
            {
                "Pending" => Color.FromArgb(146, 82, 16),
                "InPreparation" => Color.FromArgb(180, 83, 9),
                "Ready" => Color.FromArgb(21, 128, 61),
                _ => Color.FromArgb(8, 31, 63)
            };
        }

        private void AplicarEstiloPrioridadDetalle(string prioridad)
        {
            switch (prioridad)
            {
                case "Normal":
                    lblPrioridad.ForeColor =
                        Color.FromArgb(8, 126, 164);
                    break;

                case "Urgent":
                    lblPrioridad.ForeColor =
                        Color.FromArgb(185, 28, 28);
                    break;

                default:
                    lblPrioridad.ForeColor =
                        Color.FromArgb(8, 31, 63);
                    break;
            }
        }

        #endregion

        #region Utilidades de la Vista
        private static string ObtenerTextoPrioridad(string prioridad)
        {
            return prioridad switch
            {
                "Urgent" => "ALTA",
                "Normal" => "NORMAL",
                _ => prioridad.ToUpperInvariant()
            };
        }

        private static string ObtenerTextoEstado(string estado)
        {
            return estado switch
            {
                "Pending" => "PENDIENTE",
                "InPreparation" => "EN PREPARACIÓN",
                "Ready" => "LISTO",
                "Delivered" => "ENTREGADO",
                "Cancelled" => "CANCELADO",
                _ => estado.ToUpperInvariant()
            };
        }

        private void LimpiarVistaDetalle()
        {
            lblOrden.Text = "Orden: #000";
            lblHora.Text = "Hora: 00:00";
            lblTipoOrden.Text = "Tipo: -";
            lblMesa.Text = "Mesa: -";
            lblEstado.Text = "Estado: -";
            lblPrioridad.Text = "Prioridad: -";

            lblEstado.ForeColor = Color.FromArgb(8, 31, 63);
            lblPrioridad.ForeColor = Color.FromArgb(8, 31, 63);

            dgvDetallePedido.Rows.Clear();

            btnIniciarPreparacion.Enabled = false;
            btnMarcarListo.Enabled = false;
            btnEntregarPedido.Enabled = false;
            btnCancelar.Enabled = false;
        }

        #endregion

        #region Cierre del formulario

        private void FrmCocinaPedidos_FormClosed(object? sender, FormClosedEventArgs e)
        {
            /*_timerActualizacion.Stop();
            _timerActualizacion.Tick -= TimerActualizacion_Tick;
            _timerActualizacion.Dispose();*/
            _presenter.Dispose();
        }

        #endregion

       
    }
}
