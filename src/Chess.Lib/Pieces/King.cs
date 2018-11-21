using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Chess.Lib.Tiles;

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

        public bool IsChecked(Point current, Board board)
        {
            for (var x = 0; x < 8; x++)
            {
                for (var y = 0; y < 8; y++)
                {
                    if (!(board[x, y] is OccupiedTile occupiedTile)) continue;
                    var piece = occupiedTile.Piece;
                    if (piece.Team == Team) continue;
                    if (piece.GetPossibleMoves(new Point(x, y), board).Contains(new Move(current.X - x, current.Y - y)))
                        return true;
                }
            }

            return false;
        }
    }
}