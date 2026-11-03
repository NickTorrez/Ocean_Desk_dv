namespace Ocean_Desk_dv.Services.Offline;

/// <summary>
/// Indica que el registro local no puede aplicarse automáticamente
/// porque necesita una revisión o decisión de negocio.
/// </summary>
public sealed class OfflineSyncConflictException : Exception
{
    public OfflineSyncConflictException(string message)
        : base(message)
    {
    }
}
