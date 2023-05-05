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
    /// Provides configuration settings for the TouchCollector.
    /// </summary>
    public static class TouchCollectorConfiguration
    {
        internal static CollectionMode _collectionMode = CollectionMode.GestureOnly;
        internal static CollectionMethod _collectionMethod = CollectionMethod.Managed;

        internal static TouchCollector _touchCollector = new TouchCollector();
        internal static uint _collectionBufferSize = 200;

        /// <summary>
        /// Gets or sets the collection mode for the TouchCollector.
        /// </summary>
        public static CollectionMode CollectionMode
        {
            get
            {
                return _collectionMode;
            }

            set
            {
                _collectionMode = value;
            }
        }

        /// <summary>
        /// Gets or sets the collection method for the TouchCollector.
        /// </summary>
        public static CollectionMethod CollectionMethod
        {
            get
            {
                return _collectionMethod;
            }

            set
            {
                if (_collectionMethod != value)
                {
                    _collectionMethod = value;
                    _touchCollector.SetBuffer(_collectionBufferSize);
                }
            }
        }

        /// <summary>
        /// Gets or sets the sampling frequency per second.
        /// </summary>
        /// <remarks>Setting a frequency of 50 will result in 50 touch samples per second.</remarks>
        public static int SamplingFrequency
        {
            get
            {
                int param1 = 0;
                int param2 = 0;
                int param3 = 0;

                GetTouchInput(TouchInput.SamplingDistance, ref param1, ref param2, ref param3);

                if (param1 <= 0)
                {
                    return 0;
                }

                return (1000000 / param1);
            }

            set
            {
                int param1 = 0;
                int param2 = 0;
                int param3 = 0;

                // Negative or zero is not acceptable frequency.
                if (value <= 0)
                {
                    throw new ArgumentException();
                }

                param1 = 1000000 / value;

                // param1 == 0 means more than one sample is requested per microsecond,
                // which is not attainable.
                if (param1 <= 0)
                {
                    throw new ArgumentException();
                }

                SetTouchInput(TouchInput.SamplingDistance, param1, param2, param3);
            }
        }

        /// <summary>
        /// Gets the last touch point.
        /// </summary>
        /// <param name="x">The x-coordinate of the last touch point.</param>
        /// <param name="y">The y-coordinate of the last touch point.</param>
        public static void GetLastTouchPoint(ref int x, ref int y)
        {
            int param3 = 0;
            GetTouchInput(TouchInput.LastTouchPoint, ref x, ref y, ref param3);
        }

        /// <summary>
        /// Gets or sets the touch move frequency.
        /// </summary>
        /// <remarks>The touch move frequency determines how often touch move events are generated.</remarks>
        public static int TouchMoveFrequency
        {
            get
            {
                int param1 = 0;
                int param2 = 0;
                int param3 = 0;
                GetTouchInput(TouchInput.TouchMoveFrequency, ref param1, ref param2, ref param3);

                return param1;
            }

            set
            {
                int param1 = value;
                int param2 = 0;
                int param3 = 0;

                SetTouchInput(TouchInput.TouchMoveFrequency, param1, param2, param3);
            }
        }


        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        internal static extern void GetTouchPoints(ref int pointCount, short[] sx, short[] sy);

        /// <summary>
        /// Flags used to identify touch input properties.
        /// </summary>
        [Flags]
        public enum TouchInput
        {
            /// <summary>
            /// The last known touch point on the screen.
            /// </summary>
            LastTouchPoint = 0x2,
            /// <summary>
            /// The distance between touch samples in microseconds.
            /// </summary>
            SamplingDistance = 0x4,
            /// <summary>
            /// The frequency of touch move events per second.
            /// </summary>
            TouchMoveFrequency = 0x8,
        }

        /// <summary>
        /// Retrieves touch input data for a specified flag.
        /// </summary>
        /// <param name="flag">The flag indicating the type of touch input data to retrieve.</param>
        /// <param name="param1">The first parameter of the touch input data.</param>
        /// <param name="param2">The second parameter of the touch input data.</param>
        /// <param name="param3">The third parameter of the touch input data.</param>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        public static extern void GetTouchInput(TouchInput flag, ref int param1, ref int param2, ref int param3);

        /// <summary>
        /// Sets touch input data for a specified flag.
        /// </summary>
        /// <param name="flag">The flag indicating the type of touch input data to set.</param>
        /// <param name="param1">The first parameter of the touch input data.</param>
        /// <param name="param2">The second parameter of the touch input data.</param>
        /// <param name="param3">The third parameter of the touch input data.</param>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        public static extern void SetTouchInput(TouchInput flag, int param1, int param2, int param3);
    }
}
