using Godot;
using System;
using System.Collections.Generic;

public partial class One : Node2D
{
	private readonly Dictionary<string, PackedScene?> _packedScenes = [];
	
	private const string IconSceneName = "iconScene";

	private bool _shouldInit = true;
	private bool _doGaalamaExec;
	
	public override void _Ready()
	{
		GD.Print("<One>");
	}
	
	public override void _Process(double delta)
	{
		if (_shouldInit)
		{
			ShouldInit();

			FirstDraw();
			
			_shouldInit = false;
		}

		if (_doGaalamaExec)
		{
			GD.Print("<GAALAMA_EXEC>");
			
			_doGaalamaExec = false;
		}
	}

	public override void _Input(InputEvent @event)
	{
		if (@event.IsActionPressed("gaalama_exec"))
		{
			_doGaalamaExec = true;
		}
	}

	private void ShouldInit()
	{
		var iconScene = GD.Load<PackedScene>("res://scenes/icon.tscn");
		_packedScenes[IconSceneName] = iconScene;
	}

	private void FirstDraw()
	{
		var newIcon = _packedScenes[IconSceneName]!.Instantiate<Node2D>();
		newIcon.Position = new Vector2(325F, 125F);
		AddChild(newIcon);
	}
}
