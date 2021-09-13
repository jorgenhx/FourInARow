using System;
using System.Text;

namespace FourInARow
{
    class Program
    {
        static void Main(string[] args)
        {
            bool quit = false;
            Console.SetWindowSize(60, 32);
            Console.Title = "Four in a Row";
            Console.CursorVisible = false;
            Console.SetBufferSize(60, 32);
            Console.OutputEncoding = new UnicodeEncoding();

            while(!quit)
            {
                TitleScreen titleScreen = new TitleScreen();
                titleScreen.Draw();
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Escape)
                {
                    quit = true;
                    continue;
                }
                Game game = new Game();
                game.Loop();

            }
        }
    }
}
