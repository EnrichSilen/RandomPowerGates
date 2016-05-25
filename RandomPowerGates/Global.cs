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
       
        public static readonly Global instance = new Global();
        public List<Wall> walls = new List<Wall>();
        public Player player;
        private Global() { }

        
    }
}
