//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using nanoFramework.Presentation.Media;
using System;

namespace nanoFramework.Presentation.Controls
{
/// <summary>
/// 
/// </summary>
    public class Border : ContentControl
    {
        /// <summary>
        /// 
        /// </summary>
        public Border()
        {
            _borderBrush = new SolidColorBrush(Color.Black);

            _borderLeft = _borderTop = _borderRight = _borderBottom = 1;
        }

        /// <summary>
        /// 
        /// </summary>
        public Brush BorderBrush
        {
            get
            {
                VerifyAccess();

                return _borderBrush;
            }

            set
            {
                VerifyAccess();

                _borderBrush = value;
                Invalidate();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="top"></param>
        /// <param name="right"></param>
        /// <param name="bottom"></param>
        public void GetBorderThickness(out int left, out int top, out int right, out int bottom)
        {
            left = _borderLeft;
            top = _borderTop;
            right = _borderRight;
            bottom = _borderBottom;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="length"></param>
        public void SetBorderThickness(int length)
        {
            // no need to verify access here as the next call will do it
            SetBorderThickness(length, length, length, length);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="top"></param>
        /// <param name="right"></param>
        /// <param name="bottom"></param>
        public void SetBorderThickness(int left, int top, int right, int bottom)
        {
            VerifyAccess();

            // Negative values are not valid (same behavior as desktop WPF).
            if ((left < 0) || (right < 0) || (top < 0) || (bottom < 0))
            {
                string errorMessage = "'" + left.ToString() + "," + top.ToString() + "," + right.ToString() + "," + bottom.ToString() + "' is not a valid value 'BorderThickness'";

                throw new ArgumentException(errorMessage);
            }

            _borderLeft = left;
            _borderTop = top;
            _borderRight = right;
            _borderBottom = bottom;
            InvalidateMeasure();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arrangeWidth"></param>
        /// <param name="arrangeHeight"></param>
        protected override void ArrangeOverride(int arrangeWidth, int arrangeHeight)
        {
            UIElement child = Child;
            if (child != null)
            {
                child.Arrange(_borderLeft,
                              _borderTop,
                              arrangeWidth - _borderLeft - _borderRight,
                              arrangeHeight - _borderTop - _borderBottom);
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
            UIElement child = Child;
            if (child != null)
            {
                int horizontalBorder = _borderLeft + _borderRight;
                int verticalBorder = _borderTop + _borderBottom;

                child.Measure(availableWidth - horizontalBorder, availableHeight - verticalBorder);

                child.GetDesiredSize(out desiredWidth, out desiredHeight);
                desiredWidth += horizontalBorder;
                desiredHeight += verticalBorder;
            }
            else
            {
                desiredWidth = desiredHeight = 0;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dc"></param>
        public override void OnRender(DrawingContext dc)
        {
            int width = _renderWidth;
            int height = _renderHeight;

            // Border
            //
            dc.DrawRectangle(_borderBrush, null, 0, 0, width, height);

            // Background
            //
            if (_background != null)
            {
                dc.DrawRectangle(_background, null, _borderLeft, _borderTop,
                                                     width - _borderLeft - _borderRight,
                                                     height - _borderTop - _borderBottom);
            }
        }

        private Brush _borderBrush;
        private int _borderLeft, _borderTop, _borderRight, _borderBottom;
    }
}


