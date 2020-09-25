//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace nanoFramework.Presentation.Controls
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class ContentControl : Control
    {
        /// <summary>
        /// 
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
        /// 
        /// </summary>
        /// <param name="availableWidth"></param>
        /// <param name="availableHeight"></param>
        /// <param name="desiredWidth"></param>
        /// <param name="desiredHeight"></param>
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


