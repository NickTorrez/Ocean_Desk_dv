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

    User? ObtenerUsuarioPorId(int userId);

    /// <summary>
    /// Persiste los cambios efectuados sobre el usuario consultado.
    /// </summary>
    void GuardarCambios();

}
