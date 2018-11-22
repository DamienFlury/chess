using System;
using System.Linq;
using System.Security.Cryptography;
using Chess.Lib;
using Chess.Lib.Tiles;

namespace Chess.App
{
    public class ChessGame
    {
        public ChessGame(string player1, string player2)
        {
            Game = new Game(player1, player2);
            CurrentTeam = Team.White;
        }

        private Game Game { get; set; }
        private Team CurrentTeam { get; set; }

        public bool TryMove(int xCurrent, int yCurrent, int xDestination, int yDestination)
        {
            var currentTile = Game.Board[xCurrent, yCurrent];
            if (!(currentTile is OccupiedTile occupiedCurrentTile)) return false;
            var piece = occupiedCurrentTile.Piece;
            if (piece.Team != CurrentTeam) return false;
            try
            {
                Game = Game.Move(xCurrent, yCurrent, xDestination, yDestination);
            }
            catch
            {
                return false;
            }

            CurrentTeam = CurrentTeam == Team.White ? Team.Black : Team.White;
            return true;
        }

        public void PrettyPrint()
        {
            for (var y = 0; y < 8; y++)
            {
                for (var x = 0; x < 8; x++)
                {
                    if (Game.Board[x, y] is OccupiedTile occupiedTile)
                    {
                        Console.ForegroundColor = occupiedTile.Piece.Team == Team.Black
                            ? ConsoleColor.Cyan
                            : ConsoleColor.Yellow;
                        Console.Write(occupiedTile.Piece.ToString().ToUpperInvariant()[0]);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(' ');
                    }

                    Console.Write(' ');
                }

                Console.WriteLine();
            }
        }

        public void PrettyPrint2()
        {
            const int height = 50;
            const int width = 130;

            for (var y = 0; y <= height; y++)
            {
                for (var x = 0; x <= width; x++)
                {
                    var coloredChar = GetCurrentChar(x, y, width, height);
                    Console.ForegroundColor = coloredChar.Color;
                    Console.Write(coloredChar.Character);
                    Console.ResetColor();
                }

                Console.WriteLine();
            }
        }

        private ColoredCharacter GetCurrentChar(int x, int y, int width, int height)
        {
            var xPadded = x - 1;
            var yPadded = y - 1;
            var widthPadded = width - 2;
            var heightPadded = height - 2;

            var tileWidth = widthPadded / 8;
            var tileHeight = heightPadded / 8;

            if ((x == 0 || x == width) && (y - 10) % tileHeight == 0)
                return new ColoredCharacter((char) (49 + yPadded / tileHeight), ConsoleColor.Gray);
            if ((y == 0 || y == height) && (x - 9) % tileWidth == 0)
                return new ColoredCharacter((char) (char) (65 + xPadded / tileWidth), ConsoleColor.Gray);
            if (xPadded % (width / 8) == 0)
                return new ColoredCharacter('|', ConsoleColor.Gray);
            if (yPadded % (height / 8) == 0)
                return new ColoredCharacter('–', ConsoleColor.Gray);
            if ((xPadded - 8) % tileWidth == 0 && (yPadded - 3) % tileHeight == 0)
            {
                var currentTile = Game.Board[x / tileWidth, y / tileHeight];
                if (!(currentTile is OccupiedTile occupiedTile)) return new ColoredCharacter(' ', ConsoleColor.Gray);
                return new ColoredCharacter(occupiedTile.Piece.ToString()[0],
                    occupiedTile.Piece.Team == Team.White ? ConsoleColor.Green : ConsoleColor.Cyan);
            }

            return new ColoredCharacter(' ', ConsoleColor.Gray);
        }
    }
}