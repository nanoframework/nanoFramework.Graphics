//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using nanoFramework.Presentation.Media;
using System;
using System.Diagnostics;
using nanoFramework.UI;
using System.Drawing;

namespace nanoFramework.Presentation.Controls
{
    /// <summary>
    /// Represents a text run with a specific font and color.
    /// </summary>
    public class TextRun
    {
        /// <summary>
        /// Gets the text of the current text run.
        /// </summary>
        public readonly string Text;

        /// <summary>
        /// Gets the font of the current text run.
        /// </summary>
        public readonly Font Font;

        /// <summary>
        /// Gets the foreground color of the current text run.
        /// </summary>
        public readonly Color ForeColor;

        /// <summary>
        /// Gets a value indicating whether the text run is at the end of a line.
        /// </summary>
        internal bool IsEndOfLine;

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        protected int _width;

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        protected int _height;

        private TextRun()
        {
        }

        /// <summary>
        /// Initializes a new instance of the TextRun class with the specified text, font, and foreground color.
        /// </summary>
        /// <param name="text">The text of the text run.</param>
        /// <param name="font">The font of the text run.</param>
        /// <param name="foreColor">The foreground color of the text run.</param>
        public TextRun(string text, Font font, Color foreColor)
        {
            if (text == null || text.Length == 0)
            {
                throw new ArgumentNullException("Text must be non-null and non-empty");
            }

            if (font == null)
            {
                throw new ArgumentNullException("font must be non-null");
            }

            this.Text = text;
            this.Font = font;
            this.ForeColor = foreColor;
        }

        /// <summary>
        /// Gets a text run that represents the end of a line.
        /// </summary>
        public static TextRun EndOfLine
        {
            get
            {
                TextRun eol = new TextRun();
                eol.IsEndOfLine = true;
                return eol;
            }
        }

        private int EmergencyBreak(int width)
        {
            int index = Text.Length;
            int w, h;
            do
            {
                Font.ComputeExtent(Text.Substring(0, --index), out w, out h);
            }

            while (w >= width && index > 1);

            return index;
        }

        /// <summary>
        /// Splits the current text run at the specified available width and returns the resulting text runs.
        /// </summary>
        /// <param name="availableWidth">The available width at which to split the text run.</param>
        /// <param name="run1">When this method returns, contains the first part of the split text run if the split was successful; otherwise, null.</param>
        /// <param name="run2">When this method returns, contains the second part of the split text run if the split was successful; otherwise, null.</param>
        /// <param name="emergencyBreak">A value indicating whether an emergency break should be performed if a regular break cannot be found.</param>
        /// <returns>true if the text run was successfully split; otherwise, false.</returns>
        internal bool Break(int availableWidth, out TextRun run1, out TextRun run2, bool emergencyBreak)
        {
            //Debug.Assert(availableWidth > 0);
            //Debug.Assert(availableWidth < _width);
            //Debug.Assert(Text.Length > 1);

            int leftBreak = -1;
            int rightBreak = -1;
            int w, h;

            // Try to find a candidate position for breaking
            //
            bool foundBreak = false;
            while (!foundBreak)
            {
                // Try adding a word
                //
                int indexOfNextSpace = Text.IndexOf(' ', leftBreak + 1);

                foundBreak = (indexOfNextSpace == -1);

                if (!foundBreak)
                {
                    Font.ComputeExtent(Text.Substring(0, indexOfNextSpace), out w, out h);
                    foundBreak = (w >= availableWidth);
                    if (w == availableWidth)
                    {
                        leftBreak = indexOfNextSpace;
                    }
                }

                if (foundBreak)
                {
                    if (leftBreak >= 0)
                    {
                        rightBreak = leftBreak + 1;
                    }
                    else if (emergencyBreak)
                    {
                        leftBreak = EmergencyBreak(availableWidth);
                        rightBreak = leftBreak;
                    }
                    else
                    {
                        run1 = run2 = null;
                        return false;
                    }
                }
                else
                {
                    leftBreak = indexOfNextSpace;
                }
            }

            string first = Text.Substring(0, leftBreak).TrimEnd(' ');

            // Split the text run
            //
            run1 = null;
            if (first.Length > 0)
            {
                run1 = new TextRun(first, this.Font, this.ForeColor);
            }

            run2 = null;
            if (rightBreak < Text.Length)
            {
                String run2String = Text.Substring(rightBreak).TrimStart(' ');

                // if run2 is all spaces (length == 0 after trim), we'll leave run2 as null
                if (run2String.Length > 0)
                {
                    run2 = new TextRun(run2String, this.Font, this.ForeColor);
                }
            }

            return true;
        }

        /// <summary>
        /// Gets the size of the current text run.
        /// </summary>
        /// <param name="width">When this method returns, contains the width of the text run.</param>
        /// <param name="height">When this method returns, contains the height of the text run.</param>
        public void GetSize(out int width, out int height)
        {
            if (_width == 0)
            {
                Font.ComputeExtent(Text, out _width, out _height);
            }

            width = _width;
            height = _height;
        }
    }
}
