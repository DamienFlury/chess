using System;
using System.Drawing;

namespace Chess.Lib.Pieces
{
    public sealed class Queen : Piece
    {
        public Queen(ConsoleColor color) : base(color)
        {
        }
        
        public override string ToString() => "Queen";

    }
}