//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace nanoFramework.UI
{
    /// <summary>An enum representing a touch gesture.</summary>
    public enum TouchGesture : uint
    {
        // Can be used to represent an error gesture or unknown gesture
        /// <summary>Represents an unknown or error gesture.</summary>
        NoGesture = 0,

        // Standard Win7 Gestures
        /// <summary> Identifies the beginning of a gesture sequence.</summary>
        Begin = 1,
        /// <summary>Identifies the end of a gesture sequence. Fired when last finger involved in a gesture is removed.</summary>
        End = 2,

        // Standard stylus (single touch) gestues
        /// <summary>Stylus gesture: Right.</summary>
        Right = 3,
        /// <summary>Stylus gesture: Up-Right.</summary>
        UpRight = 4,
        /// <summary>Stylus gesture: Up.</summary>
        Up = 5,
        /// <summary>Stylus gesture: Up-Left.</summary>
        UpLeft = 6,
        /// <summary>Stylus gesture: Left.</summary>
        Left = 7,
        /// <summary>Stylus gesture: Down-Left.</summary>
        DownLeft = 8,
        /// <summary>Stylus gesture: Down.</summary>
        Down = 9,
        /// <summary>Stylus gesture: Down-Right.</summary>
        DownRight = 10,
        /// <summary>Stylus gesture: Tap.</summary>
        Tap = 11,
        /// <summary>Stylus gesture: Double Tap.</summary>
        DoubleTap = 12,

        // Multi-touch gestures
        /// <summary>Multi-touch gesture: Zoom. Equivalent to your "Pinch" gesture.</summary>
        Zoom = 114,
        /// <summary>Multi-touch gesture: Pan. Equivalent to your "Scroll" gesture.</summary>
        Pan = 115,
        /// <summary>Multi-touch gesture: Rotate.</summary>
        Rotate = 116,
        /// <summary>Multi-touch gesture: Two Finger Tap.</summary>
        TwoFingerTap = 117,
        /// <summary>Multi-touch gesture: Rollover. Press and tap.</summary>
        Rollover = 118,

        // Additional NetMF gestures
        /// <summary>Represents a user-defined gesture.</summary>
        UserDefined = 200,
    }
}
