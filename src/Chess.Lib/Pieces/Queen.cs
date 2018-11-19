using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Chess.Lib.Pieces
{
    public sealed class Queen : IPiece
    {
        public Queen(Team team) => Team = team;

        public override string ToString() => "Queen";

        public Team Team { get; }

        public IEnumerable<Move> GetPossibleMoves(Point current, Board board) => PossibleMovesHelper
            .GetDiagonalMoves(current, board).Concat(PossibleMovesHelper.GetStraightMoves(current, board));

    }
}