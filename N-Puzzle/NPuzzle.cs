using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Puzzle
{
    class NPuzzle : Board
    {
        public NPuzzle() : base() { }
        public NPuzzle(int x) : base(x) { }

        public bool Solved()
        {
            bool isSolved = false;                          //Creates two variables one used for statements, one used for filling the matrix that we use to check against
            int x = 2, i = 0, j = 0;
            Tile[,] tile = createSolvedBoard(i, j);  //The temporary filled solved matrix that is used for checking if the GameMatrix is solve

            for (i = 0; i < Dimension; i++)
            {
                for (j = 0; j < Dimension; j++)
                {
                    if (GameMatrix[i, j].Value == tile[i, j].Value && GameMatrix[Dimension - 1, Dimension - 1].Value == 0)
                    {
                        isSolved = true;
                    }
                    else if (GameMatrix[i, j].Value != tile[i, j].Value && GameMatrix[Dimension - 1, Dimension - 1].Value == 0)
                    {
                        isSolved = false;
                        break;
                    }
                }

                if (isSolved == false)
                    break;
            }

            return isSolved;                        //Returns the value from the loop that used to check the solved against a pre solved version of the board.
        }

        public Tile[,] createSolvedBoard(int i, int j)
        {
            Tile[,] tile = new Tile[Dimension, Dimension];
            int x = 1;

            for (i = 0; i < Dimension; i++)             //Used with x to fill the tile matrix where the last position in the board is 0
            {
                for (j = 0; j < Dimension; j++)
                {
                    if (i == Dimension - 1 && j == Dimension - 1)
                    {
                        tile[i, j] = new Tile(0);
                    }
                    else
                    {
                        tile[i, j] = new Tile(x);
                        x++;
                    }
                }
            }

            return tile;
        }
    }
}
