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
        private UIElementCollection _items;

        /// <summary>
        /// Initializes a new instance of the ListBoxItemCollection class.
        /// </summary>
        /// <param name="listBox">The ListBox that owns the ListBoxItemCollection.</param>
        /// <param name="items">The UIElementCollection to use as the basis for the ListBoxItemCollection.</param>
        public ListBoxItemCollection(ListBox listBox, UIElementCollection items)
        {
            _listBox = listBox;
            _items = items;
        }

        /// <summary>
        /// Adds a ListBoxItem to the end of the ListBoxItemCollection.
        /// </summary>
        /// <param name="item">The ListBoxItem to add to the ListBoxItemCollection.</param>
        /// <returns>The zero-based index of the ListBoxItem that was added to the ListBoxItemCollection.</returns>

        public int Add(ListBoxItem item)
        {
            int pos = _items.Add(item);
            item.SetListBox(_listBox);
            return pos;
        }

        /// <summary>
        /// Adds a UIElement to the end of the ListBoxItemCollection.
        /// </summary>
        /// <param name="element">The UIElement to add to the ListBoxItemCollection.</param>
        /// <returns>The zero-based index of the ListBoxItem that was added to the ListBoxItemCollection.</returns>
        public int Add(UIElement element)
        {
            ListBoxItem item = new ListBoxItem();
            item.Child = element;
            return Add(item);
        }

        /// <summary>
        /// Removes all items from the ListBoxItemCollection.
        /// </summary>
        public void Clear()
        {
            _items.Clear();
        }

        /// <summary>
        /// Determines whether the ListBoxItemCollection contains a specific ListBoxItem.
        /// </summary>
        /// <param name="item">The ListBoxItem to locate in the ListBoxItemCollection.</param>
        /// <returns>true if the ListBoxItem is found in the ListBoxItemCollection; otherwise, false.</returns>
        public bool Contains(ListBoxItem item)
        {
            return _items.Contains(item);
        }

        /// <summary>
        /// Gets or sets the ListBoxItem at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the ListBoxItem to get or set.</param>
        /// <returns>The ListBoxItem at the specified index.</returns>
        public ListBoxItem this[int index]
        {
            get { return (ListBoxItem)_items[index]; }
            set { _items[index] = value; value.SetListBox(_listBox); }
        }

        /// <summary>
        /// Determines the index of a specific ListBoxItem in the ListBoxItemCollection.
        /// </summary>
        /// <param name="item">The ListBoxItem to locate in the ListBoxItemCollection.</param>
        /// <returns>The zero-based index of the ListBoxItem within the ListBoxItemCollection; otherwise, -1.</returns>
        public int IndexOf(ListBoxItem item)
        {
            return _items.IndexOf(item);
        }

        /// <summary>
        /// Inserts a ListBoxItem into the ListBoxItemCollection at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which the ListBoxItem should be inserted.</param>
        /// <param name="item">The ListBoxItem to insert into the ListBoxItemCollection.</param>
        public void Insert(int index, ListBoxItem item)
        {
            _items.Insert(index, item);
            item.SetListBox(_listBox);
        }

        /// <summary>
        /// Removes the specified ListBoxItem from the collection.
        /// </summary>
        /// <param name="item">The ListBoxItem to remove.</param>
        public void Remove(ListBoxItem item)
        {
            _items.Remove(item);
            item.SetListBox(null);
        }

        /// <summary>
        /// Removes the ListBoxItem at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the ListBoxItem to remove.</param>
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
        /// Copies the entire collection to a compatible one-dimensional array, starting at the specified index of the target array.
        /// </summary>
        /// <param name="array">The one-dimensional array that is the destination of the elements copied from the collection.</param>
        /// <param name="index">The zero-based index in the destination array at which copying begins.</param>
        public void CopyTo(Array array, int index)
        {
            _items.CopyTo(array, index);
        }

        /// <summary>
        /// Gets the number of elements contained in the collection.
        /// </summary>
        public int Count
        {
            get { return _items.Count; }
        }

        /// <summary>
        /// Gets a value indicating whether access to the collection is synchronized (thread-safe).
        /// </summary>
        public bool IsSynchronized
        {
            get { return _items.IsSynchronized; }
        }

        /// <summary>
        /// Gets an object that can be used to synchronize access to the collection.
        /// </summary>
        public object SyncRoot
        {
            get { return _items.SyncRoot; }
        }

        #endregion

        #region IEnumerable Members

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator that iterates through the collection.</returns>
        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)_items).GetEnumerator();
        }

        #endregion

        private ListBox _listBox;
    }
}


