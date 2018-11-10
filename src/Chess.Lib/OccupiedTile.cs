using System;
using Chess.Lib.Pieces;

namespace Chess.Lib
{
    public sealed class OccupiedTile : ITile
    {
        public OccupiedTile(Piece piece)
        {
            piece = piece ?? throw new ArgumentNullException(nameof(piece));
            Piece = piece;
        }
        public Piece Piece { get; }
    }
}