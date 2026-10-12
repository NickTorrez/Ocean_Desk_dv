namespace Ocean_Desk_dv.Models.DTOs;

public sealed class CocinaPedidoResumenDto
{
    public int KitchenOrderId { get; init; }
    public int SaleId { get; init; }
    public string Mesa { get; init; } = string.Empty;
    public string TipoOrden { get; init; } = string.Empty;
    public DateTime Hora { get; init; }
    public string Prioridad { get; init; } = string.Empty;
    public string Estado { get; init; } = string.Empty;
}

public sealed class CocinaPedidoSeleccionadoDto
{
    public int KitchenOrderId { get; init; }
    public string Mesa { get; init; } = string.Empty;
    public string TipoOrden { get; init; } = string.Empty;
    public DateTime Hora { get; init; }
    public string Prioridad { get; init; } = string.Empty;
    public string Estado { get; init; } = string.Empty;
}

public sealed class CocinaPedidoDetalleDto
{
    public decimal Cantidad { get; init; }
    public string Producto { get; init; } = string.Empty;
    public string Observaciones { get; init; } = string.Empty;
}

public sealed class CocinaPedidoCompletoDto
{
    public CocinaPedidoSeleccionadoDto Pedido { get; init; } = new();
    public IReadOnlyList<CocinaPedidoDetalleDto> Detalles { get; init; } = Array.Empty<CocinaPedidoDetalleDto>();
}
