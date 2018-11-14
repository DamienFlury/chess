using System;

namespace Chess.Lib
{
    public struct Move : IEquatable<Move>
    {
        public Move(int x, int y) => (X, Y) = (x, y);

        public int X { get; }
        public int Y { get; }

        public bool Equals(Move other)
        {
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Move other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }

        public static bool operator ==(Move left, Move right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Move left, Move right)
        {
            return !left.Equals(right);
        }

        public void Deconstruct(out int x, out int y) => (x, y) = (X, Y);
    }
}