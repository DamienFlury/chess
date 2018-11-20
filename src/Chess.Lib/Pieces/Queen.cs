using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Chess.Lib.Pieces
{
    public sealed class Queen : Piece
    {
        public Queen(Team team, bool hasBeenMoved = false) : base(team, hasBeenMoved)
        {
        }

        public override string ToString() => "Queen";

        public override Piece With(Team? team = null, bool? hasBeenMoved = null) => new Queen(team ?? Team, hasBeenMoved ?? HasBeenMoved);

        public override IEnumerable<Move> GetPossibleMoves(Point current, Board board) => PossibleMovesHelper
            .GetDiagonalMoves(current, board).Concat(PossibleMovesHelper.GetStraightMoves(current, board));

    }
}