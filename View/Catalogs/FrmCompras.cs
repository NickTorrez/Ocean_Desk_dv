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

        private int _filaRedimensionandoDetalle = -1;
        private int _yInicioRedimensionDetalle;
        private int _alturaInicioRedimensionDetalle;
        private bool _redimensionandoDetalle;

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
            Color azulOcean = Color.FromArgb(8, 31, 63);
            Color fondoAlterno = Color.FromArgb(248, 250, 252);
            Color fondoSeleccion = Color.FromArgb(224, 234, 240);
            Color colorBorde = Color.FromArgb(220, 225, 230);

            Font fuenteFilas = new Font("Century Gothic", 10F, FontStyle.Regular);

            Font fuenteEncabezados = new Font("Century Gothic", 10F, FontStyle.Bold);

            // =========================================================
            // TABLA PRINCIPAL: COMPRAS
            // =========================================================

            dgvCompras.AutoGenerateColumns = false;
            dgvCompras.ReadOnly = true;
            dgvCompras.AllowUserToAddRows = false;
            dgvCompras.AllowUserToDeleteRows = false;
            dgvCompras.AllowUserToResizeColumns = false;
            dgvCompras.AllowUserToResizeRows = false;
            dgvCompras.MultiSelect = false;
            dgvCompras.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvCompras.RowHeadersVisible = false;
            dgvCompras.EnableHeadersVisualStyles = false;
            dgvCompras.BackgroundColor = Color.White;
            dgvCompras.BorderStyle = BorderStyle.None;
            dgvCompras.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;dgvCompras.GridColor = colorBorde;

            // Encabezado.
            dgvCompras.ColumnHeadersDefaultCellStyle.BackColor =
                azulOcean;
            dgvCompras.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;
            dgvCompras.ColumnHeadersDefaultCellStyle.Font =
                fuenteEncabezados;
            dgvCompras.ColumnHeadersDefaultCellStyle.SelectionBackColor =
                azulOcean;
            dgvCompras.ColumnHeadersDefaultCellStyle.SelectionForeColor =
                Color.White;
            dgvCompras.ColumnHeadersDefaultCellStyle.WrapMode =
                DataGridViewTriState.True;

            // Filas normales.
            dgvCompras.DefaultCellStyle.BackColor = Color.White;
            dgvCompras.DefaultCellStyle.ForeColor = azulOcean;
            dgvCompras.DefaultCellStyle.Font = fuenteFilas;
            dgvCompras.DefaultCellStyle.SelectionBackColor =
                fondoSeleccion;
            dgvCompras.DefaultCellStyle.SelectionForeColor =
                azulOcean;
            dgvCompras.DefaultCellStyle.WrapMode =
                DataGridViewTriState.False;

            // Filas alternas: sombreado muy suave.
            dgvCompras.AlternatingRowsDefaultCellStyle.BackColor =
                fondoAlterno;
            dgvCompras.AlternatingRowsDefaultCellStyle.ForeColor =
                azulOcean;
            dgvCompras.AlternatingRowsDefaultCellStyle.Font =
                fuenteFilas;
            dgvCompras.AlternatingRowsDefaultCellStyle.SelectionBackColor =
                fondoSeleccion;
            dgvCompras.AlternatingRowsDefaultCellStyle.SelectionForeColor =
                azulOcean;

            // Evitar colores y fuentes heredados del diseñador
            // en las celdas de las columnas.
            foreach (DataGridViewColumn columna in dgvCompras.Columns)
            {
                columna.DefaultCellStyle.BackColor = Color.Empty;
                columna.DefaultCellStyle.ForeColor = azulOcean;
                columna.DefaultCellStyle.Font = fuenteFilas;
                columna.DefaultCellStyle.SelectionBackColor =
                    fondoSeleccion;
                columna.DefaultCellStyle.SelectionForeColor =
                    azulOcean;
            }

            // Conservar los formatos de los datos.
            colTotalCompra.DefaultCellStyle.Format = "C$ #,##0.00";
            colFechaCompra.DefaultCellStyle.Format = "dd/MM/yyyy";
            colRecibidaCompra.DefaultCellStyle.Format = "dd/MM/yyyy";

            // =========================================================
            // TABLA SECUNDARIA: DETALLE DE COMPRA
            // =========================================================

            dgvDetalleCompra.AutoGenerateColumns = false;
            dgvDetalleCompra.ReadOnly = true;
            dgvDetalleCompra.AllowUserToAddRows = false;
            dgvDetalleCompra.AllowUserToDeleteRows = false;
            dgvDetalleCompra.AllowUserToResizeColumns = true;

            // Ocultar por completo la franja que mostraba la flecha
            // y el indicador de selección de fila.
            dgvDetalleCompra.RowHeadersVisible = false;

            // El redimensionamiento de filas se controlará mediante
            // el borde inferior de las celdas, sin mostrar encabezados.
            dgvDetalleCompra.AllowUserToResizeRows = false;
            dgvDetalleCompra.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            dgvDetalleCompra.MultiSelect = false;
            dgvDetalleCompra.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalleCompra.BackgroundColor = Color.White;
            dgvDetalleCompra.BorderStyle = BorderStyle.None;
            dgvDetalleCompra.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvDetalleCompra.GridColor = colorBorde;

            // Mantener los formatos numéricos.
            colCantidadCompra.DefaultCellStyle.Format = "#,##0.####";
            colCostoCompra.DefaultCellStyle.Format = "C$ #,##0.0000";
            colSubtotalCompra.DefaultCellStyle.Format = "C$ #,##0.00";
            colRecepcionCompra.HeaderText = "Recibido";
            colRecepcionCompra.DefaultCellStyle.Format = "#,##0.####";

            // Permitir que las observaciones ocupen varias líneas
            // cuando el usuario aumente la altura de la fila.
            colObservacionCompra.DefaultCellStyle.WrapMode =
                DataGridViewTriState.True;

            // Conservar la traducción de los productos y las unidades.
            dgvDetalleCompra.CellFormatting -=
                DgvDetalleCompra_CellFormatting;
            dgvDetalleCompra.CellFormatting +=
                DgvDetalleCompra_CellFormatting;

            // Eventos para redimensionar filas sin encabezados visibles.
            dgvDetalleCompra.MouseDown -= DgvDetalleCompra_MouseDown;
            dgvDetalleCompra.MouseDown += DgvDetalleCompra_MouseDown;

            dgvDetalleCompra.MouseMove -= DgvDetalleCompra_MouseMove;
            dgvDetalleCompra.MouseMove += DgvDetalleCompra_MouseMove;

            dgvDetalleCompra.MouseUp -= DgvDetalleCompra_MouseUp;
            dgvDetalleCompra.MouseUp += DgvDetalleCompra_MouseUp;

            dgvDetalleCompra.MouseLeave -= DgvDetalleCompra_MouseLeave;
            dgvDetalleCompra.MouseLeave += DgvDetalleCompra_MouseLeave;
        }

        private void DgvDetalleCompra_DataBindingComplete(
            object? sender,
            DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow fila in dgvDetalleCompra.Rows)
            {
                fila.Resizable = DataGridViewTriState.True;
            }
        }

        /// <summary>
        /// Identifica si el cursor está cerca del borde inferior
        /// de alguna fila visible de la tabla de detalles.
        /// </summary>
        private int ObtenerFilaEnBordeInferior(int y)
        {
            const int tolerancia = 4;

            for (int i = 0; i < dgvDetalleCompra.Rows.Count; i++)
            {
                DataGridViewRow fila = dgvDetalleCompra.Rows[i];

                if (!fila.Visible)
                    continue;

                Rectangle limites =
                    dgvDetalleCompra.GetRowDisplayRectangle(i, false);

                if (limites.Height <= 0)
                    continue;

                if (Math.Abs(y - (limites.Bottom - 1)) <= tolerancia)
                    return i;
            }

            return -1;
        }

        /// <summary>
        /// Inicia el redimensionamiento al pulsar el borde inferior
        /// de una fila.
        /// </summary>
        private void DgvDetalleCompra_MouseDown(
            object? sender,
            MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            int fila = ObtenerFilaEnBordeInferior(e.Y);

            if (fila < 0)
                return;

            _filaRedimensionandoDetalle = fila;
            _yInicioRedimensionDetalle = e.Y;
            _alturaInicioRedimensionDetalle =
                dgvDetalleCompra.Rows[fila].Height;

            _redimensionandoDetalle = true;
            dgvDetalleCompra.Cursor = Cursors.HSplit;
            dgvDetalleCompra.Capture = true;
        }

        /// <summary>
        /// Cambia la altura de la fila mientras el usuario arrastra
        /// su borde inferior.
        /// </summary>
        private void DgvDetalleCompra_MouseMove(
            object? sender,
            MouseEventArgs e)
        {
            if (_redimensionandoDetalle &&
                _filaRedimensionandoDetalle >= 0 &&
                _filaRedimensionandoDetalle <
                    dgvDetalleCompra.Rows.Count)
            {
                int diferencia = e.Y - _yInicioRedimensionDetalle;

                int nuevaAltura = Math.Clamp(
                    _alturaInicioRedimensionDetalle + diferencia,
                    28,
                    240);

                dgvDetalleCompra
                    .Rows[_filaRedimensionandoDetalle]
                    .Height = nuevaAltura;

                return;
            }

            // Mostrar el cursor apropiado al acercarse al borde.
            dgvDetalleCompra.Cursor =
                ObtenerFilaEnBordeInferior(e.Y) >= 0
                    ? Cursors.HSplit
                    : Cursors.Default;
        }

        /// <summary>
        /// Termina el arrastre y devuelve el control del cursor.
        /// </summary>
        private void DgvDetalleCompra_MouseUp(
            object? sender,
            MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            _redimensionandoDetalle = false;
            _filaRedimensionandoDetalle = -1;

            dgvDetalleCompra.Capture = false;
            dgvDetalleCompra.Cursor = Cursors.Default;
        }

        private void DgvDetalleCompra_MouseLeave(
            object? sender,
            EventArgs e)
        {
            if (!_redimensionandoDetalle)
                dgvDetalleCompra.Cursor = Cursors.Default;
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

        /// <summary>
        /// Limpia los datos de la compra mostrada en el panel derecho
        /// cuando no hay ninguna compra seleccionada.
        /// </summary>
        private void LimpiarPanelCompra()
        {
            bool cargandoAnterior = _cargandoDatos;
            _cargandoDatos = true;

            try
            {
                // Ningún proveedor queda seleccionado.
                cmbProveedorCompra.SelectedIndex = -1;

                // Dejar la fecha sin seleccionar.
                // Se activará de nuevo cuando se cree una compra.
                dtpFechaCompra.ShowCheckBox = true;
                dtpFechaCompra.Checked = false;

                txtDocumentoCompra.Clear();
                txtNotasCompra.Clear();

                // Quitar los detalles de la compra anterior.
                dgvDetalleCompra.DataSource = null;
                dgvDetalleCompra.ClearSelection();

                // Eliminar también cualquier detalle temporal.
                _detallesCapturados.Clear();

                lblSubtotalCompra.Text =
                    $"Subtotal: {FormatearCordobas(0m)}";

                lblTotalCompra.Text =
                    $"Total: {FormatearCordobas(0m)}";

                // No se puede recibir ni cancelar una compra
                // si todavía no se ha seleccionado ninguna.
                btnRegistrarRecepcion.Enabled = false;
                btnCancelarCompra.Enabled = false;
            }
            finally
            {
                _cargandoDatos = cargandoAnterior;
            }
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
                // La lista está disponible, pero no seleccionar un proveedor
                // automáticamente al abrir el módulo.
                cmbProveedorCompra.SelectedIndex = -1;
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

                // Evitar que la primera compra se seleccione por defecto.
                dgvCompras.CurrentCell = null;
                dgvCompras.ClearSelection();
            }
            finally
            {
                _cargandoDatos = false;
            }

            // No borrar el borrador mientras se captura una compra nueva.
            if (!_capturandoCompraNueva)
            {
                LimpiarPanelCompra();
            }
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

        public DetalleCompraCapturaDto? SolicitarDetalleCompra(
            IReadOnlyList<ProductoCompraDto> productos,
            IReadOnlyList<UnidadMedidaDto> unidades)
        {
            using var dialog =
                new global::Ocean_Desk_dv.View.MessageBox
                    .FrmAgregarIngredienteCompra(productos, unidades);

            return dialog.ShowDialog(this) == DialogResult.OK
                ? dialog.Resultado
                : null;
        }

        public void MostrarMensaje(string mensaje, bool esError = false)
        {
            FrmMessageBox.Show(
                mensaje,
                "Compras",
                esError ? MessageType.Error : MessageType.Information,
                this);
        }

        private void tlpValores_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
