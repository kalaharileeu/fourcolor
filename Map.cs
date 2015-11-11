using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace fourcolors
{
    public class map
    {
        [XmlAttribute]
        public int width;//Amount of tiles to make up image
        [XmlAttribute]
        public int height;//Amount of tiles to make up image
        [XmlAttribute]
        public int tilewidth;//Pixel width
        [XmlAttribute]
        public int tileheight;//pixel width
        [XmlElement("tileset")]
        public tileset tilesetinfo;
        [XmlElement("layer")]
        public List<layer> Layer;
        [XmlElement("objectgroup")]
        public List<ObjectGroup> objectgroups;//Mostly enemies and background
        Vector2 TileDimensions;
        List<EnemyGadget> maplistenemies;
        //CollisionManager collisionmanager;

        public map()
        {
            Layer = new List<layer>();
            TileDimensions = Vector2.Zero;
            objectgroups = new List<ObjectGroup>();
            maplistenemies = new List<EnemyGadget>();
            //collisionmanager = new CollisionManager();
        }

        public void LoadContent()
        {
            SoundManager.Instance.PlayMusic();

            TileDimensions.X = tilewidth;
            TileDimensions.Y = tileheight;
            foreach (layer l in Layer)
            {
                l.Image = tilesetinfo.getimage;
                int spacing = tilesetinfo.spacing;
                int margin = tilesetinfo.margin;
                l.LoadContent(TileDimensions, tileheight, tilewidth, height, width, spacing, margin);
            }

            foreach (ObjectGroup o in objectgroups)
            {
                foreach (ObjectGroup.MapObject mo in o.Mapobjects)
                {
                   //maplistenemies.Add((EnemyGadget)Activator.CreateInstance(typeof(Glider) , mo));
                   maplistenemies.Add((EnemyGadget)Activator.CreateInstance
                       (Type.GetType("fourcolors." + mo.type), mo));
                }
            }
            foreach (EnemyGadget eg in maplistenemies)
            {
                eg.LoadContent();
            }
        }

        public void UnloadContent()
        {
            foreach (layer l in Layer)
                l.UnloadContent();

            foreach (EnemyGadget eg in maplistenemies)
            {
                eg.UnloadContent();
            }
        }
        /// <summary>
        /// Map updates the layershere and checks for collsions via collision manager
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime, Player player)
        {
            //Check for collsiions between enemy and plyer and playerbullets
            CollisionManager.Instance.checkEnemyPlayerBulletCollision(maplistenemies);
            bool cleanup = false;
            foreach (layer l in Layer)
                l.Update(gameTime, player);

            foreach (EnemyGadget eg in maplistenemies)
            {
                if (!eg.Dying)
                {
                    eg.Update(gameTime);
                }
                else
                {
                    cleanup = true;
                    //Collided load animated graphics
                    BulletHandler.Instance.addAnimatedGraphics((int)eg.DeathVector.X,
                        (int)eg.DeathVector.Y);
                    SoundManager.Instance.Playexplode();
                }
            }
            //if the was somethign dying then remove it from the list
            if (cleanup)
                maplistenemies.RemoveAll(EnemyGadget => EnemyGadget.Dying);

            BulletHandler.Instance.update(gameTime);//used to be in player
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (EnemyGadget eg in maplistenemies)
            {
                eg.Draw(spriteBatch);
            }

            foreach (layer l in Layer)
                l.Draw(spriteBatch);


        }
    }
}
