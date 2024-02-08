using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameAntSim.Enums;
using MonoGameAntSim.Scenes;
//using Ant_Simulation.Source.Ant;
//using Ant_Simulation.Source.Environment;
using Color = Microsoft.Xna.Framework.Color;

namespace MonoGameAntSim;

public class SimulationGame : Game
{
    private Vector2 _aboveGroundPosition;
    private AboveGroundScene _aboveGroundScene;
    private Texture2D _aboveGroundTexture;
    private Vector2 _aboveGroundVelocity;
    private SceneType _currentScene;
    private readonly GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Vector2 _underGroundPosition;
    private UnderGroundScene _underGroundScene;
    private Texture2D _underGroundTexture;

    private Vector2 _underGroundVelocity;
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
        var aboveGroundTexture = Content.Load<Texture2D>("aboveGround");
        var underGroundTexture = Content.Load<Texture2D>("underGround");

        _aboveGroundTexture = Content.Load<Texture2D>("aboveGround");
        _underGroundTexture = Content.Load<Texture2D>("underGround");

        var width = 1300;
        var hight = 900;
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

        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();


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
        _currentScene = _currentScene == SceneType.AboveGround ? SceneType.UnderGround : SceneType.AboveGround;
        Thread.Sleep(100);
    }
}