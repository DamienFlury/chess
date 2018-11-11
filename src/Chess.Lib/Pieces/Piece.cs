using System;
using System.Drawing;

namespace Chess.Lib.Pieces
{
    /// <summary>
    /// The abstract base class of all pieces.
    /// </summary>
    public abstract class Piece
    {
        protected Piece(ConsoleColor color)
        {
            Color = color;
        }

        public ConsoleColor Color { get; }
        
        public override string ToString() => "Piece";

    }
}