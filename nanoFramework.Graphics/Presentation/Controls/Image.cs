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
    /// Summary description for Image.
    /// </summary>
    public class Image : UIElement
    {
        /// <summary>
        /// Initializes a new instance of the Image class.
        /// </summary>
        public Image()
        {
        }

        /// <summary>
        /// Initializes a new instance of the Image class with a specified Bitmap.
        /// </summary>
        /// <param name="bmp">The Bitmap to display in the Image element.</param>
        public Image(Bitmap bmp)
            : this()
        {
            _bitmap = bmp;
        }

        /// <summary>
        /// Gets or sets the Bitmap displayed in the Image element.
        /// </summary>
        public Bitmap Bitmap
        {
            get
            {
                VerifyAccess();

                return _bitmap;
            }

            set
            {
                VerifyAccess();

                _bitmap = value;
                InvalidateMeasure();
            }
        }

        /// <summary>
        /// Measures the size of the Image element based on its Bitmap.
        /// </summary>
        /// <param name="availableWidth">The available width for the Image element to occupy.</param>
        /// <param name="availableHeight">The available height for the Image element to occupy.</param>
        /// <param name="desiredWidth">The desired width of the Image element based on its Bitmap.</param>
        /// <param name="desiredHeight">The desired height of the Image element based on its Bitmap.</param>
        protected override void MeasureOverride(int availableWidth, int availableHeight, out int desiredWidth, out int desiredHeight)
        {
            desiredWidth = desiredHeight = 0;
            if (_bitmap != null)
            {
                desiredWidth = _bitmap.Width;
                desiredHeight = _bitmap.Height;
            }
        }

        /// <summary>
        /// Renders the Bitmap of the Image element on the screen.
        /// </summary>
        /// <param name="dc">The DrawingContext to use for rendering.</param>
        public override void OnRender(DrawingContext dc)
        {
            Bitmap bmp = _bitmap;
            if (bmp != null)
            {
                dc.DrawImage(_bitmap, 0, 0);
            }
        }

        private Bitmap _bitmap;
    }
}


