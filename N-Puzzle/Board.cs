using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Puzzle
{
    class Board
    {
        Tile[,] GameMatrix;
        int Dimension;
        public Position pos = new Position();
        public Position oldPos = new Position();
        public enum Direction { Up, Down, Left, Right }; //TODO: do something with enum

        public Board() : this(4) //If there is no parameter input or input is smaller than 4 default to 4x4
        {

        }

        public Board(int n) //Default to parameter input from user where input is bigger than 4
        {
            GameMatrix = new Tile[n, n];          //Set size n,n and Dimension to n as well as marking the last position of the board
            Dimension = n;

            pos.X = pos.Y = n - 1;
            oldPos.X = oldPos.Y = n - 1;

            FillBoard();                        //Fill the board with numbers and shuffle
            ShuffleBoard();
        }

        public int GetSize()
        {
            return Dimension;                   //Return the number of columns/rows there is in the board.
        }

        private void ShuffleBoard()             //Shuffle the board using Random and a variable that is used to loop so many times
        {
            Random random = new Random();
            int numberOfSwaps = Dimension * Dimension * 2 - 1;

            Position firstTile = new Position(), secondTile = new Position();

            for (int counter = 0; counter < numberOfSwaps; counter++)           //Loop (Dimension^2)*2 - 1 times
            {
                firstTile.X = random.Next(Dimension);
                firstTile.Y = random.Next(Dimension);
                secondTile.X = random.Next(Dimension);
                secondTile.Y = random.Next(Dimension);
                Swap(firstTile, secondTile); //Create 4 random locations 2 on x and 2 on y within 0 to Dimension and swap those
            }

            FindSpace();    //When the loop is done find the space that was swapped using the loop
        }

        private void FindSpace()
        {
            for (int x = 0; x < Dimension; x++)
            {
                for (int y = 0; y < Dimension; y++)
                {
                    if (GameMatrix[y, x].Value == 0)
                    {
                        pos.X = oldPos.X = x;       //When space is found store it in a position x and y which is used to swap when we go somewhere in the board
                        pos.Y = oldPos.Y = y;
                    }
                }
            }
        }

        public void DrawBoard()
        {
            ClearBoard();                       //Clears the board

            for (int i = 0; i < Dimension; i++)                 //Prints each row and column in the console as well as blankspace for 0-value location
            {

                for (int j = 0; j < Dimension; j++)
                {
                    if (GameMatrix[i, j].Value != 0)
                    {
                        Console.Write("{0,-3}{1,-4}", "|", GameMatrix[i, j].Value);
                    }
                    else
                    {
                        Console.Write("{0,-3}{1,-4}", "|", "██");
                    }

                    if (j == Dimension - 1)
                    {
                        Console.Write("|");
                    }
                }
                Console.WriteLine();
            }
        }

        public void Swap(Position oldPosition, Position newPos)        //Swapps the old position with the new position(moves the space one square in selected direction)
        {
            Tile temp = GameMatrix[oldPosition.Y, oldPosition.X];
            GameMatrix[oldPosition.Y, oldPosition.X] = GameMatrix[newPos.Y, newPos.X];
            GameMatrix[newPos.Y, newPos.X] = temp;
        }

        private void ClearBoard()
        {
            Console.Clear();                //Clears the console(completely removing the board from the console)
        }

        private void FillBoard()
        {
            int x = 1;

            for (int i = 0; i < Dimension; i++)         //Fills the board(GameMatrix) with numbers as well as last position 
            {
                for (int j = 0; j < Dimension; j++)
                {
                    if (i == Dimension - 1 && j == Dimension - 1)
                    {
                        GameMatrix[i, j] = new Tile(0);
                    } else {
                        GameMatrix[i, j] = new Tile(x);
                        x++;
                    }
                }
            }
        }

        public void updateOldPos()                  //Updates old position which was used to swap to the new position that the space has
        {
            oldPos.X = pos.X;
            oldPos.Y = pos.Y;
        }

        public bool Solved()
        {
            bool isSolved = false;                          //Creates two variables one used for statements, one used for filling the matrix that we use to check against
            int x = 1, i = 0, j = 0;
            Tile[,] tile = new Tile[Dimension, Dimension];  //The temporary filled solved matrix that is used for checking if the GameMatrix is solved

            for (i = 0; i < Dimension; i++)             //Used with x to fill the tile matrix where the last position in the board is 0
            {
                for (j = 0; j < Dimension; j++)
                {
                    if (i == Dimension-1 && j == Dimension-1)
                    {
                        tile[i, j] = new Tile(0);
                    } else
                    {
                        tile[i, j] = new Tile(x);
                        x++;
                    }
                }
            }

            i = j = 0;
            for  (i = 0; i < Dimension; i++)             //Used to check tile[i,j] against GameMatrix[i,j] and if it is true return true or false if it is false
            {
                for (j = 0; j < Dimension; j++)
                {
                    if (GameMatrix[i,j].Value >= tile[i,j].Value)
                    {
                        isSolved = true;
                    } else
                    {
                        isSolved = false;
                        break;
                    }
                }
            }

            if (GameMatrix[Dimension-1,Dimension-1].Value != 0)
                isSolved = false;

            return isSolved;                        //Returns the value from the loop that used to check the solved against a pre solved version of the board.
        }

        public Position GetOldPosition()        
        {
            return oldPos;                          //Returns the old position to be used in another place
        }

        public Position GetPosition()
        {
            return pos;                             //Returns the position of the 0(space) also to be used in another place.
        }
    }
}
