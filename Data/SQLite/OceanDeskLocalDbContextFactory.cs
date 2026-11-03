using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Ocean_Desk_dv.Data.SQLite;

/// <summary>
/// Crea contextos SQLite independientes.
/// El archivo se guarda en LocalAppData, no junto al ejecutable,
/// porque la carpeta de instalación puede no permitir escritura.
/// </summary>
public static class OceanDeskLocalDbContextFactory
{
    public static string GetDatabasePath()
    {
        string localAppData = Environment.GetFolderPath(
            Environment.SpecialFolder.LocalApplicationData);

        if (string.IsNullOrWhiteSpace(localAppData))
        {
            throw new InvalidOperationException(
                "Windows no proporcionó una carpeta LocalAppData válida.");
        }

        return Path.Combine(
            localAppData,
            "OceanDesk",
            "Data",
            "OceanDeskLocal.db");
    }

    public static string BuildConnectionString()
    {
        string databasePath = GetDatabasePath();
        string? directory = Path.GetDirectoryName(databasePath);

        if (string.IsNullOrWhiteSpace(directory))
        {
            throw new InvalidOperationException(
                "No fue posible determinar la carpeta de la base SQLite.");
        }

        Directory.CreateDirectory(directory);

        var builder = new SqliteConnectionStringBuilder
        {
            DataSource = databasePath,
            Mode = SqliteOpenMode.ReadWriteCreate,
            ForeignKeys = true,
            DefaultTimeout = 30,
            Pooling = true
        };

        return builder.ToString();
    }

    public static OceanDeskLocalDbContext CreateContext()
    {
        var options = new DbContextOptionsBuilder<OceanDeskLocalDbContext>()
            .UseSqlite(BuildConnectionString())
            .Options;

        return new OceanDeskLocalDbContext(options);
    }
}
