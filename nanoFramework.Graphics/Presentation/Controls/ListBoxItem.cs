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
    public class ListBoxItem : ContentControl
    {
        /// <summary>
        /// 
        /// </summary>
        public bool IsSelected
        {
            get
            {
                return (_listBox != null && _listBox.SelectedItem == this);
            }
        }

        /// <summary>
        /// 
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
        /// 
        /// </summary>
        /// <param name="isSelected"></param>
        protected internal virtual void OnIsSelectedChanged(bool isSelected)
        {
        }

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


