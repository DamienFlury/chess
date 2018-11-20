using System;
using System.Collections.Generic;
using System.Drawing;

namespace Chess.Lib.Pieces
{
    public sealed class Pawn : Piece
    {
        public Pawn(Team team, bool hasBeenMoved = false) : base(team, hasBeenMoved)
        {
        }

        public override string ToString() => "Pawn";

        public override Piece With(Team? team = null, bool? hasBeenMoved = null) => new Pawn(team ?? Team, hasBeenMoved ?? HasBeenMoved);

        public override IEnumerable<Move> GetPossibleMoves(Point current, Board board)
        {
            yield return new Move(0, 1);
            yield return new Move(0, 2);
        }

    }
}