using System;
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

        public ChessMatch()
        {
            Board = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.White;
            Finished = false;
            PlacePieces();
        }

        public void MakeMoviment(Position origin, Position destination)
        {
            Piece p = Board.RemovePiece(origin);
            p.IncreaseMovementQty();
            Piece capturedPiece = Board.RemovePiece(destination);
            Board.PutPiece(p, destination);
        }

        public void MakePlay(Position origin, Position destination)
        {
            MakeMoviment(origin, destination);
            turn++;
            ChangePlayer();
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
            if (!Board.GetPieceByPosition(origin).CanMoveTo(destination))
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

        private void PlacePieces()
        {
            Board.PutPiece(new Rook(Board, Color.White), new ChessPosition('c', 1).ToArrayPosition());
            Board.PutPiece(new Rook(Board, Color.White), new ChessPosition('c', 2).ToArrayPosition());
            Board.PutPiece(new Rook(Board, Color.White), new ChessPosition('d', 2).ToArrayPosition());
            Board.PutPiece(new Rook(Board, Color.White), new ChessPosition('e', 2).ToArrayPosition());
            Board.PutPiece(new Rook(Board, Color.White), new ChessPosition('e', 1).ToArrayPosition());
            Board.PutPiece(new King(Board, Color.White), new ChessPosition('d', 1).ToArrayPosition());

            Board.PutPiece(new Rook(Board, Color.Black), new ChessPosition('c', 7).ToArrayPosition());
            Board.PutPiece(new Rook(Board, Color.Black), new ChessPosition('c', 8).ToArrayPosition());
            Board.PutPiece(new Rook(Board, Color.Black), new ChessPosition('d', 7).ToArrayPosition());
            Board.PutPiece(new Rook(Board, Color.Black), new ChessPosition('e', 7).ToArrayPosition());
            Board.PutPiece(new Rook(Board, Color.Black), new ChessPosition('e', 8).ToArrayPosition());
            Board.PutPiece(new King(Board, Color.Black), new ChessPosition('d', 8).ToArrayPosition());
        }
    }
}
