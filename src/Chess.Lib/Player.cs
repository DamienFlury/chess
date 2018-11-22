using System;

namespace Chess.Lib
{
    /// <summary>
    /// The player. Each instance has the name of the player and a color. Immutable.
    /// </summary>
    internal sealed class Player : IEquatable<Player>
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

        public bool Equals(Player other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Name, other.Name) && Team == other.Team;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj is Player other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Name != null ? Name.GetHashCode() : 0) * 397) ^ (int) Team;
            }
        }

        public static bool operator ==(Player left, Player right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Player left, Player right)
        {
            return !Equals(left, right);
        }
    }
}