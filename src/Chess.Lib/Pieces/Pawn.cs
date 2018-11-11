using System;
using System.Drawing;

namespace Chess.Lib.Pieces
{
    public sealed class Pawn : Piece
    {
        public Pawn(ConsoleColor color) : base(color)
        {
        }
        
        public override string ToString() => "Pawn";

    }
}