//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using nanoFramework.Presentation;
using System;

namespace nanoFramework.UI.Input
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void TouchEventHandler(object sender, TouchEventArgs e);

    /// <summary>
    /// 
    /// </summary>
    public enum CaptureMode
    {
        /// <summary>
        ///  None
        /// </summary>
        None,

        /// <summary>
        ///  Element
        /// </summary>
        Element,

        /// <summary>
        ///  SubTree
        /// </summary>
        SubTree,
    }

    /// <summary>
    /// 
    /// </summary>
    public static class TouchCapture
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static bool Capture(UIElement element)
        {
            return Capture(element, CaptureMode.Element);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static bool Capture(UIElement element, CaptureMode mode)
        {
            if (mode != CaptureMode.None)
            {
                if (element == null)
                {
                    throw new ArgumentException();
                }

                // Make sure the element is attached
                // to the MainWindow subtree.
                if (!IsMainWindowChild(element))
                {
                    throw new ArgumentException();
                }

                if (mode == CaptureMode.SubTree)
                {
                    throw new NotImplementedException();
                }

                if (mode == CaptureMode.Element)
                {
                    _captureElement = element;
                }
            }
            else
            {
                _captureElement = null;
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        public static UIElement Captured
        {
            get
            {
                return _captureElement;
            }
        }

        private static bool IsMainWindowChild(UIElement element)
        {
            UIElement mainWindow = Application.Current.MainWindow;
            while (element != null)
            {
                if (element == mainWindow)
                    return true;

                element = element.Parent;
            }

            return false;
        }

        private static UIElement _captureElement = null;
    }

    /// <summary>
    /// 
    /// </summary>
    public sealed class TouchEvents
    {
        // Fields
        /// <summary>
        /// 
        /// </summary>
        public static readonly RoutedEvent TouchDownEvent = new RoutedEvent("TouchDownEvent", RoutingStrategy.Tunnel, typeof(TouchEventArgs));
        /// <summary>
        /// 
        /// </summary>
        public static readonly RoutedEvent TouchMoveEvent = new RoutedEvent("TouchMoveEvent", RoutingStrategy.Tunnel, typeof(TouchEventArgs));
        /// <summary>
        /// 
        /// </summary>
        public static readonly RoutedEvent TouchUpEvent = new RoutedEvent("TouchUpEvent", RoutingStrategy.Tunnel, typeof(TouchEventArgs));
    }

    /// <summary>
    /// 
    /// </summary>
    public class TouchEventArgs : InputEventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        public TouchInput[] Touches;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputDevice"></param>
        /// <param name="timestamp"></param>
        /// <param name="touches"></param>
        public TouchEventArgs(InputDevice inputDevice, DateTime timestamp, TouchInput[] touches)
            : base(inputDevice, timestamp)
        {
            Touches = touches;
        }

        ///
        public void GetPosition(UIElement relativeTo, int touchIndex, out int x, out int y)
        {
            x = Touches[touchIndex].X;
            y = Touches[touchIndex].Y;

            relativeTo.PointToClient(ref x, ref y);
        }
    }
}


