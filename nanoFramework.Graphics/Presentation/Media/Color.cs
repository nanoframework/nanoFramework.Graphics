//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace nanoFramework.Presentation.Media
{
    /// <summary>
    /// 
    /// </summary>
    public static class ColorUtility
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Color ColorFromRGB(byte r, byte g, byte b)
        {
            return (Color)((b << 16) | (g << 8) | r);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static byte GetRValue(Color color)
        {
            return (byte)((uint)color & 0xff);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static byte GetGValue(Color color)
        {
            return (byte)(((uint)color >> 8) & 0xff);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static byte GetBValue(Color color)
        {
            return (byte)(((uint)color >> 16) & 0xff);
        }

        /// <summary>
        /// Converts color into a 16bit representation.
        /// </summary>
        /// <param name="color">A color.</param>
        /// <returns>a 16 bit encoded representation.</returns>
        public static ushort To16Bpp(Color color)
        {
            // 16 bit colour  RRRRRGGGGGGBBBBB mode 565
            return (ushort)((((uint)color & 0xFF0000) >> 19) | ((((uint)color & 0x00FF00) >> 10) << 5) | (((uint)color & 0xFF) >> 3) << 11);
        }
    }

    /// <summary>
    ///  Note: Colors are not RGB 24-bit but are BGR 24-bit
    /// </summary>
    public enum Color : uint
    {
        /// <summary>
        ///
        /// </summary>
        AliceBlue = 0xFFF8F0,
        /// <summary>
        ///
        /// </summary>
        AntiqueWhite = 0xD7EBFA,
        /// <summary>
        ///
        /// </summary>
        Aqua = 0xFFFF00,
        /// <summary>
        ///
        /// </summary>
        Aquamarine = 0xD4FF7F,
        /// <summary>
        ///
        /// </summary>
        Azure = 0xFFFFF0,
        /// <summary>
        ///
        /// </summary>
        Beige = 0xDCF5F5,
        /// <summary>
        ///
        /// </summary>
        Bisque = 0xC4E4FF,
        /// <summary>
        ///
        /// </summary>
        Black = 0x000000,
        /// <summary>
        ///
        /// </summary>
        BlanchedAlmond = 0xCDEBFF,
        /// <summary>
        ///
        /// </summary>
        Blue = 0xFF0000,
        /// <summary>
        ///
        /// </summary>
        BlueViolet = 0xE22B8A,
        /// <summary>
        ///
        /// </summary>
        Brown = 0x2A2AA5,
        /// <summary>
        ///
        /// </summary>
        BurlyWood = 0x87B8DE,
        /// <summary>
        ///
        /// </summary>
        CadetBlue = 0xA09E5F,
        /// <summary>
        ///
        /// </summary>
        Chartreuse = 0x00FF7F,
        /// <summary>
        ///
        /// </summary>
        Chocolate = 0x1E69D2,
        /// <summary>
        ///
        /// </summary>
        Coral = 0x507FFF,
        /// <summary>
        ///
        /// </summary>
        CornflowerBlue = 0xED9564,
        /// <summary>
        ///
        /// </summary>
        Cornsilk = 0xDCF8FF,
        /// <summary>
        ///
        /// </summary>
        Crimson = 0x3C14DC,
        /// <summary>
        ///
        /// </summary>
        Cyan = 0xFFFF00,
        /// <summary>
        ///
        /// </summary>
        DarkBlue = 0x8B0000,
        /// <summary>
        ///
        /// </summary>
        DarkCyan = 0x8B8B00,
        /// <summary>
        ///
        /// </summary>
        DarkGoldenrod = 0x0B86B8,
        /// <summary>
        ///
        /// </summary>
        DarkGray = 0xA9A9A9,
        /// <summary>
        ///
        /// </summary>
        DarkGreen = 0x006400,
        /// <summary>
        ///
        /// </summary>
        DarkKhaki = 0x6BB7BD,
        /// <summary>
        ///
        /// </summary>
        DarkMagenta = 0x8B008B,
        /// <summary>
        ///
        /// </summary>
        DarkOliveGreen = 0x2F6B55,
        /// <summary>
        ///
        /// </summary>
        DarkOrange = 0x008CFF,
        /// <summary>
        ///
        /// </summary>
        DarkOrchid = 0xCC3299,
        /// <summary>
        ///
        /// </summary>
        DarkRed = 0x00008B,
        /// <summary>
        ///
        /// </summary>
        DarkSalmon = 0x7A96E9,
        /// <summary>
        ///
        /// </summary>
        DarkSeaGreen = 0x8FBC8F,
        /// <summary>
        ///
        /// </summary>
        DarkSlateBlue = 0x8B3D48,
        /// <summary>
        ///
        /// </summary>
        DarkSlateGray = 0x4F4F2F,
        /// <summary>
        ///
        /// </summary>
        DarkTurquoise = 0xD1CE00,
        /// <summary>
        ///
        /// </summary>
        DarkViolet = 0xD30094,
        /// <summary>
        ///
        /// </summary>
        DeepPink = 0x9314FF,
        /// <summary>
        ///
        /// </summary>
        DeepSkyBlue = 0xFFBF00,
        /// <summary>
        ///
        /// </summary>
        DimGray = 0x696969,
        /// <summary>
        ///
        /// </summary>
        DodgerBlue = 0xFF901E,
        /// <summary>
        ///
        /// </summary>
        Firebrick = 0x2222B2,
        /// <summary>
        ///
        /// </summary>
        FloralWhite = 0xF0FAFF,
        /// <summary>
        ///
        /// </summary>
        ForestGreen = 0x228B22,
        /// <summary>
        ///
        /// </summary>
        Gainsboro = 0xDCDCDC,
        /// <summary>
        ///
        /// </summary>
        GhostWhite = 0xFFF8F8,
        /// <summary>
        ///
        /// </summary>
        Gold = 0x00D7FF,
        /// <summary>
        ///
        /// </summary>
        Goldenrod = 0x20A5DA,
        /// <summary>
        ///
        /// </summary>
        Gray = 0x808080,
        /// <summary>
        ///
        /// </summary>
        Green = 0x008000,
        /// <summary>
        ///
        /// </summary>
        GreenYellow = 0x2FFFAD,
        /// <summary>
        ///
        /// </summary>
        Honeydew = 0xF0FFF0,
        /// <summary>
        ///
        /// </summary>
        HotPink = 0xB469FF,
        /// <summary>
        ///
        /// </summary>
        IndianRed = 0x5C5CCD,
        /// <summary>
        ///
        /// </summary>
        Indigo = 0x82004B,
        /// <summary>
        ///
        /// </summary>
        Ivory = 0xF0FFFF,
        /// <summary>
        ///
        /// </summary>
        Khaki = 0x8CE6F0,
        /// <summary>
        ///
        /// </summary>
        Lavender = 0xFAE6E6,
        /// <summary>
        ///
        /// </summary>
        LavenderBlush = 0xF5F0FF,
        /// <summary>
        ///
        /// </summary>
        LawnGreen = 0x00FC7C,
        /// <summary>
        ///
        /// </summary>
        LemonChiffon = 0xCDFAFF,
        /// <summary>
        ///
        /// </summary>
        LightBlue = 0xE6D8AD,
        /// <summary>
        ///
        /// </summary>
        LightCoral = 0x8080F0,
        /// <summary>
        ///
        /// </summary>
        LightCyan = 0xFFFFE0,
        /// <summary>
        ///
        /// </summary>
        LightGoldenrodYellow = 0xD2FAFA,
        /// <summary>
        ///
        /// </summary>
        LightGray = 0xD3D3D3,
        /// <summary>
        ///
        /// </summary>
        LightGreen = 0x90EE90,
        /// <summary>
        ///
        /// </summary>
        LightPink = 0xC1B6FF,
        /// <summary>
        ///
        /// </summary>
        LightSalmon = 0x7AA0FF,
        /// <summary>
        ///
        /// </summary>
        LightSeaGreen = 0xAAB220,
        /// <summary>
        ///
        /// </summary>
        LightSkyBlue = 0xFACE87,
        /// <summary>
        ///
        /// </summary>
        LightSlateGray = 0x998877,
        /// <summary>
        ///
        /// </summary>
        LightSteelBlue = 0xDEC4B0,
        /// <summary>
        ///
        /// </summary>
        LightYellow = 0xE0FFFF,
        /// <summary>
        ///
        /// </summary>
        Lime = 0x00FF00,
        /// <summary>
        ///
        /// </summary>
        LimeGreen = 0x32CD32,
        /// <summary>
        ///
        /// </summary>
        Linen = 0xE6F0FA,
        /// <summary>
        ///
        /// </summary>
        Magenta = 0xFF00FF,
        /// <summary>
        ///
        /// </summary>
        Maroon = 0x000080,
        /// <summary>
        ///
        /// </summary>
        MediumAquamarine = 0xAACD66,
        /// <summary>
        ///
        /// </summary>
        MediumBlue = 0xCD0000,
        /// <summary>
        ///
        /// </summary>
        MediumOrchid = 0xD355BA,
        /// <summary>
        ///
        /// </summary>
        MediumPurple = 0xDB7093,
        /// <summary>
        ///
        /// </summary>
        MediumSeaGreen = 0x71B33C,
        /// <summary>
        ///
        /// </summary>
        MediumSlateBlue = 0xEE687B,
        /// <summary>
        ///
        /// </summary>
        MediumSpringGreen = 0x9AFA00,
        /// <summary>
        ///
        /// </summary>
        MediumTurquoise = 0xCCD148,
        /// <summary>
        ///
        /// </summary>
        MediumVioletRed = 0x8515C7,
        /// <summary>
        ///
        /// </summary>
        MidnightBlue = 0x701919,
        /// <summary>
        ///
        /// </summary>
        MintCream = 0xFAFFF5,
        /// <summary>
        ///
        /// </summary>
        MistyRose = 0xE1E4FF,
        /// <summary>
        ///
        /// </summary>
        Moccasin = 0xB5E4FF,
        /// <summary>
        ///
        /// </summary>
        NavajoWhite = 0xADDEFF,
        /// <summary>
        ///
        /// </summary>
        Navy = 0x800000,
        /// <summary>
        ///
        /// </summary>
        OldLace = 0xE6F5FD,
        /// <summary>
        ///
        /// </summary>
        Olive = 0x008080,
        /// <summary>
        ///
        /// </summary>
        OliveDrab = 0x238E6B,
        /// <summary>
        ///
        /// </summary>
        Orange = 0x00A5FF,
        /// <summary>
        ///
        /// </summary>
        OrangeRed = 0x0045FF,
        /// <summary>
        ///
        /// </summary>
        Orchid = 0xD670DA,
        /// <summary>
        ///
        /// </summary>
        PaleGoldenrod = 0xAAE8EE,
        /// <summary>
        ///
        /// </summary>
        PaleGreen = 0x98FB98,
        /// <summary>
        ///
        /// </summary>
        PaleTurquoise = 0xEEEEAF,
        /// <summary>
        ///
        /// </summary>
        PaleVioletRed = 0x9370DB,
        /// <summary>
        ///
        /// </summary>
        PapayaWhip = 0xD5EFFF,
        /// <summary>
        ///
        /// </summary>
        PeachPuff = 0xB9DAFF,
        /// <summary>
        ///
        /// </summary>
        Peru = 0x3F85CD,
        /// <summary>
        ///
        /// </summary>
        Pink = 0xCBC0FF,
        /// <summary>
        ///
        /// </summary>
        Plum = 0xDDA0DD,
        /// <summary>
        ///
        /// </summary>
        PowderBlue = 0xE6E0B0,
        /// <summary>
        ///
        /// </summary>
        Purple = 0x800080,
        /// <summary>
        ///
        /// </summary>
        Red = 0x0000FF,
        /// <summary>
        ///
        /// </summary>
        RosyBrown = 0x8F8FBC,
        /// <summary>
        ///
        /// </summary>
        RoyalBlue = 0xE16941,
        /// <summary>
        ///
        /// </summary>
        SaddleBrown = 0x13458B,
        /// <summary>
        ///
        /// </summary>
        Salmon = 0x7280FA,
        /// <summary>
        ///
        /// </summary>
        SandyBrown = 0x60A4F4,
        /// <summary>
        ///
        /// </summary>
        SeaGreen = 0x578B2E,
        /// <summary>
        ///
        /// </summary>
        SeaShell = 0xEEF5FF,
        /// <summary>
        ///
        /// </summary>
        Sienna = 0x2D52A0,
        /// <summary>
        ///
        /// </summary>
        Silver = 0xC0C0C0,
        /// <summary>
        ///
        /// </summary>
        SkyBlue = 0xEBCE87,
        /// <summary>
        ///
        /// </summary>
        SlateBlue = 0xCD5A6A,
        /// <summary>
        ///
        /// </summary>
        SlateGray = 0x908070,
        /// <summary>
        ///
        /// </summary>
        Snow = 0xFAFAFF,
        /// <summary>
        ///
        /// </summary>
        SpringGreen = 0x7FFF00,
        /// <summary>
        ///
        /// </summary>
        SteelBlue = 0xB48246,
        /// <summary>
        ///
        /// </summary>
        Tan = 0x8CB4D2,
        /// <summary>
        ///
        /// </summary>
        Teal = 0x808000,
        /// <summary>
        ///
        /// </summary>
        Thistle = 0xD8BFD8,
        /// <summary>
        ///
        /// </summary>
        Tomato = 0x4763FF,
        /// <summary>
        ///
        /// </summary>
        Turquoise = 0xD0E040,
        /// <summary>
        ///
        /// </summary>
        Violet = 0xEE82EE,
        /// <summary>
        ///
        /// </summary>
        Wheat = 0xB3DEF5,
        /// <summary>
        ///
        /// </summary>
        White = 0xFFFFFF,
        /// <summary>
        ///
        /// </summary>
        WhiteSmoke = 0xF5F5F5,
        /// <summary>
        ///
        /// </summary>
        Yellow = 0x00FFFF,
        /// <summary>
        ///
        /// </summary>
        YellowGreen = 0x32CD9A,
    }
}

