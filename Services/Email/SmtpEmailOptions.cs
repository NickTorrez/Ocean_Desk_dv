using System;
using System.Net.Mail;

namespace Ocean_Desk_dv.Services.Email;

/// <summary>
/// Configuración SMTP obtenida exclusivamente desde variables de entorno.
/// No almacena credenciales dentro del repositorio ni de appsettings.json.
/// </summary>
public sealed class SmtpEmailOptions
{
    public string Host { get; }
    public int Port { get; }
    public bool EnableSsl { get; }
    public string UserName { get; }
    public string AppPassword { get; }
    public string FromAddress { get; }
    public string DisplayName { get; }

    private SmtpEmailOptions(
        string host,
        int port,
        bool enableSsl,
        string userName,
        string appPassword,
        string fromAddress,
        string displayName)
    {
        Host = host;
        Port = port;
        EnableSsl = enableSsl;
        UserName = userName;
        AppPassword = appPassword;
        FromAddress = fromAddress;
        DisplayName = displayName;
    }

    /// <summary>
    /// Carga la configuración SMTP desde el entorno del proceso.
    /// Para Gmail se utilizan smtp.gmail.com y el puerto 587 por defecto.
    /// </summary>
    public static SmtpEmailOptions FromEnvironment()
    {
        string host = Environment.GetEnvironmentVariable("OCEANDESK_SMTP_HOST")
            ?? "smtp.gmail.com";

        string portText = Environment.GetEnvironmentVariable("OCEANDESK_SMTP_PORT")
            ?? "587";

        string userName = Environment.GetEnvironmentVariable("OCEANDESK_SMTP_USER")
            ?? string.Empty;

        string appPassword = Environment.GetEnvironmentVariable("OCEANDESK_SMTP_APP_PASSWORD")
            ?? string.Empty;

        string fromAddress = Environment.GetEnvironmentVariable("OCEANDESK_SMTP_FROM")
            ?? userName;

        string displayName = Environment.GetEnvironmentVariable("OCEANDESK_SMTP_DISPLAY_NAME")
            ?? "Ocean Desk";

        string sslText = Environment.GetEnvironmentVariable("OCEANDESK_SMTP_ENABLE_SSL")
            ?? "true";

        if (string.IsNullOrWhiteSpace(host))
            throw new InvalidOperationException("Falta configurar OCEANDESK_SMTP_HOST.");

        if (!int.TryParse(portText, out int port) || port < 1 || port > 65535)
            throw new InvalidOperationException("OCEANDESK_SMTP_PORT no contiene un puerto válido.");

        if (string.IsNullOrWhiteSpace(userName))
            throw new InvalidOperationException("Falta configurar OCEANDESK_SMTP_USER.");

        if (string.IsNullOrWhiteSpace(appPassword))
            throw new InvalidOperationException("Falta configurar OCEANDESK_SMTP_APP_PASSWORD.");

        if (!MailAddress.TryCreate(fromAddress, out _))
            throw new InvalidOperationException("OCEANDESK_SMTP_FROM no contiene un correo válido.");

        if (!bool.TryParse(sslText, out bool enableSsl))
            throw new InvalidOperationException("OCEANDESK_SMTP_ENABLE_SSL debe ser true o false.");

        return new SmtpEmailOptions(
            host.Trim(),
            port,
            enableSsl,
            userName.Trim(),
            appPassword,
            fromAddress.Trim(),
            displayName.Trim());
    }
}
