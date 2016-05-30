using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace RandomPowerGates
{
    class Wall
    {
        //Pozice zdi
        internal Vector2 position;
        //Textura zdi
        private Texture2D wallTexture;
        //Kolizní zóna
        private Rectangle wallBounds;
        //Konstruktor
        public Wall(Vector2 position)
        {
            this.position = position;
        }
        //metoda načítající texturu zdi do paměti
        public void LoadContent(ContentManager contentManager, string texturePath)
        {
            //"Background/wall-standart.png"
            wallTexture = contentManager.Load<Texture2D>(texturePath);
            wallBounds = new Rectangle((int)position.X, (int)position.Y, wallTexture.Width, wallTexture.Height);

        }
        //Get metoda pro získání textury zdi
        public Texture2D GetWallTexture() { return wallTexture; }
        //Get metoda pro získání kolizní zóny zdi
        public Rectangle GetWallBounds() { return wallBounds; }

        //metoda vykreslování
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(wallTexture, position, Color.White);
        }
    }
}
