//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace nanoFramework.Presentation.Media
{
    /// <summary>
    /// Specifies how text is trimmed when it overflows the edge of a container.
    /// </summary>
    public enum TextTrimming
    {
        /// <summary>
        /// Text is trimmed at the end of the last fully displayed character.
        /// An ellipsis (...) is inserted to indicate that text has been truncated.
        /// </summary>
        CharacterEllipsis,

        /// <summary>
        /// Text is not trimmed and may overflow the edge of the container.
        /// </summary>
        None,

        /// <summary>
        /// Text is trimmed at the end of the last fully displayed word.
        /// An ellipsis (...) is inserted to indicate that text has been truncated.
        /// </summary>
        WordEllipsis,
    }
}
