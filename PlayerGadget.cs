using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
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
            if (image.Position.X > 600)
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
