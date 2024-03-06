using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public abstract class GameObject
{
    public bool Destroy;
    public Rectangle ObjectBoundingBox;
    public Texture2D ObjectTexture;
    public string ObjectTextureName;
    public GameObject(string textureName, Point initialPosition, Point size)
    {
        ObjectBoundingBox = new Rectangle(initialPosition, size);
        ObjectTextureName = textureName;
        Destroy = false;
    }

    public abstract void Update(GameTime gameTime, KeyboardState keyboardState);

    public abstract void Draw(GameTime gameTime, SpriteBatch _spriteBatch);

    public virtual void OnCollision(GameObject with)
    { }
}