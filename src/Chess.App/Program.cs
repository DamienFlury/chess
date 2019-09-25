using System;
using System.IO.Enumeration;
using System.Xml.Serialization;
using Chess.Lib;
using Chess.Lib.Pieces;
using Chess.Lib.Tiles;

namespace Chess.App
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("First Player: What's your name?");
            WriteInputCharacter();
            var player1 = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Second Player: What's your name then?");
            WriteInputCharacter();
            var player2 = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("|=========================|");
            Console.WriteLine("|  Alright, let's start!  |");
            Console.WriteLine("|=========================|");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(player1);
            Console.ResetColor();
            Console.Write(" vs. ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(player2);
            Console.ResetColor();
            Console.WriteLine();

            var chessGame = new ChessGame(player1, player2);
            while (true)
            {
                chessGame.PrettyPrint2();
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


                    if (!chessGame.TryMove(xCurrent, yCurrent, xDestination, yDestination))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("  Move not possible");
                        Console.ResetColor();
                    }
                }
                //else if (input == "status")
                //
                //   for (var x = 0; x < 8; x++)
                //   {
                //       for (var y = 0; y < 8; y++)
                //       {
                //           if (!(game.Board[x, y] is OccupiedTile occupiedTile)) continue;
                //           var piece = occupiedTile.Piece;
                //           if (!(piece is King king)) continue;
                //           var isChecked = king.IsChecked(game.Board);
                //           Console.Write(king.Team + ": ");
                //           if (isChecked) Console.ForegroundColor = ConsoleColor.Red;
                //           Console.WriteLine(isChecked);
                //           if (isChecked) Console.ResetColor();
                //       }
                //   }
                //}


            }
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


                    try
                    {
                        game = game.Move(xCurrent, yCurrent, xDestination, yDestination);
                    }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("  Move not possible");
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
                            var isChecked = king.IsChecked(game.Board);
                            Console.Write(king.Team + ": ");
                            if (isChecked) Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(isChecked);
                            if (isChecked) Console.ResetColor();
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
                foreach (var move in piece.GetPossibleMoves(game.Board))
                {
                    DrawBoardToConsoleSimplified(game.Move(x, y, x + move.X, y + move.Y));
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
                    game = game.Move(xCurrent, yCurrent, xDestination, yDestination);
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
                    if ((x == 0 || x == width) && (y - 8) % 5 == 0)
                    {
                        
                    }
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
                        Console.ForegroundColor = occupiedTile.Piece?.Team switch {
                            Team.Black => ConsoleColor.Cyan,
                            _ => ConsoleColor.Yellow,
                        };
                        Console.Write(occupiedTile.Piece?.ToString()?.ToUpperInvariant()[0]);
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