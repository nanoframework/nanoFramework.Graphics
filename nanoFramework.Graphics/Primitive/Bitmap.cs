//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using System;
using System.Runtime.CompilerServices;
using System.Drawing;

namespace nanoFramework.UI
{
    /// <summary>
    /// Encapsulates a bitmap, which consists of the pixel data for a graphics image and its methods and attributes
    /// This class cannot be inherited.NET nanoFramework provides the Bitmap class on the native side.
    /// </summary>
    public sealed class Bitmap : MarshalByRefObject, IDisposable
    {
        /// <summary>
        /// Gets the maximum width of the display device, in pixels.
        /// </summary>
        public static readonly int MaxWidth;//  

        /// <summary>
        /// Gets the maximum height of the display device, in pixels.
        /// </summary>
        public static readonly int MaxHeight;// 

        /// <summary>
        /// Gets the x-coordinate location of the center of the display device, in pixels.
        /// </summary>
        public static readonly int CenterX;// = (MaxWidth - 1) / 2;

        /// <summary>
        /// Gets the y-coordinate location of the center of the display device, in pixels.
        /// </summary>
        public static readonly int CenterY;// = (MaxHeight - 1) / 2;

        static Bitmap()
        {
            MaxWidth = DisplayControl.ScreenWidth;
            MaxHeight = DisplayControl.ScreenHeight;

            CenterX = (MaxWidth - 1) / 2;
            CenterY = (MaxHeight - 1) / 2;
        }


        /// <summary>
        /// Specifies that the current bitmap is opaque.
        /// </summary>
        public const ushort OpacityOpaque = 256;

        /// <summary>
        /// Specifies that the current bitmap is transparent.
        /// </summary>
        public const ushort OpacityTransparent = 0;

        /*
         * This doesn't seems to be used anywhere neither on the native side. Keeping it here on purpose in case we find out their usage.
         * 
        /// <summary>
        /// Copies the source rectangle directly to the destination rectangle.
        /// </summary>
        public const int SRCCOPY = 0x00000001;

        /// <summary>
        /// Inverts the source rectangle.
        /// </summary>
        public const int PATINVERT = 0x00000002;

        /// <summary>
        /// Inverts the destination rectangle.
        /// </summary>
        public const int DSTINVERT = 0x00000003;

        /// <summary>
        /// Fills the destination rectangle with the color associated with index number 0 in the physical palette.
        /// </summary>
        public const int BLACKNESS = 0x00000004;

        /// <summary>
        /// Fills the destination rectangle with the color associated with index number 1 in the physical palette.
        /// </summary>
        public const int WHITENESS = 0x00000005;

        /// <summary>
        /// Fills the destination rectangle with a gray color.
        /// </summary>
        public const int DSTGRAY = 0x00000006;

        /// <summary>
        /// Fills the destination rectangle with a light gray color.
        /// </summary>
        public const int DSTLTGRAY = 0x00000007;

        /// <summary>
        /// Fills the destination rectangle with a dark gray color.
        /// </summary>
        public const int DSTDKGRAY = 0x00000008;

        /// <summary>
        /// Specifies that a circle should have only a single-pixel border and no fill pattern or color.
        /// </summary>
        public const int SINGLEPIXEL = 0x00000009;

        /// <summary>
        /// Fills the destination rectangle or circle with a randomly generated pattern.
        /// </summary>
        public const int RANDOM = 0x0000000a;
        */

        /// <summary>
        ///  Note that these values have to match the c_Type* consts in CLR_GFX_BitmapDescription 
        /// </summary>
        public enum BitmapImageType : byte
        {
            /// <summary>
            /// A bitmap in a format specific to the nano Framework common language runtine (CLR).
            /// </summary>
            NanoCLRBitmap = 0,

            /// <summary>
            /// A bitmap in GIF format.
            /// </summary>
            Gif = 1,

            /// <summary>
            /// A bitmap in JPEG format.
            /// </summary>
            Jpeg = 2,

            /// <summary>
            /// A bitmap in Windows BMP format.
            /// </summary>
            Bmp = 3 // The windows .bmp format
        }

#pragma warning disable 169
        private object m_bitmap;    // Do not delete m_bitmap, this is linked to the underlying C/C++ code via magic   (MDP)
#pragma warning restore

        /// <summary>
        /// Encapsulates a bitmap, which consists of the pixel data for a graphics image and its methods and attributes.
        /// </summary>
        /// <param name="width">The width of the bitmap.</param>
        /// <param name="height">The height of the bitmap.</param>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern Bitmap(int width, int height);

        /// <summary>
        /// Encapsulates a bitmap, which consists of the pixel data for a graphics image and its methods and attributes.
        /// </summary>
        /// <param name="imageData">An array of pixel data for the specified image.</param>
        /// <param name="type">The bitmap type for the specified image.</param>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern Bitmap(byte[] imageData, BitmapImageType type);

        /// <summary>
        /// Encapsulates a bitmap, which consists of the pixel data for a graphics image and its methods and attributes.
        /// </summary>
        /// <param name="size">The <see cref="Size"/> of the bitmap.</param>
        public Bitmap(Size size) : this(size.Width, size.Height)
        {

        }

        /// <summary>
        /// Flushes the current bitmap to the display device.
        /// Bitmap will be written to the upper-left corner of the screen (full-screen, for full-screen bitmaps).
        /// </summary>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern void Flush();

        /// <summary>
        /// Flushes a sub-rectangle of the current bitmap to the display device.
        /// </summary>
        /// <param name="x">The x-coordinate of the sub-rectangle's upper-left corner.</param>
        /// <param name="y">The y-coordinate of the sub-rectangle's upper-left corner.</param>
        /// <param name="width">The width of the sub-rectangle.</param>
        /// <param name="height">The height of the sub-rectangle.</param>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern void Flush(int x, int y, int width, int height);

        /// <summary>
        /// Flushes a sub-rectangle of the current bitmap to the display device.
        /// </summary>
        public void Flush(Rectangle rectangle) => Flush(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);

        /// <summary>
        /// Flushes a sub-rectangle of the current bitmap to the display device at a specified screen position.
        /// </summary>
        /// <param name="srcX">The x-coordinate of the sub-rectangle's upper-left corner.</param>
        /// <param name="srcY">The y-coordinate of the sub-rectangle's upper-left corner.</param>
        /// <param name="width">The width of the sub-rectangle.</param>
        /// <param name="height">The height of the sub-rectangle.</param>
        /// <param name="screenX">The x-coordinate of the screen to write to.</param>
        /// <param name="screenY">The y-coordinate of the screen to write to</param>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern void Flush(int srcX, int srcY, int width, int height, int screenX, int screenY);

        /// <summary>
        /// Flushes a sub-rectangle of the current bitmap to the display device at a specified screen position.
        /// </summary>
        public void Flush(Rectangle source, System.Drawing.Point destination) => 
            Flush(source.X, source.Y, source.Width, source.Height, destination.X, destination.Y);

        /// <summary>
        /// Clears the entire drawing surface.
        /// </summary>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern void Clear();

        /// <summary>
        /// Draws text in a specified rectangle. Sets the clipping region (clipping rectangle) of a bitmap with a specified coordinate pair (x, y), width, and height.
        /// </summary>
        /// <param name="text">The text to be drawn. This parameter contains the remaining text, or an empty string, if the complete text string did not fit in the specified rectangle.</param>
        /// <param name="xRelStart">The x-coordinate, relative to the rectangle, at which text drawing is to begin.</param>
        /// <param name="yRelStart">The y-coordinate, relative to the rectangle, at which text drawing is to begin.</param>
        /// <param name="x">The x-coordinate of the upper-left corner of the rectangle.</param>
        /// <param name="y">The y-coordinate of the upper-left corner of the rectangle.</param>
        /// <param name="width">The width of the rectangle.</param>
        /// <param name="height">The height of the rectangle.</param>
        /// <param name="dtFlags">Flags that specify the format of the text.</param>
        /// <param name="color">The color to be used for the text.</param>
        /// <param name="font">The font to be used for the text.</param>
        /// <returns>Returns true if the text was completely drawn, false otherwise.</returns>
        public bool DrawTextInRect(ref string text, ref int xRelStart, ref int yRelStart, int x, int y, int width, int height, uint dtFlags, Color color, Font font) =>
            DrawTextInRect(ref text, ref xRelStart, ref yRelStart, x, y, width, height, dtFlags, (uint)color.ToArgb(), font);

        /// <summary>
        /// Draws text in a specified rectangle.
        /// Sets the clipping region (clipping rectangle) of a bitmap with a specified coordinate pair (x, y), width, and height.
        /// </summary>
        /// <param name="text">The text to be drawn. This parameter contains the remaining text, or an empty string, if the complete text string did not fit in the specified rectangle.</param>
        /// <param name="x">The x-coordinate of the upper-left corner of the rectangle.</param>
        /// <param name="y">The y-coordinate of the upper-left corner of the rectangle.</param>
        /// <param name="width">The width of the rectangle.</param>
        /// <param name="height">The height of the rectangle.</param>
        /// <param name="dtFlags">Flags that specify the format of the text.</param>
        /// <param name="color">The color to be used for the text.</param>
        /// <param name="font">The font to be used for the text.</param>
        public void DrawTextInRect(string text, int x, int y, int width, int height, uint dtFlags, Color color, Font font)
        {
            int xRelStart = 0;
            int yRelStart = 0;

            DrawTextInRect(ref text, ref xRelStart, ref yRelStart, x, y, width, height, dtFlags, color, font);
        }

        /// <summary>
        /// Draws text in a specified rectangle.
        /// </summary>
        public void DrawTextInRect(string text, Rectangle rectangle, uint dtFlags, Color color, Font font) =>
            DrawTextInRect(text, rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, dtFlags, color, font);

        /// <summary>
        /// Draws a single character to the screen.
        /// </summary>
        /// <param name="c">The character to draw.</param>
        /// <param name="x">The x-coordinate of the upper-left corner to draw to.</param>
        /// <param name="y">The y-coordinate of the upper-left corner to draw to.</param>
        /// <param name="color">The color to be used for the character.</param>
        /// <param name="font">The font to be used for the character.</param>
        public void DrawChar(ushort c, int x, int y, Color color, Font font) => DrawChar(c, x, y, (uint)color.ToArgb(), font);

        /// <summary>
        /// Sets the clipping rectangle to restrict drawing to a certain area on the screen.
        /// </summary>
        /// <param name="x">The x-coordinate of the upper-left corner of the clipping rectangle.</param>
        /// <param name="y">The y-coordinate of the upper-left corner of the clipping rectangle.</param>
        /// <param name="width">The width of the clipping rectangle.</param>
        /// <param name="height">The height of the clipping rectangle.</param>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern void SetClippingRectangle(int x, int y, int width, int height);

        /// <summary>
        /// Sets the clipping rectangle to restrict drawing to a certain area on the screen.
        /// </summary>
        public void SetClippingRectangle(Rectangle rectangle) =>
            SetClippingRectangle(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);

        /// <summary>
        /// Gets the width of the current bitmap.
        /// </summary>
        public extern int Width
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
        }

        /// <summary>
        /// Gets the height of the current bitmap.
        /// </summary>
        public extern int Height
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
        }

        /// <summary>
        /// Draws an ellipse filled with a specified color gradient.
        /// </summary>
        /// <param name="colorOutline">The outline color.</param>
        /// <param name="thicknessOutline">The thickness of the ellipse's outline, in pixels.</param>
        /// <param name="x">The x-coordinate location of the center of the ellipse.</param>
        /// <param name="y">The y-coordinate location of the center of the ellipse.</param>
        /// <param name="xRadius">The radius of the ellipse in the x-coordinate direction.</param>
        /// <param name="yRadius">The radius of the ellipse in the y-coordinate direction.</param>
        /// <param name="colorGradientStart">The starting color of the color gradient.</param>
        /// <param name="xGradientStart">The x-coordinate location of the starting point of the color gradient.</param>
        /// <param name="yGradientStart">The y-coordinate location of the starting point of the color gradient.</param>
        /// <param name="colorGradientEnd">The ending color of the color gradient.</param>
        /// <param name="xGradientEnd">The x-coordinate location of the ending point of the color gradient.</param>
        /// <param name="yGradientEnd">The y-coordinate location of the ending point of the color gradient.</param>
        /// <param name="opacity">The opacity of the ellipse.</param>
        public void DrawEllipse(
            Color colorOutline, int thicknessOutline,
            int x, int y, int xRadius, int yRadius,
            Color colorGradientStart, int xGradientStart, int yGradientStart,
            Color colorGradientEnd, int xGradientEnd, int yGradientEnd,
            ushort opacity = OpacityOpaque) => DrawEllipse((uint)colorOutline.ToArgb(), thicknessOutline,
                x, y, xRadius, yRadius,
                (uint)colorGradientStart.ToArgb(), xGradientStart, yGradientStart,
                (uint)colorGradientEnd.ToArgb(), xGradientEnd, yGradientEnd,
                opacity);

        /// <summary>
        /// Draws an ellipse filled with a specified color gradient.
        /// </summary>
        /// <param name="colorOutline">The outline color.</param>
        /// <param name="thicknessOutline">The thickness of the ellipse's outline, in pixels.</param>
        /// <param name="point">The location of the center of the ellipse.</param>
        /// <param name="xRadius">The radius of the ellipse in the x-coordinate direction.</param>
        /// <param name="yRadius">The radius of the ellipse in the y-coordinate direction.</param>
        /// <param name="colorGradientStart">The starting color of the color gradient.</param>
        /// <param name="gradientStartPoint">The location of the starting point of the color gradient.</param>
        /// <param name="colorGradientEnd">The ending color of the color gradient.</param>
        /// <param name="gradientEndPoint">The location of the ending point of the color gradient.</param>
        /// <param name="opacity">The opacity of the ellipse.</param>
        public void DrawEllipse(
            Color colorOutline, int thicknessOutline,
            System.Drawing.Point point, int xRadius, int yRadius,
            Color colorGradientStart, System.Drawing.Point gradientStartPoint,
            Color colorGradientEnd, System.Drawing.Point gradientEndPoint,
            ushort opacity = OpacityOpaque) => DrawEllipse(colorOutline, thicknessOutline, point.X, point.Y, xRadius, yRadius,
            colorGradientStart, gradientStartPoint.X, gradientStartPoint.Y, colorGradientEnd, gradientEndPoint.X,
            gradientEndPoint.Y, opacity);

        /// <summary>
        /// Draw an ellipse
        /// </summary>
        /// <param name="colorOutline">The outline color.</param>
        /// <param name="x">The x-coordinate location of the center of the ellipse.</param>
        /// <param name="y">The y-coordinate location of the center of the ellipse.</param>
        /// <param name="xRadius">The radius of the ellipse in the x-coordinate direction.</param>
        /// <param name="yRadius">The radius of the ellipse in the y-coordinate direction.</param>
        public void DrawEllipse(Color colorOutline, int x, int y, int xRadius, int yRadius)
        {
            DrawEllipse(colorOutline, 1, x, y, xRadius, yRadius, Color.Black, 0, 0, Color.Black, 0, 0, OpacityOpaque);
        }

        /// <summary>
        /// Draw an ellipse
        /// </summary>
        /// <param name="colorOutline">The outline color.</param>
        /// <param name="point">The location of the center of the ellipse.</param>
        /// <param name="xRadius">The radius of the ellipse in the x-coordinate direction.</param>
        /// <param name="yRadius">The radius of the ellipse in the y-coordinate direction.</param>
        public void DrawEllipse(Color colorOutline, System.Drawing.Point point, int xRadius, int yRadius) =>
            DrawEllipse(colorOutline, point.X, point.Y, xRadius, yRadius);

        /// <summary>
        /// Draws a rectangular block of pixels with a specified degree of transparency.
        /// </summary>
        /// <param name="xDst">The x-coordinate location of the upper-left corner of the rectangular area on the display to which the specified pixels are to be copied.</param>
        /// <param name="yDst">The y-coordinate location of the upper-left corner of the rectangular area on the display to which the specified pixels are to be copied.</param>
        /// <param name="bitmap">The source bitmap.</param>
        /// <param name="xSrc">The x-coordinate location of the upper-left corner of the rectangular area in the source bitmap from which the specified pixels are to be copied.</param>
        /// <param name="ySrc">The x-coordinate location of the upper-left corner of the rectangular area in the source bitmap from which the specified pixels are to be copied.</param>
        /// <param name="width">The width of the rectangular block of pixels to be copied.</param>
        /// <param name="height">The height of the rectangular block of pixels to be copied.</param>
        /// <param name="opacity">The degree of opacity of the bitmap. A value of 0 (zero) makes the bitmap completely opaque (not transparent at all); a value of 255 makes the bitmap completely transparent.</param>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern void DrawImage(int xDst, int yDst, Bitmap bitmap, int xSrc, int ySrc, int width, int height, ushort opacity = OpacityOpaque);

        /// <summary>
        /// Draws a rectangular block of pixels with a specified degree of transparency.
        /// </summary>
        /// <param name="point">The location of the upper-left corner of the rectangular area on the display to which the specified pixels are to be copied.</param>
        /// <param name="bitmap">The source bitmap.</param>
        /// <param name="rectangle">The rectangle of pixels to be copied.</param>
        /// <param name="opacity">The degree of opacity of the bitmap. A value of 0 (zero) makes the bitmap completely opaque (not transparent at all); a value of 255 makes the bitmap completely transparent.</param>
        public void DrawImage(System.Drawing.Point point, Bitmap bitmap, Rectangle rectangle, ushort opacity = OpacityOpaque) =>
            DrawImage(point.X, point.Y, bitmap, rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, opacity);

        /// <summary>
        /// Draws a block of pixels with a specified degree of transparency.
        /// </summary>
        /// <param name="point">The location of the upper-left corner of the rectangular area on the display to which the specified pixels are to be copied.</param>
        /// <param name="bitmap">The source bitmap.</param>
        /// <param name="opacity">The degree of opacity of the bitmap. A value of 0 (zero) makes the bitmap completely opaque (not transparent at all); a value of 255 makes the bitmap completely transparent.</param>
        public void DrawImage(System.Drawing.Point point, Bitmap bitmap, ushort opacity = OpacityOpaque) =>
            DrawImage(point.X, point.Y, bitmap, 0, 0, bitmap.Width, bitmap.Height, opacity);

        /// <summary>
        /// Rotates a rectangular block of pixels with a specified degree of transparency.
        /// </summary>
        /// <param name="angle">The degree of rotation.</param>
        /// <param name="xDst">The x-coordinate of the center of the destination bitmap.</param>
        /// <param name="yDst">The y-coordinate of the center of the destination bitmap.</param>
        /// <param name="bitmap">The source bitmap.</param>
        /// <param name="xSrc">The x-coordinate of the center of the source bitmap.</param>
        /// <param name="ySrc">The y-coordinate of the center of the source bitmap.</param>
        /// <param name="width">The width of the rectangular block of pixels to be copied.</param>
        /// <param name="height">The height of the rectangular block of pixels to be copied.</param>
        /// <param name="opacity">The degree of opacity of the bitmap. A value of 0 (zero) makes the bitmap completely opaque (not transparent at all); a value of 255 makes the bitmap completely transparent.</param>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern void RotateImage(int angle, int xDst, int yDst, Bitmap bitmap, int xSrc, int ySrc, int width, int height, ushort opacity = OpacityOpaque);

        /// <summary>
        /// Rotates a rectangular block of pixels with a specified degree of transparency.
        /// </summary>
        /// <param name="angle">The degree of rotation.</param>
        /// <param name="point">The location of the center of the destination bitmap.</param>
        /// <param name="bitmap">The source bitmap.</param>
        /// <param name="rectangle">The rectangle of the source bitmap.</param>
        /// <param name="opacity">The degree of opacity of the bitmap. A value of 0 (zero) makes the bitmap completely opaque (not transparent at all); a value of 255 makes the bitmap completely transparent.</param>
        public void RotateImage(int angle, System.Drawing.Point point, Bitmap bitmap, Rectangle rectangle, ushort opacity = OpacityOpaque) =>
            RotateImage(angle, point.X, point.Y, bitmap, rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, opacity);

        /// <summary>
        /// Rotates a rectangular block of pixels with a specified degree of transparency.
        /// </summary>
        /// <param name="angle">The degree of rotation.</param>
        /// <param name="point">The location of the center of the destination bitmap.</param>
        /// <param name="bitmap">The source bitmap.</param>
        /// <param name="opacity">The degree of opacity of the bitmap. A value of 0 (zero) makes the bitmap completely opaque (not transparent at all); a value of 255 makes the bitmap completely transparent.</param>
        public void RotateImage(int angle, System.Drawing.Point point, Bitmap bitmap, ushort opacity = OpacityOpaque) =>
            RotateImage(angle, point.X, point.Y, bitmap, 0, 0, bitmap.Width, bitmap.Height, opacity);

        /// <summary>
        /// Sets a bitmap's transparent color.
        /// </summary>
        /// <param name="color">The color to be used as the bitmap's transparent color.</param>
        public void MakeTransparent(Color color) => MakeTransparent((uint)color.ToArgb());

        /// <summary>
        /// Draws a rectangular block of pixels on the display device, stretching or shrinking the rectangular area as necessary.
        /// </summary>
        /// <param name="xDst">The x-coordinate of the upper-left corner of the rectangular area to which the pixels are to be copied.</param>
        /// <param name="yDst">The y-coordinate of the upper-left corner of the rectangular area to which the pixels are to be copied.</param>
        /// <param name="sourceBitmap">The source bitmap.</param>
        /// <param name="width">The width of the rectangular area to which the pixels are to be copied.</param>
        /// <param name="height">The height of the rectangular area to which the pixels are to be copied.</param>
        /// <param name="opacity">The degree of opacity of the bitmap. A value of 0 (zero) makes the bitmap completely opaque (not transparent at all), and a value of 255 makes the bitmap completely transparent.</param>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern void StretchImage(int xDst, int yDst, Bitmap sourceBitmap, int width, int height, ushort opacity = OpacityOpaque);

        /// <summary>
        /// Draws a rectangular block of pixels on the display device, stretching or shrinking the rectangular area as necessary.
        /// </summary>
        /// <param name="point">The location of the upper-left corner of the rectangular area to which the pixels are to be copied.</param>
        /// <param name="sourceBitmap">The source bitmap.</param>
        /// <param name="size">The size of the stretched image.</param>
        /// <param name="opacity">The degree of opacity of the bitmap. A value of 0 (zero) makes the bitmap completely opaque (not transparent at all), and a value of 255 makes the bitmap completely transparent.</param>
        public void StretchImage(System.Drawing.Point point, Bitmap sourceBitmap, Size size, ushort opacity = OpacityOpaque) =>
            StretchImage(point.X, point.Y, sourceBitmap, size.Width, size.Height, opacity);

        /// <summary>
        /// Draws a line on the display device.
        /// </summary>
        /// <param name="color">The color of the line.</param>
        /// <param name="thickness">The thickness of the line, in pixels. (Not currently available; all lines are one pixel thick.)</param>
        /// <param name="x0">The x-coordinate of the line's starting point.</param>
        /// <param name="y0">The y-coordinate of the line's starting point.</param>
        /// <param name="x1">The x-coordinate of the line's ending point.</param>
        /// <param name="y1">The y-coordinate of the line's ending point.</param>
        public void DrawLine(Color color, int thickness, int x0, int y0, int x1, int y1) => DrawLine((uint)color.ToArgb(), thickness, x0, y0, x1, y1);

        /// <summary>
        /// Draws a line on the display device.
        /// </summary>
        /// <param name="color">The color of the line.</param>
        /// <param name="thickness">The thickness of the line, in pixels. (Not currently available; all lines are one pixel thick.)</param>
        /// <param name="start">The location of the line's starting point.</param>
        /// <param name="end">The location of the line's ending point.</param>
        public void DrawLine(Color color, int thickness, System.Drawing.Point start, System.Drawing.Point end) => 
            DrawLine(color, thickness, start.X, start.Y, end.X, end.Y);

        /// <summary>
        /// Draws a rectangle outline on the display device.
        /// </summary>
        /// <param name="x">The x-coordinate of the rectangle's upper-left corner.</param>
        /// <param name="y">The y-coordinate of the rectangle's upper-left corner.</param>
        /// <param name="width">The width of the rectangle, in pixels.</param>
        /// <param name="height">The height of the rectangle, in pixels.</param>
        /// <param name="thickness">The thickness of the rectangle's outline, in pixels.</param>
        /// <param name="color">The color of the rectangle's outline.</param>
        public void DrawRectangle(int x, int y, int width, int height, int thickness, Color color) => 
            DrawRectangle(x, y, width, height, thickness, (uint)color.ToArgb());

        /// <summary>
        /// Draws a rectangle outline on the display device.
        /// </summary>
        /// <param name="rectangle">The rectangle to draw.</param>
        /// <param name="thickness">The thickness of the rectangle's outline, in pixels.</param>
        /// <param name="color">The color of the rectangle's outline.</param>
        public void DrawRectangle(Rectangle rectangle, int thickness, Color color) => 
            DrawRectangle(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, thickness, color);

        /// <summary>
        /// Draws a rectangle on the display device.
        /// </summary>
        /// <param name="colorOutline">The color of the rectangle's outline.</param>
        /// <param name="thicknessOutline">The thickness of the rectangle's outline, in pixels.</param>
        /// <param name="x">The x-coordinate of the rectangle's upper-left corner.</param>
        /// <param name="y">The y-coordinate of the rectangle's upper-left corner.</param>
        /// <param name="width">The width of the rectangle, in pixels.</param>
        /// <param name="height">The height of the rectangle, in pixels.</param>
        /// <param name="xCornerRadius">The x-coordinate value of the corner radius used to produce rounded corners on the rectangle.</param>
        /// <param name="yCornerRadius">The y-coordinate value of the corner radius used to produce rounded corners on the rectangle.</param>
        /// <param name="colorGradientStart">The starting color for a color gradient.</param>
        /// <param name="xGradientStart">The x-coordinate location of the starting point of the color gradient.</param>
        /// <param name="yGradientStart">The y-coordinate location of the starting point of the color gradient.</param>
        /// <param name="colorGradientEnd">The ending color of the color gradient.</param>
        /// <param name="xGradientEnd">The x-coordinate location of the ending point of the color gradient.</param>
        /// <param name="yGradientEnd">The y-coordinate location of the ending point of the color gradient.</param>
        /// <param name="opacity">Specifies the opacity of the fill color. Set to 0x00 for completely transparent. Set to 0xFF for completely opaque.</param>
        public void DrawRectangle(
            Color colorOutline, int thicknessOutline,
            int x, int y, int width, int height, int xCornerRadius, int yCornerRadius,
            Color colorGradientStart, int xGradientStart, int yGradientStart,
            Color colorGradientEnd, int xGradientEnd, int yGradientEnd,
            ushort opacity = OpacityOpaque
            ) => DrawRectangle(
                (uint)colorOutline.ToArgb(), thicknessOutline,
                x, y, width, height, xCornerRadius, yCornerRadius,
                (uint)colorGradientStart.ToArgb(), xGradientStart, yGradientStart,
                (uint)colorGradientEnd.ToArgb(), xGradientEnd, yGradientEnd,
                opacity);

        /// <summary>
        /// Draws a rectangle on the display device.
        /// </summary>
        /// <param name="colorOutline">The color of the rectangle's outline.</param>
        /// <param name="thicknessOutline">The thickness of the rectangle's outline, in pixels.</param>
        /// <param name="rectangle">The rectangle to draw.</param>
        /// <param name="xCornerRadius">The x-coordinate value of the corner radius used to produce rounded corners on the rectangle.</param>
        /// <param name="yCornerRadius">The y-coordinate value of the corner radius used to produce rounded corners on the rectangle.</param>
        /// <param name="colorGradientStart">The starting color for a color gradient.</param>
        /// <param name="gradientStartPoint">The location of the starting point of the color gradient.</param>
        /// <param name="colorGradientEnd">Specifies the ending color of the color gradient.</param>
        /// <param name="gradientEndPoint">The location of the ending point of the color gradient.</param>
        /// <param name="opacity">Specifies the opacity of the fill color. Set to 0x00 for completely transparent. Set to 0xFF for completely opaque.</param>
        public void DrawRectangle(
            Color colorOutline, int thicknessOutline,
            Rectangle rectangle, int xCornerRadius, int yCornerRadius,
            Color colorGradientStart, System.Drawing.Point gradientStartPoint,
            Color colorGradientEnd, System.Drawing.Point gradientEndPoint,
            ushort opacity = OpacityOpaque) =>
            DrawRectangle(colorOutline, thicknessOutline, rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height,
                xCornerRadius, yCornerRadius, colorGradientStart, gradientStartPoint.X, gradientStartPoint.Y,
                colorGradientEnd, gradientEndPoint.X, gradientEndPoint.Y, opacity);

        /// <summary>
        /// Draw a rounded rectangle outline on the display device.
        /// </summary>
        /// <param name="x">The x-coordinate of the rectangle's upper-left corner.</param>
        /// <param name="y">The y-coordinate of the rectangle's upper-left corner.</param>
        /// <param name="width">The width of the rectangle, in pixels.</param>
        /// <param name="height">The height of the rectangle, in pixels.</param>
        /// <param name="thickness">The thickness of the rectangle's outline, in pixels.</param>
        /// <param name="xCornerRadius">The x-coordinate value of the corner radius used to produce rounded corners on the rectangle.</param>
        /// <param name="yCornerRadius">The y-coordinate value of the corner radius used to produce rounded corners on the rectangle.</param>
        /// <param name="color">The color of the rectangle's outline.</param>
        public void DrawRoundRectangle(int x, int y, int width, int height, int thickness, int xCornerRadius, int yCornerRadius, Color color) => DrawRoundRectangle(x, y, width, height, thickness, xCornerRadius, yCornerRadius, (uint)color.ToArgb());

        /// <summary>
        /// Draw a rounded rectangle outline on the display device.
        /// </summary>
        /// <param name="rectangle">The rectangle to draw.</param>
        /// <param name="thickness">The thickness of the rectangle's outline, in pixels.</param>
        /// <param name="xCornerRadius">The x-coordinate value of the corner radius used to produce rounded corners on the rectangle.</param>
        /// <param name="yCornerRadius">The y-coordinate value of the corner radius used to produce rounded corners on the rectangle.</param>
        /// <param name="color">The color of the rectangle's outline.</param>
        public void DrawRoundRectangle(Rectangle rectangle, int thickness, int xCornerRadius, int yCornerRadius,
            Color color) => DrawRoundRectangle(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, thickness,
            xCornerRadius, yCornerRadius, color);

        /// <summary>
        /// Draw a rounded rectangle outline on the display device.
        /// </summary>
        /// <param name="rectangle">The rectangle to draw.</param>
        /// <param name="thickness">The thickness of the rectangle's outline, in pixels.</param>
        /// <param name="cornerRadius">The corner radius used to produce rounded corners on the rectangle.</param>
        /// <param name="color">The color of the rectangle's outline.</param>
        public void DrawRoundRectangle(Rectangle rectangle, int thickness, int cornerRadius, Color color) => 
            DrawRoundRectangle(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, thickness, cornerRadius, cornerRadius, color);

        /// <summary>
        /// Draw a filled rectangle on the display device.
        /// </summary>
        /// <param name="x">The x-coordinate of the rectangle's upper-left corner.</param>
        /// <param name="y">The y-coordinate of the rectangle's upper-left corner.</param>
        /// <param name="width">The width of the rectangle, in pixels.</param>
        /// <param name="height">The height of the rectangle, in pixels.</param>
        /// <param name="color">The color of the rectangle's outline.</param>
        /// <param name="opacity">Specifies the opacity of the fill color. Set to OpacityTransparent for completely transparent. Set to OpacityOpaque for completely opaque.</param>
        public void FillRectangle(int x, int y, int width, int height, Color color, ushort opacity = OpacityOpaque) => FillRectangle(x, y, width, height, (uint)color.ToArgb(), opacity);

        /// <summary>
        /// Draw a filled rectangle on the display device.
        /// </summary>
        /// <param name="rectangle">The rectangle to draw.</param>
        /// <param name="color">The color of the rectangle's outline.</param>
        /// <param name="opacity">Specifies the opacity of the fill color. Set to OpacityTransparent for completely transparent. Set to OpacityOpaque for completely opaque.</param>
        public void FillRectangle(Rectangle rectangle, Color color, ushort opacity = OpacityOpaque) =>
            FillRectangle(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, color, opacity);

        /// <summary>
        /// Draw a filled rounded rectangle on the display device.
        /// </summary>
        /// <param name="x">The x-coordinate of the rectangle's upper-left corner.</param>
        /// <param name="y">The y-coordinate of the rectangle's upper-left corner.</param>
        /// <param name="width">The width of the rectangle, in pixels.</param>
        /// <param name="height">The height of the rectangle, in pixels.</param>
        /// <param name="xCornerRadius">The x-coordinate value of the corner radius used to produce rounded corners on the rectangle.</param>
        /// <param name="yCornerRadius">The y-coordinate value of the corner radius used to produce rounded corners on the rectangle.</param>
        /// <param name="color">The color of the rectangle's outline.</param>
        /// <param name="opacity">Specifies the opacity of the fill color. Set to OpacityTransparent for completely transparent. Set to OpacityOpaque for completely opaque.</param>
        public void FillRoundRectangle(int x, int y, int width, int height, int xCornerRadius, int yCornerRadius, Color color, ushort opacity = OpacityOpaque) => FillRoundRectangle(x, y, width, height, xCornerRadius, yCornerRadius, (uint)color.ToArgb(), opacity);

        /// <summary>
        /// Draw a filled rounded rectangle on the display device.
        /// </summary>
        /// <param name="rectangle">The rectangle to draw.</param>
        /// <param name="xCornerRadius">The x-coordinate value of the corner radius used to produce rounded corners on the rectangle.</param>
        /// <param name="yCornerRadius">The y-coordinate value of the corner radius used to produce rounded corners on the rectangle.</param>
        /// <param name="color">The color of the rectangle's outline.</param>
        /// <param name="opacity">Specifies the opacity of the fill color. Set to OpacityTransparent for completely transparent. Set to OpacityOpaque for completely opaque.</param>
        public void FillRoundRectangle(Rectangle rectangle, int xCornerRadius, int yCornerRadius, Color color, ushort opacity = OpacityOpaque) =>
            FillRoundRectangle(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, xCornerRadius, yCornerRadius, color, opacity);

        /// <summary>
        /// Draw a filled rounded rectangle on the display device.
        /// </summary>
        /// <param name="rectangle">The rectangle to draw.</param>
        /// <param name="cornerRadius">The corner radius used to produce rounded corners on the rectangle.</param>
        /// <param name="color">The color of the rectangle's outline.</param>
        /// <param name="opacity">Specifies the opacity of the fill color. Set to OpacityTransparent for completely transparent. Set to OpacityOpaque for completely opaque.</param>
        public void FillRoundRectangle(Rectangle rectangle, int cornerRadius, Color color, ushort opacity = OpacityOpaque) =>
            FillRoundRectangle(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, cornerRadius, cornerRadius, color, opacity);

        /// <summary>
        /// Draws a filled rectangle with a color gradient on the display device.
        /// </summary>
        /// <param name="x">The x-coordinate of the rectangle's upper-left corner.</param>
        /// <param name="y">The y-coordinate of the rectangle's upper-left corner.</param>
        /// <param name="width">The width of the rectangle, in pixels.</param>
        /// <param name="height">The height of the rectangle, in pixels.</param>
        /// <param name="colorGradientStart">The starting color for the color gradient.</param>
        /// <param name="xGradientStart">The x-coordinate of the starting location of the color gradient.</param>
        /// <param name="yGradientStart">The y-coordinate of the starting location of the color gradient.</param>
        /// <param name="colorGradientEnd">The ending color of the color gradient.</param>
        /// <param name="xGradientEnd">The x-coordinate of the ending location of the color gradient.</param>
        /// <param name="yGradientEnd">The y-coordinate of the ending location of the color gradient.</param>
        /// <param name="opacity">The opacity of the fill color, ranging from completely transparent to completely opaque.</param>
        public void FillGradientRectangle(int x, int y, int width, int height,
            Color colorGradientStart, int xGradientStart, int yGradientStart,
            Color colorGradientEnd, int xGradientEnd, int yGradientEnd, ushort opacity = OpacityOpaque) => FillGradientRectangle(x, y, width, height, (uint)colorGradientStart.ToArgb(), xGradientStart, yGradientStart, (uint)colorGradientEnd.ToArgb(), xGradientEnd, yGradientEnd, opacity);

        /// <summary>
        /// Draws a filled rectangle with a color gradient on the display device.
        /// </summary>
        /// <param name="rectangle">The rectangle to draw.</param>
        /// <param name="colorGradientStart">The starting color for the color gradient.</param>
        /// <param name="gradientStartPoint">The starting location of the color gradient.</param>
        /// <param name="colorGradientEnd">The ending color of the color gradient.</param>
        /// <param name="gradientEndPoint">The ending location of the color gradient.</param>
        /// <param name="opacity">The opacity of the fill color, ranging from completely transparent to completely opaque.</param>
        public void FillGradientRectangle(Rectangle rectangle,
            Color colorGradientStart, System.Drawing.Point gradientStartPoint,
            Color colorGradientEnd, System.Drawing.Point gradientEndPoint, ushort opacity = OpacityOpaque) =>
            FillGradientRectangle(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, colorGradientStart,
                gradientStartPoint.X, gradientStartPoint.Y, colorGradientEnd, gradientEndPoint.X, gradientEndPoint.Y,
                opacity);

        /// <summary>
        /// Draws text on the display device using a specified font and color.
        /// </summary>
        /// <param name="text">The text to be drawn.</param>
        /// <param name="font">The font to be used for the text.</param>
        /// <param name="color">The color to be used for the text.</param>
        /// <param name="x">The x-coordinate of the location where the text drawing is to begin.</param>
        /// <param name="y">The y-coordinate of the location where the text drawing is to begin.</param>
        public void DrawText(string text, Font font, Color color, int x, int y) => DrawText(text, font, (uint)color.ToArgb(), x, y);

        /// <summary>
        /// Draws text on the display device using a specified font and color.
        /// </summary>
        /// <param name="text">The text to be drawn.</param>
        /// <param name="font">The font to be used for the text.</param>
        /// <param name="color">The color to be used for the text.</param>
        /// <param name="point">The location where the text drawing is to begin.</param>
        public void DrawText(string text, Font font, Color color, System.Drawing.Point point) => DrawText(text, font, color, point.X, point.Y);

        /// <summary>
        /// Sets the color of a specified pixel on the display device.
        /// </summary>
        /// <param name="xPos">The x-coordinate of the pixel whose color you want to set.</param>
        /// <param name="yPos">The y-coordinate of the pixel whose color you want to set.</param>
        /// <param name="color">The color you want to set for the specified pixel.</param>
        public void SetPixel(int xPos, int yPos, Color color) => SetPixel(xPos, yPos, (uint)color.ToArgb());

        /// <summary>
        /// Sets the color of a specified pixel on the display device.
        /// </summary>
        /// <param name="point">The location of the pixel whose color you want to set.</param>
        /// <param name="color">The color you want to set for the specified pixel.</param>
        public void SetPixel(System.Drawing.Point point, Color color) => SetPixel(point.X, point.Y, color);
        
        /// <summary>
        /// Retrieves the pixel color at a specified location on the display device.
        /// </summary>
        /// <param name="xPos">The x-coordinate of the pixel whose color you want to get.</param>
        /// <param name="yPos">The y-coordinate of the pixel whose color you want to get.</param>
        /// <returns>The color of the specified pixel.</returns>
        public Color GetPixel(int xPos, int yPos) => Color.FromArgb((int)GetPixelInt(xPos, yPos));

        /// <summary>
        /// Retrieves the pixel color at a specified location on the display device.
        /// </summary>
        /// <param name="point">The location of the pixel whose color you want to get.</param>
        /// <returns>The color of the specified pixel.</returns>
        public Color GetPixel(System.Drawing.Point point) => GetPixel(point.X, point.Y);

        /// <summary>
        /// Gets the bitmap of the display device.
        /// </summary>
        /// <returns>A byte array representing the bitmap of the display device.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern byte[] GetBitmap();

        /// <summary>
        /// Stretches a bitmap to fill a rectangular area on the display device.
        /// </summary>
        /// <param name="xDst">The x-coordinate of the upper-left corner of the rectangular area to which the pixels are to be copied.</param>
        /// <param name="yDst">The y-coordinate of the upper-left corner of the rectangular area to which the pixels are to be copied.</param>
        /// <param name="widthDst">The width of the rectangular area to which the pixels are to be copied.</param>
        /// <param name="heightDst">The height of the rectangular area to which the pixels are to be copied.</param>
        /// <param name="bitmap">The source bitmap to stretch onto the display device.</param>
        /// <param name="xSrc">The x-coordinate of the upper-left corner of the rectangular area from which the pixels are to be copied.</param>
        /// <param name="ySrc">The y-coordinate of the upper-left corner of the rectangular area from which the pixels are to be copied.</param>
        /// <param name="widthSrc">The width of the rectangular area from which the pixels are to be copied.</param>
        /// <param name="heightSrc">The height of the rectangular area from which the pixels are to be copied.</param>
        /// <param name="opacity">The bitmap's degree of opacity. A value of 0 makes the bitmap completely opaque; a value of 255 makes the bitmap completely transparent.</param>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern void StretchImage(int xDst, int yDst, int widthDst, int heightDst, Bitmap bitmap, int xSrc, int ySrc, int widthSrc, int heightSrc, ushort opacity = OpacityOpaque);

        /// <summary>
        /// Tiles an image on the display device.
        /// </summary>
        /// <param name="xDst">The x-coordinate of the upper-left corner of the rectangular area to which the pixels are to be copied.</param>
        /// <param name="yDst">The y-coordinate of the upper-left corner of the rectangular area to which the pixels are to be copied.</param>
        /// <param name="bitmap">The source bitmap to tile onto the display device.</param>
        /// <param name="width">The width of the tile.</param>
        /// <param name="height">The height of the tile.</param>
        /// <param name="opacity">The bitmap's degree of opacity. A value of 0 makes the bitmap completely opaque; a value of 255 makes the bitmap completely transparent.</param>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern void TileImage(int xDst, int yDst, Bitmap bitmap, int width, int height, ushort opacity = OpacityOpaque);

        /// <summary>
        /// Tiles an image on the display device.
        /// </summary>
        /// <param name="point">The location of the upper-left corner of the rectangular area to which the pixels are to be copied.</param>
        /// <param name="bitmap">The source bitmap to tile onto the display device.</param>
        /// <param name="size">The size of the tile.</param>
        /// <param name="opacity">The bitmap's degree of opacity. A value of 0 makes the bitmap completely opaque; a value of 255 makes the bitmap completely transparent.</param>
        public void TileImage(Point point, Bitmap bitmap, Size size, ushort opacity = OpacityOpaque) =>
            TileImage(point.X, point.Y, bitmap, size.Width, size.Height, opacity);

        /// <summary>
        /// Scales a bitmap to fill a rectangular area on the display device using the Scale9Grid technique.
        /// </summary>
        /// <param name="xDst">The x-coordinate of the upper-left corner of the rectangular area to which the pixels are to be copied.</param>
        /// <param name="yDst">The y-coordinate of the upper-left corner of the rectangular area to which the pixels are to be copied.</param>
        /// <param name="widthDst">The width of the rectangular area to which the pixels are to be copied.</param>
        /// <param name="heightDst">The height of the rectangular area to which the pixels are to be copied.</param>
        /// <param name="bitmap">The source bitmap.</param>
        /// <param name="leftBorder">The number of pixels to be left unscaled at the left edge of the source bitmap.</param>
        /// <param name="topBorder">The number of pixels to be left unscaled at the top edge of the source bitmap.</param>
        /// <param name="rightBorder">The number of pixels to be left unscaled at the right edge of the source bitmap.</param>
        /// <param name="bottomBorder">The number of pixels to be left unscaled at the bottom edge of the source bitmap.</param>
        /// <param name="opacity">The bitmap's degree of opacity. A value of 0 (zero) makes the bitmap completely opaque (not transparent at all); a value of 255 makes the bitmap completely transparent.</param>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern void Scale9Image(int xDst, int yDst, int widthDst, int heightDst, Bitmap bitmap, int leftBorder, int topBorder, int rightBorder, int bottomBorder, ushort opacity = OpacityOpaque);

        /// <summary>
        /// Scales a bitmap to fill a rectangular area on the display device using the Scale9Grid technique.
        /// </summary>
        /// <param name="xDst">The x-coordinate of the upper-left corner of the rectangular area to which the pixels are to be copied.</param>
        /// <param name="yDst">The y-coordinate of the upper-left corner of the rectangular area to which the pixels are to be copied.</param>
        /// <param name="widthDst">The width of the rectangular area to which the pixels are to be copied.</param>
        /// <param name="heightDst">The height of the rectangular area to which the pixels are to be copied.</param>
        /// <param name="bitmap">The source bitmap.</param>
        /// <param name="leftBorder">The number of pixels to be left unscaled at the left edge of the source bitmap.</param>
        /// <param name="topBorder">The number of pixels to be left unscaled at the top edge of the source bitmap.</param>
        /// <param name="rightBorder">The number of pixels to be left unscaled at the right edge of the source bitmap.</param>
        /// <param name="bottomBorder">The number of pixels to be left unscaled at the bottom edge of the source bitmap.</param>
        /// <param name="opacity">The bitmap's degree of opacity. A value of 0 (zero) makes the bitmap completely opaque (not transparent at all); a value of 255 makes the bitmap completely transparent.</param>
        public void Scale9Image(Rectangle destination, Bitmap bitmap, int leftBorder, int topBorder, int rightBorder,
            int bottomBorder, ushort opacity = OpacityOpaque) =>
            Scale9Image(destination.X, destination.Y, destination.Width, destination.Height, bitmap, leftBorder,
                topBorder, rightBorder, bottomBorder, opacity);

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases the unmanaged resources used by the Bitmap and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">True to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern void Dispose(bool disposing);

        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the Bitmap is reclaimed by garbage collection.
        /// </summary>
        ~Bitmap()
        {
            Dispose(false);
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern void DrawChar(ushort c, int x, int y, uint color, Font font);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern void DrawEllipse(
            uint colorOutline, int thicknessOutline,
            int x, int y, int xRadius, int yRadius,
            uint colorGradientStart, int xGradientStart, int yGradientStart,
            uint colorGradientEnd, int xGradientEnd, int yGradientEnd,
            ushort opacity);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern void MakeTransparent(uint color);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern void DrawLine(uint color, int thickness, int x0, int y0, int x1, int y1);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern void DrawRectangle(
            uint colorOutline, int thicknessOutline,
            int x, int y, int width, int height, int xCornerRadius, int yCornerRadius,
            uint colorGradientStart, int xGradientStart, int yGradientStart,
            uint colorGradientEnd, int xGradientEnd, int yGradientEnd,
            ushort opacity
            );

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern void DrawRectangle(int x, int y, int width, int height, int thickness, uint color);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern void FillGradientRectangle(int x, int y, int width, int height,
            uint colorGradientStart, int xGradientStart, int yGradientStart,
            uint colorGradientEnd, int xGradientEnd, int yGradientEnd, ushort opacity);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern void FillRectangle(int x, int y, int width, int height, uint color, ushort opacity);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern void DrawRoundRectangle(int x, int y, int width, int height, int thickness, int xCornerRadius, int yCornerRadius, uint color);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern void FillRoundRectangle(int x, int y, int width, int height, int xCornerRadius, int yCornerRadius, uint color, ushort opacity);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern void DrawText(string text, Font font, uint color, int x, int y);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern void SetPixel(int xPos, int yPos, uint color);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern uint GetPixelInt(int xPos, int yPos);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern bool DrawTextInRect(ref string text, ref int xRelStart, ref int yRelStart, int x, int y, int width, int height, uint dtFlags, uint color, Font font);
    }
}
