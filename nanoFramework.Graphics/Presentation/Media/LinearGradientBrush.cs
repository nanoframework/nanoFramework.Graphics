//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using nanoFramework.UI;

namespace nanoFramework.Presentation.Media
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class LinearGradientBrush : Brush
    {
        /// <summary>
        /// 
        /// </summary>
        public Color StartColor;
        /// <summary>
        /// 
        /// </summary>
        public Color EndColor;

        /// <summary>
        /// 
        /// </summary>
        public BrushMappingMode MappingMode = BrushMappingMode.RelativeToBoundingBox;

        /// <summary>
        /// 
        /// </summary>
        public int StartX, StartY;

        /// <summary>
        /// 
        /// </summary>
        public int EndX, EndY;

        /// <summary>
        /// 
        /// </summary>
        public const int RelativeBoundingBoxSize = 1000;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startColor"></param>
        /// <param name="endColor"></param>
        public LinearGradientBrush(Color startColor, Color endColor)
            : this(startColor, endColor, 0, 0, RelativeBoundingBoxSize, RelativeBoundingBoxSize)
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startColor"></param>
        /// <param name="endColor"></param>
        /// <param name="startX"></param>
        /// <param name="startY"></param>
        /// <param name="endX"></param>
        /// <param name="endY"></param>
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
        /// 
        /// </summary>
        /// <param name="bmp"></param>
        /// <param name="pen"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        protected internal override void RenderRectangle(Bitmap bmp, Pen pen, int x, int y, int width, int height)
        {
            Color outlineColor = (pen != null) ? pen.Color : (Color)0x0;
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


