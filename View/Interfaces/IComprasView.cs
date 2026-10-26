using Ocean_Desk_dv.Models.DTOs;

namespace Ocean_Desk_dv.View.Interfaces;

public interface IComprasView
{
    FiltroComprasDto FiltroActual { get; }
    int? CompraSeleccionadaId { get; }
    bool CapturandoCompraNueva { get; }
    SolicitudCompraDto SolicitudActual { get; }

    event EventHandler? FiltrosCambiados;
    event EventHandler? CompraSeleccionadaCambiada;
    event EventHandler? NuevaCompraSolicitada;
    event EventHandler? AgregarDetalleSolicitado;
    event EventHandler? GuardarCompraSolicitado;
    event EventHandler? CancelarCompraSolicitado;
    event EventHandler? RegistrarRecepcionSolicitado;

    void MostrarProveedores(IReadOnlyList<ProveedorCompraDto> proveedores);
    void MostrarCompras(IReadOnlyList<CompraResumenDto> compras);
    void MostrarCompraSeleccionada(CompraResumenDto compra, IReadOnlyList<CompraDetalleDto> detalles);
    void MostrarDetalleCapturado(IReadOnlyList<DetalleCompraCapturaDto> detalles);
    void PrepararNuevaCompra();
    void HabilitarCaptura(bool habilitar);
    DetalleCompraCapturaDto? SolicitarDetalleCompra(IReadOnlyList<ProductoCompraDto> productos);
    void MostrarMensaje(string mensaje, bool esError = false);
}
