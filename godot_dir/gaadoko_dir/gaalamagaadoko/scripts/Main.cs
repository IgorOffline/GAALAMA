using Godot;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

public partial class Main : Node
{
	private bool _firstRun = true;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print("<MAIN>");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (_firstRun)
		{
			Servero();
			
			_firstRun = false;
		}
		
		// if (_firstRun)
		// {
		// 	var btn = GetNode<Button>("Codeline/BtnSet");
		// 	if (btn == null)
		// 	{
		// 		GD.Print("btn == null");
		// 	}
		// 	else
		// 	{
		// 		btn.Pressed += () => { 
		// 			if (btn.Text.Equals(">"))
		// 			{
		// 				btn.Text = "<";
		// 			}
		// 			else
		// 			{
		// 				btn.Text = ">";
		// 			}
		// 		};
		// 	}
		//
		// 	_firstRun = false;
		// }
	}

	private async void Servero()
	{
		var hostName = Dns.GetHostName();
		IPHostEntry localhost = await Dns.GetHostEntryAsync(hostName);
		IPAddress localIpAddress = localhost.AddressList[0];
		
		IPEndPoint ipEndPoint = new(localIpAddress, 9_000);
		
		using Socket listener = new(
			ipEndPoint.AddressFamily,
			SocketType.Stream,
			ProtocolType.Tcp);

		listener.Bind(ipEndPoint);
		listener.Listen(100);

		var handler = await listener.AcceptAsync();
		
		while (true)
		{
			// Receive message.
			var buffer = new byte[1_024];
			var received = await handler.ReceiveAsync(buffer, SocketFlags.None);
			var response = Encoding.UTF8.GetString(buffer, 0, received);
    
			var eom = "<|EOM|>";
			if (response.IndexOf(eom) > -1 /* is end of message */)
			{
				Console.WriteLine(
					$"Socket server received message: \"{response.Replace(eom, "")}\"");

				var ackMessage = "<|ACK|>";
				var echoBytes = Encoding.UTF8.GetBytes(ackMessage);
				await handler.SendAsync(echoBytes, 0);
				Console.WriteLine(
					$"Socket server sent acknowledgment: \"{ackMessage}\"");

				break;
			}
			// Sample output:
			//    Socket server received message: "Hi friends 👋!"
			//    Socket server sent acknowledgment: "<|ACK|>"
		}
	}
}
