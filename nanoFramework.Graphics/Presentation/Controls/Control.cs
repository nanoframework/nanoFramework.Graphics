//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using nanoFramework.Presentation.Media;
using nanoFramework.UI;


namespace nanoFramework.Presentation.Controls
{
    /// <summary>
    /// 
    /// </summary>
    public class Control : UIElement
    {
        /// <summary>
        /// 
        /// </summary>
        public Brush Background
        {
            get
            {
                VerifyAccess();

                return _background;
            }

            set
            {
                VerifyAccess();

                _background = value;
                Invalidate();
            }
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
        public Brush Foreground
        {
            get
            {
                VerifyAccess();

                return _foreground;
            }

            set
            {
                VerifyAccess();

                _foreground = value;
                Invalidate();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dc"></param>
        public override void OnRender(DrawingContext dc)
        {
            if (_background != null)
            {
                dc.DrawRectangle(_background, null, 0, 0, _renderWidth, _renderHeight);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected internal Brush _background = null;

        /// <summary>
        /// 
        /// </summary>
        protected internal Brush _foreground = new SolidColorBrush(Color.Black);

        /// <summary>
        /// 
        /// </summary>
        protected internal Font _font;
    }
}


