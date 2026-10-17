using Ocean_Desk_dv.Models.DTOs;
using Ocean_Desk_dv.Presenters;
using Ocean_Desk_dv.Services;
using Ocean_Desk_dv.UI.MessageBox;
using Ocean_Desk_dv.View.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Ocean_Desk_dv.UI.Catalogs
{
    /// <summary>
    /// Vista del módulo de Clientes.
    /// Implementa IClientesView y delega la lógica a ClientesPresenter.
    /// </summary>
    public partial class FrmClientes : Form, IClientesView
    {
        private ClientesPresenter? _presenter;
        private int? _clienteEnEdicionId;
        private bool _cargando; // evita disparar SelectionChanged mientras se llena la grilla

        #region Constructor
        public FrmClientes()
        {
            InitializeComponent();

            dgvClientes.AutoGenerateColumns = false;
            dgvHistorial.AutoGenerateColumns = false;

            _presenter = new ClientesPresenter(this, OceanDeskRepositoryFactory.CrearClientesRepository());
            _presenter.Inicializar();
        }
        #endregion

        #region Implementación de IClientesView
        public string TextoBusqueda => txtBuscar.Text.Trim();
        public bool SoloActivos => chkSoloActivos.Checked;
        public int? ClienteEnEdicionId => _clienteEnEdicionId;

        public int? ClienteSeleccionadoId =>
            dgvClientes.SelectedRows.Count > 0 && dgvClientes.SelectedRows[0].DataBoundItem is ClienteDto c
                ? c.CustomerId
                : null;

        public event EventHandler BuscarClicked = delegate { };
        public event EventHandler NuevoClicked = delegate { };
        public event EventHandler GuardarClicked = delegate { };
        public event EventHandler CambiarEstadoClicked = delegate { };
        public event EventHandler CancelarClicked = delegate { };
        public event EventHandler ClienteSeleccionado = delegate { };

        public ClienteGuardarDto ObtenerDatosFormulario() => new()
        {
            ClienteId = _clienteEnEdicionId,
            Nombre = txtNombre.Text.Trim(),
            Apellido = txtApellido.Text.Trim(),
            Telefono = txtTelefono.Text.Trim(),
            Correo = txtCorreo.Text.Trim(),
            Direccion = txtDireccion.Text.Trim(),
            Activo = chkActivo.Checked
        };

        public void MostrarClientes(IReadOnlyList<ClienteDto> clientes)
        {
            _cargando = true;
            dgvClientes.DataSource = null;
            dgvClientes.DataSource = clientes.ToList();
            dgvClientes.ClearSelection();
            _cargando = false;
        }

        public void MostrarResumen(ResumenClientesDto resumen)
        {
            lblValorTotal.Text = resumen.Total.ToString("N0", CultureInfo.GetCultureInfo("es-NI"));
            lblValorActivos.Text = resumen.Activos.ToString("N0", CultureInfo.GetCultureInfo("es-NI"));
            lblValorFrecuentes.Text = resumen.Frecuentes.ToString("N0", CultureInfo.GetCultureInfo("es-NI"));
        }

        public void MostrarDetalleCliente(ClienteDto cliente)
        {
            _clienteEnEdicionId = cliente.CustomerId;

            lblTituloDetalle.Text = "Datos del cliente";
            txtNombre.Text = cliente.Nombre;
            txtApellido.Text = cliente.Apellido;
            txtTelefono.Text = cliente.Telefono ?? string.Empty;
            txtCorreo.Text = cliente.Correo ?? string.Empty;
            txtDireccion.Text = cliente.Direccion ?? string.Empty;
            chkActivo.Checked = cliente.Activo;

            lblInfoCompras.Text = $"Compras: {cliente.TotalCompras}  |  Total: {FormatearMoneda(cliente.TotalGastado)}";
            lblInfoFidelizacion.Text = cliente.EsFrecuente
                ? "Fidelización: Cliente frecuente"
                : $"Fidelización: {cliente.TotalCompras}/{ClientesReglas.ComprasClienteFrecuente} compras para ser frecuente";

            btnCambiarEstado.Text = cliente.Activo ? "DESACTIVAR" : "ACTIVAR";
            btnCambiarEstado.Enabled = true;
            ActualizarEstadoVisualBotones();
        }

        public void MostrarHistorial(IReadOnlyList<CompraClienteDto> compras)
        {
            dgvHistorial.DataSource = null;
            dgvHistorial.DataSource = compras.ToList();
            dgvHistorial.ClearSelection();
        }

        public void PrepararNuevoCliente()
        {
            _clienteEnEdicionId = null;

            _cargando = true;
            dgvClientes.ClearSelection();
            _cargando = false;

            lblTituloDetalle.Text = "Nuevo cliente";
            txtNombre.Clear();
            txtApellido.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtDireccion.Clear();
            chkActivo.Checked = true;

            dgvHistorial.DataSource = null;
            lblInfoCompras.Text = "Compras: 0  |  Total: " + FormatearMoneda(0m);
            lblInfoFidelizacion.Text = "Fidelización: -";

            btnCambiarEstado.Text = "DESACTIVAR";
            btnCambiarEstado.Enabled = false;
            ActualizarEstadoVisualBotones();

            txtNombre.Focus();
        }

        public void SeleccionarCliente(int clienteId)
        {
            _cargando = true;
            foreach (DataGridViewRow fila in dgvClientes.Rows)
            {
                if (fila.DataBoundItem is ClienteDto c && c.CustomerId == clienteId)
                {
                    dgvClientes.ClearSelection();
                    fila.Selected = true;
                    dgvClientes.CurrentCell = fila.Cells[0];
                    break;
                }
            }
            _cargando = false;
        }

        public void MostrarMensaje(string mensaje, MessageType tipo)
        {
            FrmMessageBox.Show(mensaje, "Clientes", tipo);
        }

        public void MostrarConfirmacion(string mensaje, string titulo, Action accionConfirmada)
        {
            DialogResult resultado = FrmMessageBox.Show(mensaje, titulo, MessageType.Confirmation);
            if (resultado == DialogResult.Yes)
                accionConfirmada();
        }
        #endregion

        #region Eventos de controles
        private void btnBuscar_Click(object sender, EventArgs e) => BuscarClicked.Invoke(this, EventArgs.Empty);
        private void btnNuevo_Click(object sender, EventArgs e) => NuevoClicked.Invoke(this, EventArgs.Empty);
        private void btnGuardar_Click(object sender, EventArgs e) => GuardarClicked.Invoke(this, EventArgs.Empty);
        private void btnCambiarEstado_Click(object sender, EventArgs e) => CambiarEstadoClicked.Invoke(this, EventArgs.Empty);
        private void btnCancelar_Click(object sender, EventArgs e) => CancelarClicked.Invoke(this, EventArgs.Empty);
        private void chkSoloActivos_CheckedChanged(object sender, EventArgs e) => BuscarClicked.Invoke(this, EventArgs.Empty);

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            e.SuppressKeyPress = true;
            BuscarClicked.Invoke(this, EventArgs.Empty);
        }

        private void dgvClientes_SelectionChanged(object sender, EventArgs e)
        {
            if (_cargando || dgvClientes.SelectedRows.Count == 0) return;
            ClienteSeleccionado.Invoke(this, EventArgs.Empty);
        }
        #endregion

        #region Formato visual
        private void dgvClientes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvClientes.Rows[e.RowIndex].DataBoundItem is not ClienteDto cliente) return;

            string columna = dgvClientes.Columns[e.ColumnIndex].Name;

            if (!cliente.Activo)
                e.CellStyle.ForeColor = Color.FromArgb(155, 163, 170);

            if (columna == "colEstado")
            {
                e.CellStyle.ForeColor = cliente.Activo
                    ? Color.FromArgb(42, 122, 82)
                    : Color.FromArgb(111, 119, 128);
                e.CellStyle.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            }
        }

        private void dgvHistorial_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvHistorial.Columns[e.ColumnIndex].Name != "colHTotal") return;

            if (e.Value != null && decimal.TryParse(e.Value.ToString(), out decimal total))
            {
                e.Value = FormatearMoneda(total);
                e.FormattingApplied = true;
            }
        }

        private void ActualizarEstadoVisualBotones()
        {
            if (btnCambiarEstado.Enabled)
            {
                btnCambiarEstado.BackColor = Color.FromArgb(238, 243, 247);
                btnCambiarEstado.ForeColor = Color.FromArgb(8, 31, 63);
            }
            else
            {
                btnCambiarEstado.BackColor = Color.FromArgb(232, 236, 239);
                btnCambiarEstado.ForeColor = Color.FromArgb(155, 163, 170);
            }
        }

        private static string FormatearMoneda(decimal monto) =>
            "C$ " + monto.ToString("N2", CultureInfo.GetCultureInfo("es-NI"));
        #endregion

        #region Liberación de recursos
        private void FrmClientes_FormClosed(object? sender, FormClosedEventArgs e)
        {
            _presenter?.Dispose();
            _presenter = null;
        }
        #endregion
    }
}
