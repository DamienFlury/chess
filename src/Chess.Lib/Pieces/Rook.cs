using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using Chess.Lib.Tiles;

namespace Chess.Lib.Pieces
{
    public sealed class Rook : Piece
    {
        public Rook(Team team, bool hasBeenMoved = false) : base(team, hasBeenMoved)
        {
        }

        public override string ToString() => "Rook";

        public override Piece With(Team? team = null, bool? hasBeenMoved = null) => new Rook(team ?? Team, hasBeenMoved ?? HasBeenMoved);

        public override IEnumerable<Move> GetPossibleMoves(Point current, Board board) => PossibleMovesHelper.GetStraightMoves(current, board);

    }
}