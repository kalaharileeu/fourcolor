using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace fourcolors
{
    class EnemyWeapons : GameObject
    {
        public EnemyWeapons()
        {
        }

        public override void LoadContent()
        {
            image.LoadContent();
        }

        public override void UnloadContent()
        {
            image.UnloadContent();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            image.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            if ((image.Position.X < 10)||(image.Position.Y < 20))
            {
                dead = true;
            }
            image.Update(gameTime);
        }

        public override Rectangle GetCurrentRect()
        {
            return new Rectangle((int)image.Position.X, (int)image.Position.Y, image.width, image.height);
        }

        public bool IsDead
        {
            get { return dead; }
        }
    }
}
