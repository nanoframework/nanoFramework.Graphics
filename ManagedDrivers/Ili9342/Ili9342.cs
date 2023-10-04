//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace nanoFramework.UI.GraphicDrivers
{
    /// <summary>
    /// Managed driver for Ili9342.
    /// </summary>
    public static class Ili9342
    {
        private static GraphicDriver _driver;

        // Those enums are left like this to match the native side
        private enum ILI9341_CMD
        {
            NOP = 0x00,
            SOFTWARE_RESET = 0x01,
            POWER_STATE = 0x10,
            Sleep_Out = 0x11,
            Noron = 0x13,
            Invert_On = 0x21,
            Invert_Off = 0x20,
            Gamma_Set = 0x26,
            Display_OFF = 0x28,
            Display_ON = 0x29,
            Column_Address_Set = 0x2A,
            Page_Address_Set = 0x2B,
            Memory_Write = 0x2C,
            Colour_Set = 0x2D,
            Memory_Read = 0x2E,
            Partial_Area = 0x30,
            Memory_Access_Control = 0x36,
            Pixel_Format_Set = 0x3A,
            Memory_Write_Continue = 0x3C,
            Write_Display_Brightness = 0x51,
            Interface_Signal_Control = 0xB0,
            Frame_Rate_Control_Normal = 0xB1,
            Display_Function_Control = 0xB6,
            Entry_Mode_Set = 0xB7,
            Power_Control_1 = 0xC0,
            Power_Control_2 = 0xC1,
            VCOM_Control_1 = 0xC5,
            VCOM_Control_2 = 0xC7,
            External_Command = 0xC8,
            Power_Control_A = 0xCB,
            Power_Control_B = 0xCF,
            Positive_Gamma_Correction = 0xE0,
            Negative_Gamma_Correction = 0XE1,
            Driver_Timing_Control_A = 0xE8,
            Driver_Timing_Control_B = 0xEA,
            Power_On_Sequence = 0xED,
            Enable_3G = 0xF2,
            Interface_Control = 0xF6,
            Pump_Ratio_Control = 0xF7
        };

        private enum ILI9341_Orientation
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
        public static uint Width { get; } = 240;

        /// <summary>
        /// Default height. Use to overrride the one you'll pass in the screen and add it to the driver.
        /// </summary>
        public static uint Height { get; } = 240;

        /// <summary>
        /// Gets the graphic driver for the Ili9342 display.
        /// </summary>
        public static GraphicDriver GraphicDriver
        {
            get
            {
                if (_driver == null)
                {
                    _driver = new GraphicDriver()
                    {
                        MemoryWrite = (byte)ILI9341_CMD.Memory_Write,
                        SetColumnAddress = (byte)ILI9341_CMD.Column_Address_Set,
                        SetRowAddress = (byte)ILI9341_CMD.Page_Address_Set,
                        InitializationSequence = new byte[]
                        {
                            (byte)GraphicDriverCommandType.Command, 4, (byte)ILI9341_CMD.External_Command, 0xFF, 0x93, 0X42,
                            (byte)GraphicDriverCommandType.Command, 3, (byte)ILI9341_CMD.Power_Control_1, 0x12, 0x12,
                            (byte)GraphicDriverCommandType.Command, 2, (byte)ILI9341_CMD.Power_Control_2, 0x03,
                            (byte)GraphicDriverCommandType.Command, 2, (byte)ILI9341_CMD.VCOM_Control_1, 0xF2,
                            (byte)GraphicDriverCommandType.Command, 2, (byte)ILI9341_CMD.Interface_Signal_Control, 0xE0,
                            (byte)GraphicDriverCommandType.Command, 4, (byte)ILI9341_CMD.Interface_Control, 0x01, 0x00, 0X00,
                            (byte)GraphicDriverCommandType.Command, 2, (byte)ILI9341_CMD.Pixel_Format_Set, 0x55,
                            (byte)GraphicDriverCommandType.Command, 16, (byte)ILI9341_CMD.Positive_Gamma_Correction, 0x00, 0x0C, 0x11, 0x04, 0x11, 0x08, 0x37, 0x89, 0x4C, 0x06, 0x0C, 0x0A, 0x2E, 0x34, 0x0F,
                            (byte)GraphicDriverCommandType.Command, 16, (byte)ILI9341_CMD.Negative_Gamma_Correction, 0x00, 0x0B, 0x11, 0x05, 0x13, 0x09, 0x33, 0x67, 0x48, 0x07, 0x0E, 0x0B, 0x2E, 0x33, 0x0F,
                            (byte)GraphicDriverCommandType.Command, 5, (byte)ILI9341_CMD.Display_Function_Control, 0x08, 0x82, 0x1D, 0x04,
                            (byte)GraphicDriverCommandType.Command, 5, (byte)ILI9341_CMD.Column_Address_Set, 0, 0, (byte)((Height - 1) >> 8), (byte)((Height - 1) & 0xFF),
                            (byte)GraphicDriverCommandType.Command, 5, (byte)ILI9341_CMD.Page_Address_Set, 0, 0, (byte)((Width - 1) >> 8), (byte)((Width- 1) & 0xFF),
                            (byte)GraphicDriverCommandType.Command, 1, (byte)ILI9341_CMD.Memory_Write,
                            (byte)GraphicDriverCommandType.Command, 1, (byte)ILI9341_CMD.Sleep_Out,
                            // Sleep 20 ms
                            (byte)GraphicDriverCommandType.Sleep, 2,
                            (byte)GraphicDriverCommandType.Command, 1, (byte)ILI9341_CMD.Display_ON,
                            // Sleep 200 ms
                            (byte)GraphicDriverCommandType.Sleep, 20,
                            (byte)GraphicDriverCommandType.Command, 1, (byte)ILI9341_CMD.NOP,
                            // Sleep 20 ms
                            (byte)GraphicDriverCommandType.Sleep, 2,
                        },
                        OrientationLandscape = new byte[]
                        {
                            (byte)GraphicDriverCommandType.Command, 2, (byte)ILI9341_CMD.Memory_Access_Control, (byte)(ILI9341_Orientation.MADCTL_ML | ILI9341_Orientation.MADCTL_BGR),
                        },
                        OrientationPortrait = new byte[]
                        {
                            (byte)GraphicDriverCommandType.Command, 2, (byte)ILI9341_CMD.Memory_Access_Control, (byte)(ILI9341_Orientation.MADCTL_MY | ILI9341_Orientation.MADCTL_MX | ILI9341_Orientation.MADCTL_MV | ILI9341_Orientation.MADCTL_BGR),
                        },
                        PowerModeNormal = new byte[]
                        {
                            (byte)GraphicDriverCommandType.Command, 3, (byte)ILI9341_CMD.POWER_STATE, 0x00, 0x00,
                        },
                        PowerModeSleep = new byte[]
                        {
                            (byte)GraphicDriverCommandType.Command, 3, (byte)ILI9341_CMD.POWER_STATE, 0x00, 0x01,
                        },
                        DefaultOrientation = DisplayOrientation.Landscape,
                        Brightness = (byte)ILI9341_CMD.Write_Display_Brightness,
                        SetWindowType = SetWindowType.X16bitsY16Bit,
                    };
                }

                return _driver;
            }
        }
    }
}
