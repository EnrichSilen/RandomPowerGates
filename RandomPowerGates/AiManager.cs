using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomPowerGates
{
    class AiManager
    {
        public AiManager()
        {
            //tři testovací boti, kteří zmizí pokud se jich dotkne hráč
            addAI(new Vector2(1000, 700));
            addAI(new Vector2(500, 700));
            addAI(new Vector2(1000, 50));
        }
        //metoda pro přidání NPC na herní plochu
        public void addAI(Vector2 npcPosition)
        {
            Global.instance.npcs.Add(new Npc(npcPosition, 500, 1));
        }
        //Načítání textury
        public void LoadContent(ContentManager contentManager)
        {
            foreach (Npc n in Global.instance.npcs)
            {
                n.LoadContent(contentManager, "Player/AI.png");
            }
        }
        //metoda vykonávající logiku
        public void Update(GameTime gameTime)
        {
            foreach (Npc n in Global.instance.npcs)
            {
                if (Global.instance.player.position.X < n.position.X)
                    n.position = new Vector2(n.position.X - n.speed, n.position.Y);
                if (Global.instance.player.position.X > n.position.X)
                    n.position = new Vector2(n.position.X + n.speed, n.position.Y);
                if (Global.instance.player.position.Y < n.position.Y)
                    n.position = new Vector2(n.position.X, n.position.Y - n.speed);
                if (Global.instance.player.position.Y > n.position.Y)
                    n.position = new Vector2(n.position.X, n.position.Y + n.speed);

                n.Update(gameTime);
            }
            for (int i = 0; i < Global.instance.npcs.Count; i++)
            {
                if (Global.instance.npcs[i].objectBounds.Intersects(Global.instance.player.objectBounds))
                {
                    Global.instance.npcs.RemoveAt(i);
                    i--;
                }
            }            
        }

        //Vykreslení na herní plochu
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Npc n in Global.instance.npcs)
            {
                n.Draw(spriteBatch);
            }
        }
    }

    class Npc : AnimatedSprite
    {
        //rychlost NPC-čka
        public int speed = 1;
        public Npc(Vector2 position, int timePerFrame, int speed) : base(position, timePerFrame)
        {
            this.speed = speed;
        }
        public void LoadContent(ContentManager contentManager, string texturePath)
        {
            //default = "Player/Player2.png"
            objectTexture = contentManager.Load<Texture2D>(texturePath);
            AddAnimation(4);
        }
    }
}
