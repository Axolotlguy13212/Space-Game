using Godot;
using System;

public partial class Movement : Area2D
{
    public float MovementSpeed = 10.0f;

	public Node2D spawner;

	public bool CanMove = true;

	public Sprite2D sprite;

	//public LiveScript liveScript = (LiveScript)GD.Load<Node>("/root/LiveScript.cs");

	//public int Lives;

	//Label myLabel;


	public override void _Ready()
	{
		// You must call this if not already set in the editor
		Monitoring = true;
		spawner = GetParent().GetNode<Node2D>("Asteroid Spawner");
		sprite = GetNode<Sprite2D>("Sprite2D");
		//myLabel = GetNode<Label>("Lives_Text");
	}

	public override void _Process(double delta)
	{
		Vector2 velocity = Vector2.Zero;

		if (CanMove)
		{
			Vector2 inputDirection = Vector2.Zero;

			if (Input.IsActionPressed("ui_right"))
			{
				inputDirection.X += MovementSpeed;
				sprite.FlipH = false; // Facing right
			}
			if (Input.IsActionPressed("ui_left"))
			{
				inputDirection.X -= MovementSpeed;
				sprite.FlipH = true; // Facing left
			}
			if (Input.IsActionPressed("ui_up"))
			{
				inputDirection.Y -= MovementSpeed;
			}
			if (Input.IsActionPressed("ui_down"))
			{
				inputDirection.Y += MovementSpeed;
			}

			if (inputDirection != Vector2.Zero)
			{
				velocity += inputDirection.Normalized();
			}
		}





		// DO NOT use Position += in Area2D, this bypasses physics
		GlobalPosition += velocity.Normalized() * MovementSpeed;
		// Lives are taken away when death

		foreach (Node area in GetOverlappingAreas())
		{
			if (area.IsInGroup("Asteroid"))
			{
				GD.Print("Asteroid detected!");
				//liveScript.Lives += -1;
				foreach (Area2D asteroid in GetTree().GetNodesInGroup("Asteroid"))
				{
					asteroid.QueueFree();
					spawner.QueueFree();
					CanMove = false;
					GetTree().Quit();

				}

				//myLabel.Text
			}

		}
		


    }
}
