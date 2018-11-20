using System;
using System.Collections.Generic;
using System.Drawing;

namespace Chess.Lib.Pieces
{
    public sealed class Pawn : IPiece
    {
        public Pawn(Team team) => Team = team;

        public override string ToString() => "Pawn";

        public Team Team { get; }

        public IEnumerable<Move> GetPossibleMoves(Point current, Board board)
        {
            yield return new Move(0, 1);
            yield return new Move(0, 2);
        }

    }
}