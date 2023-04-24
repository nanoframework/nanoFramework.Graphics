//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using nanoFramework.Presentation.Media;
using System;
using nanoFramework.UI;
using System.Drawing;

namespace nanoFramework.Presentation.Controls
{
    /// <summary>
    /// Represents a text element that can be displayed on a user interface.
    /// </summary>
    public class Text : UIElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Text"/> class.
        /// </summary>
        public Text()
            : this(null, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Text"/> class with the specified content.
        /// </summary>
        /// <param name="content">The text content to display.</param>
        public Text(string content)
            : this(null, content)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Text"/> class with the specified font and content.
        /// </summary>
        /// <param name="font">The font to use when rendering the text.</param>
        /// <param name="content">The text content to display.</param>
        public Text(Font font, string content)
        {
            _text = content;
            _font = font;
            _foreColor = Color.Black;
        }

        /// <summary>
        /// Gets or sets the font used to render the text.
        /// </summary>
        public Font Font
        {
            get
            {
                return _font;
            }

            set
            {
                VerifyAccess();

                _font = value;
                InvalidateMeasure();
            }
        }

        /// <summary>
        /// Gets or sets the font used to render the text.
        /// </summary>
        public Color ForeColor
        {
            get
            {
                return _foreColor;
            }

            set
            {
                VerifyAccess();

                _foreColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the text content to display.
        /// </summary>
        public string TextContent
        {
            get
            {
                return _text;
            }

            set
            {
                VerifyAccess();

                if (_text != value)
                {
                    _text = value;
                    InvalidateMeasure();
                }
            }
        }

        /// <summary>
        /// Gets or sets the text trimming behavior when the text does not fit within the available space.
        /// </summary>
        public TextTrimming Trimming
        {
            get
            {
                return _trimming;
            }

            set
            {
                VerifyAccess();

                _trimming = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the horizontal alignment of the text.
        /// </summary>
        public TextAlignment TextAlignment
        {
            get
            {
                return _alignment;
            }

            set
            {
                VerifyAccess();

                _alignment = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets the height of each line of text, including any additional spacing.
        /// </summary>
        public int LineHeight
        {
            //Don't support IgnoreDescent, etc...
            get
            {
                return (_font != null) ? (_font.Height + _font.ExternalLeading) : 0;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the text should be wrapped to the next line when it does not fit within the available space.
        /// </summary>
        public bool TextWrap
        {
            get
            {
                return _textWrap;
            }

            set
            {
                VerifyAccess();

                _textWrap = value;
                InvalidateMeasure();
            }
        }

        /// <summary>
        /// Measures the desired size of the control based on the available size and the text to display.
        /// </summary>
        /// <param name="availableWidth">The available width for the control.</param>
        /// <param name="availableHeight">The available height for the control.</param>
        /// <param name="desiredWidth">The desired width of the control.</param>
        /// <param name="desiredHeight">The desired height of the control.</param>
        protected override void MeasureOverride(int availableWidth, int availableHeight, out int desiredWidth, out int desiredHeight)
        {
            if (_font != null && _text != null && _text.Length > 0)
            {
                DrawTextOptions flags = DrawTextOptions.IgnoreHeight | DrawTextOptions.WordWrap;

                switch (_alignment)
                {
                    case TextAlignment.Left:
                        flags |= DrawTextOptions.AlignmentLeft;
                        break;
                    case TextAlignment.Right:
                        flags |= DrawTextOptions.AlignmentRight;
                        break;
                    case TextAlignment.Center:
                        flags |= DrawTextOptions.AlignmentCenter;
                        break;
                    default:
                        throw new NotSupportedException();
                }

                switch (_trimming)
                {
                    case TextTrimming.CharacterEllipsis:
                        flags |= DrawTextOptions.TrimmingCharacterEllipsis;
                        break;
                    case TextTrimming.WordEllipsis:
                        flags |= DrawTextOptions.TrimmingWordEllipsis;
                        break;
                }

                _font.ComputeTextInRect(_text, out desiredWidth, out desiredHeight, 0, 0, availableWidth, 0, (uint)flags);

                if (_textWrap == false) desiredHeight = _font.Height;
            }
            else
            {
                desiredWidth = 0;
                desiredHeight = (_font != null) ? _font.Height : 0;
            }
        }

        /// <summary>
        /// Renders the control on the specified drawing context.
        /// </summary>
        /// <param name="dc">The drawing context to use for rendering.</param>

        public override void OnRender(DrawingContext dc)
        {
            if (_font != null && _text != null)
            {
                int height = _textWrap ? _renderHeight : _font.Height;

                string txt = _text;
                dc.DrawText(ref txt, _font, _foreColor, 0, 0, _renderWidth, height, _alignment, _trimming);
            }
        }

#if NANOCLR_TRACE
        public override string ToString()
        {
            return base.ToString() + " [" + this.TextContent + "]";
        }

#endif

        /// <summary>
        /// The font.
        /// </summary>
        protected Font _font;
        private Color _foreColor;

        /// <summary>
        /// The text.
        /// </summary>
        protected string _text;
        private bool _textWrap;
        private TextTrimming _trimming = TextTrimming.WordEllipsis;
        private TextAlignment _alignment = TextAlignment.Left;
    }
}
