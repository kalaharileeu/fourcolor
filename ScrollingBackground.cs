using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fourcolors
{
    class ScrollingBackground : EnemyGadget
    {
        public ScrollingBackground(ObjectGroup.MapObject enemyobject) : base(enemyobject)
        {
            animatedtype = null;
            movespeed = 1.0f;
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void LoadContent()
        {
            base.LoadContent();
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            /**<comment>The move speed of the scrollingbackground
            is negative to reverse</comment>*/
            velocity.X = -GameplayScreen.scrollspeed;
            //Chech when to rest the background
            if(image.Position.X < -640)
            { 
                image.Position.X = 640;
            }
            base.Update(gameTime);
        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
