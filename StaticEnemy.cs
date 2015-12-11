using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace fourcolors
{
    class StaticEnemy : EnemyGadget
    {
        public StaticEnemy(ObjectGroup.MapObject enemyobject) : base(enemyobject)
        {
            animatedtype = "smallexplosion";
            ///No move speed for static enemies
            movespeed = 1.0f;//Movespeed is used to set velocity X
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
            //Stic Enmeies must scroll with the tiles
            ///Static enemies move speed does not get incremented here
            /// because the are SATIC
            if (!dead)
            {
                velocity.X = -movespeed;
                if (image.Position.X < -70)
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
