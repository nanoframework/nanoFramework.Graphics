//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace nanoFramework.UI
{
    /// <summary>
    /// Enum for the reason why a user session is ending.
    /// </summary>
    public enum ReasonSessionEnding : byte
    {
        /// <summary>
        /// The user is logging off.
        /// </summary>
        Logoff = 0,

        /// <summary>
        /// The system is shutting down.
        /// </summary>
        Shutdown
    }
}
