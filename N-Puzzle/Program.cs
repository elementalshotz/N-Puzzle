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

            if (size < 4)                   //When the size is less than 4 we will use 4x4
            {
                board = new Board();
            }
            else
            {                               //Else use the size that has been as an input from the user
                board = new Board(size);
            }

            //board = new Board(size);
            board.DrawBoard();              //Prints the board on screen

            ConsoleKeyInfo keyInfo;         //Used to read keys in console

            do
            {
                keyInfo = Console.ReadKey(true); //ReadKey(true) gör så att vi kan läsa knapp tryck utan att det syns vilken

                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    board.Move(Board.Direction.Up);
                }
                else if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    board.Move(Board.Direction.Left);
                }
                else if (keyInfo.Key == ConsoleKey.RightArrow)
                {
                    board.Move(Board.Direction.Right);
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    board.Move(Board.Direction.Down);
                }
                
                board.DrawBoard();
            } while (!board.Solved());

            Console.WriteLine("Congatulations, you have solved it!");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey(true);
        }
    }
}
