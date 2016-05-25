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
    class WallsManager
    {
        public enum WallType
        {
            standart
        }

        public void addWall(WallType wallType, Vector2 WallPosition)
        {
            switch (wallType)
            {
                case WallType.standart:
                    Global.instance.walls.Add(new Wall(WallPosition));
                    break;
            }

        }
        public void LoadContent(ContentManager contentManager)
        {
            Global.instance.walls[0].LoadContent(contentManager, "Background/wall-standart.png");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var w in Global.instance.walls)
            {
                spriteBatch.Draw(w.GetObjectTexture(), w.position, Color.White);
            }
        }
    }
}
