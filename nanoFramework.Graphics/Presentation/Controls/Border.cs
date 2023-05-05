//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using nanoFramework.Presentation.Media;
using System;
using System.Drawing;

namespace nanoFramework.Presentation.Controls
{
    /// <summary>
    /// Represents a WPF-like Border control that provides a border and background for its content.
    /// </summary>
    public class Border : ContentControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Border"/> class.
        /// </summary>
        public Border()
        {
            _borderBrush = new SolidColorBrush(Color.Black);

            _borderLeft = _borderTop = _borderRight = _borderBottom = 1;
        }

        /// <summary>
        /// Gets or sets the Brush used to draw the border of the <see cref="Border"/> control.
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
        /// Gets the thickness of the border of the <see cref="Border"/> control.
        /// </summary>
        /// <param name="left">Receives the thickness of the left border.</param>
        /// <param name="top">Receives the thickness of the top border.</param>
        /// <param name="right">Receives the thickness of the right border.</param>
        /// <param name="bottom">Receives the thickness of the bottom border.</param>
        public void GetBorderThickness(out int left, out int top, out int right, out int bottom)
        {
            left = _borderLeft;
            top = _borderTop;
            right = _borderRight;
            bottom = _borderBottom;
        }

        /// <summary>
        /// Sets the thickness of the border of the <see cref="Border"/> control.
        /// </summary>
        /// <param name="length">The thickness of all four borders.</param>
        public void SetBorderThickness(int length)
        {
            // no need to verify access here as the next call will do it
            SetBorderThickness(length, length, length, length);
        }

        /// <summary>
        /// Sets the thickness of the border of the <see cref="Border"/> control.
        /// </summary>
        /// <param name="left">The thickness of the left border.</param>
        /// <param name="top">The thickness of the top border.</param>
        /// <param name="right">The thickness of the right border.</param>
        /// <param name="bottom">The thickness of the bottom border.</param>
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
        /// Arranges the content of the <see cref="Border"/> control.
        /// </summary>
        /// <param name="arrangeWidth">The width of the layout slot for the control.</param>
        /// <param name="arrangeHeight">The height of the layout slot for the control.</param>
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
        /// Draws the content of the Border control.
        /// </summary>
        /// <param name="dc">The DrawingContext.</param>
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


