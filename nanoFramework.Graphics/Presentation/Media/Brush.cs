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
    /// 
    /// </summary>
    public abstract class Brush
    {
        private ushort _opacity = Bitmap.OpacityOpaque;

        /// <summary>
        /// 
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
        /// 
        /// </summary>
        /// <param name="bmp"></param>
        /// <param name="outline"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        protected internal abstract void RenderRectangle(Bitmap bmp, Pen outline, int x, int y, int width, int height);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bmp"></param>
        /// <param name="outline"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="xRadius"></param>
        /// <param name="yRadius"></param>
        protected internal virtual void RenderEllipse(Bitmap bmp, Pen outline, int x, int y, int xRadius, int yRadius)
        {
            throw new NotSupportedException("RenderEllipse is not supported with this brush.");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bmp"></param>
        /// <param name="outline"></param>
        /// <param name="pts"></param>
        protected internal virtual void RenderPolygon(Bitmap bmp, Pen outline, int[] pts)
        {
            throw new NotSupportedException("RenderPolygon is not supported with this brush.");
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public enum BrushMappingMode
    {
        /// <summary>
        /// 
        /// </summary>
        Absolute,

        /// <summary>
        /// 
        /// </summary>
        RelativeToBoundingBox
    }
}
