using System;
using Ocean_Desk_dv.Models.Entities;

namespace Ocean_Desk_dv.Services.Interfaces_Services;

/// <summary>
/// Acceso a datos requerido por el proceso de autenticación.
/// </summary>
public interface IAuthenticationRepository : IDisposable
{
    /// <summary>
    /// Obtiene el usuario por nombre, incluyendo su rol y los permisos del rol.
    /// La entidad se devuelve con seguimiento para actualizar intentos y último acceso.
    /// </summary>
    User? ObtenerUsuarioPorNombre(string username);

    /// <summary>
    /// Obtiene un usuario mediante su identificador.
    /// </summary>
    User? ObtenerUsuarioPorId(int userId);

    /// <summary>
    /// Obtiene un usuario mediante su dirección de correo electrónico.
    /// Incluye su rol y devuelve la entidad con seguimiento para
    /// gestionar las operaciones de recuperación de contraseña.
    /// </summary>
    /// <param name="email">Correo electrónico registrado.</param>
    /// <returns>Usuario encontrado o null si no existe.</returns>
    User? ObtenerUsuarioPorCorreo(string email);

    /// <summary>
    /// Persiste los cambios efectuados sobre el usuario consultado.
    /// </summary>
    void GuardarCambios();

}
