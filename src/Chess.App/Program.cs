using System;
using System.ComponentModel;
using Chess.Lib;

namespace Chess.App
{
    class Program
    {
        private static void Main(string[] args)
        {
            DrawBoardToConsole();
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
    }
}