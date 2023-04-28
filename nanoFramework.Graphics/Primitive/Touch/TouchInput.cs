//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using System;

namespace nanoFramework.UI
{
    /// <summary>
    /// Represents a single touch input on a touch-sensitive screen.
    /// </summary>
    public class TouchInput
    {
        /// <summary>
        /// Gets or sets the x-coordinate of the touch input.
        /// </summary>
        public int X;

        /// <summary>
        /// Gets or sets the y-coordinate of the touch input.
        /// </summary>
        public int Y;

        /// <summary>
        /// Gets or sets the source ID of the touch input.
        /// </summary>
        public byte SourceID;

        /// <summary>
        /// Gets or sets the flags associated with the touch input.
        /// </summary>
        public TouchInputFlags Flags;

        /// <summary>
        /// Gets or sets the width of the touch contact area.
        /// </summary>
        public uint ContactWidth;

        /// <summary>
        /// Gets or sets the height of the touch contact area.
        /// </summary>
        public uint ContactHeight;
    }
}
