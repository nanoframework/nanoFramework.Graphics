//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using nanoFramework.UI;
using System;
using System.Collections;
using nanoFramework.UI.Threading;
using System.Drawing;

namespace nanoFramework.Presentation.Media
{
    /// <summary>
    /// Drawing Context.
    /// </summary>
    public class DrawingContext : DispatcherObject, IDisposable
    {
        private Bitmap _bitmap;
        private Stack _clippingRectangles = new Stack();

        internal bool EmptyClipRect = false;     
        internal int _x;
        internal int _y;        

        /// <summary>
        /// Creates a drawing context for the specified bitmap.
        /// </summary>
        /// <param name="bmp">The bitmap.</param>
        public DrawingContext(Bitmap bmp)
        {
            _bitmap = bmp;
        }

        /// <summary>
        /// Creates a drawing context for an empty bitmap of a specific width and height.
        /// </summary>
        /// <param name="width">The target width of the bitmap.</param>
        /// <param name="height">The target height of the bitmap.</param>
        public DrawingContext(int width, int height)
        {
            _bitmap = new Bitmap(width, height);
        }

        /// <summary>
        /// Translates the drawing context by a specified amount.
        /// </summary>
        /// <param name="dx">The amount to translate in the x direction.</param>
        /// <param name="dy">The amount to translate in the y direction.</param>
        public void Translate(int dx, int dy)
        {
            VerifyAccess();

            _x += dx;
            _y += dy;
        }

        /// <summary>
        /// Retrieves the current translation of the drawing context.
        /// </summary>
        /// <param name="x">Receives the x component of the translation.</param>
        /// <param name="y">Receives the y component of the translation.</param>
        public void GetTranslation(out int x, out int y)
        {
            VerifyAccess();

            x = _x;
            y = _y;
        }

        /// <summary>
        /// Gets the bitmap associated with this drawing context.
        /// </summary>
        public Bitmap Bitmap
        {
            get
            {
                VerifyAccess();

                return _bitmap;
            }
        }

        /// <summary>
        /// Clears the bitmap associated with this drawing context.
        /// </summary>
        public void Clear()
        {
            VerifyAccess();

            _bitmap.Clear();
        }

        internal void Close()
        {
            _bitmap = null;
        }

        /// <summary>
        /// Draws a polygon with the specified brush and pen.
        /// </summary>
        /// <param name="brush">The brush to use to fill the polygon.</param>
        /// <param name="pen">The pen to use to draw the polygon edges.</param>
        /// <param name="pts">The points that define the vertices of the polygon.</param>
        public void DrawPolygon(Brush brush, Pen pen, int[] pts)
        {
            VerifyAccess();

            brush.RenderPolygon(_bitmap, pen, pts);

            int nPts = pts.Length / 2;

            for (int i = 0; i < nPts - 1; i++)
            {
                DrawLine(pen, pts[i * 2], pts[i * 2 + 1], pts[i * 2 + 2], pts[i * 2 + 3]);
            }

            if (nPts > 2)
            {
                DrawLine(pen, pts[nPts * 2 - 2], pts[nPts * 2 - 1], pts[0], pts[1]);
            }
        }

        /// <summary>
        /// Sets the pixel at the specified coordinates to the specified color.
        /// </summary>
        /// <param name="color">The color to set the pixel to.</param>
        /// <param name="x">The x-coordinate of the pixel.</param>
        /// <param name="y">The y-coordinate of the pixel.</param>
        public void SetPixel(Color color, int x, int y)
        {
            VerifyAccess();

            _bitmap.SetPixel(_x + x, _y + y, color);
        }

        /// <summary>
        /// Draws a line with the specified pen between the specified points.
        /// </summary>
        /// <param name="pen">The pen to use to draw the line.</param>
        /// <param name="x0">The x-coordinate of the start point of the line.</param>
        /// <param name="y0">The y-coordinate of the start point of the line.</param>
        /// <param name="x1">The x-coordinate of the end point of the line.</param>
        /// <param name="y1">The y-coordinate of the end point of the line.</param>
        public void DrawLine(Pen pen, int x0, int y0, int x1, int y1)
        {
            VerifyAccess();

            if (pen != null)
            {
                _bitmap.DrawLine(pen.Color, pen.Thickness, _x + x0, _y + y0, _x + x1, _y + y1);
            }
        }

        /// <summary>
        /// Draws an ellipse on the bitmap with the specified brush, pen, location, and radii.
        /// </summary>
        /// <param name="brush">The brush to fill the ellipse with.</param>
        /// <param name="pen">The pen used to draw the outline of the ellipse.</param>
        /// <param name="x">The x-coordinate of the upper-left corner of the ellipse.</param>
        /// <param name="y">The y-coordinate of the upper-left corner of the ellipse.</param>
        /// <param name="xRadius">The x-radius of the ellipse.</param>
        /// <param name="yRadius">The y-radius of the ellipse.</param>
        public void DrawEllipse(Brush brush, Pen pen, int x, int y, int xRadius, int yRadius)
        {
            VerifyAccess();

            // Fill
            if (brush != null)
            {
                brush.RenderEllipse(_bitmap, pen, _x + x, _y + y, xRadius, yRadius);
            }

            // Pen
            else if (pen != null && pen.Thickness > 0)
            {
                _bitmap.DrawEllipse(pen.Color, pen.Thickness, _x + x, _y + y, xRadius, yRadius,
                    Color.Black, 0, 0, Color.Black, 0, 0, 0);
            }

        }

        /// <summary>
        /// Draws an image on the bitmap at the specified location.
        /// </summary>
        /// <param name="source">The bitmap to draw.</param>
        /// <param name="x">The x-coordinate of the upper-left corner of the image.</param>
        /// <param name="y">The y-coordinate of the upper-left corner of the image.</param>
        public void DrawImage(Bitmap source, int x, int y)
        {
            VerifyAccess();

            _bitmap.DrawImage(_x + x, _y + y, source, 0, 0, source.Width, source.Height);
        }

        /// <summary>
        /// Draws a portion of the specified image on the bitmap at the specified location and with the specified size.
        /// </summary>
        /// <param name="source">The bitmap to draw a portion of.</param>
        /// <param name="destinationX">The x-coordinate of the upper-left corner of the destination rectangle.</param>
        /// <param name="destinationY">The y-coordinate of the upper-left corner of the destination rectangle.</param>
        /// <param name="sourceX">The x-coordinate of the upper-left corner of the source rectangle.</param>
        /// <param name="sourceY">The y-coordinate of the upper-left corner of the source rectangle.</param>
        /// <param name="sourceWidth">The width of the source rectangle.</param>
        /// <param name="sourceHeight">The height of the source rectangle.</param>
        public void DrawImage(Bitmap source, int destinationX, int destinationY, int sourceX, int sourceY, int sourceWidth, int sourceHeight)
        {
            VerifyAccess();

            _bitmap.DrawImage(_x + destinationX, _y + destinationY, source, sourceX, sourceY, sourceWidth, sourceHeight);
        }

        /// <summary>
        /// Blends the specified source image onto the current bitmap at the specified location.
        /// </summary>
        /// <param name="source">The source image to blend onto the current bitmap.</param>
        /// <param name="destinationX">The x-coordinate of the upper-left corner of the destination rectangle.</param>
        /// <param name="destinationY">The y-coordinate of the upper-left corner of the destination rectangle.</param>
        /// <param name="sourceX">The x-coordinate of the upper-left corner of the source rectangle.</param>
        /// <param name="sourceY">The y-coordinate of the upper-left corner of the source rectangle.</param>
        /// <param name="sourceWidth">The width of the source rectangle.</param>
        /// <param name="sourceHeight">The height of the source rectangle.</param>
        /// <param name="opacity">The opacity of the blended image, where 0 is completely transparent and 256 is completely opaque.</param>
        public void BlendImage(Bitmap source, int destinationX, int destinationY, int sourceX, int sourceY, int sourceWidth, int sourceHeight, ushort opacity)
        {
            VerifyAccess();

            _bitmap.DrawImage(_x + destinationX, _y + destinationY, source, sourceX, sourceY, sourceWidth, sourceHeight, opacity);
        }

        /// <summary>
        /// Rotates the specified source image by the specified angle and blends it onto the current bitmap at the specified location.
        /// </summary>
        /// <param name="angle">The angle to rotate the source image, in degrees.</param>
        /// <param name="destinationX">The x-coordinate of the upper-left corner of the destination rectangle.</param>
        /// <param name="destinationY">The y-coordinate of the upper-left corner of the destination rectangle.</param>
        /// <param name="bitmap">The source image to rotate and blend onto the current bitmap.</param>
        /// <param name="sourceX">The x-coordinate of the upper-left corner of the source rectangle.</param>
        /// <param name="sourceY">The y-coordinate of the upper-left corner of the source rectangle.</param>
        /// <param name="sourceWidth">The width of the source rectangle.</param>
        /// <param name="sourceHeight">The height of the source rectangle.</param>
        /// <param name="opacity">The opacity of the blended image, where 0 is completely transparent and 256 is completely opaque.</param>
        public void RotateImage(int angle, int destinationX, int destinationY, Bitmap bitmap, int sourceX, int sourceY, int sourceWidth, int sourceHeight, ushort opacity)
        {
            VerifyAccess();

            _bitmap.RotateImage(angle, _x + destinationX, _y + destinationY, bitmap, sourceX, sourceY, sourceWidth, sourceHeight, opacity);
        }

        /// <summary>
        /// Draws an image on the display, stretching it to fit the specified destination rectangle.
        /// </summary>
        /// <param name="xDst">The x-coordinate of the upper-left corner of the destination rectangle.</param>
        /// <param name="yDst">The y-coordinate of the upper-left corner of the destination rectangle.</param>
        /// <param name="widthDst">The width of the destination rectangle.</param>
        /// <param name="heightDst">The height of the destination rectangle.</param>
        /// <param name="bitmap">The source bitmap to draw.</param>
        /// <param name="xSrc">The x-coordinate of the upper-left corner of the portion of the source bitmap to draw.</param>
        /// <param name="ySrc">The y-coordinate of the upper-left corner of the portion of the source bitmap to draw.</param>
        /// <param name="widthSrc">The width of the portion of the source bitmap to draw.</param>
        /// <param name="heightSrc">The height of the portion of the source bitmap to draw.</param>
        /// <param name="opacity">The opacity of the image to draw, where 0 is fully transparent and 256 is fully opaque.</param>
        public void StretchImage(int xDst, int yDst, int widthDst, int heightDst, Bitmap bitmap, int xSrc, int ySrc, int widthSrc, int heightSrc, ushort opacity)
        {
            VerifyAccess();

            _bitmap.StretchImage(_x + xDst, _y + yDst, widthDst, heightDst, bitmap, xSrc, ySrc, widthSrc, heightSrc, opacity);
        }

        /// <summary>
        /// Draws an image repeatedly on the display, tiling it to fill the specified rectangle.
        /// </summary>
        /// <param name="xDst">The x-coordinate of the upper-left corner of the destination rectangle.</param>
        /// <param name="yDst">The y-coordinate of the upper-left corner of the destination rectangle.</param>
        /// <param name="bitmap">The source bitmap to tile.</param>
        /// <param name="width">The width of the destination rectangle.</param>
        /// <param name="height">The height of the destination rectangle.</param>
        /// <param name="opacity">The opacity of the image to draw, where 0 is fully transparent and 256 is fully opaque.</param>
        public void TileImage(int xDst, int yDst, Bitmap bitmap, int width, int height, ushort opacity)
        {
            VerifyAccess();

            _bitmap.TileImage(_x + xDst, _y + yDst, bitmap, width, height, opacity);
        }

        /// <summary>
        /// Draws a scalable nine-patch image on the display, scaling the middle section to fit the specified rectangle.
        /// </summary>
        /// <param name="xDst">The x-coordinate of the upper-left corner of the destination rectangle.</param>
        /// <param name="yDst">The y-coordinate of the upper-left corner of the destination rectangle.</param>
        /// <param name="widthDst">The width of the destination rectangle.</param>
        /// <param name="heightDst">The height of the destination rectangle.</param>
        /// <param name="bitmap">The source bitmap to draw.</param>
        /// <param name="leftBorder">The width of the left border.</param>
        /// <param name="topBorder">The height of the top border.</param>
        /// <param name="rightBorder">The width of the right border.</param>
        /// <param name="bottomBorder">The height of the bottom border.</param>
        /// <param name="opacity">The opacity of the image to draw, where 0 is fully transparent and 256 is fully opaque.</param>
        public void Scale9Image(int xDst, int yDst, int widthDst, int heightDst, Bitmap bitmap, int leftBorder, int topBorder, int rightBorder, int bottomBorder, ushort opacity)
        {
            VerifyAccess();

            _bitmap.Scale9Image(_x + xDst, _y + yDst, widthDst, heightDst, bitmap, leftBorder, topBorder, rightBorder, bottomBorder, opacity);
        }

        /// <summary>
        /// Draws a text string with the specified font and color at the specified position.
        /// </summary>
        /// <param name="text">The text string to draw.</param>
        /// <param name="font">The font used to draw the text.</param>
        /// <param name="color">The color used to draw the text.</param>
        /// <param name="x">The x-coordinate of the upper-left corner of the text string.</param>
        /// <param name="y">The y-coordinate of the upper-left corner of the text string.</param>
        public void DrawText(string text, Font font, Color color, int x, int y)
        {
            VerifyAccess();

            _bitmap.DrawText(text, font, color, _x + x, _y + y);
        }

        /// <summary>
        /// Draws a text string with the specified font, color, width, and height at the specified position.
        /// </summary>
        /// <param name="text">The text string to draw.</param>
        /// <param name="font">The font used to draw the text.</param>
        /// <param name="color">The color used to draw the text.</param>
        /// <param name="x">The x-coordinate of the upper-left corner of the text string.</param>
        /// <param name="y">The y-coordinate of the upper-left corner of the text string.</param>
        /// <param name="width">The width of the text string.</param>
        /// <param name="height">The height of the text string.</param>
        /// <param name="alignment">The horizontal alignment of the text within the bounding rectangle.</param>
        /// <param name="trimming">The text trimming style to be applied to the text string.</param>
        /// <returns>True if the text string was drawn successfully; otherwise, false.</returns>
        public bool DrawText(ref string text, Font font, Color color, int x, int y, int width, int height,
                             TextAlignment alignment, TextTrimming trimming)
        {
            VerifyAccess();

            DrawTextOptions flags = DrawTextOptions.WordWrap;

            // Text alignment
            switch (alignment)
            {
                case TextAlignment.Left:
                    //flags |= Bitmap.DT_AlignmentLeft;
                    break;
                case TextAlignment.Center:
                    flags |= DrawTextOptions.AlignmentCenter;
                    break;
                case TextAlignment.Right:
                    flags |= DrawTextOptions.AlignmentRight;
                    break;
                default:
                    throw new NotSupportedException();
            }

            // Trimming
            switch (trimming)
            {
                case TextTrimming.CharacterEllipsis:
                    flags |= DrawTextOptions.TrimmingCharacterEllipsis;
                    break;
                case TextTrimming.WordEllipsis:
                    flags |= DrawTextOptions.TrimmingWordEllipsis;
                    break;
            }

            int xRelStart = 0;
            int yRelStart = 0;
            return _bitmap.DrawTextInRect(ref text, ref xRelStart, ref yRelStart, _x + x, _y + y,
                                           width, height, (uint)flags, color, font);
        }

        /// <summary>
        /// Gets the clipping rectangle for the current context.
        /// </summary>
        /// <param name="x">The x-coordinate of the clipping rectangle.</param>
        /// <param name="y">The y-coordinate of the clipping rectangle.</param>
        /// <param name="width">The width of the clipping rectangle.</param>
        /// <param name="height">The height of the clipping rectangle.</param>
        public void GetClippingRectangle(out int x, out int y, out int width, out int height)
        {
            if (_clippingRectangles.Count == 0)
            {
                x = 0;
                y = 0;
                width = _bitmap.Width - _x;
                height = _bitmap.Height - _y;
            }
            else
            {
                ClipRectangle rect = (ClipRectangle)_clippingRectangles.Peek();
                x = rect.X - _x;
                y = rect.Y - _y;
                width = rect.Width;
                height = rect.Height;
            }
        }

        /// <summary>
        /// Pushes a new clipping rectangle onto the stack.
        /// </summary>
        /// <param name="x">The x-coordinate of the clipping rectangle.</param>
        /// <param name="y">The y-coordinate of the clipping rectangle.</param>
        /// <param name="width">The width of the clipping rectangle.</param>
        /// <param name="height">The height of the clipping rectangle.</param>
        public void PushClippingRectangle(int x, int y, int width, int height)
        {
            VerifyAccess();

            if (width < 0 || height < 0)
            {
                throw new ArgumentException();
            }

            ClipRectangle rect = new ClipRectangle(_x + x, _y + y, width, height);

            if (_clippingRectangles.Count > 0)
            {
                // Intersect with the existing clip bounds
                ClipRectangle previousRect = (ClipRectangle)_clippingRectangles.Peek();
                //need to evaluate performance differences of inlining Min & Max(
                int x1 = Mathematics.Max(rect.X, previousRect.X);
                int x2 = Mathematics.Min(rect.X + rect.Width, previousRect.X + previousRect.Width);
                int y1 = Mathematics.Max(rect.Y, previousRect.Y);
                int y2 = Mathematics.Min(rect.Y + rect.Height, previousRect.Y + previousRect.Height);

                rect.X = x1;
                rect.Y = y1;
                rect.Width = x2 - x1;
                rect.Height = y2 - y1;
            }

            _clippingRectangles.Push(rect);

            _bitmap.SetClippingRectangle(rect.X, rect.Y, rect.Width, rect.Height);
            EmptyClipRect = (rect.Width <= 0 || rect.Height <= 0);
        }

        /// <summary>
        /// Pops the top clipping rectangle from the stack.
        /// </summary>
        public void PopClippingRectangle()
        {
            VerifyAccess();

            int n = _clippingRectangles.Count;

            if (n > 0)
            {
                _clippingRectangles.Pop();

                ClipRectangle rect;

                if (n == 1) // in this case, at this point the stack is empty
                {
                    rect = new ClipRectangle(0, 0, _bitmap.Width, _bitmap.Height);
                }
                else
                {
                    rect = (ClipRectangle)_clippingRectangles.Peek();
                }

                _bitmap.SetClippingRectangle(rect.X, rect.Y, rect.Width, rect.Height);

                EmptyClipRect = (rect.Width == 0 && rect.Height == 0);
            }
        }

        /// <summary>
        /// Draws a rectangle onto the bitmap using the specified brush and pen.
        /// </summary>
        /// <param name="brush">The brush to use for filling the rectangle.</param>
        /// <param name="pen">The pen to use for outlining the rectangle.</param>
        /// <param name="x">The x-coordinate of the top-left corner of the rectangle.</param>
        /// <param name="y">The y-coordinate of the top-left corner of the rectangle.</param>
        /// <param name="width">The width of the rectangle.</param>
        /// <param name="height">The height of the rectangle.</param>
        public void DrawRectangle(Brush brush, Pen pen, int x, int y, int width, int height)
        {
            VerifyAccess();

            // Fill
            //
            if (brush != null)
            {
                brush.RenderRectangle(_bitmap, pen, _x + x, _y + y, width, height);
            }

            // Pen
            else if (pen != null && pen.Thickness > 0)
            {
                _bitmap.DrawRectangle(pen.Color, pen.Thickness, _x + x, _y + y, width, height, 0, 0,
                                      Color.Black, 0, 0, Color.Black, 0, 0, 0);
            }
        }

        /// <summary>
        /// Gets the width of the bitmap.
        /// </summary>
        public int Width
        {
            get
            {
                return _bitmap.Width;
            }
        }

        /// <summary>
        /// Gets the height of the bitmap.
        /// </summary>
        public int Height
        {
            get
            {
                return _bitmap.Height;
            }
        }

        private class ClipRectangle
        {
            public ClipRectangle(int x, int y, int width, int height)
            {
                X = x;
                Y = y;
                Width = width;
                Height = height;
            }

            public int X;
            public int Y;
            public int Width;
            public int Height;
        }

        /// <summary>
        /// Disposes of the bitmap and frees up any resources used by the object.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes of the bitmap and frees up any resources used by the object.
        /// </summary>
        /// <param name="disposing">True for disposing.</param>
        protected virtual void Dispose(bool disposing)
        {
            _bitmap = null;
        }
    }
}
