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
    /// <summary>
    /// Represents a touch screen that can listen for touch events.
    /// </summary>
    public class TouchScreen : IEventListener
    {
        /// <summary>
        /// Represents a rectangular region of the touch screen that can receive touch events.
        /// </summary>
        public class ActiveRectangle
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="ActiveRectangle"/> class with the specified location, size, and target object.
            /// </summary>
            /// <param name="x">The x-coordinate of the upper-left corner of the rectangle.</param>
            /// <param name="y">The y-coordinate of the upper-left corner of the rectangle.</param>
            /// <param name="width">The width of the rectangle.</param>
            /// <param name="height">The height of the rectangle.</param>
            /// <param name="target">The object that will receive touch events for this region.</param>
            public ActiveRectangle(int x, int y, int width, int height, object target)
            {
                this.X = x;
                this.Y = y;
                this.Width = width;
                this.Height = height;
                this.Target = target;
            }

            /// <summary>
            /// Determines whether the specified touch input is within the bounds of this <see cref="ActiveRectangle"/> object.
            /// </summary>
            /// <param name="input">The touch input to test.</param>
            /// <returns>true if the touch input is within the bounds of this <see cref="ActiveRectangle"/> object; otherwise, false.</returns>
            public bool Contains(TouchInput input)
            {
                if (
                    input.X >= this.X &&
                    input.X < this.X + this.Width &&
                    input.Y >= this.Y &&
                    input.Y < this.Y + this.Height
                  )
                {
                    return true;
                }
                return false;
            }

            //--//

            /// <summary>
            /// Gets the x-coordinate of the top-left corner of this active rectangle.
            /// </summary>
            public readonly int X;

            /// <summary>
            /// Gets the y-coordinate of the top-left corner of this active rectangle.
            /// </summary>
            public readonly int Y;

            /// <summary>
            /// Gets the width of this active rectangle.
            /// </summary>
            public readonly int Width;

            /// <summary>
            /// Gets the height of this active rectangle.
            /// </summary>
            public readonly int Height;

            /// <summary>
            /// Gets the target object associated with this active rectangle.
            /// </summary>
            public readonly object Target;
        }

        //--//

        private ActiveRectangle[] _activeRegions;
        private readonly int _maxWidth;
        private readonly int _maxHeight;

        //--//

        /// <summary>
        /// Initializes a new instance of the <see cref="TouchScreen"/> class with the specified active regions.
        /// </summary>
        /// <param name="activeRectangles">An array of active rectangles representing the regions of the screen that can be interacted with.</param>
        public TouchScreen(ActiveRectangle[] activeRectangles)
        {
            _maxWidth = DisplayControl.ScreenWidth;
            _maxHeight = DisplayControl.ScreenHeight;

            if (activeRectangles == null || activeRectangles.Length == 0)
            {
                this.ActiveRegions = new ActiveRectangle[] { new ActiveRectangle(0, 0, _maxWidth, _maxHeight, null) };
            }
            else
            {
                this.ActiveRegions = activeRectangles;
            }
        }

        /// <summary>
        /// Event triggered when a touch down event occurs on the TouchScreen.
        /// </summary>
        public event TouchScreenEventHandler OnTouchDown;

        /// <summary>
        /// Event triggered when a touch move event occurs on the TouchScreen.
        /// </summary>
        public event TouchScreenEventHandler OnTouchMove;

        /// <summary>
        /// Event triggered when a touch up event occurs on the TouchScreen.
        /// </summary>
        public event TouchScreenEventHandler OnTouchUp;

        /// <summary>
        /// Event triggered when a gesture starts on the TouchScreen.
        /// </summary>
        public event TouchGestureEventHandler OnGestureStarted;

        /// <summary>
        /// Event triggered when a gesture changes on the TouchScreen.
        /// </summary>
        public event TouchGestureEventHandler OnGestureChanged;

        /// <summary>
        /// Event triggered when a gesture ends on the TouchScreen.
        /// </summary>
        public event TouchGestureEventHandler OnGestureEnded;

        /// <summary>
        /// Gets or sets the ActiveRectangles that define the touchable regions on the TouchScreen.
        /// </summary>
        public ActiveRectangle[] ActiveRegions
        {
            set
            {
                // check
                for (int i = 0; i < value.Length; ++i)
                {
                    ActiveRectangle ar = value[i];
                    if (ar.X < 0 || ar.X >= _maxWidth || ar.Y < 0 || ar.Y >= _maxHeight)
                    {
                        throw new ArgumentException();
                    }
                }

                _activeRegions = value;
            }

            get
            {
                return _activeRegions;
            }
        }

        [MethodImplAttribute(MethodImplOptions.Synchronized)]
        void IEventListener.InitializeForEventSource()
        {
        }

        [MethodImplAttribute(MethodImplOptions.Synchronized)]
        bool IEventListener.OnEvent(BaseEvent ev)
        {
            // Process known events, otherwise forward as generic to MainWindow.
            //

            TouchEvent touchEvent = ev as TouchEvent;
            if (touchEvent != null)
            {
                // dispatch only when the event is in the active area            
                for (int i = 0; i < _activeRegions.Length; ++i)
                {
                    ActiveRectangle ar = _activeRegions[i];

                    // only check the first 
                    if (ar.Contains(touchEvent.Touches[0]))
                    {
                        TouchScreenEventArgs tea = new TouchScreenEventArgs(touchEvent.Time, touchEvent.Touches, ar.Target);

                        switch ((TouchMessages)touchEvent.Message)
                        {
                            case TouchMessages.Down:
                                if (OnTouchDown != null)
                                {
                                    OnTouchDown(this, tea);
                                }
                                break;
                            case TouchMessages.Up:
                                if (OnTouchUp != null)
                                {
                                    OnTouchUp(this, tea);
                                }
                                break;
                            case TouchMessages.Move:
                                if (OnTouchMove != null)
                                {
                                    OnTouchMove(this, tea);
                                }
                                break;
                        }
                    }
                }

                return true;
            }
            else if (ev is GenericEventEx)
            {
                GenericEventEx genericEventEx = (GenericEventEx)ev;
                switch ((EventCategory)genericEventEx.Category)
                {
                    case (EventCategory)EventCategoryEx.Gesture:
                        {
                            TouchGestureEventArgs ge = new TouchGestureEventArgs();

                            ge.Gesture = (TouchGesture)genericEventEx.Message;
                            ge.X = genericEventEx.X;
                            ge.Y = genericEventEx.Y;
                            ge.Arguments = (ushort)genericEventEx.Data;

                            if (ge.Gesture == TouchGesture.Begin && OnGestureStarted != null)
                            {
                                OnGestureStarted(this, ge);
                            }
                            else if (ge.Gesture == TouchGesture.End && OnGestureEnded != null)
                            {
                                OnGestureEnded(this, ge);
                            }
                            else if (OnGestureChanged != null)
                            {
                                OnGestureChanged(this, ge);
                            }

                            break;
                        }
                    default:
                        break;
                }
            }
            return false;
        }
    }
}
