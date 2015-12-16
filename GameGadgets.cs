using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace fourcolors
{
    /// <summary>
    /// Gamegadget are for the score diplayed and for instance something like power left etc.
    /// Game meters and other moslickely stionary screen objects
    /// </summary>
    class GameGadgets : GameObject
    {
        int positionx;
        int positiony;
        protected Vector2 velocity;
        /// <summary>
        /// Big constructor to load all the parameters from ObjectGroup.MapObject
        /// </summary>
        /// <param name="objectparameters"></param>
        public GameGadgets(ObjectGroup.MapObject objectparameters)
        {
            dead = false;
            dying = false;
            positionx = objectparameters.x;
            positiony = objectparameters.y;
            deathvector = Vector2.Zero;
            velocity = Vector2.Zero;
            //Parmeters drom Tiled xml
            var match = objectparameters.GetProperties.ListOfProperties.Find(x => x.name == "numFrames");
            if (match != null)
                numframesX = Convert.ToInt32(match.value);
            match = objectparameters.GetProperties.ListOfProperties.Find(x => x.name == "source");
            if (match != null)
                image = new Image(match.value);
            match = objectparameters.GetProperties.ListOfProperties.Find(x => x.name == "Height");
            if ((match != null) && (image != null))
                image.height = Convert.ToInt32(match.value);
            match = objectparameters.GetProperties.ListOfProperties.Find(x => x.name == "Width");
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
            
        }

        public override Rectangle GetCurrentRect()
        {
            return new Rectangle((int)image.Position.X, (int)image.Position.Y, image.width, image.height);
        }
    }
}
