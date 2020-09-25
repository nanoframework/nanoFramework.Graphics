//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using System;

namespace nanoFramework.UI.Input
{

    /// <summary>
    ///     The ButtonState enumeration describes the state that buttons
    ///     can be in.
    /// </summary>
    [Flags]
    public enum ButtonState : byte
    {
        /// <summary>
        ///     No state (same as up).
        /// </summary>
        None = 0,

        /// <summary>
        ///    The button is down.
        /// </summary>
        Down = 1,

        /// <summary>
        ///    The button is held
        /// </summary>
        Held = 2
    }
}


