// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#nullable enable
using nanoFramework.UI;

namespace System.Drawing
{
    // TODO: Add IEquatable<Rectangle> once generics are supported as the class already implements the contract

    /// <summary>
    /// Stores the location and size of a rectangular region.
    /// </summary>
    [Serializable]
    public struct Rectangle
    {
        /// <summary>
        /// Creates a new instance of the <see cref='Rectangle'/> class with member data left uninitialized.
        /// </summary>
        public static readonly Rectangle Empty = new();

        // Do not rename (binary serialization)
        private int x;
        // Do not rename (binary serialization)
        private int y;
        // Do not rename (binary serialization)
        private int width;
        // Do not rename (binary serialization)
        private int height; 

        /// <summary>
        /// Initializes a new instance of the <see cref='Rectangle'/> class with the specified location
        /// and size.
        /// </summary>
        public Rectangle(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        /// <summary>
        /// Initializes a new instance of the Rectangle class with the specified location and size.
        /// </summary>
        public Rectangle(Point location, Size size)
        {
            x = location.X;
            y = location.Y;
            width = size.Width;
            height = size.Height;
        }

        /// <summary>
        /// Creates a new <see cref='Rectangle'/> with the specified location and size.
        /// </summary>
        public static Rectangle FromLTRB(int left, int top, int right, int bottom) =>
            new(left, top, unchecked(right - left), unchecked(bottom - top));

        /// <summary>
        /// Gets or sets the coordinates of the upper-left corner of the rectangular region represented by this
        /// <see cref='Rectangle'/>.
        /// </summary>
        public Point Location
        {
            readonly get => new(X, Y);
            set
            {
                X = value.X;
                Y = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets the size of this <see cref='Rectangle'/>.
        /// </summary>
        public Size Size
        {
            readonly get => new(Width, Height);
            set
            {
                Width = value.Width;
                Height = value.Height;
            }
        }

        /// <summary>
        /// Gets or sets the x-coordinate of the upper-left corner of the rectangular region defined by this
        /// <see cref='Rectangle'/>.
        /// </summary>
        public int X
        {
            readonly get => x;
            set => x = value;
        }

        /// <summary>
        /// Gets or sets the y-coordinate of the upper-left corner of the rectangular region defined by this
        /// <see cref='Rectangle'/>.
        /// </summary>
        public int Y
        {
            readonly get => y;
            set => y = value;
        }

        /// <summary>
        /// Gets or sets the width of the rectangular region defined by this <see cref='Rectangle'/>.
        /// </summary>
        public int Width
        {
            readonly get => width;
            set => width = value;
        }

        /// <summary>
        /// Gets or sets the width of the rectangular region defined by this <see cref='Rectangle'/>.
        /// </summary>
        public int Height
        {
            readonly get => height;
            set => height = value;
        }

        /// <summary>
        /// Gets the x-coordinate of the upper-left corner of the rectangular region defined by this
        /// <see cref='Rectangle'/> .
        /// </summary>
        public readonly int Left => X;

        /// <summary>
        /// Gets the y-coordinate of the upper-left corner of the rectangular region defined by this
        /// <see cref='Rectangle'/>.
        /// </summary>
        public readonly int Top => Y;

        /// <summary>
        /// Gets the x-coordinate of the lower-right corner of the rectangular region defined by this
        /// <see cref='Rectangle'/>.
        /// </summary>
        public readonly int Right => unchecked(X + Width);

        /// <summary>
        /// Gets the y-coordinate of the lower-right corner of the rectangular region defined by this
        /// <see cref='Rectangle'/>.
        /// </summary>
        public readonly int Bottom => unchecked(Y + Height);

        /// <summary>
        /// Tests whether this <see cref='Rectangle'/> has a <see cref='Rectangle.Width'/>
        /// or a <see cref='Rectangle.Height'/> of 0.
        /// </summary>
        public readonly bool IsEmpty => height == 0 && width == 0 && x == 0 && y == 0;

        /// <summary>
        /// Tests whether <paramref name="other"/> is a <see cref='Rectangle'/> with the same location
        /// and size of this Rectangle.
        /// </summary>
        public readonly override bool Equals(object? other) => other is Rectangle rectangle && Equals(rectangle);

        /// <summary>
        /// Tests whether <paramref name="other"/> has the same location and size of this Rectangle.
        /// </summary>
        public readonly bool Equals(Rectangle other) => this == other;

        /// <summary>
        /// Tests whether two <see cref='Rectangle'/> objects have equal location and size.
        /// </summary>
        public static bool operator ==(Rectangle left, Rectangle right) =>
            left.X == right.X && left.Y == right.Y && left.Width == right.Width && left.Height == right.Height;

        /// <summary>
        /// Tests whether two <see cref='Rectangle'/> objects differ in location or size.
        /// </summary>
        public static bool operator !=(Rectangle left, Rectangle right) => !(left == right);

        /* TODO: Uncomment if RectangleF is copied over
        /// <summary>
        /// Converts a RectangleF to a Rectangle by performing a ceiling operation on all the coordinates.
        /// </summary>
        public static Rectangle Ceiling(RectangleF value)
        {
            unchecked
            {
                return new Rectangle(
                    (int)Math.Ceiling(value.X),
                    (int)Math.Ceiling(value.Y),
                    (int)Math.Ceiling(value.Width),
                    (int)Math.Ceiling(value.Height));
            }
        }

        /// <summary>
        /// Converts a RectangleF to a Rectangle by performing a truncate operation on all the coordinates.
        /// </summary>
        public static Rectangle Truncate(RectangleF value)
        {
            unchecked
            {
                return new Rectangle(
                    (int)value.X,
                    (int)value.Y,
                    (int)value.Width,
                    (int)value.Height);
            }
        }

        /// <summary>
        /// Converts a RectangleF to a Rectangle by performing a round operation on all the coordinates.
        /// </summary>
        public static Rectangle Round(RectangleF value)
        {
            unchecked
            {
                return new Rectangle(
                    (int)Math.Round(value.X),
                    (int)Math.Round(value.Y),
                    (int)Math.Round(value.Width),
                    (int)Math.Round(value.Height));
            }
        }
        */

        /// <summary>
        /// Determines if the specified point is contained within the rectangular region defined by this
        /// <see cref='Rectangle'/> .
        /// </summary>
        public readonly bool Contains(int x, int y) => X <= x && x < X + Width && Y <= y && y < Y + Height;

        /// <summary>
        /// Determines if the specified point is contained within the rectangular region defined by this
        /// <see cref='Rectangle'/> .
        /// </summary>
        public readonly bool Contains(Point pt) => Contains(pt.X, pt.Y);

        /// <summary>
        /// Determines if the rectangular region represented by <paramref name="rect"/> is entirely contained within the
        /// rectangular region represented by this <see cref='Rectangle'/> .
        /// </summary>
        public readonly bool Contains(Rectangle rect) =>
            (X <= rect.X) && (rect.X + rect.Width <= X + Width) &&
            (Y <= rect.Y) && (rect.Y + rect.Height <= Y + Height);

        /// <inheritdoc/>
        public readonly override int GetHashCode()
        {
            // Original: HashCode.Combine(X, Y, Width, Height);
            unchecked
            {
                return X.GetHashCode() ^ Y.GetHashCode() ^ Width.GetHashCode() ^ Height.GetHashCode();
            }
        }

        /// <summary>
        /// Inflates this <see cref='Rectangle'/> by the specified amount.
        /// </summary>
        public void Inflate(int width, int height)
        {
            unchecked
            {
                X -= width;
                Y -= height;

                Width += 2 * width;
                Height += 2 * height;
            }
        }

        /// <summary>
        /// Inflates this <see cref='Rectangle'/> by the specified amount.
        /// </summary>
        public void Inflate(Size size) => Inflate(size.Width, size.Height);

        /// <summary>
        /// Creates a <see cref='Rectangle'/> that is inflated by the specified amount.
        /// </summary>
        public static Rectangle Inflate(Rectangle rect, int x, int y)
        {
            var r = rect;
            r.Inflate(x, y);
            return r;
        }

        /// <summary>
        /// Creates a Rectangle that represents the intersection between this Rectangle and rect.
        /// </summary>
        public void Intersect(Rectangle rect)
        {
            var result = Intersect(rect, this);

            X = result.X;
            Y = result.Y;
            Width = result.Width;
            Height = result.Height;
        }

        /// <summary>
        /// Creates a rectangle that represents the intersection between a and b. If there is no intersection, an
        /// empty rectangle is returned.
        /// </summary>
        public static Rectangle Intersect(Rectangle a, Rectangle b)
        {
            int x1 = MathInternal.Max(a.X, b.X);
            int x2 = MathInternal.Min(a.X + a.Width, b.X + b.Width);
            int y1 = MathInternal.Max(a.Y, b.Y);
            int y2 = MathInternal.Min(a.Y + a.Height, b.Y + b.Height);

            if (x2 >= x1 && y2 >= y1)
            {
                return new Rectangle(x1, y1, x2 - x1, y2 - y1);
            }

            return Empty;
        }

        /// <summary>
        /// Determines if this rectangle intersects with rect.
        /// </summary>
        public readonly bool IntersectsWith(Rectangle rect) =>
            (rect.X < X + Width) && (X < rect.X + rect.Width) &&
            (rect.Y < Y + Height) && (Y < rect.Y + rect.Height);

        /// <summary>
        /// Creates a rectangle that represents the union between a and b.
        /// </summary>
        public static Rectangle Union(Rectangle a, Rectangle b)
        {
            // TODO: The documentation for Graphics says the Math library is required but it's not referenced at this time
            int x1 = MathInternal.Max(a.X, b.X);// Math.Max(a.X, b.X);
            int x2 = MathInternal.Min(a.X + a.Width, b.X + b.Width);// Math.Min(a.X + a.Width, b.X + b.Width);
            int y1 = MathInternal.Max(a.Y, b.Y);// Math.Max(a.Y, b.Y);
            int y2 = MathInternal.Min(a.Y + a.Height, b.Y + b.Height);// Math.Min(a.Y + a.Height, b.Y + b.Height);

            return new Rectangle(x1, y1, x2 - x1, y2 - y1);
        }

        /// <summary>
        /// Adjusts the location of this rectangle by the specified amount.
        /// </summary>
        public void Offset(Point pos) => Offset(pos.X, pos.Y);

        /// <summary>
        /// Adjusts the location of this rectangle by the specified amount.
        /// </summary>
        public void Offset(int x, int y)
        {
            unchecked
            {
                X += x;
                Y += y;
            }
        }

        /// <summary>
        /// Converts the attributes of this <see cref='Rectangle'/> to a human readable string.
        /// </summary>
        public readonly override string ToString() => $"{{X={X},Y={Y},Width={Width},Height={Height}}}";
    }
}
