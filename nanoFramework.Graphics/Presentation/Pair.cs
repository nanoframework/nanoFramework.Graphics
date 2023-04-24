//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace nanoFramework.Presentation
{
    internal class Pair
    {
        /// <summary>
        /// 
        /// </summary>
        public const int Flags_First = 0x1;  // Can be (optionally) used with _status

        /// <summary>
        /// 
        /// </summary>
        public const int Flags_Second = 0x2;

        /// <summary>
        /// 
        /// </summary>
        public int _first;

        /// <summary>
        /// 
        /// </summary>
        public int _second;

        /// <summary>
        /// 
        /// </summary>
        public int _status;
    }
}
