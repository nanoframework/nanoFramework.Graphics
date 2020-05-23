//
// Copyright (c) 2019 The nanoFramework project contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using System;

namespace nanoFramework.Runtime.Events
{
    /// <summary>
    /// Creates an instance of the <see cref="GenericEvent"/> class.
    /// </summary>
    public class GenericEventEx : GenericEvent
    {
        /// <summary>
        /// Specifies additional position information.
        /// </summary>
        public int X;

        /// <summary>
        /// Specifies additional position information.
        /// </summary>
        public int Y;
    }
}
