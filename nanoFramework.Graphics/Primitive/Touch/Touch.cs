//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.

using nanoFramework.Runtime.Events;
using System.Runtime.CompilerServices;
using static nanoFramework.UI.Temporary;

namespace nanoFramework.UI
{
    /// <summary>
    /// Provides a static class for handling touch events.
    /// </summary>
    public static class Touch
    {
        private static bool _initialized = false;
        private static TouchPanel _activeTouchPanel = null;

        /// <summary>
        /// Initializes touch processing and adds a touch event processor and listener.
        /// </summary>
        /// <param name="touchEventListener">The listener for touch events.</param>
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

        /// <summary>
        /// Gets the active touch panel.
        /// </summary>
        public static TouchPanel ActiveTouchPanel
        {
            get
            {
                return _activeTouchPanel;
            }
        }
    }
}
