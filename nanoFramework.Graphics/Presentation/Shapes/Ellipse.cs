//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using System;

namespace nanoFramework.Presentation.Shapes
{
    /// <summary>
    /// 
    /// </summary>
    public class Ellipse : Shape
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="xRadius"></param>
        /// <param name="yRadius"></param>
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
        /// 
        /// </summary>
        /// <param name="dc"></param>
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
