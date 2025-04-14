using System.Numerics;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using GaalamaBusiness.BusinessGenerated;
using GaalamaBusiness.BusinessMain.BusinessLogging;

namespace GaalamaBusiness.BusinessMain;

public class GaalamaGrammarListenerImpl(ILogger logger) : IGaalamaGrammarListener
{
    public GaalamaVariable LastVariable { get; set; } = GaalamaUtil.GaalamaVariableDefault();
    public GaalamaOperation LastOperation { get; set; } = GaalamaUtil.GaalamaOperationDefault();
    public Dictionary<string, GaalamaVariable> Values { get; set; } = new();
    
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

    public void EnterGaalamaint(GaalamaGrammarParser.GaalamaintContext context)
    {
        logger.Print("Enter GaalamaInt");
        
        var intvalue = context.children.First().GetText()!;
        //logger.Print($"IntValue= {intvalue}");
        
        switch (LastOperation.Operator)
        {
            case GaalamaOperator.None:
                logger.Print("LastOperationOperator= None");
                break;
            case GaalamaOperator.Set:
                logger.Print("LastOperationOperator= Set");
                LastVariable = LastVariable with { Value = BigInteger.Parse(intvalue) };
                break;
            case GaalamaOperator.Add:
                logger.Print("LastOperationOperator= Add");
                break;
            case GaalamaOperator.Subtract:
                logger.Print("LastOperationOperator= Subtract");
                var subtract = (BigInteger) LastVariable.Value;
                subtract -= 1;
                LastVariable = LastVariable with { Value = subtract };
                //LastVariable = LastVariable with { Value = Value. };
                break;
            default:
                logger.Print("LastOperationOperator= Unknown");
                break;
        }
    }

    public void ExitGaalamaint(GaalamaGrammarParser.GaalamaintContext context)
    {
        PrintLastVariable();
    }

    public void EnterGaalamavarname(GaalamaGrammarParser.GaalamavarnameContext context)
    {
        logger.Print("Enter GaalamaVarname");

        var varname = context.children.First().GetText()!;
        LastVariable = LastVariable with { Name = varname };
    }

    public void ExitGaalamavarname(GaalamaGrammarParser.GaalamavarnameContext context)
    {
        PrintLastVariable();
    }

    private void PrintLastVariable()
    {
        logger.Print($"LastVariable= {LastVariable}");
    }

    public void EnterGaalamaequals(GaalamaGrammarParser.GaalamaequalsContext context)
    {
        logger.Print("Enter GaalamaEquals");
    }

    public void ExitGaalamaequals(GaalamaGrammarParser.GaalamaequalsContext context)
    {
        //
    }

    public void EnterGaalamaaddoperator(GaalamaGrammarParser.GaalamaaddoperatorContext context)
    {
        logger.Print("Enter GaalamaAddoperator");
    }

    public void ExitGaalamaaddoperator(GaalamaGrammarParser.GaalamaaddoperatorContext context)
    {
        //
    }

    public void EnterGaalamasubtractoperator(GaalamaGrammarParser.GaalamasubtractoperatorContext context)
    {
        logger.Print("Enter GaalamaSubtractoperator");
        
        LastOperation = new GaalamaOperation(GaalamaOperator.Subtract);
    }

    public void ExitGaalamasubtractoperator(GaalamaGrammarParser.GaalamasubtractoperatorContext context)
    {
        //
    }

    public void EnterGaalamainit(GaalamaGrammarParser.GaalamainitContext context)
    {
        logger.Print("Enter GaalamaInit");

        LastOperation = new GaalamaOperation(GaalamaOperator.Set);
    }

    public void ExitGaalamainit(GaalamaGrammarParser.GaalamainitContext context)
    {
        //
    }

    public void EnterGaalamabigint(GaalamaGrammarParser.GaalamabigintContext context)
    {
        logger.Print("Enter GaalamaBigint");

        LastVariable = new GaalamaVariable(GaalamaType.Bigint, GaalamaUtil.GaalamaVariableDefaultName, BigInteger.Zero);
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

    public void EnterGaalamainitbigintset(GaalamaGrammarParser.GaalamainitbigintsetContext context)
    {
        //
    }

    public void ExitGaalamainitbigintset(GaalamaGrammarParser.GaalamainitbigintsetContext context)
    {
        //
    }

    public void EnterGaalamasubtract(GaalamaGrammarParser.GaalamasubtractContext context)
    {
        logger.Print("Enter GaalamaSubtract");
    }

    public void ExitGaalamasubtract(GaalamaGrammarParser.GaalamasubtractContext context)
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