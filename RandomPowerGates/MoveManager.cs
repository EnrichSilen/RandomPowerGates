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
        public enum MoveDirection
        {
            up,
            down,
            left,
            right
        }
        Rectangle temp;
        public void Move(KeyboardState keyboardState)
        {
            temp = Global.instance.player.objectBounds;
            if (keyboardState.IsKeyDown(Keys.W))
            {
                //temp = Global.instance.player.objectBounds;
                temp.Y -= (int)Global.instance.player.objectSpeed;
                if (!ColisonCheck(temp))
                    Global.instance.player.position.Y -= Global.instance.player.objectSpeed;
            }
            if (keyboardState.IsKeyDown(Keys.S))
            {
                //temp = Global.instance.player.objectBounds;
                temp.Y += (int)Global.instance.player.objectSpeed;
                if (!ColisonCheck(temp))
                    Global.instance.player.position.Y += Global.instance.player.objectSpeed;
            }
            if (keyboardState.IsKeyDown(Keys.A))
            {
                //temp = Global.instance.player.objectBounds;
                temp.X -= (int)Global.instance.player.objectSpeed;
                if (!ColisonCheck(temp))
                    Global.instance.player.position.X -= Global.instance.player.objectSpeed;
            }
            if (keyboardState.IsKeyDown(Keys.D))
            {
               //temp = Global.instance.player.objectBounds;
                temp.X += (int)Global.instance.player.objectSpeed;
                if (!ColisonCheck(temp))
                    Global.instance.player.position.X += Global.instance.player.objectSpeed;
            }

        }

        private bool ColisonCheck(Rectangle rectangle)
        {
            foreach (var i in Global.instance.walls)
            {
                if(rectangle.Intersects(i.objectBounds))
                    return true;
                else
                    return false;
            }
            return false;
        }

    }
}
