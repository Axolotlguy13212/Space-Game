using Godot;
using System;

public partial class Quit : Button
{
    public override void _Ready()
    {
        this.Pressed += OnButtonPressed;
    }

    private void OnButtonPressed()
    {
        GetTree().Quit();
    }
}
