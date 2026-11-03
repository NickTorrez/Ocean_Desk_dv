using Ocean_Desk_dv.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocean_Desk_dv.Services.Authentication
{

    /// <summary>
    /// Contrato encargado de gestionar la recuperación
    /// y el restablecimiento de contraseñas de Ocean Desk.
    /// </summary>
    public class PasswordRecoveryService
    {
        /// <summary>
        /// Solicita un código de recuperación para el correo indicado.
        /// Aplica las restricciones de envío y vigencia correspondientes.
        /// </summary>
        Task<ResultadoOperacionDto> SolicitarCodigoAsync(
            string email,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Verifica que el código recibido corresponda
        /// a una solicitud vigente y autorizada.
        /// </summary>
        ResultadoOperacionDto VerificarCodigo(
            string email,
            string codigo);

        /// <summary>
        /// Restablece la contraseña después de verificar nuevamente
        /// el código de recuperación.
        /// El código se invalida tras una operación exitosa.
        /// </summary>
        ResultadoOperacionDto RestablecerContrasena(
            string email,
            string codigo,
            string nuevaContrasena,
            string confirmacionContrasena);
    }
}
