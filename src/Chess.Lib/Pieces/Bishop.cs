using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Chess.Lib.Pieces
{
    public sealed class Bishop : IPiece
    {
        public Bishop(Team team, int x, int y, bool hasBeenMoved = false) =>
            (Team, X, Y, HasBeenMoved) = (team, x, y, hasBeenMoved);

        public override string ToString() => "Bishop";

        public Team Team { get; }
        public int X { get; }
        public int Y { get; }
        public bool HasBeenMoved { get; }

        public IPiece With(Team? team = null, int? x = null, int? y = null, bool? hasBeenMoved = null) =>
            new Bishop(team ?? Team, x ?? X, y ?? Y, hasBeenMoved ?? HasBeenMoved);

        public IEnumerable<Move> GetPossibleMoves(Board board) =>
            PossibleMovesHelper.GetDiagonalMoves(X, Y, board);
    }
}