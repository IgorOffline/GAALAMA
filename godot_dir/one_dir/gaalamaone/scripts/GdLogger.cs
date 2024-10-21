using GaalamaBusiness.BusinessMain.BusinessLogging;
using Godot;

namespace GaalamaOne.scripts;

public class GdLogger : ILogger
{
    public LogLevel LogLevel { get; set; }
        
    public void Print(string s)
    {
        GD.Print(s);
    }
}