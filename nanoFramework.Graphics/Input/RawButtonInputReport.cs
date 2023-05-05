//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using nanoFramework.Presentation;
using System;

namespace nanoFramework.UI.Input
{
    /// <summary>
    ///     The RawButtonInputReport class encapsulates the raw input
    ///     provided from a keyboard.
    /// </summary>
    /// <remarks>
    ///     It is important to note that the InputReport class only contains
    ///     blittable types.  This is required so that the report can be
    ///     marshalled across application domains.
    /// </remarks>
    public class RawButtonInputReport : InputReport
    {
        /// <summary>
        ///     Constructs an instance of the RawKeyboardInputReport class.
        /// </summary>
        /// <param name="inputSource"></param>
        /// <param name="timestamp"></param>
        /// <param name="button"></param>
        /// <param name="actions"></param>
        public RawButtonInputReport(PresentationSource inputSource, DateTime timestamp, Button button, RawButtonActions actions)
            : base(inputSource, timestamp)
        {
            Button = button;
            Actions = actions;
        }

        /// <summary>
        /// Read-only access to the button reported.
        /// </summary>
        public readonly Button Button;

        /// <summary>
        /// Read-only access to the action reported.
        /// </summary>
        public readonly RawButtonActions Actions;
    }
}
