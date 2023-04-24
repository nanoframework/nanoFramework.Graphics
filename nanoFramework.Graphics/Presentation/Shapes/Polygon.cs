//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using System;

namespace nanoFramework.Presentation.Shapes
{
    /// <summary>
    /// Represents a polygon shape.
    /// </summary>
    public class Polygon : Shape
    {
        private int[] _pts;

        /// <summary>
        /// Initializes a new instance of the <see cref="Polygon"/> class.
        /// </summary>
        public Polygon()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Polygon"/> class with the specified points.
        /// </summary>
        /// <param name="pts">The points of the polygon.</param>
        public Polygon(int[] pts)
        {
            Points = pts;
        }

        /// <summary>
        /// Gets or sets the points of the polygon.
        /// </summary>
        public int[] Points
        {
            get
            {
                return _pts;
            }

            set
            {
                if(value == null || value.Length == 0)
                {
                    throw new ArgumentException();
                }
                
                _pts = value;

                InvalidateMeasure();
            }
        }

        /// <summary>
        /// Renders the polygon on the specified drawing context.
        /// </summary>
        /// <param name="dc">The drawing context.</param>
        public override void OnRender(Media.DrawingContext dc)
        {
            if (_pts != null)
            {
                dc.DrawPolygon(Fill, Stroke, _pts);
            }
        }        
    }
}
