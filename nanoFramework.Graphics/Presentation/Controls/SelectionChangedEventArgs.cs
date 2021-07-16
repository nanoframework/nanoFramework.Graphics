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
    public class SelectionChangedEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        public readonly int PreviousSelectedIndex;

        /// <summary>
        /// 
        /// </summary>
        public readonly int SelectedIndex;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="previousIndex"></param>
        /// <param name="newIndex"></param>
        public SelectionChangedEventArgs(int previousIndex, int newIndex)
        {
            PreviousSelectedIndex = previousIndex;
            SelectedIndex = newIndex;
        }
    }
}


