//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using System.Drawing;

namespace nanoFramework.Presentation.Media
{
    /// <summary>
    /// Defines a pen used for drawing lines and shapes.
    /// </summary>
    public class Pen
    {
        /// <summary>
        /// Gets or sets the color of the pen.
        /// </summary>
        public Color Color;

        /// <summary>
        /// Gets or sets the thickness of the pen in pixels.
        /// </summary>
        public ushort Thickness;

        /// <summary>
        /// Initializes a new instance of the Pen class with the specified color.
        /// </summary>
        /// <param name="color">The color of the pen.</param>
        public Pen(Color color)
            : this(color, 1)
        {
        }

        /// <summary>
        /// Initializes a new instance of the Pen class with the specified color and thickness.
        /// </summary>
        /// <param name="color">The color of the pen.</param>
        /// <param name="thickness">The thickness of the pen in pixels.</param>
        public Pen(Color color, ushort thickness)
        {
            Color = color;
            Thickness = thickness;
        }
    }
}
