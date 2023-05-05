//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//


// need move this into mscorlib, also get the real implementation.
using System;
using nanoFramework.Runtime.Events;

namespace nanoFramework.UI
{

    /// <summary>
    /// Cancel event arguments.
    /// </summary>
    public class CancelEventArgs : EventArgs
    {
        /// <summary>
        /// Ture is cancelled.
        /// </summary>
        public bool Cancel;
    }
}
