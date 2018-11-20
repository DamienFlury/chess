using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess.Lib.Pieces
{
    public sealed class Bishop : Piece
    {
        public Bishop(Team team, bool hasBeenMoved = false) : base(team, hasBeenMoved)
        {
        }

        public override string ToString() => "Bishop";

        public override Piece With(Team? team = null, bool? hasBeenMoved = null) => new Bishop(team ?? Team, hasBeenMoved ?? HasBeenMoved);

        public override IEnumerable<Move> GetPossibleMoves(Point current, Board board) => PossibleMovesHelper.GetDiagonalMoves(current, board);
    }
}