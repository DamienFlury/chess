using System;
using System.Collections.Generic;
using System.Linq;

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

        public bool IsPossibleMove(Point start, Point destination, Board board) => throw new NotImplementedException();

        public bool HasPieceInTheWay(Point currentPosition, Move move, Board board)
        {
            if (!PossibleMoves.Contains(move)) throw new IllegalMoveException("Move not possible");
            var destination = currentPosition + move;
            if(IsOutOfBounds(destination)) throw new IllegalMoveException("Out of bounds");
            
            throw new NotImplementedException();
            
            
        }

        private static bool IsOutOfBounds(Point point) => point.X > 7 || point.Y > 7 || point.X < 0 || point.Y < 0;
    }
}