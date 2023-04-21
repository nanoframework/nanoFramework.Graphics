//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace nanoFramework.UI
{
    /// <summary>
    /// Draw Text options.
    /// </summary>
    public enum DrawTextOptions : uint
    {
        // These have to be kept in sync with the CLR_GFX_Bitmap::c_DrawText_ flags.
        /// <summary>
        /// Specifies that there are no format rules.
        /// </summary>
        None = 0x00000000,

        /// <summary>
        /// Specifies whether a line of bitmap text automatically wraps words to the beginning of the next line when the line reaches its maximum width.
        /// </summary>
        WordWrap = 0x00000001,

        /// <summary>
        /// Specifies that if the bitmap text is larger than the space provided, the text is truncated at the bottom.
        /// </summary>
        TruncateAtBottom = 0x00000004,

        // [Obsolete("Use DT_TrimmingWordEllipsis or DT_TrimmingCharacterEllipsis to specify the type of trimming needed.", false)]
        /// <summary>
        /// Specifies that the bitmap text is trimmed to the nearest character, and an ellipsis is inserted at the end of each trimmed line.
        /// </summary>
        Ellipsis = 0x00000008,

        /// <summary>
        /// Specifies that if the bitmap text is larger than the space provided, the text is drawn in its full size, rather than being scaled down to fit the value in the Height property.
        /// </summary>
        IgnoreHeight = 0x00000010,

        /// <summary>
        /// Specifies that text is left-aligned as it flows around a bitmap.
        /// </summary>
        AlignmentLeft = 0x00000000,

        /// <summary>
        /// Specifies that text is center-aligned as it flows around a bitmap.
        /// </summary>
        AlignmentCenter = 0x00000002,

        /// <summary>
        /// Specifies that text is right-aligned as it flows around a bitmap.
        /// </summary>
        AlignmentRight = 0x00000020,

        /// <summary>
        /// Specifies that you can use a mask to get or set text alignment around a bitmap.
        /// </summary>
        AlignmentMask = 0x00000022,

        /// <summary>
        /// Not yet documented.
        /// </summary>
        TrimmingNone = 0x00000000,

        /// <summary>
        /// Not yet documented.
        /// </summary>
        TrimmingWordEllipsis = 0x00000008,

        /// <summary>
        /// Not yet documented.
        /// </summary>
        TrimmingCharacterEllipsis = 0x00000040,

        /// <summary>
        /// Not yet documented.
        /// </summary>
        TrimmingMask = 0x00000048,
    }
}
