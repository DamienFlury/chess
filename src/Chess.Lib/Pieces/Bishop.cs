using System;
using System.Drawing;

namespace Chess.Lib.Pieces
{
    public sealed class Bishop : Piece
    {
        public Bishop(Team team) : base(team)
        {
        }

        public override string ToString() => "Bishop";
    }
}