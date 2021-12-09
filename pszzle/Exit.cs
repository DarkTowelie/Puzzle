using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pszzle
{
    class Exit
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Dir dir { get; set; }

        public Exit(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Exit(Field field)
        {
            X = field.lvlParams[field.lvlNum].xExit;
            Y = field.lvlParams[field.lvlNum].yExit;
        }
    }
}
