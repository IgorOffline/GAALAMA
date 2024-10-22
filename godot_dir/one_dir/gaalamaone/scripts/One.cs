using Godot;
using System;
using GaalamaBridge.BridgeMain;
using GaalamaBusiness.BusinessMain;

public partial class One : Node2D
{
	private GdMaster? _master;
	
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
			_master!.Logger.Print("<GAALAMA_EXEC>");
			try
			{
				_master.GaalamaExec.Execute();
			}
			catch (Exception ex)
			{
				_master.Logger.Print(ex.Message);
			}
			
			_doGaalamaExec = false;
		}

		if (_doGaalamaUndo)
		{
			_master!.Logger.Print("<GAALAMA_UNDO>");
			try
			{
				_master.GaalamaExec.Undo();
			}
			catch (Exception ex)
			{
				_master.Logger.Print(ex.Message);
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
		var logger = new GdLogger();
		_master = new GdMaster(logger, new GaalamaExec(logger));
		
		var iconScene = GD.Load<PackedScene>("res://scenes/icon.tscn");
		_master.PackedScenes[IconSceneName] = new GdSceneExtended(iconScene, SceneType.Node2D, new GdSceneId(-1));
	}

	private void FirstDraw()
	{
		var packedScene = _master!.PackedScenes[IconSceneName];
		if (packedScene.SceneType == SceneType.Node2D)
		{
			var newIcon = packedScene.PackedScene.Instantiate<Node2D>();
			newIcon.Name = IconSceneName + "_" + _master.GetAndIncrementNextId();
			newIcon.Position = new Vector2(325F, 125F);
			AddChild(newIcon);
			_master.PackedScenes[IconSceneName] = packedScene with { SceneId = new GdSceneId(_master.GetNextId()) };
		}
	}

	private void UndoFirstDraw()
	{
		//
	}
}
