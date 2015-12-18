using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace fourcolors
{
    class GreenBullet : EnemyBullet
    {
        public GreenBullet(Loader.parameter loaderparameter, int x, int y)
            : base(loaderparameter, x, y)
        {
        }

        public override void LoadContent()
        {
            base.LoadContent();
            image.height = 16;
            image.width = 16;
        }

        public override void UnloadContent()
        {
            base.UnloadContent();

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            image.Position.X -= movespeed;
            base.Update(gameTime);
        }
    }
}
