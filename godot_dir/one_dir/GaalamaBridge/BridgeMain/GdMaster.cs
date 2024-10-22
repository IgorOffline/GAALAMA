using GaalamaBusiness.BusinessMain;
using GaalamaBusiness.BusinessMain.BusinessLogging;

namespace GaalamaBridge.BridgeMain;

public class GdMaster(ILogger logger, GaalamaExec gaalamaExec)
{
    public ILogger Logger => logger;
    public GaalamaExec GaalamaExec => gaalamaExec;
    public readonly Dictionary<string, GdSceneExtended> PackedScenes = [];
    private long _nextId;

    public long GetNextId()
    {
        return _nextId;
    }
    
    public long GetAndIncrementNextId()
    {
        return _nextId++;
    }
}