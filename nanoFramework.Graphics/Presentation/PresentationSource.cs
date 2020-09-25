//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using nanoFramework.UI.Input;
using nanoFramework.UI.Threading;

namespace nanoFramework.Presentation
{
    /// <summary>
    /// Presentation source is our connection to the rest of the managed system.
    ///
    /// </summary>
    public class PresentationSource : DispatcherObject
    {
        //------------------------------------------------------
        //
        // Constructors
        //
        //------------------------------------------------------

        #region Constructors
        /// <summary>
        ///     Constructs an instance of the PresentationSource object.
        /// </summary>
        public PresentationSource()
        {
        }

        #endregion

        /// <summary>
        /// The Root UIElement for this source.
        /// </summary>
        public UIElement RootUIElement
        {
            get
            {
                return _rootUIElement;
            }

            set
            {
                VerifyAccess();

                if (_rootUIElement != value)
                {
                    UIElement oldRoot = _rootUIElement;

                    _rootUIElement = value;

                    if (value != null)
                    {
                        /*  need layout events
                          _rootUIElement.LayoutUpdated += new EventHandler(OnLayoutUpdated);
                        */
                    }

                    if (oldRoot != null)
                    {
                        /* we need layout events
                        oldRoot.LayoutUpdated -= new EventHandler(OnLayoutUpdated);
                        */
                    }

                    /* we need to generate an event here
                    RootChanged(oldRoot, value);
                    */

                    // set up the size.
                    value.Measure(Media.Constants.MaxExtent, Media.Constants.MaxExtent);

                    int desiredWidth, desiredHeight;
                    value.GetDesiredSize(out desiredWidth, out desiredHeight);
                    value.Arrange(0, 0, desiredWidth, desiredHeight);

                    // update focus.
                    Buttons.Focus(value);
                }
            }
        }

        private UIElement _rootUIElement;
    }
}


