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
            int x = 1, i = 0, j = 0;
            Tile[,] solvedBoard = new Tile[Dimension, Dimension];
            FillBoard(solvedBoard);

            for (i = 0; i < Dimension; i++)
            {
                for (j = 0; j < Dimension; j++)
                {
                    if (GameMatrix[i, j].Value == solvedBoard[i, j].Value && GameMatrix[Dimension - 1, Dimension - 1].Value == 0)
                    {
                        isSolved = true;
                        Console.Write(isSolved);
                    }
                    else if (GameMatrix[i, j].Value != solvedBoard[i, j].Value && GameMatrix[Dimension - 1, Dimension - 1].Value == 0)
                    {
                        isSolved = false;
                        Console.Write(isSolved);
                        break;
                    }

                    x++;
                }

                Console.WriteLine();

                if (isSolved == false)
                    break;
            }

            return isSolved;                        //Returns the value from the loop that used to check the solved against a pre solved version of the board.
        }
    }
}
