using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RandomPowerGates
{
    class MoveManager
    {
        //dočasné kolizní okraje hráče
        Rectangle tempRectangle;
        //metoda volající se při každém pokusu se pohnout do jakéhokoliv směru
        public void Move(KeyboardState keyboardState)
        {
            tempRectangle = Global.instance.player.objectBounds;
            if (keyboardState.IsKeyDown(Keys.W))
            {
                tempRectangle = Global.instance.player.objectBounds;
                tempRectangle.Y -= (int)Global.instance.player.objectSpeed;
                if (!ColisonCheck(tempRectangle))
                    Global.instance.player.position.Y -= Global.instance.player.objectSpeed;
            }
            if (keyboardState.IsKeyDown(Keys.S))
            {
                tempRectangle = Global.instance.player.objectBounds;
                tempRectangle.Y += (int)Global.instance.player.objectSpeed;
                if (!ColisonCheck(tempRectangle))
                    Global.instance.player.position.Y += Global.instance.player.objectSpeed;
            }
            if (keyboardState.IsKeyDown(Keys.A))
            {
                tempRectangle = Global.instance.player.objectBounds;
                tempRectangle.X -= (int)Global.instance.player.objectSpeed;
                if (!ColisonCheck(tempRectangle))
                    Global.instance.player.position.X -= Global.instance.player.objectSpeed;
            }
            if (keyboardState.IsKeyDown(Keys.D))
            {
               tempRectangle = Global.instance.player.objectBounds;
                tempRectangle.X += (int)Global.instance.player.objectSpeed;
                if (!ColisonCheck(tempRectangle))
                    Global.instance.player.position.X += Global.instance.player.objectSpeed;
            }
        }
        //metoda testující jestli došlo ke kolizi
        private bool ColisonCheck(Rectangle rectangle)
        {
#if DEBUG
            if (rectangle.Intersects(Global.instance.wall1.GetWallBounds()) || rectangle.Intersects(Global.instance.wall2.GetWallBounds()) || rectangle.Intersects(Global.instance.wall3.GetWallBounds()))
                return true;
            else
                return false;
#endif
            foreach (Wall w in Global.instance.walls)
            {
                if (rectangle.Intersects(w.GetWallBounds()))
                    return true;
                else
                    return false;
                
            }
            return false;
        }
    }
}
