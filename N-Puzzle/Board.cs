    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Puzzle
{
    class Board
    {
        protected Tile[,] GameMatrix;
        protected int Dimension;
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

            FillBoard(GameMatrix);                        //Fill the board with numbers and shuffle
            ShuffleBoard();
        }

        private void ShuffleBoard()             //Shuffle the board using Random and a variable that is used to loop ((Dimension^2)*2)-1
        {
            Random random = new Random();
            int numberOfSwaps = 1000, direction = 0;

            for (int counter = 0; counter < numberOfSwaps; counter++)           //Loop (Dimension^2)*2 - 1 times
            {
                direction = random.Next(4) + 1;
                
                switch (direction)
                {
                    case 1:
                        Move(Board.Direction.Up);
                        break;
                    case 2:
                        Move(Board.Direction.Down);
                        break;
                    case 3:
                        Move(Board.Direction.Right);
                        break;
                    case 4:
                        Move(Board.Direction.Left);
                        break;
                }
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
                        pos.Update(x, y);
                        oldPos.Update(x, y);
                    }
                }
            }
        }

        public void DrawBoard()
        {
            ClearBoard();                       //Clears the board

            for (int i =0; i < Dimension; i++)                 //Prints each row and column in the console as well as blankspace for 0-value location
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

        private void ClearBoard()
        {
            Console.Clear();                //Clears the console(completely removing the board from the console)
        }

        protected void FillBoard(Tile[,] boardToFill)
        {
            int x = 1;

            for (int i = 0; i < Dimension; i++)         //Fills the board(GameMatrix) with numbers as well as last position 
            {
                for (int j = 0; j < Dimension; j++)
                {
                    if (i == Dimension - 1 && j == Dimension - 1)
                    {
                        boardToFill[i, j] = new Tile(0);
                    }
                    else
                    {
                        boardToFill[i, j] = new Tile(x);
                        x++;
                    }
                }
            }
        }

        public void Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                    if (pos.X > 0)
                        pos.Update(pos.X - 1, pos.Y);
                    break;
                case Direction.Right:
                    if (pos.X < Dimension - 1)
                        pos.Update(pos.X + 1, pos.Y);
                    break;
                case Direction.Up:
                    if (pos.Y > 0)
                        pos.Update(pos.X, pos.Y - 1);
                    break;
                case Direction.Down:
                    if (pos.Y < Dimension - 1)
                        pos.Update(pos.X, pos.Y + 1);
                    break;
            }

            Swap(oldPos, pos);
            oldPos.Update(pos.X, pos.Y);
        }


        public void Swap(Position oldPosition, Position newPos)        //Swapps the old position with the new position(moves the space one square in selected direction)
        {
            Tile temp = GameMatrix[oldPosition.Y, oldPosition.X];
            GameMatrix[oldPosition.Y, oldPosition.X] = GameMatrix[newPos.Y, newPos.X];
            GameMatrix[newPos.Y, newPos.X] = temp;
        }
    }
}
