using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
//using Ant_Simulation.Source.Ant;
//using Ant_Simulation.Source.Environment;
using Color = Microsoft.Xna.Framework.Color;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace MonoGameAntSim
{
    public class SimulationGame : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Texture2D _aboveGroundTexture;
    private Texture2D _underGroundTexture;
    private Vector2 _aboveGroundPosition;
    private Vector2 _underGroundPosition;
    private Vector2 _aboveGroundVelocity;
    private Vector2 _underGroundVelocity;
    // ... (ToDo)
    /*enum GameState
    {
        aboveGround,
        underGround,
        
    }*/

    

    public SimulationGame()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
    }
    // ... (ToDo)

    protected override void Initialize()
    {
        // ... (ToDo)

        
        _aboveGroundPosition = new Vector2(100, 100);
        _underGroundPosition = new Vector2(100, 200);
        _aboveGroundVelocity = new Vector2(2, 2);
        _underGroundVelocity = new Vector2(1, 1);

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _aboveGroundTexture = Content.Load<Texture2D>("aboveGround"); // Load texture for above ground
        _underGroundTexture = Content.Load<Texture2D>("underGround"); // Load texture for underground
    }
    // ... (ToDo)

    protected override void Update(GameTime gameTime)
    {
        // ... (ToDo)

        
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        
        // Update ants
        _aboveGroundPosition += _aboveGroundVelocity;

        // Update enemy ants
        // Bounce above ground sprite off the window edges
        if (_aboveGroundPosition.X < 0 || _aboveGroundPosition.X > _graphics.PreferredBackBufferWidth - _aboveGroundTexture.Width)
            _aboveGroundVelocity.X *= -1;

        if (_aboveGroundPosition.Y < 0 || _aboveGroundPosition.Y > _graphics.PreferredBackBufferHeight - _aboveGroundTexture.Height)
            _aboveGroundVelocity.Y *= -1;

        // Update underground sprite position based on velocity
        _underGroundPosition += _underGroundVelocity;
        
        // Bounce underground sprite off the window edges
        if (_underGroundPosition.X < 0 || _underGroundPosition.X > _graphics.PreferredBackBufferWidth - _underGroundTexture.Width)
            _underGroundVelocity.X *= -1;

        if (_underGroundPosition.Y < 0 || _underGroundPosition.Y > _graphics.PreferredBackBufferHeight - _underGroundTexture.Height)
            _underGroundVelocity.Y *= -1;

        base.Update(gameTime);
    }

    // ... (ToDo)

    protected override void Draw(GameTime gameTime)
    {
        // ... (ToDo)

        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();
        _spriteBatch.Draw(_underGroundTexture, new Rectangle(0, 0, 800, 480), Color.White);
        _spriteBatch.Draw(_underGroundTexture, _underGroundPosition, Color.White); // Draw underground sprite
        _spriteBatch.Draw(_aboveGroundTexture, _aboveGroundPosition, Color.White); // Draw above ground sprite
        _spriteBatch.End();
        

        base.Draw(gameTime);
    }
}

}