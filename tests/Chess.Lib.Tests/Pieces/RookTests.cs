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
        public void IsLegalMove_Test()
        {
            
            var game = new Game();
            game = game.Move(new Point(0, 1), new Point(0, 3));

            var piece = (game.Board[0, 0] as OccupiedTile)?.Piece;
            var start = new Point(0, 0);
            var end = new Point(0, 2);
            Assert.True(piece?.IsPossibleMove(start, end, game.Board));
            end = new Point(0, 3);
            Assert.False(piece?.IsPossibleMove(start, end, game.Board));
        }

//        [Fact]
//        public void IsLegalMove_OutOfBoundsTest()
//        {
//            var game = new Game();
//            Assert.False(new Rook(Team.Black).IsPossibleMove(new Point(0, 0), new Point(0, -1), game.Board));
//        }

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