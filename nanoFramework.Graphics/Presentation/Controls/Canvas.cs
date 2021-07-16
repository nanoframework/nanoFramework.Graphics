//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using System;

namespace nanoFramework.Presentation.Controls
{
    /// <summary>
    /// 
    /// 
    /// </summary>
    public class Canvas : Panel
    {
        /// <summary>
        /// 
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
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static int GetBottom(UIElement e)
        {
            return GetAnchorValue(e, Edge_Bottom);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="bottom"></param>
        public static void SetBottom(UIElement e, int bottom)
        {
            SetAnchorValue(e, Edge_Bottom, bottom);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static int GetLeft(UIElement e)
        {
            return GetAnchorValue(e, Edge_Left);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="left"></param>
        public static void SetLeft(UIElement e, int left)
        {
            SetAnchorValue(e, Edge_Left, left);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static int GetRight(UIElement e)
        {
            return GetAnchorValue(e, Edge_Right);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="right"></param>
        public static void SetRight(UIElement e, int right)
        {
            SetAnchorValue(e, Edge_Right, right);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static int GetTop(UIElement e)
        {
            return GetAnchorValue(e, Edge_Top);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="top"></param>
        public static void SetTop(UIElement e, int top)
        {
            SetAnchorValue(e, Edge_Top, top);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arrangeWidth"></param>
        /// <param name="arrangeHeight"></param>
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
        /// 
        /// </summary>
        /// <param name="availableWidth"></param>
        /// <param name="availableHeight"></param>
        /// <param name="desiredWidth"></param>
        /// <param name="desiredHeight"></param>
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


