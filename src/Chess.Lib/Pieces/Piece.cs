using System;
using System.Collections.Generic;
using System.Drawing;

namespace Chess.Lib.Pieces
{
    /// <summary>
    /// The interface of all pieces.
    /// </summary>
    public abstract class Piece
    {
        protected Piece(Team team, bool hasBeenMoved = false) => (Team, HasBeenMoved) = (team, hasBeenMoved);
        
        public Team Team { get; }
        public bool HasBeenMoved { get; }
        public abstract Piece With(Team? team = null, bool? hasBeenMoved = null);
        public abstract IEnumerable<Move> GetPossibleMoves(Point current, Board board);
    }
}