using Ocean_Desk_dv.Models.DTOs;

namespace Ocean_Desk_dv.Services.Interfaces_Services;

/// <summary>Operaciones de persistencia necesarias para el módulo Proveedores.</summary>
public interface IProveedoresRepository : IDisposable
{
    IReadOnlyList<ProveedorDto> ObtenerProveedores(string? filtro = null, bool incluirInactivos = true);
    ProveedorDto? ObtenerProveedor(int supplierId);
    IReadOnlyList<ProveedorSelectorDto> ObtenerProveedoresConCompras();
    IReadOnlyList<CompraProveedorDto> ObtenerComprasAsociadas(int supplierId);
    ResultadoOperacionDto GuardarProveedor(GuardarProveedorDto solicitud, out int supplierId);
    ResultadoOperacionDto CambiarEstadoProveedor(int supplierId);
}
