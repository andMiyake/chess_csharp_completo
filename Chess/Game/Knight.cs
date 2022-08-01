using Chessboard;
using Chessboard.Enums;

namespace Game
{
    internal class Knight : Piece
    {
        public Knight(Board board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "k";
        }

        private bool CanMove(Position pos)
        {
            Piece p = Board.GetPieceByPosition(pos);
            return p == null || p.Color != Color;
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] possibleMov = new bool[Board.Rows, Board.Columns];

            Position pos = new Position(0, 0);

            //Top Left
            pos.SetPosition(Position.Row - 1, Position.Column - 2);
            if (Board.ValidPosition(pos) && CanMove(pos))
                possibleMov[pos.Row, pos.Column] = true;

            //Top Left
            pos.SetPosition(Position.Row - 2, Position.Column - 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
                possibleMov[pos.Row, pos.Column] = true;

            //Top Right
            pos.SetPosition(Position.Row - 2, Position.Column + 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
                possibleMov[pos.Row, pos.Column] = true;

            //Top Right
            pos.SetPosition(Position.Row - 1, Position.Column + 2);
            if (Board.ValidPosition(pos) && CanMove(pos))
                possibleMov[pos.Row, pos.Column] = true;

            //Bottom Right
            pos.SetPosition(Position.Row + 1, Position.Column + 2);
            if (Board.ValidPosition(pos) && CanMove(pos))
                possibleMov[pos.Row, pos.Column] = true;

            //Bottom Right
            pos.SetPosition(Position.Row + 2, Position.Column + 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
                possibleMov[pos.Row, pos.Column] = true;

            //Bottom Left
            pos.SetPosition(Position.Row + 2, Position.Column - 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
                possibleMov[pos.Row, pos.Column] = true;

            //Bottom Left
            pos.SetPosition(Position.Row + 1, Position.Column - 2);
            if (Board.ValidPosition(pos) && CanMove(pos))
                possibleMov[pos.Row, pos.Column] = true;

            return possibleMov;
        }
    }
}
