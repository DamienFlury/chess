using System;
using System.Drawing;

namespace Chess.Lib.Pieces
{
    public sealed class Pawn : Piece
    {
        public Pawn(Team team) : base(team)
        {
        }
        
        public override string ToString() => "Pawn";

    }
}