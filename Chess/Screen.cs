using System;
using Chessboard;

namespace Chess
{
    internal class Screen
    {
        public static void PrintBoard(Board board)
        {
            for (int i = 0; i < board.Rows; i++)
            {
                for (int j = 0; j < board.Columns; j++)
                {
                    if (board.Pieces[i, j] == null)
                        Console.Write("- ");
                    else
                        Console.Write(board.Pieces[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
