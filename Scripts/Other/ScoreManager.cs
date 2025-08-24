using Godot;
using System;

public partial class ScoreManager : Node
{
    [Export]
    public NodePath ScoreTextPath;

    [Export]
    public NodePath HighScoreTextPath;

    [Export]
    public NodePath ScoreScriptPath;

    private RichTextLabel ScoreText;
    private RichTextLabel HighScoreText;

    private Score scorescript;

    public override void _Ready()
    {
        ScoreText = GetNode<RichTextLabel>(ScoreTextPath);
        HighScoreText = GetNode<RichTextLabel>(HighScoreTextPath);

        if (ScoreScriptPath != null)
        {
            scorescript = GetNode<Score>(ScoreScriptPath);
        }
    }

    public override void _Process(double delta)
    {
        if (scorescript != null)
        {
            if (ScoreText != null)
                ScoreText.Text = "Score: " + scorescript.CurrentScore;

            if (HighScoreText != null)
                HighScoreText.Text = "High Score: " + scorescript.HighScore;
        }
    }
}
