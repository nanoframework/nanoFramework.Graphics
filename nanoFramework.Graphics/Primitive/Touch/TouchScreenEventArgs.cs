//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using System;

namespace nanoFramework.UI
{
    /// <summary>
    /// Represents the method that handles the TouchScreen event.
    /// </summary>
    /// <param name="sender">The object that raised the event.</param>
    /// <param name="e">A TouchScreenEventArgs object that contains the event data.</param>
    public delegate void TouchScreenEventHandler(object sender, TouchScreenEventArgs e);

    /// <summary>
    /// Event arguments for touch screen events.
    /// </summary>
    public class TouchScreenEventArgs : EventArgs
    {
        // Fields
        /// <summary>
        /// Gets or sets an array of TouchInput structures, containing information about each touch point.
        /// </summary>
        public TouchInput[] Touches;

        /// <summary>
        /// Gets or sets the time stamp for the event.
        /// </summary>
        public DateTime TimeStamp;

        /// <summary>
        /// Gets or sets the target object for the event.
        /// </summary>
        public object Target;

        // Methods
        /// <summary>
        /// Initializes a new instance of the TouchScreenEventArgs class.
        /// </summary>
        /// <param name="timestamp">The time stamp for the event.</param>
        /// <param name="touches">An array of TouchInput structures containing information about each touch point.</param>
        /// <param name="target">The target object for the event.</param>
        public TouchScreenEventArgs(DateTime timestamp, TouchInput[] touches, object target)
        {
            Touches = touches;
            TimeStamp = timestamp;
            Target = target;
        }

        /// <summary>
        /// Gets the X and Y position of the touch point at the specified index.
        /// </summary>
        /// <param name="touchIndex">The index of the touch point to get the position for.</param>
        /// <param name="x">When this method returns, contains the X position of the touch point.</param>
        /// <param name="y">When this method returns, contains the Y position of the touch point.</param>
        public void GetPosition(int touchIndex, out int x, out int y)
        {
            x = Touches[touchIndex].X;
            y = Touches[touchIndex].Y;
        }
    }
}
