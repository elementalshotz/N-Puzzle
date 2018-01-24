using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Puzzle
{
    class Program
    { 

        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkCyan;       //Sets background and foreground color
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Title = "N-Puzzle";
            Console.Clear();

            Board board;

            Console.WriteLine("What size do you want for the puzzle?");    //Tells the user to make an input of a digit
            String input = Console.ReadLine();
            int size;
            Int32.TryParse(input, out size);                //If it can be parsed we will then compare it to a statement

            //if (size < 4)                   //When the size is less than 4 we will use 4x4
            //{
            //    board = new Board();
            //}
            //else
            //{                               //Else use the size that has been as an input from the user
            //    board = new Board(size);
            //}

            board = new Board(size);
            board.DrawBoard();              //Prints the board on screen

            ConsoleKeyInfo keyInfo;         //Used to read keys in console
            Position oldPos, pos;           //oldPos and pos is used for coordinating swaps

            do
            {
                keyInfo = Console.ReadKey(true); //ReadKey(true) gör så att vi kan läsa knapp tryck utan att det syns vilken
                oldPos = board.GetOldPosition();
                pos = board.GetPosition();

                if (keyInfo.Key == ConsoleKey.UpArrow && board.pos.Y - 1 > -1)
                {
                    pos.Y = pos.Y - 1;
                    board.Swap(oldPos, pos);
                }
                else if (keyInfo.Key == ConsoleKey.LeftArrow && board.pos.X - 1 > -1)
                {
                    pos.X = pos.X - 1;
                    board.Swap(oldPos, pos);
                }
                else if (keyInfo.Key == ConsoleKey.RightArrow && board.pos.X + 1 < board.GetSize())
                {
                    pos.X = pos.X + 1;
                    board.Swap(oldPos, pos);
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow && board.pos.Y + 1 < board.GetSize())
                {
                    pos.Y = pos.Y + 1;
                    board.Swap(oldPos, pos);
                }

                board.updateOldPos();
                board.DrawBoard();
            } while (board.Solved() != true);

            Console.WriteLine("Congatulations, you have solved it!");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey(true);
        }
    }
}
