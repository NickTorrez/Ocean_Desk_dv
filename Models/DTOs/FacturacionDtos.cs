namespace Ocean_Desk_dv.Models.DTOs;

public sealed class FacturaDto
{
    public string NumeroFactura { get; init; } = string.Empty;
    public DateTime Fecha { get; init; }
    public string Cliente { get; init; } = string.Empty;
    public string TipoOrden { get; init; } = string.Empty;
    public int? Mesa { get; init; }
    public decimal Subtotal { get; init; }
    public decimal Descuento { get; init; }
    public decimal Total { get; init; }
    public string MetodoPago { get; init; } = string.Empty;
    public string Estado { get; init; } = string.Empty;
    public List<DetalleFacturaDto> Detalles { get; init; } = new();
}

public sealed class DetalleFacturaDto
{
    public string Producto { get; init; } = string.Empty;
    public int Cantidad { get; init; }
    public decimal Precio { get; init; }
    public decimal Subtotal => Cantidad * Precio;
}
