using System;
using System.Drawing;

namespace Chess.Lib.Pieces
{
    public sealed class King : Piece
    {
        public King(ConsoleColor color) : base(color)
        {
        }
        
        public override string ToString() => "King";

    }
}