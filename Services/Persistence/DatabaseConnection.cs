using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace CevicheSys_Pro_2.Services.Persistence
{
    /// <summary>
    /// Superclase base para el acceso a SQL Server 2022.
    /// Gestiona el ciclo de vida de la conexión (abrir, cerrar, liberar).
    /// Las subclases heredan la conexión y la utilizan para sus operaciones.
    /// </summary>

    public abstract class DatabaseConnection : IDisposable
    {
        //Campos Protegidos
        //'protected' permite que las subclases accedan directamente a estos miembros.

        protected SqlConnection? _connection;
        protected SqlCommand? _command;
        protected bool _disposed = false;

        //Constructor

        /// <summary>
        /// Inicializa la conexión leyendo la cadena desde appsettings.json.
        /// </summary>
        protected DatabaseConnection()
        {
            string connectionString = GetConnectionString();
            _connection = new SqlConnection(connectionString);
        }

        /// <summary>
        /// Inicializa la conexión con una cadena de conexión explícita.
        /// Útil para múltiples bases de datos o conexiones dinámicas.
        /// </summary>
        /// <param name="connectionString">Cadena de conexión a SQL Server.</param>
        protected DatabaseConnection(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
        }

        //Métodos de Conexión

        /// <summary>
        /// Abre la conexión a SQL Server si no está ya abierta.
        /// </summary>
        protected void OpenConnection()
        {
            if (_connection is null)
                throw new InvalidOperationException("La conexión no ha sido inicializada.");
            if (_connection.State == System.Data.ConnectionState.Closed)
                _connection.Open();
        }
        /// <summary>
        /// Cierra la conexión a SQL Server si está abierta.
        /// </summary>
        protected void CloseConnection()
        {
            if (_connection is not null &&
            _connection.State == System.Data.ConnectionState.Open)
            {
                _connection.Close();
            }
        }

        //Configuración

        /// <summary>
        /// Lee la cadena de conexión desde appsettings.json.
        /// </summary>
        private static string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
            .Build();
            string? connStr = config.GetConnectionString("DefaultConnection");
            if (string.IsNullOrEmpty(connStr))
                throw new InvalidOperationException(
                "No se encontró 'DefaultConnection' en appsettings.json.");
            return connStr;
        }

        //Pruebas de Conexión Publicas

        /// <summary>
        /// Verifica que la conexión a SQL Server es exitosa.
        /// Útil para diagnóstico al iniciar la aplicación.
        /// </summary>
        /// <returns>True si la conexión fue exitosa; false en caso contrario.</returns>
        public bool TestConnection()
        {
            try
            {
                OpenConnection();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                CloseConnection();
            }
        }

        //IDisposable (Liberar Recursos)

        /// <summary>
        /// Libera los recursos no administrados (conexión y comando SQL).
        /// Siempre usar 'using' o llamar a Dispose() cuando termine el uso.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _command?.Dispose();
                    CloseConnection();
                    _connection?.Dispose();
                }
                _disposed = true;
            }
        }

        /// <summary>
        /// **Conceptos clave de esta superclase:**
        /// Es `abstract`: no se puede instanciar directamente, solo heredar.
        /// Implementa `IDisposable` para garantizar que la conexión siempre se libere.
        /// Los campos `_connection` y `_command` son `protected` para que las subclases los usen.
        /// Lee la configuración desde `appsettings.json`, centralizando el dato sensible.
        /// </summary>
    }
}
