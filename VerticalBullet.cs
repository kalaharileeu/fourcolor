using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace fourcolors
{
    class VerticalBullet : EnemyBullet
    {
        public VerticalBullet(Loader.parameter loaderparameter, int x, int y) 
            : base(loaderparameter, x, y)
        {
        }

        public override void LoadContent()
        {
            base.LoadContent();
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
            image.height = 16;
            image.width = 16;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            image.Position.Y -= (movespeed * 2 );
            base.Update(gameTime);
        }
    }
}
