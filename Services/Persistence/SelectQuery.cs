using Microsoft.Data.SqlClient;
using System.Data;

namespace CevicheSys_Pro_2.Services.Persistence
{
    /// <summary>
    /// Subclase para ejecutar consultas SELECT.
    /// Devuelve datos como DataTable para uso directo en controles Windows Forms
    /// (DataGridView, ComboBox, ListBox, etc.).
    /// </summary>
    public class SelectQuery : DatabaseConnection
    {
        // Hereda _connection y _command de la superclase DatabaseConnection.
        public SelectQuery() : base() { }
        public SelectQuery(string connectionString) : base(connectionString) { }
        /// <summary>
        /// Ejecuta una consulta SELECT y devuelve un DataTable con los resultados.
        /// </summary>
        /// <param name="query">Consulta SQL parametrizada.</param>
        /// <param name="parameters">Parámetros SQL (previenen inyección SQL).</param>
        /// <returns>DataTable con los registros encontrados.</returns>
        public DataTable ExecuteSelect(string query,
        SqlParameter[]? parameters = null)
        {
            DataTable result = new DataTable();
            try
            {
                OpenConnection();
                _command = new SqlCommand(query, _connection);
                _command.CommandType = CommandType.Text;
                if (parameters is not null)
                    _command.Parameters.AddRange(parameters);
                using SqlDataAdapter adapter = new SqlDataAdapter(_command);
                adapter.Fill(result);
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error SQL al ejecutar SELECT: {ex.Message}", ex);
            }
            finally
            {
                CloseConnection();
            }
            return result;
        }

        /// <summary>
        /// Ejecuta un stored procedure SELECT y devuelve un DataTable.
        /// </summary>
        /// <param name="storedProcedure">Nombre del procedimiento almacenado.</param>
        /// <param name="parameters">Parámetros del SP.</param>
        public DataTable ExecuteStoredProcedure(string storedProcedure,
        SqlParameter[]? parameters = null)
        {
            DataTable result = new DataTable();
            try
            {
                OpenConnection();
                _command = new SqlCommand(storedProcedure, _connection);
                _command.CommandType = CommandType.StoredProcedure;
                if (parameters is not null)
                    _command.Parameters.AddRange(parameters);
                using SqlDataAdapter adapter = new SqlDataAdapter(_command);
                adapter.Fill(result);
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error SQL al ejecutar SP '{storedProcedure}': {ex.Message}", ex);
            }
            finally
            {
                CloseConnection();
            }
            return result;
        }

        /// <summary>
        /// Ejecuta una consulta y devuelve un único valor escalar (COUNT, SUM, MAX, etc.).
        /// </summary>
        public object? ExecuteScalar(string query, SqlParameter[]? parameters = null)
        {
            try
            {
                OpenConnection();
                _command = new SqlCommand(query, _connection);
                _command.CommandType = CommandType.Text;
                if (parameters is not null)
                    _command.Parameters.AddRange(parameters);
                return _command.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error SQL al ejecutar Scalar: {ex.Message}", ex);
            }
            finally
            {
                CloseConnection();
            }
        }

        public bool IsDuplicate(string query, SqlParameter[]? parameters = null)
        {
            try
            {
                OpenConnection ();

                _command = new SqlCommand(query, _connection);
                _command.CommandType |= CommandType.Text;

                if ( parameters is not null)
                    _command.Parameters.AddRange(parameters);
               
                return Convert.ToBoolean(_command.ExecuteScalar());

            }
            catch(Exception ex)
            {
                throw new Exception(
                    $"Error al ejecutar consulta escalar. {ex.Message}", ex);
            }
        }
    }
}
