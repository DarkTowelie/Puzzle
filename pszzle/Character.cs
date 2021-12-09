using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pszzle
{ 
    class Character
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Dir dir { get; set; }

        public Character(int x, int y)
        {
            X = x;
            Y = y;
            dir = Dir.STOP;
        }

        public Character(Field field)
        {
            X = field.lvlParams[field.lvlNum].xCharacter;
            Y = field.lvlParams[field.lvlNum].yCharacter;
            dir = Dir.STOP;
        }

        public void moveRigth(Field field, Barrel barrel)
        {
            bool wallExist = field.checkWallExist(X + 1, Y);
            if (X + 1 < field.Width - 1 && !wallExist)
            {
                if(X + 1 == barrel.X && Y == barrel.Y)
                {
                    if(barrel.moveRigth(field))
                    {
                        X++;
                    }
                }
                else
                {
                    X++;
                }
            }
            dir = Dir.STOP;
        }

        public void moveLeft(Field field, Barrel barrel)
        {
            bool wallExist = field.checkWallExist(X - 1, Y);
            if (X - 1 > 0 && !wallExist)
            {
                if (X - 1 == barrel.X && Y == barrel.Y)
                {
                    if (barrel.moveLeft(field))
                    {
                        X--;
                    }
                }
                else
                {
                    X--;
                }
            }
            dir = Dir.STOP;
        }

        public void moveDown(Field field, Barrel barrel)
        {
            bool wallExist = field.checkWallExist(X, Y + 1);
            if (Y + 1 < field.Height - 1 && !wallExist)
            {
                if (Y + 1 == barrel.Y && X == barrel.X)
                {
                    if (barrel.moveDown(field))
                    {
                        Y++;
                    }
                }
                else
                {
                    Y++;
                }
            }
            dir = Dir.STOP;
        }

        public void moveUp(Field field, Barrel barrel)
        {
            bool wallExist = field.checkWallExist(X, Y - 1);
            if (Y - 1 > 0 && !wallExist)
            {
                if (Y - 1 == barrel.Y && X == barrel.X)
                {
                    if (barrel.moveUp(field))
                    {
                        Y--;
                    }
                }
                else
                {
                    Y--;
                }
            }
            dir = Dir.STOP;
        }
    }
}
