using System;
using System.Drawing;

namespace Chess.Lib.Pieces
{
    /// <summary>
    /// The abstract base class of all pieces.
    /// </summary>
    public abstract class Piece
    {
        protected Piece(Team team)
        {
            Team = team;
        }

        public Team Team { get; }
        
        public override string ToString() => "Piece";

    }
}