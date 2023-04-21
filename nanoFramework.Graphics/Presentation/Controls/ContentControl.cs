//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace nanoFramework.Presentation.Controls
{
    /// <summary>
    /// Represents a base class for a control that can contain a single child element.
    /// </summary>
    public abstract class ContentControl : Control
    {
        /// <summary>
        /// Gets or sets the child element of the ContentControl.
        /// </summary>
        public UIElement Child
        {
            get
            {
                if (LogicalChildren.Count > 0)
                {
                    return _logicalChildren[0];
                }
                else
                {
                    return null;
                }
            }

            set
            {
                VerifyAccess();

                LogicalChildren.Clear();
                LogicalChildren.Add(value);
            }
        }

        /// <summary>
        /// Measures the size required for the child element of the ContentControl.
        /// </summary>
        /// <param name="availableWidth">The available width that a parent element can allocate to a child element.</param>
        /// <param name="availableHeight">The available height that a parent element can allocate to a child element.</param>
        /// <param name="desiredWidth">The width required for the child element based on the available space.</param>
        /// <param name="desiredHeight">The height required for the child element based on the available space.</param>
        protected override void MeasureOverride(int availableWidth, int availableHeight, out int desiredWidth, out int desiredHeight)
        {
            UIElement child = this.Child;
            if (child != null)
            {
                child.Measure(availableWidth, availableHeight);
                child.GetDesiredSize(out desiredWidth, out desiredHeight);
            }
            else
            {
                desiredWidth = desiredHeight = 0;
            }
        }
    }
}
