using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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
        protected bool isPlayer;
        Rectangle objectRectangle;
        Vector2 origin;
        Vector2 direction;



        public AnimatedSprite(Vector2 position, int timePerFrame)
        {
            this.timePerFrame = timePerFrame;
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
            objectRectangle = new Rectangle((int)position.X, (int)position.Y, frameWidth, objectTexture.Height);
            origin = new Vector2(objectRectangle.Width / 2, objectRectangle.Height / 2);

            direction = new Vector2(Global.instance.crosshair.position.X - position.X, Global.instance.crosshair.position.Y - position.Y);
            Global.instance.angle = -(float)Math.Atan2(direction.X, direction.Y);

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
        //float angle = 0;
        public void Draw(SpriteBatch spriteBatch)
        {
                spriteBatch.Draw(objectTexture, position, objectRectangles[frameIndex], Color.White);
            
                //angle += 0.1f ;
                //spriteBatch.Draw(objectTexture, position, objectRectangles[frameIndex],Color.White, angle, origin, 1, SpriteEffects.None,0);
                //spriteBatch.Draw(objectTexture, objectRectangle, objectRectangles[frameIndex],Color.White, angle, origin, SpriteEffects.None, 1);
            
        }
    }
}
