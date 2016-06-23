using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomPowerGates
{
    class AtackManager
    {
        int delay = 0;
        public AtackManager()
        {
            
        }

        //metoda pro přidání projektilu do pole
        private void Shooting(ContentManager contentManager)
        {
            Vector2 projPos = new Vector2(Global.instance.player.position.X + (Global.instance.player.GetWidth() / 2), Global.instance.player.position.Y + (Global.instance.player.GetHeight() / 2));
            Global.instance.projectiles.Add(new Projectile(projPos,Global.instance.playerDirection,80,8));
            foreach (Projectile p in Global.instance.projectiles)
            {
                p.LoadContent(contentManager, "Player/Projectile.png");
            }
        }
        //metoda třelby
        public void Shoot(ContentManager contentManager, KeyboardState keyboardState)
        {
            if (keyboardState.IsKeyDown(Keys.Space))
                if (delay < 1)
                {
                    Shooting(contentManager);
                    delay = 1000;
                }

            if (delay > 0)
                delay -= 25;

            
    }

        //metoda vykonávající logiku
        public void Update(GameTime gameTime)
        {
            foreach (Projectile p in Global.instance.projectiles)
            {
                if (p.direction == Direction.up)
                    p.position = new Vector2(p.position.X,p.position.Y - p.speed);
                if (p.direction == Direction.down)
                    p.position = new Vector2(p.position.X, p.position.Y + p.speed);
                if (p.direction == Direction.left)
                    p.position = new Vector2(p.position.X - p.speed, p.position.Y);
                if (p.direction == Direction.right)
                    p.position = new Vector2(p.position.X + p.speed, p.position.Y);


                p.Update(gameTime);
            }
        }

        //Vykreslení na herní plochu
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(Projectile p in Global.instance.projectiles)
            {
                p.Draw(spriteBatch);
            }

            for (int k = 0; k < Global.instance.walls.Count; k++)
            {
                for (int i = 0; i < Global.instance.projectiles.Count; i++)
                {
                    if (Global.instance.projectiles[i].objectBounds.Intersects(Global.instance.walls[k].objectBounds))
                    {
                        Global.instance.projectiles.RemoveAt(i);
                        i--;
                    }
                }
            }
        }
    }

    public class Projectile : AnimatedSprite
    {
        public Direction direction;
        public int speed = 1;
        public Projectile(Vector2 position,Direction direction, int timePerFrame, int speed = 1) : base(position, timePerFrame)
        {
            this.direction = direction;
            this.speed = speed;
        }
        public void LoadContent(ContentManager contentManager, string texturePath)
        {
            //default = "Player/Projectile.png"
            objectTexture = contentManager.Load<Texture2D>(texturePath);
            AddAnimation(4);
        }

    }
}
