using System.Drawing;

namespace Chess.Lib.Pieces
{
    public abstract class Piece
    {
        protected Piece(Color color)
        {
            Color = color;
        }

        public Color Color { get; }
    }
}