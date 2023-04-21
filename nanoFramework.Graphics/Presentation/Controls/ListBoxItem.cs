//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace nanoFramework.Presentation.Controls
{
    /// <summary>
    /// Represents an item in a ListBox control.
    /// </summary>
    public class ListBoxItem : ContentControl
    {
        /// <summary>
        /// Gets a value indicating whether this item is currently selected in the parent ListBox control.
        /// </summary>
        public bool IsSelected
        {
            get
            {
                return (_listBox != null && _listBox.SelectedItem == this);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this item can be selected by the user.
        /// </summary>
        public bool IsSelectable
        {
            get
            {
                return _isSelectable;
            }

            set
            {
                VerifyAccess();

                if (_isSelectable != value)
                {
                    _isSelectable = value;
                    if (!value && IsSelected)
                    {
                        _listBox.SelectedIndex = -1;
                    }
                }
            }
        }

        /// <summary>
        /// Called when the IsSelected property of this item changes.
        /// </summary>
        /// <param name="isSelected">The new value of the IsSelected property.</param>
        protected internal virtual void OnIsSelectedChanged(bool isSelected)
        {
        }

        /// <summary>
        /// Sets the parent ListBox control of this item.
        /// </summary>
        /// <param name="listbox">The ListBox control to set as the parent.</param>
        internal void SetListBox(ListBox listbox)
        {
            this._listBox = listbox;
            if (IsSelected && !IsSelectable)
            {
                _listBox.SelectedIndex = -1;
            }
        }

        private bool _isSelectable = true;
        private ListBox _listBox;
    }
}
