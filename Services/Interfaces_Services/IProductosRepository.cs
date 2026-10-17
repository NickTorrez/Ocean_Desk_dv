using System;
using System.Collections.Generic;
using Ocean_Desk_dv.Models.DTOs;

namespace Ocean_Desk_dv.Services.Interfaces_Services;

/// <summary>
/// Define las operaciones de acceso a datos que necesita el módulo Productos.
/// La implementación concreta consultará SQL Server mediante Entity Framework Core.
/// El Presenter dependerá de este contrato y no de la clase concreta del repositorio.
/// </summary>
public interface IProductosRepository : IDisposable
{
    /// <summary>
    /// Obtiene los productos terminados para llenar el catálogo.
    /// Puede recibir un texto de búsqueda y permite decidir si se incluyen productos inactivos.
    /// </summary>
    /// <param name="filtro">Texto opcional para buscar por código o nombre.</param>
    /// <param name="incluirInactivos">Si es true, también devuelve productos inactivos.</param>
    /// <returns>Lista de productos preparados para mostrarse en la vista.</returns>
    IReadOnlyList<ProductoCatalogoDto> ObtenerProductos(string? filtro = null, bool incluirInactivos = true);

    /// <summary>Obtiene las categorías activas disponibles para asignar a un producto.</summary>
    IReadOnlyList<CategoriaProductoDto> ObtenerCategoriasActivas();

    /// <summary>Obtiene las unidades de medida activas para el selector del formulario.</summary>
    IReadOnlyList<UnidadMedidaDto> ObtenerUnidadesActivas();

    /// <summary>
    /// Crea un producto terminado o actualiza uno existente.
    /// Debe validar el código único y mantener las operaciones de datos en el repositorio.
    /// </summary>
    /// <param name="solicitud">Datos capturados en el formulario.</param>
    /// <param name="productoId">Identificador del producto creado o actualizado cuando la operación tiene éxito.</param>
    /// <returns>Resultado con el estado y un mensaje comprensible.</returns>
    ResultadoOperacionDto GuardarProducto(GuardarProductoDto solicitud, out int productoId);

    /// <summary>Cambia el estado activo/inactivo de un producto existente.</summary>
    ResultadoOperacionDto CambiarEstadoProducto(int productoId);

    /// <summary>Obtiene los productos terminados que pueden seleccionarse para administrar recetas.</summary>
    IReadOnlyList<ProductoRecetaSelectorDto> ObtenerProductosTerminadosParaReceta();

    /// <summary>Obtiene los ingredientes activos que pueden agregarse a una receta, incluyendo su unidad base.</summary>
    IReadOnlyList<IngredienteSelectorDto> ObtenerIngredientesActivos();

    /// <summary>
    /// Obtiene la receta y sus detalles para un producto terminado.
    /// Devuelve null cuando el producto todavía no tiene una receta registrada.
    /// </summary>
    RecetaProductoDto? ObtenerReceta(int productoId);

    /// <summary>
    /// Guarda una receta y sus detalles como una sola operación lógica.
    /// La implementación deberá utilizar una transacción para evitar guardar solo una parte de la receta.
    /// </summary>
    ResultadoOperacionDto GuardarReceta(GuardarRecetaDto solicitud);
}
