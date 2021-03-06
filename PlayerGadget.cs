﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace fourcolors
{
    class PlayerGadget : GameObject
    {
        public PlayerGadget()
        {

        }

        public override void LoadContent()
        {
            image.LoadContent();
        }

        public override void UnloadContent()
        {
            image.UnloadContent();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            image.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            //The player gdget dies if it is larger the 610 position
            //other than enemy gadget/wepon that move in the other direction
            if (image.Position.X > 610)
            {
                dead = true;
            }
            image.Update(gameTime);
        }

        public override Rectangle GetCurrentRect()
        {
            return new Rectangle((int)image.Position.X, (int)image.Position.Y, image.width, image.height);
        }
    }
}
