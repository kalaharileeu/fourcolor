using System.Collections.Generic;


using Microsoft.Xna.Framework;

namespace fourcolors
{
    /// <summary>
    /// The Collisionmanager checks for collision between bullets/enemies and player.
    /// The player must register its position. the player can possibly register its
    /// position out of reach if it want to be immortal
    /// </summary>
    public class CollisionManager
    {
        //Plyer objects registers it position here for collision
        Rectangle playerposition;
        bool playercollision = false;

        private static CollisionManager instance;

        public static CollisionManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new CollisionManager();
                return instance;
            }
        }

        public bool PlayerCollision
        {
            get { return playercollision; }
        }

        public Rectangle Playerposition
        {
            get { return playerposition; }
            set { playerposition = value; }
        }

        public void checkEnemyPlayerBulletCollision(List<EnemyGadget> elist)
        {
            //set the collision to false here
            playercollision = false;
            foreach (EnemyGadget eg in elist)
            {
                if (!(eg is ScrollingBackground))
                {
                    foreach (PlayerBullet pb in BulletHandler.Instance.Listplayerbullets)
                    {
                        if(Collision.RectRect(pb.GetCurrentRect(), eg.GetCurrentRect()))
                        {
                            eg.Dead();
                            pb.Dead();
                            ScoreManager.Instance.Scoreincrement();
                        }
                        //Rectangle.Intersect(recct, rect)
                    }
                    //check for player enemy collision
                    if (Collision.RectRect(playerposition, eg.GetCurrentRect()))
                    {
                        eg.Dead();
                        playercollision = true;
                        ScoreManager.Instance.Scoredecrement();
                    }
                }
            }
        }
    }
}
