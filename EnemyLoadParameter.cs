using System.Collections.Generic;
using System.Xml.Serialization;

namespace fourcolors
{
    public class ObjectGroup
    {
        public class MapObject
        {
            //***********************class Propeties********************//
            public class Properties
            {
                //**********************class Property********************//
                public class Property
                {
                    [XmlAttribute]
                    public string name;
                    [XmlAttribute]
                    public string value;
                }
                [XmlElement("property")]
                public List<Property> listOfProperties;

                public Properties()
                {
                    listOfProperties = new List<Property>();
                }

                public List<Property> ListOfProperties
                {
                    get { return listOfProperties; }
                }
            }
            //******************MapObject down here********
            [XmlAttribute]
            public string name;
            [XmlAttribute]
            public string type;
            [XmlAttribute]
            public int x;
            [XmlAttribute]
            public int y;

            [XmlElement("properties")]
            public Properties properties;//Height, Width, numFrames, source

            public MapObject()
            {
                properties = new Properties();
            }

            public Properties GetProperties
            {
                get { return properties; }
            }
        }
        //Objectgroup down here
        [XmlElement("object")]
        public List<MapObject> mapobjects;

        public ObjectGroup()
        {
            mapobjects = new List<MapObject>();
        }

        public List<MapObject> Mapobjects
        {
            get
            {
                return mapobjects;
            }
        }
    }
}
