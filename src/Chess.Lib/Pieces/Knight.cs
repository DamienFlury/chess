using System;
using System.Drawing;

namespace Chess.Lib.Pieces
{
    public class Knight : Piece
    {
        public Knight(Team team): base(team)
        {
        }
        
        public override string ToString() => "Knight";

    }
}