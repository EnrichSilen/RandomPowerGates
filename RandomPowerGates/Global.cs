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
    class Global
    {
        //instance objektu Global
        public static readonly Global instance = new Global();
        //Mapa
        public MapManager mapManager;
        public int windowWidth, windowHeight;

        public List<Wall> walls = new List<Wall>();
        public Map map;
        public List<Ground> grounds = new List<Ground>();

#if DEBUG
        //workin' walls
        public Wall wall1;
        public Wall wall2;
        public Wall wall3;
#endif
        //Pozadí
        public Ground background;
        //Hráč
        public Player player;
        //Zaměřovač
        public Crosshair crosshair;
        //Textura projektilu
        public Texture2D projectileTexture;
        //Manažer útoku
        public AtackManager atackManager;
        public float angle;
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
