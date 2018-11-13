using Chess.Lib.Pieces;
using Xunit;

namespace Chess.Lib.Tests.Pieces
{
    public class QueenTests
    {
        [Fact]
        public void PossibleMoves_Test()
        {
            var queen = new Queen(Team.Black);
            
            Assert.Contains(new Move(3, -3), queen.PossibleMoves);
            Assert.Contains(new Move(1, 1), queen.PossibleMoves);
            Assert.Contains(new Move(0, 5), queen.PossibleMoves);
            Assert.Contains(new Move(1, 0), queen.PossibleMoves);
            Assert.Contains(new Move(-5, 0), queen.PossibleMoves);
            Assert.Contains(new Move(2, 2), queen.PossibleMoves);
            
            Assert.DoesNotContain(new Move(3, -2), queen.PossibleMoves);
            Assert.DoesNotContain(new Move(0, 0), queen.PossibleMoves);
            Assert.DoesNotContain(new Move(2, 1), queen.PossibleMoves);
            Assert.DoesNotContain(new Move(1, 5), queen.PossibleMoves);
            Assert.DoesNotContain(new Move(-4, -3), queen.PossibleMoves);


        }
    }
}