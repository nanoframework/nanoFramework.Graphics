//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace nanoFramework.Presentation
{
    /// <summary>
    /// SizeToContent
    /// </summary>
    public enum SizeToContent
    {
        /// <summary>
        /// Does not size to content
        /// </summary>
        Manual = 0,
        /// <summary>
        /// Sizes Width to content's Width
        /// </summary>
        Width = 1,
        /// <summary>
        /// Sizes Height to content's Height
        /// </summary>
        Height = 2,
        /// <summary>
        /// Sizes both Width and Height to content's size
        /// </summary>
        WidthAndHeight = 3,
        // Please update IsValidSizeToContent if there are name changes.
    }
}


