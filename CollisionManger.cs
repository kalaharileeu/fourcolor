using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
                        if (Collision.RectRect(eg.GetCurrentRect(), pb.GetCurrentRect()))
                        {
                            eg.Dead();
                            pb.Dead();
                        }
                    }
                }
            }
        }
    }
}
