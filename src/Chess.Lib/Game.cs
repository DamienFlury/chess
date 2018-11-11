using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using Chess.Lib.Pieces;

namespace Chess.Lib
{
    /// <summary>
    /// Has the board as two-dimensional array of tiles. Also know both players.
    /// Shallow immutable (planning on making the array an immutable collection to provide full immutability).
    /// </summary>
    public sealed class Game
    {
        /// <summary>
        /// Creates a new game instance. Both player names can't be null.
        /// Creates the board array of tiles as a starting game.
        /// </summary>
        /// <param name="whitePlayerName">No null allowed</param>
        /// <param name="blackPlayerName">No null allowed</param>
        public Game(string whitePlayerName, string blackPlayerName)
        {
            whitePlayerName = whitePlayerName ?? throw new ArgumentNullException(nameof(whitePlayerName));
            blackPlayerName = blackPlayerName ?? throw new ArgumentNullException(nameof(blackPlayerName));

            WhitePlayer = new Player(whitePlayerName, Color.White);
            BlackPlayer = new Player(blackPlayerName, Color.Black);

            Board = new ITile[8, 8];
            Board[0, 0] = new OccupiedTile(new Rook(Color.Black));
            Board[1, 0] = new OccupiedTile(new Knight(Color.Black));
            Board[2, 0] = new OccupiedTile(new Bishop(Color.Black));
            Board[3, 0] = new OccupiedTile(new Queen(Color.Black));
            Board[4, 0] = new OccupiedTile(new King(Color.Black));
            Board[5, 0] = new OccupiedTile(new Bishop(Color.Black));
            Board[6, 0] = new OccupiedTile(new Knight(Color.Black));
            Board[7, 0] = new OccupiedTile(new Rook(Color.Black));

            //Pawns
            Board[0, 1] = new OccupiedTile(new Pawn(Color.Black));
            Board[1, 1] = new OccupiedTile(new Pawn(Color.Black));
            Board[2, 1] = new OccupiedTile(new Pawn(Color.Black));
            Board[3, 1] = new OccupiedTile(new Pawn(Color.Black));
            Board[4, 1] = new OccupiedTile(new Pawn(Color.Black));
            Board[5, 1] = new OccupiedTile(new Pawn(Color.Black));
            Board[6, 1] = new OccupiedTile(new Pawn(Color.Black));
            Board[7, 1] = new OccupiedTile(new Pawn(Color.Black));
            
            for (var x = 0; x < 8; x++)
            {
                for (var y = 2; y < 6; y++)
                {
                    Board[x, y] = new EmptyTile();
                }
            }
            
            
            Board[0, 7] = new OccupiedTile(new Rook(Color.White));
            Board[1, 7] = new OccupiedTile(new Knight(Color.White));
            Board[2, 7] = new OccupiedTile(new Bishop(Color.White));
            Board[3, 7] = new OccupiedTile(new King(Color.White));
            Board[4, 7] = new OccupiedTile(new Queen(Color.White));
            Board[5, 7] = new OccupiedTile(new Bishop(Color.White));
            Board[6, 7] = new OccupiedTile(new Knight(Color.White));
            Board[7, 7] = new OccupiedTile(new Rook(Color.White));
            
            Board[0, 6] = new OccupiedTile(new Pawn(Color.White));
            Board[1, 6] = new OccupiedTile(new Pawn(Color.White));
            Board[2, 6] = new OccupiedTile(new Pawn(Color.White));
            Board[3, 6] = new OccupiedTile(new Pawn(Color.White));
            Board[4, 6] = new OccupiedTile(new Pawn(Color.White));
            Board[5, 6] = new OccupiedTile(new Pawn(Color.White));
            Board[6, 6] = new OccupiedTile(new Pawn(Color.White));
            Board[7, 6] = new OccupiedTile(new Pawn(Color.White));
        }

        private Player WhitePlayer { get; }
        private Player BlackPlayer { get; }

        /// <summary>
        /// The board. Contains either occupied tiles or Empty tiles. Null should never be used.
        /// </summary>
        public ITile[,] Board { get; }
    }
}