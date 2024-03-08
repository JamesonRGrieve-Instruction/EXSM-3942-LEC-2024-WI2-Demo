using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
public class Player : GameObject
{
    float ballSpeed;

    public Player() : base("SoccerBall", new Point(
        (GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2) - 50,
        (GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 2) - 50
    ), new Point(100, 100))
    {
        ballSpeed = 200f;
    }
    public override void Update(GameTime gameTime, KeyboardState keyboardState)
    {
        if (keyboardState.IsKeyDown(Keys.Up))
        {
            ObjectBoundingBox.Y -= (int)(ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds);
        }
        if (keyboardState.IsKeyDown(Keys.Down))
        {
            ObjectBoundingBox.Y += (int)(ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds);
        }
        if (keyboardState.IsKeyDown(Keys.Left))
        {
            ObjectBoundingBox.X -= (int)(ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds);
        }
        if (keyboardState.IsKeyDown(Keys.Right))
        {
            ObjectBoundingBox.X += (int)(ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds);
        }
    }
    public override void Draw(GameTime gameTime, SpriteBatch _spriteBatch)
    {
        _spriteBatch.Draw(ObjectTexture, ObjectBoundingBox, Color.White);
    }

    public override void OnCollision(GameObject with)
    {
        with.Destroy = true;
    }
}