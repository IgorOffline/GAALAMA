using GaalamaBusiness.BusinessMain;
using GaalamaBusiness.BusinessMain.BusinessLogging;

namespace GaalamaBridge.BridgeMain;

public class GdMaster(ILogger logger, GaalamaExec gaalamaExec, GdCommander commander)
{
    public ILogger Logger => logger;
    public GaalamaExec GaalamaExec => gaalamaExec;
    public GdCommander Commander => commander;
    public readonly Dictionary<string, GdSceneExtended> PackedScenes = [];
    private static long _nextId;

    public static long GetNextId()
    {
        return _nextId;
    }
    
    public static long GetAndIncrementNextId()
    {
        return ++_nextId;
    }
}