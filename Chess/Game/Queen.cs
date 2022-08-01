using Chessboard;
using Chessboard.Enums;

namespace Game
{
    internal class Queen : Piece
    {
        public Queen(Board board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "Q";
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

            //Up
            pos.SetPosition(Position.Row - 1, Position.Column);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                possibleMov[pos.Row, pos.Column] = true;
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
                possibleMov[pos.Row, pos.Column] = true;
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
                possibleMov[pos.Row, pos.Column] = true;
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
                possibleMov[pos.Row, pos.Column] = true;
                if (Board.GetPieceByPosition(pos) != null
                    && Board.GetPieceByPosition(pos).Color != Color)
                {
                    break;
                }
                pos.Column--;
            }

            //Top Left
            pos.SetPosition(Position.Row - 1, Position.Column - 1);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                possibleMov[pos.Row, pos.Column] = true;
                if (Board.GetPieceByPosition(pos) != null
                    && Board.GetPieceByPosition(pos).Color != Color)
                {
                    break;
                }
                pos.SetPosition(pos.Row - 1, pos.Column - 1);
            }

            //Top Right
            pos.SetPosition(Position.Row - 1, Position.Column + 1);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                possibleMov[pos.Row, pos.Column] = true;
                if (Board.GetPieceByPosition(pos) != null
                    && Board.GetPieceByPosition(pos).Color != Color)
                {
                    break;
                }
                pos.SetPosition(pos.Row - 1, pos.Column + 1);
            }

            //Bottom Right
            pos.SetPosition(Position.Row + 1, Position.Column + 1);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                possibleMov[pos.Row, pos.Column] = true;
                if (Board.GetPieceByPosition(pos) != null
                    && Board.GetPieceByPosition(pos).Color != Color)
                {
                    break;
                }
                pos.SetPosition(pos.Row + 1, pos.Column + 1);
            }

            //Bottom Left
            pos.SetPosition(Position.Row + 1, Position.Column - 1);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                possibleMov[pos.Row, pos.Column] = true;
                if (Board.GetPieceByPosition(pos) != null
                    && Board.GetPieceByPosition(pos).Color != Color)
                {
                    break;
                }
                pos.SetPosition(pos.Row + 1, pos.Column - 1);
            }

            return possibleMov;
        }

    }
}
