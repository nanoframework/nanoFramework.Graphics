//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using System;

namespace nanoFramework.Presentation
{
    [Flags]
    internal enum Flags : uint
    {
        None = 0x00000000,
        // IsSubtreeDirtyForRender indicates that at least one element in the sub-graph of this element needs to
        // be re-rendered.
        IsSubtreeDirtyForRender = 0x00000002,
        // IsDirtyForRender indicates that the element has changed in a way that all it's children
        // need to be updated. E.g. more/less children clipped, children themselves
        // changed, clip changed => more/less children clipped
        IsDirtyForRender = 0x00000004,

        Enabled = 0x00000020,
        InvalidMeasure = 0x00000040,
        InvalidArrange = 0x00000080,
        MeasureInProgress = 0x00000100,
        ArrangeInProgress = 0x00000200,
        MeasureDuringArrange = 0x00000400,
        NeverMeasured = 0x00000800,
        NeverArranged = 0x00001000,
        // Should post render indicates that this is a root element and therefore we need to indicate that this
        // element tree needs to be re-rendered. Today we are doing this by posting a render queue item.
        ShouldPostRender = 0x00002000,
        IsLayoutSuspended = 0x00004000,

        IsVisibleCache = 0x00008000,
    }
}
