/**
 <comment>values from player xml file
 <image source="Gameplay/heli" width = "96" height = "41">
    <Effects>SpriteSheetEffect</Effects>
  </image>
  <MoveSpeed>100</MoveSpeed>
  </comment>
 */
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace fourcolors
{
    public class Player
    {
        Image image;
        float movespeed;
        string animatedtype;
        bool dyingtiles = false;//crashed?
        bool dead = false;//dead or alive
        bool immortal = false;//After death immortal for a while
        const float immortaltime = 1.0f;
        float accumulatedtime = 0;
        Vector2 deathvector;
        Vector2 Velocity;

        public Player(Loader.parameter loaderparameters)
        {
            Velocity = Vector2.Zero;
            image = loaderparameters.image;
            movespeed = loaderparameters.movespeed;
            animatedtype = loaderparameters.animatedtype;
            deathvector = Vector2.Zero;
        }

        public bool isDead
        { 
            get { return dead; }
            set { dead = value; }
        }
        /// <summary>
        ///Bool value. Collided with tiles
        /// </summary>
        public bool DyinginTiles
        {
            get { return dyingtiles; }
            set { dyingtiles = value;  }
        }

        public Rectangle GetCurrentRect()
        {
            Rectangle collisionRect = new Rectangle((int)image.Position.X, (int)image.Position.Y, image.width, image.height);
            return collisionRect;
        }
        /// <summary>
        /// Get set the vector wher player died
        /// </summary>
        public Vector2 Deathvector
        {
            get { return deathvector; }
            set { deathvector = value;  }
        }

        public void setDeathvector(float x, float y)
        {
            deathvector.X = x;
            deathvector.Y = y;
        }

        //Load the start position of the player and content
        public void LoadContent()
        {
            image.LoadContent();
            image.Position.Y = 80;
        }

        public void UnloadContent()
        {
            image.UnloadContent();
        }

        public void Update(GameTime gameTime)
        {
            ///if immortal count elased tipe up to 3 seconds no collsion detection 
            /// else check for collision, if collide the set to immortal
            if (immortal)
            {
                isDead = false;
                accumulatedtime += (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (accumulatedtime > immortaltime)
                {
                    BulletHandler.Instance.addAnimatedGraphics((int)image.Position.X - 30, (int)image.Position.Y, "smallexplosion");//Explosion
                    accumulatedtime = 0;
                    immortal = false;//set immortal to false after immortla time done
                }
            }
            else
            {
                //Death handling If true, I collided
                if ((CollisionManager.Instance.PlayerCollision) || (dyingtiles))
                {
                    ///If collision set is dead to true
                    /// move the player back to X = -30 Y = 100 on the X axis
                    /// TODO: set imortality for a while with new image(create new sprite)
                    BulletHandler.Instance.addAnimatedGraphics((int)image.Position.X, (int)image.Position.Y);
                    SoundManager.Instance.Playexplode();//Play sound
                    BulletHandler.Instance.addAnimatedGraphics((int)image.Position.X - 30, (int)image.Position.Y, "smallexplosion");//Explosion
                    isDead = true;
                    dyingtiles = false;
                    image.Position.X = -30;//Reseet the player off screen to start again
                    image.Position.Y = 100;
                    immortal = true;//The plyaer needs to be immortal for a while
                }
            }

            if (!isDead)
            {
                image.IsActive = true;
                if (Velocity.X == 0)//If you do not want to do diagonal movement
                {
                    if (InputManager.Instance.KeyDown(Keys.Down))
                    {
                        Velocity.Y = movespeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                        image.SpriteSheetEffect.CurrentFrame.Y = 0;//Y coordinate for down is 0, left Y = 1, right Y= 2, up y = 3
                    }
                    else if (InputManager.Instance.KeyDown(Keys.Up))
                    {
                        Velocity.Y = -movespeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                        image.SpriteSheetEffect.CurrentFrame.Y = 0;//Y coordinate for down is 0, left Y = 1, right Y= 2, up y = 3
                    }
                    else
                    {
                        Velocity.Y = 0;
                        image.SpriteSheetEffect.CurrentFrame.Y = 0;
                    }
                }

                if (Velocity.Y == 0)//No diagonal movement
                {
                    if (InputManager.Instance.KeyDown(Keys.Right))
                    {
                        Velocity.X = movespeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                        image.SpriteSheetEffect.CurrentFrame.Y = 0;//Y coordinate for down is 0, left Y = 1, right Y= 2, up y = 3
                    }
                    else if (InputManager.Instance.KeyDown(Keys.Left))
                    {
                        Velocity.X = -movespeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                        image.SpriteSheetEffect.CurrentFrame.Y = 0;//Y coordinate for down is 0, left Y = 1, right Y= 2, up y = 3
                    }
                    else
                    {
                        Velocity.X = 0;
                        image.SpriteSheetEffect.CurrentFrame.Y = 0;
                    }
                }
                //Space fires bullets
                if (InputManager.Instance.KeyPressed(Keys.Space))
                {
                    //image height and width is given by texture.heigt and texture.width
                    BulletHandler.Instance.addPlayerBullet((int)(image.Position.X + image.width),
                        (int)(image.Position.Y + (image.height / 2)));
                    SoundManager.Instance.PlayPhaser();
                }
                //After death dies it reset of screen and needs to com to for front
                if(image.Position.X < 5)
                {
                    image.Position.X += 3;
                }
                ///<remark>if player not moving this stop animation</remark>
                //if (Velocity.X == 0 && Velocity.Y == 0)//if the player is not moving
                //    image.IsActive = false;
            }
                //BulletHandler.Instance.update(gameTime);//Move to map
            image.Update(gameTime);
            image.Position += Velocity;
            //Register player position for collision handling
            CollisionManager.Instance.Playerposition = new Rectangle((int)image.Position.X, 
                (int)image.Position.Y, image.width, image.height);
        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            BulletHandler.Instance.draw(spriteBatch);
            image.Draw(spriteBatch);
        }
    }
}
