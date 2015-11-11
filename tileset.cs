using System.Xml.Serialization;

namespace fourcolors
{
    /// <summary>
    /// The tileset get instantiated thought the XmlManager and contains information about the tilesset to be used.
    /// </summary>
    public class tileset
    {
        [XmlAttribute]
        public int tilewidth;
        [XmlAttribute]
        public int tileheight;
        [XmlAttribute]
        public int spacing;
        [XmlAttribute]
        public int margin;
        public Image image;

        tileset()
        {
            image = new Image();
        }

        public Image getimage
        {
            get { return image; }
        }
    }
}
