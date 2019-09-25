using Chess.Lib.Tiles;

namespace Chess.Lib
{
    public sealed class Board
    {
        public Board(ITile[][] array) => Array = array;

        public ITile[][] Array { get; }

        public ITile this[int a, int b] => Array[a][b];
    }
}