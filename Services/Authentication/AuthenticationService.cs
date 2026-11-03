using System;
using System.Linq;
using Ocean_Desk_dv.Models.DTOs;
using Ocean_Desk_dv.Models.Entities;
using Ocean_Desk_dv.Services.Interfaces_Services;

namespace Ocean_Desk_dv.Services.Authentication;

/// <summary>
/// Coordina la validación de credenciales, el bloqueo temporal y la carga de permisos.
/// </summary>
public sealed class AuthenticationService : IAuthenticationService, IDisposable
{
    private bool _disposed;
    private const int MaximoIntentosFallidos = 5;
    private const int MinutosBloqueo = 15;

    private readonly IAuthenticationRepository _repository;

    public AuthenticationService(IAuthenticationRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public ResultadoAutenticacionDto Autenticar(string username, string password)
    {
        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrEmpty(password))
        {
            return ResultadoAutenticacionDto.Fallido(
                "Ingrese su nombre de usuario y contraseña.");
        }

        User? user = _repository.ObtenerUsuarioPorNombre(username.Trim());

        // Mensaje genérico para no revelar si el usuario existe o está desactivado.
        if (user is null || !user.IsActive || user.Role is null || !user.Role.IsActive)
        {
            return ResultadoAutenticacionDto.Fallido(
                "Usuario o contraseña incorrectos, o cuenta no disponible.");
        }

        DateTime ahoraUtc = DateTime.UtcNow;

        if (user.LockoutEnd.HasValue && user.LockoutEnd.Value > ahoraUtc)
        {
            return ResultadoAutenticacionDto.Bloqueado(
                "La cuenta está bloqueada temporalmente. Intente nuevamente después de " +
                DateTime.SpecifyKind(
                    user.LockoutEnd.Value,
                    DateTimeKind.Utc).ToLocalTime(),
                user.LockoutEnd.Value);
        }

        // Si el periodo de bloqueo ya terminó, se reinicia el contador antes de validar.
        if (user.LockoutEnd.HasValue && user.LockoutEnd.Value <= ahoraUtc)
        {
            user.FailedLoginAttempts = 0;
            user.LockoutEnd = null;
        }

        if (!PasswordHasher.VerifyPassword(password, user.PasswordHash))
        {
            user.FailedLoginAttempts = Math.Max(0, user.FailedLoginAttempts) + 1;

            if (user.FailedLoginAttempts >= MaximoIntentosFallidos)
            {
                user.LockoutEnd = ahoraUtc.AddMinutes(MinutosBloqueo);
                user.UpdatedAt = ahoraUtc;
                _repository.GuardarCambios();

                return ResultadoAutenticacionDto.Bloqueado(
                    $"Se alcanzó el límite de {MaximoIntentosFallidos} intentos. " +
                    $"La cuenta permanecerá bloqueada durante {MinutosBloqueo} minutos.",
                    user.LockoutEnd.Value);
            }

            user.UpdatedAt = ahoraUtc;
            _repository.GuardarCambios();

            int intentosRestantes = MaximoIntentosFallidos - user.FailedLoginAttempts;
            return ResultadoAutenticacionDto.Fallido(
                $"Usuario o contraseña incorrectos. Intentos restantes: {intentosRestantes}.");
        }

        // Credenciales correctas: restablecer el contador y registrar el acceso.
        user.FailedLoginAttempts = 0;
        user.LockoutEnd = null;
        user.LastLoginAt = ahoraUtc;
        user.UpdatedAt = ahoraUtc;
        _repository.GuardarCambios();

        var permisos = user.Role.RoleModulePermissions
            .OrderBy(permission => permission.ModuleCode)
            .Select(permission => new PermisoModuloAutenticacionDto
            {
                ModuleCode = permission.ModuleCode,
                CanView = permission.CanView,
                CanCreate = permission.CanCreate,
                CanEdit = permission.CanEdit,
                CanDelete = permission.CanDelete,
                CanExport = permission.CanExport,
                CanChangeStatus = permission.CanChangeStatus
            })
            .ToArray();

        var usuarioAutenticado = new UsuarioAutenticadoDto
        {
            UserId = user.UserId,
            Username = user.Username,
            NombreCompleto = $"{user.FirstName} {user.LastName}".Trim(),
            RoleId = user.RoleId,
            RoleCode = user.Role.RoleCode,
            RoleName = user.Role.RoleName,
            MustChangePassword = user.MustChangePassword,
            Permisos = permisos
        };

        string mensaje = user.MustChangePassword
            ? "Autenticación correcta. Debe cambiar su contraseña para continuar."
            : "Autenticación correcta.";

        return ResultadoAutenticacionDto.Correcto(mensaje, usuarioAutenticado);
    }

    /// <summary>
    /// Actualiza la contraseña inicial de un usuario autenticado.
    /// Solo permite la operación cuando el usuario tiene pendiente
    /// el cambio obligatorio de contraseña.
    /// </summary>
    public ResultadoOperacionDto CambiarContrasenaInicial(
        int userId,
        string nuevaContrasena,
        string confirmacionContrasena)
    {
        if (userId <= 0)
            return ResultadoOperacionDto.Fallido(
                "El usuario indicado no es válido.");

        ResultadoOperacionDto validacion = PasswordPolicy.Validar(
            nuevaContrasena,
            confirmacionContrasena);

        if (!validacion.Exito)
            return validacion;

        User? user = _repository.ObtenerUsuarioPorId(userId);

        if (user is null || !user.IsActive ||
            user.Role is null || !user.Role.IsActive)
        {
            return ResultadoOperacionDto.Fallido(
                "La cuenta no está disponible.");
        }

        if (!user.MustChangePassword)
        {
            return ResultadoOperacionDto.Fallido(
                "La cuenta no tiene pendiente un cambio obligatorio de contraseña.");
        }

        if (PasswordHasher.VerifyPassword(
            nuevaContrasena,
            user.PasswordHash))
        {
            return ResultadoOperacionDto.Fallido(
                "La nueva contraseña debe ser diferente de la contraseña inicial.");
        }

        DateTime ahoraUtc = DateTime.UtcNow;

        user.PasswordHash = PasswordHasher.HashPassword(nuevaContrasena);
        user.MustChangePassword = false;
        user.PasswordChangedAt = ahoraUtc;
        user.UpdatedAt = ahoraUtc;

        user.FailedLoginAttempts = 0;
        user.LockoutEnd = null;

        user.PasswordResetTokenHash = null;
        user.PasswordResetExpiresAt = null;
        user.PasswordResetFailedAttempts = 0;
        user.PasswordResetLastSentAt = null;
        user.PasswordResetBlockedUntil = null;

        _repository.GuardarCambios();

        return ResultadoOperacionDto.Correcto(
            "La contraseña fue actualizada correctamente.");
    }

    public void Dispose()
    {
        if (_disposed)
            return;

        _repository.Dispose();
        _disposed = true;
        GC.SuppressFinalize(this);
    }
}
