using System;

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
        /// <param name="team"></param>
        public Player(string name, Team team) => (Name, Team) = (name, team);

        /// <summary>
        /// The name of the player.
        /// </summary>
        internal string Name { get; }
        
        /// <summary>
        /// The color/team of the player.
        /// </summary>
        private Team Team { get; }
    }
}