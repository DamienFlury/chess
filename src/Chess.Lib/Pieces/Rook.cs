using System;
using System.Collections.Generic;
using System.Drawing;

namespace Chess.Lib.Pieces
{
    public sealed class Rook : IPiece
    {
        public Rook(Team team)
        {
            Team = team;
        }

        public override string ToString() => "Rook";
        public Team Team { get; }

        public IEnumerable<Move> PossibleMoves
        {
            get
            {
                for (var y = -7; y <= 7; y++)
                {
                    for (var x = -7; x <= 7; x++)
                    {
                        if (x == 0 && y == 0) continue;
                        if(x == 0 || y == 0) yield return new Move(x, y);
                    }
                }
            }
        }
    }
}