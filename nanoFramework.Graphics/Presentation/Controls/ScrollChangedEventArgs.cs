//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using System;
using nanoFramework.Runtime.Events;

namespace nanoFramework.Presentation.Controls
{
    /// <summary>
    /// Provides data for the ScrollChanged event.
    /// </summary>
    public class ScrollChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the amount of horizontal change in the scroll position.
        /// </summary>
        public readonly int HorizontalChange;

        /// <summary>
        /// Gets the horizontal offset of the scroll position.
        /// </summary>
        public readonly int HorizontalOffset;

        /// <summary>
        /// Gets the amount of vertical change in the scroll position.
        /// </summary>
        public readonly int VerticalChange;

        /// <summary>
        /// Gets the vertical offset of the scroll position.
        /// </summary>
        public readonly int VerticalOffset;

        /// <summary>
        /// Initializes a new instance of the ScrollChangedEventArgs class.
        /// </summary>
        /// <param name="offsetX">The horizontal offset of the scroll position.</param>
        /// <param name="offsetY">The vertical offset of the scroll position.</param>
        /// <param name="offsetChangeX">The amount of horizontal change in the scroll position.</param>
        /// <param name="offsetChangeY">The amount of vertical change in the scroll position.</param>
        public ScrollChangedEventArgs(int offsetX, int offsetY, int offsetChangeX, int offsetChangeY)
        {
            HorizontalOffset = offsetX;
            HorizontalChange = offsetChangeX;

            VerticalOffset = offsetY;
            VerticalChange = offsetChangeY;
        }
    }
}
