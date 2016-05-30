using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RandomPowerGates
{
    class Crosshair
    {
        //Textura zaměřovače
        private Texture2D crosshairTexture;
        //Pozice zaměřovače
        public Vector2 position;


        public Crosshair(){ }
        //načtení obsahu
        public void LoadContent(ContentManager contentManager, string texturePath)
        {
            crosshairTexture = contentManager.Load<Texture2D>(texturePath);
        }
        //metoda vykonávající logiku
        public void Update(GameTime gameTime, MouseState mouseState)
        {
            if (position.X != mouseState.X || position.Y != mouseState.Y)
            {
                position = new Vector2(mouseState.X, mouseState.Y);
            }

        }
        //vykreslování
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(crosshairTexture, position, Color.Wheat);
        }
    }
}
