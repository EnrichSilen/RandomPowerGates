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
        //Mapa
        public MapManager mapManager;
        public int windowWidth, windowHeight;

        public List<Wall> walls = new List<Wall>();
        public Map map;
        public List<Portal> poratls = new List<Portal>();

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
