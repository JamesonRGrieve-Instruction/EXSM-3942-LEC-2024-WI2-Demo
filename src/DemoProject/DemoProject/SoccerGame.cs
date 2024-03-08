using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DemoProject;

public class SoccerGame : Game
{
    List<GameObject> gameObjects;
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    Player player;
    float fireTimer;
    float lastFire;
    static Random rng = new Random();
    public SoccerGame()
    {
        _graphics = new GraphicsDeviceManager(this);
        _graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
        _graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }
    protected SoccerGoal SpawnGoal()
    {
        int x = rng.Next(100, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width - 100);
        int y = rng.Next(100, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height - 100);

        return new SoccerGoal(new Point(x, y));
    }
    protected override void Initialize()
    {
        player = new Player();
        gameObjects = new List<GameObject>() {
            player,
            SpawnGoal(),
            SpawnGoal(),
            SpawnGoal()
        };
        fireTimer = 1f;
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
        if (keyboardState.IsKeyDown(Keys.Space) && gameTime.TotalGameTime.TotalSeconds - lastFire > fireTimer)
        {
            lastFire = (float)gameTime.TotalGameTime.TotalSeconds;
            Projectile newProjectile = new Projectile(new Point(player.ObjectBoundingBox.Center.X, player.ObjectBoundingBox.Center.Y), player.movement);
            newProjectile.ObjectTexture = Content.Load<Texture2D>(newProjectile.ObjectTextureName);
            gameObjects.Add(newProjectile);

        }
        gameObjects = gameObjects.Where(gameObject => !gameObject.Destroy).ToList();
        while (gameObjects.Count(gameObject => gameObject.GetType() == typeof(SoccerGoal)) < 3)
        {
            SoccerGoal newSoccerGoal = SpawnGoal();
            newSoccerGoal.ObjectTexture = Content.Load<Texture2D>(newSoccerGoal.ObjectTextureName);
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
