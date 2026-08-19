using Microsoft.Data.SqlClient;
using System.Data;


namespace CevicheSys_Pro_2.Services.Persistence
{
    /// <summary>
    /// Subclase para ejecutar operaciones DELETE.
    /// Incluye verificación de filas afectadas para detectar IDs inexistentes.
    /// </summary>
    public class DeleteCommand : DatabaseConnection
    {
        public DeleteCommand() : base() { }
        public DeleteCommand(string connectionString) : base(connectionString) { }
        /// <summary>
        /// Ejecuta un DELETE y devuelve el número de filas eliminadas.
        /// </summary>
        /// <param name="query">Sentencia DELETE parametrizada.</param>
        /// <param name="parameters">Parámetros SQL.</param>
        /// <returns>Número de filas eliminadas.</returns>
        public int ExecuteDelete(string query, SqlParameter[]? parameters = null)
        {
            try
            {
                OpenConnection();
                _command = new SqlCommand(query, _connection);
                _command.CommandType = CommandType.Text;
                if (parameters is not null)
                    _command.Parameters.AddRange(parameters);
                int rowsAffected = _command.ExecuteNonQuery();
                if (rowsAffected == 0)
                    throw new Exception("El DELETE no eliminó ningún registro. " +
                    "Verifica que el ID exista en la base de datos.");
                return rowsAffected;
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error SQL al ejecutar DELETE: {ex.Message}", ex);
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
