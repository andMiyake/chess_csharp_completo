using Chessboard;
using Chessboard.Enums;

namespace Game
{
    internal class King : Piece
    {
        private ChessMatch match;

        public King(Board board, Color color, ChessMatch match) : base(board, color)
        {
            this.match = match;
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

        private bool testRookForCastle(Position pos)
        {
            Piece p = Board.GetPieceByPosition(pos);
            return p != null && p is Rook && p.Color == Color && p.MovementQty == 0;
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] possibleMov = new bool[Board.Rows, Board.Columns];

            Position pos = new Position(0, 0);

            //Up
            pos.SetPosition(Position.Row - 1, Position.Column);
            if (Board.ValidPosition(pos) && CanMove(pos))
                possibleMov[pos.Row, pos.Column] = true;

            //Top Right
            pos.SetPosition(Position.Row - 1, Position.Column + 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
                possibleMov[pos.Row, pos.Column] = true;

            //Right
            pos.SetPosition(Position.Row, Position.Column + 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
                possibleMov[pos.Row, pos.Column] = true;

            //Bottom Right
            pos.SetPosition(Position.Row + 1, Position.Column + 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
                possibleMov[pos.Row, pos.Column] = true;

            //Down
            pos.SetPosition(Position.Row + 1, Position.Column);
            if (Board.ValidPosition(pos) && CanMove(pos))
                possibleMov[pos.Row, pos.Column] = true;

            //Bottom Left
            pos.SetPosition(Position.Row + 1, Position.Column - 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
                possibleMov[pos.Row, pos.Column] = true;

            //Left
            pos.SetPosition(Position.Row, Position.Column - 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
                possibleMov[pos.Row, pos.Column] = true;

            //Top Left
            pos.SetPosition(Position.Row - 1, Position.Column - 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
                possibleMov[pos.Row, pos.Column] = true;

            // #specialmove Castle
            if (MovementQty == 0 && !match.check)
            {
                // #specialmove Castle Kingside
                Position posRook1 = new Position(Position.Row, Position.Column + 3);
                if (testRookForCastle(posRook1))
                {
                    Position p1 = new Position(Position.Row, Position.Column + 1);
                    Position p2 = new Position(Position.Row, Position.Column + 2);
                    if (Board.GetPieceByPosition(p1) == null && Board.GetPieceByPosition(p2) == null)
                    {
                        possibleMov[Position.Row, Position.Column + 2] = true;
                    }
                }

                // #specialmove Castle Queenside
                Position posRook2 = new Position(Position.Row, Position.Column - 4);
                if (testRookForCastle(posRook2))
                {
                    Position p1 = new Position(Position.Row, Position.Column - 1);
                    Position p2 = new Position(Position.Row, Position.Column - 2);
                    Position p3 = new Position(Position.Row, Position.Column - 3);
                    if (Board.GetPieceByPosition(p1) == null && Board.GetPieceByPosition(p2) == null && Board.GetPieceByPosition(p3) == null)
                    {
                        possibleMov[Position.Row, Position.Column - 2] = true;
                    }
                }
            }

            return possibleMov;
        }
    }
}
