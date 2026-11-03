using System;

namespace Ocean_Desk_dv.Data.SQLite.Entities;

/// <summary>
/// Registro persistente de una operación que todavía debe aplicarse
/// en la base de datos principal.
/// </summary>
public sealed class OfflineOperation
{
    public Guid OperationId { get; set; }

    public string EntityType { get; set; } = string.Empty;

    public string Action { get; set; } = string.Empty;

    public int LocalRecordId { get; set; }

    public string PayloadJson { get; set; } = string.Empty;

    public OfflineOperationStatus Status { get; set; } =
        OfflineOperationStatus.Pending;

    public int AttemptCount { get; set; }

    public DateTime CreatedAtUtc { get; set; }

    public DateTime? LastAttemptAtUtc { get; set; }

    public DateTime? NextAttemptAtUtc { get; set; }

    public DateTime? SynchronizedAtUtc { get; set; }

    public string? LastError { get; set; }
}

public enum OfflineOperationStatus
{
    Pending = 0,
    Processing = 1,
    Retry = 2,
    Synchronized = 3,
    Conflict = 4,
    PermanentError = 5
}
