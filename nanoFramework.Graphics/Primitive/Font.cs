//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using System;
using System.Runtime.CompilerServices;

namespace nanoFramework.UI
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class Font : MarshalByRefObject
    {
        
#pragma warning disable 169
        private object m_font;  // Do not delete m_font, this is linked to the underlying C/C++ code via magic (MDP)
#pragma warning restore

        // Must keep in sync with CLR_GFX_Font::c_DefaultKerning
        /// <summary>
        /// Contains the default kerning for a particular font.
        /// The kerning controls the amount of space between consecutive characters in a particular font.
        /// </summary>
        public const int DefaultKerning = 1024;

        private Font()
        {
        }

        /// <summary>
        /// Gets the width of the specified character, in pixels.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        extern public int CharWidth(char c);

        /// <summary>
        /// Gets the height of the current font, in pixels.
        /// </summary>
        extern public int Height
        {
            [MethodImplAttribute(MethodImplOptions.InternalCall)]
            get;
        }

        /// <summary>
        /// Gets the average width of the characters in the current font, in pixels.
        /// </summary>
        extern public int AverageWidth
        {
            [MethodImplAttribute(MethodImplOptions.InternalCall)]
            get;
        }

        /// <summary>
        /// Gets the width of the widest character in the current font, in pixels.
        /// </summary>
        extern public int MaxWidth
        {
            [MethodImplAttribute(MethodImplOptions.InternalCall)]
            get;
        }

        /// <summary>
        /// Gets the ascent measurement for the current font, in pixels.
        /// A font's ascent is the vertical distance between the font baseline and the top of the font area.
        /// <returns>The ascent measurement for the current font, in pixels.</returns>
        /// </summary>
        extern public int Ascent
        {
            [MethodImplAttribute(MethodImplOptions.InternalCall)]
            get;
        }

        /// <summary>
        /// Gets the descent measurement for the current font, in pixels.
        /// A font's descent is the vertical distance between the font baseline and the bottom of the font area.
        /// <returns>The descent measurement for the current font, in pixels.</returns>
        /// </summary>
        extern public int Descent
        {
            [MethodImplAttribute(MethodImplOptions.InternalCall)]
            get;
        }

        /// <summary>
        /// Gets the internal leading measurement for the current font, in pixels.
        /// <returns>The internal leading measurement for the current font, in pixels.</returns>
        /// </summary>
        extern public int InternalLeading
        {
            [MethodImplAttribute(MethodImplOptions.InternalCall)]
            get;
        }

        /// <summary>
        /// Gets the external leading measurement for the current font, in pixels.
        /// <returns>The external leading measurement for the current font, in pixels.</returns>
        /// </summary>
        extern public int ExternalLeading
        {
            [MethodImplAttribute(MethodImplOptions.InternalCall)]
            get;
        }

        /// <summary>
        /// Computes the width, height, and kerning of a specified line of text.
        /// </summary>
        /// <param name = "text" > The text you want to measure.</param>
        /// <param name = "width" > The width of the specified text.</param>
        /// <param name = "height" > The height of the specified text.</param>
        public void ComputeExtent(string text, out int width, out int height)
        {
            ComputeExtent(text, out width, out height, DefaultKerning);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name = "text" > The text you want to measure.</param>
        /// <param name = "width" > The width of the specified text.</param>
        /// <param name = "height" > The height of the specified text.</param>
        /// <param name = "kerning" > The spacing between consecutive characters.</param>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        extern public void ComputeExtent(string text, out int width, out int height, int kerning);

        /// <summary>
        /// Computes the size of the rectangular area on the display device needed to render the specified text string.
        /// </summary>
        /// <param name = "text" > The text you want to render on the display device.</param>
        /// <param name = "renderWidth" > The width, in pixels, of the rectangular area needed to render the text.</param>
        /// <param name = "renderHeight" > The height, in pixels, of the rectangular area needed to render the text.</param>
        public void ComputeTextInRect(string text, out int renderWidth, out int renderHeight)
        {
            ComputeTextInRect(text, out renderWidth, out renderHeight, 0, 0, 65536, 0, Bitmap.DT_IgnoreHeight | Bitmap.DT_WordWrap);
        }

        /// <summary>
        /// Computes the size of the rectangular area on the display device needed to render the specified text string.
        /// </summary>
        /// <param name = "text" > The text you want to render on the display device.</param>
        /// <param name = "renderWidth" > The width, in pixels, of the rectangular area needed to render the text.</param>
        /// <param name = "renderHeight" > The height, in pixels, of the rectangular area needed to render the text.</param>
        /// <param name = "availableWidth" > The maximum width of text that will fit in the defined rectangular area.</param>
        public void ComputeTextInRect(string text, out int renderWidth, out int renderHeight, int availableWidth)
        {
            ComputeTextInRect(text, out renderWidth, out renderHeight, 0, 0, availableWidth, 0, Bitmap.DT_IgnoreHeight | Bitmap.DT_WordWrap);
        }

        /// <summary>
        /// Computes the size of the rectangular area on the display device needed to render the specified text string.
        /// </summary>
        /// <param name = "text" > The text you want to render on the display device.</param>
        /// <param name = "renderWidth" > The width, in pixels, of the rectangular area needed to render the text.</param>
        /// <param name = "renderHeight" > The height, in pixels, of the rectangular area needed to render the text.</param>
        /// <param name = "xRelStart" > The x-coordinate of the relative starting point for the text.</param>
        /// <param name = "yRelStart" > The y-coordinate of the relative starting point for the text.</param>
        /// <param name = "availableWidth" > The maximum width of text that will fit in the defined rectangular area.</param>
        /// <param name = "availableHeight" > The maximum height of text that will fit in the defined rectangular area.</param>
        /// <param name = "dtFlags" > Flags that specify various text characteristics, such as alignment.</param>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        extern public void ComputeTextInRect(string text, out int renderWidth, out int renderHeight, int xRelStart, int yRelStart, int availableWidth, int availableHeight, uint dtFlags);
    }
}


