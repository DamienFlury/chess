using System;
using System.Collections.Generic;
using System.Drawing;

namespace Chess.Lib.Pieces
{
    public class Knight : IPiece
    {
        public Knight(Team team) => Team = team;


        public override string ToString() => "Knight";

        public Team Team { get; }

        public IEnumerable<Move> PossibleMoves
        {
            get
            {
                for (var y = -2; y <= 2; y++)
                {
                    for (var x = -2; x <= 2; x++)
                    {
                        if (x == 0 || y == 0 || x == y) continue;
                        yield return new Move(x, y);
                    }
                }
            }
        }

        public bool IsPossibleMove(Point start, Point destination, Board board) => throw new NotImplementedException();
        public IEnumerable<Move> GetPossibleMoves(Point current, Board board)
        {
            throw new NotImplementedException();
        }

        public bool HasPieceInTheWay(Point currentPosition, Move move, Board board) => false;
    }
}