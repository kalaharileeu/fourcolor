using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace fourcolors
{
    class CollisionManager
    {
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

        public void checkenemyplayerbulletcollision(List<EnemyGadget> elist)
        {
            foreach (EnemyGadget e in elist)
            {
                foreach (PlayerBullet pb in BulletHandler.Listplayerbullets)
                {
                    if (Collision.RectRect(e.GetCurrentRect(), pb.GetCurrentRect()))
                    {
                        e.Dead(e.GetCurrentRect());
                    }
                }
            }
        }

        public void checkenemyplayerbulletcollision(EnemyGadget enemygadget)
        {
            foreach (PlayerBullet pb in BulletHandler.Listplayerbullets)
            {
                if (Collision.RectRect(enemygadget.GetCurrentRect(), pb.GetCurrentRect()))
                {
                    enemygadget.Dead(enemygadget.GetCurrentRect());
                }
            }
        }
    }
}
