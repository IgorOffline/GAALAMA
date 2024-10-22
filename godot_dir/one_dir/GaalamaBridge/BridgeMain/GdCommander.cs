using GaalamaBusiness.BusinessMain;
using GaalamaBusiness.BusinessMain.BusinessLogging;

namespace GaalamaBridge.BridgeMain;

public class GdCommander(ILogger logger)
{
    private readonly List<ICommand> _commands = [];

    public void Execute(ICommand command)
    {
        command.Execute();
        _commands.Add(command);
    }

    public void Undo()
    {
        var lastCommand = _commands.Last();
        lastCommand.Undo();
        _commands.Remove(lastCommand);
    }
}