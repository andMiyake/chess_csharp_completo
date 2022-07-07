using System;

namespace Chessboard.Exceptions
{
    internal class BoardException : ApplicationException
    {
        public BoardException(string msg) : base(msg)
        {
        }
    }
}
