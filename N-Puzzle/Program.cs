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

            Controller controller = new Controller(board);
            controller.Run();

            Console.WriteLine("Congatulations, you have solved it!");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey(true);
        }
    }
}
