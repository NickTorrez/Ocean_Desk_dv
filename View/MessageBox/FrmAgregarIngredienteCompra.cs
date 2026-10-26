using Ocean_Desk_dv.Models.DTOs;
using Ocean_Desk_dv.UI.MessageBox;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Ocean_Desk_dv.View.MessageBox
{
    public partial class FrmAgregarIngredienteCompra : Form
    {
        private const decimal CantidadMaxima = 99999999.9999m;

        private IReadOnlyList<ProductoCompraDto> _productosExistentes =
            Array.Empty<ProductoCompraDto>();

        private IReadOnlyList<UnidadMedidaDto> _unidades =
            Array.Empty<UnidadMedidaDto>();

        /// <summary>
        /// Datos que devuelve el formulario cuando se confirma
        /// la captura de un producto.
        /// </summary>
        public DetalleCompraCapturaDto? Resultado { get; private set; }


        public FrmAgregarIngredienteCompra()
        {
            InitializeComponent();

            ConfigurarFormulario();

            txtNombreIngrediente.TextChanged +=
                (_, _) => ActualizarUnidadProductoReconocido();

            btnConfirmar.Click += (_, _) => ConfirmarProducto();

            btnCancelar.Click += (_, _) =>
            {
                DialogResult = DialogResult.Cancel;
                Close();
            };
        }

        // Constructor utilizado desde FrmCompras.
        public FrmAgregarIngredienteCompra(
            IReadOnlyList<ProductoCompraDto> productosExistentes,
            IReadOnlyList<UnidadMedidaDto> unidades)
            : this()
        {
            _productosExistentes = productosExistentes
                ?? throw new ArgumentNullException(nameof(productosExistentes));

            _unidades = unidades
                ?? throw new ArgumentNullException(nameof(unidades));

            CargarUnidades();
            ConfigurarAutocompletado();
        }

        private void ConfigurarFormulario()
        {
            StartPosition = FormStartPosition.CenterParent;
            ShowInTaskbar = false;
            MaximizeBox = false;
            MinimizeBox = false;

            lblTitulo.Text = "Agregar producto a la compra";
            lblSubtitulo.Text =
                "Ingrese la mercancía que adquirirá al proveedor.";

            lblIngrediente.Text = "Nombre del producto";
            lblLote.Text = "Código de lote (opcional)";

            txtNombreIngrediente.MaxLength = 150;

            // Este control se llama nudStockMinimo en el diseñador,
            // pero visualmente corresponde al campo Cantidad.
            nudStockMinimo.DecimalPlaces = 4;
            nudStockMinimo.Minimum = 0.0001m;
            nudStockMinimo.Maximum = CantidadMaxima;
            nudStockMinimo.Value = 1m;
            nudStockMinimo.ThousandsSeparator = true;

            // Este control corresponde al costo unitario.
            nudCosto.DecimalPlaces = 4;
            nudCosto.Minimum = 0m;
            nudCosto.Maximum = 999999m;
            nudCosto.Value = 0m;
            nudCosto.ThousandsSeparator = true;

            txtLote.MaxLength = 50;
            txtLote.PlaceholderText = "Opcional";

            txtObservaciones.MaxLength = 250;
            txtObservaciones.Multiline = true;
            txtObservaciones.ScrollBars = ScrollBars.Vertical;

            dtpVencimiento.Format = DateTimePickerFormat.Short;
            dtpVencimiento.ShowCheckBox = true;
            dtpVencimiento.MinDate = DateTime.Today;
            dtpVencimiento.Value = DateTime.Today;
            dtpVencimiento.Checked = false;

            btnConfirmar.DialogResult = DialogResult.None;
            btnCancelar.DialogResult = DialogResult.Cancel;

            AcceptButton = btnConfirmar;
            CancelButton = btnCancelar;
        }

        private void CargarUnidades()
        {
            cmbUnidadMedida.DropDownStyle =
                ComboBoxStyle.DropDownList;

            cmbUnidadMedida.FormattingEnabled = true;
            cmbUnidadMedida.Format += FormatearUnidad;

            cmbUnidadMedida.DataSource = _unidades.ToList();

            cmbUnidadMedida.DisplayMember =
                nameof(UnidadMedidaDto.UnitName);

            cmbUnidadMedida.ValueMember =
                nameof(UnidadMedidaDto.UnitOfMeasureId);

            // Para un producto nuevo, el usuario debe elegir la unidad.
            cmbUnidadMedida.SelectedIndex = -1;
        }

        private void FormatearUnidad(
            object? sender,
            ListControlConvertEventArgs e)
        {
            if (e.ListItem is not UnidadMedidaDto unidad)
                return;

            string nombre = CatalogoTraducciones.TraducirUnidad(
                unidad.UnitCode,
                unidad.UnitName);

            e.Value = string.IsNullOrWhiteSpace(unidad.UnitSymbol)
                ? nombre
                : $"{nombre} ({unidad.UnitSymbol})";
        }

        private void ConfigurarAutocompletado()
        {
            txtNombreIngrediente.AutoCompleteMode =
                AutoCompleteMode.SuggestAppend;

            txtNombreIngrediente.AutoCompleteSource =
                AutoCompleteSource.CustomSource;

            var sugerencias = new AutoCompleteStringCollection();

            sugerencias.AddRange(
                _productosExistentes
                    .SelectMany(p => new[]
                    {
                        p.ProductName,
                        CatalogoTraducciones.TraducirIngrediente(
                            p.ProductCode,
                            p.ProductName)
                    })
                    .Where(n => !string.IsNullOrWhiteSpace(n))
                    .Distinct(StringComparer.OrdinalIgnoreCase)
                    .ToArray());

            txtNombreIngrediente.AutoCompleteCustomSource =
                sugerencias;
        }

        private ProductoCompraDto? BuscarProductoPorNombre()
        {
            string nombre = txtNombreIngrediente.Text.Trim();

            if (nombre.Length == 0)
                return null;

            return _productosExistentes.FirstOrDefault(p =>
                string.Equals(
                    p.ProductName.Trim(),
                    nombre,
                    StringComparison.OrdinalIgnoreCase)
                ||
                string.Equals(
                    CatalogoTraducciones.TraducirIngrediente(
                        p.ProductCode,
                        p.ProductName).Trim(),
                    nombre,
                    StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Si el texto coincide exactamente con un ingrediente existente,
        /// reutiliza su unidad de medida. No exige escogerlo en una lista.
        /// </summary>
        private void ActualizarUnidadProductoReconocido()
        {
            ProductoCompraDto? existente = BuscarProductoPorNombre();

            if (existente?.UnitOfMeasureId is int unidadId &&
                _unidades.Any(u => u.UnitOfMeasureId == unidadId))
            {
                cmbUnidadMedida.SelectedValue = unidadId;
                cmbUnidadMedida.Enabled = false;
            }
            else
            {
                if (!cmbUnidadMedida.Enabled)
                    cmbUnidadMedida.SelectedIndex = -1;

                cmbUnidadMedida.Enabled = true;
            }
        }

        private void ConfirmarProducto()
        {
            string nombre = txtNombreIngrediente.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                MostrarAdvertencia(
                    "Ingrese el nombre del producto.",
                    "Producto requerido");

                txtNombreIngrediente.Focus();
                return;
            }

            if (nombre.Length > 150)
            {
                MostrarAdvertencia(
                    "El nombre no puede superar los 150 caracteres.",
                    "Nombre inválido");

                txtNombreIngrediente.Focus();
                return;
            }

            if (cmbUnidadMedida.SelectedItem is not UnidadMedidaDto unidad)
            {
                MostrarAdvertencia(
                    "Seleccione una unidad de medida válida.",
                    "Unidad requerida");

                cmbUnidadMedida.Focus();
                return;
            }

            if (nudStockMinimo.Value <= 0m)
            {
                MostrarAdvertencia(
                    "La cantidad debe ser mayor que cero.",
                    "Cantidad inválida");

                nudStockMinimo.Focus();
                return;
            }

            if (nudCosto.Value < 0m)
            {
                MostrarAdvertencia(
                    "El costo unitario no puede ser negativo.",
                    "Costo inválido");

                nudCosto.Focus();
                return;
            }

            if (dtpVencimiento.Checked &&
                dtpVencimiento.Value.Date < DateTime.Today)
            {
                MostrarAdvertencia(
                    "La fecha de vencimiento no puede estar en el pasado.",
                    "Fecha inválida");

                dtpVencimiento.Focus();
                return;
            }

            ProductoCompraDto? existente = BuscarProductoPorNombre();

            // Si ya existe un producto con ese nombre, se utiliza su
            // identificador y código en vez de crear otro duplicado.
            if (existente is not null &&
                existente.UnitOfMeasureId != unidad.UnitOfMeasureId)
            {
                MostrarAdvertencia(
                    "El producto ya está registrado con otra unidad de medida.",
                    "Unidad incompatible");

                return;
            }

            DateOnly? vencimiento = dtpVencimiento.Checked
                ? DateOnly.FromDateTime(dtpVencimiento.Value.Date)
                : null;

            decimal cantidad = nudStockMinimo.Value;
            decimal costo = nudCosto.Value;

            Resultado = new DetalleCompraCapturaDto
            {
                ProductId = existente?.ProductId,
                ProductCode = existente?.ProductCode ?? string.Empty,
                ProductName = existente?.ProductName ?? nombre,

                UnitOfMeasureId = unidad.UnitOfMeasureId,
                UnitName = unidad.UnitName,

                Quantity = cantidad,
                UnitCost = costo,
                Subtotal = Math.Round(
                    cantidad * costo,
                    2,
                    MidpointRounding.AwayFromZero),

                ReceivedQuantity = 0m,

                LotCode = string.IsNullOrWhiteSpace(txtLote.Text)
                    ? null
                    : txtLote.Text.Trim(),

                ExpirationDate = vencimiento,

                Notes = string.IsNullOrWhiteSpace(txtObservaciones.Text)
                    ? null
                    : txtObservaciones.Text.Trim()
            };

            DialogResult = DialogResult.OK;
            Close();
        }

        private void MostrarAdvertencia(
            string mensaje,
            string titulo)
        {
            FrmMessageBox.Show(
                mensaje,
                titulo,
                MessageType.Warning,
                this);
        }

        // Se conserva porque el diseñador actual tiene asociado
        // este evento a uno de sus controles.
        private void lblVencimiento_Click(object sender, EventArgs e)
        {
        }

    }
}
