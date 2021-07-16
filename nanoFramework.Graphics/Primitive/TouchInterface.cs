//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using System;
using System.Runtime.CompilerServices;
using nanoFramework.Runtime.Events;
using static nanoFramework.UI.Temporary;

namespace nanoFramework.UI
{
    /// <summary>  </summary>
    [FlagsAttribute]
    public enum TouchInputFlags : uint
    {
        /// <summary>  </summary>

        None = 0x00,

        /// <summary>  </summary>
        Primary = 0x0010,  //The Primary flag denotes the input that is passed to the single-touch Stylus events provided

        //no controls handle the Touch events.  This flag should be set on the TouchInput structure that represents
        //the first finger down as it moves around up to and including the point it is released.

        /// <summary>  </summary>
        Pen = 0x0040,     //Hardware support is optional, but providing it allows for potentially richer applications.

        /// <summary>  </summary>
        Palm = 0x0080,     //Hardware support is optional, but providing it allows for potentially richer applications.
    }

    ///
    /// IMPORTANT - This must be in sync with code in PAL and also nanoFramework
    ///
    /// <summary>  </summary>
    public enum TouchMessages : byte
    {
        /// <summary>  </summary>
        Down = 1,
        /// <summary>  </summary>
        Up = 2,
        /// <summary>  </summary>
        Move = 3,
    }

    /// <summary>  </summary>
    public class TouchInput
    {
        /// <summary>  </summary>
        public int X;
        /// <summary>  </summary>
        public int Y;
        /// <summary>  </summary>
        public byte SourceID;
        /// <summary>  </summary>
        public TouchInputFlags Flags;
        /// <summary>  </summary>
        public uint ContactWidth;
        /// <summary>  </summary>
        public uint ContactHeight;
    }

    /// <summary>  </summary>
    public class TouchEvent : BaseEvent
    {
        /// <summary>  </summary>
        public DateTime Time;
        /// <summary>  </summary>
        public TouchInput[] Touches;
    }

  /// <summary>
  /// 
  /// </summary>
    public class TouchScreenEventArgs : EventArgs
    {
        // Fields
        /// <summary>  </summary>
        public TouchInput[] Touches;
        /// <summary>  </summary>
        public DateTime TimeStamp;
        /// <summary>  </summary>
        public object Target;

        // Methods
    /// <summary>
    /// 
    /// </summary>
    /// <param name="timestamp"></param>
    /// <param name="touches"></param>
    /// <param name="target"></param>
        public TouchScreenEventArgs(DateTime timestamp, TouchInput[] touches, object target)
        {
            this.Touches = touches;
            this.TimeStamp = timestamp;
            this.Target = target;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="touchIndex"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void GetPosition(int touchIndex, out int x, out int y)
        {
            x = Touches[touchIndex].X;
            y = Touches[touchIndex].Y;
        }
    }

    //--//

    /// <summary>  </summary>
    public delegate void TouchScreenEventHandler(object sender, TouchScreenEventArgs e);

    //--//

    /// <summary>  </summary>
    public enum TouchGesture : uint
    {
        /// <summary>  </summary>
        NoGesture = 0,          //Can be used to represent an error gesture or unknown gesture

        //Standard Win7 Gestures
        /// <summary>  </summary>
        Begin = 1,       //Used to identify the beginning of a Gesture Sequence; App can use this to highlight UIElement or some other sort of notification.
        /// <summary>  </summary>
        End = 2,       //Used to identify the end of a gesture sequence; Fired when last finger involved in a gesture is removed.

        // Standard stylus (single touch) gestues
        /// <summary>  </summary>
        Right = 3,
        /// <summary>  </summary>
        UpRight = 4,
        /// <summary>  </summary>
        Up = 5,
        /// <summary>  </summary>
        UpLeft = 6,
        /// <summary>  </summary>
        Left = 7,
        /// <summary>  </summary>
        DownLeft = 8,
        /// <summary>  </summary>
        Down = 9,
        /// <summary>  </summary>
        DownRight = 10,
        /// <summary>  </summary>
        Tap = 11,
        /// <summary>  </summary>
        DoubleTap = 12,

        // Multi-touch gestures
        /// <summary>  </summary>
        Zoom = 114,      //Equivalent to your "Pinch" gesture
        /// <summary>  </summary>
        Pan = 115,      //Equivalent to your "Scroll" gesture
        /// <summary>  </summary>
        Rotate = 116,
        /// <summary>  </summary>
        TwoFingerTap = 117,
        /// <summary>  </summary>
        Rollover = 118,      // Press and tap

        //Additional NetMF gestures
        /// <summary>  </summary>
        UserDefined = 200,
    }

    /// <summary>  </summary>
    public class TouchGestureEventArgs : EventArgs
    {
        /// <summary>  </summary>
        public readonly DateTime Timestamp;

        /// <summary>  </summary>
        public TouchGesture Gesture;

        ///<note> X and Y form the center location of the gesture for multi-touch or the starting location for single touch </note>
        /// <summary>  </summary>
        public int X;
        /// <summary>  </summary>
        public int Y;

        /// <note>2 bytes for gesture-specific arguments.
        /// TouchGesture.Zoom: Arguments = distance between fingers
        /// TouchGesture.Rotate: Arguments = angle in degrees (0-360)
        /// </note>
        /// <summary>  </summary>
        public ushort Arguments;

       /// <summary>
       /// 
       /// </summary>
        public double Angle
        {
            get
            {
                return (double)(Arguments);
            }
        }
    }

    //--//

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void TouchGestureEventHandler(object sender, TouchGestureEventArgs e);

    internal class TouchEventProcessor : IEventProcessor
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data1"></param>
        /// <param name="data2"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        extern public BaseEvent ProcessEvent(uint data1, uint data2, DateTime time);
    }

    /// <summary>  </summary>
    public static class Touch
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="touchEventListener"></param>
        [MethodImplAttribute(MethodImplOptions.Synchronized)]
        public static void Initialize(IEventListener touchEventListener)
        {
            if (_initialized)
                return;

            // Add a touch event processor.
            EventSink.AddEventProcessor((EventCategory)EventCategoryEx.Touch, new TouchEventProcessor());

            // Start the event sink process. This will pump
            // events neatly out of the other world.
            EventSink.AddEventListener((EventCategory)EventCategoryEx.Touch, touchEventListener);

            // Also add generic for Gesture stuff.
            EventSink.AddEventListener((EventCategory)EventCategoryEx.Gesture, touchEventListener);

            _initialized = true;
        }

        /// <summary>  </summary>
        public static TouchPanel ActiveTouchPanel
        {
            get
            {
                return _activeTouchPanel;
            }
        }

        private static bool _initialized = false;
        private static TouchPanel _activeTouchPanel = null;
    }
}


