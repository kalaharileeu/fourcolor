using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace fourcolors
{
    class Glider : MobileEnemy
    {
        Random rnd;
        int randnumber13;

        public Glider(ObjectGroup.MapObject enemyobject) : base(enemyobject)
        {
            rnd = new Random();
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

            //randnumber13 = rnd.Next(-2, 2);
            //velocity.X = -randnumber13;
            randnumber13 = rnd.Next(-2, 2);
            velocity.Y = -randnumber13;
            if (image.Position.X > 600 || image.Position.X < 10)
            {
                dead = true;
            }
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
/*
    class GliderCreator : BaseCreator
    {
        public override EnemyGadget createGameObject()
        {
            //return new Glider(ObjectGroup.MapObject enemyobject);
        }
    }
 */
}
