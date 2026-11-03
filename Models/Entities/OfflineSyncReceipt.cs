namespace Ocean_Desk_dv.Models.Entities;

/// <summary>
/// Comprobante de una operación offline ya aplicada en SQL Server.
/// La fila se inserta en la misma transacción que el registro de negocio.
/// </summary>
public sealed class OfflineSyncReceipt
{
    public Guid OperationId { get; set; }

    public string EntityType { get; set; } = null!;

    public string ServerRecordId { get; set; } = null!;

    public string PayloadHash { get; set; } = null!;

    public DateTime ProcessedAtUtc { get; set; }
}
