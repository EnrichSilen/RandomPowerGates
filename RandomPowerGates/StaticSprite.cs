using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RandomPowerGates
{
    public abstract class StaticSprite
    {
        public Vector2 position;
        protected Texture2D objectTexture;
        public Rectangle objectBounds;

        public StaticSprite(Vector2 position)
        {
            this.position = position;

        }
        private Rectangle addBounds()
        {
            return new Rectangle();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(objectTexture, position, Color.White);
        }
    }
}
