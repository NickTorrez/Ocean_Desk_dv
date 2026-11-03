using System;

namespace Ocean_Desk_dv.Data.SQLite.Entities;

/// <summary>
/// Copia local mínima de un cliente. ServerCustomerId queda vacío
/// mientras el registro todavía no exista en SQL Server.
/// </summary>
public sealed class LocalCustomer
{
    public int LocalCustomerId { get; set; }

    public int? ServerCustomerId { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string? Phone { get; set; }

    public bool IsActive { get; set; } = true;

    public DateTime CreatedAtUtc { get; set; }

    public DateTime? CachedAtUtc { get; set; }

    public DateTime? SynchronizedAtUtc { get; set; }

    public LocalCustomerSyncStatus SyncStatus { get; set; } =
        LocalCustomerSyncStatus.Pending;

    public string? LastSyncError { get; set; }
}

public enum LocalCustomerSyncStatus
{
    Pending = 0,
    Synchronized = 1,
    Conflict = 2,
    PermanentError = 3
}
