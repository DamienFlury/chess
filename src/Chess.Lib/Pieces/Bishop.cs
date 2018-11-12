using System;
using System.Collections.Generic;

namespace Chess.Lib.Pieces
{
    public sealed class Bishop : IPiece
    {
        public Bishop(Team team)
        {
            Team = team;
        }

        public override string ToString() => "Bishop";
        public Team Team { get; }

        public IEnumerable<Move> PossibleMoves
        {
            get
            {
                for (var y = -7; y < 8; y++)
                {
                    for (var x = -7; x < 7; x++)
                    {
                        if (x == 0 && y == 0) continue;
                        if (Math.Abs(x) == Math.Abs(y)) yield return new Move(x, y);
                    }
                }
            }
        }
    }
}