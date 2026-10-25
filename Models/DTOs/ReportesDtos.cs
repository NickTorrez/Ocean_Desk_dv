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

/// <summary>
/// Resume el estado actual de las existencias de ingredientes.
/// </summary>
public sealed class ReporteStockInventarioDto
{
    public int IngredientesBajoMinimo { get; init; }

    public int IngredientesAgotados { get; init; }
}

/// <summary>
/// Resume las operaciones de inventario de una jornada.
/// Las cantidades se presentan por movimiento porque pueden
/// pertenecer a unidades de medida diferentes.
/// </summary>
public sealed class ReporteActividadInventarioDto
{
    public int CantidadSalidas { get; init; }

    public int CantidadPerdidas { get; init; }

    public int CantidadAjustes { get; init; }

    public IReadOnlyList<MovimientoInventarioResumenDto>
        MovimientosRecientes
    { get; init; } =
            Array.Empty<MovimientoInventarioResumenDto>();
}

/// <summary>
/// Información de presentación de un movimiento reciente.
/// </summary>
public sealed class MovimientoInventarioResumenDto
{
    public string TipoMovimiento { get; init; } = string.Empty;

    public string CodigoProducto { get; init; } = string.Empty;

    public string Producto { get; init; } = string.Empty;

    public DateTime FechaHora { get; init; }

    public decimal Cantidad { get; init; }

    public string Unidad { get; init; } = string.Empty;

    public string? Observaciones { get; init; }
}
