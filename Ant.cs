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
    public int Wonder = 20;
    public int Direction;
    public int Looking;

    public Ant(Texture2D texture, Vector2 position, Vector2 velocity, int direction, int looking)
    {
        Texture = texture;
        Position = position;
        Velocity = velocity;
        Direction = direction;
        Looking = looking;
    }
  
}