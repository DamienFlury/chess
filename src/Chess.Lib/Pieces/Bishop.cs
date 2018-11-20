using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess.Lib.Pieces
{
    public sealed class Bishop : IPiece
    {
        public Bishop(Team team, bool hasBeenMoved = false) => (Team, HasBeenMoved) = (team, hasBeenMoved);

        public override string ToString() => "Bishop";

        public Team Team { get; }
        public bool HasBeenMoved { get; }
        public IPiece With(Team? team = null, bool? hasBeenMoved = null) => new Bishop(team ?? Team, hasBeenMoved ?? HasBeenMoved);

        public IEnumerable<Move> GetPossibleMoves(Point current, Board board) => PossibleMovesHelper.GetDiagonalMoves(current, board);
    }
}