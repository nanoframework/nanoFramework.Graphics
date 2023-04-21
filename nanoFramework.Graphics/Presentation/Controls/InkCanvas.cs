//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using nanoFramework.UI.Input;
using nanoFramework.Presentation.Media;
using System;
using nanoFramework.UI;
using System.Drawing;

namespace nanoFramework.Presentation.Controls
{    
    /// <summary>
    /// Note: InkCanvas control is not movable at runtime. This requires complex logic, with
    /// no customer scenario at this moment.
    /// </summary>
    public class InkCanvas : UIElement
    {
        /// <summary>
        /// Initializes a new instance of the InkCanvas class with the specified left, top, width, and height dimensions.
        /// </summary>
        /// <param name="left">The left coordinate of the InkCanvas.</param>
        /// <param name="top">The top coordinate of the InkCanvas.</param>
        /// <param name="width">The width of the InkCanvas.</param>
        /// <param name="height">The height of the InkCanvas.</param>
        public InkCanvas(int left, int top, int width, int height)
            : this(left, top, width, height, 1)
        {
        }

        /// <summary>
        /// Initializes a new instance of the InkCanvas class with the specified left, top, width, height, and border width dimensions.
        /// </summary>
        /// <param name="left">The left coordinate of the InkCanvas.</param>
        /// <param name="top">The top coordinate of the InkCanvas.</param>
        /// <param name="width">The width of the InkCanvas.</param>
        /// <param name="height">The height of the InkCanvas.</param>
        /// <param name="borderWidth">The width of the border around the InkCanvas.</param>
        public InkCanvas(int left, int top, int width, int height, int borderWidth)
        {
            Init(left, top, width, height, borderWidth);
            Canvas.SetLeft(this, left);
            Canvas.SetTop(this, top);
            HorizontalAlignment = HorizontalAlignment.Left;
            VerticalAlignment = VerticalAlignment.Top;
        }

        /// <summary>
        /// Finalizes an instance of the InkCanvas class.
        /// </summary>
        ~InkCanvas()
        {
        }

        /// <summary>
        /// Handles the touch down event for the InkCanvas.
        /// </summary>
        /// <param name="e">The touch event arguments.</param>
        protected override void OnTouchDown(TouchEventArgs e)
        {
            int x, y, w, h;

            GetLayoutOffset(out x, out y);
            GetRenderSize(out w, out h);

            x += _left;
            y += _top;

            TouchCapture.Capture(this);
            Ink.SetInkRegion(0, x, y, x + w, y + h, _borderWidth, _defaultDrawingAttributes.Color.ToArgb(), 1, _bitmap);
        }

        /// <summary>
        /// Handles the touch up event for the InkCanvas.
        /// </summary>
        /// <param name="e">The touch event arguments.</param>
        protected override void OnTouchUp(TouchEventArgs e)
        {
            Ink.ResetInkRegion();
            Invalidate();
        }

        /// <summary>
        /// Renders the InkCanvas control.
        /// </summary>
        /// <param name="dc">The drawing context to use for rendering.</param>
        public override void OnRender(nanoFramework.Presentation.Media.DrawingContext dc)
        {
            if (_bitmap != null)
            {
                dc.DrawImage(_bitmap, 0, 0);
            }
        }

        /// <summary>
        /// Clears the InkCanvas.
        /// </summary>
        public void Clear()
        {
            _bitmap.DrawRectangle(Color.Black, _borderWidth, 0, 0, _width, _height, 0, 0, Color.White, 0, 0, Color.White, 0, 0, Bitmap.OpacityOpaque);
            Invalidate();
        }

        /// <summary>
        /// Initializes the InkCanvas with the specified dimensions and border width.
        /// </summary>
        /// <param name="left">The left position of the InkCanvas on the screen.</param>
        /// <param name="top">The top position of the InkCanvas on the screen.</param>
        /// <param name="width">The width of the InkCanvas.</param>
        /// <param name="height">The height of the InkCanvas.</param>
        /// <param name="borderWidth">The width of the border around the InkCanvas.</param>
        protected virtual void Init(int left, int top, int width, int height, int borderWidth)
        {
            _width = width;
            _height = height;
            _left = left;
            _top = top;
            _borderWidth = borderWidth;

            int x1 = _left;
            int y1 = _top;

            _bitmap = new Bitmap(_width, _height);
            _bitmap.DrawRectangle(Color.Black, _borderWidth, 0, 0, _width, _height, 0, 0, Color.White, 0, 0, Color.White, 0, 0, Bitmap.OpacityOpaque);

            if ((x1 < 0) || ((x1 + _width) > DisplayControl.ScreenWidth) ||
                (y1 < 0) || ((y1 + _height) > DisplayControl.ScreenHeight))
            {
                throw new ArgumentException("screenlimit");
            }
        }

        /// <summary>
        /// Gets or sets the default drawing attributes for the InkCanvas.
        /// </summary>
        public DrawingAttributes DefaultDrawingAttributes
        {
            get
            {
                return _defaultDrawingAttributes;
            }

            set
            {
                _defaultDrawingAttributes = value;
            }
        }

        /// <summary>
        /// Measures the available space for the InkCanvas and sets the desired width and height accordingly.
        /// </summary>
        /// <param name="availableWidth">The available width for the InkCanvas.</param>
        /// <param name="availableHeight">The available height for the InkCanvas.</param>
        /// <param name="desiredWidth">The desired width for the InkCanvas.</param>
        /// <param name="desiredHeight">The desired height for the InkCanvas.</param>

        protected override void MeasureOverride(int availableWidth, int availableHeight, out int desiredWidth, out int desiredHeight)
        {
            desiredWidth = (availableWidth > _width) ? _width : availableWidth;
            desiredHeight = (availableHeight > _height) ? _height : availableHeight;
        }

        /// <summary>
        /// The default drawing attributes for the InkCanvas.
        /// </summary>
        protected DrawingAttributes _defaultDrawingAttributes = new DrawingAttributes();

        /// <summary>
        /// The Bitmap used for rendering the InkCanvas.
        /// </summary>
        protected Bitmap _bitmap = null;

        private int _borderWidth;
        private int _width;
        private int _height;
        private int _top;
        private int _left;
    }
}
