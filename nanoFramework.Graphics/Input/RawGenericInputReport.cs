//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using nanoFramework.Presentation;
using nanoFramework.Runtime.Events;

namespace nanoFramework.UI.Input
{
    /// <summary>
    ///     The RawGenericInputReport class encapsulates the raw input
    ///     provided from a keyboard.
    /// </summary>
    /// <remarks>
    ///     It is important to note that the InputReport class only contains
    ///     blittable types.  This is required so that the report can be
    ///     marshalled across application domains.
    /// </remarks>
    public class RawGenericInputReport : InputReport
    {
        /// <summary>
        ///     Constructs an instance of the RawKeyboardInputReport class.
        /// </summary>
        /// <param name="inputSource">
        ///     source of the input
        /// </param>
        /// <param name="genericEvent">
        ///     Generic event
        /// </param>
        public RawGenericInputReport(PresentationSource inputSource, GenericEventEx genericEvent)
            : base(inputSource, genericEvent.Time)
        {
            InternalEvent = genericEvent;
            Target = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputSource"></param>
        /// <param name="genericEvent"></param>
        /// <param name="destTarget"></param>
        public RawGenericInputReport(PresentationSource inputSource,
                        GenericEventEx genericEvent, UIElement destTarget)
            : base(inputSource, genericEvent.Time)
        {
            InternalEvent = genericEvent;
            Target = destTarget;
        }

        /// <summary>
        /// 
        /// </summary>
        public readonly UIElement Target;

        /// <summary>
        /// 
        /// </summary>
        public readonly GenericEventEx InternalEvent;
    }
}


