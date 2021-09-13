using System;

namespace FourInARow
{
    class Game
    {
        private int currentPlayer = 1;
        private int column = 3, row = 0;
        private int numberOfMoves = 0;
        private bool markerDropped = false;
        private bool exitLoop = false;
        private Board board = new Board();
        private Graphics graphics = new Graphics();

        public void Loop()
        {
            graphics.DrawBoard();
            graphics.DrawSelectMarker(column, currentPlayer);
            graphics.PlayerText(currentPlayer);
            while (!exitLoop)
            {
                markerDropped = false;
                KeyboardHandler(Console.ReadKey(true));
                if (board.CheckFourInRow(column, row, currentPlayer))
                {
                    graphics.Winner(currentPlayer, numberOfMoves);
                    Console.ReadKey();
                    exitLoop = true;
                }
                if (markerDropped)
                {
                    currentPlayer = currentPlayer == 1 ? 2 : 1;
                    graphics.PlayerText(currentPlayer);
                    graphics.DrawSelectMarker(column, currentPlayer);
                }
                if (numberOfMoves == board.board.GetLength(0) * board.board.GetLength(1))
                {
                    graphics.Winner(0, numberOfMoves);
                    Console.ReadKey();
                    exitLoop = true;
                }
            }
        }
        public void KeyboardHandler(ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                    if (column > 0)
                    {
                        graphics.MoveSelectMarker(column, -1, currentPlayer);
                        column -= 1;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (column < 6)
                    {
                        graphics.MoveSelectMarker(column, 1, currentPlayer);
                        column += 1;
                    }
                    break;
                case ConsoleKey.Spacebar:
                    if (board.board[0, column] == 0)
                    {
                        row = board.DropMarker(column, currentPlayer);
                        graphics.AnimateMarker(column, row, currentPlayer);
                        numberOfMoves++;
                        markerDropped = true;
                    }
                    break;
                case ConsoleKey.Escape:
                    exitLoop = true;
                    break;
            }
        }
    }
}
