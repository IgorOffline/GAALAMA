using Godot;
using System;
using System.Collections.Generic;
using GaalamaBridge.BridgeMain;
using GaalamaBusiness.BusinessMain;
using GaalamaBusiness.BusinessMain.BusinessLogging;

public partial class One : Node2D
{
	private readonly ILogger _logger = new GdLogger();
	private int _nextId;
	private readonly Dictionary<string, GdSceneExtended> _packedScenes = [];
	private GaalamaExec? _listenerImpl;
	
	private const string IconSceneName = "iconScene";

	private bool _shouldInit = true;
	private bool _doGaalamaExec;
	private bool _doGaalamaUndo;
	
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
			_logger.Print("<GAALAMA_EXEC>");
			try
			{
				_listenerImpl!.Execute();
			}
			catch (Exception ex)
			{
				_logger.Print(ex.Message);
			}
			
			_doGaalamaExec = false;
		}

		if (_doGaalamaUndo)
		{
			_logger.Print("<GAALAMA_UNDO>");
			try
			{
				_listenerImpl!.Undo();
			}
			catch (Exception ex)
			{
				_logger.Print(ex.Message);
			}
			
			_doGaalamaUndo = false;
		}
	}

	public override void _Input(InputEvent @event)
	{
		if (@event.IsActionPressed("gaalama_exec"))
		{
			_doGaalamaExec = true;
		}
		if (@event.IsActionPressed("gaalama_undo"))
		{
			_doGaalamaUndo = true;
		}
	}

	private void ShouldInit()
	{
		var iconScene = GD.Load<PackedScene>("res://scenes/icon.tscn");
		_packedScenes[IconSceneName] = new GdSceneExtended(iconScene, SceneType.Node2D, new GdSceneId(-1));

		_listenerImpl = new GaalamaExec(_logger);
	}

	private void FirstDraw()
	{
		var packedScene = _packedScenes[IconSceneName];
		if (packedScene.SceneType == SceneType.Node2D)
		{
			var newIcon = packedScene.PackedScene.Instantiate<Node2D>();
			newIcon.Name = IconSceneName + "_" + ++_nextId;
			newIcon.Position = new Vector2(325F, 125F);
			AddChild(newIcon);
			_packedScenes[IconSceneName] = packedScene with { SceneId = new GdSceneId(_nextId) };
		}
	}

	private void UndoFirstDraw()
	{
		//
	}
}
