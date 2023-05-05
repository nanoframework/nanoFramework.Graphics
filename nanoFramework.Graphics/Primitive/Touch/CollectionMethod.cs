//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using System;

namespace nanoFramework.UI
{
    /// <summary>
    /// Specifies the collection method for ink and gesture strokes.
    /// </summary>
    [Flags]
    public enum CollectionMethod : int
    {
        /// <summary>
        /// Specifies the managed collection method where ink and gesture strokes are collected and managed by the application.
        /// </summary>
        Managed = 0,

        /// <summary>
        /// Specifies the native collection method where ink and gesture strokes are collected and managed by the operating system.
        /// </summary>
        Native = 1,
    }
}
