using Godot;
using System;

public partial class Score : Node
{
    public int CurrentScore = 0;
    public int HighScore = 0;

    public override void _Process(double delta)
    {
        if (CurrentScore > HighScore)
        {
            HighScore = CurrentScore;
        }
    }
}
