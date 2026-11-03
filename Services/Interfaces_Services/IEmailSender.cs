using System.Threading;
using System.Threading.Tasks;

namespace Ocean_Desk_dv.Services.Interfaces_Services;

/// <summary>
/// Abstracción para enviar mensajes de correo electrónico.
/// La lógica de recuperación no depende de un proveedor SMTP concreto.
/// </summary>
public interface IEmailSender
{
    Task EnviarAsync(
        string destinatario,
        string asunto,
        string cuerpo,
        CancellationToken cancellationToken = default);
}
