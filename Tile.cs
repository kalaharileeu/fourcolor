using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace fourcolors
{
    public class Tile
    {
        Vector2 position;
        Rectangle sourceRect;
        string state;

        public Rectangle SourceRect
        {
            get { return sourceRect; }
        }

        public Vector2 Position
        {
            get { return position; }
        }

        public void scroll(int x)
        {
            position.X -= GameplayScreen.scrollspeed;
        }

        public void LoadContent(Vector2 position, Rectangle sourceRect, string state)
        {
            this.position = position;
            this.sourceRect = sourceRect;
            this.state = state;
        }

        public void UnloadContent()
        { 
        }
        
        public void Update(GameTime gameTime, Rectangle playerrect, Rectangle playerdv)
        {

            if(state == "Solid")//Below is the collision handling
            {
                Rectangle tileRect = new Rectangle((int)Position.X, (int)Position.Y,
                    sourceRect.Width, sourceRect.Height);

                if(Collision.RectRect(tileRect, playerrect))
                {
                    playerdv.X = playerrect.X;
                    playerdv.Y = playerrect.Y;
                }


            }
        }

        public void Draw(SpriteBatch spriteBatch)
        { 
 

        }
    }

}
