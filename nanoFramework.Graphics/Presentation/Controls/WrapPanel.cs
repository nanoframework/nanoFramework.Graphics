//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using System;
using nanoFramework.UI;

namespace nanoFramework.Presentation.Controls
{
    /// <summary>
    /// WrapPanel is used to place child UIElements at sequential positions from left to the right 
    /// and then "wrap" the lines of children from top to the bottom.
    ///
    /// All children get the layout partition of size ItemWidth x ItemHeight.
    /// </summary>
    public class WrapPanel : Panel
    {
        private struct UVSize
        {
            internal int U;
            internal int V;
            private Orientation _orientation;

            internal UVSize(Orientation orientation, int width, int height)
            {
                U = V = 0;
                _orientation = orientation;
                Width = width;
                Height = height;
            }

            internal UVSize(Orientation orientation)
            {
                U = V = 0;
                _orientation = orientation;
            }

            internal int Width
            {
                get { return (_orientation == Orientation.Horizontal ? U : V); }
                set { if (_orientation == Orientation.Horizontal) U = value; else V = value; }
            }
            internal int Height
            {
                get { return (_orientation == Orientation.Horizontal ? V : U); }
                set { if (_orientation == Orientation.Horizontal) V = value; else U = value; }
            }
        } 

        /// <summary>
        /// <see cref="UIElement.ArrangeOverride"/> 
        /// </summary> 
        protected override void ArrangeOverride(int arrangeWidth, int arrangeHeight)
        {
            UVSize arrangeSize = new UVSize(_orientation, arrangeWidth, arrangeHeight);
            UVSize currentLineSize = new UVSize(_orientation);
            int accumulatedV = 0;

            bool itemWidthSet = _itemWidth != 0;
            bool itemHeightSet = _itemHeight != 0;
            bool useSetU = _orientation == Orientation.Horizontal ? itemWidthSet : itemHeightSet;
            int itemSetU = _orientation == Orientation.Horizontal ? _itemWidth : _itemHeight;

            int firstInLineIndex = 0;
            int count = Children.Count;
            for (int i = 0; i < count; i++)
            {
                UIElement child = Children[i];
                if (child == null) continue;

                int desiredWidth, desiredHeight;
                child.GetDesiredSize(out desiredWidth, out desiredHeight);

                UVSize childSize = new UVSize(_orientation,
                    itemWidthSet ? _itemWidth : desiredWidth,
                    itemHeightSet ? _itemHeight : desiredHeight);

                // does not fit on line
                if (currentLineSize.U + childSize.U > arrangeSize.U)
                {
                    // arrange previous line
                    ArrangeLine(accumulatedV, currentLineSize.V, firstInLineIndex, i /* exclusive */, useSetU, itemSetU);
                    accumulatedV += currentLineSize.V;

                    // this child is on new line
                    currentLineSize = childSize;

                    // child is bigger than available size
                    if (childSize.U > arrangeSize.U)
                    {
                        ArrangeLine(accumulatedV, childSize.V, i, i + 1, useSetU, itemSetU);
                        i++; // order of parameters evaluation is not guaranted

                        // this is the only child on line
                        accumulatedV += childSize.V;
                        currentLineSize = new UVSize(_orientation);
                    }

                    firstInLineIndex = i;
                }
                else
                {
                    currentLineSize.U += childSize.U;
                    currentLineSize.V = Mathematics.Max(childSize.V, currentLineSize.V);
                }
            }

            if (firstInLineIndex < count)
                ArrangeLine(accumulatedV, currentLineSize.V, firstInLineIndex, count, useSetU, itemSetU);
        }
        private void ArrangeLine(int v, int lineV, int indexStart, int indexEnd, bool useSetU, int itemSetU)
        {
            int u = 0;
            bool isHorizontal = _orientation == Orientation.Horizontal;

            for (int i = indexStart; i < indexEnd; i++)
            {
                UIElement child = Children[i];
                if (child == null) continue;

                UVSize childSize = new UVSize(_orientation);
                if (isHorizontal) child.GetDesiredSize(out childSize.U, out childSize.V);
                else child.GetDesiredSize(out childSize.V, out childSize.U);

                int layoutSlotU = useSetU ? itemSetU : childSize.U;

                if (isHorizontal) child.Arrange(u, v, layoutSlotU, lineV);
                else child.Arrange(v, u, lineV, layoutSlotU);

                u += layoutSlotU;
            }
        }

        /// <summary>
        /// <see cref="UIElement.MeasureOverride"/>
        /// </summary>
        protected override void MeasureOverride(int availableWidth, int availableHeight, out int desiredWidth, out int desiredHeight)
        {
            UVSize desiredSize = new UVSize(_orientation);
            UVSize availableSize = new UVSize(_orientation, availableWidth, availableHeight);
            UVSize currentLineSize = new UVSize(_orientation);

            bool itemWidthSet = _itemWidth != 0;
            bool itemHeightSet = _itemHeight != 0;

            int availableChildWidth = itemWidthSet ? _itemWidth : availableWidth;
            int availableChildHeight = itemHeightSet ? _itemHeight : availableHeight;

            int count = Children.Count;
            for (int i = 0; i < count; i++)
            {
                UIElement child = Children[i];
                if (child == null) continue;

                child.Measure(availableChildWidth, availableChildHeight);

                int desiredChildWidth, desiredChildHeight;
                child.GetDesiredSize(out desiredChildWidth, out desiredChildHeight);

                UVSize childSize = new UVSize(_orientation,
                    itemWidthSet ? _itemWidth : desiredChildWidth,
                    itemHeightSet ? _itemHeight : desiredChildHeight);

                if (currentLineSize.U + childSize.U > availableSize.U)
                {
                    desiredSize.U = Mathematics.Max(currentLineSize.U, desiredSize.U);
                    desiredSize.V += currentLineSize.V;
                    
                    currentLineSize = childSize;
                    if (childSize.U > availableSize.U)
                    {
                        desiredSize.U = Mathematics.Max(childSize.U, desiredSize.U);
                        desiredSize.V = childSize.V;
                        currentLineSize = new UVSize(_orientation);
                    }
                }
                else
                {
                    currentLineSize.U += childSize.U;
                    currentLineSize.V = Mathematics.Max(childSize.V, currentLineSize.V);
                }
            }

            desiredWidth = Mathematics.Max(currentLineSize.U, desiredSize.U);
            desiredHeight = desiredSize.V + currentLineSize.V;
        }

        private int _itemWidth = 0;
        /// <summary> 
        /// The ItemWidth and ItemHeight properties specify the size of all items in the WrapPanel.
        /// Note that children of WrapPanel may have their own Width/Height properties set - the ItemWidth/ItemHeight 
        /// specifies the size of "layout partition" reserved by WrapPanel for the child.
        /// If this property is not set (equal to 0) - the size of layout 
        /// partition is equal to DesiredSize of the child element.
        /// </summary>
        public int ItemWidth
        {
            get { return _itemWidth; }
            set
            {
                if (_itemWidth != value)
                {
                    if (!IsWidthHeightValid(value))
                        throw new ArgumentOutOfRangeException("value");

                    _itemWidth = value;
                    InvalidateMeasure();
                }
            }
        }

        private int _itemHeight = 0;
        /// <summary> 
        /// The ItemWidth and ItemHeight properties specify the size of all items in the WrapPanel.
        /// Note that children of WrapPanel may have their own Width/Height properties set - the ItemWidth/ItemHeight 
        /// specifies the size of "layout partition" reserved by WrapPanel for the child.
        /// If this property is not set (equal to 0) - the size of layout 
        /// partition is equal to DesiredSize of the child element.
        /// </summary>
        public int ItemHeight
        {
            get { return _itemHeight; }
            set
            {
                if (_itemHeight != value)
                {
                    if (!IsWidthHeightValid(value))
                        throw new ArgumentOutOfRangeException("value");

                    _itemHeight = value;
                    InvalidateMeasure();
                }
            }
        }

        private static bool IsWidthHeightValid(object value)
        {
            int v = (int)value;
            return v >= 0;
        }

        private Orientation _orientation = Orientation.Horizontal;
        /// <summary>
        /// Specifies dimension of children positioning in absence of wrapping. 
        /// Wrapping occurs in orthogonal direction. For example, if Orientation is Horizontal,
        /// the items try to form horizontal rows first and if needed are wrapped and form vertical stack of rows. 
        /// If Orientation is Vertical, items first positioned in a vertical column, and if there is 
        /// not enough space - wrapping creates additional columns in horizontal dimension.
        /// </summary> 
        public Orientation Orientation
        {
            get { return _orientation; }
            set
            {
                if (value != _orientation)
                {
                    _orientation = value;
                    InvalidateMeasure();
                }
            }
        }
    }
}