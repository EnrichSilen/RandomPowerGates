using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomPowerGates
{
    class DebugManager
    {
        public void PressHandler(KeyboardState keyboardState, ContentManager contentManager)
        {
            if (keyboardState.IsKeyDown(Keys.K))
            {
                Global.instance.mapManager.Warp();
            }
        } 

    }
}
