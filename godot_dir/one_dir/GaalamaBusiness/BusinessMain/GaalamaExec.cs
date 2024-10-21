using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using GaalamaBusiness.BusinessGenerated;

namespace GaalamaBusiness.BusinessMain;

public class GaalamaExec
{
    public void Execute()
    {
        var listener = new GaalamaGrammarListenerImpl();

        var lexer = new GaalamaGrammarLexer(new AntlrFileStream("input.txt"));
        var tokens = new CommonTokenStream(lexer);
        var parser = new GaalamaGrammarParser(tokens);
        var tree = parser.gaalamamain();
        var walker = new ParseTreeWalker();
        walker.Walk(listener, tree);
    }
}