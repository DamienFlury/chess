using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using Chess.Lib.Tiles;

namespace Chess.Lib.Pieces
{
    public sealed class Rook : IPiece
    {
        public Rook(Team team) => Team = team;

        public override string ToString() => "Rook";
        public Team Team { get; }

        public IEnumerable<Move> PossibleMoves
        {
            get
            {
                for (var i = 1; i < 8; i++)
                {
                    yield return new Move(i, 0);
                    yield return new Move(-i, 0);
                    yield return new Move(0, i);
                    yield return new Move(0, -i);
                }
            }
        }

        public bool IsPossibleMove(Point start, Point destination, Board board)
        {
            var distance = destination - start;

            bool IsOnSameRowOrColumn() => distance.X == 0 || distance.Y == 0;

            if (!IsOnSameRowOrColumn()) return false;

            if (distance.Y == 0) return false;

            var maxCount = Math.Max(Math.Abs(distance.X), Math.Abs(distance.Y));
            var (signX, signY) = (Math.Sign(distance.X), Math.Sign(distance.Y));
            
            for (var i = 1; i < maxCount; i++)
            {
                var currentTile = board[signX * i, signY * i];
                if (currentTile is OccupiedTile) return false;
            }

            if (board[signX * maxCount, signY * maxCount] is OccupiedTile occupiedTile &&
                occupiedTile.Piece.Team == (board[start.X, start.Y] as OccupiedTile)?.Piece.Team) return false;

            return true;
        }

        public IEnumerable<Move> GetPossibleMoves(Point current, Board board)
        {
            var currentPiece = (board[current.X, current.Y] as OccupiedTile)?.Piece ?? throw new ArgumentException();
            for (var x = current.X; x < 8; x++)
            {
                var tile = board[x, 0];
                if (IsOccupiedByOwnPiece(tile)) break;
                yield return new Move(x, 0);
            }

            for (var x = current.X; x >= 0; x--)
            {
                var tile = board[x, 0];
                if(IsOccupiedByOwnPiece(tile)) break;
                yield return new Move(x, 0);
            }

            for (var y = current.Y; y < 8; y++)
            {
                var tile = board[0, y];
                if (IsOccupiedByOwnPiece(tile)) break;
                yield return new Move(0, y);
            }

            for (var y = current.Y; y >= 0; y++)
            {
                if (y == 0) continue;
                var tile = board[0, y];
                if (IsOccupiedByOwnPiece(tile)) break;
                yield return new Move(0, y);
            }

            bool IsOccupiedByOwnPiece(ITile tile) => tile is OccupiedTile occupiedTile && occupiedTile.Piece.Team == currentPiece.Team;
        }
    }
}