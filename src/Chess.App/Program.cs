using System;
using System.IO.Enumeration;
using Chess.Lib;
using Chess.Lib.Pieces;
using Chess.Lib.Tiles;

namespace Chess.App
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            ChoosingDialog();
        }

        private static void ChoosingDialog()
        {
            var game = new Game();
            for (;;)
            {
                DrawBoardToConsoleSimplified(game);
                WriteInputCharacter();
                var input = (Console.ReadLine() ?? "").ToLower();
                if (input == "mv" || input == "move")
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("  Move from:");
                    Console.ResetColor();
                    Console.Write("    x: ");
                    if (!int.TryParse(Console.ReadLine(), out var xCurrent)) continue;
                    Console.Write("    y: ");
                    if (!int.TryParse(Console.ReadLine(), out var yCurrent)) continue;

                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("  Move to:");
                    Console.ResetColor();
                    Console.Write("    x: ");
                    if (!int.TryParse(Console.ReadLine(), out var xDestination)) continue;
                    Console.Write("    y: ");
                    if (!int.TryParse(Console.ReadLine(), out var yDestination)) continue;


                    var current = new Point(xCurrent, yCurrent);
                    var destination = new Point(xDestination, yDestination);
                    try
                    {
                        game = game.Move(current, destination);
                    }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("  No move possible");
                        Console.ResetColor();
                    }
                }
                else if (input == "status")
                {
                    for (var x = 0; x < 8; x++)
                    {
                        for (var y = 0; y < 8; y++)
                        {
                            if (!(game.Board[x, y] is OccupiedTile occupiedTile)) continue;
                            var piece = occupiedTile.Piece;
                            if (!(piece is King king)) continue;
//                            Console.WriteLine(king.Team + ": " + king.IsChecked(new Point(x, y), game.Board));
                        }
                    }
                }

                Console.WriteLine();
            }
        }

        private static void WriteInputCharacter()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("» ");
            Console.ResetColor();
        }

        private static void PrintPossibleMoves()
        {
            var game = new Game();
            DrawBoardToConsoleSimplified(game);
            for (;;)
            {
                Console.Write("x: ");
                var x = int.Parse(Console.ReadLine());
                Console.Write("y: ");
                var y = int.Parse(Console.ReadLine());
                var piece = (game.Board[x, y] as OccupiedTile)?.Piece;
                if (piece is null) continue;
                var currentPoint = new Point(x, y);
                foreach (var move in piece.GetPossibleMoves(game.Board))
                {
                    DrawBoardToConsoleSimplified(game.Move(currentPoint, currentPoint + move));
                }
            }
        }

        private static void Movement()
        {
            var game = new Game("Test", "Test2");
            DrawBoardToConsoleSimplified(game);
            var piece = (game.Board[1, 0] as OccupiedTile)?.Piece ?? throw new Exception();
            foreach (var move in piece.GetPossibleMoves(game.Board))
            {
                Console.WriteLine($"x = {move.X}, y = {move.Y}");
            }

            while (true)
            {
                Console.Write("x = ");
                var xCurrent = int.Parse(Console.ReadLine());
                Console.Write("y = ");
                var yCurrent = int.Parse(Console.ReadLine());
                Console.WriteLine();
                Console.Write("x (destination) = ");
                var xDestination = int.Parse(Console.ReadLine());
                Console.Write("y (destination) = ");
                var yDestination = int.Parse(Console.ReadLine());
                try
                {
                    game = game.Move(new Point(xCurrent, yCurrent), new Point(xDestination, yDestination));
                    DrawBoardToConsoleSimplified(game);
                }
                catch
                {
                }
            }
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
    }
}