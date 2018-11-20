using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Chess.Lib.Pieces
{
    public sealed class King : Piece
    {
        public King(Team team, bool hasBeenMoved = false) : base(team, hasBeenMoved)
        {
        }

        public override string ToString() => "King";

        public override Piece With(Team? team = null, bool? hasBeenMoved = null) =>
            new King(team ?? Team, hasBeenMoved ?? HasBeenMoved);

        public override IEnumerable<Move> GetPossibleMoves(Point current, Board board)
        {
            return PossibleMovesHelper.GetStraightMoves(current, board)
                .Concat(PossibleMovesHelper.GetDiagonalMoves(current, board)).Where(move =>
                    move.X == 1 || move.X == -1 || move.Y == 1 || move.Y == -1);
        }
    }
}