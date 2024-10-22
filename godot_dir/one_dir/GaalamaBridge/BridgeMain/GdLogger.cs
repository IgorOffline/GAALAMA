using GaalamaBusiness.BusinessMain.BusinessLogging;
using Godot;

namespace GaalamaBridge.BridgeMain;

public class GdLogger : ILogger
{
    public LogLevel LogLevel { get; set; }
        
    public void Print(string s)
    {
        GD.Print(s);
    }
}