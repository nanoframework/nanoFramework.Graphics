//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using System;

namespace nanoFramework.UI
{
    /// <summary>
    /// Specifies the collection mode for ink and gesture recognition.
    /// </summary>
    [Flags]
    public enum CollectionMode : int
    {
        /// <summary>
        /// Collects ink strokes only.
        /// </summary>
        InkOnly = 2,

        /// <summary>
        /// Collects gesture input only.
        /// </summary>
        GestureOnly = 4,

        /// <summary>
        /// Collects both ink strokes and gesture input.
        /// </summary>
        InkAndGesture = InkOnly | GestureOnly,
    }
}
