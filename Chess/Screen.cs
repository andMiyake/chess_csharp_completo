using System;
using System.Collections.Generic;
using Chessboard;
using Chessboard.Enums;
using Game;

namespace Chess
{
    internal class Screen
    {
        public static void PrintMatch(ChessMatch match)
        {
            PrintBoard(match.Board);
            Console.WriteLine();
            PrintCapturedPieces(match);
            Console.WriteLine();
            Console.WriteLine("Turn: " + match.turn);
            Console.WriteLine("Waiting move: " + match.currentPlayer);

            if (match.check)
            {
                Console.WriteLine("CHECK!");
            }

        }

        public static void PrintCapturedPieces(ChessMatch match)
        {
            Console.WriteLine("Captured Pieces:");
            Console.Write("White: ");
            PrintGroup(match.GetCapturedPieces(Color.White));
            Console.WriteLine();
            Console.Write("Black: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            PrintGroup(match.GetCapturedPieces(Color.Black));
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }

        public static void PrintGroup(HashSet<Piece> group)
        {
            Console.Write("[");
            foreach (Piece piece in group)
            {
                Console.Write(piece + " ");
            }
            Console.Write("]");
        }

        public static void PrintBoard(Board board)
        {
            ConsoleColor originalBorderColor = Console.BackgroundColor;
            ConsoleColor changedEdgeBackground = ConsoleColor.DarkBlue;

            for (int i = 0; i < board.Rows; i++)
            {
                Console.BackgroundColor = changedEdgeBackground;
                Console.Write(8 - i + " ");
                Console.BackgroundColor = originalBorderColor;

                for (int j = 0; j < board.Columns; j++)
                {
                    PrintPiece(board.GetPieceByPosition(i, j));
                }
                Console.WriteLine();
            }
            Console.BackgroundColor = changedEdgeBackground;
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = originalBorderColor;
        }

        public static void PrintBoard(Board board, bool[,] possiblePositions)
        {
            ConsoleColor originalBackground = Console.BackgroundColor;
            ConsoleColor changedBackgroundEdge = ConsoleColor.DarkBlue;
            ConsoleColor changedBackground = ConsoleColor.DarkGray;

            for (int i = 0; i < board.Rows; i++)
            {
                Console.BackgroundColor = changedBackgroundEdge;
                Console.Write(8 - i + " ");
                Console.BackgroundColor = originalBackground;

                for (int j = 0; j < board.Columns; j++)
                {
                    if (possiblePositions[i, j])
                    {
                        Console.BackgroundColor = changedBackground;
                    }
                    else
                    {
                        Console.BackgroundColor = originalBackground;
                    }
                    PrintPiece(board.GetPieceByPosition(i, j));
                    Console.BackgroundColor = originalBackground;
                }
                Console.WriteLine();
            }
            Console.BackgroundColor = changedBackgroundEdge;
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = originalBackground;
        }

        public static ChessPosition ReadChessPosition()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int row = int.Parse(s[1] + "");
            return new ChessPosition(column, row);
        }

        public static void PrintPiece(Piece piece)
        {
            if (piece == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (piece.Color == Color.White)
                {
                    Console.Write(piece);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(piece);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }
    }
}
