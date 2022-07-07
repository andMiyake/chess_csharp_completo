using System;

using Chessboard;
using Chessboard.Enums;
using Chessboard.Exceptions;
using Game;

namespace Chess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //try
            //{
            //    Board board = new Board(8, 8);

            //    board.PutPiece(new Rook(board, Color.Black), new Position(0, 0));
            //    board.PutPiece(new Rook(board, Color.Black), new Position(1, 3));
            //    board.PutPiece(new King(board, Color.Black), new Position(0, 2));

            //    Screen.PrintBoard(board);

            //}
            //catch (BoardException e)
            //{
            //    Console.WriteLine(e.Message);
            //    Console.WriteLine(e.StackTrace);
            //}

            ChessPosition chessPos = new ChessPosition('c', 7);

            Console.WriteLine(chessPos);
            Console.WriteLine(chessPos.ToArrayPosition());

            Console.WriteLine();


        }
    }
}
