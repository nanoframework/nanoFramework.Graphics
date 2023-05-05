//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using System;
using System.Runtime.CompilerServices;

namespace nanoFramework.UI
{
    /// <summary>
    /// Class responsible for collecting touch data.
    /// </summary>
    internal class TouchCollector
    {
        private uint _nativeBufferSize = 200;
        private TimeSpan lastTime = TimeSpan.Zero;

        /// <summary>
        /// Initializes a new instance of the TouchCollector class.
        /// </summary>
        public TouchCollector()
        {
        }        

        /// <summary>
        /// Sets the buffer size for collecting touch data.
        /// </summary>
        /// <param name="bufferSize">The size of the buffer to be set.</param>
        internal void SetBuffer(uint bufferSize)
        {
            if (TouchCollectorConfiguration.CollectionMethod == CollectionMethod.Managed)
            {
            }
            else if (TouchCollectorConfiguration.CollectionMethod == CollectionMethod.Native)
            {
                // Not needed at this moment, we are using static buffer.
                // TouchCollectorConfiguration.SetNativeBufferSize(bufferSize, bufferSize);
                _nativeBufferSize = bufferSize;
            }
        }        
    }    
}


