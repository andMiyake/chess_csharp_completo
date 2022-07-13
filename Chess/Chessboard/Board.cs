using Chessboard.Exceptions;

namespace Chessboard
{
    internal class Board
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        private Piece[,] pieces;

        public Board(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            pieces = new Piece[rows, columns];
        }

        public Piece GetPieceByPosition(int row, int column)
        {
            return pieces[row, column];
        }

        public Piece GetPieceByPosition(Position position)
        {
            return pieces[position.Row, position.Column];
        }

        public void PutPiece(Piece piece, Position position)
        {
            if (PieceExists(position))
            {
                throw new BoardException("There's already a piece in this position.");
            }
            pieces[position.Row, position.Column] = piece;
            piece.Position = position;
        }

        public Piece RemovePiece(Position position)
        {
            if (GetPieceByPosition(position) == null)
            {
                return null;
            }
            Piece aux = GetPieceByPosition(position);
            aux.Position = null;
            pieces[position.Row, position.Column] = null;
            return aux;
        }

        public bool PieceExists(Position position)
        {
            ValidatePosition(position);
            return GetPieceByPosition(position) != null;
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
