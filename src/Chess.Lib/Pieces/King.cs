using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Chess.Lib.Pieces
{
    public sealed class King : IPiece
    {
        public King(Team team, bool hasBeenMoved = false) => (Team, HasBeenMoved) = (team, hasBeenMoved);

        public override string ToString() => "King";

        public Team Team { get; }
        public bool HasBeenMoved { get; }

        public IPiece With(Team? team = null, bool? hasBeenMoved = null) =>
            new King(team ?? Team, hasBeenMoved ?? HasBeenMoved);

        public IEnumerable<Move> GetPossibleMoves(Point current, Board board)
        {
            return PossibleMovesHelper.GetStraightMoves(current, board)
                .Concat(PossibleMovesHelper.GetDiagonalMoves(current, board)).Where(move =>
                    move.X == 1 || move.X == -1 || move.Y == 1 || move.Y == -1);
        }
    }
}