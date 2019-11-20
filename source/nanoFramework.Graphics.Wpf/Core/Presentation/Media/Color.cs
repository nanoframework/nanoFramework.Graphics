//
// Copyright (c) 2019 The nanoFramework project contributors
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
    }

    /// <summary>
    /// 
    /// </summary>
    public enum Color : uint
    {
        /// <summary>
        /// 
        /// </summary>
        AliceBlue = 0xF0F8FF,
        /// <summary>
        /// 
        /// </summary>
        AntiqueWhite = 0xFAEBD7,
        /// <summary>
        /// 
        /// </summary>
        Aqua = 0x00FFFF,
        /// <summary>
        /// 
        /// </summary>
        Aquamarine = 0x7FFFD4,
        /// <summary>
        /// 
        /// </summary>
        Azure = 0xF0FFFF,
        /// <summary>
        /// 
        /// </summary>
        Beige = 0xF5F5DC,
        /// <summary>
        /// 
        /// </summary>
        Bisque = 0xFFE4C4,
        /// <summary>
        /// 
        /// </summary>
        Black = 0x000000,
        /// <summary>
        /// 
        /// </summary>
        BlanchedAlmond = 0xFFEBCD,
        /// <summary>
        /// 
        /// </summary>
        Blue = 0x0000FF,
        /// <summary>
        /// 
        /// </summary>
        BlueViolet = 0x8A2BE2,
        /// <summary>
        /// 
        /// </summary>
        Brown = 0xA52A2A,
        /// <summary>
        /// 
        /// </summary>
        BurlyWood = 0xDEB887,
        /// <summary>
        /// 
        /// </summary>
        CadetBlue = 0x5F9EA0,
        /// <summary>
        /// 
        /// </summary>
        Chartreuse = 0x7FFF00,
        /// <summary>
        /// 
        /// </summary>
        Chocolate = 0xD2691E,
        /// <summary>
        /// 
        /// </summary>
        Coral = 0xFF7F50,
        /// <summary>
        /// 
        /// </summary>
        CornflowerBlue = 0x6495ED,
        /// <summary>
        /// 
        /// </summary>
        Cornsilk =0xFFF8DC ,
        /// <summary>
        /// 
        /// </summary>
        Crimson = 0xDC143C,
        /// <summary>
        /// 
        /// </summary>
        Cyan = 0x00FFFF,
        /// <summary>
        /// 
        /// </summary>
        DarkBlue = 0x00008B,
        /// <summary>
        /// 
        /// </summary>
        DarkCyan = 0x008B8B,
        /// <summary>
        /// 
        /// </summary>
        DarkGoldenrod = 0xB8860B,
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
        DarkKhaki = 0xBDB76B,
        /// <summary>
        /// 
        /// </summary>
        DarkMagenta = 0x8B008B,
        /// <summary>
        /// 
        /// </summary>
        DarkOliveGreen = 0x556B2F,
        /// <summary>
        /// 
        /// </summary>
        DarkOrange = 0xFF8C00,
        /// <summary>
        /// 
        /// </summary>
        DarkOrchid = 0x9932CC,
        /// <summary>
        /// 
        /// </summary>
        DarkRed = 0x8B0000,
        /// <summary>
        /// 
        /// </summary>
        DarkSalmon = 0xE9967A,
        /// <summary>
        /// 
        /// </summary>
        DarkSeaGreen = 0x8FBC8F,
        /// <summary>
        /// 
        /// </summary>
        DarkSlateBlue = 0x483D8B,
        /// <summary>
        /// 
        /// </summary>
        DarkSlateGray = 0x2F4F4F,
        /// <summary>
        /// 
        /// </summary>
        DarkTurquoise = 0x00CED1,
        /// <summary>
        /// 
        /// </summary>
        DarkViolet = 0x9400D3,
        /// <summary>
        /// 
        /// </summary>
        DeepPink = 0xFF1493,
        /// <summary>
        /// 
        /// </summary>
        DeepSkyBlue = 0x00BFFF,
        /// <summary>
        /// 
        /// </summary>
        DimGray = 0x696969,
        /// <summary>
        /// 
        /// </summary>
        DodgerBlue = 0x1E90FF,
        /// <summary>
        /// 
        /// </summary>
        Firebrick = 0xB22222,
        /// <summary>
        /// 
        /// </summary>
        FloralWhite = 0xFFFAF0,
        /// <summary>
        /// 
        /// </summary>
        ForestGreen = 0x228B22,
        /// <summary>
        /// 
        /// </summary>
        Fuchsia = 0xFF00FF,
        /// <summary>
        /// 
        /// </summary>
        Gainsboro = 0xDCDCDC,
        /// <summary>
        /// 
        /// </summary>
        GhostWhite = 0xF8F8FF,
        /// <summary>
        /// 
        /// </summary>
        Gold = 0xFFD700,
        /// <summary>
        /// 
        /// </summary>
        Goldenrod = 0xDAA520,
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
        GreenYellow = 0xADFF2F,
        /// <summary>
        /// 
        /// </summary>
        Honeydew = 0xF0FFF0,
        /// <summary>
        /// 
        /// </summary>
        HotPink = 0xFF69B4,
        /// <summary>
        /// 
        /// </summary>
        IndianRed = 0xCD5C5C,
        /// <summary>
        /// 
        /// </summary>
        Indigo = 0x4B0082,
        /// <summary>
        /// 
        /// </summary>
        Ivory = 0xFFFFF0,
        /// <summary>
        /// 
        /// </summary>
        Khaki = 0xF0E68C,
        /// <summary>
        /// 
        /// </summary>
        Lavender = 0xE6E6FA,
        /// <summary>
        /// 
        /// </summary>
        LavenderBlush = 0xFFF0F5,
        /// <summary>
        /// 
        /// </summary>
        LawnGreen = 0x7CFC00,
        /// <summary>
        /// 
        /// </summary>
        LemonChiffon = 0xFFFACD,
        /// <summary>
        /// 
        /// </summary>
        LightBlue = 0xADD8E6,
        /// <summary>
        /// 
        /// </summary>
        LightCoral = 0xF08080,
        /// <summary>
        /// 
        /// </summary>
        LightCyan = 0xE0FFFF,
        /// <summary>
        /// 
        /// </summary>
        LightGoldenrodYellow = 0xFAFAD2,
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
        LightPink = 0xFFB6C1,
        /// <summary>
        /// 
        /// </summary>
        LightSalmon = 0xFFA07A,
        /// <summary>
        /// 
        /// </summary>
        LightSeaGreen = 0x20B2AA,
        /// <summary>
        /// 
        /// </summary>
        LightSkyBlue = 0x87CEFA,
        /// <summary>
        /// 
        /// </summary>
        LightSlateGray = 0x778899,
        /// <summary>
        /// 
        /// </summary>
        LightSteelBlue = 0xB0C4DE,
        /// <summary>
        /// 
        /// </summary>
        LightYellow = 0xFFFFE0,
        /// <summary>
        /// 
        /// </summary>
        ime = 0x00FF00,
        /// <summary>
        /// 
        /// </summary>
        LimeGreen = 0x32CD32,
        /// <summary>
        /// 
        /// </summary>
        Linen = 0xFAF0E6,
        /// <summary>
        /// 
        /// </summary>
        Magenta = 0xFF00FF,
        /// <summary>
        /// 
        /// </summary>
        Maroon = 0x800000,
        /// <summary>
        /// 
        /// </summary>
        MediumAquamarine = 0x66CDAA,
        /// <summary>
        /// 
        /// </summary>
        MediumBlue = 0x0000CD,
        /// <summary>
        /// 
        /// </summary>
        MediumOrchid = 0xBA55D3,
        /// <summary>
        /// 
        /// </summary>
        MediumPurple = 0x9370DB,
        /// <summary>
        /// 
        /// </summary>
        MediumSeaGreen = 0x3CB371,
        /// <summary>
        /// 
        /// </summary>
        MediumSlateBlue = 0x7B68EE,
        /// <summary>
        /// 
        /// </summary>
        MediumSpringGreen = 0x00FA9A,
        /// <summary>
        /// 
        /// </summary>
        MediumTurquoise = 0x48D1CC,
        /// <summary>
        /// 
        /// </summary>
        MediumVioletRed = 0xC71585,
        /// <summary>
        /// 
        /// </summary>
        MidnightBlue = 0x191970,
        /// <summary>
        /// 
        /// </summary>
        MintCream = 0xF5FFFA,
        /// <summary>
        /// 
        /// </summary>
        MistyRose = 0xFFE4E1,
        /// <summary>
        /// 
        /// </summary>
        Moccasin = 0xFFE4B5,
        /// <summary>
        /// 
        /// </summary>
        NavajoWhite = 0xFFDEAD,
        /// <summary>
        /// 
        /// </summary>
        Navy = 0x000080,
        /// <summary>
        /// 
        /// </summary>
        OldLace = 0xFDF5E6,
        /// <summary>
        /// 
        /// </summary>
        Olive = 0x808000,
        /// <summary>
        /// 
        /// </summary>
        OliveDrab = 0x6B8E23,
        /// <summary>
        /// 
        /// </summary>
        Orange = 0xFFA500,
        /// <summary>
        /// 
        /// </summary>
        OrangeRed = 0xFF4500,
        /// <summary>
        /// 
        /// </summary>
        Orchid = 0xDA70D6,
        /// <summary>
        /// 
        /// </summary>
        PaleGoldenrod = 0xEEE8AA,
        /// <summary>
        /// 
        /// </summary>
        PaleGreen = 0x98FB98,
        /// <summary>
        /// 
        /// </summary>
        PaleTurquoise = 0xAFEEEE,
        /// <summary>
        /// 
        /// </summary>
        PaleVioletRed = 0xDB7093,
        /// <summary>
        /// 
        /// </summary>
        PapayaWhip = 0xFFEFD5,
        /// <summary>
        /// 
        /// </summary>
        PeachPuff = 0xFFDAB9,
        /// <summary>
        /// 
        /// </summary>
        Peru = 0xCD853F,
        /// <summary>
        /// 
        /// </summary>
        Pink = 0xFFC0CB,
        /// <summary>
        /// 
        /// </summary>
        Plum = 0xDDA0DD,
        /// <summary>
        /// 
        /// </summary>
        PowderBlue = 0xB0E0E6,
        /// <summary>
        /// 
        /// </summary>
        Purple = 0x800080,
        /// <summary>
        /// 
        /// </summary>
        Red = 0xFF0000,
        /// <summary>
        /// 
        /// </summary>
        RosyBrown = 0xBC8F8F,
        /// <summary>
        /// 
        /// </summary>
        RoyalBlue = 0x4169E1,
        /// <summary>
        /// 
        /// </summary>
        SaddleBrown = 0x8B4513,
        /// <summary>
        /// 
        /// </summary>
        Salmon = 0xFA8072,
        /// <summary>
        /// 
        /// </summary>
        SandyBrown = 0xF4A460,
        /// <summary>
        /// 
        /// </summary>
        SeaGreen = 0x2E8B57,
        /// <summary>
        /// 
        /// </summary>
        SeaShell = 0xFFF5EE,
        /// <summary>
        /// 
        /// </summary>
        Sienna = 0xA0522D,
        /// <summary>
        /// 
        /// </summary>
        Silver = 0xC0C0C0,
        /// <summary>
        /// 
        /// </summary>
        SkyBlue = 0x87CEEB,
        /// <summary>
        /// 
        /// </summary>
        SlateBlue = 0x6A5ACD,
        /// <summary>
        /// 
        /// </summary>
        SlateGray = 0x708090,
        /// <summary>
        /// 
        /// </summary>
        Snow = 0xFFFAFA,
        /// <summary>
        /// 
        /// </summary>
        SpringGreen = 0x00FF7F,
        /// <summary>
        /// 
        /// </summary>
        SteelBlue = 0x4682B4,
        /// <summary>
        /// 
        /// </summary>
        Tan = 0xD2B48C,
        /// <summary>
        /// 
        /// </summary>
        Teal = 0x008080,
        /// <summary>
        /// 
        /// </summary>
        Thistle = 0xD8BFD8,
        /// <summary>
        /// 
        /// </summary>
        Tomato = 0xFF6347,
        /// <summary>
        /// 
        /// </summary>
        Transparent = 0x00FFFFFF,
        /// <summary>
        /// 
        /// </summary>
        Turquoise = 0x40E0D0,
        /// <summary>
        /// 
        /// </summary>
        Violet = 0xEE82EE,
        /// <summary>
        /// 
        /// </summary>
        Wheat = 0xF5DEB3,
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
        Yellow = 0xFFFF00,
        /// <summary>
        /// 
        /// </summary>
        YellowGreen = 0x9ACD32
    }
}

