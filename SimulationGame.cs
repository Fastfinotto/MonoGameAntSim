using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameAntSim.Enums;
using MonoGameAntSim.Scenes;
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
    private AboveGroundScene _aboveGroundScene;
    private UnderGroundScene _underGroundScene;
    private SceneType _currentScene;
    // ... (ToDo)

    public SimulationGame()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
    }
    // ... (ToDo)

    protected override void Initialize()
    {
        // ... (ToDo)
        Texture2D aboveGroundTexture = Content.Load<Texture2D>("aboveGround");
        Texture2D underGroundTexture = Content.Load<Texture2D>("underGround");

        _aboveGroundTexture = Content.Load<Texture2D>("aboveGround");
        _underGroundTexture = Content.Load<Texture2D>("underGround");

        int width = 1300;
        int hight = 900;
        _aboveGroundScene = new AboveGroundScene(aboveGroundTexture, width, hight);
        _underGroundScene = new UnderGroundScene(underGroundTexture, width, hight);
        _currentScene = SceneType.AboveGround;
        
        _aboveGroundPosition = new Vector2(0, 0);
        _underGroundPosition = new Vector2(0, 0);
        _aboveGroundVelocity = new Vector2(1, 1);
        _underGroundVelocity = new Vector2(1, 1);
        
        _graphics.PreferredBackBufferWidth = 1280; // Width in pixels
        _graphics.PreferredBackBufferHeight = 720; // Height in pixels
        _graphics.ApplyChanges();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _aboveGroundScene.LoadContent(Content);
        _underGroundScene.LoadContent(Content);
    }
    // ... (ToDo)

    protected override void Update(GameTime gameTime)
    {
        // ... (ToDo)
        switch (_currentScene)
        {
            case SceneType.AboveGround:
                _aboveGroundScene.Update(gameTime);
                break;
            case SceneType.UnderGround:
                _underGroundScene.Update(gameTime);
                break;
        }
        if (Keyboard.GetState().IsKeyDown(Keys.S)) 
            SwitchScene();
        
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        
        // Update ants
        //_aboveGroundPosition += _aboveGroundVelocity;

        // Update enemy ants
        // Bounce above ground sprite off the window edges
        /*if (_aboveGroundPosition.X < 0 || _aboveGroundPosition.X > _graphics.PreferredBackBufferWidth - _aboveGroundTexture.Width)
            _aboveGroundVelocity.X *= -1;

        if (_aboveGroundPosition.Y < 0 || _aboveGroundPosition.Y > _graphics.PreferredBackBufferHeight - _aboveGroundTexture.Height)
            _aboveGroundVelocity.Y *= -1;

        // Update underground sprite position based on velocity
        _underGroundPosition += _underGroundVelocity;
        
        // Bounce underground sprite off the window edges
        if (_underGroundPosition.X < 0 || _underGroundPosition.X > _graphics.PreferredBackBufferWidth - _underGroundTexture.Width)
            _underGroundVelocity.X *= -1;

        if (_underGroundPosition.Y < 0 || _underGroundPosition.Y > _graphics.PreferredBackBufferHeight - _underGroundTexture.Height)
            _underGroundVelocity.Y *= -1;*/

        base.Update(gameTime);
    }

    // ... (ToDo)

    protected override void Draw(GameTime gameTime)
    {
        // ... (ToDo)

        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();
        
        switch (_currentScene)
        {
            case SceneType.AboveGround:
                _aboveGroundScene.Draw(_spriteBatch);
                break;
            case SceneType.UnderGround:
                _underGroundScene.Draw(_spriteBatch);
                break;
        }
        
        
        _spriteBatch.End();
        

        base.Draw(gameTime);
    }
    private void SwitchScene()
    {
        _currentScene = (_currentScene == SceneType.AboveGround) ? SceneType.UnderGround : SceneType.AboveGround;
        Thread.Sleep(100);
    }
}

}