// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#nullable enable
namespace System.Drawing
{
    /// <summary>
    /// Represents an ordered pair of x and y coordinates that define a point in a two-dimensional plane.
    /// </summary>
    [Serializable]
    public struct Point
    {
        /// <summary>
        /// Creates a new instance of the <see cref='Point'/> class with member data left uninitialized.
        /// </summary>
        public static readonly Point Empty;

        private int x; // Do not rename (binary serialization)
        private int y; // Do not rename (binary serialization)

        /// <summary>
        /// Initializes a new instance of the <see cref='Point'/> class with the specified coordinates.
        /// </summary>
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref='Point'/> class from a <see cref='System.Drawing.Size'/> .
        /// </summary>
        public Point(Size sz)
        {
            x = sz.Width;
            y = sz.Height;
        }

        /// <summary>
        /// Initializes a new instance of the Point class using coordinates specified by an integer value.
        /// </summary>
        public Point(int dw)
        {
            x = LowInt16(dw);
            y = HighInt16(dw);
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref='Point'/> is empty.
        /// </summary>
        public readonly bool IsEmpty => x == 0 && y == 0;

        /// <summary>
        /// Gets the x-coordinate of this <see cref='Point'/>.
        /// </summary>
        public int X
        {
            readonly get => x;
            set => x = value;
        }

        /// <summary>
        /// Gets the y-coordinate of this <see cref='Point'/>.
        /// </summary>
        public int Y
        {
            readonly get => y;
            set => y = value;
        }

        /* TODO: Uncomment if PointF is copied over
        /// <summary>
        /// Creates a <see cref='PointF'/> with the coordinates of the specified <see cref='Point'/>
        /// </summary>
        public static implicit operator PointF(Point p) => new PointF(p.X, p.Y);
        */

        /// <summary>
        /// Creates a <see cref='System.Drawing.Size'/> with the coordinates of the specified <see cref='Point'/> .
        /// </summary>
        public static explicit operator Size(Point p) => new(p.X, p.Y);

        /// <summary>
        /// Translates a <see cref='Point'/> by a given <see cref='System.Drawing.Size'/> .
        /// </summary>
        public static Point operator +(Point pt, Size sz) => Add(pt, sz);

        /// <summary>
        /// Translates a <see cref='Point'/> by the negative of a given <see cref='System.Drawing.Size'/> .
        /// </summary>
        public static Point operator -(Point pt, Size sz) => Subtract(pt, sz);

        /// <summary>
        /// Compares two <see cref='Point'/> objects. The result specifies whether the values of the
        /// <see cref='Point.X'/> and <see cref='Point.Y'/> properties of the two
        /// <see cref='Point'/> objects are equal.
        /// </summary>
        public static bool operator ==(Point left, Point right) => left.X == right.X && left.Y == right.Y;

        /// <summary>
        /// Compares two <see cref='Point'/> objects. The result specifies whether the values of the
        /// <see cref='Point.X'/> or <see cref='Point.Y'/> properties of the two
        /// <see cref='Point'/>  objects are unequal.
        /// </summary>
        public static bool operator !=(Point left, Point right) => !(left == right);

        /// <summary>
        /// Translates a <see cref='Point'/> by a given <see cref='System.Drawing.Size'/> .
        /// </summary>
        public static Point Add(Point pt, Size sz) => new(unchecked(pt.X + sz.Width), unchecked(pt.Y + sz.Height));

        /// <summary>
        /// Translates a <see cref='Point'/> by the negative of a given <see cref='System.Drawing.Size'/> .
        /// </summary>
        public static Point Subtract(Point pt, Size sz) => new(unchecked(pt.X - sz.Width), unchecked(pt.Y - sz.Height));

        /* TODO: Uncomment if PointF is copied over
        /// <summary>
        /// Converts a PointF to a Point by performing a ceiling operation on all the coordinates.
        /// </summary>
        public static Point Ceiling(PointF value) => new Point(unchecked((int)Math.Ceiling(value.X)), unchecked((int)Math.Ceiling(value.Y)));

        /// <summary>
        /// Converts a PointF to a Point by performing a truncate operation on all the coordinates.
        /// </summary>
        public static Point Truncate(PointF value) => new Point(unchecked((int)value.X), unchecked((int)value.Y));

        /// <summary>
        /// Converts a PointF to a Point by performing a round operation on all the coordinates.
        /// </summary>
        public static Point Round(PointF value) => new Point(unchecked((int)Math.Round(value.X)), unchecked((int)Math.Round(value.Y)));
        */

        /// <summary>
        /// Specifies whether this <see cref='Point'/> contains the same coordinates as the specified
        /// <see cref='object'/>.
        /// </summary>
        public readonly override bool Equals(object? other) => other is Point point && Equals(point);

        /// <summary>
        /// Specifies whether this <see cref='Point'/> contains the same coordinates as the specified <see cref="Point"/>
        /// </summary>
        public readonly bool Equals(Point other) => this == other;

        /// <summary>
        /// Returns a hash code.
        /// </summary>
        public readonly override int GetHashCode()
        {
            // Original: HashCode.Combine(X, Y);
            unchecked
            {
                return X.GetHashCode() ^ Y.GetHashCode();
            }
        }

        /// <summary>
        /// Translates this <see cref='Point'/> by the specified amount.
        /// </summary>
        public void Offset(int dx, int dy)
        {
            unchecked
            {
                X += dx;
                Y += dy;
            }
        }

        /// <summary>
        /// Translates this <see cref='Point'/> by the specified amount.
        /// </summary>
        public void Offset(Point p) => Offset(p.X, p.Y);

        /// <summary>
        /// Converts this <see cref='Point'/> to a human readable string.
        /// </summary>
        public readonly override string ToString() => $"{{X={X},Y={Y}}}";

        private static short HighInt16(int n) => unchecked((short)((n >> 16) & 0xffff));

        private static short LowInt16(int n) => unchecked((short)(n & 0xffff));
    }
}
