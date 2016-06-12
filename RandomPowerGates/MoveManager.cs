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
                if (Global.instance.playerDirection != Direction.up)
                    Global.instance.playerDirection = Direction.up;

                tempRectangle = Global.instance.player.objectBounds;
                tempRectangle.Y -= (int)Global.instance.player.objectSpeed;
                if (!ColisonCheck(tempRectangle))
                    Global.instance.player.position.Y -= Global.instance.player.objectSpeed;
            }
            if (keyboardState.IsKeyDown(Keys.S))
            {
                if (Global.instance.playerDirection != Direction.down)
                    Global.instance.playerDirection = Direction.down;

                tempRectangle = Global.instance.player.objectBounds;
                tempRectangle.Y += (int)Global.instance.player.objectSpeed;
                if (!ColisonCheck(tempRectangle))
                    Global.instance.player.position.Y += Global.instance.player.objectSpeed;
            }
            if (keyboardState.IsKeyDown(Keys.A))
            {
                if (Global.instance.playerDirection != Direction.left)
                    Global.instance.playerDirection = Direction.left;

                tempRectangle = Global.instance.player.objectBounds;
                tempRectangle.X -= (int)Global.instance.player.objectSpeed;
                if (!ColisonCheck(tempRectangle))
                    Global.instance.player.position.X -= Global.instance.player.objectSpeed;
            }
            if (keyboardState.IsKeyDown(Keys.D))
            {
                if (Global.instance.playerDirection != Direction.right)
                    Global.instance.playerDirection = Direction.right;

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
            //>
            //udržení hráče na mapě aka dočasné řešení pro vizuální kvalitu
            if (Global.instance.player.position.X < 40)
                Global.instance.player.position.X = 40;
            if (Global.instance.player.position.Y < 40)
                Global.instance.player.position.Y = 40;
            if ((Global.instance.player.position.X + Global.instance.player.GetWidth()) > 1240)
                Global.instance.player.position.X = 1200;
            if ((Global.instance.player.position.Y + Global.instance.player.GetHeight()) > 760)
                Global.instance.player.position.Y = 720;


            //verze 1
            for (int i = 0; i < Global.instance.walls.Count; i++)
            {
                if (rectangle.Intersects(Global.instance.walls[i].objectBounds))
                    return true;
                else
                    return false;
            }
            //verze2
            foreach (Wall w in Global.instance.walls)
            {
                if (rectangle.Intersects(w.objectBounds))
                    return true;
                else
                    return false;

            }
            return false;
        }
    }
}
