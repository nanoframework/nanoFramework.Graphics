//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using nanoFramework.Presentation.Media;
using nanoFramework.UI.Input;
using nanoFramework.UI;

namespace nanoFramework.Presentation
{
    /// <summary>
    /// Delegate for handling post render events.
    /// </summary>
    /// <param name="dc">The drawing context.</param>
    public delegate void PostRenderEventHandler(DrawingContext dc);

    /// <summary>
    /// Provides a container for windows and manages rendering and focus.
    /// </summary>
    public class WindowManager : Controls.Canvas
    {

        private PostRenderEventHandler _postRenderHandler;

        /// <summary>
        /// Initializes a new instance of the WindowManager class.
        /// </summary>
        private WindowManager()
        {
            //
            // initially measure and arrange ourselves.
            //
            Instance = this;

            //
            // WindowManagers have no parents but they are Visible.
            //
            _flags = _flags | Flags.IsVisibleCache;

            Measure(Media.Constants.MaxExtent, Media.Constants.MaxExtent);

            int desiredWidth, desiredHeight;

            GetDesiredSize(out desiredWidth, out desiredHeight);

            Arrange(0, 0, desiredWidth, desiredHeight);
        }

        /// <summary>
        /// Ensures that there is an instance of the WindowManager class.
        /// </summary>
        internal static WindowManager EnsureInstance()
        {
            if (Instance == null)
            {
                WindowManager wm = new WindowManager();
                // implicitly the window manager is responsible for posting renders
                wm._flags |= Flags.ShouldPostRender;
            }

            return Instance;
        }

        /// <summary>
        /// Measures the child elements of the WindowManager.
        /// </summary>
        /// <param name="availableWidth">The available width.</param>
        /// <param name="availableHeight">The available height.</param>
        /// <param name="desiredWidth">The desired width.</param>
        /// <param name="desiredHeight">The desired height.</param>
        protected override void MeasureOverride(int availableWidth, int availableHeight, out int desiredWidth, out int desiredHeight)
        {
            base.MeasureOverride(availableWidth, availableHeight, out desiredWidth, out desiredHeight);
            desiredWidth = DisplayControl.ScreenWidth;
            desiredHeight = DisplayControl.ScreenHeight;
        }

        /// <summary>
        /// Sets the specified window to be the topmost window.
        /// </summary>
        /// <param name="window">The window to set as topmost.</param>
        internal void SetTopMost(Window window)
        {
            UIElementCollection children = LogicalChildren;

            if (!IsTopMost(window))
            {
                children.Remove(window);
                children.Add(window);
            }
        }

        /// <summary>
        /// Determines if the specified window is the topmost window.
        /// </summary>
        /// <param name="window">The window to check.</param>
        /// <returns>true if the specified window is the topmost window; otherwise, false.</returns>
        internal bool IsTopMost(Window window)
        {
            int index = LogicalChildren.IndexOf(window);
            return (index >= 0 && index == LogicalChildren.Count - 1);
        }

        /// <summary>
        /// Called when a child element is added or removed from the WindowManager.
        /// </summary>
        /// <param name="added">The child element that was added.</param>
        /// <param name="removed">The child element that was removed.</param>
        /// <param name="indexAffected">The index of the child element that was affected.</param>
        protected internal override void OnChildrenChanged(UIElement added, UIElement removed, int indexAffected)
        {
            base.OnChildrenChanged(added, removed, indexAffected);

            UIElementCollection children = LogicalChildren;
            int last = children.Count - 1;

            // something was added, and it's the topmost. Make sure it is visible before setting focus
            if (added != null && indexAffected == last && Visibility.Visible == added.Visibility)
            {
                Buttons.Focus(added);
                TouchCapture.Capture(added);
            }

            // something was removed and it lost focus to us.
            if (removed != null && this.IsFocused)
            {
                // we still have a window left, so make it focused.
                if (last >= 0)
                {
                    Buttons.Focus(children[last]);
                    TouchCapture.Capture(children[last]);
                }
            }
        }

        /// <summary>
        /// Gets or sets the WindowManager instance.
        /// </summary>
        public static WindowManager Instance;

        /// <summary>
        /// Occurs when post-rendering is performed on the WindowManager.
        /// </summary>
        public event PostRenderEventHandler PostRender
        {
            add
            {
                _postRenderHandler += value;
            }

            remove
            {
                _postRenderHandler -= value;
            }
        }

        /// <summary>
        /// Represents the method that handles post-rendering of the WindowManager.
        /// </summary>
        /// <param name="dc">The DrawingContext to use for post-rendering.</param>
        protected internal override void RenderRecursive(DrawingContext dc)
        {
            base.RenderRecursive(dc);

            if (_postRenderHandler != null)
            {
                _postRenderHandler(dc);
            }
        }
    }
}
