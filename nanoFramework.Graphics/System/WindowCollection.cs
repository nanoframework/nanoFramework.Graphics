//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using nanoFramework.Presentation;
using System;
using System.Collections;
using System.Diagnostics;

namespace nanoFramework.UI
{
    /// <summary>
    /// WindowCollection can be used to interate over all the windows that have been
    /// opened in the current application.
    /// </summary>
    //CONSIDER: Should this be a sealed class?
    public sealed class WindowCollection : ICollection
    {
        private ArrayList _list;

        #region Public Methods

        /// <summary>
        /// Default constructor for the WindowCollection class.
        /// </summary>
        public WindowCollection()
        {
            _list = new ArrayList();
            _list.Capacity = 1;
        }

        /// <summary>
        /// Internal constructor for the WindowCollection class that takes a count parameter.
        /// </summary>
        /// <param name="count">The count of windows to initialize the collection with.</param>
        internal WindowCollection(int count)
        {
            //Debug.Assert(count >= 0, "count must not be less than zero");
            _list = new ArrayList();
            _list.Capacity = 1;
        }

        #endregion Public Methods

        #region Operator overload

        /// <summary>
        /// Gets the Window object at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the window to retrieve.</param>
        /// <returns>The Window object at the specified index.</returns>
        public Window this[int index]
        {
            get
            {
                return _list[index] as Window;
            }
        }

        #endregion Operator overload

        #region IEnumerable implementation

        /// <summary>
        /// Returns an enumerator that iterates through the WindowCollection.
        /// </summary>
        /// <returns>An IEnumerator object that can be used to iterate through the collection.</returns>
        public IEnumerator GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        #endregion IEnumerable implementation

        #region ICollection implementation

        /// <summary>
        /// Copies the entire WindowCollection to a compatible one-dimensional Array, starting at the specified index of the target array.
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from WindowCollection. The Array must have zero-based indexing.</param>
        /// <param name="index">The zero-based index in the array at which copying begins.</param>
        void ICollection.CopyTo(Array array, int index)
        {
            _list.CopyTo(array, index);
        }

        /// <summary>
        /// Copies the elements of the WindowCollection to an Array, starting at a particular Array index.
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from WindowCollection.</param>
        /// <param name="index">The zero-based index in array at which copying begins.</param>
        public void CopyTo(Window[] array, int index)
        {
            _list.CopyTo(array, index);
        }

        /// <summary>
        /// Gets the number of windows contained in the WindowCollection.
        /// </summary>
        public int Count
        {
            get
            {
                return _list.Count;
            }
        }

        /// <summary>
        /// Gets a value indicating whether access to the WindowCollection is synchronized (thread safe).
        /// </summary>
        public bool IsSynchronized
        {
            get
            {
                return _list.IsSynchronized;
            }
        }

        /// <summary>
        /// Gets an object that can be used to synchronize access to the WindowCollection.
        /// </summary>
        public Object SyncRoot
        {
            get
            {
                return _list.SyncRoot;
            }
        }

        #endregion ICollection implementation

        #region Internal Methods

        /// <summary>
        /// Creates a new WindowCollection that is a copy of the current instance.
        /// </summary>
        internal WindowCollection Clone()
        {
            WindowCollection clone;
            lock (_list.SyncRoot)
            {
                clone = new WindowCollection(_list.Count);
                for (int i = 0; i < _list.Count; i++)
                {
                    clone._list.Add(_list[i]);
                }
            }

            return clone;
        }

        /// <summary>
        /// Removes the specified window from the WindowCollection.
        /// </summary>
        /// <param name="win">The window to remove.</param>
        internal void Remove(Window win)
        {
            _list.Remove(win);
        }

        /// <summary>
        /// Adds the specified window to the WindowCollection.
        /// </summary>
        /// <param name="win">The window to add.</param>
        /// <returns>The index at which the window was added.</returns>
        internal int Add(Window win)
        {
            return _list.Add(win);
        }

        /// <summary>
        /// Determines whether the specified window is present in the WindowCollection.
        /// </summary>
        /// <param name="win">The window to check for.</param>
        /// <returns>True if the window is present, false otherwise.</returns>
        internal bool HasItem(Window win)
        {
            lock (_list.SyncRoot)
            {
                for (int i = 0; i < _list.Count; i++)
                {
                    if (_list[i] == win)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        #endregion Internal Methods
    }
}
