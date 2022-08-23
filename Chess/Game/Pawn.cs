using Chessboard;
using Chessboard.Enums;

namespace Game
{
    internal class Pawn : Piece
    {
        private ChessMatch match;
        public Pawn(Board board, Color color, ChessMatch match) : base(board, color)
        {
            this.match = match;
        }

        public override string ToString()
        {
            return "P";
        }

        private bool EnemyExists(Position pos)
        {
            Piece p = Board.GetPieceByPosition(pos);
            return p != null && p.Color != Color;
        }

        private bool Free(Position pos)
        {
            return Board.GetPieceByPosition(pos) == null;
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] possibleMov = new bool[Board.Rows, Board.Columns];

            Position pos = new Position(0, 0);

            if (Color == Color.White)
            {
                //Moving up
                pos.SetPosition(Position.Row - 1, Position.Column);
                if (Board.ValidPosition(pos) && Free(pos))
                {
                    possibleMov[pos.Row, pos.Column] = true;
                }
                pos.SetPosition(Position.Row - 2, Position.Column);
                if (Board.ValidPosition(pos) && Free(pos) && MovementQty == 0)
                {
                    possibleMov[pos.Row, pos.Column] = true;
                }
                //Capturing
                pos.SetPosition(Position.Row - 1, Position.Column - 1);
                if (Board.ValidPosition(pos) && EnemyExists(pos))
                {
                    possibleMov[pos.Row, pos.Column] = true;
                }
                pos.SetPosition(Position.Row - 1, Position.Column + 1);
                if (Board.ValidPosition(pos) && EnemyExists(pos))
                {
                    possibleMov[pos.Row, pos.Column] = true;
                }

                // #specialmove En passant
                if (Position.Row == 3)
                {
                    Position left = new Position(Position.Row, Position.Column - 1);
                    if (Board.ValidPosition(left) && EnemyExists(left) && Board.GetPieceByPosition(left) == match.VulnerableEnPassant)
                    {
                        possibleMov[left.Row - 1, left.Column] = true;
                    }
                    Position right = new Position(Position.Row, Position.Column + 1);
                    if (Board.ValidPosition(right) && EnemyExists(right) && Board.GetPieceByPosition(right) == match.VulnerableEnPassant)
                    {
                        possibleMov[right.Row - 1, right.Column] = true;
                    }
                }
            }
            else
            {
                //Moving down
                pos.SetPosition(Position.Row + 1, Position.Column);
                if (Board.ValidPosition(pos) && Free(pos))
                {
                    possibleMov[pos.Row, pos.Column] = true;
                }
                pos.SetPosition(Position.Row + 2, Position.Column);
                if (Board.ValidPosition(pos) && Free(pos) && MovementQty == 0)
                {
                    possibleMov[pos.Row, pos.Column] = true;
                }
                //Capturing
                pos.SetPosition(Position.Row + 1, Position.Column - 1);
                if (Board.ValidPosition(pos) && EnemyExists(pos))
                {
                    possibleMov[pos.Row, pos.Column] = true;
                }
                pos.SetPosition(Position.Row + 1, Position.Column + 1);
                if (Board.ValidPosition(pos) && EnemyExists(pos))
                {
                    possibleMov[pos.Row, pos.Column] = true;
                }

                // #specialmove En passant
                if (Position.Row == 4)
                {
                    Position left = new Position(Position.Row, Position.Column - 1);
                    if (Board.ValidPosition(left) && EnemyExists(left) && Board.GetPieceByPosition(left) == match.VulnerableEnPassant)
                    {
                        possibleMov[left.Row + 1, left.Column] = true;
                    }
                    Position right = new Position(Position.Row, Position.Column + 1);
                    if (Board.ValidPosition(right) && EnemyExists(right) && Board.GetPieceByPosition(right) == match.VulnerableEnPassant)
                    {
                        possibleMov[right.Row + 1, right.Column] = true;
                    }
                }
            }

            return possibleMov;
        }
    }
}
