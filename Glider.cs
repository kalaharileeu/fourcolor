using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace fourcolors
{
    class Glider : MobileEnemy
    {
        Random rnd;
        int randnumber13;
        float accumulate = 0;

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
            //BulletHandler.Instance.addEnemyBullet((int)(image.Position.X + image.width),
            //    (int)(image.Position.Y + (image.height / 2)));
            //position smaller than 530, start vibrating

            
            if (image.Position.X < 630)
            {
                randnumber13 = rnd.Next(-4, 4);
                velocity.Y = -randnumber13;

                accumulate += (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (accumulate % 4 > 2.8)
                {
                    BulletHandler.Instance.addEnemyBullet((int)image.Position.X, (int)image.Position.Y);
                    accumulate = 0;
                }

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
