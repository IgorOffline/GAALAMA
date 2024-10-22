using GaalamaBusiness.BusinessMain;
using Godot;

namespace GaalamaBridge.BridgeMain.BridgeCommands;

public class PlaceScene(GdMaster master, Node parent, string sceneName) : ICommand
{
    public void Execute()
    {
        var packedScene = master.PackedScenes[sceneName];
        if (packedScene.SceneType == SceneType.Node2D)
        {
            var newChild = packedScene.PackedScene.Instantiate<Node2D>();
            newChild.Name = sceneName + "_" + master.GetAndIncrementNextId();
            newChild.Position = new Vector2(325F, 125F);
            parent.AddChild(newChild);
            master.PackedScenes[sceneName] = packedScene with { SceneId = new GdSceneId(master.GetNextId()) };
        }
    }

    public void Undo()
    {
        //
    }
}