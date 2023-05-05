//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using System;

namespace nanoFramework.Presentation.Shapes
{
    /// <summary>
    /// Represents a line shape that can be rendered on a display.
    /// </summary>
    public class Line : Shape
    {
        private Direction _direction;

        /// <summary>
        /// Initializes a new instance of the Line class with default values.
        /// </summary>
        public Line()
            : this(0, 0)
        {
        }

        /// <summary>
        /// Initializes a new instance of the Line class with the specified dimensions.
        /// </summary>
        /// <param name="dx">The width of the line.</param>
        /// <param name="dy">The height of the line.</param>
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
        /// Gets or sets the direction of the line.
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
        /// Renders the line shape using the specified DrawingContext object.
        /// </summary>
        /// <param name="dc">The DrawingContext object to use for rendering.</param>
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
    }
}
