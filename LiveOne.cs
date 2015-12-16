using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace fourcolors
{
    class LiveOne : StationaryGameGadget
    {
        public LiveOne(ObjectGroup.MapObject enemyobject) : base(enemyobject)
        {

        }

        public override void LoadContent()
        {
            base.LoadContent();
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            /// it is score out of 100 if you mod 10 will give me one's
            ///scorevalues come from StationaryGameObject
            ///give image.Draw the sprite strip coordonites
            if (lives > 0)
                image.Draw(spriteBatch, 0, 0);
            else
                image.Draw(spriteBatch, 1, 0);
        }
    }
}