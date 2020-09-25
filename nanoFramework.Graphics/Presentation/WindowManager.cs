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
    /// 
    /// </summary>
    /// <param name="dc"></param>
    public delegate void PostRenderEventHandler(DrawingContext dc);

    /// <summary>
    /// 
    /// </summary>
    public class WindowManager : Controls.Canvas
    {
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
        /// 
        /// </summary>
        /// <param name="availableWidth"></param>
        /// <param name="availableHeight"></param>
        /// <param name="desiredWidth"></param>
        /// <param name="desiredHeight"></param>
        protected override void MeasureOverride(int availableWidth, int availableHeight, out int desiredWidth, out int desiredHeight)
        {
            base.MeasureOverride(availableWidth, availableHeight, out desiredWidth, out desiredHeight);
            desiredWidth = DisplayControl.ScreenWidth;
            desiredHeight = DisplayControl.ScreenHeight;
        }

        internal void SetTopMost(Window window)
        {
            UIElementCollection children = LogicalChildren;

            if (!IsTopMost(window))
            {
                children.Remove(window);
                children.Add(window);
            }
        }

        internal bool IsTopMost(Window window)
        {
            int index = LogicalChildren.IndexOf(window);
            return (index >= 0 && index == LogicalChildren.Count - 1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="added"></param>
        /// <param name="removed"></param>
        /// <param name="indexAffected"></param>
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
        /// 
        /// </summary>
        public static WindowManager Instance;


        private PostRenderEventHandler _postRenderHandler;

        /// <summary>
        /// 
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
        /// 
        /// </summary>
        /// <param name="dc"></param>
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


