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
    public class Polygon : Shape
    {
        /// <summary>
        /// 
        /// </summary>
        public Polygon()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pts"></param>
        public Polygon(int[] pts)
        {
            Points = pts;
        }

        /// <summary>
        /// 
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
        /// 
        /// </summary>
        /// <param name="dc"></param>
        public override void OnRender(Media.DrawingContext dc)
        {
            if (_pts != null)
            {
                dc.DrawPolygon(Fill, Stroke, _pts);
            }
        }

        private int[] _pts;
    }
}


