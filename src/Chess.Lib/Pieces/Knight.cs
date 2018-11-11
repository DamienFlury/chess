using System;
using System.Drawing;

namespace Chess.Lib.Pieces
{
    public class Knight : Piece
    {
        public Knight(ConsoleColor color): base(color)
        {
        }
        
        public override string ToString() => "Knight";

    }
}