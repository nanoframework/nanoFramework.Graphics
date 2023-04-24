//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using System;

namespace nanoFramework.Presentation.Shapes
{
    /// <summary>
    /// Represents a rectangle shape.
    /// </summary>
    public class Rectangle : Shape
    {
        /// <summary>
        /// Initializes a new instance of the Rectangle class.
        /// </summary>
        public Rectangle()
        {
            Width = 0;
            Height = 0;
        }

        /// <summary>
        /// Initializes a new instance of the Rectangle class with the specified width and height.
        /// </summary>
        /// <param name="width">The width of the rectangle.</param>
        /// <param name="height">The height of the rectangle.</param>
        public Rectangle(int width, int height)
        {
            if (width < 0 || height < 0)
            {
                throw new ArgumentException();
            }

            Width = width;
            Height = height;
        }

        /// <summary>
        /// Renders the Rectangle shape.
        /// </summary>
        /// <param name="dc">The drawing context to use for rendering.</param>
        public override void OnRender(Media.DrawingContext dc)
        {
            int offset = Stroke != null ? Stroke.Thickness / 2 : 0;

            dc.DrawRectangle(Fill, Stroke, offset, offset, _renderWidth - 2 * offset, _renderHeight - 2 * offset);
        }
    }
}
