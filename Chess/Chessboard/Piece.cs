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

        public bool PossibleMovementExists()
        {
            bool[,] array = PossibleMovements();
            for (int i = 0; i < Board.Rows; i++)
            {
                for (int j = 0; j < Board.Columns; j++)
                {
                    if (array[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool CanMoveTo(Position pos)
        {
            return PossibleMovements()[pos.Row, pos.Column];
        }

        public abstract bool[,] PossibleMovements();
    }
}
