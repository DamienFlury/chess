using System;
using System.Collections.Generic;
using Chess.Lib.Tiles;

namespace Chess.Lib.Pieces
{
    public static class PossibleMovesHelper
    {
        public static IEnumerable<Move> GetStraightMoves(int xCurrent, int yCurrent, Board board)
        {
            if (!(board[xCurrent, yCurrent] is OccupiedTile occupiedTile)) throw new ArgumentException();

            var team = occupiedTile.Piece.Team;
            for (var x = xCurrent + 1; x < 8; x++)
            {
                var tile = board[x, yCurrent];
                if (IsOccupiedBySameTeam(team, tile)) break;
                yield return new Move(x - xCurrent, 0);
            }

            for (var x = xCurrent - 1; x >= 0; x--)
            {
                var tile = board[x, yCurrent];
                if (IsOccupiedBySameTeam(team, tile)) break;
                yield return new Move(x - xCurrent, 0);
            }

            for (var y = yCurrent + 1; y < 8; y++)
            {
                var tile = board[xCurrent, y];
                if (IsOccupiedBySameTeam(team, tile)) break;
                yield return new Move(0, y - yCurrent);
            }

            for (var y = yCurrent - 1; y >= 0; y++)
            {
                var tile = board[xCurrent, y];
                if (IsOccupiedBySameTeam(team, tile)) break;
                yield return new Move(0, y - yCurrent);
            }
        }

        public static IEnumerable<Move> GetDiagonalMoves(int xCurrent, int yCurrent, Board board)
        {
            if (!(board[xCurrent, yCurrent] is OccupiedTile occupiedTile)) throw new ArgumentException();

            var team = occupiedTile.Piece.Team;

            for (var i = 1; xCurrent + i < 8 && yCurrent + i < 8; i++)
            {
                var x = xCurrent + i;
                var y = yCurrent + i;
                var tile = board[x, y];
                if (IsOccupiedBySameTeam(team, tile)) break;
                yield return new Move(x - xCurrent, y - yCurrent);
            }

            for (var i = 1; xCurrent + i < 8 && yCurrent - i > 0; i++)
            {
                var x = xCurrent + i;
                var y = yCurrent - i;
                var tile = board[x, y];
                if (IsOccupiedBySameTeam(team, tile)) break;
                yield return new Move(x - xCurrent, y - yCurrent);
            }

            for (var i = 1; xCurrent - i > 0 && yCurrent + i < 8; i++)
            {
                var x = xCurrent - i;
                var y = yCurrent + i;
                var tile = board[x, y];
                if (IsOccupiedBySameTeam(team, tile)) break;
                yield return new Move(x - xCurrent, y - yCurrent);
            }

            for (var i = 1; xCurrent - i > 0 && yCurrent - i > 0; i++)
            {
                var x = xCurrent - i;
                var y = yCurrent - i;
                var tile = board[x, y];
                if (IsOccupiedBySameTeam(team, tile)) break;
                yield return new Move(x - xCurrent, y - yCurrent);
            }
        }

        public static bool IsOccupiedBySameTeam(Team team, ITile tile) =>
            tile is OccupiedTile occupiedTile && occupiedTile.Piece.Team == team;
    }
}