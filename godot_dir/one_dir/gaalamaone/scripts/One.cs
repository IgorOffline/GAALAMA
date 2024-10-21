using Godot;
using System;
using System.Collections.Generic;
using GaalamaBusiness.BusinessMain;
using GaalamaBusiness.BusinessMain.BusinessLogging;
using GaalamaOne.scripts;

public partial class One : Node2D
{
	private readonly ILogger _logger = new GdLogger();
	private readonly Dictionary<string, GdSceneExtended> _packedScenes = [];
	
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
			try
			{
				var listenerImpl = new GaalamaExec(_logger);
				listenerImpl.Execute();
			}
			catch (Exception ex)
			{
				GD.Print(ex.Message);
			}
			
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
		_packedScenes[IconSceneName] = new GdSceneExtended(iconScene, SceneType.Node2D);
	}

	private void FirstDraw()
	{
		var packedScene = _packedScenes[IconSceneName]!;
		if (packedScene.SceneType == SceneType.Node2D)
		{
			var newIcon = packedScene.PackedScene.Instantiate<Node2D>();
			newIcon.Position = new Vector2(325F, 125F);
			AddChild(newIcon);
		}
	}
}
