namespace Ocean_Desk_dv.Services.Offline;

public sealed class OfflineSyncResult
{
    public int Synchronized { get; init; }

    public int Conflicts { get; init; }

    public int Failed { get; init; }

    public int Pending { get; init; }

    public bool AlreadyRunning { get; init; }
}
