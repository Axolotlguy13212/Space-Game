using Godot;
using System;

public partial class Play : Button
{
    public override void _Ready()
    {
        this.Pressed += OnButtonPressed;
    }

    public void OnButtonPressed()
    {
        GetTree().ChangeSceneToFile("res://Scenes/Normal/Space.tscn");
    }

}
