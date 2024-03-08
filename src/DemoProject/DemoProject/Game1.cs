using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DemoProject;

public class Game1 : Game
{
    List<GameObject> gameObjects;
    List<GameObject> targets;
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    Player player;
    static Random rng = new Random();
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        _graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
        _graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }
    protected SoccerGoal SpawnGoal()
    {
        int x = rng.Next(0, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width);
        int y = rng.Next(0, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height);

        return new SoccerGoal(new Point(x, y));
    }
    protected override void Initialize()
    {
        player = new Player();
        targets = new List<GameObject>() {
            SpawnGoal(),
            SpawnGoal(),
            SpawnGoal()
        };
        gameObjects = new List<GameObject>() {
            player,
        };
        gameObjects.AddRange(targets);

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        foreach (GameObject gameObject in gameObjects)
        {
            gameObject.ObjectTexture = Content.Load<Texture2D>(gameObject.ObjectTextureName);
        }
    }

    protected override void Update(GameTime gameTime)
    {
        KeyboardState keyboardState = Keyboard.GetState();

        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || keyboardState.IsKeyDown(Keys.Escape))
            Exit();


        foreach (GameObject gameObject in gameObjects)
        {
            foreach (GameObject potentialCollision in gameObjects)
            {
                if (gameObject != potentialCollision)
                {
                    if (gameObject.ObjectBoundingBox.Left < potentialCollision.ObjectBoundingBox.Right &&
                    gameObject.ObjectBoundingBox.Right > potentialCollision.ObjectBoundingBox.Left &&
                    gameObject.ObjectBoundingBox.Top < potentialCollision.ObjectBoundingBox.Bottom &&
                    gameObject.ObjectBoundingBox.Bottom > potentialCollision.ObjectBoundingBox.Top)
                    {
                        gameObject.OnCollision(potentialCollision);
                    }
                }
            }
            gameObject.Update(gameTime, keyboardState);
        }
        gameObjects = gameObjects.Where(gameObject => !gameObject.Destroy).ToList();
        targets = targets.Where(gameObject => !gameObject.Destroy).ToList();
        while (targets.Count < 3)
        {
            SoccerGoal newSoccerGoal = SpawnGoal();
            newSoccerGoal.ObjectTexture = Content.Load<Texture2D>(newSoccerGoal.ObjectTextureName);
            targets.Add(newSoccerGoal);
            gameObjects.Add(newSoccerGoal);
        }
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();
        foreach (GameObject gameObject in gameObjects)
        {
            gameObject.Draw(gameTime, _spriteBatch);
        }
        _spriteBatch.End();
        base.Draw(gameTime);
    }
}
