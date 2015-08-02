using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
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
        [XmlElement("tilelayer")]
        public List<tilelayer> Layer;
        [XmlElement("objectgroup")]
        public List<ObjectGroup> objectgroups;//Mostly enemis and background
        Vector2 TileDimensions;
        List<EnemyGadget> maplistenemies;

        public map()
        {
            Layer = new List<tilelayer>();
            TileDimensions = Vector2.Zero;
            objectgroups = new List<ObjectGroup>();
            maplistenemies = new List<EnemyGadget>();
           // collisionmanager = new CollisionManager();
           // graphicslist = new List<AnimatedGraphics>();
           // parameterdictionary = new Dictionary<string, Loader.parameter>();//the data in Loader.parameter comes from xml
        }

        public void LoadContent()
        {
            SoundManager.Instance.PlayMusic();

            TileDimensions.X = tilewidth;
            TileDimensions.Y = tileheight;
            foreach (tilelayer l in Layer)
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
                   maplistenemies.Add((EnemyGadget)Activator.CreateInstance(Type.GetType("fourcolors." + mo.type), mo));
                }
            }

            foreach (EnemyGadget eg in maplistenemies)
            {
                eg.LoadContent();
            }
        }

        public void UnloadContent()
        {
            foreach (tilelayer l in Layer)
                l.UnloadContent();

            foreach (EnemyGadget eg in maplistenemies)
            {
                eg.UnloadContent();
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (tilelayer l in Layer)
                l.Update(gameTime);

            foreach (EnemyGadget eg in maplistenemies)
            {
                CollisionManager.Instance.checkenemyplayerbulletcollision(eg);
                eg.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (EnemyGadget eg in maplistenemies)
            {
                eg.Draw(spriteBatch);
            }

            foreach (tilelayer l in Layer)
                l.Draw(spriteBatch);
        }
    }
}
