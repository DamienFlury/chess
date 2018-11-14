using System;

namespace Chess.Lib
{
    public struct Point : IEquatable<Point>
    {
        public int X { get; }
        public int Y { get; }

        public Point(int x, int y) => (X, Y) = (x, y);

        public static Move operator -(Point left, Point right) => new Move(left.X - right.X, left.Y - right.Y);

        public bool Equals(Point other)
        {
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Point other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }

        public static bool operator ==(Point left, Point right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Point left, Point right)
        {
            return !left.Equals(right);
        }

        public void Deconstruct(out int x, out int y) => (x, y) = (X, Y);
    }
}