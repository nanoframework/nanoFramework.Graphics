//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using System;
using nanoFramework.UI;

namespace nanoFramework.Presentation.Media
{
    /// <summary>
    /// Represents a brush object used to fill shapes with a color or pattern.
    /// </summary>
    public abstract class Brush
    {
        private ushort _opacity = Bitmap.OpacityOpaque;

        /// <summary>
        /// Gets or sets the opacity of the brush.
        /// </summary>
        public ushort Opacity
        {
            get
            {
                return _opacity;
            }

            set
            {
                // clip values              
                if (value > Bitmap.OpacityOpaque) value = Bitmap.OpacityOpaque;

                _opacity = value;
            }
        }

        /// <summary>
        /// Renders a rectangle using the brush.
        /// </summary>
        /// <param name="bmp">The bitmap to render to.</param>
        /// <param name="outline">The pen used to outline the rectangle.</param>
        /// <param name="x">The x-coordinate of the rectangle.</param>
        /// <param name="y">The y-coordinate of the rectangle.</param>
        /// <param name="width">The width of the rectangle.</param>
        /// <param name="height">The height of the rectangle.</param>
        protected internal abstract void RenderRectangle(Bitmap bmp, Pen outline, int x, int y, int width, int height);

        /// <summary>
        /// Renders an ellipse using the brush.
        /// </summary>
        /// <param name="bmp">The bitmap to render to.</param>
        /// <param name="outline">The pen used to outline the ellipse.</param>
        /// <param name="x">The x-coordinate of the ellipse.</param>
        /// <param name="y">The y-coordinate of the ellipse.</param>
        /// <param name="xRadius">The x-radius of the ellipse.</param>
        /// <param name="yRadius">The y-radius of the ellipse.</param>
        protected internal virtual void RenderEllipse(Bitmap bmp, Pen outline, int x, int y, int xRadius, int yRadius)
        {
            throw new NotSupportedException("RenderEllipse is not supported with this brush.");
        }

        /// <summary>
        /// Renders a polygon using the brush.
        /// </summary>
        /// <param name="bmp">The bitmap to render to.</param>
        /// <param name="outline">The pen used to outline the polygon.</param>
        /// <param name="pts">The points that define the polygon.</param>
        protected internal virtual void RenderPolygon(Bitmap bmp, Pen outline, int[] pts)
        {
            throw new NotSupportedException("RenderPolygon is not supported with this brush.");
        }
    }
}
