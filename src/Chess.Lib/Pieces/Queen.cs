using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Chess.Lib.Pieces
{
    public sealed class Queen : IPiece
    {
        public Queen(Team team, int x, int y, bool hasBeenMoved = false) => (Team, X, Y, HasBeenMoved) = (team, x, y, hasBeenMoved);

        public override string ToString() => "Queen";

        public Team Team { get; }
        public int X { get; }
        public int Y { get; }
        public bool HasBeenMoved { get; }
        public IPiece With(Team? team = null, int? x = null, int? y = null, bool? hasBeenMoved = null) => new Queen(team ?? Team, x ?? X, y ?? Y, hasBeenMoved ?? HasBeenMoved);

        public IEnumerable<Move> GetPossibleMoves(Board board) => PossibleMovesHelper
            .GetDiagonalMoves(X, Y, board).Concat(PossibleMovesHelper.GetStraightMoves(X, Y, board));

    }
}