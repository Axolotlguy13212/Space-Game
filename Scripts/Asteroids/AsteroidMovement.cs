using Godot;
using System;

public partial class AsteroidMovement : Area2D
{
    public float MovementSpeed;

    [Export]
    public NodePath ScoreScriptPath;

    private Score scorescript;

    public override void _Ready()
    {
        MovementSpeed = GD.RandRange(10, 30);

        if (ScoreScriptPath != null)
        {
            scorescript = GetNode<Score>(ScoreScriptPath);
        }
    }

    public override void _Process(double delta)
    {
        Vector2 velocity = Vector2.Left;
        Position += velocity.Normalized() * MovementSpeed;

        DeleteAsteroid();
    }

    void DeleteAsteroid()
    {
        if (Position.X < -1500.0)
        {
            if (scorescript != null)
            {
                scorescript.CurrentScore += 1;
            }
            QueueFree();
        }
    }
}
