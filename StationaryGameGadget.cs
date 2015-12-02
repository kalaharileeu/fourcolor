using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace fourcolors
{
    class StationaryGameGadget : GameGadgets
    {
        protected int scorevalue { get; set; }

        public StationaryGameGadget(ObjectGroup.MapObject enemyobject) : base(enemyobject)
        {
            scorevalue = 0;
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
            scorevalue = ScoreManager.Instance.Score;
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
