using System;
using Chess.Lib.Pieces;

namespace Chess.Lib.Tiles
{
    /// <inheritdoc />
    /// <summary>
    /// A tile that is able to include a piece. Immutable.
    /// </summary>
    public sealed class OccupiedTile : ITile
    {
        /// <summary>
        /// Creates a new occupied tile with a piece. The piece can't be null.
        /// </summary>
        /// <param name="piece">No null allowed</param>
        public OccupiedTile(Piece piece) => Piece = piece;
        
        /// <summary>
        /// Holds the piece. Can't be changed.
        /// </summary>
        public Piece Piece { get; }
    }
}