using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Puzzle
{
    class Controller
    {
        NPuzzle Game;

        public Controller(NPuzzle game)
        {
            Game = game;
        }

        public void Run()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            
            do
            {
                keyInfo = Console.ReadKey(true); //ReadKey(true) gör så att vi kan läsa knapp tryck utan att det syns vilken

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        Game.Move(Board.Direction.Up);
                        break;
                    case ConsoleKey.DownArrow:
                        Game.Move(Board.Direction.Down);
                        break;
                    case ConsoleKey.RightArrow:
                        Game.Move(Board.Direction.Right);
                        break;
                    case ConsoleKey.LeftArrow:
                        Game.Move(Board.Direction.Left);
                        break;
                }

                Game.DrawBoard();
            } while (!Game.Solved());
        }
    }
}
