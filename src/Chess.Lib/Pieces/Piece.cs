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
        bool HasBeenMoved { get; }
        IPiece With(Team? team = null, bool? hasBeenMoved = null);
        IEnumerable<Move> GetPossibleMoves(Point current, Board board);
    }
}