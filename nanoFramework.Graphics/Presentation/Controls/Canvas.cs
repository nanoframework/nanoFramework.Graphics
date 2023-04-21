//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using System;

namespace nanoFramework.Presentation.Controls
{
    /// <summary>
    /// Represents a canvas panel that can be used to arrange child elements using absolute positioning.
    /// </summary>
    public class Canvas : Panel
    {
        /// <summary>
        /// Initializes a new instance of the Canvas class.
        /// </summary>
        public Canvas()
        {
        }

        private const int Edge_Left = 0x1;
        private const int Edge_Right = 0x2;
        private const int Edge_Top = 0x4;
        private const int Edge_Bottom = 0x8;
        private const int Edge_LeftRight = Edge_Left | Edge_Right;
        private const int Edge_TopBottom = Edge_Top | Edge_Bottom;

        private static int GetAnchorValue(UIElement e, int edge)
        {
            UIElement.Pair anchorInfo = e._anchorInfo;
            if (anchorInfo != null)
            {
                if ((anchorInfo._status & edge) != 0)
                {
                    return ((edge & Edge_LeftRight) != 0) ? anchorInfo._first : anchorInfo._second;
                }
            }

            return 0;
        }

        private static void SetAnchorValue(UIElement e, int edge, int val)
        {
            e.VerifyAccess();

            UIElement.Pair anchorInfo = e._anchorInfo;
            if (anchorInfo == null)
            {
                anchorInfo = new UIElement.Pair();
                e._anchorInfo = anchorInfo;
            }

            if ((edge & Edge_LeftRight) != 0)
            {
                anchorInfo._first = val;
                anchorInfo._status &= ~Edge_LeftRight;
            }
            else
            {
                anchorInfo._second = val;
                anchorInfo._status &= ~Edge_TopBottom;
            }

            anchorInfo._status |= edge;

            if (e.Parent != null)
            {
                e.Parent.InvalidateArrange();
            }
        }

        /// <summary>
        /// Gets the value of the Bottom attached property of the specified element.
        /// </summary>
        /// <param name="e">The element to get the Bottom attached property for.</param>
        /// <returns>The value of the Bottom attached property of the specified element.</returns>
        public static int GetBottom(UIElement e)
        {
            return GetAnchorValue(e, Edge_Bottom);
        }

        /// <summary>
        /// Sets the value of the Bottom attached property of the specified element.
        /// </summary>
        /// <param name="e">The element to set the Bottom attached property for.</param>
        /// <param name="bottom">The value to set for the Bottom attached property.</param>
        public static void SetBottom(UIElement e, int bottom)
        {
            SetAnchorValue(e, Edge_Bottom, bottom);
        }

        /// <summary>
        /// Gets the value of the Left attached property of the specified element.
        /// </summary>
        /// <param name="e">The element to get the Left attached property for.</param>
        /// <returns>The value of the Left attached property of the specified element.</returns>
        public static int GetLeft(UIElement e)
        {
            return GetAnchorValue(e, Edge_Left);
        }

        /// <summary>
        /// Sets the value of the Left attached property of the specified element.
        /// </summary>
        /// <param name="e">The element to set the Left attached property for.</param>
        /// <param name="left">The value to set for the Left attached property.</param>
        public static void SetLeft(UIElement e, int left)
        {
            SetAnchorValue(e, Edge_Left, left);
        }

        /// <summary>
        /// Gets the value of the Right attached property of the specified element.
        /// </summary>
        /// <param name="e">The element to get the Right attached property for.</param>
        /// <returns>The value of the Right attached property of the specified element.</returns>
        public static int GetRight(UIElement e)
        {
            return GetAnchorValue(e, Edge_Right);
        }

        /// <summary>
        /// Sets the value of the Right attached property of the specified element.
        /// </summary>
        /// <param name="e">The element to set the Right attached property for.</param>
        /// <param name="right">The value to set for the Right attached property.</param>
        public static void SetRight(UIElement e, int right)
        {
            SetAnchorValue(e, Edge_Right, right);
        }

        /// <summary>
        /// Gets the value of the Top anchor for the specified UIElement.
        /// </summary>
        /// <param name="e">The UIElement to get the Top anchor value for.</param>
        /// <returns>The value of the Top anchor for the specified UIElement.</returns>
        public static int GetTop(UIElement e)
        {
            return GetAnchorValue(e, Edge_Top);
        }

        /// <summary>
        /// Sets the value of the Top anchor for the specified UIElement.
        /// </summary>
        /// <param name="e">The UIElement to set the Top anchor value for.</param>
        /// <param name="top">The value to set as the Top anchor for the specified UIElement.</param>
        public static void SetTop(UIElement e, int top)
        {
            SetAnchorValue(e, Edge_Top, top);
        }

        /// <summary>
        /// Arranges the child elements of the Canvas.
        /// </summary>
        /// <param name="arrangeWidth">The width of the area that the Canvas should use to arrange its children.</param>
        /// <param name="arrangeHeight">The height of the area that the Canvas should use to arrange its children.</param>
        protected override void ArrangeOverride(int arrangeWidth, int arrangeHeight)
        {
            VerifyAccess();

            UIElementCollection children = _logicalChildren;
            if (children != null)
            {
                int count = children.Count;
                for (int i = 0; i < count; i++)
                {
                    UIElement child = children[i];

                    int childWidth, childHeight;
                    child.GetDesiredSize(out childWidth, out childHeight);

                    UIElement.Pair anchorInfo = child._anchorInfo;
                    if (anchorInfo != null)
                    {
                        int status = anchorInfo._status;
                        child.Arrange(
                            ((status & Edge_Right) != 0) ? arrangeWidth - childWidth - anchorInfo._first : anchorInfo._first,
                            ((status & Edge_Bottom) != 0) ? arrangeHeight - childHeight - anchorInfo._second : anchorInfo._second,
                            childWidth,
                            childHeight);
                    }
                    else
                    {
                        child.Arrange(0, 0, childWidth, childHeight);
                    }
                }
            }
        }

        /// <summary>
        /// Measures the size required for the child elements of the Canvas.
        /// </summary>
        /// <param name="availableWidth">The available width that the Canvas can give to its children.</param>
        /// <param name="availableHeight">The available height that the Canvas can give to its children.</param>
        /// <param name="desiredWidth">The desired width of the Canvas.</param>
        /// <param name="desiredHeight">The desired height of the Canvas.</param>
        protected override void MeasureOverride(int availableWidth, int availableHeight, out int desiredWidth, out int desiredHeight)
        {
            UIElementCollection children = _logicalChildren;
            if (children != null)
            {
                for (int i = 0; i < children.Count; i++)
                {
                    children[i].Measure(Media.Constants.MaxExtent, Media.Constants.MaxExtent);
                }
            }

            desiredWidth = 0;
            desiredHeight = 0;
        }
    }
}
