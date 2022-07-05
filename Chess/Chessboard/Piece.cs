﻿using Chessboard.Enums;

namespace Chessboard
{
    internal class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int MovementQty { get; protected set; }
        public Board Board { get; set; }

        public Piece()
        {
        }

        public Piece(Position position, Color color, Board board)
        {
            Position = position;
            Color = color;
            Board = board;
            MovementQty = 0;
        }
    }
}
