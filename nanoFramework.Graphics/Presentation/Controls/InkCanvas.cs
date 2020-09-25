//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using nanoFramework.UI.Input;
using nanoFramework.Presentation.Media;
using System;
using nanoFramework.UI;

namespace nanoFramework.Presentation.Controls
{
    /// <summary>
    /// 
    /// </summary>
    public class DrawingAttributes
    {
        /// <summary>
        /// 
        /// </summary>
        public Color Color = Color.Black;
    }

    /// <summary>
    /// Note: InkCanvas control is not movable at runtime. This requires complex logic, with
    /// no customer scenario at this moment.
    /// </summary>
    public class InkCanvas : UIElement
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="top"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public InkCanvas(int left, int top, int width, int height)
            : this(left, top, width, height, 1)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="top"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="borderWidth"></param>
        public InkCanvas(int left, int top, int width, int height, int borderWidth)
        {
            Init(left, top, width, height, borderWidth);
            Canvas.SetLeft(this, left);
            Canvas.SetTop(this, top);
            HorizontalAlignment = HorizontalAlignment.Left;
            VerticalAlignment = VerticalAlignment.Top;
        }

        /// <summary>
        /// 
        /// </summary>
        ~InkCanvas()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnTouchDown(TouchEventArgs e)
        {
            int x, y, w, h;

            GetLayoutOffset(out x, out y);
            GetRenderSize(out w, out h);

            x += _left;
            y += _top;

            TouchCapture.Capture(this);
            Ink.SetInkRegion(0, x, y, x + w, y + h, _borderWidth, (int)_defaultDrawingAttributes.Color, 1, _bitmap);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnTouchUp(TouchEventArgs e)
        {
            Ink.ResetInkRegion();
            Invalidate();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dc"></param>
        public override void OnRender(nanoFramework.Presentation.Media.DrawingContext dc)
        {
            if (_bitmap != null)
            {
                dc.DrawImage(_bitmap, 0, 0);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Clear()
        {
            _bitmap.DrawRectangle(Color.Black, _borderWidth, 0, 0, _width, _height, 0, 0, Color.White, 0, 0, Color.White, 0, 0, Bitmap.OpacityOpaque);
            Invalidate();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="top"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="borderWidth"></param>
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
        /// 
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
        /// 
        /// </summary>
        /// <param name="availableWidth"></param>
        /// <param name="availableHeight"></param>
        /// <param name="desiredWidth"></param>
        /// <param name="desiredHeight"></param>
        protected override void MeasureOverride(int availableWidth, int availableHeight, out int desiredWidth, out int desiredHeight)
        {
            desiredWidth = (availableWidth > _width) ? _width : availableWidth;
            desiredHeight = (availableHeight > _height) ? _height : availableHeight;
        }

        /// <summary>
        /// 
        /// </summary>
        protected DrawingAttributes _defaultDrawingAttributes = new DrawingAttributes();

        /// <summary>
        /// 
        /// </summary>
        protected Bitmap _bitmap = null;


        private int _borderWidth;
        private int _width;
        private int _height;
        private int _top;
        private int _left;
    }
}


