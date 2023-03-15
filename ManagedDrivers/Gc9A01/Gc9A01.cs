//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace nanoFramework.UI.GraphicDrivers
{
    /// <summary>
    /// Managed driver for GC9A01.
    /// </summary>
    public static class Gc9A01
    {
        private static GraphicDriver _driver;

        // Those enums are left like this to match the native side
        private enum GC9A01_CMD
        {
            ReadDisplayInfo = 0x04,
            ReadDisplayStatus = 0x09,
            EnterSleepMode = 0x10,
            SleepOut = 0x11,
            PartialModeOn = 0x12,
            NormalDisplayMode = 0x13,
            DisplayInversionOff = 0x20,
            DisplayInversionOn = 0x21,
            DisplayOff = 0x28,
            DisplayOn = 0x29,
            ColumnAddressSet = 0x2A,
            PageAddressSet = 0x2B,
            MemoryWrite = 0x2C,
            PartialArea = 0x30,
            VerticalScrollingDefinition = 0x33,
            TearingEffectLineOff = 0x34,
            TearingEffectLineOn = 0x34,
            MemoryAccessControl = 0x36,
            VerticalScrollingStartAddress = 0x37,
            IdleModeOff = 0x38,
            IdleModeOn = 0x39,
            PixelFormatSet = 0x3A,
            WriteMemoryContinue = 0x3C,
            SetTearScanline = 0x44,
            GetScanline = 0x45,
            WriteDisplayBrightness = 0x51,
            WriteCtrlDisplay = 0x53,
            ReadId1 = 0xDA,
            ReadId2 = 0xDB,
            ReadId3 = 0xDC,
            RgbInterfaceSignalControl = 0xB0,
            BlankingPorchControl = 0xB5,
            DisplayFunctionControl = 0xB6,
            TeControl = 0xBA,
            InterfaceControl = 0xF6,
            PowerCriterionControl = 0xC1,
            VcoreVoltageControl = 0xA7,
            Vreg1aVoltageControl = 0xC3,
            Vreg2aVoltageControl = 0xC9,
            FrameRate = 0xE8,
            Spi2DataControl = 0xE9,
            ChargePumpFrequentControl = 0xEC,
            InnerRegisterEnable1 = 0xFE,
            InnerRegisterEnable2 = 0xEF,
            SetGamma1 = 0xF0,
            SetGamma2 = 0xF1,
            SetGamma3 = 0xF2,
            SetGamma4 = 0xF3
        };

        private enum GC9A01_PIXEL_FORMAT
        {
            Pixel12Bit = 0x03,
            Pixel16Bit = 0x05,
            Pixel18Bit = 0x06
        };

        private enum GC9A01_MEMORY_ACCESS_CTRL
        {
            Portrait = 0x18,
            Portrait180 = 0x28,
            Landscape = 0x48,
            Landscape180 = 0x88
        };

        /// <summary>
        /// Default weight. Use to overrride the one you'll pass in the screen and add it to the driver.
        /// </summary>
        public static ushort Width { get; } = 240;

        /// <summary>
        /// Default height. Use to overrride the one you'll pass in the screen and add it to the driver.
        /// </summary>
        public static ushort Height { get; } = 240;

        /// <summary>
        /// Gets the graphic driver for the Gc9A01 display.
        /// </summary>
        public static GraphicDriver GraphicDriver
        {
            get
            {
                if (_driver == null)
                {
                    _driver = new GraphicDriver()
                    {
                        MemoryWrite = (byte)GC9A01_CMD.MemoryWrite,
                        SetColumnAddress = (byte)GC9A01_CMD.ColumnAddressSet,
                        SetRowAddress = (byte)GC9A01_CMD.PageAddressSet,
                        BitsPerPixel = 16,
                        InitializationSequence = new byte[]
                        {
                            (byte)GraphicDriverCommandType.Command, 1, (byte)GC9A01_CMD.InnerRegisterEnable2,
                            (byte)GraphicDriverCommandType.Command, 2, 0xEB, 0x14,
                            (byte)GraphicDriverCommandType.Command, 1, (byte)GC9A01_CMD.InnerRegisterEnable1,
                            (byte)GraphicDriverCommandType.Command, 1, (byte)GC9A01_CMD.InnerRegisterEnable2,
                            (byte)GraphicDriverCommandType.Command, 2, 0xEB, 0x14,
                            (byte)GraphicDriverCommandType.Command, 2, 0x84, 0x40,
                            (byte)GraphicDriverCommandType.Command, 2, 0x85, 0xFF,
                            (byte)GraphicDriverCommandType.Command, 2, 0x86, 0xFF,
                            (byte)GraphicDriverCommandType.Command, 2, 0x87, 0xFF,
                            (byte)GraphicDriverCommandType.Command, 2, 0x88, 0x0A,
                            (byte)GraphicDriverCommandType.Command, 2, 0x89, 0x21,
                            (byte)GraphicDriverCommandType.Command, 2, 0x8A, 0x00,
                            (byte)GraphicDriverCommandType.Command, 2, 0x8B, 0x80,
                            (byte)GraphicDriverCommandType.Command, 2, 0x8C, 0x01,
                            (byte)GraphicDriverCommandType.Command, 2, 0x8D, 0x01,
                            (byte)GraphicDriverCommandType.Command, 2, 0x8E, 0xFF,
                            (byte)GraphicDriverCommandType.Command, 2, 0x8F, 0xFF,
                            (byte)GraphicDriverCommandType.Command, 3, (byte)GC9A01_CMD.DisplayFunctionControl, 0x00, 0x20,
                            (byte)GraphicDriverCommandType.Command, 2, (byte)GC9A01_CMD.PixelFormatSet, (byte)GC9A01_PIXEL_FORMAT.Pixel16Bit,
                            (byte)GraphicDriverCommandType.Command, 5, 0x90, 0x08, 0x08, 0x08, 0x08,
                            (byte)GraphicDriverCommandType.Command, 2, 0xBD, 0x06,
                            (byte)GraphicDriverCommandType.Command, 2, 0xBC, 0x00,
                            (byte)GraphicDriverCommandType.Command, 4, 0xFF, 0x60, 0x01, 0x04,
                            (byte)GraphicDriverCommandType.Command, 2, (byte)GC9A01_CMD.Vreg1aVoltageControl, 0x13,
                            (byte)GraphicDriverCommandType.Command, 2, 0xC4, 0x13,
                            (byte)GraphicDriverCommandType.Command, 2, (byte)GC9A01_CMD.Vreg2aVoltageControl, 0x22,
                            (byte)GraphicDriverCommandType.Command, 2, 0xBE, 0x11,
                            (byte)GraphicDriverCommandType.Command, 3, 0xE1, 0x10, 0x0E,
                            (byte)GraphicDriverCommandType.Command, 4, 0xDF, 0x21, 0x0C, 0x02,
                            (byte)GraphicDriverCommandType.Command, 7, 0xF0, 0x45, 0x09, 0x08, 0x08, 0x26, 0x2A,
                            (byte)GraphicDriverCommandType.Command, 7, 0xF1, 0x43, 0x70, 0x72, 0x36, 0x37, 0x6F,
                            (byte)GraphicDriverCommandType.Command, 7, 0xF2, 0x45, 0x09, 0x08, 0x08, 0x26, 0x2A,
                            (byte)GraphicDriverCommandType.Command, 7, 0xF3, 0x43, 0x70, 0x72, 0x36, 0x37, 0x6F,
                            (byte)GraphicDriverCommandType.Command, 3, 0xED, 0x1B, 0x0B,
                            (byte)GraphicDriverCommandType.Command, 2, 0xAE, 0x77,
                            (byte)GraphicDriverCommandType.Command, 2, 0xCD, 0x63,
                            (byte)GraphicDriverCommandType.Command, 10, 0x70, 0x07, 0x07, 0x04, 0x0E, 0x0F, 0x09, 0x07, 0x08, 0x03,
                            (byte)GraphicDriverCommandType.Command, 2, (byte)GC9A01_CMD.FrameRate, 0x34,
                            (byte)GraphicDriverCommandType.Command, 13, 0x62, 0x18, 0x0D, 0x71, 0xED, 0x70, 0x70, 0x18, 0x0F, 0x71, 0xEF, 0x70, 0x70,
                            (byte)GraphicDriverCommandType.Command, 13, 0x63, 0x18, 0x11, 0x71, 0xF1, 0x70, 0x70, 0x18, 0x13, 0x71, 0xF3, 0x70, 0x70,
                            (byte)GraphicDriverCommandType.Command, 8, 0x64, 0x28, 0x29, 0xF1, 0x01, 0xF1, 0x00, 0x07,
                            (byte)GraphicDriverCommandType.Command, 11, 0x66, 0x3C, 0x00, 0xCD, 0x67, 0x45, 0x45, 0x10, 0x00, 0x00, 0x00,
                            (byte)GraphicDriverCommandType.Command, 11, 0x67, 0x00, 0x3C, 0x00, 0x00, 0x00, 0x01, 0x54, 0x10, 0x32, 0x98,
                            (byte)GraphicDriverCommandType.Command, 8, 0x74, 0x10, 0x85, 0x80, 0x00, 0x00, 0x4E, 0x00,
                            (byte)GraphicDriverCommandType.Command, 3, 0x98, 0x3E, 0x07,
                            (byte)GraphicDriverCommandType.Command, 1, 0x35,
                            (byte)GraphicDriverCommandType.Command, 1, (byte)GC9A01_CMD.DisplayInversionOn,
                            (byte)GraphicDriverCommandType.Command, 1, (byte)GC9A01_CMD.SleepOut,
                            // Sleep 120 ms
                            (byte)GraphicDriverCommandType.Sleep, 12,
                            (byte)GraphicDriverCommandType.Command, 1, (byte)GC9A01_CMD.DisplayOn,
                            // Sleep 2 ms
                            (byte)GraphicDriverCommandType.Sleep, 2,
                        },
                        OrientationLandscape = new byte[]
                        {
                            (byte)GraphicDriverCommandType.Command, 2, (byte)GC9A01_CMD.MemoryAccessControl, (byte)GC9A01_MEMORY_ACCESS_CTRL.Landscape,
                        },
                        OrientationLandscape180 = new byte[]
                        {
                            (byte)GraphicDriverCommandType.Command, 2, (byte)GC9A01_CMD.MemoryAccessControl, (byte)GC9A01_MEMORY_ACCESS_CTRL.Landscape180,
                        },
                        OrientationPortrait = new byte[]
                        {
                            (byte)GraphicDriverCommandType.Command, 2, (byte)GC9A01_CMD.MemoryAccessControl, (byte)GC9A01_MEMORY_ACCESS_CTRL.Portrait,
                        },
                        OrientationPortrait180 = new byte[]
                        {
                            (byte)GraphicDriverCommandType.Command, 2, (byte)GC9A01_CMD.MemoryAccessControl, (byte)GC9A01_MEMORY_ACCESS_CTRL.Portrait180,
                        },
                        PowerModeNormal = new byte[]
                        {
                            (byte)GraphicDriverCommandType.Command, 1, (byte)GC9A01_CMD.SleepOut,
                        },
                        PowerModeSleep = new byte[]
                        {
                            (byte)GraphicDriverCommandType.Command, 1, (byte)GC9A01_CMD.EnterSleepMode,
                        },
                        DefaultOrientation = DisplayOrientation.Landscape,
                        Brightness = (byte)GC9A01_CMD.WriteDisplayBrightness,
                        SetWindowType = SetWindowType.X16bitsY16Bit,
                    };
                }

                return _driver;
            }
        }
    }
}
