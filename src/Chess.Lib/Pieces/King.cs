using System.Collections.Generic;
using System.Linq;
using Chess.Lib.Tiles;

namespace Chess.Lib.Pieces
{
    public sealed class King : IPiece
    {
        public King(Team team, int x, int y, bool hasBeenMoved = false) => (Team, X, Y, HasBeenMoved) = (team, x, y, hasBeenMoved);

        public override string ToString() => "King";

        public Team Team { get; }
        public int X { get; }
        public int Y { get; }
        public bool HasBeenMoved { get; }

        public IPiece With(Team? team = null, int? x = null, int? y = null, bool? hasBeenMoved = null) =>
            new King(team ?? Team, x ?? X, y ?? Y, hasBeenMoved ?? HasBeenMoved);

        public IEnumerable<Move> GetPossibleMoves(Board board)
        {
            return PossibleMovesHelper.GetStraightMoves(X, Y, board)
                .Concat(PossibleMovesHelper.GetDiagonalMoves(X, Y, board)).Where(move =>
                    move.X == 1 || move.X == -1 || move.Y == 1 || move.Y == -1);
        }

        public bool IsChecked(Board board)
        {
            for (var x = 0; x < 8; x++)
            {
                for (var y = 0; y < 8; y++)
                {
                    if (!(board[x, y] is OccupiedTile occupiedTile)) continue;
                    var piece = occupiedTile.Piece;
                    if (piece.Team == Team) continue;
                    if (piece.GetPossibleMoves(board).Contains(new Move(X - x, Y - y)))
                        return true;
                }
            }

            return false;
        }

//        public bool IsCheckMate(Point current, Team team, Game game)
//        {
//            if (!IsChecked(current, team, game.Board)) return false;
//            var king = new King(team);
//            
//        }
    }
}