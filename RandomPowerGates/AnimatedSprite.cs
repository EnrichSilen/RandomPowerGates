using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RandomPowerGates
{
    public abstract class AnimatedSprite
    {
        //pozice objektu
        public Vector2 position;
        //texura objektu
        protected Texture2D objectTexture;
        //jednotlivé pohledy z animace
        private Rectangle[] objectRectangles;
        //kolizní zóna
        public Rectangle objectBounds;
        //index aktuálního pohlecu
        private int frameIndex;
        //šířka jednoho pohledu
        private int frameWidth;
        //počet milisekund mezi přepnutí pohledu
        protected int timePerFrame = 500;
        //počet milisekund od poslední změny pohledu
        private int timeSinceLastFrame = 0;
        //směr jakým se hráč "kouká" (směrěm ke kurzoru)
        Vector2 direction;


        //konstruktor objektu
        public AnimatedSprite(Vector2 position, int timePerFrame)
        {
            this.timePerFrame = timePerFrame;
            this.position = position;
        }
        //metoda na přidání animace
        public void AddAnimation(int frames)
        {
            frameWidth = objectTexture.Width / frames;
            objectRectangles = new Rectangle[frames];
            for (int i = 0; i < frames; i++)
            {
                objectRectangles[i] = new Rectangle(i * frameWidth, 0, frameWidth, objectTexture.Height);
            }
        }
        //metoda, která se volá pravidelně a obsahuje logiku
        public void Update(GameTime gameTime)
        {

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
        //metoda, která se volá pravidelně a obsahuje vykreslování objektu
        public void Draw(SpriteBatch spriteBatch)
        {
                spriteBatch.Draw(objectTexture, position, objectRectangles[frameIndex], Color.White);            
        }
    }
}
