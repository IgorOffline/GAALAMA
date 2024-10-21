using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using GaalamaBusiness.BusinessGenerated;

namespace GaalamaBusiness.BusinessMain;

public class GaalamaGrammarListenerImpl : IGaalamaGrammarListener
{
    public void VisitTerminal(ITerminalNode node)
    {
        //
    }

    public void VisitErrorNode(IErrorNode node)
    {
        //
    }

    public void EnterEveryRule(ParserRuleContext ctx)
    {
        //
    }

    public void ExitEveryRule(ParserRuleContext ctx)
    {
        //
    }

    public void EnterGaalamaexec(GaalamaGrammarParser.GaalamaexecContext context)
    {
        Console.WriteLine("Enter GaalamaExec");
    }

    public void ExitGaalamaexec(GaalamaGrammarParser.GaalamaexecContext context)
    {
        //
    }

    public void EnterGaalamamain(GaalamaGrammarParser.GaalamamainContext context)
    {
        //
    }

    public void ExitGaalamamain(GaalamaGrammarParser.GaalamamainContext context)
    {
        //
    }
}