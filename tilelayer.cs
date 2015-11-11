using System;
using System.Collections.Generic;
using System.Xml.Serialization;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System.Diagnostics;

namespace fourcolors
{
    public class layer
    {
        //***********************class Propeties********************//
        public class properties
        {
            //**********************inner class Property********************//
            public class property
            {
                [XmlAttribute]
                public string name;
                [XmlAttribute]
                public string value;//Solid or passive
            }
            //Properties countains a list of Property
            [XmlElement("property")]
            public List<property> listOfProperties;

            public properties()
            {
                listOfProperties = new List<property>();
            }

            public List<property> ListOfProperties
            {
                get { return listOfProperties; }
            }
        }

      //  [XmlAttribute]
        string name;//TODO: Can possibly remove these
       // [XmlAttribute]
        string state;//TODO: Can possibly remove these Solid or passive
        [XmlElement("properties")]
        public properties propertie;
        [XmlElement("data")]
        public string data;
        [XmlIgnore]
        public Image Image;
        List<Tile> underlayTiles;

        public string Data
        {
            get { return data; }
        }

        public layer()
        {
            Image = new Image();
            underlayTiles = new List<Tile>();
            propertie = new properties(); 
        }

        public void LoadContent(Vector2 tileDimensions, int tileheight, int tilewidth, int height, int width, int spacing, int margin)
        {
            var prpty = propertie.ListOfProperties.Find(x => x.name == "state");
            if (prpty != null)
                state = prpty.value;//prpty is the instance of aproperty class
            Image.LoadContent();
            
            byte[] encodeddata = Convert.FromBase64String(data);
            //string decodedString = Encoding.UTF8.GetString(encodeddata);//not needed

            List<int> tile_ids = new List<int>();
            for (int j = 0; j < (150 * 15); j++)//TODO: fix this (the 150 * 15) should pull from xml
            {
                int i = j * 4;
                //int c = decodedString[i];//not needed
                int h = encodeddata[i];

                if (h < 0)
                {
                    int cp = 256 + h;//
                    tile_ids.Add(cp);//
                }
                else
                {
                    tile_ids.Add(h);
                }
            }
            Vector2 position = -tileDimensions;
            int numImageCol = (Image.width - margin)/(tilewidth + 2);//the (width + 2) is sell width + margin

            //The backfround range is 20 by 15: 
            int n = 0;
            for (int m = 0; m < height; m++)
            {
                for (int k = 0; k < width; k++)//the width is the amount of tiles on the x axis
                {
                   if (tile_ids[n] != 0)
                    {
                    position.X = tileDimensions.X * k;
                    position.Y = tileDimensions.Y * m;

                    int v1 = tile_ids[n];

                    int col = (tile_ids[n] % numImageCol) - 1;//Y axes to start cropping
                    int row = (tile_ids[n] / numImageCol);//X axes col to start cropping

                    //state = "Solid";//Passive state and solid state. solid state not walk throuhg
                    Tile tile = new Tile();//make a instance of a new tile
                    //send coordiantes to crop out the tile
                    //if (tile_ids[n] != 0)
                    //{
                        tile.LoadContent(position, new Rectangle(margin + col * ((int)tileDimensions.X + spacing), margin + row * ((int)tileDimensions.Y + spacing),
                            (int)tileDimensions.X, (int)tileDimensions.Y), state);//pass state to load content
                        underlayTiles.Add(tile);
                    }
                    n++;
                }
            }
        }

        public void UnloadContent()
        {
            Image.UnloadContent();
        }

        public void Update(GameTime gameTime, Rectangle playerrect)//optimise
        {
            foreach (Tile tile in underlayTiles)
            {
                //This is to check for collision.
                tile.Update(gameTime, playerrect);
                tile.scroll(1);
            }
        }

        public void Draw(SpriteBatch spriteBatch)//Optimse not to loop through everytile
        {
            List<Tile> tiles;//make a local list of tiles
            tiles = underlayTiles;

            foreach (Tile tile in tiles)//serach through the local list of tiles
            {
                Image.Position = tile.Position;
                Image.SourceRect = tile.SourceRect;
                Image.Draw(spriteBatch);
            }
        }
    }
}
