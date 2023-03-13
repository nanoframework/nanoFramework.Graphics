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
    /// ST7735 managed graphic driver.
    /// </summary>
    public static class St7735
    {
        private static GraphicDriver _driver;

        // Those enums are left like this to match the native side
        private enum ST7789V_CMD
        {
            NOP = 0x00,
            SOFTWARE_RESET = 0x01,
            Sleep_IN = 0x10,
            Sleep_OUT = 0x11,
            Invertion_Off = 0x20,
            Invertion_On = 0x21,
            Display_OFF = 0x28,
            Display_ON = 0x29,
            Column_Address_Set = 0x2A,
            Row_Address_Set = 0x2B,
            Memory_Write = 0x2C,
            Memory_Read = 0x2E,
            Partial_Area = 0x30,
            Memory_Access_Control = 0x36,
            Pixel_Format_Set = 0x3A,
            Memory_Write_Continue = 0x3C,
            Write_Display_Brightness = 0x51,
            Porch_Setting = 0xB2,
            Gate_Control = 0xB7,
            VCOMS_Setting = 0xBB,
            LCM_Control = 0xC0,
            VDV_VRH_Command_Enable = 0xC2,
            VRH_Set = 0xC3,
            VDV_Set = 0xC4,
            Frame_Rate_Control = 0xC6,
            Power_Control_1 = 0xD0,
            Positive_Voltage_Gamma = 0xE0,
            Negative_Voltage_Gamma = 0xE1,
            Read_ID1 = 0xDA,
            Read_ID2 = 0xDB,
            Read_ID3 = 0xDC,
        };

        [Flags]
        private enum ST7789V_Orientation
        {
            MADCTL_MH = 0x04, // sets the Horizontal Refresh, 0=Left-Right and 1=Right-Left
            MADCTL_ML = 0x10, // sets the Vertical Refresh, 0=Top-Bottom and 1=Bottom-Top
            MADCTL_MV = 0x20, // sets the Row/Column Swap, 0=Normal and 1=Swapped
            MADCTL_MX = 0x40, // sets the Column Order, 0=Left-Right and 1=Right-Left
            MADCTL_MY = 0x80, // sets the Row Order, 0=Top-Bottom and 1=Bottom-Top

            MADCTL_BGR = 0x08 // Blue-Green-Red pixel order
        };


        /// <summary>
        /// Default weight. Use to overrride the one you'll pass in the screen and add it to the driver.
        /// </summary>
        public static ushort Width { get; } = 320;

        /// <summary>
        /// Default height. Use to overrride the one you'll pass in the screen and add it to the driver.
        /// </summary>
        public static ushort Height { get; } = 240;

        /// <summary>
        /// Gets the graphic driver for the ST7735 display.
        /// </summary>
        public static GraphicDriver GraphicDriver
        {
            get
            {
                if (_driver == null)
                {
                    _driver = new GraphicDriver()
                    {
                        MemoryWrite = (byte)ST7789V_CMD.Memory_Write,
                        SetColumnAddress = (byte)ST7789V_CMD.Column_Address_Set,
                        SetRowAddress = (byte)ST7789V_CMD.Row_Address_Set,
                        InitializationSequence = new byte[]
                        {
                            (byte)GraphicDriverCommandType.Command, 1, (byte)ST7789V_CMD.SOFTWARE_RESET,
                            // Sleep for 50 ms
                            (byte)GraphicDriverCommandType.Sleep, 5,
                            (byte)GraphicDriverCommandType.Command, 2, (byte)ST7789V_CMD.Pixel_Format_Set, 0x55,
                            (byte)GraphicDriverCommandType.Command, 6, (byte)ST7789V_CMD.Porch_Setting, 0x0c, 0x0c, 0x00, 0x33, 0x33,
                            (byte)GraphicDriverCommandType.Command, 2, (byte)ST7789V_CMD.Gate_Control, 0x35,
                            (byte)GraphicDriverCommandType.Command, 2, (byte)ST7789V_CMD.VCOMS_Setting, 0x2B,
                            (byte)GraphicDriverCommandType.Command, 2, (byte)ST7789V_CMD.LCM_Control, 0x2C,
                            (byte)GraphicDriverCommandType.Command, 3, (byte)ST7789V_CMD.VDV_VRH_Command_Enable, 0x01, 0xFF,
                            (byte)GraphicDriverCommandType.Command, 2, (byte)ST7789V_CMD.VRH_Set, 0x11,
                            (byte)GraphicDriverCommandType.Command, 2, (byte)ST7789V_CMD.VDV_Set, 0x20,
                            (byte)GraphicDriverCommandType.Command, 2, (byte)ST7789V_CMD.Frame_Rate_Control, 0x0f,
                            (byte)GraphicDriverCommandType.Command, 3, (byte)ST7789V_CMD.Power_Control_1, 0xA4, 0xA1,
                            (byte)GraphicDriverCommandType.Command, 15, (byte)ST7789V_CMD.Positive_Voltage_Gamma, 0xD0, 0x00, 0x05, 0x0E, 0x15, 0x0D, 0x37, 0x43, 0x47, 0x09, 0x15, 0x12, 0x16, 0x19,
                            (byte)GraphicDriverCommandType.Command, 15, (byte)ST7789V_CMD.Negative_Voltage_Gamma, 0xD0, 0x00, 0x05, 0x0D, 0x0C, 0x06, 0x2D, 0x44, 0x40, 0x0E, 0x1C, 0x18, 0x16, 0x19,
                            (byte)GraphicDriverCommandType.Command, 1, (byte)ST7789V_CMD.Invertion_On,
                            (byte)GraphicDriverCommandType.Command, 1, (byte)ST7789V_CMD.Sleep_OUT,
                            // Sleep 20 ms
                            (byte)GraphicDriverCommandType.Sleep, 2,
                            (byte)GraphicDriverCommandType.Command, 1, (byte)ST7789V_CMD.Display_ON,
                            // Sleep 20 ms
                            (byte)GraphicDriverCommandType.Sleep, 2,
                            (byte)GraphicDriverCommandType.Command, 1, (byte)ST7789V_CMD.NOP,
                            // Sleep 20 ms
                            (byte)GraphicDriverCommandType.Sleep, 2,
                        },
                        OrientationLandscape = new byte[]
                        {
                            (byte)GraphicDriverCommandType.Command, 2, (byte)ST7789V_CMD.Memory_Access_Control, (byte)(ST7789V_Orientation.MADCTL_ML | ST7789V_Orientation.MADCTL_BGR),
                        },
                        PowerModeNormal = new byte[]
                        {
                            (byte)GraphicDriverCommandType.Command, 3, (byte)ST7789V_CMD.Sleep_IN, 0x00, 0x00,
                        },
                        PowerModeSleep = new byte[]
                        {
                            (byte)GraphicDriverCommandType.Command, 3, (byte)ST7789V_CMD.Sleep_IN, 0x00, 0x01,
                        },
                        DefaultOrientation = DisplayOrientation.Landscape,
                        Brightness = (byte)ST7789V_CMD.Write_Display_Brightness,
                        SetWindowType = SetWindowType.X16bitsY16Bit,
                    };
                }

                return _driver;
            }
        }
    }
}
