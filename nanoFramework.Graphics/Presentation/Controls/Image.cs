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
/// 
/// </summary>
        public Image()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bmp"></param>
        public Image(Bitmap bmp)
            : this()
        {
            _bitmap = bmp;
        }

        /// <summary>
        /// 
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
        /// 
        /// </summary>
        /// <param name="availableWidth"></param>
        /// <param name="availableHeight"></param>
        /// <param name="desiredWidth"></param>
        /// <param name="desiredHeight"></param>
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
        /// 
        /// </summary>
        /// <param name="dc"></param>
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


