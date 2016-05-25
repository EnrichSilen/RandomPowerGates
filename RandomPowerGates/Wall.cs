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
    class Wall : StaticSprite
    {
        public Wall(Vector2 position) : base(position)
        {

        }

        public void LoadContent(ContentManager contentManager, string texturePath)
        {
            //"Background/wall-standart.png"
            objectTexture = contentManager.Load<Texture2D>(texturePath);
            objectBounds = new Rectangle((int)position.X,(int)position.Y,objectTexture.Width,objectTexture.Height);
        }
        public Texture2D GetObjectTexture() { return objectTexture; }

    }
}
