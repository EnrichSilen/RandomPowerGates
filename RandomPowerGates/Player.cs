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
    class Player : AnimatedSprite
    {
        //rychlost pohybu hráče
        public float objectSpeed = 3.5f;
        //konstruktor hráče
        public Player(Vector2 position, int timePerFrame) : base(position, timePerFrame)
        {

        }
        //metoda, která se volá při spuštění a načítá texturu hráče
        public void LoadContent(ContentManager contentManager, string texturePath)
        {
            //default = "Player/Player.png"
            objectTexture = contentManager.Load<Texture2D>(texturePath);
            AddAnimation(8);
        }

    }
}
