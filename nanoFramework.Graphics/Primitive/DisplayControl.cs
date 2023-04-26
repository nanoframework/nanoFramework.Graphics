//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using nanoFramework.Presentation.Media;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace nanoFramework.UI
{
    /// <summary>
    /// Display Control.  
    /// </summary>
    public static class DisplayControl
    {
        private static uint _maximumBufferSize;

        static private Bitmap _fullScreen = null;
        private static readonly ushort[] _point = new ushort[1];

        /// <summary>
        /// Gets the maximum buffer size for Bitmap in bytes.
        /// </summary>
        public static uint MaximumBufferSize { get => _maximumBufferSize; internal set => _maximumBufferSize = value; }

        /// <summary>
        /// Initializes the screen for use with Spi configuration.
        /// </summary>
        /// <param name="spi">Spi configuration.</param>
        /// <param name="screen">A screen configuration.</param>
        /// <param name="bufferSize">The desired buffer size allocation, 0 for default.</param>
        /// <remarks>You may have to configure the pins properly for the Spi configuration to be valid before initializing your screen.</remarks>
        /// <returns>The maximum buffer size possible allocation in bytes.</returns>
        public static uint Initialize(SpiConfiguration spi, ScreenConfiguration screen, uint bufferSize = 20 * 1024)
        {
            MaximumBufferSize = NativeInitSpi(spi, screen, bufferSize);
            return MaximumBufferSize;
        }

        /// <summary>
        /// Initializes the screen to use with I2C configuration.
        /// </summary>
        /// <param name="i2c"></param>
        /// <param name="screen">A screen configuration.</param>
        /// <param name="bufferSize">The desired buffer size allocation, 0 for default.</param>
        /// <remarks>You may have to configure the pins properly for the I2C configuration to be valid before initializing your screen.</remarks>
        /// <returns>The maximum buffer size possible allocation in bytes.</returns>
        public static uint Initialize(I2cConfiguration i2c, ScreenConfiguration screen, uint bufferSize = 20 * 1024)
        {
            MaximumBufferSize = NativeInitI2c(i2c, screen, bufferSize);
            return MaximumBufferSize;
        }

        /// <summary>
        /// Gets a Bitmap object that is the size of the current display.
        /// </summary>
        /// <remarks>Please make sure you check if you have enough memory with IsFullScreenBufferAvailable.
        /// If you don't have enough, the BitMap won't get initialized and will be null.</remarks>
        public static Bitmap FullScreen
        {
            get
            {
                if (!IsFullScreenBufferAvailable)
                {
                    return null;
                }

                _fullScreen ??= new Bitmap(ScreenWidth, ScreenHeight);

                return _fullScreen;
            }
        }

        /// <summary>
        /// Determines if a full size buffer is available based on the current screen configuration.
        /// </summary>
        public static bool IsFullScreenBufferAvailable => ScreenWidth * ScreenHeight * 3 / 8 <= MaximumBufferSize; // Internal bit per pixel is 3 bytes

        /// <summary>
        /// Gets the number of pixels for the longer side of the screen.
        /// </summary>
        extern static public int LongerSide
        {
            [MethodImplAttribute(MethodImplOptions.InternalCall)]
            get;
        }

        /// <summary>
        /// Gets the number of pixels for the shorter side of the screen.
        /// </summary>
        extern static public int ShorterSide
        {
            [MethodImplAttribute(MethodImplOptions.InternalCall)]
            get;
        }

        /// <summary>
        /// Gets the number of pixels for the width of the screen based on the orientation.
        /// </summary>
        extern static public int ScreenWidth
        {
            [MethodImplAttribute(MethodImplOptions.InternalCall)]
            get;
        }

        /// <summary>
        /// Gets the number of pixels for the height of the screen based on the orientation.
        /// </summary>
        extern static public int ScreenHeight
        {
            [MethodImplAttribute(MethodImplOptions.InternalCall)]
            get;
        }

        /// <summary>
        /// Gets the number of bits per pixel used to display the screen. Currently 16 bits in RGB565 format.
        /// </summary>
        extern static public int BitsPerPixel
        {
            [MethodImplAttribute(MethodImplOptions.InternalCall)]
            get;
        }

        /// <summary>
        /// Gets the current display orientation, either landscape or portrait.
        /// </summary>
        extern static public DisplayOrientation Orientation
        {
            [MethodImplAttribute(MethodImplOptions.InternalCall)]
            get;
        }

        /// <summary>
        /// Changes the orientation of the display and recreates the display canvas with new dimensions.
        /// </summary>
        /// <param name="orientation">The new orientation to set.</param>
        /// <returns>True if the orientation was supported and changed.</returns>
        /// <remarks>
        /// When the orientation is changed, the display canvas is disposed and recreated with the new dimensions when FullScreen property is next called.
        /// </remarks>
        static public bool ChangeOrientation(DisplayOrientation orientation)
        {
            bool result = NativeChangeOrientation(orientation);
            // if change happened then destroy bitmap as it needs to be recreated with new dimensions.
            if (result && _fullScreen != null)
            {
                _fullScreen.Dispose();
                _fullScreen = null;
            }

            return result;
        }

        /// <summary>
        /// Writes a single point on the screen with the specified color.
        /// </summary>
        /// <param name="x">The x coordinate of the point to be written.</param>
        /// <param name="y">The y coordinate of the point to be written.</param>
        /// <param name="color">The 16-bit color value of the point to be written BGR656 format.</param>
        public static void WritePoint(ushort x, ushort y, ushort color)
        {
            _point[0] = color;
            Write(x, y, 1, 1, _point);
        }

        /// <summary>
        /// Writes a single point on the screen with the specified color.
        /// </summary>
        /// <param name="x">The x coordinate of the point to be written.</param>
        /// <param name="y">The y coordinate of the point to be written.</param>
        /// <param name="color">The 16-bit color value of the point to be written BGR656 format.</param>
        public static void WritePoint(ushort x, ushort y, Color color)
        {
            _point[0] = color.ToBgr565();
            Write(x, y, 1, 1, _point);
        }

        /// <summary>
        /// Clears the screen.
        /// </summary>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        public extern static void Clear();

        /// <summary>
        /// Directly write in the screen at coordinate x,y a width,height buffer of 16 bits colors.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <param name="width">The width of the area to display.</param>
        /// <param name="height">The height of the area to display.</param>
        /// <param name="colors">A BGR565, 16 bits color array.</param>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        public extern static void Write(ushort x, ushort y, ushort width, ushort height, ushort[] colors);

        /// <summary>
        /// Directly write in the screen at coordinate x,y a width,height buffer of 16 bits colors.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <param name="width">The width of the area to display.</param>
        /// <param name="height">The height of the area to display.</param>
        /// <param name="colors">A color array.</param>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        public extern static void Write(ushort x, ushort y, ushort width, ushort height, Color[] colors);

        /// <summary>
        /// Directly write on the screen a text at coordinate x,y a width,height with a background and foreground color.
        /// </summary>
        /// <param name="text">The text to write.</param>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <param name="width">The width of the area to display.</param>
        /// <param name="height">The height of the area to display.</param>
        /// <param name="font">The font to use.</param>
        /// <param name="foreground">Foreground color.</param>
        /// <param name="background">Background color.</param>    
        public static void Write(string text, ushort x, ushort y, ushort width, ushort height, Font font, Color foreground, Color background)
            => Write(text, x, y, width, height, font, (uint)foreground.ToArgb(), (uint)background.ToArgb());

        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        private extern static void Write(string text, ushort x, ushort y, ushort width, ushort height, Font font, uint foreground, uint background);

        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        private extern static bool NativeChangeOrientation(DisplayOrientation Orientation);

        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        private extern static uint NativeInitSpi(SpiConfiguration spi, ScreenConfiguration screen, uint bufferSize);

        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        private extern static uint NativeInitI2c(I2cConfiguration i2c, ScreenConfiguration screen, uint bufferSize);
    }
}
