using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace fourcolors
{
    public class GameplayScreen : GameScreen
    {
        Player player;
        map tilesandenemies;
        Loader.parameter playerparameters;
        Loader.parameter playerbulletparameter;
        Loader.parameter animatedparameter;

        //Loader loadedparams;
        public static int scrollspeed = 1;

        public override void LoadContent()
        {
            base.LoadContent();
            SoundManager.Instance.LoadContent();
            //XmlManager<Loader> paramloader = new XmlManager<Loader>();
            ///The player class variables gets stored in a defferent class
            XmlManager<Loader.parameter> playerloader = new XmlManager<Loader.parameter>();
            //XmlManager<Loader.parameter> playerbulletloader = new XmlManager<Loader.parameter>();
            XmlManager<map> mapLoader = new XmlManager<map>();
            //loadedparams = paramloader.Load("Content/Gameplay/Explosion/parameters.xml");
            //player loader is the xml manager instance
            playerparameters = playerloader.Load("Content/Gameplay/Player.xml");
            playerbulletparameter = playerloader.Load("Content/Gameplay/Playergadgets.xml");//bullet
            animatedparameter = playerloader.Load("Content/Gameplay/Animatedgraphics.xml");
            tilesandenemies = mapLoader.Load("Content/Gameplay/Map/doodlescene.xml");
            //playerbulletparam has set shorthand
            BulletHandler.Instance.Playerbulletparam = playerbulletparameter;
            BulletHandler.Instance.Animatedgraphicsparam = animatedparameter;
           // map1.LoadContent();
            LoadTilesandEnemies();//this is the map

            tilesandenemies.LoadContent();
            player.LoadContent();
        }

        void LoadTilesandEnemies()
        {
            player = new Player(playerparameters);
           /* foreach (Loader.parameter v in loadedparams.Loadedparamaters)
            {
                try
                {
                    map1.Parameterdictionary.Add(v.type, v);
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("An element with Key = \"v.type\" already exists.");
                }
            }*/
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
            player.UnloadContent();
            tilesandenemies.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            //update player before map because to map update stuff dependent on player
            player.Update(gameTime);
            //map1.Update(gameTime, player);
            //this is the map
            tilesandenemies.Update(gameTime, player.GetCurrentRect());
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
           // map1.Draw(spriteBatch, "Underlay");//Draw map befor the player so that player is ontop
           // map1.Draw(spriteBatch, "Overlay");
            tilesandenemies.Draw(spriteBatch);
            if(!player.Dying)
                player.Draw(spriteBatch);
        }
    }
}
