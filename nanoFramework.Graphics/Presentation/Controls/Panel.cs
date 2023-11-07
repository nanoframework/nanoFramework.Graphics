//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using System;
using nanoFramework.UI;

namespace nanoFramework.Presentation.Controls
{
    /// <summary>
    /// Represents a container that can contain multiple child elements.
    /// </summary>
    public class Panel : UIElement
    {
        /// <summary>
        /// Gets the collection of child elements of this panel.
        /// </summary>
        public UIElementCollection Children
        {
            get
            {
                return LogicalChildren;
            }
        }

        /// <summary>
        /// Measures the size required for this panel and its child elements.
        /// </summary>
        /// <param name="availableWidth">The available width for this panel.</param>
        /// <param name="availableHeight">The available height for this panel.</param>
        /// <param name="desiredWidth">The desired width of this panel.</param>
        /// <param name="desiredHeight">The desired height of this panel.</param>

        protected override void MeasureOverride(int availableWidth, int availableHeight, out int desiredWidth, out int desiredHeight)
        {
            desiredWidth = desiredHeight = 0;
            UIElementCollection children = _logicalChildren;
            if (children != null)
            {
                for (int i = 0; i < children.Count; i++)
                {
                    UIElement child = children[i];
                    child.Measure(availableWidth, availableHeight);
                    int childDesiredWidth, childDesiredHeight;
                    child.GetDesiredSize(out childDesiredWidth, out childDesiredHeight);
                    desiredWidth = MathInternal.Max(desiredWidth, childDesiredWidth);
                    desiredHeight = MathInternal.Max(desiredHeight, childDesiredHeight);
                    desiredWidth = MathInternal.Max(desiredWidth, childDesiredWidth);
                    desiredHeight = MathInternal.Max(desiredHeight, childDesiredHeight);
                }
            }
        }
    }
}
