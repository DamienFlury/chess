using System.Drawing;

namespace Chess.Lib.Pieces
{
    public sealed class King : Piece
    {
        public King(Color color) : base(color)
        {
        }
        
        public override string ToString() => "King";

    }
}