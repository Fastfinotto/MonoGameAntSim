using System;
using System.Collections.Generic;
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
    Random rnd = new Random();

    private float rnd2 = 1;
    // Random rnd3 = new Random();
    // ... (ToDo)

    public SimulationGame()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
    }
    // ... (ToDo)
    public double GetRandomNumber(double minimum, double maximum)
    { 
        Random random = new Random();
        return random.NextDouble() * (maximum - minimum) + minimum;
    }

    protected override void Initialize()
    {
        // ... (ToDo)
        var aboveGroundTexture = Content.Load<Texture2D>("aboveGround");
        var underGroundTexture = Content.Load<Texture2D>("underGround");

        _aboveGroundTexture = Content.Load<Texture2D>("aboveGround");
        _underGroundTexture = Content.Load<Texture2D>("underGround");

        var width = 1280;
        var hight = 720;
        _aboveGroundScene = new AboveGroundScene(aboveGroundTexture, width, hight);
        _underGroundScene = new UnderGroundScene(underGroundTexture, width, hight);
        _currentScene = SceneType.AboveGround;

        _aboveGroundPosition = new Vector2(0, 0);
        _underGroundPosition = new Vector2(0, 0);
        _aboveGroundVelocity = new Vector2(rnd2, rnd2);
        _underGroundVelocity = new Vector2(1, 1);

        _graphics.PreferredBackBufferWidth = width; // Width in pixels
        _graphics.PreferredBackBufferHeight = hight; // Height in pixels - screen sizes
        _graphics.ApplyChanges();
        
        Texture2D antTexture = Content.Load<Texture2D>("ant" + rnd.Next(1, 4));
        Ant ant = new Ant(antTexture, new Vector2(300, 300), _aboveGroundVelocity);
        _aboveGroundScene.AddAnt(ant);
        _aboveGroundScene.AddAnt(ant);

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

        rnd2 = (float)GetRandomNumber(-1.5, 2);
        

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