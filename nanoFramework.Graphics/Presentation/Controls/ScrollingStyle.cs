//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace nanoFramework.Presentation.Controls
{
    /// <summary>
    /// Specifies the scrolling style for a ScrollViewer control.
    /// </summary>
    public enum ScrollingStyle
    {
        /// <summary>
        /// Scrolls content by a line at a time.
        /// </summary>
        First,

        /// <summary>
        /// Scrolls content by a line at a time.
        /// </summary>
        LineByLine = First,

        /// <summary>
        /// Scrolls content by a page at a time.
        /// </summary>
        PageByPage,

        /// <summary>
        /// Scrolls content by a page at a time.
        /// </summary>
        Last = PageByPage
    }
}
