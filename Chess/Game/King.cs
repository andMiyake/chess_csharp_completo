using Chessboard;
using Chessboard.Enums;

namespace Game
{
    internal class King : Piece
    {
        public King(Board board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "K";
        }

        private bool CanMove(Position position)
        {
            Piece p = Board.GetPieceByPosition(position);
            return p == null || p.Color != Color;           //can move when the space is free or it has a piece from the opponent.
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] poosibleMov = new bool[Board.Rows, Board.Columns];

            Position pos = new Position(0, 0);

            //Up
            pos.SetPosition(Position.Row - 1, Position.Column);
            if (Board.ValidPosition(pos) && CanMove(pos))
                poosibleMov[pos.Row, pos.Column] = true;

            //Top Right
            pos.SetPosition(Position.Row - 1, Position.Column + 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
                poosibleMov[pos.Row, pos.Column] = true;

            //Right
            pos.SetPosition(Position.Row, Position.Column + 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
                poosibleMov[pos.Row, pos.Column] = true;

            //Bottom Right
            pos.SetPosition(Position.Row + 1, Position.Column + 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
                poosibleMov[pos.Row, pos.Column] = true;

            //Down
            pos.SetPosition(Position.Row + 1, Position.Column);
            if (Board.ValidPosition(pos) && CanMove(pos))
                poosibleMov[pos.Row, pos.Column] = true;

            //Bottom Left
            pos.SetPosition(Position.Row + 1, Position.Column - 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
                poosibleMov[pos.Row, pos.Column] = true;

            //Left
            pos.SetPosition(Position.Row, Position.Column - 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
                poosibleMov[pos.Row, pos.Column] = true;

            //Top Left
            pos.SetPosition(Position.Row - 1, Position.Column - 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
                poosibleMov[pos.Row, pos.Column] = true;

            return poosibleMov;
        }
    }
}
