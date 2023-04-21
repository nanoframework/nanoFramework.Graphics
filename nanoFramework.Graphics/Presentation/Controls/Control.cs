//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using nanoFramework.Presentation.Media;
using nanoFramework.UI;
using System.Drawing;

namespace nanoFramework.Presentation.Controls
{
    /// <summary>
    /// Represents a base class for all WPF controls.
    /// </summary>
    public class Control : UIElement
    {
        /// <summary>
        /// Gets or sets the Brush that fills the background of the control.
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
        /// Gets or sets the Font of the control.
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
        /// Gets or sets the Brush that is used to paint the foreground of the control.
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
        /// Called when the control is redrawn.
        /// </summary>
        /// <param name="dc">The DrawingContext used to render the control.</param>
        public override void OnRender(DrawingContext dc)
        {
            if (_background != null)
            {
                dc.DrawRectangle(_background, null, 0, 0, _renderWidth, _renderHeight);
            }
        }

        /// <summary>
        /// The Brush used to fill the background of the control.
        /// </summary>
        protected internal Brush _background = null;

        /// <summary>
        /// The Brush used to paint the foreground of the control.
        /// </summary>
        protected internal Brush _foreground = new SolidColorBrush(Color.Black);

        /// <summary>
        /// The Font used to render the control.
        /// </summary>
        protected internal Font _font;
    }
}
