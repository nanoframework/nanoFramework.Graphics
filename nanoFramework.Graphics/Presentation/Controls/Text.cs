//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using nanoFramework.Presentation.Media;
using System;
using nanoFramework.UI;

namespace nanoFramework.Presentation.Controls
{
    /// <summary>
    /// 
    /// </summary>
    public class Text : UIElement
    {
        /// <summary>
        /// 
        /// </summary>
        public Text()
            : this(null, null)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        public Text(string content)
            : this(null, content)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="font"></param>
        /// <param name="content"></param>
        public Text(Font font, string content)
        {
            _text = content;
            _font = font;
            _foreColor = Color.Black;
        }

        /// <summary>
        /// 
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
        /// 
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
        /// 
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
        /// 
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
        /// 
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
        /// 
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
        /// 
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
        /// 
        /// </summary>
        /// <param name="availableWidth"></param>
        /// <param name="availableHeight"></param>
        /// <param name="desiredWidth"></param>
        /// <param name="desiredHeight"></param>
        protected override void MeasureOverride(int availableWidth, int availableHeight, out int desiredWidth, out int desiredHeight)
        {
            if (_font != null && _text != null && _text.Length > 0)
            {
                uint flags = Bitmap.DT_IgnoreHeight | Bitmap.DT_WordWrap;

                switch (_alignment)
                {
                    case TextAlignment.Left:
                        flags |= Bitmap.DT_AlignmentLeft;
                        break;
                    case TextAlignment.Right:
                        flags |= Bitmap.DT_AlignmentRight;
                        break;
                    case TextAlignment.Center:
                        flags |= Bitmap.DT_AlignmentCenter;
                        break;
                    default:
                        throw new NotSupportedException();
                }

                switch (_trimming)
                {
                    case TextTrimming.CharacterEllipsis:
                        flags |= Bitmap.DT_TrimmingCharacterEllipsis;
                        break;
                    case TextTrimming.WordEllipsis:
                        flags |= Bitmap.DT_TrimmingWordEllipsis;
                        break;
                }

                _font.ComputeTextInRect(_text, out desiredWidth, out desiredHeight, 0, 0, availableWidth, 0, flags);

                if (_textWrap == false) desiredHeight = _font.Height;
            }
            else
            {
                desiredWidth = 0;
                desiredHeight = (_font != null) ? _font.Height : 0;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dc"></param>
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
        /// 
        /// </summary>
        protected Font _font;
        private Color _foreColor;

        /// <summary>
        /// 
        /// </summary>
        protected string _text;
        private bool _textWrap;
        private TextTrimming _trimming = TextTrimming.WordEllipsis;
        private TextAlignment _alignment = TextAlignment.Left;
    }
}


