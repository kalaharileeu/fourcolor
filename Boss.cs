using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace fourcolors
{
    class Boss : StaticEnemy
    {
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

            if (image.Position.X < 0)
            {
                Dead();
            }
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
