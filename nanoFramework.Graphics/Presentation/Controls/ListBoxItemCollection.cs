//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using System;
using System.Collections;

namespace nanoFramework.Presentation.Controls
{
    /// <summary>
    /// 
    /// </summary>
    public class ListBoxItemCollection : ICollection
    {
        UIElementCollection _items;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="listBox"></param>
        /// <param name="items"></param>
        public ListBoxItemCollection(ListBox listBox, UIElementCollection items)
        {
            _listBox = listBox;
            _items = items;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int Add(ListBoxItem item)
        {
            int pos = _items.Add(item);
            item.SetListBox(_listBox);
            return pos;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public int Add(UIElement element)
        {
            ListBoxItem item = new ListBoxItem();
            item.Child = element;
            return Add(item);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Clear()
        {
            _items.Clear();
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(ListBoxItem item)
        {
            return _items.Contains(item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public ListBoxItem this[int index]
        {
            get { return (ListBoxItem)_items[index]; }
            set { _items[index] = value; value.SetListBox(_listBox); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int IndexOf(ListBoxItem item)
        {
            return _items.IndexOf(item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="item"></param>
        public void Insert(int index, ListBoxItem item)
        {
            _items.Insert(index, item);
            item.SetListBox(_listBox);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public void Remove(ListBoxItem item)
        {
            _items.Remove(item);
            item.SetListBox(null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            if (index >= 0 && index < _items.Count)
            {
                this[index].SetListBox(null);
            }

            _items.RemoveAt(index);
        }

        #region ICollection Members

        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        public void CopyTo(Array array, int index)
        {
            _items.CopyTo(array, index);
        }

        /// <summary>
        /// 
        /// </summary>
        public int Count
        {
            get { return _items.Count; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsSynchronized
        {
            get { return _items.IsSynchronized; }
        }

        /// <summary>
        /// 
        /// </summary>
        public object SyncRoot
        {
            get { return _items.SyncRoot; }
        }

        #endregion

        #region IEnumerable Members

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)_items).GetEnumerator();
        }

        #endregion

        private ListBox _listBox;
    }
}


