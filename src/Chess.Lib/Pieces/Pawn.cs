using System;
using System.Collections.Generic;
using System.Drawing;

namespace Chess.Lib.Pieces
{
    public sealed class Pawn : IPiece
    {
        public Pawn(Team team, int x, int y, bool hasBeenMoved = false) => (Team, X, Y, HasBeenMoved) = (team, x, y, hasBeenMoved);

        public override string ToString() => "Pawn";

        public Team Team { get; }
        public int X { get; }
        public int Y { get; }
        public bool HasBeenMoved { get; }
        public IPiece With(Team? team = null, int? x = null, int? y = null, bool? hasBeenMoved = null) => new Pawn(team ?? Team, x ?? X, y ?? Y, hasBeenMoved ?? HasBeenMoved);

        public IEnumerable<Move> GetPossibleMoves(Board board)
        {
            if (Team == Team.Black)
            {
                yield return new Move(0, 1);
                yield return new Move(0, 2);
            }
            else
            {
                yield return new Move(0, -1);
                yield return new Move(0, -2);
            }
        }

    }
}