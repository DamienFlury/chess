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
        private Game(string whitePlayerName, string blackPlayerName, ITile[,] board)
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

        private static ITile[,] GetStartingTiles()
        {
            var board = new ITile[8, 8];
            board[0, 0] = new OccupiedTile(new Rook(Team.Black));
            board[1, 0] = new OccupiedTile(new Knight(Team.Black));
            board[2, 0] = new OccupiedTile(new Bishop(Team.Black));
            board[3, 0] = new OccupiedTile(new Queen(Team.Black));
            board[4, 0] = new OccupiedTile(new King(Team.Black));
            board[5, 0] = new OccupiedTile(new Bishop(Team.Black));
            board[6, 0] = new OccupiedTile(new Knight(Team.Black));
            board[7, 0] = new OccupiedTile(new Rook(Team.Black));

            //Pawns
            board[0, 1] = new OccupiedTile(new Pawn(Team.Black));
            board[1, 1] = new OccupiedTile(new Pawn(Team.Black));
            board[2, 1] = new OccupiedTile(new Pawn(Team.Black));
            board[3, 1] = new OccupiedTile(new Pawn(Team.Black));
            board[4, 1] = new OccupiedTile(new Pawn(Team.Black));
            board[5, 1] = new OccupiedTile(new Pawn(Team.Black));
            board[6, 1] = new OccupiedTile(new Pawn(Team.Black));
            board[7, 1] = new OccupiedTile(new Pawn(Team.Black));

            for (var x = 0; x < 8; x++)
            {
                for (var y = 2; y < 6; y++)
                {
                    board[x, y] = new EmptyTile();
                }
            }


            board[0, 7] = new OccupiedTile(new Rook(Team.White));
            board[1, 7] = new OccupiedTile(new Knight(Team.White));
            board[2, 7] = new OccupiedTile(new Bishop(Team.White));
            board[3, 7] = new OccupiedTile(new King(Team.White));
            board[4, 7] = new OccupiedTile(new Queen(Team.White));
            board[5, 7] = new OccupiedTile(new Bishop(Team.White));
            board[6, 7] = new OccupiedTile(new Knight(Team.White));
            board[7, 7] = new OccupiedTile(new Rook(Team.White));

            board[0, 6] = new OccupiedTile(new Pawn(Team.White));
            board[1, 6] = new OccupiedTile(new Pawn(Team.White));
            board[2, 6] = new OccupiedTile(new Pawn(Team.White));
            board[3, 6] = new OccupiedTile(new Pawn(Team.White));
            board[4, 6] = new OccupiedTile(new Pawn(Team.White));
            board[5, 6] = new OccupiedTile(new Pawn(Team.White));
            board[6, 6] = new OccupiedTile(new Pawn(Team.White));
            board[7, 6] = new OccupiedTile(new Pawn(Team.White));

            return board;
        }


        private Player Player1 { get; }
        private Player Player2 { get; }

        /// <summary>
        /// The board. Contains either occupied tiles or Empty tiles. Null should never be used.
        /// </summary>
        public ITile[,] Board { get; }

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


            var nextBoard = (ITile[,]) Board.Clone();

            nextBoard[xCurrent, yCurrent] = new EmptyTile();
            nextBoard[xDestination, yDestination] = currentTile;

            return new Game(Player1.Name, Player2.Name, nextBoard);
        }
    }
}