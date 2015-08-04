using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace fourcolors
{
    class BulletHandler
    {
        Loader.parameter playerbulletparam;
        Loader.parameter enemybulletparam;
        static List<PlayerBullet> listplayerbullets;
        List<EnemyBullet> listenemybullets;
        int i;

        public Loader.parameter Playerbulletparam
        {
            set
            {
                playerbulletparam = value;
            }
        }

        private static BulletHandler instance;

        public static BulletHandler Instance
        {
            get
            {
                if (instance == null)
                    instance = new BulletHandler();
                return instance;
            }
        }

        public BulletHandler()
        {
            listplayerbullets = new List<PlayerBullet>();
            listenemybullets = new List<EnemyBullet>();
        }

        public static List<PlayerBullet> Listplayerbullets
        {
            get { return listplayerbullets; }
        }

        public void addEnemyBullet(int x, int y)
        {
            listenemybullets.Add(new EnemyBullet(enemybulletparam, x, y));
        }

        public void addPlayerBullet(int x, int y)
        {
            if (listplayerbullets.Count > 4)
                    i++;
            listplayerbullets.Add(new PlayerBullet(playerbulletparam, x, y));
        }

        public void addPlayerBullet(PlayerBullet pb)
        {
            listplayerbullets.Add(pb);
        }

       public void clearbullet()
        {

        }

        public void update(GameTime gametime)
        {
            listplayerbullets.RemoveAll(PlayerBullet => PlayerBullet.Dead == true);
            listenemybullets.RemoveAll(EnemyBullet => EnemyBullet.Dead == true);

            foreach (PlayerBullet pb in listplayerbullets)
                pb.Update(gametime);

            foreach (EnemyBullet eb in listenemybullets)
                eb.Update(gametime);
        }

        public void draw(SpriteBatch spriteBatch)
        {
            foreach(PlayerBullet pb in listplayerbullets)
            {
                pb.Draw(spriteBatch);
            }

            foreach(EnemyBullet eb in listenemybullets)
            {
                eb.Draw(spriteBatch);
            }
        }


    }
}
