using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace fourcolors
{
    class EnemyBullet : PlayerGadget
    {
        int enemyx;
        int enemyy;
        Vector2 velocity;

        public EnemyBullet(Loader.parameter loaderparameters, int x, int y)
        {
            //image = loaderparameters.image;
            movespeed = loaderparameters.movespeed;
            animatedtype = loaderparameters.animatedtype;
            numframesX = loaderparameters.numframesX;
            numframesY = loaderparameters.numframesY;
            dead = loaderparameters.dead;
            dying = loaderparameters.dying;
            enemyx = x;
            enemyy = y;
            //image = new Image();
            LoadContent();
            //numFrames = 1;
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
            image.Position.X += 2;
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }



        public bool IsDead
        {
            get { return dead; }
        }
    }
}
