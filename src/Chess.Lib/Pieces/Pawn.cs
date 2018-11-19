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

        public IEnumerable<Move> PossibleMoves
        {
            get
            {
                yield return new Move(0, 1);
                yield return new Move(0, 2);
            }
        }

        public bool IsPossibleMove(Point start, Point destination, Board board) => throw new NotImplementedException();
        public IEnumerable<Move> GetPossibleMoves(Point current, Board board)
        {
            throw new NotImplementedException();
        }

        public bool HasPieceInTheWay(Point currentPosition, Move move, Board board)
        {
            throw new NotImplementedException();
        }
    }
}