//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using nanoFramework.Presentation.Media;
using nanoFramework.UI;

namespace nanoFramework.Presentation.Shapes
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class Shape : UIElement
    {
        /// <summary>
        /// 
        /// </summary>
        public Brush Fill
        {
            get
            {
                if (_fill == null)
                {
                    _fill = new SolidColorBrush(Color.Black);
                    _fill.Opacity = Bitmap.OpacityTransparent;
                }

                return _fill;
            }

            set
            {
                _fill = value;
                Invalidate();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Pen Stroke
        {
            get
            {
                if (_stroke == null)
                {
                    _stroke = new Pen(Color.White, 0);
                }

                return _stroke;
            }

            set
            {
                _stroke = value;
                Invalidate();
            }
        }

        private Brush _fill;
        private Pen _stroke;
    }
}


