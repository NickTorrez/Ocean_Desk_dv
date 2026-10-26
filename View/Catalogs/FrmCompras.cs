using Ocean_Desk_dv.UI.MessageBox;
using Ocean_Desk_dv.Data;
using Ocean_Desk_dv.Models.DTOs;
using Ocean_Desk_dv.Presenters;
using Ocean_Desk_dv.Services;
using Ocean_Desk_dv.Services.Interfaces_Services;
using Ocean_Desk_dv.Services.Repository;
using Ocean_Desk_dv.View.Interfaces;
using Ocean_Desk_dv.View.Localization;
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
    public partial class FrmCompras : Form, IComprasView
    {
        private ComprasPresenter? _presenter;
        private bool _cargandoDatos;
        private bool _capturandoCompraNueva;
        private List<DetalleCompraCapturaDto> _detallesCapturados = new();

        public FrmCompras()
        {
            InitializeComponent();

            ConfigurarGrillas();
            ConfigurarFiltros();
            ConectarEventos();

            FormClosed += (_, _) =>
            {
                _presenter?.Dispose();
                _presenter = null;
            };
        }

        /// <summary>
        /// Formatea un importe en córdobas sin depender
        /// del símbolo monetario de la configuración regional.
        /// </summary>
        private static string FormatearCordobas(decimal importe)
        {
            return $"C$ {importe:N2}";
        }

        /// <summary>
        /// Recibe el Presenter desde el punto de composición
        /// e inicia la carga de los datos del módulo.
        /// </summary>
        public void VincularPresenter(ComprasPresenter presenter)
        {
            if (presenter is null)
                throw new ArgumentNullException(nameof(presenter));

            if (_presenter is not null)
                throw new InvalidOperationException(
                    "El Presenter de compras ya fue asignado.");

            _presenter = presenter;
            _presenter.Inicializar();
        }
        public FiltroComprasDto FiltroActual => new()
        {
            Texto = string.IsNullOrWhiteSpace(txtBuscarCompra.Text) ? null : txtBuscarCompra.Text.Trim(),
            Estado = cmbEstadoCompra.SelectedItem?.ToString(),
            Fecha = dtpFechaCompraFiltro.Checked ? dtpFechaCompraFiltro.Value.Date : null
        };

        public int? CompraSeleccionadaId =>
            dgvCompras.SelectedRows.Count > 0 &&
            dgvCompras.SelectedRows[0].DataBoundItem is CompraResumenDto compra
                ? compra.PurchaseId
                : null;

        public bool CapturandoCompraNueva => _capturandoCompraNueva;

        public SolicitudCompraDto SolicitudActual => new()
        {
            SupplierId = cmbProveedorCompra.SelectedValue is int id ? id : 0,
            PurchaseDate = dtpFechaCompra.Value,
            DocumentNumber = txtDocumentoCompra.Text,
            Notes = txtNotasCompra.Text,
            Details = _detallesCapturados.ToList()
        };

        public event EventHandler? FiltrosCambiados;
        public event EventHandler? CompraSeleccionadaCambiada;
        public event EventHandler? NuevaCompraSolicitada;
        public event EventHandler? AgregarDetalleSolicitado;
        public event EventHandler? GuardarCompraSolicitado;
        public event EventHandler? CancelarCompraSolicitado;
        public event EventHandler? RegistrarRecepcionSolicitado;

        private void ConfigurarGrillas()
        {
            dgvCompras.AutoGenerateColumns = false;
            dgvCompras.ReadOnly = true;
            dgvCompras.AllowUserToAddRows = false;
            dgvCompras.AllowUserToDeleteRows = false;
            dgvCompras.MultiSelect = false;
            dgvCompras.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            colTotalCompra.DefaultCellStyle.Format = "C$ #,##0.00";
            colFechaCompra.DefaultCellStyle.Format = "dd/MM/yyyy";
            colRecibidaCompra.DefaultCellStyle.Format = "dd/MM/yyyy";

            dgvDetalleCompra.AutoGenerateColumns = false;
            dgvDetalleCompra.ReadOnly = true;
            dgvDetalleCompra.AllowUserToAddRows = false;
            dgvDetalleCompra.AllowUserToDeleteRows = false;
            dgvDetalleCompra.MultiSelect = false;
            dgvDetalleCompra.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            colCantidadCompra.DefaultCellStyle.Format = "#,##0.####";
            colCostoCompra.DefaultCellStyle.Format = "C$ #,##0.0000";
            colSubtotalCompra.DefaultCellStyle.Format = "C$ #,##0.00";
            colRecepcionCompra.HeaderText = "Recibido";

            dgvDetalleCompra.CellFormatting -= DgvDetalleCompra_CellFormatting;
            dgvDetalleCompra.CellFormatting += DgvDetalleCompra_CellFormatting;

            // Configurar el formato de la cantidad recibida.
            colRecepcionCompra.DefaultCellStyle.Format = "#,##0.####";

            // Aplicar el estilo visual de la tabla principal.
            ConfigurarEstiloDgvCompras();
        }

        /// <summary>
        /// Elimina los tonos azules heredados del diseñador
        /// y establece un encabezado negro con filas claras.
        /// </summary>
        private void ConfigurarEstiloDgvCompras()
        {
            dgvCompras.EnableHeadersVisualStyles = false;

            // Encabezado negro y texto blanco.
            //dgvCompras.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
            //dgvCompras.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            //dgvCompras.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.Black;
            //dgvCompras.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;

            // Filas normales.
            dgvCompras.DefaultCellStyle.BackColor = Color.White;
            dgvCompras.DefaultCellStyle.ForeColor = Color.Black;

            // Selección de fila en gris claro, sin azul.
            dgvCompras.DefaultCellStyle.SelectionBackColor = Color.Gainsboro;
            dgvCompras.DefaultCellStyle.SelectionForeColor = Color.Black;

            // Estilo de filas alternas.
            dgvCompras.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            dgvCompras.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;
            dgvCompras.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.Gainsboro;
            dgvCompras.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.Black;

            // Eliminar los colores azules heredados de las filas nuevas.
            dgvCompras.RowTemplate.DefaultCellStyle.BackColor = Color.White;
            dgvCompras.RowTemplate.DefaultCellStyle.ForeColor = Color.Black;
            dgvCompras.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.Gainsboro;
            dgvCompras.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.Black;

            // Separadores discretos.
            dgvCompras.GridColor = Color.LightGray;
        }

        private void DgvDetalleCompra_CellFormatting(
            object? sender,
            DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            object? registro = dgvDetalleCompra.Rows[e.RowIndex].DataBoundItem;
            string columna = dgvDetalleCompra.Columns[e.ColumnIndex].Name;

            string codigo = string.Empty;
            string producto = string.Empty;
            string unidad = string.Empty;

            if (registro is CompraDetalleDto detalleGuardado)
            {
                codigo = detalleGuardado.ProductCode;
                producto = detalleGuardado.ProductName;
                unidad = detalleGuardado.UnitName;
            }
            else if (registro is DetalleCompraCapturaDto detalleNuevo)
            {
                codigo = detalleNuevo.ProductCode;
                producto = detalleNuevo.ProductName;
                unidad = detalleNuevo.UnitName;
            }
            else
            {
                return;
            }

            if (columna == colProductoCompra.Name)
            {
                e.Value = CatalogoTraducciones.TraducirIngrediente(codigo, producto);
                e.FormattingApplied = true;
            }
            else if (columna == colUnidadCompra.Name)
            {
                e.Value = CatalogoTraducciones.TraducirUnidad(null, unidad);
                e.FormattingApplied = true;
            }
        }

        private void ConfigurarFiltros()
        {
            cmbEstadoCompra.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstadoCompra.Items.Clear();
            cmbEstadoCompra.Items.AddRange(new object[]
            {
            "Todas", EstadosCompra.Borrador, EstadosCompra.Pendiente,
            EstadosCompra.Recibida, EstadosCompra.Cancelada
            });
            cmbEstadoCompra.SelectedIndex = 0;
            dtpFechaCompraFiltro.ShowCheckBox = true;
            dtpFechaCompraFiltro.Checked = false;
            dtpFechaCompra.Value = DateTime.Today;
        }

        private void ConectarEventos()
        {
            btnNuevaCompra.Click += (_, _) => NuevaCompraSolicitada?.Invoke(this, EventArgs.Empty);
            btnAgregarProducto.Click += (_, _) => AgregarDetalleSolicitado?.Invoke(this, EventArgs.Empty);
            btnGuardarCompra.Click += (_, _) => GuardarCompraSolicitado?.Invoke(this, EventArgs.Empty);
            btnCancelarCompra.Click += (_, _) =>
            {
                if (_capturandoCompraNueva ||
                    FrmMessageBox.Show(
                        "¿Desea cancelar la compra pendiente seleccionada?",
                        "Cancelar compra",
                        MessageType.Confirmation,
                        this) == DialogResult.Yes)
                {
                    CancelarCompraSolicitado?.Invoke(this, EventArgs.Empty);
                }
            };

            btnRegistrarRecepcion.Click += (_, _) =>
            {
                if (FrmMessageBox.Show(
                    "La recepción aumentará el stock, creará lotes y registrará movimientos de inventario. ¿Desea continuar?",
                    "Confirmar recepción",
                    MessageType.Confirmation,
                    this) == DialogResult.Yes)
                {
                    RegistrarRecepcionSolicitado?.Invoke(this, EventArgs.Empty);
                }
            };

            txtBuscarCompra.TextChanged += (_, _) =>
            {
                if (!_cargandoDatos) FiltrosCambiados?.Invoke(this, EventArgs.Empty);
            };
            cmbEstadoCompra.SelectedIndexChanged += (_, _) =>
            {
                if (!_cargandoDatos) FiltrosCambiados?.Invoke(this, EventArgs.Empty);
            };
            dtpFechaCompraFiltro.ValueChanged += (_, _) =>
            {
                if (!_cargandoDatos && dtpFechaCompraFiltro.Checked)
                    FiltrosCambiados?.Invoke(this, EventArgs.Empty);
            };
            dtpFechaCompraFiltro.CloseUp += (_, _) =>
            {
                if (!_cargandoDatos) FiltrosCambiados?.Invoke(this, EventArgs.Empty);
            };
            dgvCompras.SelectionChanged += (_, _) =>
            {
                if (!_cargandoDatos && !_capturandoCompraNueva && CompraSeleccionadaId.HasValue)
                    CompraSeleccionadaCambiada?.Invoke(this, EventArgs.Empty);
            };
        }

        public void MostrarProveedores(IReadOnlyList<ProveedorCompraDto> proveedores)
        {
            _cargandoDatos = true;
            try
            {
                cmbProveedorCompra.DataSource = null;
                cmbProveedorCompra.DisplayMember = nameof(ProveedorCompraDto.SupplierName);
                cmbProveedorCompra.ValueMember = nameof(ProveedorCompraDto.SupplierId);
                cmbProveedorCompra.DataSource = proveedores.ToList();
                cmbProveedorCompra.SelectedIndex = proveedores.Count > 0 ? 0 : -1;
            }
            finally { _cargandoDatos = false; }
        }

        public void MostrarCompras(IReadOnlyList<CompraResumenDto> compras)
        {
            _cargandoDatos = true;
            try
            {
                dgvCompras.DataSource = null;
                dgvCompras.DataSource = compras.ToList();
                dgvCompras.ClearSelection();
            }
            finally { _cargandoDatos = false; }
        }

        public void MostrarCompraSeleccionada(CompraResumenDto compra, IReadOnlyList<CompraDetalleDto> detalles)
        {
            _capturandoCompraNueva = false;
            _cargandoDatos = true;
            try
            {
                int index = cmbProveedorCompra.FindStringExact(compra.SupplierName);
                if (index >= 0) cmbProveedorCompra.SelectedIndex = index;
                else cmbProveedorCompra.SelectedValue = compra.SupplierId;

                dtpFechaCompra.Value = compra.PurchaseDate < dtpFechaCompra.MinDate
                    ? dtpFechaCompra.MinDate
                    : compra.PurchaseDate > dtpFechaCompra.MaxDate ? dtpFechaCompra.MaxDate : compra.PurchaseDate;
                txtDocumentoCompra.Text = compra.DocumentNumber ?? string.Empty;
                txtNotasCompra.Text = compra.Notes ?? string.Empty;
                dgvDetalleCompra.DataSource = null;
                dgvDetalleCompra.DataSource = detalles.ToList();
                lblSubtotalCompra.Text = $"Subtotal: {FormatearCordobas(compra.Subtotal)}";
                lblTotalCompra.Text = $"Total: {FormatearCordobas(compra.Total)}";
                HabilitarCaptura(false);
                bool pendiente = compra.Status == EstadosCompra.Pendiente;
                btnRegistrarRecepcion.Enabled = pendiente && detalles.Count > 0;
                btnCancelarCompra.Enabled = pendiente;
            }
            finally { _cargandoDatos = false; }
        } 

        public void MostrarDetalleCapturado(IReadOnlyList<DetalleCompraCapturaDto> detalles)
        {
            _detallesCapturados = detalles.ToList();
            dgvDetalleCompra.DataSource = null;
            dgvDetalleCompra.DataSource = _detallesCapturados.ToList();
            decimal subtotal = Math.Round(_detallesCapturados.Sum(d => d.Subtotal), 2, MidpointRounding.AwayFromZero);
            lblSubtotalCompra.Text = $"Subtotal: {FormatearCordobas(subtotal)}";
            lblTotalCompra.Text = $"Total: {FormatearCordobas(subtotal)}";
        }

        public void PrepararNuevaCompra()
        {
            _capturandoCompraNueva = true;
            _detallesCapturados.Clear();
            _cargandoDatos = true;
            try
            {
                dgvCompras.ClearSelection();
                dtpFechaCompra.Value = DateTime.Today;
                txtDocumentoCompra.Clear();
                txtNotasCompra.Clear();
                dgvDetalleCompra.DataSource = null;
                lblSubtotalCompra.Text = $"Subtotal: {FormatearCordobas(0m)}";
                lblTotalCompra.Text = $"Total: {FormatearCordobas(0m)}";
            }
            finally { _cargandoDatos = false; }
            HabilitarCaptura(true);
            btnRegistrarRecepcion.Enabled = false;
            btnCancelarCompra.Enabled = true;
        }

        public void HabilitarCaptura(bool habilitar)
        {
            // Al cancelar o terminar de guardar una captura nueva, no dejar
            // líneas ni totales temporales visibles como si fueran una compra guardada.
            if (!habilitar && _capturandoCompraNueva)
            {
                _detallesCapturados.Clear();
                _cargandoDatos = true;
                try
                {
                    txtDocumentoCompra.Clear();
                    txtNotasCompra.Clear();
                    dgvDetalleCompra.DataSource = null;
                    lblSubtotalCompra.Text = "Subtotal: C$ 0.00";
                    lblTotalCompra.Text = "Total: C$ 0.00";
                }
                finally
                {
                    _cargandoDatos = false;
                }
            }

            _capturandoCompraNueva = habilitar;
            cmbProveedorCompra.Enabled = habilitar;
            dtpFechaCompra.Enabled = habilitar;
            txtDocumentoCompra.Enabled = habilitar;
            txtNotasCompra.Enabled = habilitar;
            btnAgregarProducto.Enabled = habilitar;
            btnGuardarCompra.Enabled = habilitar;
            btnRegistrarRecepcion.Enabled = false;
            btnNuevaCompra.Enabled = !habilitar;
            btnCancelarCompra.Enabled = habilitar;
        }

        public DetalleCompraCapturaDto? SolicitarDetalleCompra(IReadOnlyList<ProductoCompraDto> productos)
        {
            using var dialog = new Form
            {
                Text = "Agregar ingrediente a la compra",
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MinimizeBox = false,
                MaximizeBox = false,
                ShowInTaskbar = false,
                ClientSize = new Size(460, 430),
                Font = new Font("Century Gothic", 9F),
                BackColor = Color.White
            };

            var layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(16),
                ColumnCount = 2,
                RowCount = 7,
                BackColor = Color.White
            };
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 135F));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            for (int r = 0; r < 6; r++) layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            var cmbProducto = new ComboBox
            {
                Dock = DockStyle.Fill,
                DropDownStyle = ComboBoxStyle.DropDownList,
                FormattingEnabled = true
            };
            cmbProducto.DisplayMember = nameof(ProductoCompraDto.ProductName);
            cmbProducto.Format += (_, e) =>
            {
                if (e.ListItem is ProductoCompraDto producto)
                {
                    string nombre = CatalogoTraducciones.TraducirIngrediente(
                        producto.ProductCode,
                        producto.ProductName);
                    string unidad = CatalogoTraducciones.TraducirUnidad(
                        null,
                        producto.UnitName);
                    e.Value = $"{producto.ProductCode} - {nombre} ({unidad})";
                }
            };
            cmbProducto.DataSource = productos.ToList();
            var nudCantidad = new NumericUpDown { Dock = DockStyle.Fill, DecimalPlaces = 4, Minimum = 0.0001m, Maximum = 99999999.9999m, Value = 1m, ThousandsSeparator = true };
            var nudCosto = new NumericUpDown { Dock = DockStyle.Fill, DecimalPlaces = 4, Minimum = 0m, Maximum = 999999m, Value = 0m, ThousandsSeparator = true };
            var txtLote = new TextBox { Dock = DockStyle.Fill, MaxLength = 50, PlaceholderText = "Opcional" };
            var dtpVencimiento = new DateTimePicker { Dock = DockStyle.Fill, Format = DateTimePickerFormat.Short, ShowCheckBox = true, Checked = false };
            var txtNotas = new TextBox { Dock = DockStyle.Fill, MaxLength = 250, PlaceholderText = "Observaciones (opcional)" };
            var botones = new FlowLayoutPanel { Dock = DockStyle.Fill, FlowDirection = FlowDirection.RightToLeft, WrapContents = false };
            var btnAceptar = new Button { Text = "✓ Agregar", Width = 115, Height = 34, BackColor = Color.FromArgb(8, 126, 164), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, DialogResult = DialogResult.OK };
            var btnCancelar = new Button { Text = "✕ Cancelar", Width = 115, Height = 34, DialogResult = DialogResult.Cancel, FlatStyle = FlatStyle.Flat };
            botones.Controls.Add(btnAceptar);
            botones.Controls.Add(btnCancelar);

            void AddRow(int row, string label, Control control)
            {
                layout.Controls.Add(new Label { Text = label, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft }, 0, row);
                layout.Controls.Add(control, 1, row);
            }
            AddRow(0, "Ingrediente", cmbProducto);
            AddRow(1, "Cantidad", nudCantidad);
            AddRow(2, "Costo unitario (C$)", nudCosto);
            AddRow(3, "Código de lote", txtLote);
            AddRow(4, "Vencimiento", dtpVencimiento);
            AddRow(5, "Observaciones", txtNotas);
            layout.Controls.Add(botones, 0, 6);
            layout.SetColumnSpan(botones, 2);
            dialog.Controls.Add(layout);
            dialog.AcceptButton = btnAceptar;
            dialog.CancelButton = btnCancelar;

            if (dialog.ShowDialog(this) != DialogResult.OK || cmbProducto.SelectedItem is not ProductoCompraDto producto)
                return null;

            decimal cantidad = nudCantidad.Value;
            decimal costo = nudCosto.Value;
            return new DetalleCompraCapturaDto
            {
                ProductId = producto.ProductId,
                ProductCode = producto.ProductCode,
                ProductName = producto.ProductName,
                UnitName = producto.UnitName,
                Quantity = cantidad,
                UnitCost = costo,
                Subtotal = Math.Round(cantidad * costo, 2, MidpointRounding.AwayFromZero),
                ReceivedQuantity = 0m,
                LotCode = string.IsNullOrWhiteSpace(txtLote.Text) ? null : txtLote.Text.Trim(),
                ExpirationDate = dtpVencimiento.Checked ? DateOnly.FromDateTime(dtpVencimiento.Value) : null,
                Notes = string.IsNullOrWhiteSpace(txtNotas.Text) ? null : txtNotas.Text.Trim()
            };
        }

        public void MostrarMensaje(string mensaje, bool esError = false)
        {
            FrmMessageBox.Show(
                mensaje,
                "Compras",
                esError ? MessageType.Error : MessageType.Information,
                this);
        }
    }
}
