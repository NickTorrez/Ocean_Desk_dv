using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Ocean_Desk_dv.Data.SQLite;

/// <summary>
/// Inicializa y actualiza el esquema local usando migraciones EF Core.
/// La primera migración debe generarse en Visual Studio antes de ejecutar
/// esta inicialización por primera vez.
/// </summary>
public static class LocalDatabaseInitializer
{
    private static readonly object SyncRoot = new();
    private static bool _initialized;

    public static void Initialize()
    {
        if (_initialized)
            return;

        lock (SyncRoot)
        {
            if (_initialized)
                return;

            using (var context =
                   OceanDeskLocalDbContextFactory.CreateContext())
            {
                context.Database.Migrate();
            }

            // WAL permite que los lectores continúen mientras se realiza
            // una escritura. No se utiliza Cache=Shared.
            using (var connection = new SqliteConnection(
                       OceanDeskLocalDbContextFactory.BuildConnectionString()))
            {
                connection.Open();

                using var command = connection.CreateCommand();
                command.CommandText = "PRAGMA journal_mode=WAL;";
                command.ExecuteScalar();
            }

            _initialized = true;
        }
    }
}
