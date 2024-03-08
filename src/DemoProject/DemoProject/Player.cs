using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
public class Player : GameObject
{
    float ballSpeed;
    public Vector2 movement;
    public Player() : base("SoccerBall", new Point(
        (GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2) - 50,
        (GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 2) - 50
    ), new Point(100, 100))
    {
        ballSpeed = 200f;
    }
    public override void Update(GameTime gameTime, KeyboardState keyboardState)
    {
        movement = new Vector2(0, 0);
        if (keyboardState.IsKeyDown(Keys.Up))
        {
            movement.Y -= 1;
        }
        if (keyboardState.IsKeyDown(Keys.Down))
        {
            movement.Y += 1;
        }
        if (keyboardState.IsKeyDown(Keys.Left))
        {
            movement.X -= 1;
        }
        if (keyboardState.IsKeyDown(Keys.Right))
        {
            movement.X += 1;
        }
        ObjectBoundingBox.Y += (int)(movement.Y * ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds);
        ObjectBoundingBox.X += (int)(movement.X * ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds);
    }
    public override void Draw(GameTime gameTime, SpriteBatch _spriteBatch)
    {
        _spriteBatch.Draw(ObjectTexture, ObjectBoundingBox, Color.White);
    }

    public override void OnCollision(GameObject with)
    {
        if (with.GetType() == typeof(SoccerGoal))
        {
            with.Destroy = true;
        }
    }
}