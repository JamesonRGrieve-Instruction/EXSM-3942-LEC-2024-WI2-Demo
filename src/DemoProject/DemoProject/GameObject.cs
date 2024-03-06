using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public abstract class GameObject
{
    public abstract void Update(GameTime gameTime, KeyboardState keyboardState);

    public abstract void Draw(GameTime gameTime, SpriteBatch _spriteBatch);
}