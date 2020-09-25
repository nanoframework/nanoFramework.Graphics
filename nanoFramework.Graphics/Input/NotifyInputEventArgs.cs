//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using System;
using nanoFramework.Runtime.Events;

namespace nanoFramework.UI.Input
{
    /// <summary>
    ///     Provides information about an input event being processed by the
    ///     input manager.
    /// </summary>
    /// <remarks>
    ///     An instance of this class, or a derived class, is passed to the
    ///     handlers of the following events:
    ///     <list>
    ///     </list>
    /// </remarks>
    public class NotifyInputEventArgs : EventArgs
    {
        // Only we can make these.
        internal NotifyInputEventArgs(StagingAreaInputItem input)
        {
            StagingItem = input;
        }

        /// <summary>
        ///     The staging area input item being processed by the input
        ///     manager.
        /// </summary>
        public readonly StagingAreaInputItem StagingItem;
    }

    /// <summary>
    ///     Delegate type for handles of events that use
    ///     <see cref="NotifyInputEventArgs"/>.
    /// </summary>
    public delegate void NotifyInputEventHandler(object sender, NotifyInputEventArgs e);
}


