//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace nanoFramework.UI.GraphicDrivers
{
    /// <summary>
    /// Managed driver for Ili9488.
    /// </summary>
    public static class Ili9488
    {
        private static GraphicDriver _driver;

        // Those enums are left like this to match the native side
        private enum ILI9488_CMD
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
            Inversion_Control = 0xB4,
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
            Set_Image_Function = 0xE9,
            Power_On_Sequence = 0xED,
            Enable_3G = 0xF2,
            Interface_Control = 0xF6,
            Pump_Ratio_Control = 0xF7
        };

        private enum ILI9488_Orientation
        {
            MADCTL_MH = 0x04, // sets the Horizontal Refresh, 0=Left-Right and 1=Right-Left
            MADCTL_ML = 0x10, // sets the Vertical Refresh, 0=Top-Bottom and 1=Bottom-Top
            MADCTL_MV = 0x20, // sets the Row/Column Swap, 0=Normal and 1=Swapped
            MADCTL_MX = 0x40, // sets the Column Order, 0=Left-Right and 1=Right-Left
            MADCTL_MY = 0x80, // sets the Row Order, 0=Top-Bottom and 1=Bottom-Top

            MADCTL_BGR = 0x08, // Blue-Green-Red pixel order
            MADCTL_RGB = 0x00  // Red-Green-Blue pixel order
        };

        /// <summary>
        /// Default width. Use to override the one you'll pass in the screen and add it to the driver.
        /// </summary>
        public static uint Width { get; } = 480;

        /// <summary>
        /// Default height. Use to override the one you'll pass in the screen and add it to the driver.
        /// </summary>
        public static uint Height { get; } = 320;

        /// <summary>
        /// Gets the graphic driver for the Ili9488 display.
        /// </summary>
        public static GraphicDriver GraphicDriver
        {
            get
            {
                if (_driver == null)
                {
                    _driver = new GraphicDriver()
                    {
                        MemoryWrite = (byte)ILI9488_CMD.Memory_Write,
                        SetColumnAddress = (byte)ILI9488_CMD.Column_Address_Set,
                        SetRowAddress = (byte)ILI9488_CMD.Page_Address_Set,
                        InitializationSequence = new byte[]
                        {
                            (byte)GraphicDriverCommandType.Command, 3, (byte)ILI9488_CMD.Power_Control_1, 0x17, 0x15,
                            (byte)GraphicDriverCommandType.Command, 2, (byte)ILI9488_CMD.Power_Control_2, 0x41,
                            (byte)GraphicDriverCommandType.Command, 4, (byte)ILI9488_CMD.VCOM_Control_1,  0x00, 0x12, 0x80,
                            (byte)GraphicDriverCommandType.Command, 2, (byte)ILI9488_CMD.Pixel_Format_Set, 0x66, // 18 bit SPI
                            (byte)GraphicDriverCommandType.Command, 16, (byte)ILI9488_CMD.Positive_Gamma_Correction, 0x00, 0x03, 0x09, 0x08, 0x16, 0x0A, 0x3F, 0x78, 0x4C, 0x09, 0x0A, 0x08, 0x16, 0x1A, 0x0F,
                            (byte)GraphicDriverCommandType.Command, 16, (byte)ILI9488_CMD.Negative_Gamma_Correction, 0x00, 0x16, 0x19, 0x03, 0x0F, 0x05, 0x32, 0x45, 0x46, 0x04, 0x0E, 0x0D, 0x35, 0x37, 0x0F,
                            (byte)GraphicDriverCommandType.Command, 2, (byte)ILI9488_CMD.Interface_Signal_Control, 0x80,
                            (byte)GraphicDriverCommandType.Command, 2, (byte)ILI9488_CMD.Frame_Rate_Control_Normal, 0xA0,
                            (byte)GraphicDriverCommandType.Command, 2, (byte)ILI9488_CMD.Inversion_Control, 0x02,
                            (byte)GraphicDriverCommandType.Command, 4, (byte)ILI9488_CMD.Display_Function_Control, 0x02, 0x02, 0x3B,
                            (byte)GraphicDriverCommandType.Command, 2, (byte)ILI9488_CMD.Set_Image_Function, 0x00,
                            (byte)GraphicDriverCommandType.Command, 5, (byte)ILI9488_CMD.Pump_Ratio_Control, 0xA9, 0x51, 0x2C, 0x82,
                            (byte)GraphicDriverCommandType.Command, 1, (byte)ILI9488_CMD.Sleep_Out,
                            (byte)GraphicDriverCommandType.Sleep, 12, // Sleep 120 ms
                            (byte)GraphicDriverCommandType.Command, 1, (byte)ILI9488_CMD.Display_ON,
                            (byte)GraphicDriverCommandType.Sleep, 20, // Sleep 200 ms
                            (byte)GraphicDriverCommandType.Command, 1, (byte)ILI9488_CMD.NOP,
                            (byte)GraphicDriverCommandType.Sleep, 2 // Sleep 20 ms
                        },
                        OrientationLandscape = new byte[]
                        {
                            (byte)GraphicDriverCommandType.Command, 2, (byte)ILI9488_CMD.Memory_Access_Control,
                                (byte)(
                                    ILI9488_Orientation.MADCTL_MX |
                                    ILI9488_Orientation.MADCTL_MY |
                                    ILI9488_Orientation.MADCTL_MV |
                                    ILI9488_Orientation.MADCTL_RGB
                                ),
                        },
                        OrientationLandscape180 = new byte[]
                        {
                            (byte)GraphicDriverCommandType.Command, 2, (byte)ILI9488_CMD.Memory_Access_Control,
                                (byte)(
                                    ILI9488_Orientation.MADCTL_MV |
                                    ILI9488_Orientation.MADCTL_RGB
                                ),
                        },
                        OrientationPortrait = new byte[]
                        {
                            (byte)GraphicDriverCommandType.Command, 2, (byte)ILI9488_CMD.Memory_Access_Control,
                                (byte)(
                                    ILI9488_Orientation.MADCTL_MX |
                                    ILI9488_Orientation.MADCTL_RGB
                                ),
                        },
                        OrientationPortrait180 = new byte[]
                        {
                            (byte)GraphicDriverCommandType.Command, 2, (byte)ILI9488_CMD.Memory_Access_Control,
                                (byte)(
                                    ILI9488_Orientation.MADCTL_MY |
                                    ILI9488_Orientation.MADCTL_RGB
                                ),
                        },
                        PowerModeNormal = new byte[]
                        {
                            (byte)GraphicDriverCommandType.Command, 3, (byte)ILI9488_CMD.POWER_STATE, 0x00, 0x00,
                        },
                        PowerModeSleep = new byte[]
                        {
                            (byte)GraphicDriverCommandType.Command, 3, (byte)ILI9488_CMD.POWER_STATE, 0x00, 0x01,
                        },
                        DefaultOrientation = DisplayOrientation.Landscape,
                        Brightness = (byte)ILI9488_CMD.Write_Display_Brightness,
                        SetWindowType = SetWindowType.X16bitsY16Bit,
                        BitsPerPixel = 18
                    };
                }

                return _driver;
            }
        }
    }
}
