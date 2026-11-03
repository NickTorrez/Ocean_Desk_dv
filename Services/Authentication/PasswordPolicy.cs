using System;
using System.Linq;
using Ocean_Desk_dv.Models.DTOs;

namespace Ocean_Desk_dv.Services.Authentication;

/// <summary>
/// Centraliza la política de contraseñas de Ocean Desk para que
/// el cambio inicial y la recuperación apliquen los mismos requisitos.
/// </summary>
public static class PasswordPolicy
{
    public const int LongitudMinima = 12;
    public const int LongitudMaxima = 128;

    /// <summary>
    /// Valida la nueva contraseña y su confirmación.
    /// Retorna un resultado satisfactorio cuando cumple la política.
    /// </summary>
    public static ResultadoOperacionDto Validar(
        string? nuevaContrasena,
        string? confirmacionContrasena)
    {
        if (string.IsNullOrWhiteSpace(nuevaContrasena))
        {
            return ResultadoOperacionDto.Fallido(
                "Ingrese una nueva contraseña.");
        }

        if (!string.Equals(
            nuevaContrasena,
            confirmacionContrasena,
            StringComparison.Ordinal))
        {
            return ResultadoOperacionDto.Fallido(
                "Las contraseñas no coinciden.");
        }

        if (nuevaContrasena.Length < LongitudMinima ||
            nuevaContrasena.Length > LongitudMaxima ||
            !nuevaContrasena.Any(char.IsUpper) ||
            !nuevaContrasena.Any(char.IsLower) ||
            !nuevaContrasena.Any(char.IsDigit) ||
            !nuevaContrasena.Any(c =>
                !char.IsLetterOrDigit(c) && !char.IsWhiteSpace(c)))
        {
            return ResultadoOperacionDto.Fallido(
                $"La contraseña debe tener entre {LongitudMinima} y {LongitudMaxima} caracteres, " +
                "incluyendo mayúsculas, minúsculas, números y al menos un símbolo.");
        }

        return ResultadoOperacionDto.Correcto(
            "La contraseña cumple los requisitos de seguridad.");
    }
}
