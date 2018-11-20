using System;
using System.Collections.Generic;

namespace Chess.Lib.Pieces
{
    public class Knight : IPiece
    {
        public Knight(Team team) => Team = team;


        public override string ToString() => "Knight";

        public Team Team { get; }

        public IEnumerable<Move> GetPossibleMoves(Point current, Board board)
        {
            var numbersToCheck = new[] {-2, -1, 1, 2};

            foreach (var x in numbersToCheck)
            {
                foreach (var y in numbersToCheck)
                {
                    if (Math.Abs(x) == Math.Abs(y)) continue;
                    var realX = current.X + x;
                    var realY = current.Y + y;
                    if(realX < 0 || realX > 7 || realY < 0 || realY > 7) continue;
                    var tile = board[realX, realY];
                    if (PossibleMovesHelper.IsOccupiedBySameTeam(Team, tile)) break;
                    yield return new Move(realX, realY);
                }
            }
        }
    }
}