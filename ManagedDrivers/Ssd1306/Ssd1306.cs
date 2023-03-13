//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using System;
using System.Runtime.InteropServices;

namespace nanoFramework.UI.GraphicDrivers
{
    /// <summary>
    /// Ssd1306 managed graphic driver.
    /// </summary>
    public static class Ssd1306
    {
        private static GraphicDriver _driver;

        // Those enums are left like this to match the native side
        private enum SSD1306_CMD
        {
            Set_Memory_Addressing_Mode = 0x20,

            // Set Column address - 0x21, start adr, end address
            Set_Column_Address = 0x21,

            // Set Page address - 0x22, page start adr, page end address
            Set_Page_address = 0x22,

            Memory_Write = 0x40,

            // Set contrast 0x81 xx
            Set_Contrast = 0x81,

            // Enable / Disable charge pump
            Charge_Pump = 0x8D,

            Set_Segment_remap127 = 0xA1,

            // Display Normal / Inverse
            Set_Normal = 0xA6,
            Set_Inversion = 0xA6,

            // Display On/Off
            Display_OFF = 0xAE,
            Display_ON = 0xAF,

            Set_COM_Scan_x = 0xC8
        };

        [Flags]
        private enum _Orientation
        {
            MADCTL_MH = 0x04, // sets the Horizontal Refresh, 0=Left-Right and 1=Right-Left
            MADCTL_ML = 0x10, // sets the Vertical Refresh, 0=Top-Bottom and 1=Bottom-Top
            MADCTL_MV = 0x20, // sets the Row/Column Swap, 0=Normal and 1=Swapped
            MADCTL_MX = 0x40, // sets the Column Order, 0=Left-Right and 1=Right-Left
            MADCTL_MY = 0x80, // sets the Row Order, 0=Top-Bottom and 1=Bottom-Top

            MADCTL_BGR = 0x08 // Blue-Green-Red pixel order, 0 = RGB, 1 = BGR
        };

        /// <summary>
        /// Default weight. Use to overrride the one you'll pass in the screen and add it to the driver.
        /// </summary>
        public static ushort Width { get; } = 128;

        /// <summary>
        /// Default height. Use to overrride the one you'll pass in the screen and add it to the driver.
        /// </summary>
        public static ushort Height { get; } = 64;

        /// <summary>
        /// Gets the graphic driver for the Ssd1306 display.
        /// </summary>
        public static GraphicDriver GraphicDriver
        {
            get
            {
                if (_driver == null)
                {
                    _driver = new GraphicDriver()
                    {
                        MemoryWrite = (byte)SSD1306_CMD.Memory_Write,
                        SetColumnAddress = (byte)SSD1306_CMD.Set_Column_Address,
                        SetRowAddress = (byte)SSD1306_CMD.Set_Page_address,
                        InitializationSequence = new byte[]
                        {
                            (byte)GraphicDriverCommandType.Command, 2, (byte)(byte)SSD1306_CMD.Charge_Pump, 0x14,
                            (byte)GraphicDriverCommandType.Command, 2, (byte)SSD1306_CMD.Set_Memory_Addressing_Mode, 0x00,
                            (byte)GraphicDriverCommandType.Command, 1, (byte)SSD1306_CMD.Set_Segment_remap127,
                            (byte)GraphicDriverCommandType.Command, 1, (byte)SSD1306_CMD.Set_COM_Scan_x,
                            (byte)GraphicDriverCommandType.Command, 1, (byte)SSD1306_CMD.Display_ON,
                            // Sleep for 50 ms
                            (byte)GraphicDriverCommandType.Sleep, 5,                            
                        },
                        OrientationLandscape = new byte[]
                        {
                            (byte)GraphicDriverCommandType.Command, 1, (byte)SSD1306_CMD.Set_Segment_remap127,
                            (byte)GraphicDriverCommandType.Command, 1, (byte) SSD1306_CMD.Set_COM_Scan_x,
                        },
                        DefaultOrientation = DisplayOrientation.Landscape,
                        SetWindowType = SetWindowType.X8bitsY1Bit,
                    };
                }

                return _driver;
            }
        }
    }
}
