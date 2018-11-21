using System.Linq;
using Chess.Lib.Pieces;
using Xunit;

namespace Chess.Lib.Tests.Pieces
{
    public class QueenTests
    {
        [Fact]
        public void GetPossibleMoves_Test()
        {
            var game = new Game();
            var queen = new Queen(Team.Black, 3, 0);
            Assert.Empty(queen.GetPossibleMoves(game.Board));

            var movedPawnGame = game.Move(new Point(3, 1), new Point(3, 3));
            
            Assert.True(queen.GetPossibleMoves(movedPawnGame.Board).Count() == 2);
        }
    }
}