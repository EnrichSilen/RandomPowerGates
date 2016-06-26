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
    public enum Direction
    {
        up,
        down,
        right,
        left
    }
    class Global
    {
       

        //instance objektu Global
        public static readonly Global instance = new Global();
        //Obsah
        public ContentManager contentManager;
        //RANDOM
        public Random rng = new Random();
        //Mapa
        public MapManager mapManager;
        public int windowWidth, windowHeight;
        public List<Map> maps = new List<Map>();
        public int warpIndex = 0;

        public List<Wall> walls1 = new List<Wall>();
        public List<Portal> portals1 = new List<Portal>();

        public List<Wall> walls2 = new List<Wall>();
        public List<Portal> portals2 = new List<Portal>();

        public List<Wall> walls3 = new List<Wall>();
        public List<Portal> portals3 = new List<Portal>();

        public List<Wall> walls4 = new List<Wall>();
        public List<Portal> portals4 = new List<Portal>();

        public List<Wall> walls5 = new List<Wall>();
        public List<Portal> portals5 = new List<Portal>();



        //Debug
        public DebugManager debugManager = new DebugManager();

        //Pozadí
        public BackGround background;
        //Hráč
        public Player player;
        //Zaměřovač
        public Crosshair crosshair;
        //Manažer útoku
        public AtackManager atackManager;
        public List<Projectile> projectiles = new List<Projectile>();
        public Texture2D projectileTexture;
        public Direction playerDirection;
        //Manažer textů
        public TextManager textManager;
        //Manažer pohybu
        public MoveManager moveManager;
        //AI & NPX
        public AiManager aiManager;
        public List<Npc> npcs = new List<Npc>();
        //privátní konstruktor objektu Global znemožňující instanci objektu vytvořit
        private Global() { }

        
    }
}
