﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace fourcolors
{
    /// <summary>
    /// The bullet handler handles bullets and explosions(animatedgraphics)
    /// </summary>
    class BulletHandler
    {
        Loader.parameter animatedgraphicsparam;
        Loader.parameter playerbulletparam;
        Loader.parameter enemybulletparam;
        static List<PlayerBullet> listplayerbullets;
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

        public void addAnimatedGraphics(int x, int y)
        {
            listanimatedgraphics.Add(new AnimatedGraphics(animatedgraphicsparam, x, y));
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
