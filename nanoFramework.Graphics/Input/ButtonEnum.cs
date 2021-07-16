//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace nanoFramework.UI.Input
{
    /// <summary>
    /// 
    /// </summary>
    public enum Button
    {
        /// <summary>  </summary>
        None = 0,
        /// <summary>  </summary>
        VK_LBUTTON = 0x01,
        /// <summary>  </summary>
        VK_RBUTTON = 0x02,
        /// <summary>  </summary>
        VK_CANCEL = 0x03,
        /// <summary>  </summary>
        VK_MBUTTON = 0x04,    /* NOT contiguous with L & RBUTTON */

        /// <summary>  </summary>
        VK_BACK = 0x08,
        /// <summary>  </summary>
        VK_TAB = 0x09,

        /// <summary>  </summary>
        VK_CLEAR = 0x0C,
        /// <summary>  </summary>
        VK_RETURN = 0x0D,

        /// <summary>  </summary>
        VK_SHIFT = 0x10,
        /// <summary>  </summary>
        VK_CONTROL = 0x11,
        /// <summary>  </summary>
        VK_MENU = 0x12,
        /// <summary>  </summary>
        VK_PAUSE = 0x13,
        /// <summary>  </summary>
        VK_CAPITAL = 0x14,

        /// <summary>  </summary>
        VK_KANA = 0x15,
        /// <summary>  </summary>
        VK_HANGEUL = 0x15,  /* old name - should be here for compatibility */
        /// <summary>  </summary>
        VK_HANGUL = 0x15,

        /// <summary>  </summary>
        VK_JUNJA = 0x17,
        /// <summary>  </summary>
        VK_FINAL = 0x18,
        /// <summary>  </summary>
        VK_HANJA = 0x19,
        /// <summary>  </summary>
        VK_KANJI = 0x19,

        /// <summary>  </summary>
        VK_ESCAPE = 0x1B,

        /// <summary>  </summary>
        VK_CONVERT = 0x1c,
        /// <summary>  </summary>
        VK_NOCONVERT = 0x1d,

        /// <summary>  </summary>
        VK_SPACE = 0x20,
        /// <summary>  </summary>
        VK_PRIOR = 0x21,
        /// <summary>  </summary>
        VK_NEXT = 0x22,
        /// <summary>  </summary>
        VK_END = 0x23,
        /// <summary>  </summary>
        VK_HOME = 0x24,
        /// <summary> The LEFT button. </summary>
        VK_LEFT = 0x25,
        /// <summary>  The UP button.  </summary>
        VK_UP = 0x26,
        /// <summary> The RIGHT button. </summary>
        VK_RIGHT = 0x27,
        /// <summary> The DOWN button. </summary>
        VK_DOWN = 0x28,
        /// <summary>  </summary>
        VK_SELECT = 0x29,
        /// <summary>  </summary>
        VK_PRINT = 0x2A,
        /// <summary>  </summary>
        VK_EXECUTE = 0x2B,
        /// <summary>  </summary>
        VK_SNAPSHOT = 0x2C,
        /// <summary>  </summary>
        VK_INSERT = 0x2D,
        /// <summary>  </summary>
        VK_DELETE = 0x2E,
        /// <summary>  </summary>
        VK_HELP = 0x2F,

        /* VK_0 thru VK_9 are the same as ASCII '0' thru '9' (0x30 - 0x39) */
        /// <summary>  </summary>
        VK_0 = 0x30,
        /// <summary>  </summary>
        VK_1 = 0x31,
        /// <summary>  </summary>
        VK_2 = 0x32,
        /// <summary>  </summary>
        VK_3 = 0x33,
        /// <summary>  </summary>
        VK_4 = 0x34,
        /// <summary>  </summary>
        VK_5 = 0x35,
        /// <summary>  </summary>
        VK_6 = 0x36,
        /// <summary>  </summary>
        VK_7 = 0x37,
        /// <summary>  </summary>
        VK_8 = 0x38,
        /// <summary>  </summary>
        VK_9 = 0x39,

        /* VK_A thru VK_Z are the same as ASCII 'A' thru 'Z' (0x41 - 0x5A) */
        /// <summary>  </summary>
        VK_A = 0x41,
        /// <summary>  </summary>
        VK_B = 0x42,
        /// <summary>  </summary>
        VK_C = 0x43,
        /// <summary>  </summary>
        VK_D = 0x44,
        /// <summary>  </summary>
        VK_E = 0x45,
        /// <summary>  </summary>
        VK_F = 0x46,
        /// <summary>  </summary>
        VK_G = 0x47,
        /// <summary>  </summary>
        VK_H = 0x48,
        /// <summary>  </summary>
        VK_I = 0x49,
        /// <summary>  </summary>
        VK_J = 0x4A,
        /// <summary>  </summary>
        VK_K = 0x4B,
        /// <summary>  </summary>
        VK_L = 0x4C,
        /// <summary>  </summary>
        VK_M = 0x4D,
        /// <summary>  </summary>
        VK_N = 0x4E,
        /// <summary>  </summary>
        VK_O = 0x4F,
        /// <summary>  </summary>
        VK_P = 0x50,
        /// <summary>  </summary>
        VK_Q = 0x51,
        /// <summary>  </summary>
        VK_R = 0x52,
        /// <summary>  </summary>
        VK_S = 0x53,
        /// <summary>  </summary>
        VK_T = 0x54,
        /// <summary>  </summary>
        VK_U = 0x55,
        /// <summary>  </summary>
        VK_V = 0x56,
        /// <summary>  </summary>
        VK_W = 0x57,
        /// <summary>  </summary>
        VK_X = 0x58,
        /// <summary>  </summary>
        VK_Y = 0x59,
        /// <summary>  </summary>
        VK_Z = 0x5A,
        /// <summary>  </summary>
        VK_LWIN = 0x5B,
        /// <summary>  </summary>
        VK_RWIN = 0x5C,
        /// <summary>  </summary>
        VK_APPS = 0x5D,

        /// <summary>  </summary>
        VK_SLEEP = 0x5F,

        /// <summary>  </summary>
        VK_NUMPAD0 = 0x60,
        /// <summary>  </summary>
        VK_NUMPAD1 = 0x61,
        /// <summary>  </summary>
        VK_NUMPAD2 = 0x62,
        /// <summary>  </summary>
        VK_NUMPAD3 = 0x63,
        /// <summary>  </summary>
        VK_NUMPAD4 = 0x64,
        /// <summary>  </summary>
        VK_NUMPAD5 = 0x65,
        /// <summary>  </summary>
        VK_NUMPAD6 = 0x66,
        /// <summary>  </summary>
        VK_NUMPAD7 = 0x67,
        /// <summary>  </summary>
        VK_NUMPAD8 = 0x68,
        /// <summary>  </summary>
        VK_NUMPAD9 = 0x69,
        /// <summary>  </summary>
        VK_MULTIPLY = 0x6A,
        /// <summary>  </summary>
        VK_ADD = 0x6B,
        /// <summary>  </summary>
        VK_SEPARATOR = 0x6C,
        /// <summary>  </summary>
        VK_SUBTRACT = 0x6D,
        /// <summary>  </summary>
        VK_DECIMAL = 0x6E,
        /// <summary>  </summary>
        VK_DIVIDE = 0x6F,
        /// <summary>  </summary>
        VK_F1 = 0x70,
        /// <summary>  </summary>
        VK_F2 = 0x71,
        /// <summary>  </summary>
        VK_F3 = 0x72,
        /// <summary>  </summary>
        VK_F4 = 0x73,
        /// <summary>  </summary>
        VK_F5 = 0x74,
        /// <summary>  </summary>
        VK_F6 = 0x75,
        /// <summary>  </summary>
        VK_F7 = 0x76,
        /// <summary>  </summary>
        VK_F8 = 0x77,
        /// <summary>  </summary>
        VK_F9 = 0x78,
        /// <summary>  </summary>
        VK_F10 = 0x79,
        /// <summary>  </summary>
        VK_F11 = 0x7A,
        /// <summary>  </summary>
        VK_F12 = 0x7B,
        /// <summary>  </summary>
        VK_F13 = 0x7C,
        /// <summary>  </summary>
        VK_F14 = 0x7D,
        /// <summary>  </summary>
        VK_F15 = 0x7E,
        /// <summary>  </summary>
        VK_F16 = 0x7F,
        /// <summary>  </summary>
        VK_F17 = 0x80,
        /// <summary>  </summary>
        VK_F18 = 0x81,
        /// <summary>  </summary>
        VK_F19 = 0x82,
        /// <summary>  </summary>
        VK_F20 = 0x83,
        /// <summary>  </summary>
        VK_F21 = 0x84,
        /// <summary>  </summary>
        VK_F22 = 0x85,
        /// <summary>  </summary>
        VK_F23 = 0x86,
        /// <summary>  </summary>
        VK_F24 = 0x87,
        /// <summary>  </summary>

        VK_NUMLOCK = 0x90,
        /// <summary>  </summary>
        VK_SCROLL = 0x91,

        /*
        * VK_L* & VK_R* - left and right Alt, Ctrl and Shift virtual keys.
        * Used only as parameters to GetAsyncKeyState() and GetKeyState().
        * No other API or message will distinguish left and right keys in this way.
        */
        /// <summary>  </summary>
        VK_LSHIFT = 0xA0,
        /// <summary>  </summary>
        VK_RSHIFT = 0xA1,
        /// <summary>  </summary>
        VK_LCONTROL = 0xA2,
        /// <summary>  </summary>
        VK_RCONTROL = 0xA3,
        /// <summary>  </summary>
        VK_LMENU = 0xA4,
        /// <summary>  </summary>
        VK_RMENU = 0xA5,
        /// <summary>  </summary>
        VK_EXTEND_BSLASH = 0xE2,
        /// <summary>  </summary>
        VK_OEM_102 = 0xE2,
        /// <summary>  </summary>
        VK_PROCESSKEY = 0xE5,
        /// <summary>  </summary>
        VK_ATTN = 0xF6,
        /// <summary>  </summary>
        VK_CRSEL = 0xF7,
        /// <summary>  </summary>
        VK_EXSEL = 0xF8,
        /// <summary>  </summary>
        VK_EREOF = 0xF9,
        /// <summary>  </summary>
        VK_PLAY = 0xFA,
        /// <summary>  </summary>
        VK_ZOOM = 0xFB,
        /// <summary>  </summary>
        VK_NONAME = 0xFC,
        /// <summary>  </summary>
        VK_PA1 = 0xFD,
        /// <summary>  </summary>
        VK_OEM_CLEAR = 0xFE,
        /// <summary>  </summary>
        VK_SEMICOLON = 0xBA,
        /// <summary>  </summary>
        VK_EQUAL = 0xBB,
        /// <summary>  </summary>
        VK_COMMA = 0xBC,
        /// <summary>  </summary>
        VK_HYPHEN = 0xBD,
        /// <summary>  </summary>
        VK_PERIOD = 0xBE,
        /// <summary>  </summary>
        VK_SLASH = 0xBF,
        /// <summary>  </summary>
        VK_BACKQUOTE = 0xC0,
        /// <summary>  </summary>
        VK_BROWSER_BACK = 0xA6,
        /// <summary>  </summary>
        VK_BROWSER_FORWARD = 0xA7,
        /// <summary>  </summary>
        VK_BROWSER_REFRESH = 0xA8,
        /// <summary>  </summary>
        VK_BROWSER_STOP = 0xA9,
        /// <summary>  </summary>
        VK_BROWSER_SEARCH = 0xAA,
        /// <summary>  </summary>
        VK_BROWSER_FAVORITES = 0xAB,
        /// <summary>  </summary>
        VK_BROWSER_HOME = 0xAC,
        /// <summary>  </summary>
        VK_VOLUME_MUTE = 0xAD,
        /// <summary>  </summary>
        VK_VOLUME_DOWN = 0xAE,
        /// <summary>  </summary>
        VK_VOLUME_UP = 0xAF,
        /// <summary>  </summary>
        VK_MEDIA_NEXT_TRACK = 0xB0,
        /// <summary>  </summary>
        VK_MEDIA_PREV_TRACK = 0xB1,
        /// <summary>  </summary>
        VK_MEDIA_STOP = 0xB2,
        /// <summary>  </summary>
        VK_MEDIA_PLAY_PAUSE = 0xB3,
        /// <summary>  </summary>
        VK_LAUNCH_MAIL = 0xB4,
        /// <summary>  </summary>
        VK_LAUNCH_MEDIA_SELECT = 0xB5,
        /// <summary>  </summary>
        VK_LAUNCH_APP1 = 0xB6,
        /// <summary>  </summary>
        VK_LAUNCH_APP2 = 0xB7,
        /// <summary>  </summary>
        VK_LBRACKET = 0xDB,
        /// <summary>  </summary>
        VK_BACKSLASH = 0xDC,
        /// <summary>  </summary>
        VK_RBRACKET = 0xDD,
        /// <summary>  </summary>
        VK_APOSTROPHE = 0xDE,
        /// <summary>  </summary>
        VK_OFF = 0xDF,
        /// <summary>  </summary>
        VK_DBE_ALPHANUMERIC = 0x0f0,
        /// <summary>  </summary>
        VK_DBE_KATAKANA = 0x0f1,
        /// <summary>  </summary>
        VK_DBE_HIRAGANA = 0x0f2,
        /// <summary>  </summary>
        VK_DBE_SBCSCHAR = 0x0f3,
        /// <summary>  </summary>
        VK_DBE_DBCSCHAR = 0x0f4,
        /// <summary>  </summary>
        VK_DBE_ROMAN = 0x0f5,
        /// <summary>  </summary>
        VK_DBE_NOROMAN = 0x0f6,
        /// <summary>  </summary>
        VK_DBE_ENTERWORDREGISTERMODE = 0x0f7,
        /// <summary>  </summary>
        VK_DBE_ENTERIMECONFIGMODE = 0x0f8,
        /// <summary>  </summary>
        VK_DBE_FLUSHSTRING = 0x0f9,
        /// <summary>  </summary>
        VK_DBE_CODEINPUT = 0x0fa,
        /// <summary>  </summary>
        VK_DBE_NOCODEINPUT = 0x0fb,
        /// <summary>  </summary>
        VK_DBE_DETERMINESTRING = 0x0fc,
        /// <summary>  </summary>
        VK_DBE_ENTERDLGCONVERSIONMODE = 0x0fd,

        /// <summary>
        /// Last in the standard MF buttons enumeration
        /// </summary>
        LastSystemDefinedButton = 0x110,

        // Users may define their button definitions with values larger than
        // Button.LastSystemDefinedButton
        // Values less that Button.LastSystemDefinedButton are reserved for standard buttons.
        // Values above Button.LastSystemDefinedButton are for third party extensions.
        /// <summary>  </summary>
        AppDefined1 = LastSystemDefinedButton + 1,
        /// <summary>  </summary>
        AppDefined2 = LastSystemDefinedButton + 2,
        /// <summary>  </summary>
        AppDefined3 = LastSystemDefinedButton + 3,
        /// <summary>  </summary>
        AppDefined4 = LastSystemDefinedButton + 4,
        /// <summary>  </summary>
        AppDefined5 = LastSystemDefinedButton + 5,
        /// <summary>  </summary>
        AppDefined6 = LastSystemDefinedButton + 6,
        /// <summary>  </summary>
        AppDefined7 = LastSystemDefinedButton + 7,
        /// <summary>  </summary>
        AppDefined8 = LastSystemDefinedButton + 8,

    }
}


