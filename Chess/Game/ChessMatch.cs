using System;
using Chessboard;
using Chessboard.Enums;

namespace Game
{
    internal class ChessMatch
    {
        public Board Board { get; private set; }
        private int turn;
        private Color currentPlayer;
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
