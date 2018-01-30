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
            Console.BackgroundColor = ConsoleColor.Black;       //Sets background and foreground color
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Title = "N-Puzzle";
            Console.Clear();

            int size;
            NPuzzle board;
            String input;

            do {
                Console.WriteLine("What size do you want for the puzzle?");    //Tells the user to make an input of a digit
                input = Console.ReadLine();
            } while (!Int32.TryParse(input, out size));                //If it can be parsed we will then compare it to a statement)

            board = new NPuzzle(size);
            board.DrawBoard();              //Prints the board on screen

            ConsoleKeyInfo keyInfo;         //Used to read keys in console

            do
            {
                keyInfo = Console.ReadKey(true); //ReadKey(true) gör så att vi kan läsa knapp tryck utan att det syns vilken

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        board.Move(Board.Direction.Up);
                        break;
                    case ConsoleKey.DownArrow:
                        board.Move(Board.Direction.Down);
                        break;
                    case ConsoleKey.RightArrow:
                        board.Move(Board.Direction.Right);
                        break;
                    case ConsoleKey.LeftArrow:
                        board.Move(Board.Direction.Left);
                        break;
                }
                
                board.DrawBoard();
            } while (!board.Solved());

            Console.WriteLine("Congatulations, you have solved it!");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey(true);
        }
    }
}
