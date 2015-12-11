using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace fourcolors
{
    class Intruder : MobileEnemy
    {
        public Intruder(ObjectGroup.MapObject enemyobject) : base(enemyobject)
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
            //if position larger than 640 only scroll speed
            if (image.Position.X < 640)
            {
                if (image.Position.X < 530)
                {
                    //Xaxis movespeed increases
                    movespeed += 2;
                }
            }
            else
                movespeed = 1.0f;//this is the same as the scroll speed

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
