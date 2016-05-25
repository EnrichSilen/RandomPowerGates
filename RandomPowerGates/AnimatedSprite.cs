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
        public Vector2 position;
        protected Texture2D objectTexture;
        private Rectangle[] objectRectangles;
        public Rectangle objectBounds;
        private int frameIndex;
        private int frameWidth;
        protected int timePerFrame = 500;
        private int timeSinceLastFrame = 0;
        public AnimatedSprite(Vector2 position)
        {
            this.position = position;
        }

        public void AddAnimation(int frames)
        {
            frameWidth = objectTexture.Width / frames;
            objectRectangles = new Rectangle[frames];
            for (int i = 0; i < frames; i++)
            {
                objectRectangles[i] = new Rectangle(i * frameWidth, 0, frameWidth, objectTexture.Height);
            }
        }

        //public int FramesPerSecond
        //{
        //    set { timePerFrame = (1 / value); }
        //}

        public void Update(GameTime gameTime)
        {
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            objectBounds = new Rectangle((int)position.X, (int)position.Y, frameWidth, objectTexture.Height);
            if (timeSinceLastFrame >= timePerFrame)
            {
                if (!(frameIndex < objectRectangles.Length - 1))
                {
                    frameIndex = 0;
                    
                }
                else
                    frameIndex++;

                timeSinceLastFrame = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(objectTexture, position,objectRectangles[frameIndex], Color.White);
        }
    }
}
