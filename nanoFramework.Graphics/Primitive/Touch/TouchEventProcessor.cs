//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using nanoFramework.Runtime.Events;
using System.Runtime.CompilerServices;
using System;

namespace nanoFramework.UI
{
    /// <summary>
    /// The TouchEventProcessor class implements the IEventProcessor interface to handle touch input events.
    /// </summary>
    internal class TouchEventProcessor : IEventProcessor
    {
        /// <summary>
        /// Processes the touch input events.
        /// </summary>
        /// <param name="data1">The first touch event data.</param>
        /// <param name="data2">The second touch event data.</param>
        /// <param name="time">The time at which the touch input occurred.</param>
        /// <returns>A BaseEvent object that encapsulates the touch input event data.</returns>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        extern public BaseEvent ProcessEvent(uint data1, uint data2, DateTime time);
    }
}
