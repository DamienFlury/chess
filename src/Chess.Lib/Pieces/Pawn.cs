using System;
using System.Collections.Generic;
using System.Drawing;

namespace Chess.Lib.Pieces
{
    public sealed class Pawn : IPiece
    {
        public Pawn(Team team, bool hasBeenMoved = false) => (Team, HasBeenMoved) = (team, hasBeenMoved);

        public override string ToString() => "Pawn";

        public Team Team { get; }
        public bool HasBeenMoved { get; }
        public IPiece With(Team? team = null, bool? hasBeenMoved = null) => new Pawn(team ?? Team, hasBeenMoved ?? HasBeenMoved);

        public IEnumerable<Move> GetPossibleMoves(Point current, Board board)
        {
            yield return new Move(0, 1);
            yield return new Move(0, 2);
        }

    }
}