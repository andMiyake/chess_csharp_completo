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
                    try
                    {
                        Console.Clear();
                        Screen.PrintMatch(match);

                        Console.WriteLine();
                        Console.Write("Origin: ");
                        Position origin = Screen.ReadChessPosition().ToArrayPosition();
                        match.ValidateOriginPosition(origin);

                        bool[,] possiblePositions = match.Board.GetPieceByPosition(origin).PossibleMovements();

                        Console.Clear();
                        Screen.PrintBoard(match.Board, possiblePositions);

                        Console.WriteLine();
                        Console.Write("Destination: ");
                        Position destination = Screen.ReadChessPosition().ToArrayPosition();
                        match.ValidateDestinationPosition(origin, destination);

                        match.MakePlay(origin, destination);
                    }
                    catch (BoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }

                }

                Console.Clear();
                Screen.PrintMatch(match);


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
