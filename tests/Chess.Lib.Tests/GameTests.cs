using System;
using Chess.Lib.Pieces;
using Chess.Lib.Tiles;
using Xunit;

namespace Chess.Lib.Tests
{
    public class GameTests
    {
        [Fact]
        public void Board_CorrectPieceTest()
        {
            var game = new Game("First", "Second");
            Assert.True(game.Board[0, 0] is OccupiedTile occupiedTile1 && occupiedTile1.Piece is Rook);
            Assert.True(game.Board[1, 0] is OccupiedTile occupiedTile2 && occupiedTile2.Piece is Knight);
            Assert.True(game.Board[2, 0] is OccupiedTile occupiedTile3 && occupiedTile3.Piece is Bishop);
            Assert.True(game.Board[3, 0] is OccupiedTile occupiedTile4 && occupiedTile4.Piece is Queen);
            Assert.True(game.Board[4, 0] is OccupiedTile occupiedTile5 && occupiedTile5.Piece is King);
            Assert.True(game.Board[5, 0] is OccupiedTile occupiedTile6 && occupiedTile6.Piece is Bishop);
            Assert.True(game.Board[6, 0] is OccupiedTile occupiedTile7 && occupiedTile7.Piece is Knight);
            Assert.True(game.Board[7, 0] is OccupiedTile occupiedTile8 && occupiedTile8.Piece is Rook);
        }

        [Fact]
        public void Board_CorrectTileTest()
        {
            var game = new Game("First", "Second");

            for (var y = 0; y < 8; y++)
            {
                for (var x = 0; x < 8; x++)
                {
                    if (y < 2 || y > 5)
                    {
                        Assert.True(game.Board[x, y] is OccupiedTile);
                    }
                    else
                    {
                        Assert.True(game.Board[x, y] is EmptyTile);
                    }
                }
            }
        }

        [Fact]
        public void Move_Test()
        {
            var game = new Game("First", "Second");

            Assert.Throws<IllegalMoveException>(() => game.Move(new Point(0, 0), new Point(0, 3)));
        }

        [Fact]
        public void IllegalMoveException_Test()
        {
            var game = new Game("", "");
            Assert.Throws<IllegalMoveException>(() => game.Move(new Point(0, 0), new Point(1, 1)));
            Assert.Throws<IllegalMoveException>(() => game.Move(new Point(1, 0), new Point(0, 3)));

            Assert.True(game.Board[2, 3] is EmptyTile);

            var ex = Record.Exception(() => game.Move(new Point(2, 1), new Point(2, 3)));
            Assert.Null(ex);

            Assert.Throws<IllegalMoveException>(() => game.Move(new Point(2, 0), new Point(4, 2)));
        }

        [Fact]
        public void IllegalMoveException_CaptureOwnPiece_Test()
        {
            var game = new Game("", "");
            var tile = game.Board[4, 0];

            Assert.True(tile is OccupiedTile occupiedTile && occupiedTile.Piece is King);

            var ex = Record.Exception(() => game.Move(new Point(4, 0), new Point(5, 0)));

            Assert.IsType<IllegalMoveException>(ex);
            Assert.True(ex.Message == "Cannot capture your own piece");
        }

        [Fact]
        public void CaptureEnemyPiece_Test()
        {
        }
    }
}