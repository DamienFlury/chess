using System;

namespace Chess.Lib
{
    public class IllegalMoveException : Exception
    {
        public IllegalMoveException(string message) : base(message)
        {
        }
    }
}