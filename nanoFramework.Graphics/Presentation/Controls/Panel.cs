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
    public class Panel : UIElement
    {
        /// <summary>
        /// 
        /// </summary>
        public UIElementCollection Children
        {
            get
            {
                return LogicalChildren;
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
            UIElementCollection children = _logicalChildren;
            if (children != null)
            {
                for (int i = 0; i < children.Count; i++)
                {
                    UIElement child = children[i];
                    child.Measure(availableWidth, availableHeight);
                    int childDesiredWidth, childDesiredHeight;
                    child.GetDesiredSize(out childDesiredWidth, out childDesiredHeight);
                    desiredWidth = Mathematics.Max(desiredWidth, childDesiredWidth);
                    desiredHeight = Mathematics.Max(desiredHeight, childDesiredHeight);
                    desiredWidth = Mathematics.Max(desiredWidth, childDesiredWidth);
                    desiredHeight = Mathematics.Max(desiredHeight, childDesiredHeight);
                }
            }
        }
    }
}


