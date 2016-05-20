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
        public Player(Vector2 position) : base(position)
        {
            
        }

        public void LoadContent(ContentManager contentManager)
        {
            objectTexture = contentManager.Load<Texture2D>("Player/Player.png");
        }

    }
}
