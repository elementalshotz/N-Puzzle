using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Puzzle
{
    class Tile
    {
        private int TileValue;      //Holds the value for each tile

        public Tile(int value)
        {
            TileValue = value;      //Sets the value for each tile created
        }

        public int Value {
            get => TileValue;       //returns the value if needed when swapping or comparing
            set => TileValue = value;   //Sets the value of the tile if necessary
        }
    }
}
