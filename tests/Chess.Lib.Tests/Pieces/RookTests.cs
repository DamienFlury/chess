using System.Linq;
using Chess.Lib.Pieces;
using Xunit;

namespace Chess.Lib.Tests.Pieces
{
    public class RookTests
    {
        [Fact]
        public void PossibleMoves_Test()
        {
            var rook = new Rook(Team.White);
            Assert.Contains(new Move(1, 0), rook.PossibleMoves);
            Assert.Contains(new Move(2, 0), rook.PossibleMoves);
            Assert.Contains(new Move(-5, 0), rook.PossibleMoves);
            Assert.Contains(new Move(0, 3), rook.PossibleMoves);
            Assert.Contains(new Move(0, 7), rook.PossibleMoves);
            
            
            Assert.DoesNotContain(new Move(1, 1), rook.PossibleMoves);
            Assert.DoesNotContain(new Move(0, 0), rook.PossibleMoves);
            Assert.DoesNotContain(new Move(-5, 5), rook.PossibleMoves);
            Assert.DoesNotContain(new Move(-5, 1), rook.PossibleMoves);
            Assert.DoesNotContain(new Move(4, 5), rook.PossibleMoves);


        }
    }
}