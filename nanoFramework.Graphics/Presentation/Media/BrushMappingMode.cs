//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace nanoFramework.Presentation.Media
{
    /// <summary>
    /// Specifies how a brush is mapped to a shape or region.
    /// </summary>
    public enum BrushMappingMode
    {
        /// <summary>
        /// The brush is mapped in absolute coordinates.
        /// </summary>
        Absolute,

        /// <summary>
        /// The brush is mapped relative to the bounding box of the shape or region.
        /// </summary>
        RelativeToBoundingBox
    }
}
