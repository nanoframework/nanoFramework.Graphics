//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace nanoFramework.UI.Input
{
    /// <summary>
    /// The button or key.
    /// </summary>
    public enum Button
    {
        /// <summary>None.</summary>
        None = 0,

        /* Those are the mouse keys 0x01 -> 0x06 */

        /// <summary>
        /// Left mouse button
        /// </summary>
        VK_LBUTTON = 0x01,
        /// <summary>
        /// Right mouse button
        /// </summary>
        VK_RBUTTON = 0x02,
        /// <summary>
        /// Control-break processing
        /// </summary>
        VK_CANCEL = 0x03,
        /// <summary>
        /// Middle mouse button (three-button mouse)
        /// </summary>
        VK_MBUTTON = 0x04,
        /// <summary>
        /// X1 mouse button
        /// </summary>
        VK_XBUTTON1 = 0x05,
        /// <summary>
        /// X2 mouse button
        /// </summary>
        VK_XBUTTON2 = 0x06,

        /* Control keys 0x08 -> 0x2F */

        /// <summary>
        /// BACKSPACE key
        /// </summary>
        VK_BACK = 0x08,
        /// <summary>
        /// TAB key
        /// </summary>
        VK_TAB = 0x09,
        /// <summary>
        /// CLEAR key
        /// </summary>
        VK_CLEAR = 0x0C,
        /// <summary>
        /// ENTER key
        /// </summary>
        VK_RETURN = 0x0D,
        /// <summary>
        /// SHIFT key
        /// </summary>
        VK_SHIFT = 0x10,
        /// <summary>
        /// CTRL key
        /// </summary>
        VK_CONTROL = 0x11,
        /// <summary>
        /// ALT key
        /// </summary>
        VK_MENU = 0x12,
        /// <summary>
        /// PAUSE key
        /// </summary>
        VK_PAUSE = 0x13,
        /// <summary>
        /// CAPS LOCK key
        /// </summary>
        VK_CAPITAL = 0x14,
        /// <summary>
        /// IME Kana mode
        /// </summary>
        VK_KANA = 0x15,
        /// <summary>
        /// IME Hanguel mode (maintained for compatibility; use VK_HANGUL)
        /// </summary>
        VK_HANGEUL = 0x15,
        /// <summary>
        /// IME Hangul mode
        /// </summary>
        VK_HANGUL = 0x15,
        /// <summary>
        /// IME Junja mode
        /// </summary>
        VK_JUNJA = 0x17,
        /// <summary>
        /// IME final mode
        /// </summary>
        VK_FINAL = 0x18,
        /// <summary>
        /// IME Hanja mode
        /// </summary>
        VK_HANJA = 0x19,
        /// <summary>
        /// IME Kanji mode
        /// </summary>
        VK_KANJI = 0x19,
        /// <summary>
        /// ESC key
        /// </summary>
        VK_ESCAPE = 0x1B,
        /// <summary>
        /// IME convert
        /// </summary>
        VK_CONVERT = 0x1C,
        /// <summary>
        /// IME nonconvert
        /// </summary>
        VK_NONCONVERT = 0x1D,
        /// <summary>
        /// IME accept
        /// </summary>
        VK_ACCEPT = 0x1E,
        /// <summary>
        /// IME mode change request
        /// </summary>
        VK_MODECHANGE = 0x1F,
        /// <summary>
        /// SPACEBAR
        /// </summary>
        VK_SPACE = 0x20,
        /// <summary>
        /// PAGE UP key
        /// </summary>
        VK_PRIOR = 0x21,
        /// <summary>
        /// PAGE DOWN key
        /// </summary>
        VK_NEXT = 0x22,
        /// <summary>
        /// END key
        /// </summary>
        VK_END = 0x23,
        /// <summary>
        /// HOME key
        /// </summary>
        VK_HOME = 0x24,
        /// <summary>
        /// LEFT ARROW key
        /// </summary>
        VK_LEFT = 0x25,
        /// <summary>
        /// UP ARROW key
        /// </summary>
        VK_UP = 0x26,
        /// <summary>
        /// RIGHT ARROW key
        /// </summary>
        VK_RIGHT = 0x27,
        /// <summary>
        /// DOWN ARROW key
        /// </summary>
        VK_DOWN = 0x28,
        /// <summary>
        /// SELECT key
        /// </summary>
        VK_SELECT = 0x29,
        /// <summary>
        /// PRINT key
        /// </summary>
        VK_PRINT = 0x2A,
        /// <summary>
        /// EXECUTE key
        /// </summary>
        VK_EXECUTE = 0x2B,
        /// <summary>
        /// PRINT SCREEN key
        /// </summary>
        VK_SNAPSHOT = 0x2C,
        /// <summary>
        /// INS key
        /// </summary>
        VK_INSERT = 0x2D,
        /// <summary>
        /// DEL key
        /// </summary>
        VK_DELETE = 0x2E,
        /// <summary>
        /// HELP key
        /// </summary>
        VK_HELP = 0x2F,

        /* VK_0 thru VK_9 are the same as ASCII '0' thru '9' (0x30 - 0x39) */

        /// <summary>
        /// 0 key
        /// </summary>
        VK_0 = 0x30,
        /// <summary>
        /// 1 key
        /// </summary>
        VK_1 = 0x31,
        /// <summary>
        /// 2 key
        /// </summary>
        VK_2 = 0x32,
        /// <summary>
        /// 3 key
        /// </summary>
        VK_3 = 0x33,
        /// <summary>
        /// 4 key
        /// </summary>
        VK_4 = 0x34,
        /// <summary>
        /// 5 key
        /// </summary>
        VK_5 = 0x35,
        /// <summary>
        /// 6 key
        /// </summary>
        VK_6 = 0x36,
        /// <summary>
        /// 7 key
        /// </summary>
        VK_7 = 0x37,
        /// <summary>
        /// 8 key
        /// </summary>
        VK_8 = 0x38,
        /// <summary>
        /// 9 key
        /// </summary>
        VK_9 = 0x39,

        /* VK_A thru VK_Z are the same as ASCII 'A' thru 'Z' (0x41 - 0x5A) */

        /// <summary>
        /// A key
        /// </summary>
        VK_A = 0x41,
        /// <summary>
        /// B key
        /// </summary>
        VK_B = 0x42,
        /// <summary>
        /// C key
        /// </summary>
        VK_C = 0x43,
        /// <summary>
        /// D key
        /// </summary>
        VK_D = 0x44,
        /// <summary>
        /// E key
        /// </summary>
        VK_E = 0x45,
        /// <summary>
        /// F key
        /// </summary>
        VK_F = 0x46,
        /// <summary>
        /// G key
        /// </summary>
        VK_G = 0x47,
        /// <summary>
        /// H key
        /// </summary>
        VK_H = 0x48,
        /// <summary>
        /// I key
        /// </summary>
        VK_I = 0x49,
        /// <summary>
        /// J key
        /// </summary>
        VK_J = 0x4A,
        /// <summary>
        /// K key
        /// </summary>
        VK_K = 0x4B,
        /// <summary>
        /// L key
        /// </summary>
        VK_L = 0x4C,
        /// <summary>
        /// M key
        /// </summary>
        VK_M = 0x4D,
        /// <summary>
        /// N key
        /// </summary>
        VK_N = 0x4E,
        /// <summary>
        /// O key
        /// </summary>
        VK_O = 0x4F,
        /// <summary>
        /// P key
        /// </summary>
        VK_P = 0x50,
        /// <summary>
        /// Q key
        /// </summary>
        VK_Q = 0x51,
        /// <summary>
        /// R key
        /// </summary>
        VK_R = 0x52,
        /// <summary>
        /// S key
        /// </summary>
        VK_S = 0x53,
        /// <summary>
        /// T key
        /// </summary>
        VK_T = 0x54,
        /// <summary>
        /// U key
        /// </summary>
        VK_U = 0x55,
        /// <summary>
        /// V key
        /// </summary>
        VK_V = 0x56,
        /// <summary>
        /// W key
        /// </summary>
        VK_W = 0x57,
        /// <summary>
        /// X key
        /// </summary>
        VK_X = 0x58,
        /// <summary>
        /// Y key
        /// </summary>
        VK_Y = 0x59,
        /// <summary>
        /// Z key
        /// </summary>
        VK_Z = 0x5A,

        /// <summary>
        /// Left Windows key (Microsoft Natural keyboard) 
        /// </summary>
        VK_LWIN = 0x5B,
        /// <summary>
        /// Right Windows key (Natural keyboard)
        /// </summary>
        VK_RWIN = 0x5C,
        /// <summary>
        /// Applications key (Natural keyboard)
        /// </summary>
        VK_APPS = 0x5D,
        /// <summary>
        /// Computer Sleep key
        /// </summary>
        VK_SLEEP = 0x5F,
        /// <summary>
        /// Numeric keypad 0 key
        /// </summary>
        VK_NUMPAD0 = 0x60,
        /// <summary>
        /// Numeric keypad 1 key
        /// </summary>
        VK_NUMPAD1 = 0x61,
        /// <summary>
        /// Numeric keypad 2 key
        /// </summary>
        VK_NUMPAD2 = 0x62,
        /// <summary>
        /// Numeric keypad 3 key
        /// </summary>
        VK_NUMPAD3 = 0x63,
        /// <summary>
        /// Numeric keypad 4 key
        /// </summary>
        VK_NUMPAD4 = 0x64,
        /// <summary>
        /// Numeric keypad 5 key
        /// </summary>
        VK_NUMPAD5 = 0x65,
        /// <summary>
        /// Numeric keypad 6 key
        /// </summary>
        VK_NUMPAD6 = 0x66,
        /// <summary>
        /// Numeric keypad 7 key
        /// </summary>
        VK_NUMPAD7 = 0x67,
        /// <summary>
        /// Numeric keypad 8 key
        /// </summary>
        VK_NUMPAD8 = 0x68,
        /// <summary>
        /// Numeric keypad 9 key
        /// </summary>
        VK_NUMPAD9 = 0x69,
        /// <summary>
        /// Multiply key (*)
        /// </summary>
        VK_MULTIPLY = 0x6A,
        /// <summary>
        /// Add key (+)
        /// </summary>
        VK_ADD = 0x6B,
        /// <summary>
        /// Separator key
        /// </summary>
        VK_SEPARATOR = 0x6C,
        /// <summary>
        /// Subtract key (-)
        /// </summary>
        VK_SUBTRACT = 0x6D,
        /// <summary>
        /// Decimal key (. or ,)
        /// </summary>
        VK_DECIMAL = 0x6E,
        /// <summary>
        /// Divide key (/)
        /// </summary>
        VK_DIVIDE = 0x6F,

        /// <summary>
        /// F1 key
        /// </summary>
        VK_F1 = 0x70,
        /// <summary>
        /// F2 key
        /// </summary>
        VK_F2 = 0x71,
        /// <summary>
        /// F3 key
        /// </summary>
        VK_F3 = 0x72,
        /// <summary>
        /// F4 key
        /// </summary>
        VK_F4 = 0x73,
        /// <summary>
        /// F5 key
        /// </summary>
        VK_F5 = 0x74,
        /// <summary>
        /// F6 key
        /// </summary>
        VK_F6 = 0x75,
        /// <summary>
        /// F7 key
        /// </summary>
        VK_F7 = 0x76,
        /// <summary>
        /// F8 key
        /// </summary>
        VK_F8 = 0x77,
        /// <summary>
        /// F9 key
        /// </summary>
        VK_F9 = 0x78,
        /// <summary>
        /// F10 key
        /// </summary>
        VK_F10 = 0x79,
        /// <summary>
        /// F11 key
        /// </summary>
        VK_F11 = 0x7A,
        /// <summary>
        /// F12 key
        /// </summary>
        VK_F12 = 0x7B,
        /// <summary>
        /// F13 key
        /// </summary>
        VK_F13 = 0x7C,
        /// <summary>
        /// F14 key
        /// </summary>
        VK_F14 = 0x7D,
        /// <summary>
        /// F15 key
        /// </summary>
        VK_F15 = 0x7E,
        /// <summary>
        /// F16 key
        /// </summary>
        VK_F16 = 0x7F,
        /// <summary>
        /// F17 key
        /// </summary>
        VK_F17 = 0x80,
        /// <summary>
        /// F18 key
        /// </summary>
        VK_F18 = 0x81,
        /// <summary>
        /// F19 key
        /// </summary>
        VK_F19 = 0x82,
        /// <summary>
        /// F20 key
        /// </summary>
        VK_F20 = 0x83,
        /// <summary>
        /// F21 key
        /// </summary>
        VK_F21 = 0x84,
        /// <summary>
        /// F22 key
        /// </summary>
        VK_F22 = 0x85,
        /// <summary>
        /// F23 key
        /// </summary>
        VK_F23 = 0x86,
        /// <summary>
        /// F24 key
        /// </summary>
        VK_F24 = 0x87,

        /// <summary>
        /// NUM LOCK key
        /// </summary>
        VK_NUMLOCK = 0x90,        
        /// <summary>
        /// Scroll lock key
        /// </summary>
        VK_SCROLL = 0x91,

        /*
        * VK_L* & VK_R* - left and right Alt, Ctrl and Shift virtual keys.
        * Used only as parameters to GetAsyncKeyState() and GetKeyState().
        * No other API or message will distinguish left and right keys in this way.
        */

        /// <summary>
        /// Left shift key
        /// </summary>
        VK_LSHIFT = 0xA0,
        /// <summary>
        /// Right shift key
        /// </summary>
        VK_RSHIFT = 0xA1,
        /// <summary>
        /// Left control key
        /// </summary>
        VK_LCONTROL = 0xA2,
        /// <summary>
        /// Right control key
        /// </summary>
        VK_RCONTROL = 0xA3,
        /// <summary>
        /// Left menu key
        /// </summary>
        VK_LMENU = 0xA4,
        /// <summary>
        /// Right menu key
        /// </summary>
        VK_RMENU = 0xA5,
        /// <summary>
        /// Browser back key
        /// </summary>
        VK_BROWSER_BACK = 0xA6,
        /// <summary>
        /// Browser forward key
        /// </summary>
        VK_BROWSER_FORWARD = 0xA7,
        /// <summary>
        /// Browser refresh key
        /// </summary>
        VK_BROWSER_REFRESH = 0xA8,
        /// <summary>
        /// Browser stop key
        /// </summary>
        VK_BROWSER_STOP = 0xA9,
        /// <summary>
        /// Browser search key
        /// </summary>
        VK_BROWSER_SEARCH = 0xAA,
        /// <summary>
        /// Browser favorites key
        /// </summary>
        VK_BROWSER_FAVORITES = 0xAB,
        /// <summary>
        /// Browser home key
        /// </summary>
        VK_BROWSER_HOME = 0xAC,
        /// <summary>
        /// Volume mute key
        /// </summary>
        VK_VOLUME_MUTE = 0xAD,
        /// <summary>
        /// Volume down key
        /// </summary>
        VK_VOLUME_DOWN = 0xAE,
        /// <summary>
        /// Volume up key
        /// </summary>
        VK_VOLUME_UP = 0xAF,
        /// <summary>
        /// Media next track key
        /// </summary>
        VK_MEDIA_NEXT_TRACK = 0xB0,
        /// <summary>
        /// Media previous track key
        /// </summary>
        VK_MEDIA_PREV_TRACK = 0xB1,
        /// <summary>
        /// Media stop key
        /// </summary>
        VK_MEDIA_STOP = 0xB2,
        /// <summary>
        /// Media play pause key
        /// </summary>
        VK_MEDIA_PLAY_PAUSE = 0xB3,
        /// <summary>
        /// Launch mail key
        /// </summary>
        VK_LAUNCH_MAIL = 0xB4,
        /// <summary>
        /// Launch media select key
        /// </summary>
        VK_LAUNCH_MEDIA_SELECT = 0xB5,
        /// <summary>
        /// Launch application 1 key
        /// </summary>
        VK_LAUNCH_APP1 = 0xB6,
        /// <summary>
        /// Launch application 2 key
        /// </summary>
        VK_LAUNCH_APP2 = 0xB7,
        /// <summary>
        /// OEM 1 key
        /// </summary>
        VK_OEM_1 = 0xBA,
        /// <summary>
        /// OEM specific
        /// </summary>
        VK_OEM_PLUS = 0xBB,
        /// <summary>
        /// OEM specific
        /// </summary>
        VK_OEM_COMMA = 0xBC,
        /// <summary>
        /// OEM specific
        /// </summary>
        VK_OEM_MINUS = 0xBD,
        /// <summary>
        /// OEM specific
        /// </summary>
        VK_OEM_PERIOD = 0xBE,
        /// <summary>
        /// OEM specific
        /// </summary>
        VK_OEM_2 = 0xBF,
        /// <summary>
        /// OEM specific
        /// </summary>
        VK_OEM_3 = 0xC0,
        /// <summary>
        /// OEM specific
        /// </summary>
        VK_OEM_4 = 0xDB,
        /// <summary>
        /// OEM specific
        /// </summary>
        VK_OEM_5 = 0xDC,
        /// <summary>
        /// OEM specific
        /// </summary>
        VK_OEM_6 = 0xDD,
        /// <summary>
        /// OEM specific
        /// </summary>
        VK_OEM_7 = 0xDE,
        /// <summary>
        /// OEM specific
        /// </summary>
        VK_OEM_8 = 0xDF,
        /// <summary>
        /// OEM specific
        /// </summary>
        VK_OEM_AX = 0xE1,
        /// <summary>
        /// OEM specific
        /// </summary>
        VK_OEM_102 = 0xE2,
        /// <summary>
        /// OEM specific
        /// </summary>
        VK_ICO_HELP = 0xE3,
        /// <summary>
        /// OEM specific
        /// </summary>
        VK_ICO_00 = 0xE4,
        /// <summary>
        /// Clear key
        /// </summary>
        VK_PROCESSKEY = 0xE5,
        /// <summary>
        /// OEM specific
        /// </summary>
        VK_ICO_CLEAR = 0xE6,
        /// <summary>
        /// Packet key
        /// </summary>
        VK_PACKET = 0xE7,
        /// <summary>
        /// OEM specific
        /// </summary>
        VK_OEM_RESET = 0xE9,
        /// <summary>
        /// OEM specific
        /// </summary>
        VK_OEM_JUMP = 0xEA,
        /// <summary>
        /// OEM specific
        /// </summary>
        VK_OEM_PA1 = 0xEB,
        /// <summary>
        /// OEM specific
        /// </summary>
        VK_OEM_PA2 = 0xEC,
        /// <summary>
        /// OEM specific
        /// </summary>
        VK_OEM_PA3 = 0xED,
        /// <summary>
        /// OEM specific
        /// </summary>
        VK_OEM_WSCTRL = 0xEE,
        /// <summary>
        /// OEM specific
        /// </summary>
        VK_OEM_CUSEL = 0xEF,
        /// <summary>
        /// OEM specific
        /// </summary>
        VK_OEM_ATTN = 0xF0,
        /// <summary>
        /// OEM specific
        /// </summary>
        VK_OEM_FINISH = 0xF1,
        /// <summary>
        /// OEM specific
        /// </summary>
        VK_OEM_COPY = 0xF2,
        /// <summary>
        /// OEM specific
        /// </summary>
        VK_OEM_AUTO = 0xF3,
        /// <summary>
        /// OEM specific
        /// </summary>
        VK_OEM_ENLW = 0xF4,
        /// <summary>
        /// Attn key
        /// </summary>
        VK_ATTN = 0xF6,
        /// <summary>
        /// CrSel key
        /// </summary>
        VK_CRSEL = 0xF7,
        /// <summary>
        /// ExSel key
        /// </summary>
        VK_EXSEL = 0xF8,
        /// <summary>
        /// Erase EOF key
        /// </summary>
        VK_EREOF = 0xF9,
        /// <summary>
        /// Play key
        /// </summary>
        VK_PLAY = 0xFA,
        /// <summary>
        /// Zoom key
        /// </summary>
        VK_ZOOM = 0xFB,
        /// <summary>
        /// Reserved
        /// </summary>
        VK_NONAME = 0xFC,
        /// <summary>
        /// PA1 key
        /// </summary>
        VK_PA1 = 0xFD,
        /// <summary>
        /// Clear key
        /// </summary>
        VK_OEM_CLEAR = 0xFE,

        /* Those are for compatibility with the previous enums, they are not the official names */

        /// <summary>Semicolon key</summary>
        VK_SEMICOLON = 0xBA,
        /// <summary>Equal key</summary>
        VK_EQUAL = 0xBB,
        /// <summary>Coma key</summary>
        VK_COMMA = 0xBC,
        /// <summary>Hyphen key</summary>
        VK_HYPHEN = 0xBD,
        /// <summary>Period key</summary>
        VK_PERIOD = 0xBE,
        /// <summary>Slash key</summary>
        VK_SLASH = 0xBF,
        /// <summary>Back quote key</summary>
        VK_BACKQUOTE = 0xC0,
        
        /// <summary>Left backet key</summary>
        VK_LBRACKET = 0xDB,
        /// <summary>Back slash key</summary>
        VK_BACKSLASH = 0xDC,
        /// <summary>Righ bracket key</summary>
        VK_RBRACKET = 0xDD,
        /// <summary>Apostrophe key</summary>
        VK_APOSTROPHE = 0xDE,
        /// <summary>Off key</summary>
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


