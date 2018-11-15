using System;
using System.Collections.Generic;
using System.Drawing;

namespace Chess.Lib.Pieces
{
    public sealed class King : IPiece
    {
        public King(Team team) => Team = team;


        public override string ToString() => "King";

        public Team Team { get; }

        public IEnumerable<Move> PossibleMoves
        {
            get
            {
                yield return new Move(0, -1);
                yield return new Move(1, -1);
                yield return new Move(1, 0);
                yield return new Move(1, 1);
                yield return new Move(0, 1);
                yield return new Move(-1, 1);
                yield return new Move(-1, 0);
                yield return new Move(-1, -1);
            }
        }

        public bool HasPieceInTheWay(Point currentPosition, Move move, Board board)
        {
            throw new NotImplementedException();
        }
    }
}