using GaalamaBusiness.BusinessMain;
using Godot;

namespace GaalamaBridge.BridgeMain.BridgeCommands;

public class PlaceScene(GdMaster master, Node parent, string sceneName) : ICommand
{
    private GdLongId _sceneId = new(-1);
    
    public void Execute()
    {
        var packedScene = master.PackedScenes[sceneName];
        if (packedScene.SceneType == SceneType.Node2D)
        {
            var newChild = packedScene.PackedScene.Instantiate<Node2D>();
            _sceneId = new GdLongId(GdMaster.GetAndIncrementNextId());
            newChild.Name = sceneName + "_" + _sceneId.Val;
            parent.AddChild(newChild);
            master.PackedScenes[sceneName] = packedScene with { SceneId = new GdLongId(_sceneId.Val) };
        }
    }

    public void Undo()
    {
        foreach (var child in parent.GetChildren())
        {
            if (child.Name.ToString().EndsWith("_" + _sceneId.Val))
            {
                master.Logger.Print("Removing: " + _sceneId.Val);
                parent.RemoveChild(child);
                child.QueueFree();
            }
        }
    }
}