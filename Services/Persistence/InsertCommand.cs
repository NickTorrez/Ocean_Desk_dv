using Microsoft.Data.SqlClient;
using System.Data;

namespace CevicheSys_Pro_2.Services.Persistence
{
    /// <summary>
    /// Subclase para ejecutar operaciones INSERT.
    /// Puede devolver el ID generado (IDENTITY) del nuevo registro.
    /// </summary>
    public class InsertCommand : DatabaseConnection
    {
        public InsertCommand() : base() { }
        public InsertCommand(string connectionString) : base(connectionString) { }
        /// <summary>
        /// Ejecuta un INSERT y devuelve el número de filas afectadas.
        /// </summary>
        /// <param name="query">Sentencia INSERT parametrizada.</param>
        /// <param name="parameters">Parámetros SQL.</param>
        /// <returns>Número de filas insertadas (generalmente 1).</returns>
        public int ExecuteInsert(string query, SqlParameter[]? parameters = null)
        {
            try
            {
                OpenConnection();
                _command = new SqlCommand(query, _connection);
                _command.CommandType = CommandType.Text;
                if (parameters is not null)
                    _command.Parameters.AddRange(parameters);
                return _command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error SQL al ejecutar INSERT: {ex.Message}", ex);
            }
            finally
            {
                CloseConnection();
            }
        }

        /// <summary>
        /// Ejecuta un INSERT y devuelve el ID (IDENTITY) del nuevo registro.
        /// Agrega automáticamente SELECT SCOPE_IDENTITY() a la consulta.
        /// </summary>
        /// <param name="query">Sentencia INSERT (sin SELECT SCOPE_IDENTITY).</param>
        /// <param name="parameters">Parámetros SQL.</param>
        /// <returns>ID del nuevo registro insertado, o -1 si falla.</returns>
        public int ExecuteInsertReturnId(string query, SqlParameter[]? parameters = null)
        {
            // Concatenar SELECT SCOPE_IDENTITY() para obtener el ID generado
            string queryWithId = query.TrimEnd().TrimEnd(';') + "; SELECT SCOPE_IDENTITY();";
            try
            {
                OpenConnection();
                _command = new SqlCommand(queryWithId, _connection);
                _command.CommandType = CommandType.Text;
                if (parameters is not null)
                    _command.Parameters.AddRange(parameters);
                object? result = _command.ExecuteScalar();
                return result is not null ? Convert.ToInt32(result) : -1;
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error SQL al ejecutar INSERT con ID: {ex.Message}", ex);
            }
            finally
            {
                CloseConnection();
            }
        }

        public int ExecuteInsertWithDetailsTransaction(
            string masterQuery,
            SqlParameter[] masterParameters,
            string detailQuery,
            IEnumerable<SqlParameter[]> detailParameters)
        {
            string queryWithId = masterQuery.TrimEnd().TrimEnd(';') + "; SELECT SCOPE_IDENTITY();";
            SqlTransaction? transaction = null;

            try
            {
                OpenConnection();

                if (_connection is null)
                    throw new InvalidOperationException("La conexión no ha sido inicializada.");

                transaction = _connection.BeginTransaction();

                using SqlCommand masterCommand = new SqlCommand(queryWithId, _connection, transaction)
                {
                    CommandType = CommandType.Text
                };
                masterCommand.Parameters.AddRange(masterParameters);

                object? result = masterCommand.ExecuteScalar();
                int generatedId = result is not null ? Convert.ToInt32(result) : -1;

                if (generatedId <= 0)
                    throw new InvalidOperationException("No se pudo generar el identificador maestro.");

                foreach (SqlParameter[] detailParameterSet in detailParameters)
                {
                    SqlParameter? saleIdParameter = detailParameterSet.FirstOrDefault(parameter => parameter.ParameterName == "@SaleId");
                    if (saleIdParameter is not null)
                        saleIdParameter.Value = generatedId;

                    using SqlCommand detailCommand = new SqlCommand(detailQuery, _connection, transaction)
                    {
                        CommandType = CommandType.Text
                    };
                    detailCommand.Parameters.AddRange(detailParameterSet);

                    int affectedRows = detailCommand.ExecuteNonQuery();
                    if (affectedRows <= 0)
                        throw new InvalidOperationException("No se pudo registrar uno de los detalles de la transacción.");
                }

                transaction.Commit();
                return generatedId;
            }
            catch (Exception ex) when (ex is SqlException || ex is InvalidOperationException)
            {
                try
                {
                    transaction?.Rollback();
                }
                catch (Exception rollbackEx)
                {
                    throw new Exception($"Error al revertir la transacción: {rollbackEx.Message}", rollbackEx);
                }

                throw new Exception($"Error SQL al ejecutar INSERT transaccional: {ex.Message}", ex);
            }
            finally
            {
                transaction?.Dispose();
                CloseConnection();
            }
        }
    }
}
