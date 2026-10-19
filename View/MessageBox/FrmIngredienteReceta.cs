using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Ocean_Desk_dv.Models.DTOs;
using Ocean_Desk_dv.View.Localization;
using Ocean_Desk_dv.UI.MessageBox;
using Ocean_Desk_dv.View.MessageBox;
namespace Ocean_Desk_dv.View.Catalogs;

/// <summary>
/// Dialog used to add an ingredient to a recipe or edit the quantity and notes of an existing line.
/// </summary>
public partial class FrmIngredienteReceta : Form
{
    private readonly DetalleRecetaDto? _detalleActual;

    /// <summary>Gets the ingredient line confirmed by the user, or null if the dialog was cancelled.</summary>
    public DetalleRecetaDto? DetalleResultado { get; private set; }

    /// <summary>Initializes the dialog for adding a new ingredient or editing an existing recipe line.</summary>
    /// <param name="ingredientes">Active ingredients that can be assigned to a recipe.</param>
    /// <param name="detalleActual">Existing line when editing; null when adding.</param>
    public FrmIngredienteReceta(
        IReadOnlyList<IngredienteSelectorDto> ingredientes,
        DetalleRecetaDto? detalleActual = null)
    {
        InitializeComponent();
        _detalleActual = detalleActual;

        List<IngredienteSelectorDto> origen = ingredientes?.ToList() ?? new List<IngredienteSelectorDto>();

        // Keep the current ingredient editable even if it was later deactivated; the user is only editing its line.
        if (_detalleActual is not null && origen.All(i => i.ProductId != _detalleActual.IngredientProductId))
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

        cmbIngrediente.Format += FormatearIngrediente;
        cmbIngrediente.DisplayMember = nameof(IngredienteSelectorDto.TextoMostrar);
        cmbIngrediente.ValueMember = nameof(IngredienteSelectorDto.ProductId);
        cmbIngrediente.DataSource = origen;

        if (_detalleActual is not null)
        {
            Text = "Editar ingrediente de receta";
            lblTitulo.Text = "Editar ingrediente";
            lblDescripcion.Text = "Ajusta la cantidad necesaria y las notas de preparación.";
            cmbIngrediente.SelectedValue = _detalleActual.IngredientProductId;
            cmbIngrediente.Enabled = false;
            btnAceptar.Text = "Guardar cambios";

            nudCantidad.Value = Math.Max(nudCantidad.Minimum,
                Math.Min(nudCantidad.Maximum, _detalleActual.Quantity));
            txtNotas.Text = _detalleActual.Notes ?? string.Empty;
        }
        else
        {
            Text = "Agregar ingrediente a receta";
            lblTitulo.Text = "Agregar ingrediente";
            lblDescripcion.Text = "Selecciona un ingrediente y define la cantidad para una porción.";
            if (cmbIngrediente.Items.Count > 0)
                cmbIngrediente.SelectedIndex = 0;
            btnAceptar.Text = "Agregar ingrediente";
        }

        if (origen.Count == 0)
        {
            lblAyuda.Text = "No hay ingredientes activos con una unidad base activa.";
            cmbIngrediente.Enabled = false;
            nudCantidad.Enabled = false;
            txtNotas.Enabled = false;
            btnAceptar.Enabled = false;
        }
        else
        {
            ActualizarAyudaUnidad();
        }

        cmbIngrediente.SelectedValueChanged += (_, _) => ActualizarAyudaUnidad();
        btnAceptar.Click += (_, _) => Confirmar();
    }

    /// <summary>Formats the ingredient selector in Spanish without changing database values.</summary>
    private static void FormatearIngrediente(object? sender, ListControlConvertEventArgs e)
    {
        e.Value = CatalogoTraducciones.TextoCombo(e.ListItem);
        e.FormattingApplied = true;
    }

    /// <summary>Explains which base unit applies to the selected ingredient.</summary>
    private void ActualizarAyudaUnidad()
    {
        if (cmbIngrediente.SelectedItem is IngredienteSelectorDto ingrediente)
        {
            string unidad = CatalogoTraducciones.TraducirUnidad(ingrediente.UnitCode, ingrediente.UnitName);
            lblAyuda.Text = $"Cantidad por porción. Unidad base: {unidad}.";
        }
    }

    /// <summary>Validates the input and returns the recipe line to the Presenter.</summary>
    private void Confirmar()
    {
        if (cmbIngrediente.SelectedItem is not IngredienteSelectorDto ingrediente)
        {
            MessageBox.Show(this, "Seleccione un ingrediente válido.", "Ingrediente requerido",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (nudCantidad.Value <= 0)
        {
            MessageBox.Show(this, "La cantidad debe ser mayor que cero.", "Cantidad inválida",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            nudCantidad.Focus();
            return;
        }

        string notas = txtNotas.Text.Trim();
        if (notas.Length > 250)
        {
            MessageBox.Show(this, "Las notas no pueden superar los 250 caracteres.", "Notas demasiado largas",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtNotas.Focus();
            return;
        }

        DetalleResultado = new DetalleRecetaDto
        {
            RecipeDetailId = _detalleActual?.RecipeDetailId ?? 0,
            IngredientProductId = ingrediente.ProductId,
            IngredientCode = ingrediente.ProductCode,
            IngredientName = ingrediente.ProductName,
            UnitCode = ingrediente.UnitCode,
            UnitName = ingrediente.UnitName,
            Quantity = nudCantidad.Value,
            Notes = string.IsNullOrWhiteSpace(notas) ? null : notas
        };

        DialogResult = DialogResult.OK;
        Close();
    }
}
