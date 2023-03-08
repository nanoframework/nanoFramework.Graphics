//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace nanoFramework.UI
{
    /// <summary>
    /// Graphic driver command types.
    /// </summary>
    public enum GraphicDriverCommandType
    {
        /// <summary>
        /// Sleep command by chunk of 10 milliseconds.
        /// </summary>
        Sleep = 0,

        /// <summary>
        /// Normal command followed by data.
        /// </summary>
        Command = 1,
    }
}
