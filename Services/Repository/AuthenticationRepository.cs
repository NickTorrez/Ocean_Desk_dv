using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Ocean_Desk_dv.Data;
using Ocean_Desk_dv.Models.Entities;
using Ocean_Desk_dv.Services.Interfaces_Services;

namespace Ocean_Desk_dv.Services.Repository;

/// <summary>
/// Repositorio SQL Server para recuperar cuentas y persistir el estado de autenticación.
/// </summary>
public sealed class AuthenticationRepository : IAuthenticationRepository
{
    private readonly OceanDeskDbContext _context;
    private bool _disposed;

    public AuthenticationRepository(OceanDeskDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public User? ObtenerUsuarioPorNombre(string username)
    {
        if (string.IsNullOrWhiteSpace(username))
            return null;

        return _context.Users
            .Include(user => user.Role)
                .ThenInclude(role => role.RoleModulePermissions)
            .SingleOrDefault(user => user.Username == username.Trim());
    }

    public void GuardarCambios()
    {
        _context.SaveChanges();
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
