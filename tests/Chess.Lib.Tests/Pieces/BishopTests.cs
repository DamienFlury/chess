using Chess.Lib.Pieces;
using Newtonsoft.Json.Serialization;
using Xunit;

namespace Chess.Lib.Tests.Pieces
{
    public class BishopTests
    {
        [Fact]
        public void PossibleMoves_Test()
        {
            var bishop = new Bishop(Team.Black);
            
            Assert.Contains(new Move(1, 1), bishop.PossibleMoves);
            Assert.Contains(new Move(5, 5), bishop.PossibleMoves);
            Assert.Contains(new Move(5, -5), bishop.PossibleMoves);
            Assert.Contains(new Move(-3, -3), bishop.PossibleMoves);
            Assert.Contains(new Move(-4, 4), bishop.PossibleMoves);
            
            Assert.DoesNotContain(new Move(1, 2), bishop.PossibleMoves);
            Assert.DoesNotContain(new Move(2, 3), bishop.PossibleMoves);
            Assert.DoesNotContain(new Move(-1, 0), bishop.PossibleMoves);
            Assert.DoesNotContain(new Move(0, 5), bishop.PossibleMoves);
            Assert.DoesNotContain(new Move(3, -4), bishop.PossibleMoves);
        }
    }
}