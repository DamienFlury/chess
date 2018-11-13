using System.Linq;
using Chess.Lib.Pieces;
using Xunit;

namespace Chess.Lib.Tests.Pieces
{
    public class PawnTests
    {
        [Fact]
        public void PossibleMoves_Test()
        {
            var pawn = new Pawn(Team.Black);
            
            Assert.True(pawn.PossibleMoves.All(move => move == new Move(0, 1) || move == new Move(0, 2)));
        }
    }
}