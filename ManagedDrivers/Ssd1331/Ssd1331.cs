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
        private enum SSD1331_CMD
        {
            Set_Column_Address = 0x15,
            Set_Row_Address = 0x75,

            Set_Contrast_A = 0x81,
            Set_Contrast_B = 0x82,
            Set_Contrast_C = 0x83,

            Master_Current_Control = 0x87,

            Set_Second_Pre_charge_Speed_A = 0x8A,
            Set_Second_Pre_charge_Speed_B = 0x8B,
            Set_Second_Pre_charge_Speed_C = 0x8C,

            Remap_and_Colour_Depth_setting = 0xA0,

            Set_Display_Start_Line = 0xA1,
            Set_Display_Offset = 0xA2,
            Set_Display_Mode_Normal = 0xA4,
            Set_Display_Mode_Entire_On = 0xA5,
            Set_Display_Mode_Entire_Off = 0xA6,
            Set_Display_Mode_Inverse = 0xA7,

            Set_Multiplex_Ratio = 0xA8,
            Dim_Mode_Setting = 0xAB,
            Set_Master_Configuration = 0xAD,
            Set_Display_On_Dim = 0xAC,
            Set_Display_Off_Sleep = 0xAE,
            Set_Display_On_Normal = 0xAF,
            Power_Save_Mode = 0xB0,
            Phase1_2_Period = 0xB1,
            Display_Clock_Divider = 0xB3,
            Set_Gray_Scale_Table = 0xB8,
            Enable_Linear_Gray_Scale_Table = 0xB9,
            Set_Pre_Charge_Level = 0xBB,
            Set_Vcomh = 0xBE,
            Set_Command_Lock = 0xFD,

            Draw_Line = 0x21,
            Draw_Rectangle = 0x22,
            Copy = 0x23,
            Dim_Window = 0x24,
            Clear_Window = 0x25,
            Fill_Enable_Disable = 0x26,
            Scrolling_Setup = 0x27,
            Deactivate_Scolling = 0x2E,
            Activate_Scrolling = 0x2F
        };

        [Flags]
        private enum SSD1331_Orientation
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
        public static ushort Width { get; } = 94;

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
                        SetColumnAddress = (byte)SSD1331_CMD.Set_Column_Address,
                        SetRowAddress = (byte)SSD1331_CMD.Set_Row_Address,
                        InitializationSequence = new byte[]
                        {
                            (byte)GraphicDriverCommandType.Command, 1, (byte)SSD1331_CMD.Set_Display_Off_Sleep,
                            // Thos next 2 lines are supposed to set the orientation but it is not correct a priori.
                            (byte)GraphicDriverCommandType.Command, 1, (byte)SSD1331_CMD.Remap_and_Colour_Depth_setting,
                            (byte)GraphicDriverCommandType.Command, 1, 0x40 | 0x72,
                            (byte)GraphicDriverCommandType.Command, 2, (byte)SSD1331_CMD.Set_Display_Start_Line, 0x00,
                            (byte)GraphicDriverCommandType.Command, 2, (byte)SSD1331_CMD.Set_Display_Offset, 0x00,
                            (byte)GraphicDriverCommandType.Command, 1, (byte)SSD1331_CMD.Set_Display_Mode_Normal,
                            (byte)GraphicDriverCommandType.Command, 2, (byte)SSD1331_CMD.Set_Multiplex_Ratio, 0x3F,
                            (byte)GraphicDriverCommandType.Command, 2, (byte)SSD1331_CMD.Set_Master_Configuration, 0x8E,
                            (byte)GraphicDriverCommandType.Command, 2, (byte)SSD1331_CMD.Power_Save_Mode, 0x0B,
                            (byte)GraphicDriverCommandType.Command, 2, (byte)SSD1331_CMD.Phase1_2_Period, 0x31,
                            (byte)GraphicDriverCommandType.Command, 2, (byte)SSD1331_CMD.Display_Clock_Divider, 0xF0,
                            (byte)GraphicDriverCommandType.Command, 2, (byte)SSD1331_CMD.Set_Second_Pre_charge_Speed_A, 0x64,
                            (byte)GraphicDriverCommandType.Command, 2, (byte)SSD1331_CMD.Set_Second_Pre_charge_Speed_B, 0x78,
                            (byte)GraphicDriverCommandType.Command, 2, (byte)SSD1331_CMD.Set_Second_Pre_charge_Speed_C, 0x64,
                            (byte)GraphicDriverCommandType.Command, 2, (byte)SSD1331_CMD.Set_Pre_Charge_Level, 0x3A,
                            (byte)GraphicDriverCommandType.Command, 2, (byte)SSD1331_CMD.Set_Vcomh, 0x3E,
                            (byte)GraphicDriverCommandType.Command, 2, (byte)SSD1331_CMD.Master_Current_Control, 0x06,
                            (byte)GraphicDriverCommandType.Command, 2, (byte)SSD1331_CMD.Set_Contrast_A, 0x91,
                            (byte)GraphicDriverCommandType.Command, 2, (byte)SSD1331_CMD.Set_Contrast_B, 0x50,
                            (byte)GraphicDriverCommandType.Command, 2, (byte)SSD1331_CMD.Set_Contrast_C, 0x7D,
                            (byte)GraphicDriverCommandType.Command,1, (byte)SSD1331_CMD.Set_Display_On_Normal ,
                            // Sleep for 50 ms
                            (byte)GraphicDriverCommandType.Sleep, 5,
                        },
                        OrientationLandscape = new byte[]
                        {
                            (byte)GraphicDriverCommandType.Command, 1, (byte)SSD1331_CMD.Remap_and_Colour_Depth_setting,
                            (byte)GraphicDriverCommandType.Command, 1, 0x40 | 0x72,
                        },
                        OrientationLandscape180 = new byte[]
                        {
                            (byte)GraphicDriverCommandType.Command, 1, (byte)SSD1331_CMD.Remap_and_Colour_Depth_setting,
                            (byte)GraphicDriverCommandType.Command, 1, 0x40 | 0x70,
                        },
                        PowerModeNormal = new byte[]
                        {
                            (byte)GraphicDriverCommandType.Command, 1, (byte)SSD1331_CMD.Power_Save_Mode,
                            (byte)GraphicDriverCommandType.Command, 1, 0x0B,
                        },
                        PowerModeSleep = new byte[]
                        {
                            (byte)GraphicDriverCommandType.Command, 1, (byte)SSD1331_CMD.Power_Save_Mode,
                            (byte)GraphicDriverCommandType.Command, 1, 0x1A,
                        },
                        DefaultOrientation = DisplayOrientation.Landscape,
                        SetWindowType = SetWindowType.X8bitsY8Bits,
                    };
                }

                return _driver;
            }
        }
    }
}
