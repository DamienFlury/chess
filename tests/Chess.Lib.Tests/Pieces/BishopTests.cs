using Chess.Lib.Pieces;
using Xunit;

namespace Chess.Lib.Tests.Pieces
{
    public class BishopTests
    {
        [Fact]
        public void GetPossibleMoves_Test()
        {
            var game = new Game();
            var bishop = new Bishop(Team.Black);
            
            Assert.Empty(bishop.GetPossibleMoves(new Point(2, 0), game.Board));

            game = game.Move(new Point(3, 1), new Point(3, 3));
            Assert.NotEmpty(bishop.GetPossibleMoves(new Point(2, 0), game.Board));

            var ex = Record.Exception(() => game.Move(new Point(2, 0), new Point(4, 2)));
            Assert.Null(ex);

            Assert.Throws<IllegalMoveException>(() => game.Move(new Point(2, 0), new Point(3, 2)));
            Assert.Throws<IllegalMoveException>(() => game.Move(new Point(2, 0), new Point(1, 1)));

            var newGame = game.Move(new Point(1, 1), new Point(1, 2));
            var ex2 = Record.Exception(() => newGame.Move(new Point(2, 0), new Point(1, 1)));
            Assert.Null(ex2);
        }
    }
}