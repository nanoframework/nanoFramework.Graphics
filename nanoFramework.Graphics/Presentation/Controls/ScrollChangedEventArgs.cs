//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using System;
using nanoFramework.Runtime.Events;

namespace nanoFramework.Presentation.Controls
{
    /// <summary>
    /// 
    /// </summary>
    public class ScrollChangedEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        public readonly int HorizontalChange;
        /// <summary>
        /// 
        /// </summary>
        public readonly int HorizontalOffset;

        /// <summary>
        /// 
        /// </summary>
        public readonly int VerticalChange;
        /// <summary>
        /// 
        /// </summary>
        public readonly int VerticalOffset;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="offsetX"></param>
        /// <param name="offsetY"></param>
        /// <param name="offsetChangeX"></param>
        /// <param name="offsetChangeY"></param>
        public ScrollChangedEventArgs(int offsetX, int offsetY, int offsetChangeX, int offsetChangeY)
        {
            HorizontalOffset = offsetX;
            HorizontalChange = offsetChangeX;

            VerticalOffset = offsetY;
            VerticalChange = offsetChangeY;
        }
    }
}


