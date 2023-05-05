//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using System;

namespace nanoFramework.Presentation.Shapes
{
    /// <summary>
    /// Defines an ellipse shape.
    /// </summary>
    public class Ellipse : Shape
    {
        /// <summary>
        /// Initializes a new instance of the Ellipse class with the specified radii.
        /// </summary>
        /// <param name="xRadius">The x-radius of the ellipse.</param>
        /// <param name="yRadius">The y-radius of the ellipse.</param>
        /// <exception cref="ArgumentException">Thrown when either radius is less than zero.</exception>
        public Ellipse(int xRadius, int yRadius)
        {
            if( xRadius < 0 || yRadius < 0)                
            {
                throw new ArgumentException();
            }
            
            this.Width = xRadius * 2 + 1;
            this.Height = yRadius * 2 + 1;
        }

        /// <summary>
        /// Draws the ellipse on a Media.DrawingContext.
        /// </summary>
        /// <param name="dc">The Media.DrawingContext on which to draw the ellipse.</param>
        public override void OnRender(Media.DrawingContext dc)
        {
            // Make room for cases when strokes are thick.
            int x = _renderWidth / 2 + Stroke.Thickness - 1;
            int y = _renderHeight / 2 + Stroke.Thickness - 1;
            int w = _renderWidth / 2 - (Stroke.Thickness - 1) * 2;
            int h = _renderHeight / 2 - (Stroke.Thickness - 1) * 2;

            dc.DrawEllipse(Fill, Stroke, x, y, w, h);
        }
    }
}
