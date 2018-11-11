using System;
using System.Drawing;

namespace Chess.Lib.Pieces
{
    public sealed class Bishop : Piece
    {
        public Bishop(ConsoleColor color) : base(color)
        {
        }

        public override string ToString() => "Bishop";
    }
}