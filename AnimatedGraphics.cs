using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace fourcolors
{
    //AnimatedGraphics is where explosions and effects are created
    class AnimatedGraphics : PlayerGadget
    {
        int animationx;
        int animationy;
        Vector2 velocity;
        int animatedlife;

        public AnimatedGraphics(Loader.parameter loaderparameters, int x, int y )
        {
            movespeed = loaderparameters.movespeed;
            animatedtype = loaderparameters.animatedtype;
            numframesX = loaderparameters.numframesX;
            numframesY = loaderparameters.numframesY;
            animationx = x;
            animationy = y;
            Effect = loaderparameters.Effects;
            animatedlife = loaderparameters.life;
            //get the image source directly from loaderparameters
            image = new Image(loaderparameters.imagesource);
            //image.Set(loaderparameters.Effects);
            image.Effects = Effect;
            image.Position.X = animationx;
            image.Position.Y = animationy;
            image.amountofframes.X = numframesX;
            image.amountofframes.Y = numframesY;
            //image.width = 
            LoadContent();
        }

        public override void LoadContent()
        {
            base.LoadContent();
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            //image.Update(gameTime);
            animatedlife -= 1;
            image.IsActive = true;
            image.Position.Y += movespeed;
            if (animatedlife == 0)
                dead = true;
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
