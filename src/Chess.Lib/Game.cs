using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using Chess.Lib.Pieces;

namespace Chess.Lib
{
    public sealed class Game
    {
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
            for (var x = 0; x < 8; x++)
            {
                for (var y = 1; y < 7; y++)
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
        }

        private Player WhitePlayer { get; }
        private Player BlackPlayer { get; }
        
        public ITile[,] Board { get; }
    }
}