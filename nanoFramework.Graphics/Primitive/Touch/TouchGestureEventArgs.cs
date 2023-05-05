//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using System;

namespace nanoFramework.UI
{
    /// <summary>
    /// Represents the method that handles the TouchGesture event.
    /// </summary>
    /// <param name="sender">The object that raised the event.</param>
    /// <param name="e">A TouchGestureEventArgs object that contains the event data.</param>
    public delegate void TouchGestureEventHandler(object sender, TouchGestureEventArgs e);

    /// <summary>
    /// Represents the event data for a touch gesture event.
    /// </summary>
    public class TouchGestureEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the time when the gesture occurred.
        /// </summary>
        public readonly DateTime Timestamp;

        /// <summary>
        /// Gets or sets the type of gesture.
        /// </summary>
        public TouchGesture Gesture;

        /// <summary>
        /// Gets or sets the X-coordinate of the gesture center or start location.
        /// </summary>
        /// <remarks> X and Y form the center location of the gesture for multi-touch or the starting location for single touch.</remarks>
        public int X;

        /// <summary>
        /// Gets or sets the Y-coordinate of the gesture center or start location.
        /// </summary>
        /// <remarks> X and Y form the center location of the gesture for multi-touch or the starting location for single touch.</remarks>
        public int Y;

        /// <summary>
        /// Gets or sets the arguments associated with the gesture.
        /// </summary>
        /// <remarks>2 bytes for gesture-specific arguments.
        /// TouchGesture.Zoom: Arguments = distance between fingers
        /// TouchGesture.Rotate: Arguments = angle in degrees (0-360)
        /// </remarks>
        public ushort Arguments;

        /// <summary>
        /// Gets the angle of rotation for a Rotate gesture in degrees.
        /// </summary>
        public double Angle
        {
            get
            {
                return (double)(Arguments);
            }
        }
    }
}
