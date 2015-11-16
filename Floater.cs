using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace fourcolors
{
    class Floater : StaticEnemy
    {
        //floater does not move far on the X plane, so static
        public Floater(ObjectGroup.MapObject enemyobject) : base(enemyobject)
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
            //velocity.Y = -randnumber13;
            if (image.Position.X < -10)
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
