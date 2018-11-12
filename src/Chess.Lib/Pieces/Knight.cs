using System;
using System.Collections.Generic;
using System.Drawing;

namespace Chess.Lib.Pieces
{
    public class Knight : IPiece
    {
        public Knight(Team team)
        {
            Team = team;
        }


        public override string ToString() => "Knight";

        public Team Team { get; }

        public IEnumerable<Move> PossibleMoves
        {
            get
            {
                for (var y = -2; y <= 2; y++)
                {
                    for (var x = -2; x <= 2; x++)
                    {
                        if (x == 0 || y == 0 || x == y) continue;
                        yield return new Move(x, y);
                    }
                }
            }
        }
    }
}