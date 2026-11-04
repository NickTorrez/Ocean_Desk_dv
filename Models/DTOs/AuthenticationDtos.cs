using System;
using System.Collections.Generic;

namespace Ocean_Desk_dv.Models.DTOs;

/// <summary>
/// Permisos de un módulo asociados al rol del usuario autenticado.
/// </summary>
public sealed class PermisoModuloAutenticacionDto
{
    public string ModuleCode { get; init; } = string.Empty;
    public bool CanView { get; init; }
    public bool CanCreate { get; init; }
    public bool CanEdit { get; init; }
    public bool CanDelete { get; init; }
    public bool CanExport { get; init; }
    public bool CanChangeStatus { get; init; }
}

/// <summary>
/// Datos mínimos del usuario que ha superado la autenticación.
/// No contiene el hash de contraseña ni tokens de recuperación.
/// </summary>
public sealed class UsuarioAutenticadoDto
{
    public int UserId { get; init; }
    public string Username { get; init; } = string.Empty;
    public string NombreCompleto { get; init; } = string.Empty;
    public int RoleId { get; init; }
    public string RoleCode { get; init; } = string.Empty;
    public string RoleName { get; init; } = string.Empty;
    public bool MustChangePassword { get; init; }
    /// <summary>
    /// Indica que la sesión fue validada utilizando la autorización
    /// local protegida y no mediante una consulta actual a SQL Server.
    /// </summary>
    public bool EsSesionOffline { get; init; }
    public IReadOnlyList<PermisoModuloAutenticacionDto> Permisos { get; init; }
        = Array.Empty<PermisoModuloAutenticacionDto>();
}

/// <summary>
/// Resultado de una solicitud de autenticación.
/// </summary>
public sealed class ResultadoAutenticacionDto
{
    public bool Exito { get; init; }
    public string Mensaje { get; init; } = string.Empty;
    public UsuarioAutenticadoDto? Usuario { get; init; }
    public bool CuentaBloqueada { get; init; }
    public DateTime? BloqueoHastaUtc { get; init; }

    public static ResultadoAutenticacionDto Fallido(string mensaje) => new()
    {
        Exito = false,
        Mensaje = mensaje
    };

    public static ResultadoAutenticacionDto Bloqueado(string mensaje, DateTime bloqueoHastaUtc) => new()
    {
        Exito = false,
        Mensaje = mensaje,
        CuentaBloqueada = true,
        BloqueoHastaUtc = bloqueoHastaUtc
    };

    public static ResultadoAutenticacionDto Correcto(
        string mensaje,
        UsuarioAutenticadoDto usuario) => new()
        {
            Exito = true,
            Mensaje = mensaje,
            Usuario = usuario
        };
}
