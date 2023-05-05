//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using System;

namespace nanoFramework.UI
{
    /// <summary>
    /// Specifies the TouchInputFlags enumeration, which represents the flags for touch input.
    /// </summary>
    [Flags]
    public enum TouchInputFlags : uint
    {
        /// <summary>
        /// No flags are set.
        /// </summary>
        None = 0x00,

        /// <summary>
        /// The Primary flag denotes the input that is passed to the single-touch Stylus events provided when no controls handle the Touch events.
        /// This flag should be set on the TouchInput structure that represents the first finger down as it moves around up to and including the point it is released.
        /// </summary>
        Primary = 0x0010,

        /// <summary>
        /// Specifies that the touch input is from a pen. Hardware support is optional, but providing it allows for potentially richer applications.
        /// </summary>
        Pen = 0x0040,

        /// <summary>
        /// Specifies that the touch input is from a palm. Hardware support is optional, but providing it allows for potentially richer applications.
        /// </summary>
        Palm = 0x0080,
    }
}
