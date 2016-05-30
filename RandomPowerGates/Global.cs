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
    //Global.instance.
    class Global
    {


        //instance of Global
        public static readonly Global instance = new Global();
        //Map
        public MapManager mapManager;
        public int windowWidth, windowHeight;

        public List<Wall> walls = new List<Wall>();
        public Map map;
        public List<Ground> grounds = new List<Ground>();
        //test
        public Wall wall1;
        public Wall wall2;
        public Wall wall3;
        //
        public Ground background;
        //Player
        public Player player;
        public Crosshair crosshair;
        public Texture2D projectileTexture;
        public AtackManager atackManager;
        public float angle;
        //Texts
        public TextManager textManager;
        //Movement
        public MoveManager moveManager;
        //AI & NPX
        public AiManager aiManager;
        public List<Npc> npcs = new List<Npc>();
        
        private Global() { }

        
    }
}
