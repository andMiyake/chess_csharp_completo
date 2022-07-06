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

        public void PutPiece(Piece piece, Position position)
        {
            Pieces[position.Row, position.Column] = piece;
            piece.Position = position; //????????????????????
        }
    }
}
