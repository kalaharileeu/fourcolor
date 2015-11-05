using System;
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
            //position smaller than 530, start vibrating
            if(image.Position.X < 530)
            {
                randnumber13 = rnd.Next(-4, 4);
                velocity.Y = -randnumber13;
                if (image.Position.X < 0)
                {
                    Dead();
                }
            }
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
