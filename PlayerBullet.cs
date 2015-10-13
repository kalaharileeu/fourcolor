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

        public override void LoadContent()
        {
            base.LoadContent();
            image.Position.X = playerx;
            image.Position.Y = playery;
            image.height = 11;
            image.width = 11;
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            image.Position.X += movespeed;
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        public void Dead()
        {
            dying = true;
            deathvector.X = (int)image.Position.X;
            deathvector.Y = (int)image.Position.Y;
            dead = true;
        }

        public bool IsDead
        {
            get {return dead;}
        }

        public string AnimatedType
        {
            get { return animatedtype; }
        }
    }
}
