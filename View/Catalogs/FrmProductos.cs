using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ocean_Desk_dv.Models.DTOs;
using Ocean_Desk_dv.Presenters;
using Ocean_Desk_dv.View.Interfaces;
using Ocean_Desk_dv.View.MessageBox;

namespace Ocean_Desk_dv.View.Catalogs
{
    /// <summary>Vista del catálogo de productos y de la composición de sus recetas.</summary>
    public partial class FrmProductos : Form, IProductosView
    {
        private readonly BindingSource _productos = new();
        private readonly BindingSource _categorias = new();
        private readonly BindingSource _unidades = new();
        private readonly BindingSource _productosReceta = new();
        private readonly BindingSource _ingredientes = new();
        private readonly BindingSource _detalles = new();
        private ComboBox cmbIngrediente = null!;
        private NumericUpDown nudCantidadIngrediente = null!;
        private TextBox txtNotasIngrediente = null!;
        private TextBox txtInstruccionesReceta = null!;
        private ProductosPresenter? _presenter;
        private int? _productoEnEdicionId;
        private bool _actualizando;

        public event EventHandler? BusquedaCambiada;
        public event EventHandler? NuevoProductoSolicitado;
        public event EventHandler? EditarProductoSolicitado;
        public event EventHandler? CambiarEstadoProductoSolicitado;
        public event EventHandler? LimpiarProductoSolicitado;
        public event EventHandler? GuardarProductoSolicitado;
        public event EventHandler? ProductoSeleccionadoCambiado;
        public event EventHandler? ProductoRecetaSeleccionadoCambiado;
        public event EventHandler? AgregarIngredienteSolicitado;
        public event EventHandler? EditarIngredienteSolicitado;
        public event EventHandler? QuitarIngredienteSolicitado;
        public event EventHandler? GuardarRecetaSolicitado;

        public FrmProductos()
        {
            InitializeComponent();
            foreach (Label lbl in new[] { lblCodigo, lblNombre, lblCategoria, lblDescripcion, lblPrecio, lblUnidad, lblStockMinimo })
                lbl.ForeColor = ColorTranslator.FromHtml("#6F7780");

            AplicarEstiloGrid(dgvProductos);
            AplicarEstiloGrid(dgvReceta);
            PrepararEnlaces();
            CrearControlesReceta();
            ConectarEventos();

        }

        /// <summary>Asocia el Presenter y ejecuta la carga inicial de datos.</summary>
        public void VincularPresenter(ProductosPresenter presenter)
        {
            _presenter = presenter ?? throw new ArgumentNullException(nameof(presenter));
            _presenter.Inicializar();
        }

        public string TextoBusqueda => txtBuscarProducto.Text;
        public int? ProductoSeleccionadoId => (dgvProductos.CurrentRow?.DataBoundItem as ProductoCatalogoDto)?.ProductId;
        public int? ProductoRecetaSeleccionadoId => cmbProductoReceta.SelectedValue is int id && id > 0 ? id : null;
        public string InstruccionesReceta => txtInstruccionesReceta.Text.Trim();
        public int? IngredienteSeleccionadoId => cmbIngrediente.SelectedValue is int id && id > 0 ? id : null;
        public decimal CantidadIngrediente => nudCantidadIngrediente.Value;
        public string? NotasIngrediente => string.IsNullOrWhiteSpace(txtNotasIngrediente.Text) ? null : txtNotasIngrediente.Text.Trim();
        public int? DetalleIngredienteSeleccionadoId => (dgvReceta.CurrentRow?.DataBoundItem as DetalleRecetaDto)?.IngredientProductId;
        public IReadOnlyList<DetalleRecetaDto> DetallesRecetaActuales => _detalles.List.Cast<object>().OfType<DetalleRecetaDto>().ToArray();

        /// <summary>Convierte los campos del formulario en el DTO que usa el repositorio.</summary>
        public GuardarProductoDto DatosFormularioProducto => new GuardarProductoDto
        {
            ProductId = _productoEnEdicionId,
            ProductCode = txtCodigo.Text.Trim(),
            ProductName = txtNombre.Text.Trim(),
            Description = string.IsNullOrWhiteSpace(txtDescripcion.Text) ? null : txtDescripcion.Text.Trim(),
            ProductCategoryId = cmbCategoria.SelectedValue is int categoriaId ? categoriaId : 0,
            UnitPrice = nudPrecio.Value,
            UnitOfMeasureId = cmbUnidad.SelectedValue is int unidadId ? unidadId : null,
            IsAvailable = chkDisponible.Checked,
            IsActive = chkActivo.Checked
        };

        private void PrepararEnlaces()
        {
            dgvProductos.AutoGenerateColumns = false;
            dgvProductos.DataSource = _productos;
            dgvReceta.AutoGenerateColumns = false;
            dgvReceta.DataSource = _detalles;
            cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoria.DisplayMember = nameof(CategoriaProductoDto.CategoryName);
            cmbCategoria.ValueMember = nameof(CategoriaProductoDto.ProductCategoryId);
            cmbCategoria.DataSource = _categorias;
            cmbUnidad.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUnidad.DisplayMember = nameof(UnidadMedidaDto.UnitName);
            cmbUnidad.ValueMember = nameof(UnidadMedidaDto.UnitOfMeasureId);
            cmbUnidad.DataSource = _unidades;
            cmbProductoReceta.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProductoReceta.DisplayMember = nameof(ProductoRecetaSelectorDto.TextoMostrar);
            cmbProductoReceta.ValueMember = nameof(ProductoRecetaSelectorDto.ProductId);
            cmbProductoReceta.DataSource = _productosReceta;
        }

        /// <summary>Añade los campos de receta que no existen en el diseñador original.</summary>
        private void CrearControlesReceta()
        {
            pnlSeleccionReceta.SuspendLayout();
            pnlSeleccionReceta.Height = 178;
            cmbProductoReceta.Dock = DockStyle.None;
            cmbProductoReceta.Location = new Point(30, 8);
            cmbProductoReceta.Size = new Size(Math.Max(260, pnlSeleccionReceta.ClientSize.Width - 60), 28);
            cmbProductoReceta.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlSeleccionReceta.Controls.Add(Etiqueta("Ingrediente", 30, 43, 100));
            cmbIngrediente = new ComboBox { Name = "cmbIngrediente", DropDownStyle = ComboBoxStyle.DropDownList, Font = new Font("Century Gothic", 9F), Location = new Point(30, 64), Size = new Size(250, 27) };
            cmbIngrediente.DisplayMember = nameof(IngredienteSelectorDto.TextoMostrar);
            cmbIngrediente.ValueMember = nameof(IngredienteSelectorDto.ProductId);
            cmbIngrediente.DataSource = _ingredientes;
            pnlSeleccionReceta.Controls.Add(cmbIngrediente);
            pnlSeleccionReceta.Controls.Add(Etiqueta("Cantidad", 294, 43, 100));
            nudCantidadIngrediente = new NumericUpDown { Name = "nudCantidadIngrediente", DecimalPlaces = 4, Minimum = 0.0001M, Maximum = 999999999M, Increment = 0.1M, Font = new Font("Century Gothic", 9F), Location = new Point(294, 64), Size = new Size(100, 27) };
            pnlSeleccionReceta.Controls.Add(nudCantidadIngrediente);
            pnlSeleccionReceta.Controls.Add(Etiqueta("Notas (opcional)", 408, 43, 140));
            txtNotasIngrediente = new TextBox { Name = "txtNotasIngrediente", Font = new Font("Century Gothic", 9F), Location = new Point(408, 64), Size = new Size(Math.Max(100, pnlSeleccionReceta.ClientSize.Width - 438), 27), Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right };
            pnlSeleccionReceta.Controls.Add(txtNotasIngrediente);
            pnlSeleccionReceta.Controls.Add(Etiqueta("Instrucciones de preparación", 30, 99, 220));
            txtInstruccionesReceta = new TextBox { Name = "txtInstruccionesReceta", Multiline = true, ScrollBars = ScrollBars.Vertical, MaxLength = 1000, Font = new Font("Century Gothic", 9F), Location = new Point(30, 120), Size = new Size(Math.Max(260, pnlSeleccionReceta.ClientSize.Width - 60), 48), Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right };
            pnlSeleccionReceta.Controls.Add(txtInstruccionesReceta);
            pnlSeleccionReceta.ResumeLayout();
        }

        private static Label Etiqueta(string texto, int x, int y, int ancho) => new Label { Text = texto, AutoSize = false, Location = new Point(x, y), Size = new Size(ancho, 19), Font = new Font("Century Gothic", 8.5F, FontStyle.Bold), ForeColor = Color.FromArgb(8, 31, 63) };

        private void ConectarEventos()
        {
            txtBuscarProducto.TextChanged += (_, _) => BusquedaCambiada?.Invoke(this, EventArgs.Empty);
            btnNuevoProducto.Click += (_, _) => NuevoProductoSolicitado?.Invoke(this, EventArgs.Empty);
            btnEditarProducto.Click += (_, _) => EditarProductoSolicitado?.Invoke(this, EventArgs.Empty);
            btnCambiarEstado.Click += (_, _) => CambiarEstadoProductoSolicitado?.Invoke(this, EventArgs.Empty);
            btnLimpiarProducto.Click += (_, _) => LimpiarProductoSolicitado?.Invoke(this, EventArgs.Empty);
            btnGuardarProducto.Click += (_, _) => GuardarProductoSolicitado?.Invoke(this, EventArgs.Empty);
            dgvProductos.SelectionChanged += (_, _) => ProductoSeleccionadoCambiado?.Invoke(this, EventArgs.Empty);
            cmbProductoReceta.SelectedValueChanged += (_, _) => { if (!_actualizando) ProductoRecetaSeleccionadoCambiado?.Invoke(this, EventArgs.Empty); };
            btnAgregarIngrediente.Click += (_, _) => AgregarIngredienteSolicitado?.Invoke(this, EventArgs.Empty);
            btnEditarIngrediente.Click += (_, _) => EditarIngredienteSolicitado?.Invoke(this, EventArgs.Empty);
            btnQuitarIngrediente.Click += (_, _) => QuitarIngredienteSolicitado?.Invoke(this, EventArgs.Empty);
            btnGuardarReceta.Click += (_, _) => GuardarRecetaSolicitado?.Invoke(this, EventArgs.Empty);
            dgvReceta.SelectionChanged += (_, _) => CargarDetalleSeleccionadoEnCampos();
        }

        private void CargarDetalleSeleccionadoEnCampos()
        {
            if (dgvReceta.CurrentRow?.DataBoundItem is not DetalleRecetaDto detalle) return;
            _actualizando = true;
            try
            {
                cmbIngrediente.SelectedValue = detalle.IngredientProductId;
                nudCantidadIngrediente.Value = Math.Max(nudCantidadIngrediente.Minimum, Math.Min(nudCantidadIngrediente.Maximum, detalle.Quantity));
                txtNotasIngrediente.Text = detalle.Notes ?? string.Empty;
            }
            finally { _actualizando = false; }
        }

        private void AplicarEstiloGrid(DataGridView dgv)
        {
            dgv.EnableHeadersVisualStyles = false;
            dgv.BackgroundColor = Color.White;
            dgv.GridColor = Color.FromArgb(230, 234, 238);

            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.FromArgb(8, 31, 63);
            dgv.DefaultCellStyle.Font = new Font("Century Gothic", 9F, FontStyle.Regular);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 234, 240);
            dgv.DefaultCellStyle.SelectionForeColor = Color.FromArgb(8, 31, 63);

            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            dgv.AlternatingRowsDefaultCellStyle.Font = new Font("Century Gothic", 9F, FontStyle.Regular);

            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(8, 31, 63);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 9F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(6, 0, 0, 0);
        }

        public void MostrarProductos(IReadOnlyList<ProductoCatalogoDto> productos) { _productos.DataSource = productos.ToList(); }
        public void MostrarCategorias(IReadOnlyList<CategoriaProductoDto> categorias) { _categorias.DataSource = categorias.ToList(); if (cmbCategoria.Items.Count > 0) cmbCategoria.SelectedIndex = 0; }
        public void MostrarUnidades(IReadOnlyList<UnidadMedidaDto> unidades) { _unidades.DataSource = unidades.ToList(); if (cmbUnidad.Items.Count > 0) cmbUnidad.SelectedIndex = 0; }
        public void MostrarProductosParaReceta(IReadOnlyList<ProductoRecetaSelectorDto> productos) { _actualizando = true; try { _productosReceta.DataSource = productos.ToList(); if (cmbProductoReceta.Items.Count > 0) cmbProductoReceta.SelectedIndex = 0; } finally { _actualizando = false; } }
        public void MostrarIngredientesDisponibles(IReadOnlyList<IngredienteSelectorDto> ingredientes) { _ingredientes.DataSource = ingredientes.ToList(); }

        /// <summary>Coloca los datos del producto elegido en los campos para edición.</summary>
        public void CargarProductoEnFormulario(ProductoCatalogoDto p)
        {
            _productoEnEdicionId = p.ProductId;
            txtCodigo.Text = p.ProductCode; txtNombre.Text = p.ProductName; txtDescripcion.Text = p.Description ?? string.Empty;
            SeleccionarValor(cmbCategoria, p.ProductCategoryId); SeleccionarValor(cmbUnidad, p.UnitOfMeasureId);
            nudPrecio.Value = Math.Max(nudPrecio.Minimum, Math.Min(nudPrecio.Maximum, p.UnitPrice));
            chkDisponible.Checked = p.IsAvailable; chkActivo.Checked = p.IsActive;
        }

        /// <summary>Limpia los campos de producto y prepara el registro de uno nuevo.</summary>
        public void LimpiarFormularioProducto()
        {
            _productoEnEdicionId = null; txtCodigo.Clear(); txtNombre.Clear(); txtDescripcion.Clear();
            if (cmbCategoria.Items.Count > 0) cmbCategoria.SelectedIndex = 0;
            if (cmbUnidad.Items.Count > 0) cmbUnidad.SelectedIndex = 0;
            nudPrecio.Value = nudPrecio.Minimum; nudStockMinimo.Value = nudStockMinimo.Minimum;
            chkDisponible.Checked = true; chkActivo.Checked = true; txtCodigo.Focus();
        }

        private static void SeleccionarValor(ComboBox combo, int? valor) { if (valor.HasValue && combo.Items.Count > 0) combo.SelectedValue = valor.Value; else if (combo.Items.Count > 0) combo.SelectedIndex = 0; }
        public void MostrarDetallesReceta(IReadOnlyList<DetalleRecetaDto> detalles) { _detalles.DataSource = detalles.ToList(); txtNotasIngrediente.Clear(); nudCantidadIngrediente.Value = nudCantidadIngrediente.Minimum; }
        public void MostrarInstruccionesReceta(string instrucciones) { txtInstruccionesReceta.Text = instrucciones ?? string.Empty; }
        public void MostrarMensaje(string mensaje, string titulo = "Productos", bool esError = false) => System.Windows.Forms.MessageBox.Show(this, mensaje, titulo, System.Windows.Forms.MessageBoxButtons.OK, esError ? System.Windows.Forms.MessageBoxIcon.Warning : System.Windows.Forms.MessageBoxIcon.Information);

        /// <summary>Traduce los valores booleanos de la tabla a etiquetas legibles.</summary>
        private void dgvProductos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value is not bool valor) return;
            string columna = dgvProductos.Columns[e.ColumnIndex].Name;
            if (columna == "colDisponible") { e.Value = valor ? "Sí" : "No"; e.FormattingApplied = true; }
            else if (columna == "colActivo") { e.Value = valor ? "Activo" : "Inactivo"; e.CellStyle.ForeColor = valor ? Color.FromArgb(42, 122, 82) : Color.FromArgb(163, 61, 61); e.FormattingApplied = true; }
        }
    }
}

