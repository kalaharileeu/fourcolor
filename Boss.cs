using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace fourcolors
{
    class Boss : StaticEnemy
    {
        int x = 0;
        int y = 0;
        float accumulate = 0;
        //Boss does not move far on the X plane so pretty static
        public Boss(ObjectGroup.MapObject enemyobject) : base(enemyobject)
        {
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
            if (image.Position.X < 630)
            {
                accumulate += (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (accumulate % 4 > 2)//Shoot every 2 seconds
                {
                    BulletHandler.Instance.addEnemyBullet((int)image.Position.X,
                        (int)image.Position.Y, "GreenBullet");
                    BulletHandler.Instance.addEnemyBullet((int)image.Position.X,
                        (int)image.Position.Y + image.height - 7, "GreenBullet");

                    accumulate = 0;
                }


                if (image.Position.X < 0)
                {
                    Dead();
                }
                //moving algorithm

                if (y < 100)
                {
                    y += 1;
                    velocity.Y = -1;
                }
                else
                {
                    velocity.Y = 1;
                    y += 1;
                }
                velocity.X = 1;
                if (y > 200)
                {
                    y = 0;
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
