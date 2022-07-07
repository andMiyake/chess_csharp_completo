using Chessboard.Exceptions;

namespace Chessboard
{
    internal class Board
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        public Piece[,] Pieces { get; private set; }

        public Board(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            Pieces = new Piece[rows, columns];
        }

        public Piece FindPieceByPosition(Position position)
        {
            return Pieces[position.Row, position.Column];
        }

        public void PutPiece(Piece piece, Position position)
        {
            if (PieceExists(position))
            {
                throw new BoardException("There's already a piece in this position.");
            }
            Pieces[position.Row, position.Column] = piece;
            piece.Position = position;
        }

        public bool PieceExists(Position position)
        {
            ValidatePosition(position);
            return FindPieceByPosition(position) != null;
        }

        public bool ValidPosition(Position position)
        {
            if (position.Row < 0 || position.Row >= Rows ||
                position.Column < 0 || position.Column >= Columns)
            {
                return false;
            }
            return true;
        }

        public void ValidatePosition(Position position)
        {
            if (!ValidPosition(position))
            {
                throw new BoardException("Invalid Position!");
            }
        }
    }
}
