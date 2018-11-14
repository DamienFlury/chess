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
        IEnumerable<Move> PossibleMoves { get; }
//        bool IsInTheWay(Board board, Move move);
    }
}