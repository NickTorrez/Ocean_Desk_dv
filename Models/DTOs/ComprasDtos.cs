namespace Ocean_Desk_dv.Models.DTOs;

public static class EstadosCompra
{
    public const string Borrador = "Borrador";
    public const string Pendiente = "Pendiente";
    public const string Recibida = "Recibida";
    public const string Cancelada = "Cancelada";
}

public sealed class FiltroComprasDto
{
    public string? Texto { get; init; }
    public string? Estado { get; init; }
    public DateTime? Fecha { get; init; }
}

public sealed class ProveedorCompraDto
{
    public int SupplierId { get; init; }
    public string SupplierCode { get; init; } = string.Empty;
    public string SupplierName { get; init; } = string.Empty;
    public string? Phone { get; init; }
    public override string ToString() => SupplierName;
}

public sealed class ProductoCompraDto
{
    public int ProductId { get; init; }
    public string ProductCode { get; init; } = string.Empty;
    public string ProductName { get; init; } = string.Empty;
    public string UnitName { get; init; } = string.Empty;
    public decimal CurrentStock { get; init; }
    public override string ToString() => $"{ProductCode} - {ProductName} ({UnitName})";
}

public sealed class CompraResumenDto
{
    public int PurchaseId { get; init; }
    public string PurchaseCode { get; init; } = string.Empty;
    public DateTime PurchaseDate { get; init; }
    public int SupplierId { get; init; }
    public string SupplierName { get; init; } = string.Empty;
    public string? DocumentNumber { get; init; }
    public string Status { get; init; } = string.Empty;
    public decimal Subtotal { get; init; }
    public decimal Total { get; init; }
    public DateTime? ReceivedDate { get; init; }
    public string? Notes { get; init; }
}

public sealed class CompraDetalleDto
{
    public int PurchaseDetailId { get; init; }
    public int ProductId { get; init; }
    public string ProductCode { get; init; } = string.Empty;
    public string ProductName { get; init; } = string.Empty;
    public string UnitName { get; init; } = string.Empty;
    public decimal Quantity { get; init; }
    public decimal UnitCost { get; init; }
    public decimal Subtotal { get; init; }
    public decimal ReceivedQuantity { get; init; }
    public string? LotCode { get; init; }
    public DateOnly? ExpirationDate { get; init; }
    public string? Notes { get; init; }
}

public sealed class DetalleCompraCapturaDto
{
    public int ProductId { get; init; }
    public string ProductCode { get; init; } = string.Empty;
    public string ProductName { get; init; } = string.Empty;
    public string UnitName { get; init; } = string.Empty;
    public decimal Quantity { get; init; }
    public decimal UnitCost { get; init; }
    public decimal Subtotal { get; init; }
    public decimal ReceivedQuantity { get; init; }
    public string? LotCode { get; init; }
    public DateOnly? ExpirationDate { get; init; }
    public string? Notes { get; init; }
}

public sealed class SolicitudCompraDto
{
    public int SupplierId { get; init; }
    public DateTime PurchaseDate { get; init; }
    public string? DocumentNumber { get; init; }
    public string? Notes { get; init; }
    public IReadOnlyList<DetalleCompraCapturaDto> Details { get; init; } = Array.Empty<DetalleCompraCapturaDto>();
}

public sealed class ResultadoCompraDto
{
    public bool Exito { get; init; }
    public string Mensaje { get; init; } = string.Empty;
    public int? PurchaseId { get; init; }

    public static ResultadoCompraDto Correcto(string mensaje, int? purchaseId = null) =>
        new() { Exito = true, Mensaje = mensaje, PurchaseId = purchaseId };

    public static ResultadoCompraDto Fallido(string mensaje) =>
        new() { Exito = false, Mensaje = mensaje };
}
