using Chessboard;
using Chessboard.Enums;

namespace Game
{
    internal class Rook : Piece
    {
        public Rook(Board board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "R";
        }

        private bool CanMove(Position position)
        {
            Piece p = Board.GetPieceByPosition(position);
            return p == null || p.Color != Color;           // can move when the space is free or it has a piece from the opponent.
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] poosibleMov = new bool[Board.Rows, Board.Columns];

            Position pos = new Position(0, 0);

            //Up
            pos.SetPosition(Position.Row - 1, Position.Column);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                poosibleMov[pos.Row, pos.Column] = true;
                if (Board.GetPieceByPosition(pos) != null
                    && Board.GetPieceByPosition(pos).Color != Color)
                {
                    break;
                }
                pos.Row--;
            }

            //Down
            pos.SetPosition(Position.Row + 1, Position.Column);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                poosibleMov[pos.Row, pos.Column] = true;
                if (Board.GetPieceByPosition(pos) != null
                    && Board.GetPieceByPosition(pos).Color != Color)
                {
                    break;
                }
                pos.Row++;
            }

            //Right
            pos.SetPosition(Position.Row, Position.Column + 1);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                poosibleMov[pos.Row, pos.Column] = true;
                if (Board.GetPieceByPosition(pos) != null
                    && Board.GetPieceByPosition(pos).Color != Color)
                {
                    break;
                }
                pos.Column++;
            }

            //Left
            pos.SetPosition(Position.Row, Position.Column - 1);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                poosibleMov[pos.Row, pos.Column] = true;
                if (Board.GetPieceByPosition(pos) != null
                    && Board.GetPieceByPosition(pos).Color != Color)
                {
                    break;
                }
                pos.Column--;
            }

            return poosibleMov;
        }
    }
}
