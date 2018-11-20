using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Chess.Lib.Pieces
{
    public sealed class Queen : IPiece
    {
        public Queen(Team team, bool hasBeenMoved = false) => (Team, HasBeenMoved) = (team, hasBeenMoved);

        public override string ToString() => "Queen";

        public Team Team { get; }
        public bool HasBeenMoved { get; }
        public IPiece With(Team? team = null, bool? hasBeenMoved = null) => new Queen(team ?? Team, hasBeenMoved ?? HasBeenMoved);

        public IEnumerable<Move> GetPossibleMoves(Point current, Board board) => PossibleMovesHelper
            .GetDiagonalMoves(current, board).Concat(PossibleMovesHelper.GetStraightMoves(current, board));

    }
}