using System;
using System.Collections.Generic;
using System.Drawing;

namespace Chess.Lib.Pieces
{
    public sealed class King : IPiece
    {
        public King(Team team)
        {
            Team = team;
        }


        public override string ToString() => "King";

        public Team Team { get; }

        public IEnumerable<Move> PossibleMoves
        {
            get
            {
                for (var y = -1; y <= 1; y++)
                {
                    for (var x = -1; x <= 1; x++)
                    {
                        if (!(x == 0 && y == 0)) yield return new Move(x, y);
                    }
                }
            }
        }
    }
}