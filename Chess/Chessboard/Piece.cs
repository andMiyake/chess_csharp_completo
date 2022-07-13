using Chessboard.Enums;

namespace Chessboard
{
    internal abstract class Piece
    {
        public Board Board { get; set; }
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int MovementQty { get; protected set; }


        public Piece(Board board, Color color)
        {
            Board = board;
            Position = null;
            Color = color;
            MovementQty = 0;
        }

        public void IncreaseMovementQty()
        {
            MovementQty++;
        }
    }
}
