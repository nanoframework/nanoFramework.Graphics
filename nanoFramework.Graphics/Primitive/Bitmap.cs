//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using System;
using System.Runtime.CompilerServices;
using nanoFramework.UI;
using nanoFramework.Presentation.Media;

namespace nanoFramework.UI
{
    /// <summary>
    /// Encapsulates a bitmap, which consists of the pixel data for a graphics image and its methods and attributes
    /// This class cannot be inherited.The.NET Micro Framework provides the
    /// </summary>
    public sealed class Bitmap : MarshalByRefObject, IDisposable
    {
        /// <summary>
        /// Specifies the maximum width of the display device, in pixels.
        /// </summary>
        public static readonly int MaxWidth;//  

        /// <summary>
        /// Specifies the maximum height of the display device, in pixels.
        /// </summary>
        public static readonly int MaxHeight;// 

        /// <summary>
        /// Represents the x-coordinate location of the center of the display device, in pixels.
        /// </summary>
        public static readonly int CenterX;// = (MaxWidth - 1) / 2;

        /// <summary>
        /// Represents the y-coordinate location of the center of the display device, in pixels.
        /// </summary>
        public static readonly int CenterY;// = (MaxHeight - 1) / 2;

        static Bitmap()
        {
            MaxWidth = DisplayControl.ScreenWidth;
            MaxHeight = DisplayControl.ScreenHeight;

            CenterX = (MaxWidth - 1) / 2;
            CenterY = (MaxHeight - 1) / 2;
        }

        /// These have to be kept in sync with the CLR_GFX_Bitmap::c_DrawText_ flags.
        /// <summary>
        /// Specifies that the current bitmap is opaque.
        /// </summary>
        public const ushort OpacityOpaque = 256;
        /// <summary>
        /// Specifies that the current bitmap is transparent.
        /// </summary>
        public const ushort OpacityTransparent = 0;
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
        /// <summary>
        /// Specifies that there are no format rules.
        /// </summary>
        public const uint DT_None = 0x00000000;
        /// <summary>
        /// Specifies whether a line of bitmap text automatically wraps words to the beginning of the next line when the line reaches its maximum width.
        /// </summary>
        public const uint DT_WordWrap = 0x00000001;
        /// <summary>
        /// Specifies that if the bitmap text is larger than the space provided, the text is truncated at the bottom.
        /// </summary>
        public const uint DT_TruncateAtBottom = 0x00000004;
        // [Obsolete("Use DT_TrimmingWordEllipsis or DT_TrimmingCharacterEllipsis to specify the type of trimming needed.", false)]

        /// <summary>
        /// Specifies that the bitmap text is trimmed to the nearest character, and an ellipsis is inserted at the end of each trimmed line.
        /// </summary>
        public const uint DT_Ellipsis = 0x00000008;
        /// <summary>
        /// Specifies that if the bitmap text is larger than the space provided, the text is drawn in its full size, rather than being scaled down to fit the value in the Height property.
        /// </summary>
        public const uint DT_IgnoreHeight = 0x00000010;
        /// <summary>
        /// Specifies that text is left-aligned as it flows around a bitmap.
        /// </summary>
        public const uint DT_AlignmentLeft = 0x00000000;
        /// <summary>
        /// Specifies that text is center-aligned as it flows around a bitmap.
        /// </summary>
        public const uint DT_AlignmentCenter = 0x00000002;
        /// <summary>
        /// Specifies that text is right-aligned as it flows around a bitmap.
        /// </summary>
        public const uint DT_AlignmentRight = 0x00000020;
        /// <summary>
        /// Specifies that you can use a mask to get or set text alignment around a bitmap.
        /// </summary>
        public const uint DT_AlignmentMask = 0x00000022;
        /// <summary>
        /// Not yet documented.
        /// </summary>
        public const uint DT_TrimmingNone = 0x00000000;
        /// <summary>
        /// Not yet documented.
        /// </summary>
        public const uint DT_TrimmingWordEllipsis = 0x00000008;
        /// <summary>
        /// Not yet documented.
        /// </summary>
        public const uint DT_TrimmingCharacterEllipsis = 0x00000040;
        /// <summary>
        /// Not yet documented.
        /// </summary>
        public const uint DT_TrimmingMask = 0x00000048;
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
        /// <param name = "width" > The width of the bitmap.</param>
        /// <param name = "height" > The height of the bitmap.</param>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        extern public Bitmap(int width, int height);

        /// <summary>
        /// Not docummented yet.
        /// </summary>
        /// <param name = "imageData" > An array of pixel data for the specified image.</param>
        /// <param name = "type" > The bitmap type for the specified image.</param>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        extern public Bitmap(byte[] imageData, BitmapImageType type);

        /// <summary>
        /// Flushes the current bitmap to the display device.
        /// The bitmap must have the same dimensions as the display device.The.NET Micro Framework provides the
        /// </summary>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        extern public void Flush();

        /// <summary>
        /// Flushes the current bitmap to the display device.
        /// </summary>
        /// <param name = "x" > The x-coordinate of the bitmap's upper-left corner.</param>
        /// <param name = "y" > The y-coordinate of the bitmap's upper-left corner.</param>
        /// <param name = "width" > The width of the bitmap.</param>
        /// <param name = "height" > The height of the bitmap.</param>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        extern public void Flush(int x, int y, int width, int height);

        /// <summary>
        /// Clears the entire drawing surface.
        /// </summary>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        extern public void Clear();

        /// <summary>
        /// Draws text in a specified rectangle.
        /// Sets the clipping region (clipping rectangle) of a bitmap with a specified coordinate pair (x, y), width, and height.
        /// </summary>
        /// <param name = "text" > The text to be drawn. This parameter contains the remaining text, or an empty string, if the complete text string did not fit in the specified rectangle.</param>
        /// <param name = "xRelStart" > The x-coordinate, relative to the rectangle, at which text drawing is to begin.</param>
        /// <param name = "yRelStart" > The y-coordinate, relative to the rectangle, at which text drawing is to begin.</param>
        /// <param name = "x" > The x-coordinate of the upper-left corner of the rectangle.</param>
        /// <param name = "y" > The y-coordinate of the upper-left corner of the rectangle.</param>
        /// <param name = "width" > The width of the rectangle.</param>
        /// <param name = "height" > The height of the rectangle.</param>
        /// <param name = "dtFlags" > Flags that specify the format of the text.</param>
        /// <param name = "color" > The color to be used for the text.</param>
        /// <param name = "font" > The font to be used for the text.</param>
        /// <returns></returns>

        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        extern public bool DrawTextInRect(ref string text, ref int xRelStart, ref int yRelStart, int x, int y, int width, int height, uint dtFlags, Color color, Font font);

        /// <summary>
        /// <param name = "text" > The text to be drawn. This parameter contains the remaining text, or an empty string, if the complete text string did not fit in the specified rectangle.</param>
        /// <param name = "x" > The x-coordinate of the upper-left corner of the rectangle.</param>
        /// <param name = "y" > The y-coordinate of the upper-left corner of the rectangle.</param>
        /// <param name = "width" > The width of the rectangle.</param>
        /// <param name = "height" > The height of the rectangle.</param>
        /// <param name = "dtFlags" > Flags that specify the format of the text.</param>
        /// <param name = "color" > The color to be used for the text.</param>
        /// <param name = "font" > The font to be used for the text.</param>
        /// </summary>
        public void DrawTextInRect(string text, int x, int y, int width, int height, uint dtFlags, Color color, Font font)
        {
            int xRelStart = 0;
            int yRelStart = 0;

            DrawTextInRect(ref text, ref xRelStart, ref yRelStart, x, y, width, height, dtFlags, color, font);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name = "x" > The x-coordinate of the upper-left corner of the clipping rectangle.</param>
        /// <param name = "y" > The y-coordinate of the upper-left corner of the clipping rectangle.</param>
        /// <param name = "width" > The width of the clipping rectangle.</param>
        /// <param name = "height" > The height of the clipping rectangle.</param>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        extern public void SetClippingRectangle(int x, int y, int width, int height);

        /// <summary>
        /// Gets the width of the current bitmap.
        /// </summary>
        extern public int Width
        {
            [MethodImplAttribute(MethodImplOptions.InternalCall)]
            get;
        }

        /// <summary>
        /// Gets the height of the current bitmap.
        /// </summary>
        extern public int Height
        {
            [MethodImplAttribute(MethodImplOptions.InternalCall)]
            get;
        }

        /// <summary>
        /// Draws an ellipse filled with a specified color gradient.
        /// </summary>
        /// <param name = "colorOutline" > The outline color.</param>
        /// <param name = "thicknessOutline" > The thickness of the ellipse's outline, in pixels.</param>
        /// <param name = "x" > The x-coordinate location of the center of the ellipse.</param>
        /// <param name = "y" > The y-coordinate location of the center of the ellipse.</param>
        /// <param name = "xRadius" > The radius of the ellipse in the x-coordinate direction.</param>
        /// <param name = "yRadius" > The radius of the ellipse in the y-coordinate direction.</param>
        /// <param name = "colorGradientStart" > The starting color of the color gradient.</param>
        /// <param name = "xGradientStart" > The x-coordinate location of the starting point of the color gradient.</param>
        /// <param name = "yGradientStart" > The y-coordinate location of the starting point of the color gradient.</param>
        /// <param name = "colorGradientEnd" > The ending color of the color gradient.</param>
        /// <param name = "xGradientEnd" > The x-coordinate location of the ending point of the color gradient.</param>
        /// <param name = "yGradientEnd" > The y-coordinate location of the ending point of the color gradient.</param>
        /// <param name = "opacity" > The opacity of the ellipse.</param>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        extern public void DrawEllipse(
            Color colorOutline, int thicknessOutline,
            int x, int y, int xRadius, int yRadius,
            Color colorGradientStart, int xGradientStart, int yGradientStart,
            Color colorGradientEnd, int xGradientEnd, int yGradientEnd,
            ushort opacity);

        /// <summary>
        /// Draw and Ellipse
        /// </summary>
        ///<param name = "colorOutline" > The outline color.</param>
        ///<param name = "x" > The x-coordinate location of the center of the ellipse.</param>
        ///<param name = "y" > The y-coordinate location of the center of the ellipse.</param>
        ///<param name = "xRadius" > The radius of the ellipse in the x-coordinate direction.</param>
        ///<param name = "yRadius" > The radius of the ellipse in the y-coordinate direction.</param>
        public void DrawEllipse(Color colorOutline, int x, int y, int xRadius, int yRadius)
        {
            DrawEllipse(colorOutline, 1, x, y, xRadius, yRadius, Color.Black, 0, 0, Color.Black, 0, 0, OpacityOpaque);
        }

        /// <summary>
        /// Draws a rectangular block of pixels with a specified degree of transparency.
        /// </summary>
        /// <param name = "xDst" > The x-coordinate location of the upper-left corner of the rectangular area on the display to which the specified pixels are to be copied.</param>
        /// <param name = "yDst" > The y-coordinate location of the upper-left corner of the rectangular area on the display to which the specified pixels are to be copied.</param>
        /// <param name = "bitmap" > The source bitmap.</param>
        /// <param name = "xSrc" > The x-coordinate location of the upper-left corner of the rectangular area in the source bitmap from which the specified pixels are to be copied.</param>
        /// <param name = "ySrc" > The x-coordinate location of the upper-left corner of the rectangular area in the source bitmap from which the specified pixels are to be copied.</param>
        /// <param name = "width" > The width of the rectangular block of pixels to be copied.</param>
        /// <param name = "height" > The height of the rectangular block of pixels to be copied.</param>
        public void DrawImage(int xDst, int yDst, Bitmap bitmap, int xSrc, int ySrc, int width, int height)
        {
            DrawImage(xDst, yDst, bitmap, xSrc, ySrc, width, height, OpacityOpaque);
        }

        /// <summary>
        ///  Draws a rectangular block of pixels with a specified degree of transparency.
        /// </summary>
        /// <param name = "xDst" > The x-coordinate location of the upper-left corner of the rectangular area on the display to which the specified pixels are to be copied.</param>
        /// <param name = "yDst" > The y-coordinate location of the upper-left corner of the rectangular area on the display to which the specified pixels are to be copied.</param>
        /// <param name = "bitmap" > The source bitmap.</param>
        /// <param name = "xSrc" > The x-coordinate location of the upper-left corner of the rectangular area in the source bitmap from which the specified pixels are to be copied.</param>
        /// <param name = "ySrc" > The x-coordinate location of the upper-left corner of the rectangular area in the source bitmap from which the specified pixels are to be copied.</param>
        /// <param name = "width" > The width of the rectangular block of pixels to be copied.</param>
        /// <param name = "height" > The height of the rectangular block of pixels to be copied.</param>
        /// <param name = "opacity" > The degree of opacity of the bitmap. A value of 0 (zero) makes the bitmap completely opaque (not transparent at all); a value of 255 makes the bitmap completely transparent.</param>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        extern public void DrawImage(int xDst, int yDst, Bitmap bitmap, int xSrc, int ySrc, int width, int height, ushort opacity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name = "angle" > The degree of rotation.</param>
        /// <param name = "xDst" > The x-coordinate of the center? of the destination bitmap.</param>
        /// <param name = "yDst" > The y-coordinate of the center? of the destination bitmap.</param>
        /// <param name = "bitmap"></param>                        ?
        /// <param name = "xSrc" > The x-coordinate of the center? of the source bitmap.</param>
        /// <param name = "ySrc" > The y-coordinate of the center? of the source bitmap.</param>
        /// <param name = "width"></param>
        /// <param name = "height"></param>
        /// <param name = "opacity"></param>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        extern public void RotateImage(int angle, int xDst, int yDst, Bitmap bitmap, int xSrc, int ySrc, int width, int height, ushort opacity);

        /// <summary>
        /// Sets a bitmap's transparent color.
        /// </summary>
        /// <param name = "color" > The color to be used as the bitmap's transparent color.</param>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        extern public void MakeTransparent(Color color);

        /// <summary>
        /// Draws a rectangular block of pixels on the display device, stretching or shrinking the rectangular area as necessary.
        /// </summary>
        /// <param name = "xDst" > The x-coordinate of the upper-left corner of the rectangular area to which the pixels are to be copied.</param>
        /// <param name = "yDst" > The y-coordinate of the upper-left corner of the rectangular area to which the pixels are to be copied.</param>
        /// <param name = "sourceBitmap" > The source bitmap.</param>
        /// <param name = "width" > The width of the rectangluar area to which the pixels are to be copied.</param>
        /// <param name = "height" > The height of the rectangluar area to which the pixels are to be copied.</param>
        /// <param name = "opacity" > The bitmap's degree of opacity. A value of 0 (zero) makes the bitmap completely opaque (not transparent at all); a value of 255 makes the bitmap completely transparent.</param>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        extern public void StretchImage(int xDst, int yDst, Bitmap sourceBitmap, int width, int height, ushort opacity);

        /// <summary>
        ///  Draws a line on the display device.
        /// </summary>
        /// <param name = "color" > The color of the line.</param>
        /// <param name = "thickness" > The thickness of the line, in pixels.Remark: The thickness parameter is not currently available.For now, all lines are one pixel thick.</param>
        /// <param name = "x0" > The x-coordinate location of the line's starting point.</param>
        /// <param name = "y0" > The y-coordinate location of the line's starting point.</param>
        /// <param name = "x1" > The x-coordinate location of the line's ending point.</param>
        /// <param name = "y1" > The y-coordinate location of the line's ending point.</param>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        extern public void DrawLine(Color color, int thickness, int x0, int y0, int x1, int y1);

        /// <summary>
        /// Draws a rectangle on the display device.
        /// </summary>
        /// <param name = "colorOutline" > The color of the rectangle's outline.</param>
        /// <param name = "thicknessOutline" > The thickness of the rectangle's outline, in pixels.</param>
        /// <param name = "x" > The x-coordinate of the rectangle's upper-left corner.</param>
        /// <param name = "y" > The y-coordinate of the rectangle's upper-left corner.</param>
        /// <param name = "width" > The width of the rectangle, in pixels.</param>
        /// <param name = "height" > The height of the rectangle, in pixels.</param>
        /// <param name = "xCornerRadius" > The x-coordinate value of the corner radius used to produce rounded corners on the rectangle.</param>
        /// <param name = "yCornerRadius" > The y-coordinate value of the corner radius used to produce rounded corners on the rectangle.</param>
        /// <param name = "colorGradientStart" > The starting color for a color gradient.</param>
        /// <param name = "xGradientStart" > Holds the x coordinate of the starting location of the color gradient.</param>
        /// <param name = "yGradientStart" > Holds the y coordinate of the starting location of the color gradient.</param>
        /// <param name = "colorGradientEnd" > Specifies the ending color of the color gradient.</param>
        /// <param name = "xGradientEnd" > Holds the x coordinate of the ending location of the color gradient.</param>
        /// <param name = "yGradientEnd" > Holds the y coordinate of the ending location of the color gradient.</param>
        /// <param name = "opacity" > Specifies the opacity of the fill color. Set to 0x00 for completely transparent. Set to 0xFF for completely opague.</param>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        extern public void DrawRectangle(
            Color colorOutline, int thicknessOutline,
            int x, int y, int width, int height, int xCornerRadius, int yCornerRadius,
            Color colorGradientStart, int xGradientStart, int yGradientStart,
            Color colorGradientEnd, int xGradientEnd, int yGradientEnd,
            ushort opacity
            );

        /// <summary>
        /// Draws text on the display device, using a specified font and color.
        /// </summary>
        /// <param name = "text" > The text to be drawn.</param>
        /// <param name = "font" > The font to be used for the text.</param>
        /// <param name = "color" > The color to be used for the text.</param>
        /// <param name = "x" > The x-coordinate of the location where text drawing is to begin.</param>
        /// <param name = "y" > The y-coordinate of the location where text drawing is to begin.</param>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        extern public void DrawText(string text, Font font, Color color, int x, int y);

        /// <summary>
        /// Sets the color for a specified pixel.
        /// </summary>
        /// <param name = "xPos" > The x-coordinate of the pixel whose color you want to set.</param>
        /// <param name = "yPos" > The y-coordinate of the pixel whose color you want to set.</param>
        /// <param name = "color" > The color you want to set for the specified pixel.</param>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        extern public void SetPixel(int xPos, int yPos, Color color);

        /// <summary>
        /// Retrieves the pixel color at a specified location on the display device.
        /// </summary>
        /// <param name = "xPos" > The x-coordinate of the pixel whose color you want to get.</param>
        /// <param name = "yPos" > The y-coordinate of the pixel whose color you want to get.</param>
        /// <returns></returns>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        extern public Color GetPixel(int xPos, int yPos);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        extern public byte[] GetBitmap();

        /// <summary>
        /// 
        /// </summary>
        /// <param name = "xDst" > The x-coordinate of the upper-left corner of the rectangular area to which the pixels are to be copied.</param>
        /// <param name = "yDst" > The y-coordinate of the upper-left corner of the rectangular area to which the pixels are to be copied.</param>
        /// <param name = "widthDst" > The width of the rectangluar area to which the pixels are to be copied.</param>
        /// <param name = "heightDst" > The height of the rectangluar area to which the pixels are to be copied.</param>
        /// <param name = "bitmap" > The source bitmap.</param>
        /// <param name="xSrc"></param>
        /// <param name="ySrc"></param>
        /// <param name="widthSrc"></param>
        /// <param name="heightSrc"></param>
        /// <param name = "opacity" > The bitmap's degree of opacity. A value of 0 (zero) makes the bitmap completely opaque (not transparent at all); a value of 255 makes the bitmap completely transparent.</param>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        extern public void StretchImage(int xDst, int yDst, int widthDst, int heightDst, Bitmap bitmap, int xSrc, int ySrc, int widthSrc, int heightSrc, ushort opacity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name = "xDst" > The x-coordinate of the upper-left corner of the rectangular area to which the pixels are to be copied.</param>
        /// <param name = "yDst" > The y-coordinate of the upper-left corner of the rectangular area to which the pixels are to be copied.</param>
        /// <param name = "bitmap" > The source bitmap.</param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name = "opacity" > The bitmap's degree of opacity. A value of 0 (zero) makes the bitmap completely opaque (not transparent at all); a value of 255 makes the bitmap completely transparent.</param>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        extern public void TileImage(int xDst, int yDst, Bitmap bitmap, int width, int height, ushort opacity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name = "xDst" > The x-coordinate of the upper-left corner of the rectangular area to which the pixels are to be copied.</param>
        /// <param name = "yDst" > The y-coordinate of the upper-left corner of the rectangular area to which the pixels are to be copied.</param>
        /// <param name="widthDst"></param>
        /// <param name="heightDst"></param>
        /// <param name="bitmap"></param>
        /// <param name="leftBorder"></param>
        /// <param name="topBorder"></param>
        /// <param name="rightBorder"></param>
        /// <param name="bottomBorder"></param>
        /// <param name = "opacity" > The bitmap's degree of opacity. A value of 0 (zero) makes the bitmap completely opaque (not transparent at all); a value of 255 makes the bitmap completely transparent.</param>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        extern public void Scale9Image(int xDst, int yDst, int widthDst, int heightDst, Bitmap bitmap, int leftBorder, int topBorder, int rightBorder, int bottomBorder, ushort opacity);

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        extern private void Dispose(bool disposing);

        /// <summary>
        /// 
        /// </summary>
        ~Bitmap()
        {
            Dispose(false);
        }
    }
}


