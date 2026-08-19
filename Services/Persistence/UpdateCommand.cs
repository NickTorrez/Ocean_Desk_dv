using Microsoft.Data.SqlClient;
using System.Data;

namespace CevicheSys_Pro_2.Services.Persistence
{
    /// <summary>
    /// Subclase para ejecutar operaciones UPDATE.
    /// </summary>
    public class UpdateCommand : DatabaseConnection
    {
        public UpdateCommand() : base() { }
        public UpdateCommand(string connectionString) : base(connectionString) { }
        /// <summary>
        /// Ejecuta un UPDATE y devuelve el número de filas afectadas.
        /// </summary>
        /// <param name="query">Sentencia UPDATE parametrizada.</param>
        /// <param name="parameters">Parámetros SQL.</param>
        /// <returns>Número de filas modificadas.</returns>
        public int ExecuteUpdate(string query, SqlParameter[]? parameters = null)
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
                    throw new Exception("El UPDATE no afectó ningún registro. " +
                    "Verifica que el ID exista en la base de datos.");
                return rowsAffected;
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error SQL al ejecutar UPDATE: {ex.Message}", ex);
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
