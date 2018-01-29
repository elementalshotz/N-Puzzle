using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Puzzle
{
    class Position         //Holds the position for x and y
    {
        public int X { get; protected set; }
        public int Y { get; protected set; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Update(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
