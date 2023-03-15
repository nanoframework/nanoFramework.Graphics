//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace nanoFramework.UI.GraphicDrivers
{
    /// <summary>
    /// Managed driver for Otm8009A.
    /// </summary>
    public static class Otm8009A
    {
        private static GraphicDriver _driver;

        // Those enums are left like this to match the native side
        private const byte COLMOD_RGB565 = 0x55; // COLMOD  pixel format
        private const byte OTM8009A_CMD_SLPOUT = 0x11; // Sleep Out command
        private const byte OTM8009A_CMD_DISPON = 0x29; // Display On command
        private const byte OTM8009A_CMD_RAMWR = 0x2C; // Memory (GRAM) write command
        private const byte OTM8009A_CMD_RAMRD = 0x2E; // Memory (GRAM) read command
        private const byte OTM8009A_CMD_WRTESCN = 0x44; // Write Tearing Effect Scan line command
        private const byte OTM8009A_CMD_WRCTRLD = 0x53; // Write CTRL Display command
        private const byte OTM8009A_CMD_WRCABC = 0x55; // Write Content Adaptive Brightness command
        private const byte OTM8009A_CMD_WRCABCMB = 0x5E; // Write CABC Minimum Brightness command
        private const byte OTM8009A_CMD_WRDISBV = 0x51; // Write Display Brightness command

        private const byte COLMOD = 0x3A;// Interface Pixel format command  (12/16/18/24 bits per pixel)
        private const byte CASET = 0x2A;// Column address set command (used to define area of frame memory where MCU can access)
        private const byte PASET = 0x2B;// Page address set command (used to define area of frame memory where MCU can access)
        private const byte MADCTR = 0x36;// Memory Access control  (defines read/ write scanning direction of frame memory)

        private const byte Register0xFF = 0xFF;
        private const byte Register0x00 = 0x00;

        /// <summary>
        /// Default weight. Use to overrride the one you'll pass in the screen and add it to the driver.
        /// </summary>
        public static ushort Width { get; } = 800;

        /// <summary>
        /// Default height. Use to overrride the one you'll pass in the screen and add it to the driver.
        /// </summary>
        public static ushort Height { get; } = 480;

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
                        Width= Width,
                        Height= Height,
                        InitializationSequence = new byte[]
                        {
                            (byte)GraphicDriverCommandType.Command, 2, 0x00, 0x00,
                            (byte)GraphicDriverCommandType.Command, 4, Register0xFF, 0x80, 0x09, 0x01,
                            (byte)GraphicDriverCommandType.Command, 2, 0x00, 0x00,
                            (byte)GraphicDriverCommandType.Command, 2, Register0x00, 0x80,
                            (byte)GraphicDriverCommandType.Command, 3, Register0xFF, 0x80, 0x09,
                            (byte)GraphicDriverCommandType.Command, 2, 0x00, 0x80,
                            (byte)GraphicDriverCommandType.Command, 2, 0xC4, 0x30,
                            // Sleep 10 ms
                            (byte)GraphicDriverCommandType.Sleep, 1,
                            (byte)GraphicDriverCommandType.Command, 2, 0x00, 0x8A,
                            (byte)GraphicDriverCommandType.Command, 2, 0xC4, 0x4,
                            // Sleep 10 ms
                            (byte)GraphicDriverCommandType.Sleep, 1,
                            (byte)GraphicDriverCommandType.Command, 2, 0x00, 0xB1,
                            (byte)GraphicDriverCommandType.Command, 2, 0xC5, 0xA9,
                            (byte)GraphicDriverCommandType.Command, 2, 0x00, 0x91,
                            (byte)GraphicDriverCommandType.Command, 2, 0xC5, 0x34,
                            (byte)GraphicDriverCommandType.Command, 2, 0x00, 0xB4,
                            (byte)GraphicDriverCommandType.Command, 2, 0xC0, 0x50,
                            (byte)GraphicDriverCommandType.Command, 2, 0x00, 0x00,
                            (byte)GraphicDriverCommandType.Command, 2, 0xD9, 0x4E,
                            (byte)GraphicDriverCommandType.Command, 2, 0x00, 0x81,
                            (byte)GraphicDriverCommandType.Command, 2, 0xC1, 0x66,
                            (byte)GraphicDriverCommandType.Command, 2, 0x00, 0xA1,
                            (byte)GraphicDriverCommandType.Command, 2, 0xC1, 0x08,
                            (byte)GraphicDriverCommandType.Command, 2, 0x00, 0x92,
                            (byte)GraphicDriverCommandType.Command, 2, 0xC5, 0x01,
                            (byte)GraphicDriverCommandType.Command, 2, 0x00, 0x95,
                            (byte)GraphicDriverCommandType.Command, 2, 0xC5, 0x34,
                            (byte)GraphicDriverCommandType.Command, 2, 0x00, 0x00,
                            (byte)GraphicDriverCommandType.Command, 3, 0xD8, 0x79, 0x79,
                            (byte)GraphicDriverCommandType.Command, 2, 0x00, 0x94,
                            (byte)GraphicDriverCommandType.Command, 2, 0xC5, 0x33,
                            (byte)GraphicDriverCommandType.Command, 2, 0x00, 0xA3,
                            (byte)GraphicDriverCommandType.Command, 2, 0xC0, 0x1B,
                            (byte)GraphicDriverCommandType.Command, 2, 0x00, 0x82,
                            (byte)GraphicDriverCommandType.Command, 2, 0xC5, 0x83,
                            (byte)GraphicDriverCommandType.Command, 2, 0x00, 0x81,
                            (byte)GraphicDriverCommandType.Command, 2, 0xC4, 0x83,
                            (byte)GraphicDriverCommandType.Command, 2, 0x00, 0xA1,
                            (byte)GraphicDriverCommandType.Command, 2, 0xC1, 0x0E,
                            (byte)GraphicDriverCommandType.Command, 2, 0x00, 0xA6,
                            (byte)GraphicDriverCommandType.Command, 2, 0x00, 0x80,
                            (byte)GraphicDriverCommandType.Command, 7, 0xCE, 0x85, 0x01, 0x00, 0x84, 0x01, 0x00,
                            (byte)GraphicDriverCommandType.Command, 2, 0x00, 0xA0,
                            (byte)GraphicDriverCommandType.Command, 15, 0xCE, 0x18, 0x04, 0x03, 0x39, 0x00, 0x00, 0x00, 0x18, 0x03, 0x03, 0x3A, 0x00, 0x00, 0x00,
                            (byte)GraphicDriverCommandType.Command, 2, 0x00, 0xB0,
                            (byte)GraphicDriverCommandType.Command, 15, 0xCE, 0x18, 0x02, 0x03, 0x3B, 0x00, 0x00, 0x00, 0x18, 0x01, 0x03, 0x3C, 0x00, 0x00, 0x00,
                            (byte)GraphicDriverCommandType.Command, 2, 0x00, 0xC0,
                            (byte)GraphicDriverCommandType.Command, 11, 0xCF, 0x01, 0x01, 0x20, 0x20, 0x00, 0x00, 0x01, 0x02, 0x00, 0x00,
                            (byte)GraphicDriverCommandType.Command, 2, 0x00, 0xD0,
                            (byte)GraphicDriverCommandType.Command, 2, 0xCF, 0x00,
                            (byte)GraphicDriverCommandType.Command, 2, 0x00, 0x80,
                            (byte)GraphicDriverCommandType.Command, 11, 0xCB, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                            (byte)GraphicDriverCommandType.Command, 2, 0x00, 0x90,
                            (byte)GraphicDriverCommandType.Command, 16, 0xCB, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                            (byte)GraphicDriverCommandType.Command, 2, 0x00, 0xA0,
                            (byte)GraphicDriverCommandType.Command, 16, 0xCB, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                            (byte)GraphicDriverCommandType.Command, 2, 0x00, 0xB0,
                            (byte)GraphicDriverCommandType.Command, 11, 0xCB, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                            (byte)GraphicDriverCommandType.Command, 2, 0x00, 0xC0,
                            (byte)GraphicDriverCommandType.Command, 16, 0xCB, 0x00, 0x04, 0x04, 0x04, 0x04, 0x04, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0,
                            (byte)GraphicDriverCommandType.Command, 2, 0x00, 0xD0,
                            (byte)GraphicDriverCommandType.Command, 16, 0xCB, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x04, 0x04, 0x04, 0x04, 0x04, 0x00, 0x00, 0x00, 0x00,
                            (byte)GraphicDriverCommandType.Command, 2, 0x00, 0xE0,
                            (byte)GraphicDriverCommandType.Command, 11, 0xCB, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
                            (byte)GraphicDriverCommandType.Command, 2, 0x00, 0xF0,
                            (byte)GraphicDriverCommandType.Command, 11, 0xCB, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
                            (byte)GraphicDriverCommandType.Command, 2, 0x00, 0x80,
                            (byte)GraphicDriverCommandType.Command, 11, 0xCC, 0x00, 0x26, 0x09, 0x0B, 0x01, 0x25, 0x00, 0x00, 0x00, 0x00,
                            (byte)GraphicDriverCommandType.Command, 2, 0x00, 0x90,
                            (byte)GraphicDriverCommandType.Command, 16, 0xCC, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x26, 0x0A, 0x0C, 0x02, 
                            (byte)GraphicDriverCommandType.Command, 2, 0x00, 0xA0,
                            (byte)GraphicDriverCommandType.Command, 16, 0xCC, 0x25, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                            (byte)GraphicDriverCommandType.Command, 2, 0x00, 0xB0,
                            (byte)GraphicDriverCommandType.Command, 11, 0xCC, 0x00, 0x25, 0x0C, 0x0A, 0x02, 0x26, 0x00, 0x00, 0x00, 0x00, 
                            (byte)GraphicDriverCommandType.Command, 2, 0x00, 0xC0,
                            (byte)GraphicDriverCommandType.Command, 16, 0xCC, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x25, 0x0B, 0x09, 0x01,
                            (byte)GraphicDriverCommandType.Command, 2, 0x00, 0xD0,
                            (byte)GraphicDriverCommandType.Command, 16, 0xCC, 0x26, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                            (byte)GraphicDriverCommandType.Command, 2, 0x00, 0x81,
                            (byte)GraphicDriverCommandType.Command, 2, 0xC5, 0x66,
                            (byte)GraphicDriverCommandType.Command, 2, 0x00, 0xB6,
                            (byte)GraphicDriverCommandType.Command, 2, 0xF5, 0x06,
                            (byte)GraphicDriverCommandType.Command, 2, 0x00, 0xB1,
                            (byte)GraphicDriverCommandType.Command, 2, 0xC6, 0x06,
                            (byte)GraphicDriverCommandType.Command, 2, 0x00, 0x00,
                            (byte)GraphicDriverCommandType.Command, 4, 0xFF, 0xFF, 0xFF, 0xFF,
                            (byte)GraphicDriverCommandType.Command, 2, 0x00, 0x00,
                            (byte)GraphicDriverCommandType.Command, 2, 0x00, 0x00,
                            (byte)GraphicDriverCommandType.Command, 17, 0xE1, 0x00, 0x09, 0x0F, 0x0E, 0x07, 0x10, 0x0B, 0x0A, 0x04, 0x07, 0x0B, 0x08, 0x0F, 0x10, 0x0A, 0x01,
                            (byte)GraphicDriverCommandType.Command, 2, 0x00, 0x00,
                            (byte)GraphicDriverCommandType.Command, 17, 0xE2, 0x00, 0x09, 0x0F, 0x0E, 0x07, 0x10, 0x0B, 0x0A, 0x04, 0x07, 0x0B, 0x08, 0x0F, 0x10, 0x0A, 0x01, 
                            (byte)GraphicDriverCommandType.Command, 2, OTM8009A_CMD_SLPOUT, 0x00,
                            // Sleep 120 ms
                            (byte)GraphicDriverCommandType.Sleep, 12,
                            (byte)GraphicDriverCommandType.Command, 2, COLMOD, COLMOD_RGB565,
                            (byte)GraphicDriverCommandType.Command, 2, OTM8009A_CMD_WRDISBV, 0x7F,
                            (byte)GraphicDriverCommandType.Command, 2, OTM8009A_CMD_WRCTRLD, 0x2C,
                            (byte)GraphicDriverCommandType.Command, 2, OTM8009A_CMD_WRCABC, 0x02,
                            (byte)GraphicDriverCommandType.Command, 2, OTM8009A_CMD_WRCABCMB, 0xFF,
                            (byte)GraphicDriverCommandType.Command, 2, OTM8009A_CMD_DISPON, 0x00,
                            (byte)GraphicDriverCommandType.Command, 2, 0x00, 0x00,
                            (byte)GraphicDriverCommandType.Command, 2, OTM8009A_CMD_RAMWR, 0x00,
                            (byte)GraphicDriverCommandType.Command, 2, MADCTR, 0x60,
                            (byte)GraphicDriverCommandType.Command, 5, CASET, 0x00, 0x00, (byte)((Width - 1) >> 8), (byte)((Width - 1) & 0xff),
                            (byte)GraphicDriverCommandType.Command, 5, PASET, 0x00, 0x00, (byte)((Height - 1) >> 8), (byte)((Height - 1) & 0xff),
                        },
                        OrientationLandscape = new byte[]
                        {
                            (byte)GraphicDriverCommandType.Command, 2, 2, MADCTR, 0x60,
                        },
                        DefaultOrientation = DisplayOrientation.Landscape,
                        Brightness = OTM8009A_CMD_WRCABCMB,
                        SetWindowType = SetWindowType.NoWindowing,
                    };
                }

                return _driver;
            }
        }
    }
}
