using System;
using System.Linq;
using Chess.Lib.Pieces;
using Chess.Lib.Tiles;

namespace Chess.Lib
{
    /// <summary>
    /// Has the board as two-dimensional array of tiles. Also know both players.
    /// Shallow immutable (planning on making the array an immutable collection to provide full immutability).
    /// </summary>
    public sealed class Game
    {
        public Game(string whitePlayerName = "", string blackPlayerName = "", Board board = null)
        {
            Player1 = new Player(whitePlayerName, Team.White);
            Player2 = new Player(blackPlayerName, Team.Black);
            Board = board ?? GetStartingTiles();
        }

        private static Board GetStartingTiles()
        {
            var tiles = new ITile[8, 8];
            tiles[0, 0] = new OccupiedTile(new Rook(Team.Black, 0, 0));
            tiles[1, 0] = new OccupiedTile(new Knight(Team.Black, 1, 0));
            tiles[2, 0] = new OccupiedTile(new Bishop(Team.Black, 2, 0));
            tiles[3, 0] = new OccupiedTile(new Queen(Team.Black, 3, 0));
            tiles[4, 0] = new OccupiedTile(new King(Team.Black, 4, 0));
            tiles[5, 0] = new OccupiedTile(new Bishop(Team.Black, 5, 0));
            tiles[6, 0] = new OccupiedTile(new Knight(Team.Black, 6, 0));
            tiles[7, 0] = new OccupiedTile(new Rook(Team.Black, 7, 0));

            //Pawns
            tiles[0, 1] = new OccupiedTile(new Pawn(Team.Black, 0, 1));
            tiles[1, 1] = new OccupiedTile(new Pawn(Team.Black, 1, 1));
            tiles[2, 1] = new OccupiedTile(new Pawn(Team.Black, 2, 1));
            tiles[3, 1] = new OccupiedTile(new Pawn(Team.Black, 3, 1));
            tiles[4, 1] = new OccupiedTile(new Pawn(Team.Black, 4, 1));
            tiles[5, 1] = new OccupiedTile(new Pawn(Team.Black, 5, 1));
            tiles[6, 1] = new OccupiedTile(new Pawn(Team.Black, 6, 1));
            tiles[7, 1] = new OccupiedTile(new Pawn(Team.Black, 7, 1));

            for (var x = 0; x < 8; x++)
            {
                for (var y = 2; y < 6; y++)
                {
                    tiles[x, y] = new EmptyTile();
                }
            }


            tiles[0, 7] = new OccupiedTile(new Rook(Team.White, 0, 7));
            tiles[1, 7] = new OccupiedTile(new Knight(Team.White, 1, 7));
            tiles[2, 7] = new OccupiedTile(new Bishop(Team.White, 2, 7));
            tiles[3, 7] = new OccupiedTile(new Queen(Team.White, 3, 7));
            tiles[4, 7] = new OccupiedTile(new King(Team.White, 4, 7));
            tiles[5, 7] = new OccupiedTile(new Bishop(Team.White, 5, 7));
            tiles[6, 7] = new OccupiedTile(new Knight(Team.White, 6, 7));
            tiles[7, 7] = new OccupiedTile(new Rook(Team.White, 7, 7));

            tiles[0, 6] = new OccupiedTile(new Pawn(Team.White, 0, 6));
            tiles[1, 6] = new OccupiedTile(new Pawn(Team.White, 1, 6));
            tiles[2, 6] = new OccupiedTile(new Pawn(Team.White, 2, 6));
            tiles[3, 6] = new OccupiedTile(new Pawn(Team.White, 3, 6));
            tiles[4, 6] = new OccupiedTile(new Pawn(Team.White, 4, 6));
            tiles[5, 6] = new OccupiedTile(new Pawn(Team.White, 5, 6));
            tiles[6, 6] = new OccupiedTile(new Pawn(Team.White, 6, 6));
            tiles[7, 6] = new OccupiedTile(new Pawn(Team.White, 7, 7));

            return new Board(tiles);
        }


        private Player Player1 { get; }
        private Player Player2 { get; }

        /// <summary>
        /// The board. Contains either occupied tiles or Empty tiles. Null should never be used.
        /// </summary>
        public Board Board { get; }

        /// <summary>
        /// Moves a piece.
        /// </summary>
        /// <param name="xCurrent"></param>
        /// <param name="yCurrent"></param>
        /// <param name="xDestination"></param>
        /// <param name="yDestination"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="IllegalMoveException"></exception>
        public Game Move(int xCurrent, int yCurrent, int xDestination, int yDestination)
        {
            var currentTile = Board[xCurrent, yCurrent];

            if (!(currentTile is OccupiedTile currentTileOccupied))
                throw new ArgumentException("Current tile can't be empty");

            var piece = currentTileOccupied.Piece;

            var move = new Move(xDestination - xCurrent, yDestination - yCurrent);


            var destinationTile = Board[xDestination, yDestination];

            if (destinationTile is OccupiedTile occupiedTile && occupiedTile.Piece.Team == piece.Team)
                throw new IllegalMoveException("Cannot capture your own piece");

            if (!piece.GetPossibleMoves(Board).Contains(move)) throw new IllegalMoveException("");

            var nextTiles = new ITile[8, 8];
            for (var y = 0; y < 8; y++)
            {
                for (var x = 0; x < 8; x++)
                {
                    nextTiles[x, y] = Board[x, y];
                }
            }

            nextTiles[xCurrent, yCurrent] = new EmptyTile();
            nextTiles[xDestination, yDestination] = new OccupiedTile(piece.With(x: xDestination, y: yDestination, hasBeenMoved: true));

            return new Game(Player1.Name, Player2.Name, new Board(nextTiles));
        }
    }
}