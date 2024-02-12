using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameAntSim.Scenes;

public class AboveGroundScene
{
    private Texture2D _texture;
    private Rectangle _destinationRectangle;
    private List<Ant> _ant;

    private Vector2 _direction;
    // Other scene-specific variables

    public AboveGroundScene(Texture2D texture, int width, int height)
    {
        _ant = new List<Ant>();
        _texture = texture;
        _destinationRectangle = new Rectangle(0, 0, width, height);
        
        // Initialize other scene-specific variables
    }
    public void AddAnt(Ant ant)
    {
        _ant.Add(ant);
    }

    public void LoadContent(ContentManager content)
    {
        // Load content specific to this scene
        _texture = content.Load<Texture2D>("aboveGround");
    }

    public void Update(GameTime gameTime)
    {
        
        foreach (var ant in _ant)
        {
            // Update sprite position based on velocity
            if (ant.Position.X <= 1280 && ant.Position.Y <= 720)
            {
                ant.Position += ant.Velocity;
            }
            else if (ant.Position.X > 1280 || ant.Position.X < 0)
            {
                ant.Position = new Vector2(0, ant.Position.Y);
            }
            else if (ant.Position.Y > 720 || ant.Position.Y < 0)
            {
                ant.Position = new Vector2(ant.Position.X, 0);
            }
            
        }
        
        // Update logic for this scene
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        // Draw objects specific to this scene
        spriteBatch.Draw(_texture, Vector2.Zero, _destinationRectangle, Color.White);
        foreach (var ant in _ant)
        {
            spriteBatch.Draw(ant.Texture, ant.Position, Color.White);
        }
    }
}