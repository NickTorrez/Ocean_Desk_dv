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
using Ocean_Desk_dv.UI.MessageBox;
using Ocean_Desk_dv.View.MessageBox;
using Ocean_Desk_dv.View.Localization;

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

        private ProductosPresenter? _presenter;
        private int? _productoEnEdicionId;
        private int? _ingredienteSeleccionadoId;
        private decimal _cantidadIngrediente;
        private string? _notasIngrediente;
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
            OcultarStockMinimoEnCatalogo();

            foreach (Label lbl in new[]
            {
                lblCodigo,
                lblNombre,
                lblCategoria,
                lblDescripcion,
                lblPrecio,
                lblUnidad
            })
            {
                lbl.ForeColor = ColorTranslator.FromHtml("#6F7780");
            }

            // Libera el Presenter y su repositorio cuando se destruye la vista.
            Disposed += (_, _) =>
            {
                _presenter?.Dispose();
                _presenter = null;
            };

            ConfigurarMascaraCodigo();

            AplicarEstiloGrid(dgvProductos);
            AplicarEstiloGrid(dgvReceta);

            // Mostrar hasta cuatro decimales, sin rellenar ceros innecesarios.
            colCantidadReceta.DefaultCellStyle.Format = "#,##0.####";

            PrepararEnlaces();

            // Configura cómo se seleccionan las líneas de receta.
            ConfigurarComportamientoSeleccionReceta();

            ConectarEventos();
            ConfigurarEstadoInicialProducto();

            // Los botones comienzan en el estado que corresponda
            // a la selección actual.
            ActualizarEstadoBotonesReceta();

            ActualizarEstadoBarraSuperior();
        }

        /// <summary>
        /// Deshabilita las acciones del catálogo cuando se selecciona Receta,
        /// manteniendo disponible el botón Nuevo.
        /// </summary>
        private void ActualizarEstadoBarraSuperior()
        {
            bool esReceta = Tcproductos.SelectedTab == tpReceta;

            // El botón Nuevo debe permanecer disponible en ambas pestañas.
            pnlHeaderNuevo.Enabled = true;
            btnNuevoProducto.Enabled = true;

            // Se bloquean las demás acciones de la barra.
            pnlHeaderEditar.Enabled = !esReceta;
            pnlHeaderCambiar.Enabled = !esReceta;
            pnlBuscar.Enabled = !esReceta;
            pnlLabelBuscar.Enabled = !esReceta;
        }

        /// <summary>
        /// El stock mínimo se configura desde Inventario, no desde Productos.
        /// Se colapsan sus dos filas para no dejar espacio vacío en el formulario.
        /// </summary>
        private void OcultarStockMinimoEnCatalogo()
        {
            pnlStockMinimo.Visible = false;
            pnlInputStock.Visible = false;

            // Son las filas 12 y 13 del TableLayoutPanel actual.
            if (tlpInputProducto.RowStyles.Count > 13)
            {
                tlpInputProducto.RowStyles[12].SizeType =
                    SizeType.Absolute;
                tlpInputProducto.RowStyles[12].Height = 0;

                tlpInputProducto.RowStyles[13].SizeType =
                    SizeType.Absolute;
                tlpInputProducto.RowStyles[13].Height = 0;
            }
        }

        /// <summary>
        /// Configura la selección de filas y el aspecto visual de los botones
        /// que administran los ingredientes de la receta.
        /// </summary>
        private void ConfigurarComportamientoSeleccionReceta()
        {
            // La tabla se utiliza para consultar las líneas de receta.
            // Los cambios se realizan mediante el formulario modal.
            dgvReceta.ReadOnly = true;

            // El usuario selecciona una fila completa por vez.
            dgvReceta.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReceta.MultiSelect = false;

            // Limpia cualquier selección inicial.
            dgvReceta.ClearSelection();

            // Utiliza un estilo consistente para Agregar y Editar.
            foreach (Button boton in new[]
            {
                btnAgregarIngrediente,
                btnEditarIngrediente
            })
            {
                boton.FlatStyle = FlatStyle.Flat;
                boton.UseVisualStyleBackColor = false;

                boton.BackColor = Color.FromArgb(238, 243, 247);
                boton.ForeColor = Color.FromArgb(8, 31, 63);

                boton.FlatAppearance.BorderSize = 0;

                // Evita que el color del botón cambie de forma inesperada
                // al pasar el cursor o presionarlo.
                boton.FlatAppearance.MouseOverBackColor =
                    Color.FromArgb(220, 231, 239);

                boton.FlatAppearance.MouseDownBackColor =
                    Color.FromArgb(207, 220, 231);
            }

            // Editar, Quitar y Guardar dependen de la selección y del contenido.
            btnEditarIngrediente.Enabled = false;
            btnQuitarIngrediente.Enabled = false;
            btnGuardarReceta.Enabled = false;
        }

        /// <summary>
        /// Habilita o deshabilita los botones según el producto seleccionado,
        /// los ingredientes disponibles y la selección de la tabla.
        /// </summary>
        private void ActualizarEstadoBotonesReceta()
        {
            bool productoSeleccionado =
                ProductoRecetaSeleccionadoId.HasValue;

            bool hayIngredientesDisponibles =
                _ingredientes.Count > 0;

            bool filaSeleccionada =
                dgvReceta.SelectedRows.Count > 0 &&
                dgvReceta.SelectedRows[0].DataBoundItem
                    is DetalleRecetaDto;

            bool hayDetalles =
                _detalles.Count > 0;

            // Agregar depende de que exista un producto y haya ingredientes.
            btnAgregarIngrediente.Enabled =
                productoSeleccionado &&
                hayIngredientesDisponibles;

            // Editar y Quitar requieren una fila seleccionada.
            btnEditarIngrediente.Enabled =
                productoSeleccionado &&
                filaSeleccionada;

            btnQuitarIngrediente.Enabled =
                productoSeleccionado &&
                filaSeleccionada;

            // No se puede guardar una receta vacía.
            btnGuardarReceta.Enabled =
                productoSeleccionado &&
                hayDetalles;
        }

        /// <summary>
        /// Configura el formato del código para aceptar tres letras,
        /// un guion y tres dígitos obligatorios.
        /// </summary>
        private void ConfigurarMascaraCodigo()
        {
            txtCodigo.Mask = "LLL-000";
            txtCodigo.PromptChar = '#';
            txtCodigo.TextMaskFormat = MaskFormat.IncludeLiterals;

            txtCodigo.KeyPress -= TxtCodigo_KeyPress;
            txtCodigo.KeyPress += TxtCodigo_KeyPress;

            txtCodigo.HidePromptOnLeave = false;
        }

        /// <summary>
        /// Convierte las letras ingresadas en el código a mayúsculas.
        /// </summary>
        private void TxtCodigo_KeyPress(object? sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpperInvariant(e.KeyChar);
        }

        /// <summary>
        /// Prefijos permitidos para los códigos de productos de Ocean Desk.
        /// Los prefijos propuestos para futuras categorías deben coordinarse
        /// con las categorías y reglas de negocio antes de utilizarlos.
        /// Utilizar HashSet facilita comprobar si un prefijo está permitido y evita duplicados.
        /// </summary>
        private static readonly HashSet<string> PrefijosProductoPermitidos = new(StringComparer.OrdinalIgnoreCase)
        {
            "PRD", // Productos genéricos o terminados.
            "CEV", // Ceviches.
            "BEB", // Bebidas.
            "ENT", // Entradas y acompañamientos.
            "MAR", // Mariscos.
            "PES", // Pescados.
            "CAR", // Carnes y proteínas terrestres.
            "ENS", // Ensaladas.
            "POS", // Postres.
            "SOP", // Sopas y caldos.
            "COM", // Combos y promociones.
            "SAL", // Salsas y aderezos.
            "INS", // Insumos generales de cocina.
            "CON", // Condimentos y especias.
            "PAN", // Panadería.
            "LAC", // Lácteos.
            "ING" // Ingredientes identificados para el control de inventario.
        };


        /// <summary>
        /// Deshabilita los controles de captura al iniciar el formulario para evitar
        /// modificaciones hasta que el usuario elija Nuevo o Editar.
        /// </summary>
        private void ConfigurarEstadoInicialProducto()
        {
            EstablecerEdicionProductoHabilitada(false);
            RestablecerCamposProducto();
        }

        /// <summary>
        /// Activa o desactiva todos los controles que permiten capturar datos del producto.
        /// </summary>
        /// <param name="habilitar">True permite capturar; false bloquea la edición.</param>
        private void EstablecerEdicionProductoHabilitada(bool habilitar)
        {
            txtCodigo.Enabled = habilitar;
            txtNombre.Enabled = habilitar;
            txtDescripcion.Enabled = habilitar;
            cmbCategoria.Enabled = habilitar;
            cmbUnidad.Enabled = habilitar;
            nudPrecio.Enabled = habilitar;
            chkDisponible.Enabled = habilitar;
            chkActivo.Enabled = habilitar;
            btnLimpiarProducto.Enabled = habilitar;
            btnGuardarProducto.Enabled = habilitar;
        }

        /// <summary>
        /// Restablece los valores de captura sin cambiar el estado habilitado de los controles.
        /// </summary>
        private void RestablecerCamposProducto()
        {
            _productoEnEdicionId = null;
            txtCodigo.Clear();
            txtNombre.Clear();
            txtDescripcion.Clear();

            if (cmbCategoria.Items.Count > 0)
                cmbCategoria.SelectedIndex = 0;

            if (cmbUnidad.Items.Count > 0)
                cmbUnidad.SelectedIndex = 0;

            nudPrecio.Value = nudPrecio.Minimum;
            chkDisponible.Checked = true;
            chkActivo.Checked = true;
        }

        /// <summary>
        /// Comprueba que el código del producto tenga un prefijo autorizado
        /// y que cumpla el formato AAA-000.
        /// </summary>
        /// <returns>
        /// true si el código es válido; false si falta completar la máscara
        /// o el prefijo no está permitido.
        /// </returns>
        private bool ValidarCodigoProducto()
        {
            if (!txtCodigo.MaskCompleted)
            {
                MostrarMensaje(
                    "Complete el código del producto con el formato AAA-000.",
                    "Código de producto",
                    true);

                txtCodigo.Focus();
                return false;
            }

            string codigo = txtCodigo.Text.Trim().ToUpperInvariant();
            string prefijo = codigo[..3];

            if (!PrefijosProductoPermitidos.Contains(prefijo))
            {
                MostrarMensaje(
                    $"El prefijo '{prefijo}' no está permitido. " +
                    "Consulte la lista de prefijos autorizados.",
                    "Prefijo no válido",
                    true);

                txtCodigo.Focus();
                return false;
            }

            return true;
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

        /// <summary>
        /// Identificador del ingrediente confirmado en el formulario modal.
        /// </summary>
        public int? IngredienteSeleccionadoId => _ingredienteSeleccionadoId;

        /// <summary>
        /// Cantidad confirmada en el formulario modal.
        /// </summary>
        public decimal CantidadIngrediente => _cantidadIngrediente;

        /// <summary>
        /// Notas confirmadas en el formulario modal.
        /// </summary>
        public string? NotasIngrediente => _notasIngrediente;
        /// <summary>
        /// Obtiene el identificador del ingrediente de la fila seleccionada.
        /// Devuelve null cuando no existe una selección explícita.
        /// </summary>
        public int? DetalleIngredienteSeleccionadoId => dgvReceta.SelectedRows.Count > 0 && dgvReceta.SelectedRows[0].DataBoundItem is DetalleRecetaDto detalle
                    ? detalle.IngredientProductId
                    : null;
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

        /// <summary>Convierte los objetos enlazados a los ComboBox en textos de presentación en español.</summary>
        private static void FormatearTextoCombo(object? sender, ListControlConvertEventArgs e)
        {
            e.Value = CatalogoTraducciones.TextoCombo(e.ListItem);
        }

        /// <summary>
        /// Configura los ComboBox para mostrar propiedades legibles de los DTO.
        /// Comprueba también qué tipo de objeto contiene cada lista enlazada.
        /// </summary>
        private void PrepararEnlaces()
        {
            dgvProductos.AutoGenerateColumns = false;
            dgvProductos.DataSource = _productos;

            dgvReceta.AutoGenerateColumns = false;
            dgvReceta.DataSource = _detalles;

            ConfigurarComboBox(
                cmbCategoria,
                _categorias,
                nameof(CategoriaProductoDto.CategoryName),
                nameof(CategoriaProductoDto.ProductCategoryId));

            ConfigurarComboBox(
                cmbUnidad,
                _unidades,
                nameof(UnidadMedidaDto.UnitName),
                nameof(UnidadMedidaDto.UnitOfMeasureId));

            ConfigurarComboBox(
                cmbProductoReceta,
                _productosReceta,
                nameof(ProductoRecetaSelectorDto.TextoMostrar),
                nameof(ProductoRecetaSelectorDto.ProductId));
        }

        /// <summary>
        /// Establece las propiedades de presentación y valor de un ComboBox.
        /// </summary>
        private static void ConfigurarComboBox(
            ComboBox combo,
            BindingSource origen,
            string propiedadVisible,
            string propiedadValor)
        {
            combo.BeginUpdate();

            try
            {

                combo.FormattingEnabled = true;
                combo.Format -= FormatearTextoCombo;
                combo.Format += FormatearTextoCombo;

                combo.DataSource = null;
                combo.Items.Clear();

                combo.DropDownStyle = ComboBoxStyle.DropDownList;
                combo.FormattingEnabled = true;

                combo.DisplayMember = propiedadVisible;
                combo.ValueMember = propiedadValor;
                combo.DataSource = origen;

                // Fuerza la actualización de la presentación del control.
                combo.Refresh();
            }
            finally
            {
                combo.EndUpdate();
            }
        }

        private void ConectarEventos()
        {
            txtBuscarProducto.TextChanged += (_, _) => BusquedaCambiada?.Invoke(this, EventArgs.Empty);
            btnNuevoProducto.Click += (_, _) => NuevoProductoSolicitado?.Invoke(this, EventArgs.Empty);
            btnEditarProducto.Click += (_, _) => EditarProductoSolicitado?.Invoke(this, EventArgs.Empty);
            Tcproductos.SelectedIndexChanged += (_, _) => ActualizarEstadoBarraSuperior();
            btnCambiarEstado.Click += (_, _) => SolicitarCambioEstadoConConfirmacion();
            btnLimpiarProducto.Click += (_, _) =>
            {
                LimpiarFormularioProducto();
                EstablecerEdicionProductoHabilitada(false);
            };

            btnGuardarProducto.Click += (_, _) =>
            {
                {
                    if (ValidarCodigoProducto())
                    {
                        GuardarProductoSolicitado?.Invoke(this, EventArgs.Empty);
                    }
                }

            };

            // Mantiene la disponibilidad coherente con el estado del producto.
            chkActivo.CheckedChanged += (_, _) =>
            {
                if (!chkActivo.Checked)
                {
                    chkDisponible.Checked = false;
                    chkDisponible.Enabled = false;
                }
                else
                {
                    chkDisponible.Enabled = true;
                }
            };

            dgvProductos.SelectionChanged += (_, _) => ProductoSeleccionadoCambiado?.Invoke(this, EventArgs.Empty);

            // Al cambiar el producto, actualiza el estado de los botones
            // y solicita al Presenter que cargue la receta correspondiente.
            cmbProductoReceta.SelectedValueChanged += (_, _) =>
            {
                if (_actualizando)
                    return;

                ActualizarEstadoBotonesReceta();

                ProductoRecetaSeleccionadoCambiado?.Invoke(
                    this,
                    EventArgs.Empty);
            };

            // Los botones de edición dependen de la fila seleccionada.
            dgvReceta.SelectionChanged += (_, _) =>
            {
                ActualizarEstadoBotonesReceta();
            };

            btnAgregarIngrediente.Click += (_, _) => AbrirEditorIngrediente(false);
            btnEditarIngrediente.Click += (_, _) => AbrirEditorIngrediente(true);
            btnQuitarIngrediente.Click += (_, _) => QuitarIngredienteSolicitado?.Invoke(this, EventArgs.Empty);
            btnGuardarReceta.Click += (_, _) => GuardarRecetaSolicitado?.Invoke(this, EventArgs.Empty);
           
        }

        /// <summary>
        /// Abre el formulario modal para agregar un ingrediente o editar
        /// un ingrediente existente de la receta.
        /// </summary>
        /// <param name="editar">
        /// True para editar el ingrediente seleccionado; false para agregar uno.
        /// </param>
        private void AbrirEditorIngrediente(bool editar)
        {
            DetalleRecetaDto? detalle = editar && dgvReceta.SelectedRows.Count > 0 ? dgvReceta.SelectedRows[0].DataBoundItem as DetalleRecetaDto
            : null;

            if (editar && detalle is null)
            {
                MostrarMensaje(
                    "Seleccione un ingrediente de la receta antes de editar.",
                    "Ingrediente requerido",
                    true);

                return;
            }

            List<IngredienteSelectorDto> ingredientes = _ingredientes.List
                .Cast<object>()
                .OfType<IngredienteSelectorDto>()
                .ToList();

            // Conserva el ingrediente de la receta aunque ya no figure
            // en la lista de ingredientes activos.
            if (detalle is not null &&
                !ingredientes.Any(i =>
                    i.ProductId == detalle.IngredientProductId))
            {
                ingredientes.Add(new IngredienteSelectorDto
                {
                    ProductId = detalle.IngredientProductId,
                    ProductCode = detalle.IngredientCode,
                    ProductName = detalle.IngredientName,
                    UnitCode = detalle.UnitCode,
                    UnitName = detalle.UnitName
                });
            }

            if (ingredientes.Count == 0)
            {
                MostrarMensaje(
                    "No hay ingredientes disponibles para agregar.",
                    "Ingredientes no disponibles",
                    true);

                return;
            }

            using var formulario = new FrmIngredienteReceta(
                ingredientes,
                detalle);

            // Cancelar no debe modificar la receta temporal.
            if (formulario.ShowDialog(this) != DialogResult.OK)
                return;

            DetalleRecetaDto? resultado = formulario.DetalleResultado;

            if (resultado is null ||
                resultado.IngredientProductId <= 0)
            {
                MostrarMensaje(
                    "No se recibieron datos válidos del ingrediente.",
                    "Ingrediente inválido",
                    true);

                return;
            }

            // Conserva los datos confirmados para que el Presenter
            // ejecute sus validaciones y actualice la receta temporal.
            _ingredienteSeleccionadoId = resultado.IngredientProductId;
            _cantidadIngrediente = resultado.Quantity;
            _notasIngrediente = resultado.Notes;

            if (editar)
            {
                EditarIngredienteSolicitado?.Invoke(
                    this,
                    EventArgs.Empty);
            }
            else
            {
                AgregarIngredienteSolicitado?.Invoke(
                    this,
                    EventArgs.Empty);
            }
        }

        /// <summary>
        /// Solicita confirmación antes de cambiar el estado del producto seleccionado.
        /// Si el usuario confirma, notifica la solicitud al Presenter.
        /// </summary>
        private void SolicitarCambioEstadoConConfirmacion()
        {
            if (dgvProductos.CurrentRow?.DataBoundItem is not ProductoCatalogoDto producto)
            {
                MostrarMensaje(
                    "Seleccione un producto del catálogo antes de cambiar su estado.",
                    "Producto no seleccionado",
                    true);

                return;
            }

            string nuevoEstado = producto.IsActive ? "inactivo" : "activo";

            DialogResult respuesta = FrmMessageBox.Show(
                $"¿Desea cambiar el estado del producto '{producto.ProductName}' a {nuevoEstado}?",
                "Confirmar cambio de estado",
                MessageType.Confirmation);

            if (respuesta == DialogResult.Yes)
            {
                CambiarEstadoProductoSolicitado?.Invoke(this, EventArgs.Empty);
            }
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

        public void MostrarCategorias(IReadOnlyList<CategoriaProductoDto> categorias)
        {
            _categorias.DataSource = categorias.ToList();
            if (cmbCategoria.Items.Count > 0 && cmbCategoria.SelectedIndex < 0)
                cmbCategoria.SelectedIndex = 0;
        }

        public void MostrarUnidades(IReadOnlyList<UnidadMedidaDto> unidades)
        {
            _unidades.DataSource = unidades.ToList();
            if (cmbUnidad.Items.Count > 0 && cmbUnidad.SelectedIndex < 0)
                cmbUnidad.SelectedIndex = 0;
        }

        /// <summary>
        /// Carga los productos terminados en el selector de recetas e incluye
        /// una opción predeterminada sin producto seleccionado.
        /// </summary>
        /// <param name="productos">Productos terminados disponibles.</param>
        public void MostrarProductosParaReceta(
            IReadOnlyList<ProductoRecetaSelectorDto> productos)
        {
            _actualizando = true;

            try
            {
                // El identificador cero está reservado para la opción predeterminada.
                var opciones = new List<ProductoRecetaSelectorDto>
        {
            new ProductoRecetaSelectorDto
            {
                ProductId = 0,
                ProductCode = string.Empty,
                ProductName = "Seleccione el Producto..."
            }
        };

                // Agrega los productos reales después de la opción predeterminada.
                opciones.AddRange(productos);

                _productosReceta.DataSource = opciones;

                // Selecciona siempre el elemento predeterminado.
                if (cmbProductoReceta.Items.Count > 0)
                {
                    cmbProductoReceta.SelectedIndex = 0;
                }
            }
            finally
            {
                _actualizando = false;
            }

            // Sin producto seleccionado, los botones dependientes de la receta
            // deberán permanecer deshabilitados.
            ActualizarEstadoBotonesReceta();
        }

        /// <summary>
        /// Actualiza la lista de ingredientes que pueden añadirse a las recetas.
        /// </summary>
        /// <param name="ingredientes">Ingredientes disponibles para selección.</param>
        public void MostrarIngredientesDisponibles(
            IReadOnlyList<IngredienteSelectorDto> ingredientes)
        {
            _ingredientes.DataSource = ingredientes.ToList();

            ActualizarEstadoBotonesReceta();
        }

        /// <summary>
        /// Carga los datos del producto seleccionado y habilita su edición.
        /// </summary>
        public void CargarProductoEnFormulario(ProductoCatalogoDto p)
        {
            if (p is null)
                throw new ArgumentNullException(nameof(p));

            EstablecerEdicionProductoHabilitada(true);
            _productoEnEdicionId = p.ProductId;
            txtCodigo.Text = p.ProductCode;
            txtNombre.Text = p.ProductName;
            txtDescripcion.Text = p.Description ?? string.Empty;
            SeleccionarValor(cmbCategoria, p.ProductCategoryId);
            SeleccionarValor(cmbUnidad, p.UnitOfMeasureId);
            nudPrecio.Value = Math.Max(nudPrecio.Minimum, Math.Min(nudPrecio.Maximum, p.UnitPrice));
            chkDisponible.Checked = p.IsAvailable;
            chkActivo.Checked = p.IsActive;
            txtNombre.Focus();

            // Un producto inactivo nunca puede quedar disponible para la venta.
            chkDisponible.Enabled = p.IsActive;
            if (!p.IsActive)
            {
                chkDisponible.Checked = false;
            }
        }

        /// <summary>
        /// Limpia el formulario y lo deja en modo captura para registrar un producto nuevo.
        /// </summary>
        public void LimpiarFormularioProducto()
        {
            RestablecerCamposProducto();
            EstablecerEdicionProductoHabilitada(true);
            txtCodigo.Focus();
        }

        /// <summary>
        /// Deshabilita los campos de captura después de completar el guardado.
        /// </summary>
        public void BloquearEdicionProducto()
        {
            EstablecerEdicionProductoHabilitada(false);
        }

        /// <summary>
        /// Selecciona en el ComboBox el elemento cuyo SelectedValue coincide con valor; si valor es nulo selecciona el
        /// primer elemento si existe alguno.
        /// </summary>
        /// <remarks>Si existe un valor pero no hay ningún elemento con ese SelectedValue, la selección
        /// queda sin elemento seleccionado.</remarks>
        /// <param name="combo">ComboBox donde se realiza la selección; si no tiene elementos no se realiza ninguna selección.</param>
        /// <param name="valor">Valor a buscar en SelectedValue; si es nulo se selecciona el primer elemento si existe.</param>
        private static void SeleccionarValor(ComboBox combo, int? valor) { if (valor.HasValue && combo.Items.Count > 0) combo.SelectedValue = valor.Value; else if (combo.Items.Count > 0) combo.SelectedIndex = 0; }

        /// <summary>
        /// Muestra los ingredientes de la receta y restablece la selección.
        /// </summary>
        /// <param name="detalles">
        /// Ingredientes y cantidades que componen la receta.
        /// </param>
        public void MostrarDetallesReceta(
            IReadOnlyList<DetalleRecetaDto> detalles)
        {
            _detalles.DataSource = detalles.ToList();

            // Evita que quede seleccionada automáticamente una línea anterior.
            dgvReceta.ClearSelection();

            // Limpia los valores temporales del último ingrediente editado.
            _ingredienteSeleccionadoId = null;
            _cantidadIngrediente = 0m;
            _notasIngrediente = null;

            // Actualiza los botones después de enlazar los datos.
            ActualizarEstadoBotonesReceta();
        }

        /// <summary>
        /// Actualiza txtInstruccionesReceta.Text con las instrucciones de la receta.
        /// </summary>
        /// <remarks>Sustituye null por string.Empty antes de asignar al control de interfaz.</remarks>
        /// <param name="instrucciones">Texto con las instrucciones de la receta; si es null se reemplaza por string.Empty.</param>
        public void MostrarInstruccionesReceta(string instrucciones) { txtInstruccionesReceta.Text = instrucciones ?? string.Empty; }

        /// <summary>
        /// Muestra mensajes mediante el cuadro estandarizado de Ocean Desk.
        /// Los mensajes de validación se presentan como advertencias y las
        /// excepciones identificadas por su título se presentan como errores.
        /// </summary>
        /// <param name="mensaje">Texto que se mostrará al usuario.</param>
        /// <param name="titulo">Título de la ventana de mensaje.</param>
        /// <param name="esError">Indica si el mensaje corresponde a una advertencia o error.</param>
        public void MostrarMensaje(
            string mensaje,
            string titulo = "Productos",
            bool esError = false)
        {
            MessageType tipo = MessageType.Information;

            if (esError)
            {
                tipo = titulo.Contains(
                    "error",
                    StringComparison.OrdinalIgnoreCase)
                    ? MessageType.Error
                    : MessageType.Warning;
            }

            FrmMessageBox.Show(mensaje, titulo, tipo);
        }

        /// <summary>Traduce los valores booleanos de la tabla a etiquetas legibles.</summary>
        private void dgvProductos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value is not bool valor) return;
            string columna = dgvProductos.Columns[e.ColumnIndex].Name;
            if (columna == "colDisponible") { e.Value = valor ? "Sí" : "No"; e.FormattingApplied = true; }
            else if (columna == "colActivo") { e.Value = valor ? "Activo" : "Inactivo"; e.CellStyle.ForeColor = valor ? Color.FromArgb(42, 122, 82) : Color.FromArgb(163, 61, 61); e.FormattingApplied = true; }
        }

        /// <summary>Traduce ingredientes y unidades al mostrarlos en la tabla de receta.</summary>
        private void dgvReceta_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || dgvReceta.Rows[e.RowIndex].DataBoundItem is not DetalleRecetaDto detalle)
                return;

            string columna = dgvReceta.Columns[e.ColumnIndex].Name;
            if (columna == "colIngrediente")
            {
                e.Value = CatalogoTraducciones.TraducirIngrediente(detalle.IngredientCode, detalle.IngredientName);
                e.FormattingApplied = true;
            }
            else if (columna == "colUnidadReceta")
            {
                e.Value = CatalogoTraducciones.TraducirUnidad(detalle.UnitCode, detalle.UnitName);
                e.FormattingApplied = true;
            }
        }
    }
}

