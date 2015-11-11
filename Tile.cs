using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace fourcolors
{
    public class Tile
    {
        Vector2 position;
        Rectangle sourceRect;
        string state;
        Vector2 deathtile2d;

        public Rectangle SourceRect
        {
            get { return sourceRect; }
        }

        public Vector2 Position
        {
            get { return position; }
        }

        public void LoadContent(Vector2 position, Rectangle sourceRect, string state)
        {
            deathtile2d = new Vector2(0, 0);
            
            this.position = position;
            this.sourceRect = sourceRect;
            this.state = state;
        }

        public void UnloadContent()
        { 
        }

        public void scroll(int x)
        {
            position.X -= GameplayScreen.scrollspeed;
        }

        public void Update(GameTime gameTime, Player player)
        {
            deathtile2d.X = 0;
            deathtile2d.Y = 0;
            if(state == "Solid")//Below is the collision handling
            {
                Rectangle tileRect = new Rectangle((int)Position.X, (int)Position.Y,
                    sourceRect.Width, sourceRect.Height);

                if(Collision.RectRect(tileRect, player.GetCurrentRect()))
                {
                    player.DyinginTiles = true;
                    //deathtile2d.X = playerrect.X;
                    //deathtile2d.Y = playerrect.Y;
                }
            }
            //return the point of collisionplayer vs tile
        }

        public void Draw(SpriteBatch spriteBatch)
        { 
 

        }
    }

}
