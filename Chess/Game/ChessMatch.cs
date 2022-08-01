using System.Collections.Generic;
using Chessboard;
using Chessboard.Enums;
using Chessboard.Exceptions;

namespace Game
{
    internal class ChessMatch
    {
        public Board Board { get; private set; }
        public int turn { get; private set; }
        public Color currentPlayer { get; private set; }
        public bool Finished { get; private set; }
        private HashSet<Piece> ownPiecesList;
        private HashSet<Piece> capturedPiecesList;
        public bool check { get; private set; } //Is or not in check

        public ChessMatch()
        {
            Board = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.White;
            Finished = false;
            check = false;
            ownPiecesList = new HashSet<Piece>();
            capturedPiecesList = new HashSet<Piece>();
            PlacePieces();
        }

        public Piece MakeMoviment(Position origin, Position destination)
        {
            Piece p = Board.RemovePiece(origin);
            p.IncreaseMovementQty();
            Piece capturedPiece = Board.RemovePiece(destination);
            Board.PutPiece(p, destination);

            if (capturedPiece != null)
            {
                capturedPiecesList.Add(capturedPiece);
            }
            return capturedPiece;
        }

        public void UndoMovement(Position origin, Position destination, Piece capturedPiece)
        {
            Piece p = Board.RemovePiece(destination);
            p.DecreaseMovementQty();
            if (capturedPiece != null)
            {
                Board.PutPiece(capturedPiece, destination);
                capturedPiecesList.Remove(capturedPiece);
            }
            Board.PutPiece(p, origin);
        }

        public void MakePlay(Position origin, Position destination)
        {
            Piece capturedPiece = MakeMoviment(origin, destination);

            //********************************
            //********************************
            //Possible way to improve code!!!
            //rather than undoing the movement after doing it,
            //verify if it's possible before and don't allow the user to make it
            //********************************
            //********************************
            //********************************


            if (IsInCheck(currentPlayer))
            {
                UndoMovement(origin, destination, capturedPiece);
                throw new BoardException("You can't put yourself in check!");
            }

            if (IsInCheck(GetOpponentColor(currentPlayer)))
            {
                check = true;
            }
            else
            {
                check = false;
            }

            if (CheckMateTest(GetOpponentColor(currentPlayer)))
            {
                Finished = true;
            }
            else
            {
                turn++;
                ChangePlayer();
            }
        }

        public void ValidateOriginPosition(Position pos)
        {
            if (Board.GetPieceByPosition(pos) == null)
            {
                throw new BoardException("There's no piece in the chosen origin position!");
            }
            if (currentPlayer != Board.GetPieceByPosition(pos).Color)
            {
                throw new BoardException("The chosen origin piece isn't yours!");
            }
            if (!Board.GetPieceByPosition(pos).PossibleMovementExists())
            {
                throw new BoardException("There are no moves possible for the chosen origin piece!");
            }
        }

        public void ValidateDestinationPosition(Position origin, Position destination)
        {
            if (!Board.GetPieceByPosition(origin).PossibleMovement(destination))
            {
                throw new BoardException("Invalid destination position!");
            }
        }

        private void ChangePlayer()
        {
            if (currentPlayer == Color.White)
            {
                currentPlayer = Color.Black;
            }
            else
            {
                currentPlayer = Color.White;
            }
        }

        public HashSet<Piece> GetCapturedPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece piece in capturedPiecesList)
            {
                if (piece.Color == color)
                {
                    aux.Add(piece);
                }
            }
            return aux;
        }

        public HashSet<Piece> InGamePieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece piece in ownPiecesList)
            {
                if (piece.Color == color)
                {
                    aux.Add(piece);
                }
            }
            aux.ExceptWith(GetCapturedPieces(color));
            return aux;
        }

        private Color GetOpponentColor(Color color)
        {
            if (color == Color.White)
            {
                return Color.Black;
            }
            else
            {
                return Color.White;
            }
        }

        private Piece GetKing(Color color)
        {
            foreach (Piece piece in InGamePieces(color))
            {
                if (piece is King)
                {
                    return piece;
                }
            }
            return null;
        }

        public bool IsInCheck(Color color)
        {
            Piece king = GetKing(color);
            if (king == null)
            {
                throw new BoardException("There's no " + color + " king in the board.");
            }

            foreach (Piece piece in InGamePieces(GetOpponentColor(color)))
            {
                //Getting opponent possible movements
                bool[,] array = piece.PossibleMovements();

                //If any of the possible movements can move to the king position
                if (array[king.Position.Row, king.Position.Column])
                {
                    return true;
                }
            }

            return false;
        }

        public bool CheckMateTest(Color color)
        {
            if (!IsInCheck(color))
            {
                return false;
            }

            foreach (Piece piece in InGamePieces(color))
            {
                bool[,] array = piece.PossibleMovements();
                for (int i = 0; i < Board.Rows; i++)
                {
                    for (int j = 0; j < Board.Columns; j++)
                    {
                        if (array[i, j])
                        {
                            Position origin = piece.Position;
                            Position detination = new Position(i, j);
                            Piece capturedPiece = MakeMoviment(origin, detination);
                            bool CheckTest = IsInCheck(color);
                            UndoMovement(origin, detination, capturedPiece);
                            if (!CheckTest)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public void PlaceNewPiece(char column, int row, Piece piece)
        {
            Board.PutPiece(piece, new ChessPosition(column, row).ToArrayPosition());
            ownPiecesList.Add(piece);
        }

        private void PlacePieces()
        {
            //PlaceNewPiece('c', 1, new Rook(Board, Color.White));
            //PlaceNewPiece('c', 2, new Rook(Board, Color.White));
            //PlaceNewPiece('d', 2, new Rook(Board, Color.White));
            //PlaceNewPiece('e', 2, new Rook(Board, Color.White));
            //PlaceNewPiece('e', 1, new Rook(Board, Color.White));
            //PlaceNewPiece('d', 1, new King(Board, Color.White));

            //PlaceNewPiece('c', 7, new Rook(Board, Color.Black));
            //PlaceNewPiece('c', 8, new Rook(Board, Color.Black));
            //PlaceNewPiece('d', 7, new Rook(Board, Color.Black));
            //PlaceNewPiece('e', 7, new Rook(Board, Color.Black));
            //PlaceNewPiece('e', 8, new Rook(Board, Color.Black));
            //PlaceNewPiece('d', 8, new King(Board, Color.Black));

            //--
            //PlaceNewPiece('c', 1, new Rook(Board, Color.White));
            //PlaceNewPiece('d', 1, new King(Board, Color.White));
            //PlaceNewPiece('h', 7, new Rook(Board, Color.White));

            //PlaceNewPiece('a', 8, new King(Board, Color.Black));
            //PlaceNewPiece('b', 8, new Rook(Board, Color.Black));

            PlaceNewPiece('a', 1, new Rook(Board, Color.White));
            PlaceNewPiece('b', 1, new Knight(Board, Color.White));
            PlaceNewPiece('c', 1, new Bishop(Board, Color.White));
            PlaceNewPiece('d', 1, new Queen(Board, Color.White));
            PlaceNewPiece('e', 1, new King(Board, Color.White));
            PlaceNewPiece('f', 1, new Bishop(Board, Color.White));
            PlaceNewPiece('g', 1, new Knight(Board, Color.White));
            PlaceNewPiece('h', 1, new Rook(Board, Color.White));
            PlaceNewPiece('a', 2, new Pawn(Board, Color.White));
            PlaceNewPiece('b', 2, new Pawn(Board, Color.White));
            PlaceNewPiece('c', 2, new Pawn(Board, Color.White));
            PlaceNewPiece('d', 2, new Pawn(Board, Color.White));
            PlaceNewPiece('e', 2, new Pawn(Board, Color.White));
            PlaceNewPiece('f', 2, new Pawn(Board, Color.White));
            PlaceNewPiece('g', 2, new Pawn(Board, Color.White));
            PlaceNewPiece('h', 2, new Pawn(Board, Color.White));

            PlaceNewPiece('a', 8, new Rook(Board, Color.Black));
            PlaceNewPiece('b', 8, new Knight(Board, Color.Black));
            PlaceNewPiece('c', 8, new Bishop(Board, Color.Black));
            PlaceNewPiece('d', 8, new Queen(Board, Color.Black));
            PlaceNewPiece('e', 8, new King(Board, Color.Black));
            PlaceNewPiece('f', 8, new Bishop(Board, Color.Black));
            PlaceNewPiece('g', 8, new Knight(Board, Color.Black));
            PlaceNewPiece('h', 8, new Rook(Board, Color.Black));
            PlaceNewPiece('a', 7, new Pawn(Board, Color.Black));
            PlaceNewPiece('b', 7, new Pawn(Board, Color.Black));
            PlaceNewPiece('c', 7, new Pawn(Board, Color.Black));
            PlaceNewPiece('d', 7, new Pawn(Board, Color.Black));
            PlaceNewPiece('e', 7, new Pawn(Board, Color.Black));
            PlaceNewPiece('f', 7, new Pawn(Board, Color.Black));
            PlaceNewPiece('g', 7, new Pawn(Board, Color.Black));
            PlaceNewPiece('h', 7, new Pawn(Board, Color.Black));
        }
    }
}
