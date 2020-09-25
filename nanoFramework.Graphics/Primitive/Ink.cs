//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using System.Runtime.CompilerServices;
using nanoFramework.UI;

namespace nanoFramework.UI
{
    /// <summary>
    /// 
    /// </summary>
    public static class Ink
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="flags"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="borderWidth"></param>
        /// <param name="color"></param>
        /// <param name="penWidth"></param>
        /// <param name="bitmap"></param>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        public static extern void SetInkRegion(uint flags, int x1, int y1, int x2, int y2, int borderWidth, int color, int penWidth, Bitmap bitmap);

        /// <summary>
        /// 
        /// </summary>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        public static extern void ResetInkRegion();
    }
}


