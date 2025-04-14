using Godot;
using System;

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
			var btn = GetNode<Button>("Codeline/BtnSet");
			if (btn == null)
			{
				GD.Print("btn == null");
			}
			else
			{
				btn.Pressed += () => { 
					if (btn.Text.Equals(">"))
					{
						btn.Text = "<";
					}
					else
					{
						btn.Text = ">";
					}
				};
			}

			_firstRun = false;
		}
	}
}
