using System.IO;
using System.Net.Sockets;
using Microsoft.Data.SqlClient;

namespace Ocean_Desk_dv.Services.Offline;

/// <summary>
/// Distingue una caída de conectividad de errores de validación o de negocio.
/// No convierte cualquier excepción en una operación offline.
/// </summary>
public static class SqlServerConnectionFailureDetector
{
    private static readonly HashSet<int> NetworkErrorNumbers =
    [
        -1, -2, 0, 2, 17, 20, 26, 53, 64, 121, 233, 258,
        10053, 10054, 10060, 10061, 11001
    ];

    public static bool IsConnectionFailure(Exception exception)
    {
        for (Exception? current = exception;
             current is not null;
             current = current.InnerException)
        {
            if (current is TimeoutException ||
                current is SocketException ||
                current is IOException)
            {
                return true;
            }

            if (current is SqlException sqlException &&
                sqlException.Errors
                    .Cast<SqlError>()
                    .Any(error => NetworkErrorNumbers.Contains(error.Number)))
            {
                return true;
            }
        }

        return false;
    }

    public static bool IsMissingReceiptTable(Exception exception)
    {
        for (Exception? current = exception;
             current is not null;
             current = current.InnerException)
        {
            if (current is SqlException sqlException &&
                sqlException.Errors.Cast<SqlError>()
                    .Any(error => error.Number == 208))
            {
                return true;
            }
        }

        return false;
    }
}
