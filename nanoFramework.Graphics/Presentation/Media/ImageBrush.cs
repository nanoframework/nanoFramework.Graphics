//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using nanoFramework.UI;
using System.Drawing;

namespace nanoFramework.Presentation.Media
{
    /// <summary>
    /// Represents a brush that paints an area with an image.
    /// </summary>
    public sealed class ImageBrush : Brush
    {
        /// <summary>
        /// Gets or sets the source bitmap for the brush.
        /// </summary>
        public Bitmap BitmapSource;

        /// <summary>
        /// Gets or sets the stretch mode for the brush.
        /// </summary>
        public Stretch Stretch = Stretch.Fill;

        /// <summary>
        /// Initializes a new instance of the ImageBrush class with the specified bitmap.
        /// </summary>
        /// <param name="bmp">The source bitmap for the brush.</param>
        public ImageBrush(Bitmap bmp)
        {
            BitmapSource = bmp;
        }

        /// <summary>
        /// Renders a rectangle using the brush.
        /// </summary>
        /// <param name="bmp">The bitmap to render the rectangle on.</param>
        /// <param name="pen">The pen used to outline the rectangle.</param>
        /// <param name="x">The x-coordinate of the upper-left corner of the rectangle.</param>
        /// <param name="y">The y-coordinate of the upper-left corner of the rectangle.</param>
        /// <param name="width">The width of the rectangle.</param>
        /// <param name="height">The height of the rectangle.</param>
        protected internal override void RenderRectangle(Bitmap bmp, Pen pen, int x, int y, int width, int height)
        {
            if (Stretch == Stretch.None)
            {
                bmp.DrawImage(x, y, BitmapSource, 0, 0, BitmapSource.Width, BitmapSource.Height, Opacity);
            }
            else if (width == BitmapSource.Width && height == BitmapSource.Height)
            {
                bmp.DrawImage(x, y, BitmapSource, 0, 0, width, height, Opacity);
            }
            else
            {
                bmp.StretchImage(x, y, BitmapSource, width, height, Opacity);
            }

            if (pen != null && pen.Thickness > 0)
            {
                bmp.DrawRectangle(pen.Color, pen.Thickness, x, y, width, height, 0, 0,
                                      Color.Black, 0, 0, Color.Black, 0, 0, 0);
            }
        }
    }
}
