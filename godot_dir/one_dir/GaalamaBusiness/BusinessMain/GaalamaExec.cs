using System.Net;
using System.Net.Sockets;
using System.Text;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using GaalamaBusiness.BusinessGenerated;
using GaalamaBusiness.BusinessMain.BusinessLogging;

namespace GaalamaBusiness.BusinessMain;

public class GaalamaExec(ILogger logger)
{
    public void Execute()
    {
        Asinka();
    }

    private async void Asinka()
    {
        var hostName = Dns.GetHostName();
        IPHostEntry localhost = await Dns.GetHostEntryAsync(hostName);
        IPAddress localIpAddress = localhost.AddressList[0];
        
        IPEndPoint ipEndPoint = new(localIpAddress, 9_000);
        
        using Socket client = new(
            ipEndPoint.AddressFamily, 
            SocketType.Stream, 
            ProtocolType.Tcp);

        await client.ConnectAsync(ipEndPoint);
        while (true)
        {
            // Send message.
            var message = "Hi friends 👋!<|EOM|>";
            var messageBytes = Encoding.UTF8.GetBytes(message);
            _ = await client.SendAsync(messageBytes, SocketFlags.None);
            Console.WriteLine($"Socket client sent message: \"{message}\"");

            // Receive ack.
            var buffer = new byte[1_024];
            var received = await client.ReceiveAsync(buffer, SocketFlags.None);
            var response = Encoding.UTF8.GetString(buffer, 0, received);
            if (response == "<|ACK|>")
            {
                Console.WriteLine(
                    $"Socket client received acknowledgment: \"{response}\"");
                break;
            }
            // Sample output:
            //     Socket client sent message: "Hi friends 👋!<|EOM|>"
            //     Socket client received acknowledgment: "<|ACK|>"
        }

        client.Shutdown(SocketShutdown.Both);
    }
    
    // public void Execute()
    // {
    //     var listener = new GaalamaGrammarListenerImpl(logger);
    //
    //     var lexer = new GaalamaGrammarLexer(new AntlrFileStream("input.txt"));
    //     var tokens = new CommonTokenStream(lexer);
    //     var parser = new GaalamaGrammarParser(tokens);
    //     var tree = parser.gaalamamain();
    //     var walker = new ParseTreeWalker();
    //     walker.Walk(listener, tree);
    // }

    public void Undo()
    {
        //
    }
}