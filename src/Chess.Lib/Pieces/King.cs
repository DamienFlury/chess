using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Chess.Lib.Pieces
{
    public sealed class King : IPiece
    {
        public King(Team team) => Team = team;


        public override string ToString() => "King";

        public Team Team { get; }

        public IEnumerable<Move> GetPossibleMoves(Point current, Board board)
        {
            return PossibleMovesHelper.GetStraightMoves(current, board)
                .Concat(PossibleMovesHelper.GetDiagonalMoves(current, board)).Where(move =>
                    move.X == 1 || move.X == -1 || move.Y == 1 || move.Y == -1);
        }
    }
}