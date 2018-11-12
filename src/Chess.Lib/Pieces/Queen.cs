using System;
using System.Drawing;

namespace Chess.Lib.Pieces
{
    public sealed class Queen : Piece
    {
        public Queen(Team team) : base(team)
        {
        }
        
        public override string ToString() => "Queen";

    }
}