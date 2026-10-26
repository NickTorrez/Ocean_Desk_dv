using Ocean_Desk_dv.Models.DTOs;
using Ocean_Desk_dv.Presenters;
using Ocean_Desk_dv.UI.MessageBox;
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

namespace Ocean_Desk_dv.View.Catalogs
{
    public partial class FrmProveedores : Form, IProveedoresView
    {
        private ProveedoresPresenter? _presenter;
        private bool _cargandoDatos;
        private bool _edicionHabilitada;
        private bool _hayProveedorSeleccionado;
        private int? _proveedorEnFormularioId;

        private static readonly Font FuenteFilasGrid = new Font(
            "Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
        private static readonly Font FuenteEncabezadosGrid = new Font(
            "Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);

        public FrmProveedores()
        {
            InitializeComponent();

            ConfigurarControles();
            ConectarEventos();

            Shown += FrmProveedores_Shown;

            LimpiarFormularioProveedor();
            HabilitarEdicion(false);
            ActualizarEstadoAcciones(false, false);
            MostrarProveedoresConCompras(Array.Empty<ProveedorSelectorDto>());
            MostrarComprasAsociadas(Array.Empty<CompraProveedorDto>());

            Disposed += (_, _) =>
            {
                _presenter?.Dispose();
                _presenter = null;
            };
        }

        private void FrmProveedores_Shown(object? sender, EventArgs e)
        {
            // Esperar a que finalice la presentación inicial del formulario.
            BeginInvoke((Action)(() =>
            {
                if (IsDisposed)
                    return;

                // Mantener la cuadrícula cargada, pero sin fila seleccionada.
                LimpiarFormularioProveedor();

                // La captura debe comenzar deshabilitada.
                HabilitarEdicion(false);
                ActualizarEstadoAcciones(false, false);
            }));
        }

        public void VincularPresenter(ProveedoresPresenter presenter)
        {
            if (presenter is null)
                throw new ArgumentNullException(nameof(presenter));

            if (_presenter is not null)
                throw new InvalidOperationException(
                    "El Presenter de proveedores ya fue asignado.");

            _presenter = presenter;
            _presenter.Inicializar();
        }

        public string TextoBusqueda => txtBuscarProveedor.Text.Trim();

        public int? ProveedorSeleccionadoId =>
            dgvProveedores.SelectedRows.Count > 0 &&
            dgvProveedores.SelectedRows[0].DataBoundItem is ProveedorDto proveedor
                ? proveedor.SupplierId
                : null;

        public int? ProveedorComprasSeleccionadoId =>
            cmbProveedorCompra.SelectedItem is ProveedorSelectorDto proveedor &&
            proveedor.SupplierId > 0
                ? proveedor.SupplierId
                : null;

        public GuardarProveedorDto DatosFormulario => new()
        {
            SupplierId = _proveedorEnFormularioId,
            SupplierName = txtNombreProveedor.Text.Trim(),
            ContactName = string.IsNullOrWhiteSpace(textBox1.Text)
                ? null
                : textBox1.Text.Trim(),
            Phone = ObtenerTelefonoIngresado(),
            Email = string.IsNullOrWhiteSpace(txtCorreoProveedor.Text)
                ? null
                : txtCorreoProveedor.Text.Trim(),
            Address = string.IsNullOrWhiteSpace(txtDireccionProveedor.Text)
                ? null
                : txtDireccionProveedor.Text.Trim(),
            IsActive = chkActivoProveedor.Checked
        };

        public event EventHandler? BusquedaCambiada;
        public event EventHandler? ProveedorSeleccionadoCambiado;
        public event EventHandler? NuevoProveedorSolicitado;
        public event EventHandler? EditarProveedorSolicitado;
        public event EventHandler? CambiarEstadoProveedorSolicitado;
        public event EventHandler? GuardarProveedorSolicitado;
        public event EventHandler? CancelarEdicionSolicitada;
        public event EventHandler? ProveedorComprasSeleccionadoCambiado;

        private void ConfigurarControles()
        {
            txtNombreProveedor.MaxLength = 150;
            textBox1.MaxLength = 120;
            txtCorreoProveedor.MaxLength = 150;
            txtDireccionProveedor.MaxLength = 250;

            txtTelefonoNuevoCliente.Mask = " 0000-0000";
            txtTelefonoNuevoCliente.PromptChar = '0';
            txtTelefonoNuevoCliente.TextMaskFormat = MaskFormat.IncludeLiterals;

            txtBuscarProveedor.PlaceholderText = "Buscar proveedor...";
            cmbProveedorCompra.DropDownStyle = ComboBoxStyle.DropDownList;

            colNombreProveedor.DataPropertyName = nameof(ProveedorDto.SupplierName);
            colTelefonoProveedor.DataPropertyName = nameof(ProveedorDto.Phone);
            colCorreoProveedor.DataPropertyName = nameof(ProveedorDto.Email);
            colEstadoProveedor.DataPropertyName = nameof(ProveedorDto.IsActive);
            // El diseñador tenía ContactName enlazado a la columna Dirección.
            colDireccionProveedor.DataPropertyName = nameof(ProveedorDto.Address);

            colIdCompraProv.DataPropertyName = nameof(CompraProveedorDto.PurchaseId);
            colFechaCompraProv.DataPropertyName = nameof(CompraProveedorDto.PurchaseDate);
            colTotalCompraProv.DataPropertyName = nameof(CompraProveedorDto.Total);
            colEstadoCompraProv.DataPropertyName = nameof(CompraProveedorDto.Status);
            colDocumentoCompraProv.DataPropertyName = nameof(CompraProveedorDto.DocumentNumber);
            colFechaCompraProv.DefaultCellStyle.Format = "dd/MM/yyyy";
            colTotalCompraProv.DefaultCellStyle.Format = "C$ #,##0.00";

            dgvProveedores.AutoGenerateColumns = false;
            dgvComprasProveedor.AutoGenerateColumns = false;
            AplicarEstiloGrid(dgvProveedores);
            AplicarEstiloGrid(dgvComprasProveedor);

            dgvProveedores.CellFormatting += DgvProveedores_CellFormatting;
            dgvComprasProveedor.ClearSelection();
        }

        /// <summary>
        /// Replica la configuración visual de dgvExistencias de Inventario.
        /// Se aplica el mismo método a las dos cuadrículas de este módulo.
        /// </summary>
        private static void AplicarEstiloGrid(DataGridView grid)
        {
            Color azulOcean = Color.FromArgb(8, 31, 63);
            Color fondoAlterno = Color.FromArgb(248, 250, 252);
            Color fondoSeleccion = Color.FromArgb(224, 234, 240);

            grid.AutoGenerateColumns = false;
            grid.ReadOnly = true;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AllowUserToResizeColumns = false;
            grid.AllowUserToResizeRows = false;
            grid.AllowUserToOrderColumns = true;
            grid.MultiSelect = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.BackgroundColor = Color.White;
            grid.BorderStyle = BorderStyle.None;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.EnableHeadersVisualStyles = false;
            grid.RowHeadersVisible = false;
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grid.RowTemplate.Height = 38;
            grid.ScrollBars = ScrollBars.Vertical;
            grid.GridColor = SystemColors.ControlDark;

            grid.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;
            grid.ColumnHeadersDefaultCellStyle.BackColor = azulOcean;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = FuenteEncabezadosGrid;
            grid.ColumnHeadersDefaultCellStyle.Padding = new Padding(6, 0, 0, 0);
            grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.MidnightBlue;
            grid.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;

            grid.DefaultCellStyle.BackColor = Color.White;
            grid.DefaultCellStyle.Font = FuenteFilasGrid;
            grid.DefaultCellStyle.ForeColor = azulOcean;
            grid.DefaultCellStyle.SelectionBackColor = fondoSeleccion;
            grid.DefaultCellStyle.SelectionForeColor = azulOcean;
            grid.DefaultCellStyle.WrapMode = DataGridViewTriState.False;

            grid.AlternatingRowsDefaultCellStyle.BackColor = fondoAlterno;
            grid.AlternatingRowsDefaultCellStyle.Font = FuenteFilasGrid;
            grid.AlternatingRowsDefaultCellStyle.ForeColor = azulOcean;
            grid.AlternatingRowsDefaultCellStyle.SelectionBackColor = fondoSeleccion;
            grid.AlternatingRowsDefaultCellStyle.SelectionForeColor = azulOcean;

            grid.RowTemplate.DefaultCellStyle.BackColor = Color.Empty;
            grid.RowTemplate.DefaultCellStyle.Font = FuenteFilasGrid;
            grid.RowTemplate.DefaultCellStyle.ForeColor = azulOcean;
            grid.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.Empty;
            grid.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.Empty;

            // Limpiar formatos de color heredados por columna sin alterar
            // alineaciones ni los formatos numéricos definidos por cada campo.
            foreach (DataGridViewColumn columna in grid.Columns)
            {
                columna.DefaultCellStyle.BackColor = Color.Empty;
                columna.DefaultCellStyle.Font = FuenteFilasGrid;
                columna.DefaultCellStyle.ForeColor = azulOcean;
                columna.DefaultCellStyle.SelectionBackColor = fondoSeleccion;
                columna.DefaultCellStyle.SelectionForeColor = azulOcean;
            }
        }

        private void DgvProveedores_CellFormatting(
            object? sender,
            DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (dgvProveedores.Columns[e.ColumnIndex].Name != colEstadoProveedor.Name)
                return;

            if (e.Value is not bool activo)
                return;

            e.Value = activo ? "Activo" : "Inactivo";
            e.CellStyle.ForeColor = activo ? Color.DarkGreen : Color.Firebrick;
            e.FormattingApplied = true;
        }

        private void ConectarEventos()
        {
            txtBuscarProveedor.TextChanged += (_, _) =>
            {
                if (!_cargandoDatos &&
                    tcProveedores.SelectedTab == tpProveedores &&
                    !_edicionHabilitada)
                {
                    BusquedaCambiada?.Invoke(this, EventArgs.Empty);
                }
            };

            // Cargar un proveedor cuando el usuario haga clic en una fila.
            dgvProveedores.CellClick += (_, e) =>
            {
                if (_cargandoDatos || e.RowIndex < 0)
                    return;

                ProveedorSeleccionadoCambiado?.Invoke(
                    this,
                    EventArgs.Empty);
            };

            // Permitir recorrer los proveedores mediante el teclado.
            dgvProveedores.KeyUp += (_, e) =>
            {
                if (_cargandoDatos || dgvProveedores.SelectedRows.Count == 0)
                    return;

                bool teclaNavegacion =
                    e.KeyCode == Keys.Up ||
                    e.KeyCode == Keys.Down ||
                    e.KeyCode == Keys.Home ||
                    e.KeyCode == Keys.End ||
                    e.KeyCode == Keys.PageUp ||
                    e.KeyCode == Keys.PageDown;

                if (!teclaNavegacion)
                    return;

                ProveedorSeleccionadoCambiado?.Invoke(
                    this,
                    EventArgs.Empty);
            };

            btnNuevoProveedor.Click += (_, _) =>
            {
                // Nuevo siempre permanece disponible, incluso en Compras asociadas.
                if (tcProveedores.SelectedTab != tpProveedores)
                    tcProveedores.SelectedTab = tpProveedores;

                NuevoProveedorSolicitado?.Invoke(this, EventArgs.Empty);
            };

            btnEditarProveedor.Click += (_, _) =>
                EditarProveedorSolicitado?.Invoke(this, EventArgs.Empty);

            btnCambiarEstadoProveedor.Click += (_, _) =>
                CambiarEstadoProveedorSolicitado?.Invoke(this, EventArgs.Empty);

            btnGuardarProveedor.Click += (_, _) =>
                GuardarProveedorSolicitado?.Invoke(this, EventArgs.Empty);

            btnCancelarProveedor.Click += (_, _) =>
                CancelarEdicionSolicitada?.Invoke(this, EventArgs.Empty);

            cmbProveedorCompra.SelectedIndexChanged += (_, _) =>
            {
                if (!_cargandoDatos)
                    ProveedorComprasSeleccionadoCambiado?.Invoke(this, EventArgs.Empty);
            };

            tcProveedores.SelectedIndexChanged += (_, _) =>
            {
                AplicarEstadoBarraSuperior();
                if (tcProveedores.SelectedTab == tpComprasAsociadas &&
                    ProveedorComprasSeleccionadoId is null)
                {
                    MostrarComprasAsociadas(Array.Empty<CompraProveedorDto>());
                }
            };
        }

        private void AplicarEstadoBarraSuperior()
        {
            bool enComprasAsociadas = tcProveedores.SelectedTab == tpComprasAsociadas;

            // Mantener el contenedor habilitado; se deshabilitan sus secciones
            // individualmente para que Nuevo siga funcionando en ambas pestañas.
            tlpFiltroButons.Enabled = true;
            pnlFiltroProveedor.Enabled = !enComprasAsociadas && !_edicionHabilitada;
            pnlNuevo.Enabled = true;
            btnNuevoProveedor.Enabled = true;
            pnlEditar.Enabled = !enComprasAsociadas && !_edicionHabilitada && _hayProveedorSeleccionado;
            pnlCambiar.Enabled = !enComprasAsociadas && !_edicionHabilitada && _hayProveedorSeleccionado;
            dgvProveedores.Enabled = !_edicionHabilitada;
        }

        public void MostrarProveedores(
            IReadOnlyList<ProveedorDto> proveedores,
            int? seleccionarId = null)
        {
            _cargandoDatos = true;
            try
            {
                dgvProveedores.DataSource = null;
                dgvProveedores.DataSource = proveedores.ToList();
                dgvProveedores.CurrentCell = null;
                dgvProveedores.ClearSelection();

                bool seleccionEncontrada = false;
                if (seleccionarId.HasValue)
                {
                    foreach (DataGridViewRow fila in dgvProveedores.Rows)
                    {
                        if (fila.DataBoundItem is ProveedorDto proveedor &&
                            proveedor.SupplierId == seleccionarId.Value)
                        {
                            fila.Selected = true;
                            if (fila.Cells.Count > 0)
                                dgvProveedores.CurrentCell = fila.Cells[0];
                            seleccionEncontrada = true;
                            break;
                        }
                    }
                }

                _hayProveedorSeleccionado = seleccionEncontrada;
            }
            finally
            {
                _cargandoDatos = false;
            }

            AplicarEstadoBarraSuperior();
        }

        public void MostrarProveedoresConCompras(
            IReadOnlyList<ProveedorSelectorDto> proveedores,
            int? seleccionarId = null)
        {
            _cargandoDatos = true;
            try
            {
                var opciones = new List<ProveedorSelectorDto>
            {
                new() { SupplierId = 0, SupplierName = "Seleccione Proveedor..." }
            };
                opciones.AddRange(proveedores);

                cmbProveedorCompra.DataSource = null;
                cmbProveedorCompra.DisplayMember = nameof(ProveedorSelectorDto.SupplierName);
                cmbProveedorCompra.ValueMember = nameof(ProveedorSelectorDto.SupplierId);
                cmbProveedorCompra.DataSource = opciones;
                cmbProveedorCompra.SelectedIndex = 0;

                if (seleccionarId.HasValue &&
                    opciones.Any(p => p.SupplierId == seleccionarId.Value))
                {
                    cmbProveedorCompra.SelectedValue = seleccionarId.Value;
                }
            }
            finally
            {
                _cargandoDatos = false;
            }
        }

        public void MostrarComprasAsociadas(IReadOnlyList<CompraProveedorDto> compras)
        {
            _cargandoDatos = true;
            try
            {
                dgvComprasProveedor.DataSource = null;
                dgvComprasProveedor.DataSource = compras.ToList();
                dgvComprasProveedor.CurrentCell = null;
                dgvComprasProveedor.ClearSelection();
            }
            finally
            {
                _cargandoDatos = false;
            }
        }

        public void CargarProveedorEnFormulario(ProveedorDto proveedor)
        {
            _cargandoDatos = true;
            try
            {
                _proveedorEnFormularioId = proveedor.SupplierId;
                txtNombreProveedor.Text = proveedor.SupplierName;
                textBox1.Text = proveedor.ContactName ?? string.Empty;
                txtCorreoProveedor.Text = proveedor.Email ?? string.Empty;
                txtDireccionProveedor.Text = proveedor.Address ?? string.Empty;
                chkActivoProveedor.Checked = proveedor.IsActive;

                string? telefono = proveedor.Phone;
                if (!string.IsNullOrWhiteSpace(telefono))
                {
                    string digitos = new(telefono.Where(char.IsDigit).ToArray());
                    if (digitos.Length == 8)
                        telefono = $"{digitos[..4]}-{digitos[4..]}";
                    txtTelefonoNuevoCliente.Text = string.IsNullOrWhiteSpace(telefono)
                        ? string.Empty
                        : " " + telefono;
                }
                else
                {
                    txtTelefonoNuevoCliente.Clear();
                }
            }
            finally
            {
                _cargandoDatos = false;
            }
        }

        public void LimpiarFormularioProveedor()
        {
            _cargandoDatos = true;
            try
            {
                _proveedorEnFormularioId = null;
                dgvProveedores.CurrentCell = null;
                dgvProveedores.ClearSelection();
                _hayProveedorSeleccionado = false;
                txtNombreProveedor.Clear();
                textBox1.Clear();
                txtTelefonoNuevoCliente.Clear();
                txtCorreoProveedor.Clear();
                txtDireccionProveedor.Clear();
                chkActivoProveedor.Checked = true;
            }
            finally
            {
                _cargandoDatos = false;
            }
        }

        public void HabilitarEdicion(bool habilitar)
        {
            _edicionHabilitada = habilitar;
            tlpInputDatosProveedor.Enabled = habilitar;
            tlpButtons.Enabled = habilitar;
            AplicarEstadoBarraSuperior();
        }

        public void ActualizarEstadoAcciones(bool haySeleccion, bool editando)
        {
            _hayProveedorSeleccionado = haySeleccion;
            _edicionHabilitada = editando;
            AplicarEstadoBarraSuperior();
        }

        public void SeleccionarPestanaProveedores()
        {
            tcProveedores.SelectedTab = tpProveedores;
        }

        public void LimpiarBusqueda()
        {
            _cargandoDatos = true;
            try
            {
                txtBuscarProveedor.Clear();
            }
            finally
            {
                _cargandoDatos = false;
            }
        }

        public void MostrarMensaje(string mensaje, bool esError = false)
        {
            FrmMessageBox.Show(
                mensaje,
                "Proveedores",
                esError ? MessageType.Error : MessageType.Information,
                this);
        }

        public bool ConfirmarCambioEstado(string nombreProveedor, bool activar)
        {
            string accion = activar ? "activar" : "desactivar";
            return FrmMessageBox.Show(
                $"¿Desea {accion} al proveedor «{nombreProveedor}»?",
                "Cambiar estado del proveedor",
                MessageType.Confirmation,
                this) == DialogResult.Yes;
        }

        private string? ObtenerTelefonoIngresado()
        {
            MaskFormat formatoAnterior = txtTelefonoNuevoCliente.TextMaskFormat;
            try
            {
                txtTelefonoNuevoCliente.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                string digitos = txtTelefonoNuevoCliente.Text.Trim();
                return string.IsNullOrWhiteSpace(digitos) ? null : digitos;
            }
            finally
            {
                txtTelefonoNuevoCliente.TextMaskFormat = formatoAnterior;
            }
        }

    }
}
