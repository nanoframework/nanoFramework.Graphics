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
    public enum Direction
    {
        /// <summary>
        /// 
        /// </summary>
        TopToBottom,

        /// <summary>
        /// 
        /// </summary>
        BottomToTop
    }

    /// <summary>
    /// 
    /// </summary>
    public class Line : Shape
    {
        /// <summary>
        /// 
        /// </summary>
        public Line()
            : this(0, 0)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dx"></param>
        /// <param name="dy"></param>
        public Line(int dx, int dy)
        {
            if( dx < 0 || dy < 0)
            {
                throw new ArgumentException();
            }
            
            this.Width = dx + 1;
            this.Height = dy + 1;
        }

        /// <summary>
        /// 
        /// </summary>
        public Direction Direction
        {
            get
            {
                return _direction;
            }

            set
            {
                _direction = value;
                Invalidate();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dc"></param>
        public override void OnRender(Media.DrawingContext dc)
        {
            int width = this._renderWidth;
            int height = this._renderHeight;

            if (_direction == Direction.TopToBottom)
            {
                dc.DrawLine(Stroke, 0, 0, width - 1, height - 1);
            }
            else
            {
                dc.DrawLine(Stroke, 0, height - 1, width - 1, 0);
            }
        }

        private Direction _direction;
    }
}


