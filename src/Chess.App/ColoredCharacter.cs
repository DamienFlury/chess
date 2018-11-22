using System;

namespace Chess.App
{
    public struct ColoredCharacter
    {
        public ColoredCharacter(char character, ConsoleColor color) => (Character, Color) = (character, color);

        public char Character { get; }
        public ConsoleColor Color { get; }
    }
}