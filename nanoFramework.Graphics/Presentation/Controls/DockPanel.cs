//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using System;
using System.Collections;
using nanoFramework.UI;

namespace nanoFramework.Presentation.Controls
{
    /// <summary>
    /// Dock - Enum which describes how to position and stretch the child of a DockPanel.
    /// </summary> 
    /// <seealso cref="DockPanel" />
    public enum Dock
    {
        /// <summary>
        /// Position this child at the left of the remaining space. 
        /// </summary>
        Left,

        /// <summary> 
        /// Position this child at the top of the remaining space.
        /// </summary> 
        Top,

        /// <summary> 
        /// Position this child at the right of the remaining space.
        /// </summary>
        Right,

        /// <summary>
        /// Position this child at the bottom of the remaining space. 
        /// </summary>
        Bottom
    }

    /// <summary> 
    /// DockPanel is used to size and position children inward from the edges of available space.
    /// 
    /// A <see cref="Dock" /> enum (see <see cref="SetDock" /> and <see cref="GetDock" />) 
    /// determines on which size a child is placed.  Children are stacked in order from these edges until
    /// there is no more space; this happens when previous children have consumed all available space, or a child 
    /// with Dock set to Fill is encountered.
    /// </summary>
    public class DockPanel : Panel
    {
        private static ArrayList DockPropertiesKeys = new ArrayList();
        private static ArrayList DockPropertiesValues = new ArrayList();
        
        /// <summary> 
        /// DockPanel computes a position and final size for each of its children based upon their <see cref="Dock" /> enum and sizing properties. 
        /// </summary> 
        /// <param name="arrangeWidth">Width that DockPanel will assume to position children.</param>
        /// <param name="arrangeHeight">Height that DockPanel will assume to position children.</param>
        protected override void ArrangeOverride(int arrangeWidth, int arrangeHeight)
        {
            int totalChildrenCount   = Children.Count;
            int nonFillChildrenCount = totalChildrenCount - (LastChildFill ? 1 : 0);

            int accumulatedLeft   = 0;
            int accumulatedTop    = 0;
            int accumulatedRight  = 0;
            int accumulatedBottom = 0;

            for (int i = 0; i < totalChildrenCount; i++)
            {
                UIElement child = Children[i];
                if (child == null) continue;

                int desiredWidth, desiredHeight;
                child.GetDesiredSize(out desiredWidth, out desiredHeight);

                int finalX = accumulatedLeft, finalY = accumulatedTop;
                int finalWidth = Mathematics.Max(0, arrangeWidth - accumulatedLeft - accumulatedRight);
                int finalHeight = Mathematics.Max(0, arrangeHeight - accumulatedTop - accumulatedBottom);

                if (i < nonFillChildrenCount)
                    switch (DockPanel.GetDock(child))
                    {
                        case Dock.Left:
                            accumulatedLeft += desiredWidth;
                            finalWidth = desiredWidth;
                            break;

                        case Dock.Top:
                            accumulatedTop += desiredHeight;
                            finalHeight = desiredHeight;
                            break;

                        case Dock.Right:
                            accumulatedRight += desiredWidth;
                            finalX = Mathematics.Max(0, arrangeWidth - accumulatedRight);
                            finalWidth = desiredWidth;
                            break;

                        case Dock.Bottom:
                            accumulatedBottom += desiredHeight;
                            finalY = Mathematics.Max(0, arrangeHeight - accumulatedBottom);
                            finalHeight = desiredHeight;
                            break;
                    }

                child.Arrange(finalX, finalY, finalWidth, finalHeight);
            }
        }

        /// <summary>
        /// Updates DesiredSize of the DockPanel.
        /// Called by parent UIElement.
        /// This is the first pass of layout.
        /// </summary>
        /// <param name="availableWidth">An "upper limit" that the return value should not exceed.</param>
        /// <param name="availableHeight">An "upper limit" that the return value should not exceed.</param>
        /// <param name="desiredWidth">The Panel's desired width.</param>
        /// <param name="desiredHeight">The Panel's desired height.</param>
        protected override void MeasureOverride(int availableWidth, int availableHeight, out int desiredWidth, out int desiredHeight)
        {
            int count = Children.Count;
            int accumulatedWidth  = 0;
            int accumulatedHeight = 0;

            desiredWidth  = 0;
            desiredHeight = 0;

            for (int i = 0; i < count; i++)
            {
                UIElement child = Children[i];

                if (child == null) continue;

                int childAvailableWidth = Mathematics.Max(0, availableWidth - accumulatedWidth);
                int childAvailableHeight = Mathematics.Max(0, availableHeight - accumulatedHeight);
                child.Measure(childAvailableWidth, childAvailableHeight);

                int childDesiredWidth;
                int childDesiredHeight;
                child.GetDesiredSize(out childDesiredWidth, out childDesiredHeight);

                switch (DockPanel.GetDock(child))
                {
                    case Dock.Left:
                    case Dock.Right:
                        desiredHeight = Mathematics.Max(desiredHeight, accumulatedHeight + childDesiredHeight);
                        accumulatedWidth += childDesiredWidth;
                        break;
                    case Dock.Top:
                    case Dock.Bottom:
                        desiredWidth = Mathematics.Max(desiredWidth, accumulatedWidth + childDesiredWidth);
                        accumulatedHeight += childDesiredHeight;
                        break;
                }
            }

            desiredWidth = Mathematics.Max(desiredWidth, accumulatedWidth);
            desiredHeight = Mathematics.Max(desiredHeight, accumulatedHeight);
        }

        /// <summary> 
        /// Reads the pseudo-attached property Dock from the given element.
        /// </summary> 
        /// <param name="element">UIElement from which to read the pseudo-attached property.</param>
        /// <returns>The property's value.</returns>
        public static Dock GetDock(UIElement element)
        {
            if (element == null)
                throw new ArgumentNullException("element");

            int index = DockPropertiesKeys.IndexOf(element);            
            if (index != -1)
                return (Dock)DockPropertiesValues[index]; 
            
            return Dock.Left;           
        }

        /// <summary>
        /// Writes the pseudo-attached property Dock to the given element. 
        /// </summary>
        /// <param name="element">UIElement to which to write the attached property.</param> 
        /// <param name="dock">The property value to set.</param> 
        public static void SetDock(UIElement element, Dock dock)
        {
            if (element == null)
                throw new ArgumentNullException("element");

            if (!IsValidDock(dock))
                throw new ArgumentException(null, "dock");

            int index = DockPropertiesKeys.IndexOf(element);
            if (index == -1)
            {
                index =
                    DockPropertiesKeys.Add(element);
                    DockPropertiesValues.Add(dock);
            }
            
            DockPropertiesValues[index] = dock;
        }

        internal static bool IsValidDock(object o)
        {
            Dock dock = (Dock)o;

            return (dock == Dock.Left
                    || dock == Dock.Top
                    || dock == Dock.Right
                    || dock == Dock.Bottom);
        }

        private bool _lastChildFill = true;
        /// <summary>
        /// 
        /// </summary>
        public bool LastChildFill
        {
            get
            {
                return _lastChildFill;
            }
            set
            {
                if (value != _lastChildFill)
                {
                    _lastChildFill = value;
                    InvalidateMeasure();
                }
            }
        }
    }
}