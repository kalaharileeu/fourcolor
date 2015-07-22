using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace fourcolors
{
    class MobileEnemy : EnemyGadget
    {
        public MobileEnemy(ObjectGroup.MapObject enemyobject) : base(enemyobject)
        {
            animatedtype = "smallexplosion";
            movespeed = 2.0f;
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void LoadContent()
        {
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            //move speed is the constant movespeed for all enemies 2.0f
            if(!dead)
            {
                velocity.X = -movespeed;
            }
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
