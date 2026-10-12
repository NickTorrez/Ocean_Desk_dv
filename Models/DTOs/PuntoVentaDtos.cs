namespace Ocean_Desk_dv.Models.DTOs;

public sealed class ProductoVentaDto
{
    public int ProductId { get; init; }
    public string ProductCode { get; init; } = string.Empty;
    public string ProductName { get; init; } = string.Empty;
    public decimal UnitPrice { get; init; }
    public bool IsAvailable { get; init; }
    public bool IsActive { get; init; }
    public string CategoryName { get; init; } = string.Empty;
}

public sealed class ClienteVentaDto
{
    public int CustomerId { get; init; }
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;
    public string? Phone { get; init; }
}

public sealed class PuntoVentaDetalleDto
{
    public int ProductoId { get; init; }
    public decimal Cantidad { get; init; }
    public string Observacion { get; init; } = string.Empty;
}

public sealed class SolicitudVentaDto
{
    public int UsuarioId { get; init; }
    public int? ClienteId { get; init; }
    public int? MesaId { get; init; }
    public string TipoOrden { get; init; } = string.Empty;
    public string MetodoPago { get; init; } = string.Empty;
    public string Prioridad { get; init; } = string.Empty;
    public IReadOnlyList<PuntoVentaDetalleDto> Detalles { get; init; } = Array.Empty<PuntoVentaDetalleDto>();
}

public sealed class ResultadoVentaDto
{
    public bool Exito { get; init; }
    public string Mensaje { get; init; } = string.Empty;
    public string Titulo { get; init; } = string.Empty;
    public bool EsError { get; init; }
    public decimal Total { get; init; }
    public string MetodoPago { get; init; } = string.Empty;
    public int? SaleId { get; init; }
    public static ResultadoVentaDto Fallido(string mensaje, string titulo, bool error = true) => new() { Exito = false, Mensaje = mensaje, Titulo = titulo, EsError = error };
    public static ResultadoVentaDto Correcto(decimal total, string metodoPago, int saleId) => new() { Exito = true, Mensaje = "La venta fue registrada correctamente.", Titulo = "Venta registrada", Total = total, MetodoPago = metodoPago, SaleId = saleId };
}
