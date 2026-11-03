using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using Ocean_Desk_dv.Models.DTOs;
using Ocean_Desk_dv.Models.Entities;
using Ocean_Desk_dv.Services.Interfaces_Services;

namespace Ocean_Desk_dv.Services.Authentication;

/// <summary>
/// Implementa la solicitud, verificación y restablecimiento de contraseñas.
/// Los códigos se almacenan usando PBKDF2 mediante PasswordHasher.
/// </summary>
public sealed class PasswordRecoveryService : IPasswordRecoveryService
{
    private const int LongitudCodigo = 8;
    private const int MinutosVigencia = 10;
    private const int MaximoIntentosFallidos = 5;
    private const int MinutosBloqueo = 15;
    private const int SegundosEntreEnvios = 60;

    private const string MensajeSolicitudGenerico =
        "Si el correo corresponde a una cuenta activa, recibirás un código de recuperación. " +
        "Revisa también la carpeta de correo no deseado.";

    private const string MensajeCodigoInvalido =
        "El código no es válido o ha expirado. Solicita uno nuevo.";

    private readonly IAuthenticationRepository _repository;
    private readonly IEmailSender _emailSender;
    private bool _disposed;

    public PasswordRecoveryService(
        IAuthenticationRepository repository,
        IEmailSender emailSender)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _emailSender = emailSender ?? throw new ArgumentNullException(nameof(emailSender));
    }

    /// <summary>
    /// Genera y envía un código de recuperación al correo de una cuenta activa.
    /// La respuesta es genérica para no revelar si una dirección está registrada.
    /// </summary>
    public async Task<ResultadoOperacionDto> SolicitarCodigoAsync(
        string email,
        CancellationToken cancellationToken = default)
    {
        ThrowIfDisposed();

        if (!TryNormalizarCorreo(email, out string correoNormalizado))
        {
            return ResultadoOperacionDto.Fallido(
                "Introduce una dirección de correo electrónico válida.");
        }

        cancellationToken.ThrowIfCancellationRequested();

        User? user = _repository.ObtenerUsuarioPorCorreo(correoNormalizado);

        if (!CuentaDisponible(user))
            return ResultadoOperacionDto.Correcto(MensajeSolicitudGenerico);

        DateTime ahoraUtc = DateTime.UtcNow;

        // Si un bloqueo anterior ya venció, se permite iniciar un nuevo ciclo.
        if (user!.PasswordResetBlockedUntil.HasValue)
        {
            DateTime bloqueoHastaUtc = ComoUtc(user.PasswordResetBlockedUntil.Value);

            if (bloqueoHastaUtc > ahoraUtc)
                return ResultadoOperacionDto.Correcto(MensajeSolicitudGenerico);

            user.PasswordResetBlockedUntil = null;
            user.PasswordResetFailedAttempts = 0;
        }

        // Impide solicitar códigos repetidamente para la misma cuenta.
        if (user.PasswordResetLastSentAt.HasValue)
        {
            DateTime ultimoEnvioUtc = ComoUtc(user.PasswordResetLastSentAt.Value);

            if (ahoraUtc < ultimoEnvioUtc.AddSeconds(SegundosEntreEnvios))
            {
                return ResultadoOperacionDto.Correcto(MensajeSolicitudGenerico);
            }
        }

        // Defensa adicional ante un estado inconsistente de la cuenta.
        if (user.PasswordResetFailedAttempts >= MaximoIntentosFallidos)
        {
            user.PasswordResetBlockedUntil = ahoraUtc.AddMinutes(MinutosBloqueo);
            user.PasswordResetTokenHash = null;
            user.PasswordResetExpiresAt = null;
            user.UpdatedAt = ahoraUtc;
            _repository.GuardarCambios();

            return ResultadoOperacionDto.Correcto(MensajeSolicitudGenerico);
        }

        string codigo = GenerarCodigo();
        DateTime expiracionUtc = ahoraUtc.AddMinutes(MinutosVigencia);

        // PasswordHasher aplica PBKDF2-SHA256, sal aleatoria y comparación constante.
        user.PasswordResetTokenHash = PasswordHasher.HashPassword(codigo);
        user.PasswordResetExpiresAt = expiracionUtc;
        user.PasswordResetLastSentAt = ahoraUtc;
        user.UpdatedAt = ahoraUtc;

        // Guardamos primero el hash y su vencimiento; nunca el código en texto plano.
        _repository.GuardarCambios();

        string asunto = "Ocean Desk - Código de recuperación";
        string cuerpo =
            $"Hola {user.FirstName},\r\n\r\n" +
            "Recibimos una solicitud para recuperar la contraseña de tu cuenta de Ocean Desk.\r\n\r\n" +
            $"Tu código de recuperación es: {codigo}\r\n\r\n" +
            $"El código vence en {MinutosVigencia} minutos.\r\n" +
            "No compartas este código con nadie. Si no solicitaste este cambio, puedes ignorar este mensaje.\r\n\r\n" +
            "Ocean Desk";

        try
        {
            await _emailSender.EnviarAsync(
                user.Email!,
                asunto,
                cuerpo,
                cancellationToken).ConfigureAwait(false);
        }
        catch (OperationCanceledException)
        {
            LimpiarSolicitudTrasFalloDeEnvio(user);
            throw;
        }
        catch (Exception ex)
        {
            Trace.TraceError(
                "Ocean Desk: fallo al enviar un correo de recuperación. Detalle: {0}",
                ex);

            LimpiarSolicitudTrasFalloDeEnvio(user);

            // Se mantiene la misma respuesta para no revelar la existencia de la cuenta.
            return ResultadoOperacionDto.Correcto(MensajeSolicitudGenerico);
        }

        return ResultadoOperacionDto.Correcto(MensajeSolicitudGenerico);
    }

    /// <summary>
    /// Verifica un código vigente. La verificación no consume el código:
    /// RestablecerContrasena vuelve a comprobarlo antes de cambiar la clave.
    /// </summary>
    public ResultadoOperacionDto VerificarCodigo(string email, string codigo)
    {
        ThrowIfDisposed();

        if (!TryNormalizarCorreo(email, out string correoNormalizado))
            return ResultadoOperacionDto.Fallido(MensajeCodigoInvalido);

        User? user = _repository.ObtenerUsuarioPorCorreo(correoNormalizado);

        if (!CuentaDisponible(user))
            return ResultadoOperacionDto.Fallido(MensajeCodigoInvalido);

        DateTime ahoraUtc = DateTime.UtcNow;

        if (EstaBloqueadaLaRecuperacion(user!, ahoraUtc))
            return ResultadoOperacionDto.Fallido(MensajeCodigoInvalido);

        if (!TieneCodigoVigente(user!, ahoraUtc))
        {
            InvalidarCodigoExpirado(user!, ahoraUtc);
            return ResultadoOperacionDto.Fallido(MensajeCodigoInvalido);
        }

        if (!CodigoTieneFormatoValido(codigo) ||
            !PasswordHasher.VerifyPassword(codigo, user!.PasswordResetTokenHash))
        {
            return RegistrarIntentoFallido(user!, ahoraUtc);
        }

        // El código demuestra que el usuario controla la dirección registrada.
        user!.EmailVerifiedAt ??= ahoraUtc;
        user.PasswordResetFailedAttempts = 0;
        user.UpdatedAt = ahoraUtc;
        _repository.GuardarCambios();

        return ResultadoOperacionDto.Correcto(
            "Código verificado correctamente. Ya puedes establecer una nueva contraseña.");
    }

    /// <summary>
    /// Revalida el código y actualiza la contraseña. El código se consume
    /// en la misma operación de persistencia que guarda el nuevo hash.
    /// </summary>
    public ResultadoOperacionDto RestablecerContrasena(
        string email,
        string codigo,
        string nuevaContrasena,
        string confirmacionContrasena)
    {
        ThrowIfDisposed();

        ResultadoOperacionDto validacion = PasswordPolicy.Validar(
            nuevaContrasena,
            confirmacionContrasena);

        if (!validacion.Exito)
            return validacion;

        if (!TryNormalizarCorreo(email, out string correoNormalizado))
            return ResultadoOperacionDto.Fallido(MensajeCodigoInvalido);

        User? user = _repository.ObtenerUsuarioPorCorreo(correoNormalizado);

        if (!CuentaDisponible(user))
            return ResultadoOperacionDto.Fallido(MensajeCodigoInvalido);

        DateTime ahoraUtc = DateTime.UtcNow;

        if (EstaBloqueadaLaRecuperacion(user!, ahoraUtc))
            return ResultadoOperacionDto.Fallido(MensajeCodigoInvalido);

        if (!TieneCodigoVigente(user!, ahoraUtc))
        {
            InvalidarCodigoExpirado(user!, ahoraUtc);
            return ResultadoOperacionDto.Fallido(MensajeCodigoInvalido);
        }

        if (!CodigoTieneFormatoValido(codigo) ||
            !PasswordHasher.VerifyPassword(codigo, user!.PasswordResetTokenHash))
        {
            return RegistrarIntentoFallido(user!, ahoraUtc);
        }

        if (PasswordHasher.VerifyPassword(nuevaContrasena, user!.PasswordHash))
        {
            return ResultadoOperacionDto.Fallido(
                "La nueva contraseña debe ser diferente de la contraseña actual.");
        }

        user.PasswordHash = PasswordHasher.HashPassword(nuevaContrasena);
        user.PasswordChangedAt = ahoraUtc;
        user.UpdatedAt = ahoraUtc;
        user.MustChangePassword = false;

        // Una recuperación correcta también limpia el bloqueo de inicio de sesión.
        user.FailedLoginAttempts = 0;
        user.LockoutEnd = null;

        // El correo queda verificado porque se acaba de demostrar su control.
        user.EmailVerifiedAt ??= ahoraUtc;

        // Consumo del código: no puede volver a utilizarse.
        user.PasswordResetTokenHash = null;
        user.PasswordResetExpiresAt = null;
        user.PasswordResetFailedAttempts = 0;
        user.PasswordResetLastSentAt = null;
        user.PasswordResetBlockedUntil = null;

        _repository.GuardarCambios();

        return ResultadoOperacionDto.Correcto(
            "La contraseña se restableció correctamente. Ya puedes iniciar sesión.");
    }

    private ResultadoOperacionDto RegistrarIntentoFallido(User user, DateTime ahoraUtc)
    {
        user.PasswordResetFailedAttempts =
            Math.Max(0, user.PasswordResetFailedAttempts) + 1;

        if (user.PasswordResetFailedAttempts >= MaximoIntentosFallidos)
        {
            user.PasswordResetBlockedUntil = ahoraUtc.AddMinutes(MinutosBloqueo);
            user.PasswordResetTokenHash = null;
            user.PasswordResetExpiresAt = null;
        }

        user.UpdatedAt = ahoraUtc;
        _repository.GuardarCambios();

        return ResultadoOperacionDto.Fallido(MensajeCodigoInvalido);
    }

    private bool EstaBloqueadaLaRecuperacion(User user, DateTime ahoraUtc)
    {
        if (!user.PasswordResetBlockedUntil.HasValue)
            return false;

        DateTime bloqueoHastaUtc = ComoUtc(user.PasswordResetBlockedUntil.Value);

        if (bloqueoHastaUtc > ahoraUtc)
            return true;

        // El bloqueo venció: permite un nuevo ciclo de recuperación.
        user.PasswordResetBlockedUntil = null;
        user.PasswordResetFailedAttempts = 0;
        user.UpdatedAt = ahoraUtc;
        _repository.GuardarCambios();

        return false;
    }

    private bool TieneCodigoVigente(User user, DateTime ahoraUtc)
    {
        if (string.IsNullOrWhiteSpace(user.PasswordResetTokenHash) ||
            !user.PasswordResetExpiresAt.HasValue)
        {
            return false;
        }

        return ComoUtc(user.PasswordResetExpiresAt.Value) > ahoraUtc;
    }

    private void InvalidarCodigoExpirado(User user, DateTime ahoraUtc)
    {
        if (!user.PasswordResetExpiresAt.HasValue ||
            ComoUtc(user.PasswordResetExpiresAt.Value) > ahoraUtc)
        {
            return;
        }

        user.PasswordResetTokenHash = null;
        user.PasswordResetExpiresAt = null;
        user.UpdatedAt = ahoraUtc;
        _repository.GuardarCambios();
    }

    private void LimpiarSolicitudTrasFalloDeEnvio(User user)
    {
        user.PasswordResetTokenHash = null;
        user.PasswordResetExpiresAt = null;
        user.PasswordResetLastSentAt = null;
        user.UpdatedAt = DateTime.UtcNow;

        try
        {
            _repository.GuardarCambios();
        }
        catch (Exception cleanupException)
        {
            Trace.TraceError(
                "Ocean Desk: no fue posible limpiar un código cuyo envío falló. Detalle: {0}",
                cleanupException);
        }
    }

    private static bool CuentaDisponible(User? user)
    {
        return user is not null &&
               user.IsActive &&
               user.Role is not null &&
               user.Role.IsActive &&
               !string.IsNullOrWhiteSpace(user.Email);
    }

    private static bool TryNormalizarCorreo(string? email, out string correoNormalizado)
    {
        correoNormalizado = string.Empty;

        if (string.IsNullOrWhiteSpace(email) ||
            !MailAddress.TryCreate(email.Trim(), out MailAddress? direccion))
        {
            return false;
        }

        correoNormalizado = direccion!.Address.Trim().ToLowerInvariant();
        return true;
    }

    private static bool CodigoTieneFormatoValido(string? codigo)
    {
        return !string.IsNullOrEmpty(codigo) &&
               codigo.Length == LongitudCodigo &&
               codigo.All(caracter => caracter >= '0' && caracter <= '9');
    }

    private static string GenerarCodigo()
    {
        int valor = RandomNumberGenerator.GetInt32(0, 100_000_000);
        return valor.ToString("D8", CultureInfo.InvariantCulture);
    }

    // SQL Server DATETIME2 no conserva DateTimeKind. Los valores persistidos
    // por este servicio se escriben en UTC, por lo que se restaura ese Kind al leerlos.
    private static DateTime ComoUtc(DateTime fecha)
    {
        return DateTime.SpecifyKind(fecha, DateTimeKind.Utc);
    }

    private void ThrowIfDisposed()
    {
        if (_disposed)
            throw new ObjectDisposedException(nameof(PasswordRecoveryService));
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
