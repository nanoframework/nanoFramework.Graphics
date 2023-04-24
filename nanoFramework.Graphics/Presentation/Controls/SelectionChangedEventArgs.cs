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
    /// Provides data for the SelectionChanged event of a control.
    /// </summary>
    public class SelectionChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Provides data for the SelectionChanged event of a control.
        /// </summary>
        public readonly int PreviousSelectedIndex;

        /// <summary>
        /// Gets the index of the newly selected item.
        /// </summary>
        public readonly int SelectedIndex;

        /// <summary>
        /// Initializes a new instance of the SelectionChangedEventArgs class with the specified previous and new selected indexes.
        /// </summary>
        /// <param name="previousIndex">The previous selected index.</param>
        /// <param name="newIndex">The new selected index.</param>
        public SelectionChangedEventArgs(int previousIndex, int newIndex)
        {
            PreviousSelectedIndex = previousIndex;
            SelectedIndex = newIndex;
        }
    }
}
