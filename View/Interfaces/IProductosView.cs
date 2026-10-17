using System;
using System.Collections.Generic;
using Ocean_Desk_dv.Models.DTOs;

namespace Ocean_Desk_dv.View.Interfaces;

/// <summary>
/// Contrato entre FrmProductos y ProductosPresenter.
/// Expone los datos introducidos por el usuario, los eventos de la interfaz y los métodos necesarios
/// para presentar resultados sin permitir que el Presenter dependa directamente de controles WinForms.
/// </summary>
public interface IProductosView
{
    // Datos del formulario de producto

    /// <summary>Texto escrito en el campo de búsqueda del catálogo.</summary>
    string TextoBusqueda { get; }

    /// <summary>Identificador del producto seleccionado en el catálogo; null si no hay selección.</summary>
    int? ProductoSeleccionadoId { get; }

    /// <summary>Datos actuales del formulario para crear o editar un producto terminado.</summary>
    GuardarProductoDto DatosFormularioProducto { get; }

    /// <summary>Identificador del producto seleccionado en la pestaña Receta; null si no hay selección.</summary>
    int? ProductoRecetaSeleccionadoId { get; }

    /// <summary>Instrucciones de preparación introducidas para la receta.</summary>
    string InstruccionesReceta { get; }

    /// <summary>Identificador del ingrediente seleccionado en el selector; null si no hay selección.</summary>
    int? IngredienteSeleccionadoId { get; }

    /// <summary>Cantidad introducida para el ingrediente, expresada en su unidad base.</summary>
    decimal CantidadIngrediente { get; }

    /// <summary>Notas opcionales introducidas para el ingrediente seleccionado.</summary>
    string? NotasIngrediente { get; }

    /// <summary>Identificador del ingrediente seleccionado en la tabla de receta; null si no hay selección.</summary>
    int? DetalleIngredienteSeleccionadoId { get; }

    /// <summary>Detalles de receta que actualmente aparecen en la tabla, incluidos los cambios aún no guardados.</summary>
    IReadOnlyList<DetalleRecetaDto> DetallesRecetaActuales { get; }

    // Métodos para presentar información en el formulario

    /// <summary>Muestra los productos en la tabla del catálogo.</summary>
    void MostrarProductos(IReadOnlyList<ProductoCatalogoDto> productos);

    /// <summary>Llena el selector de categorías.</summary>
    void MostrarCategorias(IReadOnlyList<CategoriaProductoDto> categorias);

    /// <summary>Llena el selector de unidades de medida.</summary>
    void MostrarUnidades(IReadOnlyList<UnidadMedidaDto> unidades);

    /// <summary>Llena el selector de productos terminados de la pestaña Receta.</summary>
    void MostrarProductosParaReceta(IReadOnlyList<ProductoRecetaSelectorDto> productos);

    /// <summary>Muestra los ingredientes disponibles para agregarlos a una receta.</summary>
    void MostrarIngredientesDisponibles(IReadOnlyList<IngredienteSelectorDto> ingredientes);

    /// <summary>Carga los datos de un producto en los controles de edición.</summary>
    void CargarProductoEnFormulario(ProductoCatalogoDto producto);

    /// <summary>Limpia los controles del formulario y lo prepara para registrar un producto nuevo.</summary>
    void LimpiarFormularioProducto();

    /// <summary>Muestra los detalles de la receta seleccionada en la tabla de ingredientes.</summary>
    void MostrarDetallesReceta(IReadOnlyList<DetalleRecetaDto> detalles);

    /// <summary>Muestra las instrucciones de la receta en el control correspondiente.</summary>
    void MostrarInstruccionesReceta(string instrucciones);

    /// <summary>Presenta un mensaje informativo o de error al usuario.</summary>
    /// <param name="mensaje">Texto que explica el resultado.</param>
    /// <param name="titulo">Título de la ventana de mensaje.</param>
    /// <param name="esError">Indica si el mensaje representa un error.</param>
    void MostrarMensaje(string mensaje, string titulo = "Productos", bool esError = false);

    // Eventos que el formulario notificará al Presenter

    /// <summary>Se produce cuando cambia el texto de búsqueda.</summary>
    event EventHandler? BusquedaCambiada;

    /// <summary>Se produce cuando el usuario solicita registrar un producto nuevo.</summary>
    event EventHandler? NuevoProductoSolicitado;

    /// <summary>Se produce cuando el usuario solicita editar el producto seleccionado.</summary>
    event EventHandler? EditarProductoSolicitado;

    /// <summary>Se produce cuando el usuario solicita cambiar el estado del producto seleccionado.</summary>
    event EventHandler? CambiarEstadoProductoSolicitado;

    /// <summary>Se produce cuando el usuario solicita limpiar el formulario de producto.</summary>
    event EventHandler? LimpiarProductoSolicitado;

    /// <summary>Se produce cuando el usuario solicita guardar el producto del formulario.</summary>
    event EventHandler? GuardarProductoSolicitado;

    /// <summary>Se produce cuando cambia la selección de producto en el catálogo.</summary>
    event EventHandler? ProductoSeleccionadoCambiado;

    /// <summary>Se produce cuando cambia el producto seleccionado en la pestaña Receta.</summary>
    event EventHandler? ProductoRecetaSeleccionadoCambiado;

    /// <summary>Se produce cuando el usuario solicita agregar un ingrediente a la receta actual.</summary>
    event EventHandler? AgregarIngredienteSolicitado;

    /// <summary>Se produce cuando el usuario solicita editar el ingrediente seleccionado de la receta.</summary>
    event EventHandler? EditarIngredienteSolicitado;

    /// <summary>Se produce cuando el usuario solicita quitar un ingrediente de la receta actual.</summary>
    event EventHandler? QuitarIngredienteSolicitado;

    /// <summary>Se produce cuando el usuario solicita guardar la receta y sus detalles.</summary>
    event EventHandler? GuardarRecetaSolicitado;
}
