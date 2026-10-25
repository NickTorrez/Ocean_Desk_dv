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
using Ocean_Desk_dv.UI.MessageBox;
using Ocean_Desk_dv.View.Localization;

namespace Ocean_Desk_dv.View.MessageBox
{
    /// <summary>
    /// Formulario modal para agregar o editar un ingrediente de una receta.
    /// </summary>
    public partial class FrmIngredienteReceta : Form
    {
        private readonly DetalleRecetaDto? _detalleActual;

        /// <summary>
        /// Obtiene el detalle validado cuando el usuario confirma la operación.
        /// Es null si el usuario cancela o no confirma los datos.
        /// </summary>
        public DetalleRecetaDto? DetalleResultado { get; private set; }

        /// <summary>
        /// Crea el formulario modal para agregar o editar un ingrediente.
        /// </summary>
        /// <param name="ingredientes">Ingredientes permitidos para la receta.</param>
        /// <param name="detalleActual">
        /// Detalle de receta existente al editar; null al agregar.
        /// </param>
        public FrmIngredienteReceta(IReadOnlyList<IngredienteSelectorDto> ingredientes,
            DetalleRecetaDto? detalleActual = null)
        {
            InitializeComponent();

            _detalleActual = detalleActual;

            if (ingredientes is null)
            {
                throw new ArgumentNullException(nameof(ingredientes));
            }

            List<IngredienteSelectorDto> origen = ingredientes.ToList();

            // Conserva el ingrediente actual cuando se edita una receta,
            // aunque ya no aparezca entre los ingredientes activos.
            if (_detalleActual is not null &&
                !origen.Any(i =>
                    i.ProductId == _detalleActual.IngredientProductId))
            {
                origen.Add(new IngredienteSelectorDto
                {
                    ProductId = _detalleActual.IngredientProductId,
                    ProductCode = _detalleActual.IngredientCode,
                    ProductName = _detalleActual.IngredientName,
                    UnitCode = _detalleActual.UnitCode,
                    UnitName = _detalleActual.UnitName
                });
            }

            if (origen.Count == 0)
            {
                throw new ArgumentException(
                    "Debe existir al menos un ingrediente para abrir el formulario.",
                    nameof(ingredientes));
            }

            // Configuración del selector.
            cmbIngrediente.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbIngrediente.DisplayMember =
                nameof(IngredienteSelectorDto.TextoMostrar);
            cmbIngrediente.ValueMember =
                nameof(IngredienteSelectorDto.ProductId);

            cmbIngrediente.Format += FormatearIngrediente;
            cmbIngrediente.DataSource = origen;

            // Configuración de la cantidad.
            nudCantidad.DecimalPlaces = 4;
            nudCantidad.Minimum = 0.0001M;
            nudCantidad.Maximum = 99999999.9999M;
            nudCantidad.Increment = 0.1M;

            // Configuración de las notas.
            txtNotas.MaxLength = 250;

            // Configura los botones del cuadro modal.
            btnAceptar.DialogResult = DialogResult.None;
            btnCancelar.DialogResult = DialogResult.Cancel;

            AcceptButton = btnAceptar;
            CancelButton = btnCancelar;

            btnAceptar.Click += (_, _) => Confirmar();

            if (_detalleActual is not null)
            {
                // Modo edición: no se cambia el ingrediente de la línea.
                Text = "Editar ingrediente";
                lblTitulo.Text = "Editar ingrediente";
                lblDescripcion.Text = "Ajusta la cantidad necesaria y las notas de preparación.";

                cmbIngrediente.SelectedValue =
                    _detalleActual.IngredientProductId;

                cmbIngrediente.Enabled = false;

                nudCantidad.Value = Math.Max(
                    nudCantidad.Minimum,
                    Math.Min(
                        nudCantidad.Maximum,
                        _detalleActual.Quantity));

                txtNotas.Text = _detalleActual.Notes ?? string.Empty;
                btnAceptar.Text = "✓ GUARDAR CAMBIOS";
            }
            else
            {
                // Modo agregar.
                Text = "Agregar ingrediente";
                lblTitulo.Text = "Agregar ingrediente";
                lblDescripcion.Text =
                    "Selecciona un ingrediente y define la cantidad por porción.";

                if (cmbIngrediente.Items.Count > 0)
                {
                    cmbIngrediente.SelectedIndex = 0;
                }

                nudCantidad.Value = 1M;
                btnAceptar.Text = "+ AGREGAR INGREDIENTE";
            }

            cmbIngrediente.SelectedValueChanged +=
                (_, _) => ActualizarAyudaUnidad();

            ActualizarAyudaUnidad();
        }

        /// <summary>
        /// Formatea el texto visible del ComboBox en español.
        /// </summary>
        private static void FormatearIngrediente(
            object? sender,
            ListControlConvertEventArgs e)
        {
            e.Value = CatalogoTraducciones.TextoCombo(e.ListItem);
        }

        /// <summary>
        /// Muestra la unidad base correspondiente al ingrediente seleccionado.
        /// </summary>
        private void ActualizarAyudaUnidad()
        {
            if (cmbIngrediente.SelectedItem is not IngredienteSelectorDto ingrediente)
            {
                lblAyuda.Text = "Seleccione un ingrediente.";
                return;
            }

            string unidad = CatalogoTraducciones.TraducirUnidad(
                ingrediente.UnitCode,
                ingrediente.UnitName);

            lblAyuda.Text =
                $"La cantidad se expresa en la unidad base: {unidad}.";
        }

        /// <summary>
        /// Valida los datos capturados y devuelve el detalle confirmado.
        /// </summary>
        private void Confirmar()
        {
            if (cmbIngrediente.SelectedItem
                is not IngredienteSelectorDto ingrediente)
            {
                FrmMessageBox.Show(
                    "Seleccione un ingrediente válido.",
                    "Ingrediente requerido",
                    MessageType.Warning);

                cmbIngrediente.Focus();
                return;
            }

            if (nudCantidad.Value <= 0)
            {
                FrmMessageBox.Show(
                    "La cantidad debe ser mayor que cero.",
                    "Cantidad inválida",
                    MessageType.Warning);

                nudCantidad.Focus();
                return;
            }

            string notas = txtNotas.Text.Trim();

            if (notas.Length > 250)
            {
                FrmMessageBox.Show(
                    "Las notas no pueden superar los 250 caracteres.",
                    "Notas demasiado largas",
                    MessageType.Warning);

                txtNotas.Focus();
                return;
            }

            // No se escribe en la base de datos desde este formulario.
            // El Presenter mantiene la edición temporal y realiza el guardado.
            DetalleResultado = new DetalleRecetaDto
            {
                RecipeDetailId = _detalleActual?.RecipeDetailId ?? 0,
                IngredientProductId = ingrediente.ProductId,
                IngredientCode = ingrediente.ProductCode,
                IngredientName = ingrediente.ProductName,
                UnitCode = ingrediente.UnitCode,
                UnitName = ingrediente.UnitName,
                Quantity = nudCantidad.Value,
                Notes = string.IsNullOrWhiteSpace(notas)
                    ? null
                    : notas
            };

            DialogResult = DialogResult.OK;
            Close();
        }

    }

}

