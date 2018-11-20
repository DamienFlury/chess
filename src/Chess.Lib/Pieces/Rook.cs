using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using Chess.Lib.Tiles;

namespace Chess.Lib.Pieces
{
    public sealed class Rook : IPiece
    {
        public Rook(Team team) => Team = team;

        public override string ToString() => "Rook";
        public Team Team { get; }

        public IEnumerable<Move> GetPossibleMoves(Point current, Board board) => PossibleMovesHelper.GetStraightMoves(current, board);
    }
}