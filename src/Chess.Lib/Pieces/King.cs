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

        public IEnumerable<Move> GetPossibleMoves(Point current, Board board)
        {
            throw new NotImplementedException();
        }


    }
}