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
        List<bool> detections = new List<bool>();


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
            //>

            detections.Clear();
            //verze 1
            for (int i = 0; i < Global.instance.walls.Count; i++)
            {
                if (rectangle.Intersects(Global.instance.walls[i].objectBounds))
                    //return true;
                    detections.Add(true);
                else
                    //return false;
                    detections.Add(false);
            }
            //verze2
            foreach (bool b in detections)
            {
                if (b)
                    return true;
            }
            detections.Clear();
            return false;

        }
    }
}
