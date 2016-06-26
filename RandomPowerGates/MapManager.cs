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
        
        public void addWall(Vector2 position, int mapIndex)
        {
            switch (mapIndex)
            {
                case 0:
                    Global.instance.walls1.Add(new Wall(position));
                    break;
                case 1:
                    Global.instance.walls2.Add(new Wall(position));
                    break;
                case 2:
                    Global.instance.walls3.Add(new Wall(position));
                    break;
                case 3:
                    Global.instance.walls4.Add(new Wall(position));
                    break;
                case 4:
                    Global.instance.walls5.Add(new Wall(position));
                    break;

            }
        }
        
        public void addGround(Vector2 position, int mapIndex)
        {

            switch (mapIndex)
            {
                case 0:
                    Global.instance.portals1.Add(new Portal(position));
                    break;
                case 1:
                    Global.instance.portals2.Add(new Portal(position));
                    break;
                case 2:
                    Global.instance.portals3.Add(new Portal(position));
                    break;
                case 3:
                    Global.instance.portals4.Add(new Portal(position));
                    break;
                case 4:
                    Global.instance.portals5.Add(new Portal(position));
                    break;


            }

        }

        public void Warp()
        {
            switch (Global.instance.warpIndex)
            {
                case 1:
                    Global.instance.player.position = new Vector2(45, 500);
                    Global.instance.walls1 = new List<Wall>(Global.instance.walls2);
                    Global.instance.portals1 = new List<Portal>(Global.instance.portals2);
                    Global.instance.mapManager.LoadContent(Global.instance.contentManager);
                    break;
                case 2:
                    Global.instance.player.position = new Vector2(580, 700);
                    Global.instance.walls1 = new List<Wall>(Global.instance.walls3);
                    Global.instance.portals1 = new List<Portal>(Global.instance.portals3);
                    Global.instance.mapManager.LoadContent(Global.instance.contentManager);
                    break;
                case 3:
                    Global.instance.player.position = new Vector2(1200, 460);
                    Global.instance.walls1 = new List<Wall>(Global.instance.walls4);
                    Global.instance.portals1 = new List<Portal>(Global.instance.portals4);
                    Global.instance.mapManager.LoadContent(Global.instance.contentManager);
                    break;
                case 4:
                    Global.instance.player.position = new Vector2(600, 45);
                    Global.instance.walls1 = new List<Wall>(Global.instance.walls5);
                    Global.instance.portals1 = new List<Portal>(Global.instance.portals5);
                    Global.instance.mapManager.LoadContent(Global.instance.contentManager);
                    break;
                default: break;
            }

            if (Global.instance.player.points >= 2)
            {
                Global.instance.player.points = 0;
                Global.instance.warpIndex++;
                Global.instance.aiManager.SpawnGroup(3 + Global.instance.warpIndex);
            }

            

        }

        public void Initialize()
        {

            //Generating map from seed
            

            Global.instance.maps.Add(new Map(0, "22222222222222222222222222222222n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000001n20000000000000000000000000000001n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n22222222222222222222222222222222&"));
            Global.instance.maps.Add(new Map(1, "22222222222222112222222222222222n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n22222222222222222222222222222222&"));
            Global.instance.maps.Add(new Map(2, "22222222222222222222222222222222n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n10000000000000000000000000000002n10000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n22222222222222222222222222222222&"));
            Global.instance.maps.Add(new Map(3, "22222222222222222222222222222222n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n22222222222222112222222222222222&"));
            Global.instance.maps.Add(new Map(4, "22222222222222222222222222222222n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n20000000000000000000000000000002n22222222222222222222222222222222&"));

            Global.instance.background = new BackGround(Vector2.Zero);
            GenerateMap(0);
            GenerateMap(1);
            GenerateMap(2);
            GenerateMap(3);
            GenerateMap(4);
        }

        public void GenerateMap(int mapIndex)
        {
            

            int x = -1, y = 0;
            for (int i = 0; i < Global.instance.maps[mapIndex].mapSeed.Length; i++)
            {
                x++;
                if (Global.instance.maps[mapIndex].mapSeed[i] == '1')   //GROUND
                    Global.instance.maps[mapIndex].walls[x, y] = 1;
                if (Global.instance.maps[mapIndex].mapSeed[i] == '2')   //WALL
                    Global.instance.maps[mapIndex].walls[x, y] = 2;
                if (Global.instance.maps[mapIndex].mapSeed[i] == 'n')   //NEW LINE
                {
                    x = -1;
                    y++;
                }
            }
            for (int i = 0; i < Global.instance.maps[mapIndex].walls.GetLength(0); i++)
            {
                for (int k = 0; k < Global.instance.maps[mapIndex].walls.GetLength(1); k++)
                {
                    if (Global.instance.maps[mapIndex].walls[i, k] == 1)
                        addGround(new Vector2(40 * i, 40 * k), mapIndex);
                    if (Global.instance.maps[mapIndex].walls[i, k] == 2)
                        addWall(new Vector2(40 * i, 40 * k), mapIndex);
                }
            }
           
        }
        public void LoadContent(ContentManager contentManager)
        {
            foreach (Wall w in Global.instance.walls1)
            {
                w.LoadContent(contentManager, "Background/wall-standart.png");
            }
            foreach (Portal g in Global.instance.portals1)
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
            foreach (Wall w in Global.instance.walls1)
            {
                spriteBatch.Draw(w.GetWallTexture(), w.position, Color.White);
            }
            foreach (Portal g in Global.instance.portals1)
            {
                spriteBatch.Draw(g.portalTexture, g.position, Color.White);
            }

        }
    }

    class Map
    {
        // 1 - Portal   2- WALL
        public string mapSeed = "";
        public int id;
        public int[,] walls = new int[32, 20];

        public Map(int id, string mapSeed)
        {
            this.mapSeed = mapSeed;
            this.id = id;
        }
    }

    class Portal
    {
        public Texture2D portalTexture;
        public Vector2 position;
        public Rectangle objectBounds;

        public Portal(Vector2 position)
        {
            this.position = position;
        }
        public void LoadContent(ContentManager contentManager, string texturePath)
        {
            portalTexture = contentManager.Load<Texture2D>(texturePath);
            objectBounds = new Rectangle((int)position.X, (int)position.Y, portalTexture.Width, portalTexture.Height);
        }
    }

    class Wall
    {
        internal Vector2 position;
        private Texture2D wallTexture;
        public Rectangle objectBounds;

        public Wall(Vector2 position)
        {
            this.position = position;
        }

        public void LoadContent(ContentManager contentManager, string texturePath)
        {
            //"Background/wall-standart.png"
            wallTexture = contentManager.Load<Texture2D>(texturePath);
            objectBounds = new Rectangle((int)position.X, (int)position.Y, wallTexture.Width, wallTexture.Height);

        }
        public Texture2D GetWallTexture()
        {
            return wallTexture;
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
