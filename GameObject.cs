using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace fourcolors
{
    /// <summary>
    /// Base to EnemyGadget && PlayerGadget
    /// </summary>
    abstract public class GameObject
    {
        protected float movespeed;
        protected string animatedtype;
        protected int numframesX;
        protected int numframesY;
        protected bool dead;
        protected bool dying;
        protected int hits;
        protected int strength;
        protected Vector2 deathvector;
        protected Image image;
        protected string Effect;//this is a image effect

        abstract public void LoadContent();
        abstract public void UnloadContent();
        abstract public void Update(GameTime gameTime);
        abstract public void Draw(SpriteBatch spriteBatch);
        abstract public Rectangle GetCurrentRect();
    }
}