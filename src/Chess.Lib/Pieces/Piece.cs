using System.Drawing;

namespace Chess.Lib.Pieces
{
    /// <summary>
    /// The abstract base class of all pieces.
    /// </summary>
    public abstract class Piece
    {
        protected Piece(Color color)
        {
            Color = color;
        }

        public Color Color { get; }
        
        public override string ToString() => "Piece";

    }
}