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
            var queen = new Queen(Team.Black);
            Assert.Empty(queen.GetPossibleMoves(new Point(3, 0), game.Board));

            var movedPawnGame = game.Move(new Point(3, 1), new Point(3, 3));
            
            Assert.True(queen.GetPossibleMoves(new Point(3, 0), movedPawnGame.Board).Count() == 2);
        }
    }
}