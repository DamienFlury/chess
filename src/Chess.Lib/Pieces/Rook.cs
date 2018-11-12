using System;
using System.Drawing;

namespace Chess.Lib.Pieces
{
    public sealed class Rook : Piece
    {
        public Rook(Team team) : base(team)
        {
        }
        
        public override string ToString() => "Rook";
    }
}