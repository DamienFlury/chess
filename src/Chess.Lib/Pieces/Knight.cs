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

        public IEnumerable<Move> GetPossibleMoves(Point current, Board board) =>
            PossibleMovesHelper.GetDiagonalMoves(current, board);

    }
}