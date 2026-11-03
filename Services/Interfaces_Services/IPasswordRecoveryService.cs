using System;
using System.Threading;
using System.Threading.Tasks;
using Ocean_Desk_dv.Models.DTOs;

namespace Ocean_Desk_dv.Services.Interfaces_Services;

/// <summary>
/// Gestiona la solicitud, verificación y ejecución de la recuperación
/// de contraseñas de Ocean Desk.
/// </summary>
public interface IPasswordRecoveryService : IDisposable
{
    /// <summary>
    /// Solicita el envío de un código al correo asociado a una cuenta activa.
    /// La respuesta no revela si la dirección está registrada.
    /// </summary>
    Task<ResultadoOperacionDto> SolicitarCodigoAsync(
        string email,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Comprueba un código vigente. Si el correo aún no estaba verificado,
    /// registra la verificación de su propiedad.
    /// </summary>
    ResultadoOperacionDto VerificarCodigo(string email, string codigo);

    /// <summary>
    /// Verifica nuevamente el código y restablece la contraseña.
    /// El código se invalida cuando la operación termina correctamente.
    /// </summary>
    ResultadoOperacionDto RestablecerContrasena(
        string email,
        string codigo,
        string nuevaContrasena,
        string confirmacionContrasena);
}
