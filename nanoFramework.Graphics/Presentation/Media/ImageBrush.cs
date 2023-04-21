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
    /// Image Brush class.
    /// </summary>
    public sealed class ImageBrush : Brush
    {
        /// <summary>
        /// The source bitmap.
        /// </summary>
        public Bitmap BitmapSource;

        /// <summary>
        /// The stretch mode.
        /// </summary>
        public Stretch Stretch = Stretch.Fill;

        /// <summary>
        /// Creates a new instance of the ImageBrush class from a bitmap.
        /// </summary>
        /// <param name="bmp">The bitmap.</param>
        public ImageBrush(Bitmap bmp)
        {
            BitmapSource = bmp;
        }

        /// <summary>
        /// Render a rectangle.
        /// </summary>
        /// <param name="bmp"></param>
        /// <param name="pen"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
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


