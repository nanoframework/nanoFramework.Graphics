//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using nanoFramework.UI;

namespace nanoFramework.Presentation.Controls
{
    /// <summary>
    /// 
    /// </summary>
    public class StackPanel : Panel
    {
        /// <summary>
        /// 
        /// </summary>
        public StackPanel()
            : this(Orientation.Vertical)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orientation"></param>
        public StackPanel(Orientation orientation)
        {
            this.Orientation = orientation;
        }

        /// <summary>
        /// 
        /// </summary>
        public Orientation Orientation
        {
            get
            {
                return _orientation;
            }

            set
            {
                VerifyAccess();

                _orientation = value;
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
            desiredWidth = 0;
            desiredHeight = 0;

            bool fHorizontal = (Orientation == Orientation.Horizontal);

            //  Iterate through children.
            //
            int nChildren = Children.Count;
            for (int i = 0; i < nChildren; i++)
            {
                UIElement child = Children[i];

                if (child.Visibility != Visibility.Collapsed)
                {
                    // Measure the child.
                    // - according to Avalon specs, the stack panel should not constrain
                    //   a child's measure in the direction of the stack
                    //
                    if (fHorizontal)
                    {
                        child.Measure(Media.Constants.MaxExtent, availableHeight);
                    }
                    else
                    {
                        child.Measure(availableWidth, Media.Constants.MaxExtent);
                    }

                    // Accumulate child size.
                    //
                    int childDesiredWidth, childDesiredHeight;
                    child.GetDesiredSize(out childDesiredWidth, out childDesiredHeight);

                    if (fHorizontal)
                    {
                        desiredWidth += childDesiredWidth;
                        desiredHeight = Mathematics.Max(desiredHeight, childDesiredHeight);
                    }
                    else
                    {
                        desiredWidth = Mathematics.Max(desiredWidth, childDesiredWidth);
                        desiredHeight += childDesiredHeight;
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arrangeWidth"></param>
        /// <param name="arrangeHeight"></param>
        protected override void ArrangeOverride(int arrangeWidth, int arrangeHeight)
        {
            bool fHorizontal = (Orientation == Orientation.Horizontal);
            int previousChildSize = 0;
            int childPosition = 0;

            // Arrange and Position Children.
            //
            int nChildren = Children.Count;
            for (int i = 0; i < nChildren; ++i)
            {
                UIElement child = Children[i];
                if (child.Visibility != Visibility.Collapsed)
                {
                    childPosition += previousChildSize;
                    int childDesiredWidth, childDesiredHeight;
                    child.GetDesiredSize(out childDesiredWidth, out childDesiredHeight);

                    if (fHorizontal)
                    {
                        previousChildSize = childDesiredWidth;
                        child.Arrange(childPosition, 0, previousChildSize, Mathematics.Max(arrangeHeight, childDesiredHeight));
                    }
                    else
                    {
                        previousChildSize = childDesiredHeight;
                        child.Arrange(0, childPosition, Mathematics.Max(arrangeWidth, childDesiredWidth), previousChildSize);
                    }
                }
            }
        }

        private Orientation _orientation;
    }
}


