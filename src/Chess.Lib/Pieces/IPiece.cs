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
        bool IsPossibleMove(Point start, Point destination, Board board);
    }
}