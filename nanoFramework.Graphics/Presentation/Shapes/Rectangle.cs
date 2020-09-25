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
    public class Rectangle : Shape
    {
        /// <summary>
        /// 
        /// </summary>
        public Rectangle()
        {
            Width = 0;
            Height = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public Rectangle(int width, int height)
        {
            if( width < 0 || height < 0)                
            {
                throw new ArgumentException();
            }
            
            Width = width;
            Height = height;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dc"></param>
        public override void OnRender(Media.DrawingContext dc)
        {
            int offset = Stroke != null ? Stroke.Thickness / 2 : 0;
            
            dc.DrawRectangle(Fill, Stroke, offset, offset, _renderWidth - 2 * offset, _renderHeight - 2 * offset);
        }
    }
}
