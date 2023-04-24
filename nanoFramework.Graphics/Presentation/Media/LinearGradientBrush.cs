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
    /// Represents a linear gradient brush, which fills a shape with a gradient color
    /// that varies in a linear fashion between a start color and an end color.
    /// </summary>
    public sealed class LinearGradientBrush : Brush
    {
        /// <summary>
        /// Gets or sets the start color of the gradient brush.
        /// </summary>
        public Color StartColor;

        /// <summary>
        /// Gets or sets the end color of the gradient brush.
        /// </summary>
        public Color EndColor;

        /// <summary>
        /// Gets or sets the mapping mode of the gradient brush.
        /// </summary>
        public BrushMappingMode MappingMode = BrushMappingMode.RelativeToBoundingBox;

        /// <summary>
        /// Gets or sets the X-coordinate of the starting point of the gradient brush.
        /// </summary>
        public int StartX;

        /// <summary>
        /// Gets or sets the Y-coordinate of the starting point of the gradient brush.
        /// </summary>
        public int StartY;

        /// <summary>
        /// Gets or sets the X-coordinate of the ending point of the gradient brush.
        /// </summary>
        public int EndX;

        /// <summary>
        /// Gets or sets the Y-coordinate of the ending point of the gradient brush.
        /// </summary>
        public int EndY;

        /// <summary>
        /// The size of the bounding box used in the relative mapping mode.
        /// </summary>
        public const int RelativeBoundingBoxSize = 1000;

        /// <summary>
        /// Initializes a new instance of the LinearGradientBrush class
        /// with the specified start and end colors.
        /// </summary>
        /// <param name="startColor">The start color of the gradient brush.</param>
        /// <param name="endColor">The end color of the gradient brush.</param>
        public LinearGradientBrush(Color startColor, Color endColor)
            : this(startColor, endColor, 0, 0, RelativeBoundingBoxSize, RelativeBoundingBoxSize)
        { }

        /// <summary>
        /// Initializes a new instance of the LinearGradientBrush class
        /// with the specified start and end colors and starting and ending points.
        /// </summary>
        /// <param name="startColor">The start color of the gradient brush.</param>
        /// <param name="endColor">The end color of the gradient brush.</param>
        /// <param name="startX">The X-coordinate of the starting point of the gradient brush.</param>
        /// <param name="startY">The Y-coordinate of the starting point of the gradient brush.</param>
        /// <param name="endX">The X-coordinate of the ending point of the gradient brush.</param>
        /// <param name="endY">The Y-coordinate of the ending point of the gradient brush.</param>
        public LinearGradientBrush(Color startColor, Color endColor, int startX, int startY, int endX, int endY)
        {
            StartColor = startColor;
            EndColor = endColor;
            StartX = startX;
            StartY = startY;
            EndX = endX;
            EndY = endY;
        }

        /// <summary>
        /// Renders a rectangle using the current brush and pen.
        /// </summary>
        /// <param name="bmp">The bitmap on which to draw the rectangle.</param>
        /// <param name="pen">The pen to use for the rectangle's outline, or null for no outline.</param>
        /// <param name="x">The x-coordinate of the top-left corner of the rectangle.</param>
        /// <param name="y">The y-coordinate of the top-left corner of the rectangle.</param>
        /// <param name="width">The width of the rectangle.</param>
        /// <param name="height">The height of the rectangle.</param>
        protected internal override void RenderRectangle(Bitmap bmp, Pen pen, int x, int y, int width, int height)
        {
            Color outlineColor = (pen != null) ? pen.Color : Color.Black;
            ushort outlineThickness = (pen != null) ? pen.Thickness : (ushort)0;

            int x1, y1;
            int x2, y2;

            switch (MappingMode)
            {
                case BrushMappingMode.RelativeToBoundingBox:
                    x1 = x + (int)((long)(width - 1) * StartX / RelativeBoundingBoxSize);
                    y1 = y + (int)((long)(height - 1) * StartY / RelativeBoundingBoxSize);
                    x2 = x + (int)((long)(width - 1) * EndX / RelativeBoundingBoxSize);
                    y2 = y + (int)((long)(height - 1) * EndY / RelativeBoundingBoxSize);
                    break;
                default: //case BrushMappingMode.Absolute:
                    x1 = StartX;
                    y1 = StartY;
                    x2 = EndX;
                    y2 = EndY;
                    break;
            }

            bmp.DrawRectangle(outlineColor, outlineThickness, x, y, width, height, 0, 0,
                                          StartColor, x1, y1, EndColor, x2, y2, Opacity);
        }
    }
}
