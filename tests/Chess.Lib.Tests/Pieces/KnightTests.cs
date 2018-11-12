using System.Linq;
using Chess.Lib.Pieces;
using Xunit;

namespace Chess.Lib.Tests.Pieces
{
    public class KnightTests
    {
        [Fact]
        public void PossibleMoves_Test()
        {
            var knight = new Knight(Team.Black);
            
            var expected = new Move[]
            {
                new Move(1, 2),
                new Move(1, -2),
                new Move(-1, 2),
                new Move(-1, -2),
                new Move(2, 1),
                new Move(2, -1),
                new Move(-2, 1),
                new Move(-2, -1)
            };
            
            Assert.True(expected.All(knight.PossibleMoves.Contains));
        }
    }
}