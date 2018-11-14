using System;
using System.Collections.Generic;

namespace Chess.Lib.Pieces
{
    public sealed class Bishop : IPiece
    {
        public Bishop(Team team) => Team = team;

        public override string ToString() => "Bishop";
        public Team Team { get; }

        public IEnumerable<Move> PossibleMoves
        {
            get
            {
                for (var i = 1; i < 8; i++)
                {
                    yield return new Move(i, i);
                    yield return new Move(i, -i);
                    yield return new Move(-i, i);
                    yield return new Move(-i, -i);
                }
            }
        }
    }
}