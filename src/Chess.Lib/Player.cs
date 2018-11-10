using System;
using System.Drawing;

namespace Chess.Lib
{
    internal sealed class Player
    {
        public Player(string name, Color color)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Color = color;
        }

        internal string Name { get; }
        internal Color Color { get; }
    }
}