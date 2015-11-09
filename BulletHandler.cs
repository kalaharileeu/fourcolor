using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace fourcolors
{
    /// <summary>
    /// The bullet handler handles bullets and explosions(animatedgraphics)
    /// The player updates its position in the bullet handler for collision
    /// detection. The collsion manager get it here.
    /// The list of animated graphics are explosions or other graphics.
    /// </summary>
    class BulletHandler
    {
        Loader.parameter animatedgraphicsparam;//large explotion
        Loader.parameter playerbulletparam;
        //Loader.parameter smallexplotion;
        //From xml serialization ready for animated bullets and explosions
        //Types: playerbullet, smallexplosion, largeexplosion
        List<Loader.parameter> listofparameters; //From xml serialization ready for 
        //Loader.parameter enemybulletparam;//TODO implemment
        List<PlayerBullet> listplayerbullets;
        List<EnemyBullet> listenemybullets;
        List<AnimatedGraphics> listanimatedgraphics;
        int i;

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
            listanimatedgraphics = new List<AnimatedGraphics>();
            listofparameters = new List<Loader.parameter>();
        }

        public List<PlayerBullet> Listplayerbullets
        {
            get { return listplayerbullets; }
        }

        //public void addEnemyBullet(int x, int y)
        //{
        //    listenemybullets.Add(new EnemyBullet(enemybulletparam, x, y));
        //}

        //Populate a list of parameters to instantiate bullets and explosion
        public void Addloaderparameter(Loader.parameter v)
        {
            listofparameters.Add(v);
        }

        public void addAnimatedGraphics(int x, int y, string name)
        {
            Loader.parameter lp = new Loader.parameter();
            lp = listofparameters.Find(z => z.animatedtype == name);
            listanimatedgraphics.Add(new AnimatedGraphics(lp, x, y));
        }

        public void addPlayerBullet(int x, int y)
        {
            if (listplayerbullets.Count > 4)
                    i++;
            listplayerbullets.Add(new PlayerBullet(playerbulletparam, x, y));
        }
        //Add in real time a animated graphic to the list(a explosion or something)
        //it will be animated and showed 
        public void addAnimatedGraphics(int x, int y)
        {
            listanimatedgraphics.Add(new AnimatedGraphics(animatedgraphicsparam, x, y));
        }

        public void addPlayerBullet(PlayerBullet pb)
        {
            listplayerbullets.Add(pb);
        }

       //public void clearbullet()
       // {

       // }

        public void update(GameTime gametime)
        {
            //remove all the dead bullets
            listplayerbullets.RemoveAll(PlayerBullet => PlayerBullet.IsDead == true);
            listenemybullets.RemoveAll(EnemyBullet => EnemyBullet.IsDead == true);
            listanimatedgraphics.RemoveAll(AnimatedGraphics => AnimatedGraphics.IsDead == true);

            foreach (PlayerBullet pb in listplayerbullets)
                pb.Update(gametime);

            foreach (EnemyBullet eb in listenemybullets)
                eb.Update(gametime);

            foreach (AnimatedGraphics ag in listanimatedgraphics)
                ag.Update(gametime);
        }

        public void draw(SpriteBatch spriteBatch)
        {
            foreach(PlayerBullet pb in listplayerbullets)
                pb.Draw(spriteBatch);

            foreach(EnemyBullet eb in listenemybullets)
                eb.Draw(spriteBatch);

            foreach (AnimatedGraphics ag in listanimatedgraphics)
                ag.Draw(spriteBatch);
        }

        public Loader.parameter Playerbulletparam
        {
            set{ playerbulletparam = value; }
        }

        public Loader.parameter Animatedgraphicsparam
        {
            set{ animatedgraphicsparam = value; }
        }
    }
}
