using System;
using Chessboard;

namespace Chess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Position p;

            p = new Position(3, 4);

            Console.WriteLine("Position: " + p);

            Board board = new Board(8, 8);

        }
    }
}
