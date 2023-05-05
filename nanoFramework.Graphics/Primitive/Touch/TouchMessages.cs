//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using System;

namespace nanoFramework.UI
{
    // IMPORTANT - This must be in sync with code in PAL and also nanoFramework
    /// <summary>
    /// Specifies the type of touch message that occurred.
    /// </summary>
    public enum TouchMessages : byte
    {
        /// <summary>
        /// A touch down message.
        /// </summary>
        Down = 1,

        /// <summary>
        /// A touch up message.
        /// </summary>
        Up = 2,

        /// <summary>
        /// A touch move message.
        /// </summary>
        Move = 3,
    }
}
