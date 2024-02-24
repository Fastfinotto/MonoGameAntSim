using System;
using System.Collections.Generic;
using System.Security.Cryptography.Xml;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameAntSim.Scenes;

public class AboveGroundScene
{
    private Texture2D _texture;
    private Rectangle _destinationRectangle;
    private List<Ant> _ant;
    private float rnd2 = 1;
    private float rnd3 = 1;
    private int wonder = 1;
    private int i = 1;
    private float angle = 0;
    private int antNum = 0;
    private int ii = 0;
    
    
    // Other scene-specific variables
    public int GetRandomNumber(int minimum, int maximum)
    { 
        Random random = new Random();
        return random.Next(minimum, maximum);
    }
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

            if (ii > (_ant.Count - 1))
            {
                ii = 0;
            }

            antNum = ii;
            
            wonder = ant.Wonder;
            if (i < 1)
            {
                i = GetRandomNumber(20, 100);
            }
            // Update sprite position based on velocity
            if (_ant[antNum].Position.X <= 1280 && _ant[antNum].Position.Y <= 720)
            {

                if (i == 1)
                {
                    rnd2 = GetRandomNumber(0, 7); // 0: north, 1: northeast, 2: east, 3: southeast, 4: south, 5: southwest, 6: west, 7: northwest
                }
                switch (rnd2)
                {
                    case 0:
                        _ant[antNum].Position = new Vector2(_ant[antNum].Position.X, _ant[antNum].Position.Y - 1); // move north
                        angle = 180;
                        break;
                    case 1:
                        _ant[antNum].Position = new Vector2(_ant[antNum].Position.X + 1, _ant[antNum].Position.Y);; // move east
                        _ant[antNum].Position = new Vector2(_ant[antNum].Position.X, _ant[antNum].Position.Y - 1); // move north
                        angle = 225;
                        break;
                    case 2:
                        _ant[antNum].Position = new Vector2(_ant[antNum].Position.X + 1, _ant[antNum].Position.Y); // move east
                        angle = 270;
                        break;
                    case 3:
                        _ant[antNum].Position = new Vector2(_ant[antNum].Position.X + 1, _ant[antNum].Position.Y); // move east
                        _ant[antNum].Position = new Vector2(_ant[antNum].Position.X, _ant[antNum].Position.Y + 1); // move south
                        angle = 315;
                        break;
                    case 4:
                        _ant[antNum].Position = new Vector2(_ant[antNum].Position.X, _ant[antNum].Position.Y + 1); // move south
                        angle = 0;
                        break;
                    case 5:
                        _ant[antNum].Position = new Vector2(_ant[antNum].Position.X - 1, _ant[antNum].Position.Y); // move west
                        _ant[antNum].Position = new Vector2(_ant[antNum].Position.X, _ant[antNum].Position.Y + 1); // move south
                        angle = 45;
                        break;
                    case 6:
                        _ant[antNum].Position = new Vector2(_ant[antNum].Position.X - 1, _ant[antNum].Position.Y); // move west
                        angle = 90;
                        break;
                    case 7:
                        _ant[antNum].Position = new Vector2(_ant[antNum].Position.X - 1, _ant[antNum].Position.Y); // move west
                        _ant[antNum].Position = new Vector2(_ant[antNum].Position.X, _ant[antNum].Position.Y - 1); // move north
                        angle = 135;
                        break;
                }

                ii++;
                i--;
                // _ant[antNum].Position += SteerForce * new Vector2(rnd2, rnd2);
            }
            else if (_ant[antNum].Position.X > 1280 || _ant[antNum].Position.X < 0)
            {
                _ant[antNum].Position = new Vector2(0, _ant[antNum].Position.Y);
            }
            else if (_ant[antNum].Position.Y > 720 || _ant[antNum].Position.Y < 0)
            {
                _ant[antNum].Position = new Vector2(_ant[antNum].Position.X, 0);
            }
            
        }
        // Update logic for this scene
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        // Draw objects specific to this scene
        spriteBatch.Draw(_texture, Vector2.Zero, _destinationRectangle, Color.White);
        Vector2 origin = new Vector2(0, 0);

        foreach (var ant in _ant)
        {
            float move = MathHelper.ToRadians(angle);
            spriteBatch.Draw(_ant[antNum].Texture, _ant[antNum].Position, null, Color.White, move, origin, 1.0f, SpriteEffects.None, 1);
        }
    }
}