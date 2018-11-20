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
        
        public IEnumerable<Move> GetPossibleMoves(Point current, Board board) => PossibleMovesHelper.GetDiagonalMoves(current, board);
    }
}