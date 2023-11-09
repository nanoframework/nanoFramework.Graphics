//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System.Drawing
{
    /// <summary>
    /// Enum for specifying the order in which color components are arranged in a pixel.
    /// </summary>
    public enum ColorOrder
    {
        /// <summary>
        /// Red-Green-Blue (RGB) order.
        /// </summary>
        Rgb = 0,

        /// <summary>
        /// Blue-Green-Red (BGR) order.
        /// </summary>
        Bgr = 1,

        /// <summary>
        /// Blue-Red-Green (BRG) order.
        /// </summary>
        Brg = 2,

        /// <summary>
        /// Green-Blue-Red (GBR) order.
        /// </summary>
        Gbr = 3,

        /// <summary>
        /// Red-Blue-Green (RBG) order.
        /// </summary>
        Rbg = 4,

        /// <summary>
        /// Green-Red-Blue (GRB) order.
        /// </summary>
        Grb = 5
    }
}
