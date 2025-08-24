using Godot;
using System;

public partial class AsteroidSprite : Sprite2D
{
    public float AsteroidTexture;
    
    void PickRandomSprite()
    {
        Texture2D Asteroid1 = GD.Load<Texture2D>("res://Images/Asteroids/Asteroid1.png");
        Texture2D Asteroid2 = GD.Load<Texture2D>("res://Images/Asteroids/Asteroid2.png");
        Texture2D Asteroid3 = GD.Load<Texture2D>("res://Images/Asteroids/Asteroid3.png");

        AsteroidTexture = GD.RandRange(1, 3);

        if (AsteroidTexture == 1)
        {
            this.Texture = Asteroid1;
            GD.Print(AsteroidTexture);
        } else if (AsteroidTexture == 2)
        {
            this.Texture = Asteroid2;
            GD.Print(AsteroidTexture);
        } else if (AsteroidTexture == 3)
        {
            this.Texture = Asteroid3;
            GD.Print(AsteroidTexture);
        }
    }

    public override void _Ready()
    {
        PickRandomSprite();
    }
}
