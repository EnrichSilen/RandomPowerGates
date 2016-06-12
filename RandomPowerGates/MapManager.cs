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
    class MapManager
    {
        #region Walls
        public void addWall(Vector2 WallPosition)
        {
            Global.instance.walls.Add(new Wall(WallPosition));
        }
        #endregion
        #region Background
        public void addGround(Vector2 position)
        {
            Global.instance.grounds.Add(new Ground(position));
        }

        #endregion

        public void Initialize()
        {
#if DEBUG
            //workin' walls
            Global.instance.wall1 = new Wall(new Vector2(40, 40));
            Global.instance.wall2 = new Wall(new Vector2(80, 40));
            Global.instance.wall3 = new Wall(new Vector2(120, 40));

#else
            //Generating map from seed
            int x = -1, y = 0;
            Global.instance.map = new Map();
            for (int i = 0; i < Global.instance.map.defaultMap.Length; i++)
            {
                x++;
                if (Global.instance.map.defaultMap[i] == '1')   //GROUND
                    Global.instance.map.walls[x, y] = 1;
                if (Global.instance.map.defaultMap[i] == '2')   //WALL
                    Global.instance.map.walls[x, y] = 2;
                if (Global.instance.map.defaultMap[i] == 'n')   //NEW LINE
                {
                    x = -1;
                    y++;
                }
            }
            for (int i = 0; i < Global.instance.map.walls.GetLength(0); i++)
            {
                for (int k = 0; k < Global.instance.map.walls.GetLength(1); k++)
                {
                    if (Global.instance.map.walls[i, k] == 1)       
                        addGround(new Vector2(40 * i, 40 * k));
                    if (Global.instance.map.walls[i, k] == 2)
                        addWall(new Vector2(40 * i, 40 * k));
                }
            }
#endif
            Global.instance.background = new Ground(Vector2.Zero);
        }
        public void LoadContent(ContentManager contentManager)
        {
            foreach (Wall w in Global.instance.walls)
            {
                w.LoadContent(contentManager, "Background/wall-standart.png");
            }
            foreach (Ground g in Global.instance.grounds)
            {
                g.LoadContent(contentManager, "Background/Ground.png");
            }
#if DEBUG
            Global.instance.background.LoadContent(contentManager, "Background/Background-dev.png");
            //workin' walls
            Global.instance.wall1.LoadContent(contentManager, "Background/wall-standart.png");
            Global.instance.wall2.LoadContent(contentManager, "Background/wall-standart.png");
            Global.instance.wall3.LoadContent(contentManager, "Background/wall-standart.png");
            //
#else
            Global.instance.background.LoadContent(contentManager, "Background/Background-standart.png");
#endif
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Ground g2 = Global.instance.background;
            spriteBatch.Draw(g2.groundTexture, g2.groundPosition, null, Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 1f);
            foreach (Wall w in Global.instance.walls)
            {
                spriteBatch.Draw(w.GetWallTexture(), w.position, Color.White);
            }
            foreach (Ground g in Global.instance.grounds)
            {
                spriteBatch.Draw(g.groundTexture, g.groundPosition,Color.White);
            }
#if DEBUG
            //workin' walls
            spriteBatch.Draw(Global.instance.wall1.GetWallTexture(), Global.instance.wall1.position, Color.White);
            spriteBatch.Draw(Global.instance.wall2.GetWallTexture(), Global.instance.wall2.position, Color.White);
            spriteBatch.Draw(Global.instance.wall3.GetWallTexture(), Global.instance.wall3.position, Color.White);
            //
#endif
        }
    }

    class Map
    {
        public string defaultMap = "0n0n0n0n000021212121n0002121212";
        public int[,] walls = new int[32, 20];

        public Map()
        {
        }
    }

    class Ground
    {
        public Texture2D groundTexture;
        public Vector2 groundPosition;

        public Ground(Vector2 groundPosition)
        {
            this.groundPosition = groundPosition;
        }
        public void LoadContent(ContentManager contentManager, string texturePath)
        {
            groundTexture = contentManager.Load<Texture2D>(texturePath);
        }
    }
}
