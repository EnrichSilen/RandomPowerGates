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
        internal Vector2 position;
        private Texture2D wallTexture;
        private Rectangle wallBounds;

        public Wall(Vector2 position)
        {
            this.position = position;
        }

        public void LoadContent(ContentManager contentManager, string texturePath)
        {
            //"Background/wall-standart.png"
            wallTexture = contentManager.Load<Texture2D>(texturePath);
            wallBounds = new Rectangle((int)position.X, (int)position.Y, wallTexture.Width, wallTexture.Height);

        }
        public void setBounds()
        {  
             
        }
        public Texture2D GetWallTexture() { return wallTexture; }
        public Rectangle GetWallBounds() { return wallBounds; }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(wallTexture, position, Color.White);
        }
    }
}
