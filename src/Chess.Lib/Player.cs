using System;
using System.Drawing;

namespace Chess.Lib
{
    /// <summary>
    /// The player. Each instance has the name of the player and a color. Immutable.
    /// </summary>
    internal sealed class Player
    {
        /// <summary>
        /// Creates a new instance of Player. Name can't be null.
        /// </summary>
        /// <param name="name">No null allowed</param>
        /// <param name="color"></param>
        public Player(string name, ConsoleColor color)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Color = color;
        }

        /// <summary>
        /// The name of the player.
        /// </summary>
        internal string Name { get; }
        
        /// <summary>
        /// The color/team of the player.
        /// </summary>
        internal ConsoleColor Color { get; }
    }
}