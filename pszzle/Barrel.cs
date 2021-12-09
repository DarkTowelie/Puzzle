using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pszzle
{
    class Barrel
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Barrel(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Barrel(Field field)
        {
            X = field.lvlParams[field.lvlNum].xBarrel;
            Y = field.lvlParams[field.lvlNum].yBarrel;
        }

        public bool moveRigth(Field field)
        {
            bool wallExist = field.checkWallExist(X + 1, Y);
            if (X + 1 < field.Width - 1 && !wallExist)
            {
                X++;
                return true;
            }
            return false;
        }

        public bool moveLeft(Field field)
        {
            bool wallExist = field.checkWallExist(X - 1, Y);
            if (X - 1 > 0 && !wallExist)
            {
                X--;
                return true;
            }
            return false;
        }

        public bool moveDown(Field field)
        {
            bool wallExist = field.checkWallExist(X, Y + 1);
            if (Y + 1 < field.Height - 1 && !wallExist)
            {
                Y++;
                return true;
            }
            return false;
        }

        public bool moveUp(Field field)
        {
            bool wallExist = field.checkWallExist(X, Y - 1);
            if (Y - 1 > 0 && !wallExist)
            {
                Y--;
                return true;
            }
            return false;
        }
    }
}
