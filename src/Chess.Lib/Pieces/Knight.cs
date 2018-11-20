using System;
using System.Collections.Generic;

namespace Chess.Lib.Pieces
{
    public class Knight : Piece
    {
        public Knight(Team team, bool hasBeenMoved = false) : base(team, hasBeenMoved)
        {
        }

        public override string ToString() => "Knight";

        public override Piece With(Team? team = null, bool? hasBeenMoved = null) =>
            new Knight(team ?? Team, hasBeenMoved ?? HasBeenMoved);

        public override IEnumerable<Move> GetPossibleMoves(Point current, Board board)
        {
            var numbersToCheck = new[] {-2, -1, 1, 2};

            foreach (var x in numbersToCheck)
            {
                foreach (var y in numbersToCheck)
                {
                    if (Math.Abs(x) == Math.Abs(y)) continue;
                    var realX = current.X + x;
                    var realY = current.Y + y;
                    if (realX < 0 || realX > 7 || realY < 0 || realY > 7) continue;
                    var tile = board[realX, realY];
                    if (PossibleMovesHelper.IsOccupiedBySameTeam(Team, tile)) break;
                    yield return new Move(realX, realY);
                }
            }
        }
    }
}