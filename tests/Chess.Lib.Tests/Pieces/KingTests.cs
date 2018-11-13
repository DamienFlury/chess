using System.Linq;
using Chess.Lib.Pieces;
using Xunit;

namespace Chess.Lib.Tests.Pieces
{
    public class KingTests
    {
        [Fact]
        public void PossibleMoves_Test()
        {
            var king = new King(Team.Black);

            var expected = new Move[]
            {
                new Move(0, -1),
                new Move(1, 1),
                new Move(1, 0),
                new Move(1, 1),
                new Move(0, 1),
                new Move(-1, 1),
                new Move(-1, 0),
                new Move(-1, -1)
            };

            Assert.True(expected.All(king.PossibleMoves.Contains));
        }
    }
}