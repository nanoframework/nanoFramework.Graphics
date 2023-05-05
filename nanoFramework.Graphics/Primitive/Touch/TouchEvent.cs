//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using System;
using nanoFramework.Runtime.Events;

namespace nanoFramework.UI
{
    /// <summary>
    /// Represents a touch event that encapsulates touch input data.
    /// </summary>
    public class TouchEvent : BaseEvent
    {
        /// <summary>
        /// Gets or sets the time when the touch event occurred.
        /// </summary>
        public DateTime Time;

        /// <summary>
        /// Gets or sets an array of touch input data for the touch event.
        /// </summary>
        public TouchInput[] Touches;
    }
}
