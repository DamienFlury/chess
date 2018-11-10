using System;
using System.Drawing;
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
        }

        private Player WhitePlayer { get; }
        private Player BlackPlayer { get; }
        
        public ITile[,] Board { get; }
    }
}