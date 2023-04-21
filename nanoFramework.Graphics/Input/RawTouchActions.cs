//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace nanoFramework.UI.Input
{
    /// <summary>
    /// Raw touch actions.
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
