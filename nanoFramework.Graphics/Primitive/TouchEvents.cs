//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace nanoFramework.UI
{
    /// <summary>
    /// Temporary class to extend the EventCatory enum found in the nanoFramework.Runtime.Events
    ///  Need to merge these into this class update references and remove this file
    /// </summary>
    public static class Temporary
    {
        /// <summary>
        ///  Temporary enum with unique values within the EventCategory enum range found in nanoFramework.Runtime.Events
        /// </summary>
        public enum EventCategoryEx 
        {
        /// <summary>
        /// Specifies a Touch Event
        /// </summary>
        Touch = 80,

        /// <summary>
        /// Specifies a Gesture Event
        /// </summary>
        Gesture = 90
        }
    }
}
