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
            Global.instance.poratls.Add(new Portal(position));
        }

        #endregion

        public void Initialize()
        {

            //Generating map from seed
            int x = -1, y = 0;
            Global.instance.map = new Map("22222222222222222222222222222222n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000002200002n20000000000000000000000002200002n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000110002n20000000000000000000000000110002n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n22222222222222222222222222222222&");
            for (int i = 0; i < Global.instance.map.mapSeed.Length; i++)
            {
                x++;
                if (Global.instance.map.mapSeed[i] == '1')   //GROUND
                    Global.instance.map.walls[x, y] = 1;
                if (Global.instance.map.mapSeed[i] == '2')   //WALL
                    Global.instance.map.walls[x, y] = 2;
                if (Global.instance.map.mapSeed[i] == 'n')   //NEW LINE
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
            Global.instance.background = new BackGround(Vector2.Zero);
        }
        public void LoadContent(ContentManager contentManager)
        {
            foreach (Wall w in Global.instance.walls)
            {
                w.LoadContent(contentManager, "Background/wall-standart.png");
            }
            foreach (Portal g in Global.instance.poratls)
            {
                g.LoadContent(contentManager, "Background/Ground.png");
            }
#if DEBUG
            Global.instance.background.LoadContent(contentManager, "Background/Background-dev.png");
#else
            Global.instance.background.LoadContent(contentManager, "Background/Background-standart.png");
#endif
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            BackGround g2 = Global.instance.background;
            spriteBatch.Draw(g2.bcTexture, g2.bcPosition, null, Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 1f);
            foreach (Wall w in Global.instance.walls)
            {
                spriteBatch.Draw(w.GetWallTexture(), w.position, Color.White);
            }
            foreach (Portal g in Global.instance.poratls)
            {
                spriteBatch.Draw(g.portalTexture, g.groundPosition,Color.White);
            }
        }
    }

    class Map
    {
        // 1 - Portal   2- WALL
        public string mapSeed = "";
        public int[,] walls = new int[32, 20];

        public Map(string mapSeed)
        {
            this.mapSeed = mapSeed;
        }
    }

    class Portal
    {
        public Texture2D portalTexture;
        public Vector2 groundPosition;

        public Portal(Vector2 portalPosition)
        {
            this.groundPosition = portalPosition;
        }
        public void LoadContent(ContentManager contentManager, string texturePath)
        {
            portalTexture = contentManager.Load<Texture2D>(texturePath);
        }
    }

    class BackGround
    {
        public Texture2D bcTexture;
        public Vector2 bcPosition;

        public BackGround(Vector2 bcPosition)
        {
            this.bcPosition = bcPosition;
        }
        public void LoadContent(ContentManager contentManager, string texturePath)
        {
            bcTexture = contentManager.Load<Texture2D>(texturePath);
        }
    }
}
