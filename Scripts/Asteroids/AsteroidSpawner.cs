using Godot;
using System;

public partial class AsteroidSpawner : Node2D
{
    private PackedScene Asteroid = GD.Load<PackedScene>("res://Scenes/Prefabs/Asteroid.tscn");
    public float AsteroidPosition;

    // Beat-based spawn timing
    private float bpm = 120f;
    private float beatLength;
    private float timeSinceLastBeat = 0f;

    private AudioStreamPlayer musicPlayer;

    public override void _Ready()
    {
        // Calculate beat length
        beatLength = 60f / bpm;

        // Adjust this path based on your scene!
        musicPlayer = GetNodeOrNull<AudioStreamPlayer>("AudioStreamPlayer");
        if (musicPlayer == null)
        {
            GD.PrintErr("AudioStreamPlayer not found! Make sure it’s a child of this node or fix the path.");
        }
    }

    public override void _Process(double delta)
    {
        if (Input.IsActionJustPressed("SpawnAsteroid"))
        {
            Spawn();
        }

        // Only spawn to the beat if the music is playing and we have a valid player
        if (musicPlayer != null && musicPlayer.Playing)
        {
            timeSinceLastBeat += (float)delta;

            if (timeSinceLastBeat >= beatLength)
            {
                Spawn();
                timeSinceLastBeat -= beatLength;
            }
        }
    }

    public void RandomizeY()
    {
        AsteroidPosition = GD.RandRange(0, 1080);
    }

    void Spawn()
    {
        if (Asteroid == null)
        {
            GD.PrintErr("Asteroid scene not found!");
            return;
        }
        GD.Print($"Spawning asteroid at: ({this.Position.X}, {AsteroidPosition})");


        var asteroidInstance = Asteroid.Instantiate<Area2D>();

        RandomizeY();

        GetTree().CurrentScene.AddChild(asteroidInstance);

        asteroidInstance.GlobalPosition = new Vector2(this.GlobalPosition.X, AsteroidPosition);

    }
}
