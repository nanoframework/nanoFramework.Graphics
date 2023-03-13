//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace nanoFramework.UI
{
    /// <summary>
    /// The window type to use when setting the window.
    /// </summary>
    public enum SetWindowType
    {
        /// <summary>
        /// No windowing is used.
        /// </summary>
        NoWindowing = 0,

        /// <summary>
        /// Address to set the window is using 8 bits for X and 1 bit for Y. Y is addressed using Y / 8.
        /// </summary>
        X8bitsY1Bit = 1,

        /// <summary>
        /// Address to set the window is using 8 bits for X and 8 bits for Y.
        /// </summary>
        X8bitsY8Bits = 2,

        /// <summary>
        /// Address to set the window is using 16 bits for X and 16 bits for Y.
        /// </summary>
        X16bitsY16Bit = 3,
    }
}
