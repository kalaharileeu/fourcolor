using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace fourcolors
{
    class PlayerBullet : PlayerGadget
    {
        int playerx;
        int playery;
        Vector2 velocity;

        public PlayerBullet(Loader.parameter loaderparameters, int x, int y)
        {
            //imagesource = loaderparameters.imagesource;
            movespeed = loaderparameters.movespeed;
            animatedtype = loaderparameters.animatedtype;
            numframesX = loaderparameters.numframesX;
            numframesY = loaderparameters.numframesY;
            dead = loaderparameters.dead;
            dying = loaderparameters.dying;
            playerx = x;
            playery = y;
            //get the image source directly from loaderparameters
            image = new Image(loaderparameters.imagesource);
            LoadContent();
        }

        public bool Dead
        {
            get { return dead; }
        }

        public override void LoadContent()
        {
            base.LoadContent();
            image.Position.X = playerx;
            image.Position.Y = playery;
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            image.Position.X += 3;
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
