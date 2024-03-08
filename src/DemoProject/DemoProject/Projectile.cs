using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
public class Projectile : GameObject
{
    Vector2 travel;
    float projectileSpeed;
    public Projectile(Point initialPosition, Vector2 travel) : base("SoccerBall", initialPosition, new Point(25, 25))
    {
        this.travel = travel;
        this.projectileSpeed = 300f;
    }
    public override void Update(GameTime gameTime, KeyboardState keyboardState)
    {
        this.ObjectBoundingBox.X += (int)(travel.X * projectileSpeed * gameTime.ElapsedGameTime.TotalSeconds);
        this.ObjectBoundingBox.Y += (int)(travel.Y * projectileSpeed * gameTime.ElapsedGameTime.TotalSeconds);
    }
    public override void Draw(GameTime gameTime, SpriteBatch _spriteBatch)
    {
        _spriteBatch.Draw(ObjectTexture, ObjectBoundingBox, Color.White);
    }
}