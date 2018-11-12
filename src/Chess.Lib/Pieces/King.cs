using System;
using System.Drawing;

namespace Chess.Lib.Pieces
{
    public sealed class King : Piece
    {
        public King(Team team) : base(team)
        {
        }
        
        public override string ToString() => "King";

    }
}