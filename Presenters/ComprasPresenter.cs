using Ocean_Desk_dv.Models.DTOs;
using Ocean_Desk_dv.Services.Interfaces_Services;
using Ocean_Desk_dv.View.Interfaces;

namespace Ocean_Desk_dv.Presenters;

/// <summary>Coordina las acciones de la pantalla Compras sin depender de controles WinForms.</summary>
public sealed class ComprasPresenter : IDisposable
{
    private readonly IComprasView _view;
    private readonly IComprasRepository _repository;
    private bool _disposed;

    public ComprasPresenter(IComprasView view, IComprasRepository repository)
    {
        _view = view ?? throw new ArgumentNullException(nameof(view));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));

        _view.CargaSolicitada += OnCargaSolicitada;
        _view.FiltrosCambiados += OnFiltrosCambiados;
        _view.CompraSeleccionadaCambiada += OnCompraSeleccionadaCambiada;
        _view.NuevaCompraSolicitada += OnNuevaCompraSolicitada;
        _view.AgregarDetalleSolicitado += OnAgregarDetalleSolicitado;
        _view.GuardarCompraSolicitado += OnGuardarCompraSolicitado;
        _view.CancelarCompraSolicitado += OnCancelarCompraSolicitado;
        _view.RegistrarRecepcionSolicitado += OnRegistrarRecepcionSolicitado;
    }

    public void Inicializar()
    {
        _view.MostrarProveedores(_repository.ObtenerProveedoresActivos());
        _view.HabilitarCaptura(false);
        ActualizarListado();
    }

    private void OnCargaSolicitada(object? sender, EventArgs e) => Inicializar();

    private void OnFiltrosCambiados(object? sender, EventArgs e) => ActualizarListado();

    private void OnCompraSeleccionadaCambiada(object? sender, EventArgs e)
    {
        if (_view.CapturandoCompraNueva || !_view.CompraSeleccionadaId.HasValue)
            return;

        int id = _view.CompraSeleccionadaId.Value;
        CompraResumenDto? compra = _repository.ObtenerCompra(id);
        if (compra is null) return;

        _view.MostrarCompraSeleccionada(compra, _repository.ObtenerDetalles(id));
    }

    private void OnNuevaCompraSolicitada(object? sender, EventArgs e)
    {
        _view.PrepararNuevaCompra();
    }

    private void OnAgregarDetalleSolicitado(object? sender, EventArgs e)
    {
        if (!_view.CapturandoCompraNueva)
        {
            _view.MostrarMensaje("Pulse «Nueva compra» antes de agregar ingredientes.");
            return;
        }

        IReadOnlyList<ProductoCompraDto> productos = _repository.ObtenerIngredientesActivos();
        if (productos.Count == 0)
        {
            _view.MostrarMensaje("No hay ingredientes activos con unidad de medida. Revise el catálogo de Productos.", true);
            return;
        }

        DetalleCompraCapturaDto? detalle = _view.SolicitarDetalleCompra(productos);
        if (detalle is null) return;

        if (detalle.Quantity <= 0m || detalle.UnitCost < 0m)
        {
            _view.MostrarMensaje("La cantidad debe ser mayor que cero y el costo no puede ser negativo.", true);
            return;
        }

        // Un código de lote no puede repetirse para el mismo ingrediente,
        // aunque se capture con una fecha distinta. Sin código, se evita repetir
        // el mismo ingrediente con la misma fecha de vencimiento.
        string? nuevoCodigoLote = string.IsNullOrWhiteSpace(detalle.LotCode)
            ? null
            : detalle.LotCode.Trim();

        bool duplicado = _view.SolicitudActual.Details.Any(d =>
            d.ProductId == detalle.ProductId &&
            ((!string.IsNullOrWhiteSpace(nuevoCodigoLote) &&
              !string.IsNullOrWhiteSpace(d.LotCode) &&
              string.Equals(d.LotCode.Trim(), nuevoCodigoLote, StringComparison.OrdinalIgnoreCase)) ||
             (string.IsNullOrWhiteSpace(nuevoCodigoLote) &&
              string.IsNullOrWhiteSpace(d.LotCode) &&
              d.ExpirationDate == detalle.ExpirationDate)));
        if (duplicado)
        {
            _view.MostrarMensaje("Ese ingrediente y código de lote ya están agregados; use un código diferente para otro lote.");
            return;
        }

        var detalles = _view.SolicitudActual.Details.ToList();
        detalles.Add(detalle);
        _view.MostrarDetalleCapturado(detalles);
    }

    private void OnGuardarCompraSolicitado(object? sender, EventArgs e)
    {
        if (!_view.CapturandoCompraNueva)
        {
            _view.MostrarMensaje("Pulse «Nueva compra» para registrar una compra.");
            return;
        }

        SolicitudCompraDto solicitud = _view.SolicitudActual;
        if (solicitud.SupplierId <= 0)
        {
            _view.MostrarMensaje("Seleccione un proveedor.", true);
            return;
        }
        if (solicitud.Details.Count == 0)
        {
            _view.MostrarMensaje("Agregue al menos un ingrediente antes de guardar.", true);
            return;
        }

        ResultadoCompraDto resultado = _repository.RegistrarCompra(solicitud);
        _view.MostrarMensaje(resultado.Mensaje, !resultado.Exito);
        if (!resultado.Exito) return;

        _view.HabilitarCaptura(false);
        ActualizarListado();
    }

    private void OnCancelarCompraSolicitado(object? sender, EventArgs e)
    {
        if (_view.CapturandoCompraNueva)
        {
            _view.HabilitarCaptura(false);
            ActualizarListado();
            return;
        }

        if (!_view.CompraSeleccionadaId.HasValue)
        {
            _view.MostrarMensaje("Seleccione una compra pendiente para cancelarla.");
            return;
        }

        ResultadoCompraDto resultado = _repository.CancelarCompra(_view.CompraSeleccionadaId.Value);
        _view.MostrarMensaje(resultado.Mensaje, !resultado.Exito);
        if (resultado.Exito) ActualizarListado();
    }

    private void OnRegistrarRecepcionSolicitado(object? sender, EventArgs e)
    {
        if (!_view.CompraSeleccionadaId.HasValue)
        {
            _view.MostrarMensaje("Seleccione una compra pendiente para registrar su recepción.");
            return;
        }

        ResultadoCompraDto resultado = _repository.RegistrarRecepcion(_view.CompraSeleccionadaId.Value);
        _view.MostrarMensaje(resultado.Mensaje, !resultado.Exito);
        if (resultado.Exito) ActualizarListado();
    }

    private void ActualizarListado() => _view.MostrarCompras(_repository.ObtenerCompras(_view.FiltroActual));

    public void Dispose()
    {
        if (_disposed) return;
        _view.CargaSolicitada -= OnCargaSolicitada;
        _view.FiltrosCambiados -= OnFiltrosCambiados;
        _view.CompraSeleccionadaCambiada -= OnCompraSeleccionadaCambiada;
        _view.NuevaCompraSolicitada -= OnNuevaCompraSolicitada;
        _view.AgregarDetalleSolicitado -= OnAgregarDetalleSolicitado;
        _view.GuardarCompraSolicitado -= OnGuardarCompraSolicitado;
        _view.CancelarCompraSolicitado -= OnCancelarCompraSolicitado;
        _view.RegistrarRecepcionSolicitado -= OnRegistrarRecepcionSolicitado;
        _repository.Dispose();
        _disposed = true;
    }
}
