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

    public void EnterGaalamavarname(GaalamaGrammarParser.GaalamavarnameContext context)
    {
        logger.Print("Enter GaalamaVarname");

        var varname = context.children.First().GetText()!;
        logger.Print($"Varname= {varname}");
    }

    public void ExitGaalamavarname(GaalamaGrammarParser.GaalamavarnameContext context)
    {
        //
    }

    public void EnterGaalamainit(GaalamaGrammarParser.GaalamainitContext context)
    {
        logger.Print("Enter GaalamaInit");
    }

    public void ExitGaalamainit(GaalamaGrammarParser.GaalamainitContext context)
    {
        //
    }

    public void EnterGaalamabigint(GaalamaGrammarParser.GaalamabigintContext context)
    {
        logger.Print("Enter GaalamaBigint");
    }

    public void ExitGaalamabigint(GaalamaGrammarParser.GaalamabigintContext context)
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

    public void EnterGaalamainitbigint(GaalamaGrammarParser.GaalamainitbigintContext context)
    {
        logger.Print("Enter GaalamaInitbigint");
    }

    public void ExitGaalamainitbigint(GaalamaGrammarParser.GaalamainitbigintContext context)
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