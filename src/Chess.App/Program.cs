using System;
using System.ComponentModel;
using Chess.Lib;
using Chess.Lib.Pieces;
using Chess.Lib.Tiles;

namespace Chess.App
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var game = new Game("Test", "Test2");
            DrawBoardToConsoleSimplified(game);
            Console.WriteLine();
            DrawBoardToConsoleSimplified(game.Move(0, 0, 0, 3));
            Console.WriteLine();
            DrawBoardToConsoleSimplified(game);
        }

        private static void DrawBoardToConsole()
        {
            const int height = 42;
            const int width = 122;

            for (var y = 0; y <= height; y++)
            {
                for (var x = 0; x <= width; x++)
                {
                    Console.Write((x == 0 || x == width) && (y - 8) % 5 == 0
                        ? (char) (49 + y / 5)
                        : (y == 0 || y == height) && (x - 8) % 15 == 0
                            ? (char) (65 + x / 15)
                            : (x - 1) % (width / 8) == 0
                                ? '|'
                                : (y - 1) % (height / 8) == 0
                                    ? '–'
                                    : ' ');
                }

                Console.WriteLine();
            }
        }

        private static void DrawBoardToConsoleSimplified(Game game)
        {
            for (var y = 0; y < 8; y++)
            {
                for (var x = 0; x < 8; x++)
                {
                    if (game.Board[x, y] is OccupiedTile occupiedTile)
                    {
                        Console.ForegroundColor = occupiedTile.Piece.Team == Team.Black ? ConsoleColor.Cyan : ConsoleColor.Yellow;
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
    }
}