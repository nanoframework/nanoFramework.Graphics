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
    /// 
    /// </summary>
    [Flags]
    public enum CollectionMethod : int
    {
        /// <summary>
        /// 
        /// </summary>
        Managed = 0,

        /// <summary>
        /// 
        /// </summary>
        Native = 1,
    }

    /// <summary>
    /// 
    /// </summary>
    [Flags]
    public enum CollectionMode : int
    {
        /// <summary>
        /// 
        /// </summary>
        InkOnly = 2,

        /// <summary>
        /// 
        /// </summary>
        GestureOnly = 4,

        /// <summary>
        /// 
        /// </summary>
        InkAndGesture = InkOnly | GestureOnly,
    }

    internal class TouchCollector
    {
        /// <summary>
        /// 
        /// </summary>
        public TouchCollector()
        {
        }

        TimeSpan lastTime = TimeSpan.Zero;

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

        private uint _nativeBufferSize = 200;
    }

    /// <summary>
    /// 
    /// </summary>
    public static class TouchCollectorConfiguration
    {
        /// <summary>
        /// 
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
        /// 
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
        /// Sampling rate per second. Setting 50 will result 50 touch samples in a second.
        /// </summary>
        public static int SamplingFrequency
        {
            get
            {
                int param1 = 0;
                int param2 = 0;
                int param3 = 0;

                GetTouchInput(TouchInput.SamplingDistance, ref param1, ref param2, ref param3);

                if (param1 <= 0)
                    return 0;

                return (1000000 / param1);
            }

            set
            {
                int param1 = 0;
                int param2 = 0;
                int param3 = 0;

                // Negative or zero is not acceptable frequency.
                if (value <= 0)
                    throw new ArgumentException();

                param1 = 1000000 / value;

                // param1 == 0 means more than one sample is requested per microsecond,
                // which is not attainable.
                if (param1 <= 0)
                    throw new ArgumentException();

                SetTouchInput(TouchInput.SamplingDistance, param1, param2, param3);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static void GetLastTouchPoint(ref int x, ref int y)
        {
            int param3 = 0;
            GetTouchInput(TouchInput.LastTouchPoint, ref x, ref y, ref param3);
        }

        /// <summary>
        /// 
        /// </summary>
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
        /// 
        /// </summary>
        [Flags]
        public enum TouchInput
        {
            /// <summary>
            /// param1- X, param2-Y, param3-unused.
            /// </summary>
            LastTouchPoint = 0x2, 
            /// <summary>
            /// param1- Distance in micro seconds.
            /// </summary>
            SamplingDistance = 0x4, 
            /// <summary>
            /// param1- frequency per second.
            /// </summary>
            TouchMoveFrequency = 0x8,
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        /// <param name="param3"></param>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        public static extern void GetTouchInput(TouchInput flag, ref int param1, ref int param2, ref int param3);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        /// <param name="param3"></param>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        public static extern void SetTouchInput(TouchInput flag, int param1, int param2, int param3);

        internal static CollectionMode _collectionMode = CollectionMode.GestureOnly;
        internal static CollectionMethod _collectionMethod = CollectionMethod.Managed;

        internal static TouchCollector _touchCollector = new TouchCollector();
        internal static uint _collectionBufferSize = 200;
    }
}


