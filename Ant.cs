using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameAntSim;

public class Ant
{
    public Texture2D Texture { get; set; }
    public Vector2 Position { get; set; }
    public Vector2 Velocity { get; set; }
    public Vector2 Direction { get; set; }
    public float Speed = 2;
    public float Steer = 2;
    public int Wonder = 20;

    public Ant(Texture2D texture, Vector2 position, Vector2 velocity)
    {
        Texture = texture;
        Position = position;
        Velocity = velocity;
    }
    // public void LoadContent(ContentManager content)
    // {
    //     // Load content specific to this scene
    //     Texture = content.Load<Texture2D>("ant" + rnd.Next(1, 4) + " (1)");
    // }
}