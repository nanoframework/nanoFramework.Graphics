//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using nanoFramework.Presentation;
using nanoFramework.UI;
using nanoFramework.UI.Threading;

namespace nanoFramework.UI.Input
{
    /// <summary>
    ///     Provides the base class for all input devices.
    /// </summary>
    public abstract class InputDevice : DispatcherObject
    {
        /// <summary>
        ///     Constructs an instance of the InputDevice class.
        /// </summary>
        protected InputDevice()
        {
        }

        /// <summary>
        ///     Returns the element that input from this device is sent to.
        /// </summary>
        public abstract UIElement Target { get; }

        /// <summary>
        /// Input Device Type
        /// </summary>
        public abstract InputManager.InputDeviceType DeviceType { get; }
    }
}


