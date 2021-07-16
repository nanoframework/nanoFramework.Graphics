//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace nanoFramework.Presentation.Media
{
    /// <summary>
    /// 
    /// </summary>
    public class Pen
    {
        /// <summary>
        /// 
        /// </summary>
        public Color Color;

        /// <summary>
        /// 
        /// </summary>
        public ushort Thickness;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="color"></param>
        public Pen(Color color)
            : this(color, 1)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="color"></param>
        /// <param name="thickness"></param>
        public Pen(Color color, ushort thickness)
        {
            Color = color;
            Thickness = thickness;
        }
    }
}


