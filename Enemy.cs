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
            if (!dead)
            {
                ///This is just to keep up with scroll speed,
                ///Will look static
                velocity.X = -movespeed;
            }
            if (image.Position.X < -20)
            {
                Dead();
            }
            //move speed is the constant movespeed for all enemies 2.0f
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
