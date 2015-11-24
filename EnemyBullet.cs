using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace fourcolors
{
    class EnemyBullet : EnemyWeapons
    {
        int enemyx;
        int enemyy;

        public EnemyBullet(Loader.parameter loaderparameters, int x, int y)
        {
            //imagesource = loaderparameters.imagesource;
            movespeed = loaderparameters.movespeed;
            animatedtype = loaderparameters.animatedtype;
            numframesX = loaderparameters.numframesX;
            numframesY = loaderparameters.numframesY;
            dead = loaderparameters.dead;
            dying = loaderparameters.dying;
            enemyx = x;
            enemyy = y;
            //get the image source directly from loaderparameters
            image = new Image(loaderparameters.imagesource);

            LoadContent();
        }

        public override void LoadContent()
        {
            base.LoadContent();
            image.Position.X = enemyx;
            image.Position.Y = enemyy;
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            image.Position.X -= movespeed;
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
