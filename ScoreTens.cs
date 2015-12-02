using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace fourcolors
{
    class ScoreTens : StationaryGameGadget
    {
        public ScoreTens(ObjectGroup.MapObject enemyobject) : base(enemyobject)
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
            // it is score out of 100 if you mod 10 will give me one's
            //scorevalues come from StationaryGameObject
            image.Draw(spriteBatch, (scorevalue % 100) / 10, 0);
        }
    }
}
