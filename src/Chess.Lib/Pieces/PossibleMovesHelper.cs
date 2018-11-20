using System;
using System.Collections.Generic;
using Chess.Lib.Tiles;

namespace Chess.Lib.Pieces
{
    public static class PossibleMovesHelper
    {
        public static IEnumerable<Move> GetStraightMoves(Point current, Board board)
        {
            if (!(board[current.X, current.Y] is OccupiedTile occupiedTile)) throw new ArgumentException();

            var team = occupiedTile.Piece.Team;
            for (var x = current.X + 1; x < 8; x++)
            {
                var tile = board[x, 0];
                if (IsOccupiedBySameTeam(team, tile)) break;
                yield return new Move(x, 0);
            }

            for (var x = current.X - 1; x >= 0; x--)
            {
                var tile = board[x, 0];
                if (IsOccupiedBySameTeam(team, tile)) break;
                yield return new Move(x, 0);
            }

            for (var y = current.Y + 1; y < 8; y++)
            {
                var tile = board[0, y];
                if (IsOccupiedBySameTeam(team, tile)) break;
                yield return new Move(0, y);
            }

            for (var y = current.Y - 1; y >= 0; y++)
            {
                var tile = board[0, y];
                if (IsOccupiedBySameTeam(team, tile)) break;
                yield return new Move(0, y);
            }
        }

        public static IEnumerable<Move> GetDiagonalMoves(Point current, Board board)
        {
            if (!(board[current.X, current.Y] is OccupiedTile occupiedTile)) throw new ArgumentException();

            var team = occupiedTile.Piece.Team;

            for (var i = 1; current.X + i < 8 && current.Y + i < 8; i++)
            {
                var x = current.X + i;
                var y = current.Y + i;
                var tile = board[x, y];
                if (IsOccupiedBySameTeam(team, tile)) break;
                yield return new Move(x, y);
            }

            for (var i = 1; current.X + i < 8 && current.Y - i > 0; i++)
            {
                var x = current.X + i;
                var y = current.Y - i;
                var tile = board[x, y];
                if (IsOccupiedBySameTeam(team, tile)) break;
                yield return new Move(x, y);
            }

            for (var i = 1; current.X - i > 0 && current.Y + i < 8; i++)
            {
                var x = current.X - i;
                var y = current.Y + i;
                var tile = board[x, y];
                if (IsOccupiedBySameTeam(team, tile)) break;
                yield return new Move(x, y);
            }

            for (var i = 1; current.X - i > 0 && current.Y - i > 0; i++)
            {
                var x = current.X - i;
                var y = current.Y - i;
                var tile = board[x, y];
                if (IsOccupiedBySameTeam(team, tile)) break;
                yield return new Move(x, y);
            }
        }

        public static bool IsOccupiedBySameTeam(Team team, ITile tile) =>
            tile is OccupiedTile occupiedTile && occupiedTile.Piece.Team == team;
    }
}