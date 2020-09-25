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
    ///     The RawTouchInputReport class encapsulates the raw input
    ///     provided from a multitouch source.
    /// </summary>
    /// <remarks>
    ///     It is important to note that the InputReport class only contains
    ///     blittable types.  This is required so that the report can be
    ///     marshalled across application domains.
    /// </remarks>
public class RawTouchInputReport : InputReport
    {
        /// <summary>
        ///     Constructs an instance of the RawKeyboardInputReport class.
        /// </summary>
        /// <param name="inputSource"></param>
        /// <param name="timestamp"></param>
        /// <param name="eventMessage"></param>
        /// <param name="touches"></param>
        public RawTouchInputReport(PresentationSource inputSource, DateTime timestamp, byte eventMessage, TouchInput[] touches)
            : base(inputSource, timestamp)
        {
            EventMessage = eventMessage;
            Touches = touches;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputSource"></param>
        /// <param name="timestamp"></param>
        /// <param name="eventMessage"></param>
        /// <param name="touches"></param>
        /// <param name="destTarget"></param>
        public RawTouchInputReport(PresentationSource inputSource,
                    DateTime timestamp, byte eventMessage, TouchInput[] touches, UIElement destTarget)
            : base(inputSource, timestamp)
        {
            EventMessage = eventMessage;
            Touches = touches;
            Target = destTarget;
        }

        /// <summary>
        /// 
        /// </summary>
        public readonly UIElement Target;

        /// <summary>
        /// 
        /// </summary>
        public readonly byte EventMessage;

        /// <summary>
        /// 
        /// </summary>
        public readonly TouchInput[] Touches;
    }

    /// <summary>
    /// 
    /// </summary>
    public enum RawTouchActions
    {
        /// <summary>
        ///  Touch Down
        /// </summary>
        TouchDown = 0x01,

        /// <summary>
        ///  Touch Up
        /// </summary>
        TouchUp = 0x02,

        /// <summary>
        ///  Activate
        /// </summary>
        Activate = 0x04,

        /// <summary>
        ///  Deactivate
        /// </summary>
        Deactivate = 0x08,

        /// <summary>
        ///  Touch Move
        /// </summary>
        TouchMove = 0x10,
    }
}


