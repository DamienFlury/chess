using Chess.Lib.Tiles;

namespace Chess.Lib
{
    public sealed class Board
    {
        public Board(ITile[,] array) => _array = array;

        private readonly ITile[,] _array;

        public ITile this[int a, int b] => _array[a, b];
    }
}