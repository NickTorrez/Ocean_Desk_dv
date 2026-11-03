using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Ocean_Desk_dv.Services.Interfaces_Services;

namespace Ocean_Desk_dv.Services.Email;

/// <summary>
/// Implementación SMTP de IEmailSender.
/// Utiliza credenciales externas al código fuente.
/// </summary>
public sealed class SmtpEmailSender : IEmailSender
{
    private readonly SmtpEmailOptions _options;

    public SmtpEmailSender(SmtpEmailOptions options)
    {
        _options = options ?? throw new ArgumentNullException(nameof(options));
    }

    public async Task EnviarAsync(
        string destinatario,
        string asunto,
        string cuerpo,
        CancellationToken cancellationToken = default)
    {
        if (!MailAddress.TryCreate(destinatario, out MailAddress? direccionDestino))
            throw new ArgumentException("La dirección destinataria no es válida.", nameof(destinatario));

        using var mensaje = new MailMessage
        {
            From = new MailAddress(
                _options.FromAddress,
                _options.DisplayName,
                Encoding.UTF8),
            Subject = asunto,
            SubjectEncoding = Encoding.UTF8,
            Body = cuerpo,
            BodyEncoding = Encoding.UTF8,
            IsBodyHtml = false
        };

        mensaje.To.Add(direccionDestino);

        using var cliente = new SmtpClient(_options.Host, _options.Port)
        {
            EnableSsl = _options.EnableSsl,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(
                _options.UserName,
                _options.AppPassword),
            Timeout = 30000
        };

        await cliente.SendMailAsync(mensaje, cancellationToken)
            .ConfigureAwait(false);
    }
}
