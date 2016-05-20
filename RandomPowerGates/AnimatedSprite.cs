using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RandomPowerGates
{
    public abstract class AnimatedSprite
    {
        private Vector2 position;
        protected Texture2D objectTexture;
        private Rectangle[] objectRectangles;
        private int frameIndex;
        public AnimatedSprite(Vector2 position)
        {
            this.position = position;
        }

        public void AddAnimation(int frames)
        {

        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(objectTexture, position,objectRectangles[frameIndex], Color.White);
        }
    }
}
