﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace fourcolors
{
    class ScoreOnes : StationaryGameGadget
    {
        public ScoreOnes(ObjectGroup.MapObject enemyobject) : base(enemyobject)
        { }

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
            ///it is score out of 100 if you mod 10 will give me one's
            ///scorevalues inherited StationaryGameObject
            ///tells what the spriabtch strip image coordinates are 
            image.Draw(spriteBatch, scorevalue % 10, 0);
        }
    }
}
