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
            try
            {
                ChessMatch match = new ChessMatch();

                while (!match.Finished)
                {
                    Console.Clear();
                    Screen.PrintBoard(match.Board);

                    Console.WriteLine();
                    Console.Write("Origin: ");
                    Position origin = Screen.ReadChessPosition().ToArrayPosition();

                    bool[,] possiblePositions = match.Board.GetPieceByPosition(origin).PossibleMovements();

                    Console.Clear();
                    Screen.PrintBoard(match.Board, possiblePositions);

                    Console.WriteLine();
                    Console.Write("Destination: ");
                    Position destination = Screen.ReadChessPosition().ToArrayPosition();

                    match.MakeMoviment(origin, destination);
                }

                

            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }

            Console.WriteLine();


        }
    }
}
