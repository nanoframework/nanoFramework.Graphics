//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using System.Runtime.CompilerServices;

namespace nanoFramework.UI
{
    /// <summary>
    /// Class that represents a touch panel and provides calibration-related functions.
    /// </summary>
    public class TouchPanel
    {
        /// <summary>
        /// Sets the calibration parameters for the touch panel.
        /// </summary>
        /// <param name="cCalibrationPoints">The number of calibration points.</param>
        /// <param name="screenXBuffer">The X coordinates of the points on the screen.</param>
        /// <param name="screenYBuffer">The Y coordinates of the points on the screen.</param>
        /// <param name="uncalXBuffer">The uncalibrated X coordinates of the points.</param>
        /// <param name="uncalYBuffer">The uncalibrated Y coordinates of the points.</param>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        public extern void SetCalibration(int cCalibrationPoints,
                short[] screenXBuffer,
                short[] screenYBuffer,
                short[] uncalXBuffer,
                short[] uncalYBuffer);

        /// <summary>
        /// Gets the number of calibration points currently set for the touch panel.
        /// </summary>
        /// <param name="count">The number of calibration points.</param>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        public extern void GetCalibrationPointCount(ref int count);

        /// <summary>
        /// Starts the calibration process for the touch panel.
        /// </summary>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        public extern void StartCalibration();

        /// <summary>
        /// Gets the coordinates of a calibration point.
        /// </summary>
        /// <param name="index">The index of the calibration point.</param>
        /// <param name="x">The X coordinate of the calibration point.</param>
        /// <param name="y">The Y coordinate of the calibration point.</param>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        public extern void GetCalibrationPoint(int index, ref int x, ref int y);
    }
}
