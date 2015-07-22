using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml.Serialization;

namespace fourcolors
{
    public class Loader
    {
        public class parameter
        {
            public Image image;
            public string imagesource;
            public float movespeed;
            public int life;//number of frames to animate till deat of animation
            public string animatedtype;
            public int numframesX;
            public int numframesY;
            public bool dead;
            public bool dying;
            public int hits;
            public int strength;
        }

        [XmlElement("parameter")]
        public List<parameter> loadparameters;

        public List<parameter> Loadedparamaters
        {
            get { return loadparameters; }  
        }

        public Loader()
        {
            loadparameters = new List<parameter>();
        }
    }
}
