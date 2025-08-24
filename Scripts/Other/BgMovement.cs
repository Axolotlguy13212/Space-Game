using Godot;
using System;

public partial class BgMovement : Node2D
{
    public float Speed = 15f;
    public override void _Process(double delta)
    {
        GlobalPosition -= new Vector2(Speed * (float)delta, 0);

        if (this.GlobalPosition.X < -3836.0)
        {
            this.GlobalPosition = new Vector2(0, 0);
        }
    }

}
