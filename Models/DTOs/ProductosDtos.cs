using System;
using System.Collections.Generic;

namespace Ocean_Desk_dv.Models.DTOs;

/// <summary>
/// Representa un producto en el catálogo de Productos, con los datos necesarios para mostrarlo en la tabla.
/// No expone directamente la entidad Product a la interfaz visual.
/// </summary>
public sealed class ProductoCatalogoDto
{
    /// <summary>Identificador interno del producto.</summary>
    public int ProductId { get; init; }

    /// <summary>Código único que identifica al producto.</summary>
    public string ProductCode { get; init; } = string.Empty;

    /// <summary>Nombre que se muestra en el sistema.</summary>
    public string ProductName { get; init; } = string.Empty;

    /// <summary>Descripción opcional del producto.</summary>
    public string? Description { get; init; }

    /// <summary>Identificador de la categoría asignada.</summary>
    public int ProductCategoryId { get; init; }

    /// <summary>Nombre de la categoría, preparado para mostrar en la tabla.</summary>
    public string CategoryName { get; init; } = string.Empty;

    /// <summary>Precio de venta del producto terminado.</summary>
    public decimal UnitPrice { get; init; }

    /// <summary>Indica si el producto puede ofrecerse en el punto de venta.</summary>
    public bool IsAvailable { get; init; }

    /// <summary>Indica si el producto está activo en el catálogo.</summary>
    public bool IsActive { get; init; }

    /// <summary>Tipo del producto almacenado en la base de datos; para este catálogo se esperan productos terminados.</summary>
    public string ProductType { get; init; } = string.Empty;

    /// <summary>Identificador de la unidad de medida, cuando corresponda.</summary>
    public int? UnitOfMeasureId { get; init; }

    /// <summary>Código de la unidad de medida, por ejemplo PORTION o UNIT.</summary>
    public string? UnitCode { get; init; }

    /// <summary>Nombre de la unidad de medida para mostrar en pantalla.</summary>
    public string? UnitName { get; init; }
}

/// <summary>
/// Datos mínimos de una categoría activa para llenar el selector de categorías.
/// </summary>
public sealed class CategoriaProductoDto
{
    /// <summary>Identificador de la categoría.</summary>
    public int ProductCategoryId { get; init; }

    /// <summary>Nombre visible de la categoría.</summary>
    public string CategoryName { get; init; } = string.Empty;
}

/// <summary>
/// Datos mínimos de una unidad activa para llenar el selector de unidades de medida.
/// </summary>
public sealed class UnidadMedidaDto
{
    /// <summary>Identificador de la unidad de medida.</summary>
    public int UnitOfMeasureId { get; init; }

    /// <summary>Código de la unidad, por ejemplo PORTION, KG o UNIT.</summary>
    public string UnitCode { get; init; } = string.Empty;

    /// <summary>Nombre de la unidad que se mostrará al usuario.</summary>
    public string UnitName { get; init; } = string.Empty;

    /// <summary>Abreviatura o símbolo de la unidad.</summary>
    public string UnitSymbol { get; init; } = string.Empty;
}

/// <summary>
/// Contiene los datos capturados en el formulario al crear o editar un producto terminado.
/// La propiedad MinimumStock se omite porque pertenece a Inventory, no a Product.
/// </summary>
public sealed class GuardarProductoDto
{
    /// <summary>Identificador del producto; null significa que se está creando uno nuevo.</summary>
    public int? ProductId { get; init; }

    /// <summary>Código único escrito para el producto.</summary>
    public string ProductCode { get; init; } = string.Empty;

    /// <summary>Nombre del producto.</summary>
    public string ProductName { get; init; } = string.Empty;

    /// <summary>Descripción opcional.</summary>
    public string? Description { get; init; }

    /// <summary>Categoría seleccionada.</summary>
    public int ProductCategoryId { get; init; }

    /// <summary>Precio de venta.</summary>
    public decimal UnitPrice { get; init; }

    /// <summary>Unidad de venta asignada al producto terminado, por ejemplo porción o unidad.</summary>
    public int? UnitOfMeasureId { get; init; }

    /// <summary>Indica si el producto está disponible para venderse.</summary>
    public bool IsAvailable { get; init; }

    /// <summary>Indica si el producto está activo en el catálogo.</summary>
    public bool IsActive { get; init; }
}

/// <summary>
/// Producto terminado que puede seleccionarse para consultar o editar su receta.
/// </summary>
public sealed class ProductoRecetaSelectorDto
{
    /// <summary>Identificador interno del producto terminado.</summary>
    public int ProductId { get; init; }

    /// <summary>Código del producto terminado.</summary>
    public string ProductCode { get; init; } = string.Empty;

    /// <summary>Nombre visible del producto terminado.</summary>
    public string ProductName { get; init; } = string.Empty;

    /// <summary>Texto preparado para mostrarse en un ComboBox.</summary>
    public string TextoMostrar => $"{ProductCode} - {ProductName}";
}

/// <summary>
/// Ingrediente activo que puede agregarse a una receta.
/// La unidad base se muestra para que la cantidad se introduzca correctamente.
/// </summary>
public sealed class IngredienteSelectorDto
{
    /// <summary>Identificador del ingrediente (un registro de Product de tipo Ingredient).</summary>
    public int ProductId { get; init; }

    /// <summary>Código del ingrediente.</summary>
    public string ProductCode { get; init; } = string.Empty;

    /// <summary>Nombre del ingrediente.</summary>
    public string ProductName { get; init; } = string.Empty;

    /// <summary>Identificador de su unidad base.</summary>
    public int? UnitOfMeasureId { get; init; }

    /// <summary>Código de la unidad base, por ejemplo KG o L.</summary>
    public string UnitCode { get; init; } = string.Empty;

    /// <summary>Nombre de la unidad base, por ejemplo Kilogramo o Litro.</summary>
    public string UnitName { get; init; } = string.Empty;

    /// <summary>Texto preparado para mostrarse en un ComboBox.</summary>
    public string TextoMostrar => $"{ProductName} ({UnitCode})";
}

/// <summary>
/// Representa una línea de receta que se muestra en la tabla de ingredientes.
/// </summary>
public sealed class DetalleRecetaDto
{
    /// <summary>Identificador del detalle guardado; cero si todavía no se ha guardado.</summary>
    public int RecipeDetailId { get; init; }

    /// <summary>Identificador del ingrediente seleccionado.</summary>
    public int IngredientProductId { get; init; }

    /// <summary>Código del ingrediente.</summary>
    public string IngredientCode { get; init; } = string.Empty;

    /// <summary>Nombre del ingrediente que se muestra en la tabla.</summary>
    public string IngredientName { get; init; } = string.Empty;

    /// <summary>Código de la unidad base del ingrediente.</summary>
    public string UnitCode { get; init; } = string.Empty;

    /// <summary>Nombre de la unidad base del ingrediente.</summary>
    public string UnitName { get; init; } = string.Empty;

    /// <summary>Cantidad necesaria para preparar una porción, expresada en la unidad base del ingrediente.</summary>
    public decimal Quantity { get; init; }

    /// <summary>Nota opcional sobre el uso o preparación del ingrediente.</summary>
    public string? Notes { get; init; }
}

/// <summary>
/// Representa una receta completa cargada para un producto terminado.
/// </summary>
public sealed class RecetaProductoDto
{
    /// <summary>Identificador de la receta; null indica que todavía no existe una receta guardada.</summary>
    public int? RecipeId { get; init; }

    /// <summary>Identificador del producto terminado al que pertenece la receta.</summary>
    public int ProductId { get; init; }

    /// <summary>Instrucciones generales de preparación.</summary>
    public string? Instructions { get; init; }

    /// <summary>Indica si la receta está activa.</summary>
    public bool IsActive { get; init; }

    /// <summary>Ingredientes y cantidades que componen la receta.</summary>
    public IReadOnlyList<DetalleRecetaDto> Detalles { get; init; } = Array.Empty<DetalleRecetaDto>();
}

/// <summary>
/// Solicitud para guardar una receta y todos sus ingredientes.
/// El repositorio deberá guardar la receta y sus detalles dentro de una misma transacción.
/// </summary>
public sealed class GuardarRecetaDto
{
    /// <summary>Identificador del producto terminado cuya receta se guardará.</summary>
    public int ProductId { get; init; }

    /// <summary>Instrucciones generales; se recomienda indicar si la receta es provisional.</summary>
    public string? Instructions { get; init; }

    /// <summary>Estado de la receta.</summary>
    public bool IsActive { get; init; } = true;

    /// <summary>Ingredientes y cantidades por porción, en las unidades base de cada ingrediente.</summary>
    public IReadOnlyList<DetalleRecetaDto> Detalles { get; init; } = Array.Empty<DetalleRecetaDto>();
}
