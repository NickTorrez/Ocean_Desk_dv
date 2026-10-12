namespace Ocean_Desk_dv.Models.DTOs;

public sealed class CashRegisterDto
{
    public int CashRegisterId { get; init; }
    public int OpeningUserId { get; init; }
    public DateTime OpeningDateTime { get; init; }
    public decimal OpeningAmount { get; init; }
    public DateTime? ClosingDateTime { get; init; }
    public decimal? ExpectedCash { get; init; }
    public decimal? ActualCash { get; init; }
    public decimal? Difference { get; init; }
    public int? ClosingUserId { get; init; }
    public string Status { get; init; } = string.Empty;
}

public sealed class MovimientoCajaDto
{
    public DateTime Fecha { get; init; }
    public string Tipo { get; init; } = string.Empty;
    public string Concepto { get; init; } = string.Empty;
    public string MetodoPago { get; init; } = string.Empty;
    public decimal Monto { get; init; }
    public string Usuario { get; init; } = string.Empty;
}

public sealed class ResumenCajaDto
{
    public IReadOnlyList<MovimientoCajaDto> Movimientos { get; init; } = Array.Empty<MovimientoCajaDto>();
    public decimal Ingresos { get; init; }
    public decimal Egresos { get; init; }
    public decimal EfectivoEsperado { get; init; }
}
