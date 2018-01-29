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
        Position pos, oldPos;
        public enum Direction { Up, Down, Right, Left }

        public Board() : this(4) //If there is no parameter input or input is smaller than 4 default to 4x4
        {

        }

        public Board(int n) //Default to parameter input from user where input is bigger than 4
        {
            GameMatrix = new Tile[n, n];          //Set size n,n and Dimension to n as well as marking the last position of the board
            Dimension = n;

            pos = new Position(n - 1, n - 1);
            oldPos = new Position(n - 1, n - 1);

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

            Position firstTile, secondTile;

            for (int counter = 0; counter < numberOfSwaps; counter++)           //Loop (Dimension^2)*2 - 1 times
            {
                firstTile = new Position(random.Next(Dimension), random.Next(Dimension));
                secondTile = new Position(random.Next(Dimension), random.Next(Dimension));
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
                        pos.update(x, y);
                        oldPos.update(x, y);
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
                    }
                    else
                    {
                        GameMatrix[i, j] = new Tile(x);
                        x++;
                    }
                }
            }
        }

        public bool Solved()
        {
            bool isSolved = false;                          //Creates two variables one used for statements, one used for filling the matrix that we use to check against
            int x = 2, i = 0, j = 0;
            Tile[,] tile = createSolvedBoard(i,j);  //The temporary filled solved matrix that is used for checking if the GameMatrix is solve
            
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

        public void Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                    if (pos.X > 0)
                        pos.update(pos.X - 1, pos.Y);
                    break;
                case Direction.Right:
                    if (pos.X < Dimension - 1)
                        pos.update(pos.X + 1, pos.Y);
                    break;
                case Direction.Up:
                    if (pos.Y > 0)
                        pos.update(pos.X, pos.Y - 1);
                    break;
                case Direction.Down:
                    if (pos.Y < Dimension - 1)
                        pos.update(pos.X, pos.Y + 1);
                    break;
            }

            Swap(oldPos, pos);
            oldPos.update(pos.X, pos.Y);
        }
    }
}
