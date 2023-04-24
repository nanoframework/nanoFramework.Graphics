//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using System;
using System.Diagnostics;
using nanoFramework.UI.Input;
using nanoFramework.UI;


namespace nanoFramework.Presentation.Controls
{
    /// <summary>
    /// Represents a control that provides a scrollable view of content in a container.
    /// </summary>
    public class ScrollViewer : ContentControl
    {
        /// <summary>
        /// Initializes a new instance of the ScrollViewer class.
        /// </summary>
        public ScrollViewer()
        {
            this.HorizontalAlignment = HorizontalAlignment.Left;
            this.VerticalAlignment = VerticalAlignment.Stretch;
        }

        /// <summary>
        /// Occurs when the ScrollViewer's scrolling state has changed.
        /// </summary>
        public event ScrollChangedEventHandler ScrollChanged
        {
            add
            {
                VerifyAccess();

                _scrollChanged += value;
            }

            remove
            {
                VerifyAccess();

                _scrollChanged -= value;
            }
        }

        /// <summary>
        /// Gets or sets the horizontal offset of the ScrollViewer's content.
        /// </summary>
        public int HorizontalOffset
        {
            get
            {
                return _horizontalOffset;
            }

            set
            {
                VerifyAccess();

                if (value < 0)
                {
                    value = 0;
                }
                else if ((_flags & Flags.NeverArranged) == 0 && value > _scrollableWidth)
                {
                    value = _scrollableWidth;
                }

                if (_horizontalOffset != value)
                {
                    _horizontalOffset = value;
                    InvalidateArrange();
                }
            }
        }

        /// <summary>
        /// Gets or sets the vertical offset of the ScrollViewer's content.
        /// </summary>
        public int VerticalOffset
        {
            get
            {
                return _verticalOffset;
            }

            set
            {
                VerifyAccess();

                if (value < 0)
                {
                    value = 0;
                }
                else if ((_flags & Flags.NeverArranged) == 0 && value > _scrollableHeight)
                {
                    value = _scrollableHeight;
                }

                if (_verticalOffset != value)
                {
                    _verticalOffset = value;
                    InvalidateArrange();
                }
            }
        }

        /// <summary>
        /// Gets the extent height of the ScrollViewer's content.
        /// </summary>
        public int ExtentHeight
        {
            get
            {
                return _extentHeight;
            }
        }

        /// <summary>
        /// Gets the extent width of the ScrollViewer's content.
        /// </summary>
        public int ExtentWidth
        {
            get
            {
                return _extentWidth;
            }
        }

        /// <summary>
        /// Gets or sets the width of each line in the ScrollViewer's content.
        /// </summary>
        public int LineWidth
        {
            get
            {
                return _lineWidth;
            }

            set
            {
                VerifyAccess();

                if (value < 0)
                {
                    throw new System.ArgumentOutOfRangeException("LineWidth");
                }

                _lineWidth = value;
            }
        }

        /// <summary>
        /// Gets or sets the height of each line in the ScrollViewer's content.
        /// </summary>
        public int LineHeight
        {
            get
            {
                return _lineHeight;
            }

            set
            {
                VerifyAccess();

                if (value < 0)
                {
                    throw new System.ArgumentOutOfRangeException("LineHeight");
                }

                _lineHeight = value;
            }
        }

        /// <summary>
        /// Gets or sets the style used for scrolling in the ScrollViewer.
        /// </summary>
        public ScrollingStyle ScrollingStyle
        {
            get
            {
                return _scrollingStyle;
            }

            set
            {
                VerifyAccess();

                if (value < ScrollingStyle.First || value > ScrollingStyle.Last)
                {
                    throw new ArgumentOutOfRangeException("ScrollingStyle", "Invalid Enum");
                }

                _scrollingStyle = value;
            }
        }

        /// <summary>
        /// Measures the size required for the ScrollViewer and its content.
        /// </summary>
        /// <param name="availableWidth">The available width for the ScrollViewer.</param>
        /// <param name="availableHeight">The available height for the ScrollViewer.</param>
        /// <param name="desiredWidth">The desired width of the ScrollViewer.</param>
        /// <param name="desiredHeight">The desired height of the ScrollViewer.</param>
        protected override void MeasureOverride(int availableWidth, int availableHeight, out int desiredWidth, out int desiredHeight)
        {
            UIElement child = this.Child;
            if (child != null && child.Visibility != Visibility.Collapsed)
            {
                child.Measure((HorizontalAlignment == HorizontalAlignment.Stretch) ? Media.Constants.MaxExtent : availableWidth, (VerticalAlignment == VerticalAlignment.Stretch) ? Media.Constants.MaxExtent : availableHeight);
                child.GetDesiredSize(out desiredWidth, out desiredHeight);
                _extentHeight = child._unclippedHeight;
                _extentWidth = child._unclippedWidth;
            }
            else
            {
                desiredWidth = desiredHeight = 0;
                _extentHeight = _extentWidth = 0;
            }
        }

        /// <summary>
        /// Arranges the ScrollViewer and its content.
        /// </summary>
        /// <param name="arrangeWidth">The arranged width of the ScrollViewer.</param>
        /// <param name="arrangeHeight">The arranged height of the ScrollViewer.</param>
        protected override void ArrangeOverride(int arrangeWidth, int arrangeHeight)
        {
            UIElement child = this.Child;
            if (child != null)
            {
                // Clip scroll-offset if necessary
                //
                _scrollableWidth = Mathematics.Max(0, ExtentWidth - arrangeWidth);
                _scrollableHeight = Mathematics.Max(0, ExtentHeight - arrangeHeight);
                _horizontalOffset = Mathematics.Min(_horizontalOffset, _scrollableWidth);
                _verticalOffset = Mathematics.Min(_verticalOffset, _scrollableHeight);

                //Debug.Assert(_horizontalOffset >= 0);
                //Debug.Assert(_verticalOffset >= 0);

                child.Arrange(-_horizontalOffset,
                               -_verticalOffset,
                               Mathematics.Max(arrangeWidth, ExtentWidth),
                               Mathematics.Max(arrangeHeight, ExtentHeight));
            }
            else
            {
                _horizontalOffset = _verticalOffset = 0;
            }

            InvalidateScrollInfo();
        }

        /// <summary>
        /// Scrolls down by one line in the ScrollViewer.
        /// </summary>
        public void LineDown()
        {
            VerticalOffset += _lineHeight;
        }

        /// <summary>
        /// Scrolls the content to the left by a single line width.
        /// </summary>
        public void LineLeft()
        {
            HorizontalOffset -= _lineWidth;
        }

        /// <summary>
        /// Scrolls the content to the right by a single line width.
        /// </summary>
        public void LineRight()
        {
            HorizontalOffset += _lineWidth;
        }

        /// <summary>
        /// Scrolls the content to the right by a single line width.
        /// </summary>
        public void LineUp()
        {
            VerticalOffset -= _lineHeight;
        }

        /// <summary>
        /// Scrolls the content down by the height of the viewport.
        /// </summary>
        public void PageDown()
        {
            VerticalOffset += ActualHeight;
        }

        /// <summary>
        /// Scrolls the content to the left by the width of the viewport.
        /// </summary>
        public void PageLeft()
        {
            HorizontalOffset -= ActualWidth;
        }

        /// <summary>
        /// Scrolls the content to the right by the width of the viewport.
        /// </summary>
        public void PageRight()
        {
            HorizontalOffset += ActualWidth;
        }

        /// <summary>
        /// Scrolls the content up by the height of the viewport.
        /// </summary>
        public void PageUp()
        {
            VerticalOffset -= ActualHeight;
        }

        private void InvalidateScrollInfo()
        {
            if (_scrollChanged != null)
            {
                int deltaX = _horizontalOffset - _previousHorizontalOffset;
                int deltaY = _verticalOffset - _previousVerticalOffset;
                _scrollChanged(this, new ScrollChangedEventArgs(_horizontalOffset, _verticalOffset, deltaX, deltaY));
            }

            _previousHorizontalOffset = _horizontalOffset;
            _previousVerticalOffset = _verticalOffset;
        }

        /// <summary>
        /// Handles button down events and scrolls the content accordingly.
        /// </summary>
        /// <param name="e">The button event arguments.</param>
        protected override void OnButtonDown(ButtonEventArgs e)
        {
            switch (e.Button)
            {
                case Button.VK_UP:
                    if (_scrollingStyle == ScrollingStyle.LineByLine) LineUp(); else PageUp();
                    break;
                case Button.VK_DOWN:
                    if (_scrollingStyle == ScrollingStyle.LineByLine) LineDown(); else PageDown();
                    break;
                case Button.VK_LEFT:
                    if (_scrollingStyle == ScrollingStyle.LineByLine) LineLeft(); else PageLeft();
                    break;
                case Button.VK_RIGHT:
                    if (_scrollingStyle == ScrollingStyle.LineByLine) LineRight(); else PageRight();
                    break;
                default:
                    return;
            }

            if (_previousHorizontalOffset != _horizontalOffset || _previousVerticalOffset != _verticalOffset)
            {
                e.Handled = true;
            }
        }

        private int _previousHorizontalOffset;
        private int _previousVerticalOffset;
        private int _horizontalOffset;
        private int _verticalOffset;
        private int _extentWidth;
        private int _extentHeight;
        private int _scrollableWidth;
        private int _scrollableHeight;

        private int _lineHeight = 1;
        private int _lineWidth = 1;

        private ScrollingStyle _scrollingStyle = ScrollingStyle.LineByLine;

        private ScrollChangedEventHandler _scrollChanged;
    }
}
