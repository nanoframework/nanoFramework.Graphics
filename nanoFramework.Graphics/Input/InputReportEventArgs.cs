//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using System;

namespace nanoFramework.UI.Input
{
    /// <summary>
    ///     The InputReportEventArgs class contains information about an input
    ///     report that is being processed.
    /// </summary>
    public class InputReportEventArgs : InputEventArgs
    {
        /// <summary>
        ///     Initializes a new instance of the InputReportEventArgs class.
        /// </summary>
        /// <param name="inputDevice">
        ///     The input device to associate this input with.
        /// </param>
        /// <param name="report">
        ///     The input report being processed.
        /// </param>
        public InputReportEventArgs(InputDevice inputDevice,
                                    InputReport report)
            : base(inputDevice, ((report != null) ? report.Timestamp : DateTime.MinValue))
        {
            if (report == null)
                throw new ArgumentNullException("report");

            Report = report;
        }

        /// <summary>
        ///     Read-only access to the input report being processed.
        /// </summary>
        public readonly InputReport Report;
    }
}


