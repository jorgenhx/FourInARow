using System;

namespace FourInARow
{
    class Board
    {
        public int[,] board { get; } = { { 0, 0, 0, 0, 0, 0, 0 },
                                         { 0, 0, 0, 0, 0, 0, 0 },
                                         { 0, 0, 0, 0, 0, 0, 0 },
                                         { 0, 0, 0, 0, 0, 0, 0 },
                                         { 0, 0, 0, 0, 0, 0, 0 },
                                         { 0, 0, 0, 0, 0, 0, 0 } };

        public int DropMarker(int x, int player)
        {
            int y = 0;
            for (y = board.GetUpperBound(0); y >= 0; y--)
            {
                if (board[y, x] == 0)
                {
                    board[y, x] = player;
                    break;
                }
            }
            return y;
        }
        public bool CheckFourInRow(int x, int y, int player)
        {
            int _x = x;
            int _y = y;
            int hit = 0;

            // Check horizontal
            for (_x = 0; _x <= board.GetUpperBound(1); _x++) // Right
            {
                if (board[y, _x] == player) hit++;
                else hit = 0;
                if (hit == 4) return true;
            }

            // Check vertical
            hit = 0;
            for (_y = 0; _y <= board.GetUpperBound(0); _y++) // Down
            {
                if (board[_y, x] == player) hit++;
                else hit = 0;
                if (hit == 4) return true;
            }

            // Check diagonal left->right
            hit = 0;
            _x = x;
            for (_y = y; _y >= 0 && _x >= 0; _y--) // Up-left
            {
                if (board[_y, _x--] == player) hit++;
                else break;
            }
            _x = x + 1;
            for (_y = y + 1; _y <= board.GetUpperBound(0) && _x <= board.GetUpperBound(1); _y++) // Down-right
            {
                if (board[_y, _x++] == 1) hit++;
                else break;
            }
            if (hit == 4) return true;

            // Check diagonal right->left
            hit = 0;
            _x = x;
            for (_y = y; _y >= 0 && _x <= board.GetUpperBound(1); _y--) // Up-right
            {
                if (board[_y, _x++] == player) hit++;
                else break;
            }
            _x = x - 1;
            for (_y = y + 1; _y <= board.GetUpperBound(0) && _x >= 0; _y++) // Down-left
            {
                if (board[_y, _x--] == player) hit++;
                else break;
            }
            if (hit == 4) return true;
            else return false;
        }

    }
}
