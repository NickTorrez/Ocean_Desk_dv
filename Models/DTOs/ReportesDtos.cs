namespace Ocean_Desk_dv.Models.DTOs;

/// <summary>Indicadores calculados para el período consultado.</summary>
public sealed class ReporteIndicadoresDto
{
    public int CantidadVentas { get; init; }
    public decimal Ingresos { get; init; }
    public int ProductosRegistrados { get; init; }
}

public sealed class EvolucionVentaDto
{
    public DateTime Fecha { get; init; }
    public decimal Total { get; init; }
}

public sealed class ProductoVendidoDto
{
    public string Producto { get; init; } = string.Empty;
    public decimal Cantidad { get; init; }
}
