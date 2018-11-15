using System;
using System.Collections.Generic;
using System.Drawing;

namespace Chess.Lib.Pieces
{
    public sealed class Queen : IPiece
    {
        public Queen(Team team) => Team = team;

        public override string ToString() => "Queen";

        public Team Team { get; }

        public IEnumerable<Move> PossibleMoves
        {
            get
            {
                for (var i = 1; i < 8; i++)
                {
                    yield return new Move(0, -i);
                    yield return new Move(i, -i);
                    yield return new Move(i, 0);
                    yield return new Move(i, i);
                    yield return new Move(0, i);
                    yield return new Move(-i, i);
                    yield return new Move(-i, 0);
                    yield return new Move(-i, -i);
                }
            }
        }

        public bool HasPieceInTheWay(Point currentPosition, Move move, Board board)
        {
            throw new NotImplementedException();
        }
    }
}