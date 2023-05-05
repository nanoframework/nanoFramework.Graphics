//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace nanoFramework.UI
{
    /// <summary>
    /// Enumerates the possible shutdown modes of a WPF application.
    /// </summary>
    public enum ShutdownMode : byte
    {
        /// <summary>
        /// The application shuts down when the last window is closed.
        /// </summary>
        OnLastWindowClose = 0,

        /// <summary>
        /// The application shuts down when the main window is closed.
        /// </summary>
        OnMainWindowClose = 1,

        /// <summary>
        /// The application shuts down explicitly, by calling the Shutdown method.
        /// </summary>
        OnExplicitShutdown

        // NOTE: if you add or remove any values in this enum, be sure to update Application.IsValidShutdownMode()
    }
}
