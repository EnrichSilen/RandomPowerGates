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
        List<bool> wallsDetections = new List<bool>();
        List<bool> portalsDetections = new List<bool>();


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

            wallsDetections.Clear();
            //Zdivo
            for (int i = 0; i < Global.instance.walls1.Count; i++)
            {
                if (rectangle.Intersects(Global.instance.walls1[i].objectBounds))
                    //return true;
                    wallsDetections.Add(true);
                else
                    //return false;
                    wallsDetections.Add(false);
            }
            foreach (bool b in wallsDetections)
            {
                if (b)
                    return true;
            }
            wallsDetections.Clear();
            portalsDetections.Clear();
            for (int p = 0; p < Global.instance.portals1.Count; p++)
            {
                if (rectangle.Intersects(Global.instance.portals1[p].objectBounds))
                    //return true;
                    portalsDetections.Add(true);
                else
                    //return false;
                    portalsDetections.Add(false);
            }
            foreach (bool b in portalsDetections)
            {
                if (b)
                { 
                    Global.instance.mapManager.Warp();
                }
            }
            portalsDetections.Clear();
            return false;

        }
    }
}
