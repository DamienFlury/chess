using System;
using System.Collections.Generic;

namespace Chess.Lib.Pieces
{
    public class Knight : IPiece
    {
        public Knight(Team team, int x, int y, bool hasBeenMoved = false) => (Team, X, Y, HasBeenMoved) = (team, x, y, hasBeenMoved);

        public override string ToString() => "Knight";

        public Team Team { get; }
        public int X { get; }
        public int Y { get; }
        public bool HasBeenMoved { get; }

        public IPiece With(Team? team = null, int? x = null, int? y = null, bool? hasBeenMoved = null) =>
            new Knight(team ?? Team, x ?? X, y ?? Y, hasBeenMoved ?? HasBeenMoved);

        public IEnumerable<Move> GetPossibleMoves(Board board)
        {
            var numbersToCheck = new[] {-2, -1, 1, 2};

            foreach (var x in numbersToCheck)
            {
                foreach (var y in numbersToCheck)
                {
                    if (Math.Abs(x) == Math.Abs(y)) continue;
                    var realX = Y + x;
                    var realY = Y + y;
                    if (realX < 0 || realX > 7 || realY < 0 || realY > 7) continue;
                    var tile = board[realX, realY];
                    if (PossibleMovesHelper.IsOccupiedBySameTeam(Team, tile)) break;
                    yield return new Move(realX - X, realY - Y);
                }
            }
        }
    }
}