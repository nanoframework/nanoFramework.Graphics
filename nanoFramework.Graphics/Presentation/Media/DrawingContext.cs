//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using nanoFramework.UI;
using System;
using System.Collections;
using nanoFramework.UI.Threading;

namespace nanoFramework.Presentation.Media
{
    /// <summary>
    /// Drawing Context.
    /// </summary>
    public class DrawingContext : DispatcherObject,IDisposable 
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bmp"></param>
        public DrawingContext(Bitmap bmp)
        {
            this._bitmap = bmp;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public DrawingContext(int width, int height)
        {
            this._bitmap = new Bitmap(width, height);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dx"></param>
        /// <param name="dy"></param>
        public void Translate(int dx, int dy)
        {
            VerifyAccess();

            _x += dx;
            _y += dy;            
        }        
 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void GetTranslation(out int x, out int y)
        {
            VerifyAccess();

            x = _x;
            y = _y;            
        }        

        /// <summary>
        /// 
        /// </summary>
        public Bitmap Bitmap
        {
            get
            {
                VerifyAccess();

                return _bitmap;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Clear()
        {
            VerifyAccess();

            _bitmap.Clear();
        }

        internal void Close()
        {
            _bitmap = null;                   
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="brush"></param>
        /// <param name="pen"></param>
        /// <param name="pts"></param>
        public void DrawPolygon(Brush brush, Pen pen, int[] pts)
        {
            VerifyAccess();

            brush.RenderPolygon(_bitmap, pen, pts);

            int nPts = pts.Length / 2;

            for (int i = 0; i < nPts - 1; i++)
            {
                DrawLine(pen, pts[i * 2], pts[i * 2 + 1], pts[i * 2 + 2], pts[i * 2 + 3]);
            }

            if (nPts > 2)
            {
                DrawLine(pen, pts[nPts * 2 - 2], pts[nPts * 2 - 1], pts[0], pts[1]);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="color"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void SetPixel(Color color, int x, int y)
        {
            VerifyAccess();

            _bitmap.SetPixel(_x + x, _y + y, color);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pen"></param>
        /// <param name="x0"></param>
        /// <param name="y0"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        public void DrawLine(Pen pen, int x0, int y0, int x1, int y1)
        {
            VerifyAccess();

            if (pen != null)
            {
                _bitmap.DrawLine(pen.Color, pen.Thickness, _x + x0, _y + y0, _x + x1, _y + y1);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="brush"></param>
        /// <param name="pen"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="xRadius"></param>
        /// <param name="yRadius"></param>
        public void DrawEllipse(Brush brush, Pen pen, int x, int y, int xRadius, int yRadius)
        {
            VerifyAccess();

            // Fill
            //
            if (brush != null)
            {
                brush.RenderEllipse(_bitmap, pen, _x + x, _y + y, xRadius, yRadius);
            }

            // Pen
            else if (pen != null && pen.Thickness > 0)
            {
                _bitmap.DrawEllipse(pen.Color, pen.Thickness, _x + x, _y + y, xRadius, yRadius,
                    (Color)0x0, 0, 0, (Color)0x0, 0, 0, 0);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void DrawImage(Bitmap source, int x, int y)
        {
            VerifyAccess();

            _bitmap.DrawImage(_x + x, _y + y, source, 0, 0, source.Width, source.Height);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destinationX"></param>
        /// <param name="destinationY"></param>
        /// <param name="sourceX"></param>
        /// <param name="sourceY"></param>
        /// <param name="sourceWidth"></param>
        /// <param name="sourceHeight"></param>
        public void DrawImage(Bitmap source, int destinationX, int destinationY, int sourceX, int sourceY, int sourceWidth, int sourceHeight)
        {
            VerifyAccess();

            _bitmap.DrawImage(_x + destinationX, _y + destinationY, source, sourceX, sourceY, sourceWidth, sourceHeight);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destinationX"></param>
        /// <param name="destinationY"></param>
        /// <param name="sourceX"></param>
        /// <param name="sourceY"></param>
        /// <param name="sourceWidth"></param>
        /// <param name="sourceHeight"></param>
        /// <param name="opacity"></param>
        public void BlendImage(Bitmap source, int destinationX, int destinationY, int sourceX, int sourceY, int sourceWidth, int sourceHeight, ushort opacity)
        {
            VerifyAccess();

            _bitmap.DrawImage( _x + destinationX, _y + destinationY, source, sourceX, sourceY, sourceWidth, sourceHeight, opacity );
        }                
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="angle"></param>
        /// <param name="destinationX"></param>
        /// <param name="destinationY"></param>
        /// <param name="bitmap"></param>
        /// <param name="sourceX"></param>
        /// <param name="sourceY"></param>
        /// <param name="sourceWidth"></param>
        /// <param name="sourceHeight"></param>
        /// <param name="opacity"></param>
        public void RotateImage( int angle, int destinationX, int destinationY, Bitmap bitmap, int sourceX, int sourceY, int sourceWidth, int sourceHeight, ushort opacity )
        {
            VerifyAccess();

            _bitmap.RotateImage( angle,  _x + destinationX, _y +  destinationY, bitmap, sourceX, sourceY, sourceWidth, sourceHeight, opacity );
        }                

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xDst"></param>
        /// <param name="yDst"></param>
        /// <param name="widthDst"></param>
        /// <param name="heightDst"></param>
        /// <param name="bitmap"></param>
        /// <param name="xSrc"></param>
        /// <param name="ySrc"></param>
        /// <param name="widthSrc"></param>
        /// <param name="heightSrc"></param>
        /// <param name="opacity"></param>
        public void StretchImage(int xDst, int yDst, int widthDst, int heightDst, Bitmap bitmap, int xSrc, int ySrc, int widthSrc, int heightSrc, ushort opacity)
        {
            VerifyAccess();

            _bitmap.StretchImage( _x + xDst, _y + yDst, widthDst, heightDst, bitmap, xSrc, ySrc, widthSrc, heightSrc, opacity );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xDst"></param>
        /// <param name="yDst"></param>
        /// <param name="bitmap"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="opacity"></param>
        public void TileImage(int xDst, int yDst, Bitmap bitmap, int width, int height, ushort opacity)
        {
            VerifyAccess();

            _bitmap.TileImage( _x + xDst, _y + yDst, bitmap, width, height, opacity );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xDst"></param>
        /// <param name="yDst"></param>
        /// <param name="widthDst"></param>
        /// <param name="heightDst"></param>
        /// <param name="bitmap"></param>
        /// <param name="leftBorder"></param>
        /// <param name="topBorder"></param>
        /// <param name="rightBorder"></param>
        /// <param name="bottomBorder"></param>
        /// <param name="opacity"></param>
        public void Scale9Image(int xDst, int yDst, int widthDst, int heightDst, Bitmap bitmap, int leftBorder, int topBorder, int rightBorder, int bottomBorder, ushort opacity)
        {
            VerifyAccess();

            _bitmap.Scale9Image( _x + xDst, _y + yDst, widthDst, heightDst, bitmap, leftBorder, topBorder, rightBorder, bottomBorder, opacity );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="font"></param>
        /// <param name="color"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void DrawText(string text, Font font, Color color, int x, int y)
        {
            VerifyAccess();

            _bitmap.DrawText(text, font, color, _x + x, _y + y);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="font"></param>
        /// <param name="color"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="alignment"></param>
        /// <param name="trimming"></param>
        /// <returns></returns>
        public bool DrawText(ref string text, Font font, Color color, int x, int y, int width, int height,
                             TextAlignment alignment, TextTrimming trimming)
        {
            VerifyAccess();

            uint flags = Bitmap.DT_WordWrap;

            // Text alignment
            switch (alignment)
            {
                case TextAlignment.Left:
                    //flags |= Bitmap.DT_AlignmentLeft;
                    break;
                case TextAlignment.Center:
                    flags |= Bitmap.DT_AlignmentCenter;
                    break;
                case TextAlignment.Right:
                    flags |= Bitmap.DT_AlignmentRight;
                    break;
                default:
                    throw new NotSupportedException();
            }

            // Trimming
            switch (trimming)
            {
                case TextTrimming.CharacterEllipsis:
                    flags |= Bitmap.DT_TrimmingCharacterEllipsis;
                    break;
                case TextTrimming.WordEllipsis:
                    flags |= Bitmap.DT_TrimmingWordEllipsis;
                    break;
            }

            int xRelStart = 0;
            int yRelStart = 0;
            return _bitmap.DrawTextInRect(ref text, ref xRelStart, ref yRelStart, _x + x, _y + y,
                                           width, height, flags, color, font);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void GetClippingRectangle(out int x, out int y, out int width, out int height)
        {
            if (_clippingRectangles.Count == 0)
            {
                x = 0;
                y = 0;
                width = _bitmap.Width - _x;
                height = _bitmap.Height - _y;
            }
            else
            {
                ClipRectangle rect = (ClipRectangle)_clippingRectangles.Peek();
                x = rect.X - _x;
                y = rect.Y - _y;
                width = rect.Width;
                height = rect.Height;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void PushClippingRectangle(int x, int y, int width, int height)
        {
            VerifyAccess();

            if(width < 0 || height < 0)
            {
                throw new ArgumentException();
            }

            ClipRectangle rect = new ClipRectangle( _x + x, _y + y, width, height );

            if (_clippingRectangles.Count > 0)
            {
                // Intersect with the existing clip bounds
                ClipRectangle previousRect = (ClipRectangle)_clippingRectangles.Peek();
                //need to evaluate performance differences of inlining Min & Max(
                int x1 = Mathematics.Max(rect.X, previousRect.X);
                int x2 = Mathematics.Min(rect.X + rect.Width, previousRect.X + previousRect.Width);
                int y1 = Mathematics.Max(rect.Y, previousRect.Y);
                int y2 = Mathematics.Min(rect.Y + rect.Height, previousRect.Y + previousRect.Height);

                rect.X = x1;
                rect.Y = y1;
                rect.Width = x2 - x1;
                rect.Height = y2 - y1;
            }

            _clippingRectangles.Push(rect);

            _bitmap.SetClippingRectangle(rect.X, rect.Y, rect.Width, rect.Height);
            EmptyClipRect = (rect.Width <= 0 || rect.Height <= 0);
        }

        /// <summary>
        /// 
        /// </summary>
        public void PopClippingRectangle()
        {
            VerifyAccess();

            int n = _clippingRectangles.Count;
            
            if (n > 0)
            {
                _clippingRectangles.Pop();

                ClipRectangle rect;
                
                if (n == 1) // in this case, at this point the stack is empty
                {
                    rect = new ClipRectangle(0, 0, _bitmap.Width, _bitmap.Height);
                }
                else
                {
                    rect = (ClipRectangle)_clippingRectangles.Peek();
                }

                _bitmap.SetClippingRectangle(rect.X, rect.Y, rect.Width, rect.Height);
                
                EmptyClipRect = (rect.Width == 0 && rect.Height == 0);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="brush"></param>
        /// <param name="pen"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void DrawRectangle(Brush brush, Pen pen, int x, int y, int width, int height)
        {
            VerifyAccess();

            // Fill
            //
            if (brush != null)
            {
                brush.RenderRectangle(_bitmap, pen, _x + x, _y + y, width, height);
            }

            // Pen
            else if (pen != null && pen.Thickness > 0)
            {
                _bitmap.DrawRectangle(pen.Color, pen.Thickness, _x + x, _y + y, width, height, 0, 0,
                                      (Color)0, 0, 0, (Color)0, 0, 0, 0);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int Width
        {
            get
            {
                return _bitmap.Width;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int Height
        {
            get
            {
                return _bitmap.Height;
            }
        }

        private class ClipRectangle
        {
            public ClipRectangle(int x, int y, int width, int height)
            {
                X = x;
                Y = y;
                Width = width;
                Height = height;
            }

            public int X;
            public int Y;
            public int Width;
            public int Height;
        }

        internal bool EmptyClipRect = false;

        private Bitmap _bitmap;
        internal int _x;
        internal int _y;
        private Stack _clippingRectangles = new Stack();

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            _bitmap = null; 
        }

    }
}


