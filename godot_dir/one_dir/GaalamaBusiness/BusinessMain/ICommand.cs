namespace GaalamaBusiness.BusinessMain;

public interface ICommand
{
    void Execute();

    void Undo();
}