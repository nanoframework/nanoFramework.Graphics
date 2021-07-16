//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace nanoFramework.UI.Threading
{
    /// <summary>
    ///     An enumeration describing the status of a DispatcherOperation.
    /// </summary>
    ///
    public enum DispatcherOperationStatus
    {
        /// <summary>
        ///     The operation is still pending.
        /// </summary>
        Pending,

        /// <summary>
        ///     The operation has been aborted.
        /// </summary>
        Aborted,

        /// <summary>
        ///     The operation has been completed.
        /// </summary>
        Completed,

        /// <summary>
        ///     The operation has started executing, but has not completed yet.
        /// </summary>
        Executing
    }
}


