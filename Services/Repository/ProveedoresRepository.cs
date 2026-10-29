using System.Net.Mail;
using Microsoft.EntityFrameworkCore;
using Ocean_Desk_dv.Data;
using Ocean_Desk_dv.Models.DTOs;
using Ocean_Desk_dv.Models.Entities;
using Ocean_Desk_dv.Services.Interfaces_Services;

namespace Ocean_Desk_dv.Services.Repository;

/// <summary>Persistencia del catálogo de proveedores mediante Entity Framework Core.</summary>
public sealed class ProveedoresRepository : IProveedoresRepository
{
    private readonly OceanDeskDbContext _context;
    private bool _disposed;

    public ProveedoresRepository(OceanDeskDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public IReadOnlyList<ProveedorDto> ObtenerProveedores(
        string? filtro = null,
        bool incluirInactivos = true)
    {
        IQueryable<Supplier> consulta = _context.Suppliers.AsNoTracking();

        if (!incluirInactivos)
            consulta = consulta.Where(s => s.IsActive);

        if (!string.IsNullOrWhiteSpace(filtro))
        {
            string texto = filtro.Trim();
            consulta = consulta.Where(s =>
                s.SupplierCode.Contains(texto) ||
                s.SupplierName.Contains(texto) ||
                (s.ContactName != null && s.ContactName.Contains(texto)) ||
                (s.Phone != null && s.Phone.Contains(texto)) ||
                (s.Email != null && s.Email.Contains(texto)) ||
                (s.Address != null && s.Address.Contains(texto)));
        }

        return consulta
            .OrderBy(s => s.SupplierName)
            .Select(s => new ProveedorDto
            {
                SupplierId = s.SupplierId,
                SupplierCode = s.SupplierCode,
                SupplierName = s.SupplierName,
                ContactName = s.ContactName,
                Phone = s.Phone,
                Email = s.Email,
                Address = s.Address,
                IsActive = s.IsActive
            })
            .ToList();
    }

    public ProveedorDto? ObtenerProveedor(int supplierId) =>
        _context.Suppliers.AsNoTracking()
            .Where(s => s.SupplierId == supplierId)
            .Select(s => new ProveedorDto
            {
                SupplierId = s.SupplierId,
                SupplierCode = s.SupplierCode,
                SupplierName = s.SupplierName,
                ContactName = s.ContactName,
                Phone = s.Phone,
                Email = s.Email,
                Address = s.Address,
                IsActive = s.IsActive
            })
            .FirstOrDefault();

    /// <summary>
    /// Devuelve únicamente proveedores con al menos una compra. Incluye los inactivos
    /// para que sus compras históricas sigan siendo consultables.
    /// </summary>
    public IReadOnlyList<ProveedorSelectorDto> ObtenerProveedoresConCompras() =>
        _context.Suppliers.AsNoTracking()
            .Where(s => s.Purchases.Any())
            .OrderBy(s => s.SupplierName)
            .Select(s => new ProveedorSelectorDto
            {
                SupplierId = s.SupplierId,
                SupplierName = s.SupplierName
            })
            .ToList();

    public IReadOnlyList<CompraProveedorDto> ObtenerComprasAsociadas(int supplierId)
    {
        if (supplierId <= 0)
            return Array.Empty<CompraProveedorDto>();

        return _context.Purchases.AsNoTracking()
            .Where(p => p.SupplierId == supplierId)
            .OrderByDescending(p => p.PurchaseDate)
            .ThenByDescending(p => p.PurchaseId)
            .Select(p => new CompraProveedorDto
            {
                PurchaseId = p.PurchaseId,
                PurchaseDate = p.PurchaseDate,
                Total = p.Total,
                Status = p.Status,
                DocumentNumber = p.DocumentNumber
            })
            .ToList();
    }

    public ResultadoOperacionDto GuardarProveedor(
        GuardarProveedorDto solicitud,
        out int supplierId)
    {
        supplierId = 0;

        if (solicitud is null)
            return ResultadoOperacionDto.Fallido("No se recibieron los datos del proveedor.");

        string nombre = solicitud.SupplierName.Trim();
        string? contacto = NormalizarTexto(solicitud.ContactName);
        string? email = NormalizarTexto(solicitud.Email);
        string? direccion = NormalizarTexto(solicitud.Address);

        if (nombre.Length == 0 || nombre.Length > 150)
            return ResultadoOperacionDto.Fallido(
                "El nombre del proveedor es obligatorio y admite hasta 150 caracteres.");

        if (contacto?.Length > 120)
            return ResultadoOperacionDto.Fallido(
                "El nombre del contacto admite hasta 120 caracteres.");

        if (email?.Length > 150)
            return ResultadoOperacionDto.Fallido(
                "El correo electrónico admite hasta 150 caracteres.");

        if (direccion?.Length > 250)
            return ResultadoOperacionDto.Fallido(
                "La dirección admite hasta 250 caracteres.");

        string? telefono = NormalizarTelefono(solicitud.Phone, out bool telefonoValido);
        if (!telefonoValido)
            return ResultadoOperacionDto.Fallido(
                "El teléfono debe contener exactamente 8 dígitos, con el formato 0000-0000.");

        if (!string.IsNullOrWhiteSpace(email) && !CorreoValido(email))
            return ResultadoOperacionDto.Fallido("Ingrese un correo electrónico válido.");

        int? idExcluir = solicitud.SupplierId;
        List<string> nombresExistentes = _context.Suppliers.AsNoTracking()
            .Where(s => !idExcluir.HasValue || s.SupplierId != idExcluir.Value)
            .Select(s => s.SupplierName)
            .ToList();

        if (nombresExistentes.Any(n => string.Equals(
            n.Trim(), nombre, StringComparison.OrdinalIgnoreCase)))
        {
            return ResultadoOperacionDto.Fallido(
                "Ya existe un proveedor registrado con ese nombre.");
        }

        Supplier proveedor;
        bool esNuevo = !solicitud.SupplierId.HasValue;

        if (esNuevo)
        {
            proveedor = new Supplier
            {
                SupplierCode = GenerarCodigoProveedorDisponible(),
                CreatedAt = DateTime.Now
            };
            _context.Suppliers.Add(proveedor);
        }
        else
        {
            proveedor = _context.Suppliers.FirstOrDefault(s =>
                s.SupplierId == solicitud.SupplierId!.Value)!;

            if (proveedor is null)
                return ResultadoOperacionDto.Fallido(
                    "El proveedor que intenta editar ya no existe.");

            proveedor.UpdatedAt = DateTime.Now;
        }

        proveedor.SupplierName = nombre;
        proveedor.ContactName = contacto;
        proveedor.Phone = telefono;
        proveedor.Email = email;
        proveedor.Address = direccion;
        proveedor.IsActive = solicitud.IsActive;

        try
        {
            _context.SaveChanges();
            supplierId = proveedor.SupplierId;
            string accion = esNuevo ? "registrado" : "actualizado";
            return ResultadoOperacionDto.Correcto(
                $"El proveedor {proveedor.SupplierName} fue {accion} correctamente.");
        }
        catch (DbUpdateException)
        {
            _context.ChangeTracker.Clear();
            return ResultadoOperacionDto.Fallido(
                "No se pudo guardar el proveedor. Verifique los datos e intente nuevamente.");
        }
    }

    public ResultadoOperacionDto CambiarEstadoProveedor(int supplierId)
    {
        if (supplierId <= 0)
            return ResultadoOperacionDto.Fallido("El proveedor seleccionado no es válido.");

        Supplier? proveedor = _context.Suppliers
            .FirstOrDefault(s => s.SupplierId == supplierId);

        if (proveedor is null)
            return ResultadoOperacionDto.Fallido("El proveedor seleccionado ya no existe.");

        proveedor.IsActive = !proveedor.IsActive;
        proveedor.UpdatedAt = DateTime.Now;

        try
        {
            _context.SaveChanges();
            return ResultadoOperacionDto.Correcto(proveedor.IsActive
                ? $"El proveedor {proveedor.SupplierName} fue activado correctamente."
                : $"El proveedor {proveedor.SupplierName} fue desactivado. No estará disponible para nuevas compras.");
        }
        catch (DbUpdateException)
        {
            _context.ChangeTracker.Clear();
            return ResultadoOperacionDto.Fallido(
                "No se pudo cambiar el estado del proveedor.");
        }
    }

    private string GenerarCodigoProveedorDisponible()
    {
        var codigos = _context.Suppliers.AsNoTracking()
            .Select(s => s.SupplierCode)
            .ToHashSet(StringComparer.OrdinalIgnoreCase);

        for (int numero = 1; numero <= 999999; numero++)
        {
            string codigo = $"PROV-{numero:000000}";
            if (!codigos.Contains(codigo))
                return codigo;
        }

        throw new InvalidOperationException(
            "No hay códigos de proveedor disponibles en la secuencia PROV-000001 a PROV-999999.");
    }

    private static string? NormalizarTexto(string? texto) =>
        string.IsNullOrWhiteSpace(texto) ? null : texto.Trim();

    private static string? NormalizarTelefono(string? valor, out bool valido)
    {
        valido = true;
        string? texto = NormalizarTexto(valor);
        if (texto is null)
            return null;

        string digitos = new(texto.Where(char.IsDigit).ToArray());
        if (digitos.Length != 8)
        {
            valido = false;
            return null;
        }

        return $"{digitos[..4]}-{digitos[4..]}";
    }

    private static bool CorreoValido(string correo)
    {
        try
        {
            var direccion = new MailAddress(correo);
            return string.Equals(
                direccion.Address,
                correo,
                StringComparison.OrdinalIgnoreCase);
        }
        catch (FormatException)
        {
            return false;
        }
    }

    public void Dispose()
    {
        if (_disposed)
            return;

        _context.Dispose();
        _disposed = true;
        GC.SuppressFinalize(this);
    }
}
