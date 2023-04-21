//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace nanoFramework.Presentation.Controls
{
    /// <summary>
    /// Dock - Enum which describes how to position and stretch the child of a DockPanel.
    /// </summary> 
    /// <seealso cref="DockPanel" />
    public enum Dock
    {
        /// <summary>
        /// Position this child at the left of the remaining space. 
        /// </summary>
        Left,

        /// <summary> 
        /// Position this child at the top of the remaining space.
        /// </summary> 
        Top,

        /// <summary> 
        /// Position this child at the right of the remaining space.
        /// </summary>
        Right,

        /// <summary>
        /// Position this child at the bottom of the remaining space. 
        /// </summary>
        Bottom
    }
}
