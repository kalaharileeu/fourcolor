﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace fourcolors
{
    class EnemyGadget : GameObject
    {
        int positionx;
        int positiony;
        protected Vector2 velocity;
<<<<<<< HEAD
        Rectangle deathvector;
=======
>>>>>>> 2fa82ea2fc86dd0128829cfefa5c8af7e28e6f96


        public EnemyGadget(ObjectGroup.MapObject enemyobject)
        {
            dead = false;
            dying = false;
            positionx = enemyobject.x;
            positiony = enemyobject.y;
<<<<<<< HEAD
            deathvector = new Rectangle();
=======
>>>>>>> 2fa82ea2fc86dd0128829cfefa5c8af7e28e6f96

            foreach (ObjectGroup.MapObject.Properties.Property p in enemyobject.GetProperties.ListOfProperties)
            {
                if (p.name == "numframes")
                    numframesX = Convert.ToInt32(p.value);
                else if(p.name == "source")
                    image = new Image(p.value);
            }

            velocity = Vector2.Zero;
            LoadContent();
        }

<<<<<<< HEAD
        public void Dead(Rectangle dv)
        {
            deathvector = dv;
            dying = true;
        }

        public Rectangle GetCurrentRect()
        {
            Rectangle collisionRect = new Rectangle((int)image.Position.X, (int)image.Position.Y, image.Texture.Width, image.Texture.Height);
            return collisionRect;
        }

=======
>>>>>>> 2fa82ea2fc86dd0128829cfefa5c8af7e28e6f96
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
    }
}
