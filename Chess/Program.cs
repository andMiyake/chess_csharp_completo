using System;
using Board;

namespace Chess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Position p;

            p = new Position(3, 4);

            Console.WriteLine("Position: " + p);

        }
    }
}
