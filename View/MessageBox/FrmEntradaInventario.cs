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

namespace Ocean_Desk_dv.View.MessageBox
{
    /// <summary>
    /// Permite registrar una entrada de inventario para un ingrediente
    /// existente o crear un ingrediente con su stock inicial.
    /// No accede directamente a la base de datos.
    /// </summary>
    public partial class FrmEntradaInventario : Form
    {
        private const decimal CantidadMaxima = 99999999.9999m;

        private readonly IReadOnlyList<IngredienteSelectorDto> _ingredientes;
        private readonly IReadOnlyList<UnidadMedidaDto> _unidades;
        private readonly string? _codigoPropuesto;

        private IngredienteSelectorDto? _ingredienteExistente;

        public SolicitudEntradaIngredienteDto? Resultado { get; private set; }

        public FrmEntradaInventario(IReadOnlyList<IngredienteSelectorDto> ingredientes,
            IReadOnlyList<UnidadMedidaDto> unidades,
            string? codigoPropuesto)
        {
            InitializeComponent();

            _ingredientes = ingredientes ??
                throw new ArgumentNullException(nameof(ingredientes));

            _unidades = unidades ??
                throw new ArgumentNullException(nameof(unidades));

            _codigoPropuesto = codigoPropuesto;

            ConfigurarFormulario();
            ConfigurarControles();
            ConectarEventos();
            ActualizarIngredienteReconocido();
        }

        private void ConfigurarFormulario()
        {
            StartPosition = FormStartPosition.CenterParent;
            ShowInTaskbar = false;
            MaximizeBox = false;
            MinimizeBox = false;

            btnConfirmar.DialogResult = DialogResult.None;
            btnCancelar.DialogResult = DialogResult.Cancel;

            AcceptButton = btnConfirmar;
            CancelButton = btnCancelar;

            lblTitulo.Text = "Registrar entrada de ingrediente";
            lblSubtitulo.Text = "Ingrese un ingrediente nuevo o busque uno existente.";
        }

        private void ConfigurarControles()
        {
            txtNombreIngrediente.MaxLength = 150;

            // Autocompletado con los ingredientes registrados.
            txtNombreIngrediente.AutoCompleteMode =
                AutoCompleteMode.SuggestAppend;

            txtNombreIngrediente.AutoCompleteSource =
                AutoCompleteSource.CustomSource;

            var sugerencias = new AutoCompleteStringCollection();

            sugerencias.AddRange(
                _ingredientes
                    .SelectMany(i => new[]
                    {
            i.ProductName,
            CatalogoTraducciones.TraducirIngrediente(
                i.ProductCode,
                i.ProductName)
                    })
                    .Where(n => !string.IsNullOrWhiteSpace(n))
                    .Distinct(StringComparer.OrdinalIgnoreCase)
                    .ToArray());

            txtNombreIngrediente.AutoCompleteCustomSource = sugerencias;

            // El código es de solo lectura.
            txtCodigoProducto.ReadOnly = true;
            txtCodigoProducto.Text = _codigoPropuesto
                ?? "No hay códigos disponibles";

            cmbUnidadMedida.DropDownStyle =
                ComboBoxStyle.DropDownList;

            cmbUnidadMedida.Format -= FormatearUnidad;
            cmbUnidadMedida.Format += FormatearUnidad;

            cmbUnidadMedida.DataSource = _unidades.ToList();
            cmbUnidadMedida.DisplayMember =
                nameof(UnidadMedidaDto.UnitName);
            cmbUnidadMedida.ValueMember =
                nameof(UnidadMedidaDto.UnitOfMeasureId);

            // No se asigna una unidad por defecto para un ingrediente nuevo.
            cmbUnidadMedida.SelectedIndex = -1;

            nudCantidad.DecimalPlaces = 4;
            nudCantidad.Minimum = 0.0001m;
            nudCantidad.Maximum = CantidadMaxima;
            nudCantidad.Increment = 0.1m;
            nudCantidad.ThousandsSeparator = true;
            nudCantidad.Value = 1m;

            dtpVencimiento.Format = DateTimePickerFormat.Short;
            dtpVencimiento.ShowCheckBox = true;
            dtpVencimiento.MinDate = DateTime.Today;
            dtpVencimiento.Value = DateTime.Today;
            dtpVencimiento.Checked = false;

            // El lote tiene un límite de 250 caracteres en el esquema actual.
            txtObservaciones.MaxLength = 250;
            txtObservaciones.Multiline = true;
            txtObservaciones.ScrollBars = ScrollBars.Vertical;
        }

        private void ConectarEventos()
        {
            txtNombreIngrediente.TextChanged += (_, _) =>
                ActualizarIngredienteReconocido();

            btnConfirmar.Click += (_, _) =>
                ConfirmarEntrada();
        }

        /// <summary>
        /// Si el texto coincide con un ingrediente existente, conserva
        /// su código y unidad base. Si es nuevo, propone un código ING.
        /// </summary>
        private void ActualizarIngredienteReconocido()
        {
            string nombre = txtNombreIngrediente.Text.Trim();

            bool eraExistente = _ingredienteExistente is not null;

            _ingredienteExistente = _ingredientes.FirstOrDefault(i =>
                string.Equals(
                    i.ProductName.Trim(),
                    nombre,
                    StringComparison.OrdinalIgnoreCase)
                ||
                string.Equals(
                    CatalogoTraducciones.TraducirIngrediente(
                        i.ProductCode,
                        i.ProductName).Trim(),
                    nombre,
                    StringComparison.OrdinalIgnoreCase));

            if (_ingredienteExistente is not null)
            {
                txtCodigoProducto.Text =
                    _ingredienteExistente.ProductCode;

                cmbUnidadMedida.Enabled = false;

                if (_ingredienteExistente.UnitOfMeasureId.HasValue)
                {
                    cmbUnidadMedida.SelectedValue =
                        _ingredienteExistente.UnitOfMeasureId.Value;
                }
                else
                {
                    cmbUnidadMedida.SelectedIndex = -1;
                }

                return;
            }

            txtCodigoProducto.Text = _codigoPropuesto
                ?? "No hay códigos disponibles";

            cmbUnidadMedida.Enabled = true;

            // No conservar la unidad del producto anterior cuando
            // el usuario empieza a escribir un ingrediente nuevo.
            if (eraExistente)
                cmbUnidadMedida.SelectedIndex = -1;
        }

        private void FormatearUnidad(
            object? sender,
            ListControlConvertEventArgs e)
        {
            if (e.ListItem is UnidadMedidaDto unidad)
            {
                string nombre = CatalogoTraducciones.TraducirUnidad(
                    unidad.UnitCode,
                    unidad.UnitName);

                e.Value = string.IsNullOrWhiteSpace(unidad.UnitSymbol)
                    ? nombre
                    : $"{nombre} ({unidad.UnitSymbol})";
            }
        }

        private void ConfirmarEntrada()
        {
            string nombre = txtNombreIngrediente.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                MostrarAdvertencia(
                    "Ingrese el nombre del ingrediente.",
                    "Ingrediente requerido");

                txtNombreIngrediente.Focus();
                return;
            }

            if (nombre.Length > 150)
            {
                MostrarAdvertencia(
                    "El nombre no puede superar los 150 caracteres.",
                    "Nombre demasiado largo");

                txtNombreIngrediente.Focus();
                return;
            }

            if (_ingredienteExistente is null &&
            string.IsNullOrWhiteSpace(_codigoPropuesto))
            {
                MostrarAdvertencia(
                    "No hay códigos ING disponibles. Revise la numeración " +
                    "del catálogo antes de crear otro ingrediente.",
                    "Código no disponible");

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

            if (nudCantidad.Value <= 0m ||
                nudCantidad.Value > CantidadMaxima ||
                nudCantidad.Value != decimal.Round(nudCantidad.Value, 4))
            {
                MostrarAdvertencia(
                    "La cantidad debe ser mayor que cero y admitir " +
                    "como máximo cuatro decimales.",
                    "Cantidad inválida");

                nudCantidad.Focus();
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

            if (txtObservaciones.Text.Trim().Length > 250)
            {
                MostrarAdvertencia(
                    "Las observaciones no pueden superar los 250 caracteres.",
                    "Observaciones inválidas");

                txtObservaciones.Focus();
                return;
            }

            DateOnly? vencimiento = dtpVencimiento.Checked
                ? DateOnly.FromDateTime(dtpVencimiento.Value.Date)
                : null;

            string tipoAccion = _ingredienteExistente is null
                ? "crear el ingrediente y registrar su stock inicial"
                : "registrar una entrada para el ingrediente existente";

            string codigoMostrar = txtCodigoProducto.Text;

            DialogResult confirmar = FrmMessageBox.Show(
                $"¿Desea {tipoAccion}?\n\n" +
                $"Ingrediente: {nombre}\n" +
                $"Código: {codigoMostrar}\n" +
                $"Unidad: {unidad.UnitName}\n" +
                $"Cantidad: {nudCantidad.Value:0.####}\n" +
                $"Vencimiento: {(vencimiento.HasValue ? vencimiento.Value.ToString("dd/MM/yyyy") : "Sin fecha")}",
                "Confirmar entrada de inventario",
                MessageType.Confirmation);

            if (confirmar != DialogResult.Yes)
                return;

            Resultado = new SolicitudEntradaIngredienteDto
            {
                ProductId = _ingredienteExistente?.ProductId,
                ProductName = nombre,
                UnitOfMeasureId = unidad.UnitOfMeasureId,
                Quantity = nudCantidad.Value,
                ExpirationDate = vencimiento,
                Notes = string.IsNullOrWhiteSpace(txtObservaciones.Text)
                    ? null
                    : txtObservaciones.Text.Trim()
            };

            DialogResult = DialogResult.OK;
            Close();
        }

        private static void MostrarAdvertencia(
            string mensaje,
            string titulo)
        {
            FrmMessageBox.Show(
                mensaje,
                titulo,
                MessageType.Warning);
        }
    }
}
