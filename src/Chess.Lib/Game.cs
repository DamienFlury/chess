using System;
using System.Drawing;
using System.Runtime.CompilerServices;
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

            Player1 = new Player(whitePlayerName, Team.White);
            Player2 = new Player(blackPlayerName, Team.Black);

            Board = new ITile[8, 8];
            Board[0, 0] = new OccupiedTile(new Rook(Player2.Team));
            Board[1, 0] = new OccupiedTile(new Knight(Player2.Team));
            Board[2, 0] = new OccupiedTile(new Bishop(Player2.Team));
            Board[3, 0] = new OccupiedTile(new Queen(Player2.Team));
            Board[4, 0] = new OccupiedTile(new King(Player2.Team));
            Board[5, 0] = new OccupiedTile(new Bishop(Player2.Team));
            Board[6, 0] = new OccupiedTile(new Knight(Player2.Team));
            Board[7, 0] = new OccupiedTile(new Rook(Player2.Team));

            //Pawns
            Board[0, 1] = new OccupiedTile(new Pawn(Player2.Team));
            Board[1, 1] = new OccupiedTile(new Pawn(Player2.Team));
            Board[2, 1] = new OccupiedTile(new Pawn(Player2.Team));
            Board[3, 1] = new OccupiedTile(new Pawn(Player2.Team));
            Board[4, 1] = new OccupiedTile(new Pawn(Player2.Team));
            Board[5, 1] = new OccupiedTile(new Pawn(Player2.Team));
            Board[6, 1] = new OccupiedTile(new Pawn(Player2.Team));
            Board[7, 1] = new OccupiedTile(new Pawn(Player2.Team));
            
            for (var x = 0; x < 8; x++)
            {
                for (var y = 2; y < 6; y++)
                {
                    Board[x, y] = new EmptyTile();
                }
            }
            
            
            Board[0, 7] = new OccupiedTile(new Rook(Player1.Team));
            Board[1, 7] = new OccupiedTile(new Knight(Player1.Team));
            Board[2, 7] = new OccupiedTile(new Bishop(Player1.Team));
            Board[3, 7] = new OccupiedTile(new King(Player1.Team));
            Board[4, 7] = new OccupiedTile(new Queen(Player1.Team));
            Board[5, 7] = new OccupiedTile(new Bishop(Player1.Team));
            Board[6, 7] = new OccupiedTile(new Knight(Player1.Team));
            Board[7, 7] = new OccupiedTile(new Rook(Player1.Team));
            
            Board[0, 6] = new OccupiedTile(new Pawn(Player1.Team));
            Board[1, 6] = new OccupiedTile(new Pawn(Player1.Team));
            Board[2, 6] = new OccupiedTile(new Pawn(Player1.Team));
            Board[3, 6] = new OccupiedTile(new Pawn(Player1.Team));
            Board[4, 6] = new OccupiedTile(new Pawn(Player1.Team));
            Board[5, 6] = new OccupiedTile(new Pawn(Player1.Team));
            Board[6, 6] = new OccupiedTile(new Pawn(Player1.Team));
            Board[7, 6] = new OccupiedTile(new Pawn(Player1.Team));
        }

        private Player Player1 { get; }
        private Player Player2 { get; }

        /// <summary>
        /// The board. Contains either occupied tiles or Empty tiles. Null should never be used.
        /// </summary>
        public ITile[,] Board { get; }
    }
}