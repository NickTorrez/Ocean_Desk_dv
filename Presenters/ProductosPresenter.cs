using System;
using System.Collections.Generic;
using System.Linq;
using Ocean_Desk_dv.Models.DTOs;
using Ocean_Desk_dv.Services.Interfaces_Services;
using Ocean_Desk_dv.View.Interfaces;

namespace Ocean_Desk_dv.Presenters;

/// <summary>
/// Coordina las acciones del formulario de Productos con el repositorio.
/// No accede directamente a controles WinForms ni ejecuta consultas SQL.
/// </summary>
public sealed class ProductosPresenter : IDisposable
{
    private readonly IProductosView _view;
    private readonly IProductosRepository _repository;
    private IReadOnlyList<ProductoCatalogoDto> _productos = Array.Empty<ProductoCatalogoDto>();
    private IReadOnlyList<IngredienteSelectorDto> _ingredientes = Array.Empty<IngredienteSelectorDto>();
    private readonly List<DetalleRecetaDto> _detallesTemporales = new();
    private bool _disposed;

    /// <summary>
    /// Crea el Presenter y suscribe los eventos de la vista.
    /// </summary>
    /// <param name="view">Formulario que implementa el contrato IProductosView.</param>
    /// <param name="repository">Repositorio encargado del acceso a datos.</param>
    public ProductosPresenter(IProductosView view, IProductosRepository repository)
    {
        _view = view ?? throw new ArgumentNullException(nameof(view));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        SuscribirEventos();
    }

    /// <summary>Realiza la carga inicial de catálogos, productos e ingredientes.</summary>
    public void Inicializar()
    {
        EjecutarSeguro(() =>
        {
            _view.MostrarCategorias(_repository.ObtenerCategoriasActivas());
            _view.MostrarUnidades(_repository.ObtenerUnidadesActivas());
            _productos = _repository.ObtenerProductos(_view.TextoBusqueda);
            _view.MostrarProductos(_productos);
            _view.MostrarProductosParaReceta(_repository.ObtenerProductosTerminadosParaReceta());
            _ingredientes = _repository.ObtenerIngredientesActivos();
            _view.MostrarIngredientesDisponibles(_ingredientes);
            _view.MostrarDetallesReceta(Array.Empty<DetalleRecetaDto>());
            _view.MostrarInstruccionesReceta(string.Empty);
        });
    }

    private void SuscribirEventos()
    {
        _view.BusquedaCambiada += AlCambiarBusqueda;
        _view.NuevoProductoSolicitado += AlSolicitarNuevoProducto;
        _view.EditarProductoSolicitado += AlSolicitarEditarProducto;
        _view.CambiarEstadoProductoSolicitado += AlSolicitarCambiarEstado;
        //_view.LimpiarProductoSolicitado += AlSolicitarLimpiarProducto;
        _view.GuardarProductoSolicitado += AlSolicitarGuardarProducto;
        _view.ProductoSeleccionadoCambiado += AlCambiarProductoSeleccionado;
        _view.ProductoRecetaSeleccionadoCambiado += AlCambiarProductoReceta;
        _view.AgregarIngredienteSolicitado += AlSolicitarAgregarIngrediente;
        _view.EditarIngredienteSolicitado += AlSolicitarEditarIngrediente;
        _view.QuitarIngredienteSolicitado += AlSolicitarQuitarIngrediente;
        _view.GuardarRecetaSolicitado += AlSolicitarGuardarReceta;
    }

    /// <summary>Actualiza el catálogo cuando cambia el texto de búsqueda.</summary>
    private void AlCambiarBusqueda(object? sender, EventArgs e) => EjecutarSeguro(() =>
    {
        _productos = _repository.ObtenerProductos(_view.TextoBusqueda);
        _view.MostrarProductos(_productos);
    });

    /// <summary>Prepara la vista para capturar un producto nuevo.</summary>
    private void AlSolicitarNuevoProducto(object? sender, EventArgs e) => _view.LimpiarFormularioProducto();

    /// <summary>Carga en el formulario los datos del producto seleccionado.</summary>
    private void AlSolicitarEditarProducto(object? sender, EventArgs e) => EjecutarSeguro(() =>
    {
        ProductoCatalogoDto? producto = BuscarProductoSeleccionado();
        if (producto is null)
        {
            _view.MostrarMensaje("Seleccione un producto del catálogo antes de editar.", esError: true);
            return;
        }
        _view.CargarProductoEnFormulario(producto);
    });

    /// <summary>Activa o desactiva el producto seleccionado y refresca el catálogo.</summary>
    private void AlSolicitarCambiarEstado(object? sender, EventArgs e) => EjecutarSeguro(() =>
    {
        if (!_view.ProductoSeleccionadoId.HasValue)
        {
            _view.MostrarMensaje("Seleccione un producto para cambiar su estado.", esError: true);
            return;
        }
        ResultadoOperacionDto resultado = _repository.CambiarEstadoProducto(_view.ProductoSeleccionadoId.Value);
        _view.MostrarMensaje(resultado.Mensaje, esError: !resultado.Exito);
        if (resultado.Exito) RecargarProductos();
    });

    /// <summary>Limpia los controles del formulario de producto.</summary>
    private void AlSolicitarLimpiarProducto(object? sender, EventArgs e) => _view.LimpiarFormularioProducto();

    /// <summary>Valida y solicita al repositorio guardar el producto capturado.</summary>
    private void AlSolicitarGuardarProducto(object? sender, EventArgs e) => EjecutarSeguro(() =>
    {
        GuardarProductoDto datos = _view.DatosFormularioProducto;
        ResultadoOperacionDto resultado = _repository.GuardarProducto(datos, out int productoId);
        _view.MostrarMensaje(resultado.Mensaje, esError: !resultado.Exito);
        if (!resultado.Exito) return;

        RecargarProductos();
        _view.LimpiarFormularioProducto();
    });

    /// <summary>Recarga los datos del producto seleccionado en el catálogo.</summary>
    private void AlCambiarProductoSeleccionado(object? sender, EventArgs e) { /* La selección se usa al solicitar editar o cambiar estado. */ }

    /// <summary>Carga la receta existente o prepara una receta nueva para el producto seleccionado.</summary>
    private void AlCambiarProductoReceta(object? sender, EventArgs e) => EjecutarSeguro(() =>
    {
        _detallesTemporales.Clear();
        if (!_view.ProductoRecetaSeleccionadoId.HasValue)
        {
            _view.MostrarDetallesReceta(_detallesTemporales);
            _view.MostrarInstruccionesReceta(string.Empty);
            return;
        }

        RecetaProductoDto? receta = _repository.ObtenerReceta(_view.ProductoRecetaSeleccionadoId.Value);
        if (receta is not null) _detallesTemporales.AddRange(receta.Detalles);
        _view.MostrarDetallesReceta(_detallesTemporales.ToArray());
        _view.MostrarInstruccionesReceta(receta?.Instructions ?? string.Empty);
    });

    /// <summary>Agrega el ingrediente seleccionado a la lista temporal de la receta.</summary>
    private void AlSolicitarAgregarIngrediente(object? sender, EventArgs e) => EjecutarSeguro(() =>
    {
        if (!_view.IngredienteSeleccionadoId.HasValue)
        {
            _view.MostrarMensaje("Seleccione un ingrediente.", esError: true);
            return;
        }
        if (_view.CantidadIngrediente <= 0)
        {
            _view.MostrarMensaje("La cantidad debe ser mayor que cero.", esError: true);
            return;
        }

        IngredienteSelectorDto? ingrediente = _ingredientes.FirstOrDefault(i => i.ProductId == _view.IngredienteSeleccionadoId.Value);
        if (ingrediente is null)
        {
            _view.MostrarMensaje("El ingrediente seleccionado ya no está disponible.", esError: true);
            return;
        }
        if (_detallesTemporales.Any(d => d.IngredientProductId == ingrediente.ProductId))
        {
            _view.MostrarMensaje("Ese ingrediente ya está agregado a la receta. Edite su cantidad en lugar de duplicarlo.", esError: true);
            return;
        }

        _detallesTemporales.Add(new DetalleRecetaDto
        {
            IngredientProductId = ingrediente.ProductId,
            IngredientCode = ingrediente.ProductCode,
            IngredientName = ingrediente.ProductName,
            UnitCode = ingrediente.UnitCode,
            UnitName = ingrediente.UnitName,
            Quantity = _view.CantidadIngrediente,
            Notes = _view.NotasIngrediente
        });
        MostrarDetallesTemporales();
    });

    /// <summary>Actualiza la cantidad y las notas del ingrediente seleccionado en la tabla de receta.</summary>
    private void AlSolicitarEditarIngrediente(object? sender, EventArgs e) => EjecutarSeguro(() =>
    {
        if (!_view.DetalleIngredienteSeleccionadoId.HasValue)
        {
            _view.MostrarMensaje("Seleccione una línea de ingrediente para editar.", esError: true);
            return;
        }
        if (_view.CantidadIngrediente <= 0)
        {
            _view.MostrarMensaje("La cantidad debe ser mayor que cero.", esError: true);
            return;
        }

        int ingredienteId = _view.DetalleIngredienteSeleccionadoId.Value;
        int indice = _detallesTemporales.FindIndex(d => d.IngredientProductId == ingredienteId);
        if (indice < 0)
        {
            _view.MostrarMensaje("No se encontró el ingrediente seleccionado.", esError: true);
            return;
        }
        DetalleRecetaDto anterior = _detallesTemporales[indice];
        _detallesTemporales[indice] = new DetalleRecetaDto
        {
            RecipeDetailId = anterior.RecipeDetailId,
            IngredientProductId = anterior.IngredientProductId,
            IngredientCode = anterior.IngredientCode,
            IngredientName = anterior.IngredientName,
            UnitCode = anterior.UnitCode,
            UnitName = anterior.UnitName,
            Quantity = _view.CantidadIngrediente,
            Notes = _view.NotasIngrediente
        };
        MostrarDetallesTemporales();
    });

    /// <summary>Quita de la lista temporal el ingrediente seleccionado.</summary>
    private void AlSolicitarQuitarIngrediente(object? sender, EventArgs e) => EjecutarSeguro(() =>
    {
        if (!_view.DetalleIngredienteSeleccionadoId.HasValue)
        {
            _view.MostrarMensaje("Seleccione una línea de ingrediente para quitar.", esError: true);
            return;
        }
        int id = _view.DetalleIngredienteSeleccionadoId.Value;
        int eliminados = _detallesTemporales.RemoveAll(d => d.IngredientProductId == id);
        if (eliminados == 0)
        {
            _view.MostrarMensaje("No se encontró el ingrediente seleccionado.", esError: true);
            return;
        }
        MostrarDetallesTemporales();
    });

    /// <summary>Guarda la receta completa y sus detalles como una operación lógica.</summary>
    private void AlSolicitarGuardarReceta(object? sender, EventArgs e) => EjecutarSeguro(() =>
    {
        if (!_view.ProductoRecetaSeleccionadoId.HasValue)
        {
            _view.MostrarMensaje("Seleccione el producto terminado al que pertenece la receta.", esError: true);
            return;
        }
        if (_detallesTemporales.Count == 0)
        {
            _view.MostrarMensaje("Agregue al menos un ingrediente antes de guardar la receta.", esError: true);
            return;
        }

        var solicitud = new GuardarRecetaDto
        {
            ProductId = _view.ProductoRecetaSeleccionadoId.Value,
            Instructions = _view.InstruccionesReceta,
            IsActive = true,
            Detalles = _detallesTemporales.ToArray()
        };
        ResultadoOperacionDto resultado = _repository.GuardarReceta(solicitud);
        _view.MostrarMensaje(resultado.Mensaje, esError: !resultado.Exito);
        if (resultado.Exito) AlCambiarProductoReceta(this, EventArgs.Empty);
    });

    private ProductoCatalogoDto? BuscarProductoSeleccionado() =>
        _view.ProductoSeleccionadoId.HasValue
            ? _productos.FirstOrDefault(p => p.ProductId == _view.ProductoSeleccionadoId.Value)
            : null;

    private void RecargarProductos()
    {
        _productos = _repository.ObtenerProductos(_view.TextoBusqueda);
        _view.MostrarProductos(_productos);
        _view.MostrarProductosParaReceta(_repository.ObtenerProductosTerminadosParaReceta());
    }

    private void MostrarDetallesTemporales() => _view.MostrarDetallesReceta(_detallesTemporales.ToArray());

    /// <summary>Ejecuta una acción y presenta cualquier excepción con un mensaje comprensible.</summary>
    private void EjecutarSeguro(Action accion)
    {
        try { accion(); }
        catch (Exception ex)
        {
            _view.MostrarMensaje($"No se pudo completar la operación. Detalle: {ex.Message}", "Error en Productos", true);
        }
    }

    /// <summary>Libera los recursos del Presenter y desuscribe los eventos para evitar referencias innecesarias.</summary>
    public void Dispose()
    {
        if (_disposed) return;
        _view.BusquedaCambiada -= AlCambiarBusqueda;
        _view.NuevoProductoSolicitado -= AlSolicitarNuevoProducto;
        _view.EditarProductoSolicitado -= AlSolicitarEditarProducto;
        _view.CambiarEstadoProductoSolicitado -= AlSolicitarCambiarEstado;
        //_view.LimpiarProductoSolicitado -= AlSolicitarLimpiarProducto;
        _view.GuardarProductoSolicitado -= AlSolicitarGuardarProducto;
        _view.ProductoSeleccionadoCambiado -= AlCambiarProductoSeleccionado;
        _view.ProductoRecetaSeleccionadoCambiado -= AlCambiarProductoReceta;
        _view.AgregarIngredienteSolicitado -= AlSolicitarAgregarIngrediente;
        _view.EditarIngredienteSolicitado -= AlSolicitarEditarIngrediente;
        _view.QuitarIngredienteSolicitado -= AlSolicitarQuitarIngrediente;
        _view.GuardarRecetaSolicitado -= AlSolicitarGuardarReceta;
        _repository.Dispose();
        _disposed = true;
    }
}
