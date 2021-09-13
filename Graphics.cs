using System;
using System.Threading;

namespace FourInARow
{
    class Graphics
    {
        private readonly char[,] marker = { { '\u0020', '\u2584', '\u2584', '\u2584', '\u2584', '\u0020' },
                                            { '\u2588', '\u2588', '\u2588', '\u2588', '\u2588', '\u2588' },
                                            { '\u2588', '\u2588', '\u2588', '\u2588', '\u2588', '\u2588' },
                                            { '\u0020', '\u2580', '\u2580', '\u2580', '\u2580', '\u0020' } };
        private readonly int offsetX = 2;
        private readonly int offsetY = 6;
        private readonly ConsoleColor boardColor = ConsoleColor.Blue;
        private readonly ConsoleColor backgroundColor = ConsoleColor.Gray;
        private readonly ConsoleColor player1Color = ConsoleColor.Red;
        private readonly ConsoleColor player2Color = ConsoleColor.Yellow;

        public void DrawMarker(int x, int y)
        {
            for (int i = 0; i < marker.GetLength(0); i++)
            {
                Console.SetCursorPosition(x, y + i);
                for (int j = 0; j < marker.GetLength(1); j++)
                {
                    Console.Write(marker[i, j]);
                }
            }
        }
        public void AnimateMarker(int x, int y, int player)
        {
            x = offsetX + 1 + x * 2 + x * marker.GetLength(1);
            Console.BackgroundColor = boardColor;

            for (int i = 0; i <= y; i++)
            {
                Console.ForegroundColor = player == 1 ? player1Color : player2Color;
                DrawMarker(x, offsetY + i * marker.GetLength(0));
                Thread.Sleep(100);
                if (i != y)
                {
                    Console.ForegroundColor = backgroundColor;
                    DrawMarker(x, offsetY + i * marker.GetLength(0));
                }
            }

        }
        public void DrawSelectMarker(int x, int player)
        {
            x = offsetX + 1 + x * 2 + x * marker.GetLength(1);
            int y = offsetY - marker.GetLength(0);

            Console.BackgroundColor = backgroundColor;
            Console.ForegroundColor = player == 1 ? player1Color : player2Color;

            DrawMarker(x, y);
        }
        public void MoveSelectMarker(int x, int direction, int player)
        {
            int _x = offsetX + 1 + x * 2 + x * marker.GetLength(1);
            int y = offsetY - marker.GetLength(0);

            Console.BackgroundColor = backgroundColor;
            Console.ForegroundColor = backgroundColor;
            DrawMarker(_x, y);
            DrawSelectMarker(x+direction, player);
        }
        public void DrawBoard()
        {
            Console.BackgroundColor = backgroundColor;
            Console.Clear();
            Console.BackgroundColor = boardColor;
            for (int i = 0; i < 24; i++)
            {
                Console.SetCursorPosition(offsetX, offsetY + i);
                for (int j = 0; j < 56; j++)
                {
                    Console.Write(' ');
                }
            }
            Console.BackgroundColor = boardColor;
            Console.ForegroundColor = backgroundColor;
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    DrawMarker(offsetX + 1 + i * 2 + i * marker.GetLength(1), offsetY + j * marker.GetLength(0));
                }
            }
        }
        public void PlayerText(int player)
        {
            Console.SetCursorPosition(17, 1);
            Console.BackgroundColor = backgroundColor;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"Player {player}, make your move");
        }
        public void Winner(int player, int moves)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;

            for (int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(offsetX+4, offsetY + 10 + i);
                for (int j = 0; j < 48; j++)
                {
                    if (i == 0 || i == 2) Console.Write('\u2550');
                    else if (i == 1 && (j == 0 || j == 47)) Console.Write('\u2551');
                    else Console.Write(' ');
                }
            }
            Console.SetCursorPosition(offsetX + 4, offsetY + 10);
            Console.Write('\u2554');
            Console.SetCursorPosition(offsetX + 51, offsetY + 10);
            Console.Write('\u2557');
            Console.SetCursorPosition(offsetX + 4, offsetY + 12);
            Console.Write('\u255A');
            Console.SetCursorPosition(offsetX + 51, offsetY + 12);
            Console.Write('\u255D');
            if (player == 0)
            {
                Console.SetCursorPosition(offsetX + 10, offsetY + 11);
                Console.Write($"Oops, no space left. Everyone loses!");
            }
            else
            {
                Console.SetCursorPosition(offsetX + 13, offsetY + 11);
                Console.Write($"Player {player} wins after {moves} moves!");
            }
        }
    }
}
