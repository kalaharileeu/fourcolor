using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace fourcolors
{
    public class EnemyGadget : GameObject
    {
        int positionx;
        int positiony;
        protected Vector2 velocity;


        public EnemyGadget(ObjectGroup.MapObject enemyobject)
        {
            dead = false;
            dying = false;
            positionx = enemyobject.x;
            positiony = enemyobject.y;
            deathvector = Vector2.Zero;
            velocity = Vector2.Zero;

            foreach (ObjectGroup.MapObject.Properties.Property p in enemyobject.GetProperties.ListOfProperties)
            {
                if (p.name == "numframes")
                    numframesX = Convert.ToInt32(p.value);
                else if(p.name == "source")
                    image = new Image(p.value);
            }
            LoadContent();
        }

        public override void LoadContent()
        {
            image.LoadContent();
            image.Position.X = positionx;
            image.Position.Y = positiony;
        }

        public override void UnloadContent()
        {
            image.UnloadContent();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            image.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            if(!dead)
            {
                image.Position.X += velocity.X;
                image.Position.Y += velocity.Y;
            }
        }

        public override Rectangle GetCurrentRect()
        {
            return new Rectangle((int)image.Position.X, (int)image.Position.Y, image.width, image.height);
        }

        public void Dead()
        {
            dying = true;
            deathvector.X = (int)image.Position.X;
            deathvector.Y = (int)image.Position.Y;
            dead = true;
        }

        public Vector2 DeathVector
        {
            //Return the place of dying
            get { return deathvector; }
        }

        public bool Dying
        { 
            get { return dying; } 
        }
    }
}
