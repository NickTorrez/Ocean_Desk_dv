using System;
namespace Ocean_Desk_dv.Models.DTOs;

/// <summary>Proveedor presentado en el catálogo de proveedores.</summary>
public sealed class ProveedorDto
{
    public int SupplierId { get; init; }
    public string SupplierCode { get; init; } = string.Empty;
    public string SupplierName { get; init; } = string.Empty;
    public string? ContactName { get; init; }
    public string? Phone { get; init; }
    public string? Email { get; init; }
    public string? Address { get; init; }
    public bool IsActive { get; init; }
}

/// <summary>Datos capturados en la vista para crear o actualizar un proveedor.</summary>
public sealed class GuardarProveedorDto
{
    /// <summary>Null cuando se está creando un proveedor nuevo.</summary>
    public int? SupplierId { get; init; }
    public string SupplierName { get; init; } = string.Empty;
    public string? ContactName { get; init; }
    public string? Phone { get; init; }
    public string? Email { get; init; }
    public string? Address { get; init; }
    public bool IsActive { get; init; } = true;
}

/// <summary>Proveedor disponible en el selector de consultas de compras asociadas.</summary>
public sealed class ProveedorSelectorDto
{
    public int SupplierId { get; init; }
    public string SupplierName { get; init; } = string.Empty;

    public override string ToString() => SupplierName;
}

/// <summary>Compra registrada para un proveedor seleccionado.</summary>
public sealed class CompraProveedorDto
{
    public int PurchaseId { get; init; }
    public DateTime PurchaseDate { get; init; }
    public decimal Total { get; init; }
    public string Status { get; init; } = string.Empty;
    public string? DocumentNumber { get; init; }
}
