using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DemoProject;

public class Game1 : Game
{
    List<GameObject> gameObjects;
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    Player player;
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        player = new Player();
        gameObjects = new List<GameObject>() {
            player,
            new SoccerGoal(new Point(100, 300)),
            new SoccerGoal(new Point(400, 250)),
            new SoccerGoal(new Point(330, 100)),
        };

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
