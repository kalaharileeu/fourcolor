using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace fourcolors
{
    abstract class GameObject
    {
        //protected string imagesource;
        protected float movespeed;
        protected string animatedtype;
        protected int numframesX;
        protected int numframesY;
        protected bool dead;
        protected bool dying;
        protected int hits;
        protected int strength;
        protected Image image;

        abstract public void LoadContent();
        abstract public void UnloadContent();
        abstract public void Update(GameTime gameTime);
        abstract public void Draw(SpriteBatch spriteBatch);
    }
}