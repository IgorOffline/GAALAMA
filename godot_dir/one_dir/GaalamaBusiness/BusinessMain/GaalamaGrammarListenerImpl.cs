using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using GaalamaBusiness.BusinessGenerated;
using GaalamaBusiness.BusinessMain.BusinessLogging;

namespace GaalamaBusiness.BusinessMain;

public class GaalamaGrammarListenerImpl(ILogger logger) : IGaalamaGrammarListener
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
        logger.Print("Enter GaalamaExec");
    }

    public void ExitGaalamaexec(GaalamaGrammarParser.GaalamaexecContext context)
    {
        //
    }

    public void EnterGaalamadi(GaalamaGrammarParser.GaalamadiContext context)
    {
        logger.Print("Enter GaalamaDi");
    }

    public void ExitGaalamadi(GaalamaGrammarParser.GaalamadiContext context)
    {
        //
    }

    public void EnterGaalamado(GaalamaGrammarParser.GaalamadoContext context)
    {
        logger.Print("Enter GaalamaDo");
    }

    public void ExitGaalamado(GaalamaGrammarParser.GaalamadoContext context)
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