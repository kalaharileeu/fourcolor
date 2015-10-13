using System.Collections.Generic;


using Microsoft.Xna.Framework;

namespace fourcolors
{
    public class CollisionManager
    {
        public void checkEnemyPlayerBulletCollision(List<EnemyGadget> elist)
        {
            foreach (EnemyGadget eg in elist)
            {
                if (!(eg is ScrollingBackground))
                {
                    foreach (PlayerBullet pb in BulletHandler.Listplayerbullets)
                    {
                        if(Collision.RectRect(pb.GetCurrentRect(), eg.GetCurrentRect()))
                        {
                            eg.Dead();
                            pb.Dead();
                        }
                        //Rectangle.Intersect(recct, rect)
                    }
                }
            }
        }
    }
}
