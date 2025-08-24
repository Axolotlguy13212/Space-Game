using Godot;
using System;
using System.ComponentModel;

public partial class Movement_AlienShip : CharacterBody2D
{
    [Export] public int Speed = 200;
    [Export] public int WalkSpeed = 200;
    [Export] public int SprintSpeed = 500;
    [Export] public int JumpForce = 400;
    [Export] public int Gravity = 900;

    public override void _PhysicsProcess(double delta)
    {
        Vector2 velocity = Velocity;

        // Apply gravity
        if (!IsOnFloor())
            velocity.Y += Gravity * (float)delta;
        else
            velocity.Y = 0;

        // Move left/right
        velocity.X = 0;
        if (Input.IsActionPressed("ui_left"))
            velocity.X = -Speed;
        if (Input.IsActionPressed("ui_right"))
            velocity.X = Speed;

        // Jump
        if (Input.IsActionJustPressed("jump") && IsOnFloor())
            velocity.Y = -JumpForce;

        Velocity = velocity;
        MoveAndSlide();
        GD.Print("On floor: " + IsOnFloor());

        if (Input.IsActionPressed("Sprint"))
        {
            Speed = SprintSpeed;
        }
        if (Input.IsActionJustReleased("Sprint"))
        {
            Speed = WalkSpeed;
        }

    }
}
