using System;
using System.Linq;
using System.Threading;
using Chess.Lib.Pieces;
using Chess.Lib.Tiles;
using Xunit;

namespace Chess.Lib.Tests.Pieces
{
    public class RookTests
    {
        [Fact]
        public void IsLegalMove_Test()
        {
            
            var game = new Game();
            game = game.Move(new Point(0, 1), new Point(0, 3));

            var piece = (game.Board[0, 0] as OccupiedTile)?.Piece;
            var start = new Point(0, 0);
            var end = new Point(0, 2);
            Assert.True(piece.IsPossibleMove(start, end, game.Board));
            end = new Point(0, 3);
            Assert.False(piece.IsPossibleMove(start, end, game.Board));
        }
    }
}