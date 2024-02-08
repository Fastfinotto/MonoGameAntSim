using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameAntSim.Scenes;

public class AboveGroundScene
{
    private Texture2D _texture;
    private Rectangle _destinationRectangle;
    // Other scene-specific variables

    public AboveGroundScene(Texture2D texture, int width, int height)
    {
        _texture = texture;
        _destinationRectangle = new Rectangle(0, 0, width, height);
        // Initialize other scene-specific variables
    }

    public void LoadContent(ContentManager content)
    {
        // Load content specific to this scene
        _texture = content.Load<Texture2D>("aboveGround");
    }

    public void Update(GameTime gameTime)
    {
        // Update logic for this scene
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        // Draw objects specific to this scene
        spriteBatch.Draw(_texture, Vector2.Zero, _destinationRectangle, Color.White);
    }
}