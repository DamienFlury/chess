using System;
using System.Collections.Generic;
using System.Drawing;

namespace Chess.Lib.Pieces
{
    /// <summary>
    /// The interface of all pieces.
    /// </summary>
    public interface IPiece
    {
        Team Team { get; }
        int X { get; }
        int Y { get; }
        bool HasBeenMoved { get; }
        IPiece With(Team? team = null, int? x = null, int? y = null, bool? hasBeenMoved = null);
        IEnumerable<Move> GetPossibleMoves(Board board);
    }
}