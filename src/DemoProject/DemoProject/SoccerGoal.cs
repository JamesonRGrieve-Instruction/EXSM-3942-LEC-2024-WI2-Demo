using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
public class SoccerGoal : GameObject
{

    public SoccerGoal(Point initialPosition) : base("SoccerGoal", initialPosition, new Point(100, 100))
    {
    }
    public override void Update(GameTime gameTime, KeyboardState keyboardState)
    {

    }
    public override void Draw(GameTime gameTime, SpriteBatch _spriteBatch)
    {
        _spriteBatch.Draw(ObjectTexture, ObjectBoundingBox, Color.White);
    }
}