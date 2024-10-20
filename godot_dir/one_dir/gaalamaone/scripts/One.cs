using Godot;
using System;

public partial class One : Node2D
{
    public override void _Ready()
    {
        GD.Print("<One>");
    }
    
    public override void _Process(double delta)
    {
    }
}