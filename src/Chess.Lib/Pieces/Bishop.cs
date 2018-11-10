using System.Drawing;

namespace Chess.Lib.Pieces
{
    public sealed class Bishop : Piece
    {
        public Bishop(Color color) : base(color)
        {
        }

        public override string ToString() => "Bishop";
    }
}