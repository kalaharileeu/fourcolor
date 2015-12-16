using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace fourcolors
{
    /// <summary>
    /// The stationary game gadget keepst track of the lives and score
    /// </summary>
    class StationaryGameGadget : GameGadgets
    {
        protected int scorevalue { get; set; }
        protected int lives { get; set; }

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
            lives = ScoreManager.Instance.Lives;
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
