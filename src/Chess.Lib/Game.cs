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
        private Game(string whitePlayerName, string blackPlayerName, Board board)
        {
            whitePlayerName = whitePlayerName ?? throw new ArgumentNullException(nameof(whitePlayerName));
            blackPlayerName = blackPlayerName ?? throw new ArgumentNullException(nameof(blackPlayerName));

            Player1 = new Player(whitePlayerName, Team.White);
            Player2 = new Player(blackPlayerName, Team.Black);
            Board = board;
        }


        /// <summary>
        /// Creates a new game instance. Both player names can't be null.
        /// Creates the board array of tiles as a starting game.
        /// </summary>
        /// <param name="whitePlayerName">No null allowed</param>
        /// <param name="blackPlayerName">No null allowed</param>
        public Game(string whitePlayerName, string blackPlayerName) : this(whitePlayerName, blackPlayerName,
            GetStartingTiles())
        {
        }

        private static Board GetStartingTiles()
        {
            var tiles = new ITile[8, 8];
            tiles[0, 0] = new OccupiedTile(new Rook(Team.Black));
            tiles[1, 0] = new OccupiedTile(new Knight(Team.Black));
            tiles[2, 0] = new OccupiedTile(new Bishop(Team.Black));
            tiles[3, 0] = new OccupiedTile(new Queen(Team.Black));
            tiles[4, 0] = new OccupiedTile(new King(Team.Black));
            tiles[5, 0] = new OccupiedTile(new Bishop(Team.Black));
            tiles[6, 0] = new OccupiedTile(new Knight(Team.Black));
            tiles[7, 0] = new OccupiedTile(new Rook(Team.Black));

            //Pawns
            tiles[0, 1] = new OccupiedTile(new Pawn(Team.Black));
            tiles[1, 1] = new OccupiedTile(new Pawn(Team.Black));
            tiles[2, 1] = new OccupiedTile(new Pawn(Team.Black));
            tiles[3, 1] = new OccupiedTile(new Pawn(Team.Black));
            tiles[4, 1] = new OccupiedTile(new Pawn(Team.Black));
            tiles[5, 1] = new OccupiedTile(new Pawn(Team.Black));
            tiles[6, 1] = new OccupiedTile(new Pawn(Team.Black));
            tiles[7, 1] = new OccupiedTile(new Pawn(Team.Black));

            for (var x = 0; x < 8; x++)
            {
                for (var y = 2; y < 6; y++)
                {
                    tiles[x, y] = new EmptyTile();
                }
            }


            tiles[0, 7] = new OccupiedTile(new Rook(Team.White));
            tiles[1, 7] = new OccupiedTile(new Knight(Team.White));
            tiles[2, 7] = new OccupiedTile(new Bishop(Team.White));
            tiles[3, 7] = new OccupiedTile(new King(Team.White));
            tiles[4, 7] = new OccupiedTile(new Queen(Team.White));
            tiles[5, 7] = new OccupiedTile(new Bishop(Team.White));
            tiles[6, 7] = new OccupiedTile(new Knight(Team.White));
            tiles[7, 7] = new OccupiedTile(new Rook(Team.White));

            tiles[0, 6] = new OccupiedTile(new Pawn(Team.White));
            tiles[1, 6] = new OccupiedTile(new Pawn(Team.White));
            tiles[2, 6] = new OccupiedTile(new Pawn(Team.White));
            tiles[3, 6] = new OccupiedTile(new Pawn(Team.White));
            tiles[4, 6] = new OccupiedTile(new Pawn(Team.White));
            tiles[5, 6] = new OccupiedTile(new Pawn(Team.White));
            tiles[6, 6] = new OccupiedTile(new Pawn(Team.White));
            tiles[7, 6] = new OccupiedTile(new Pawn(Team.White));

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
        public Game Move(int xCurrent, int yCurrent, int xDestination, int yDestination)
        {
            if (!(Board[xCurrent, yCurrent] is OccupiedTile currentTile))
                throw new ArgumentException("Current tile can't be empty");

            var piece = currentTile.Piece;

            var move = new Move(xDestination - xCurrent, yDestination - yCurrent);

            if (!piece.PossibleMoves.Contains(move)) throw new IllegalMoveException("This move is illegal");

            var destinationTile = Board[xDestination, yDestination];

            if (destinationTile is OccupiedTile occupiedTile && occupiedTile.Piece.Team == piece.Team)
                throw new IllegalMoveException("Cannot capture your own piece");

            var nextTiles = new ITile[8, 8];
            for (var y = 0; y < 8; y++)
            {
                for (var x = 0; x < 8; x++)
                {
                    nextTiles[x, y] = Board[x, y];
                }
            }
            nextTiles[xCurrent, yCurrent] = new EmptyTile();
            nextTiles[xDestination, yDestination] = currentTile;

            return new Game(Player1.Name, Player2.Name, new Board(nextTiles));
        }
    }
}