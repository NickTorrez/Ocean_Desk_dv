using Ocean_Desk_dv.Models.DTOs;

namespace Ocean_Desk_dv.Services.Interfaces_Services;

/// <summary>
/// Contrato del servicio de autenticación de Ocean Desk.
/// </summary>
public interface IAuthenticationService : System.IDisposable
{
    ResultadoAutenticacionDto Autenticar(string username, string password);
}
