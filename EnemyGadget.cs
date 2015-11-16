using System;

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

            var match = enemyobject.GetProperties.ListOfProperties.Find(x => x.name == "numFrames");
            if (match != null)
                numframesX = Convert.ToInt32(match.value);
            match = enemyobject.GetProperties.ListOfProperties.Find(x => x.name == "source");
            if (match != null)
                image = new Image(match.value);
            match = enemyobject.GetProperties.ListOfProperties.Find(x => x.name == "Height");
            if ((match != null) && (image != null))
                image.height = Convert.ToInt32(match.value);
            match = enemyobject.GetProperties.ListOfProperties.Find(x => x.name == "Width");
            if ((match != null) && (image != null))
                image.width = Convert.ToInt32(match.value);

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
            ///Static and mobile enemy inherit from this class, although static
            /// enemy does not move a lot on the X Y axis it still needs below to
            /// maybe jitter or do some other local movement, or scroll
            //Standard movement or mobile enemy
            if (!dead)
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
