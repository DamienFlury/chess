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
                for (var i = 1; i < 8; i++)
                {
                    yield return new Move(i, 0);
                    yield return new Move(-i, 0);
                    yield return new Move(0, i);
                    yield return new Move(0, -i);
                }
            }
        }
    }
}