using System;
using System.Linq;
using System.Threading;
using Chess.Lib.Pieces;
using Chess.Lib.Tiles;
using Newtonsoft.Json.Serialization;
using Xunit;

namespace Chess.Lib.Tests.Pieces
{
    public class RookTests
    {
        [Fact]
        public void GetPossibleMoves_Test()
        {
            var game = new Game();
            var rook = (game.Board[0, 0] as OccupiedTile)?.Piece;
            Assert.NotNull(rook);
            Assert.False(rook.GetPossibleMoves(new Point(0, 0), game.Board).Any());
        }

        [Fact]
        public void GetPossibleMoves_Test2()
        {
            var game = new Game();
            game = game.Move(new Point(0, 1), new Point(0, 2));
            var rook = (game.Board[0, 0] as OccupiedTile)?.Piece;
            Assert.NotNull(rook);
            var possibleMoves = rook.GetPossibleMoves(new Point(0, 0), game.Board).ToArray();

            Assert.Contains(new Move(0, 1), possibleMoves);
            Assert.True(possibleMoves.Count() == 1);
        }
    }
}