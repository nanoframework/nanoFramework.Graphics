//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using nanoFramework.Presentation.Media;
using System;
using System.Collections;
using nanoFramework.UI;
using System.Drawing;

namespace nanoFramework.Presentation.Controls
{
    /// <summary>
    /// Represents a collection of TextRun objects that can be added, removed, and modified.
    /// </summary>
    public class TextRunCollection : ICollection
    {
        private TextFlow _textFlow;
        private ArrayList _textRuns;

        internal TextRunCollection(TextFlow textFlow)
        {
            this._textFlow = textFlow;
            _textRuns = new ArrayList();
        }

        /// <summary>
        /// Gets the number of elements in the TextRunCollection.
        /// </summary>
        public int Count
        {
            get
            {
                return _textRuns.Count;
            }
        }

        /// <summary>
        /// Adds a TextRun object to the TextRunCollection using the specified text, font, and foreground color, and returns the index at which the new TextRun was added.
        /// </summary>
        /// <param name="text">The text for the new TextRun.</param>
        /// <param name="font">The font for the new TextRun.</param>
        /// <param name="foreColor">The foreground color for the new TextRun.</param>
        /// <returns>The index at which the new TextRun was added.</returns>
        public int Add(string text, Font font, Color foreColor)
        {
            return Add(new TextRun(text, font, foreColor));
        }

        /// <summary>
        /// Adds a TextRun object to the TextRunCollection and returns the index at which the new TextRun was added.
        /// </summary>
        /// <param name="textRun">The TextRun to add.</param>
        /// <returns>The index at which the new TextRun was added.</returns>
        public int Add(TextRun textRun)
        {
            if (textRun == null)
            {
                throw new ArgumentNullException("textRun");
            }

            int result = _textRuns.Add(textRun);
            _textFlow.InvalidateMeasure();
            return result;
        }

        /// <summary>
        /// Removes all elements from the TextRunCollection.
        /// </summary>
        public void Clear()
        {
            _textRuns.Clear();
            _textFlow.InvalidateMeasure();
        }

        /// <summary>
        /// Determines whether a specific TextRun object is in the TextRunCollection.
        /// </summary>
        /// <param name="run">The TextRun to locate in the TextRunCollection.</param>
        /// <returns>true if the TextRun is found in the TextRunCollection; otherwise, false.</returns>
        public bool Contains(TextRun run)
        {
            return _textRuns.Contains(run);
        }

        /// <summary>
        /// Searches for the specified TextRun and returns the zero-based index of the first occurrence within the entire TextRunCollection.
        /// </summary>
        /// <param name="run">The TextRun to locate in the TextRunCollection.</param>
        /// <returns>The zero-based index of the first occurrence of the TextRun within the entire TextRunCollection, if found; otherwise, -1.</returns>
        public int IndexOf(TextRun run)
        {
            return _textRuns.IndexOf(run);
        }

        /// <summary>
        /// Inserts a TextRun object into the TextRunCollection at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which the TextRun should be inserted.</param>
        /// <param name="run">The TextRun to insert.</param>
        public void Insert(int index, TextRun run)
        {
            _textRuns.Insert(index, run);
            _textFlow.InvalidateMeasure();
        }

        /// <summary>
        /// Removes the specified TextRun object from the TextRunCollection.
        /// </summary>
        /// <param name="run">The TextRun to remove.</param>
        public void Remove(TextRun run)
        {
            _textRuns.Remove(run);
            _textFlow.InvalidateMeasure();
        }

        /// <summary>
        /// Removes the TextRun object at the specified index from the TextRunCollection.
        /// </summary>
        /// <param name="index">The zero-based index of the TextRun to remove.</param>
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _textRuns.Count)
            {
                throw new ArgumentOutOfRangeException("index");
            }

            _textRuns.RemoveAt(index);

            _textFlow.InvalidateMeasure();
        }

        /// <summary>
        /// Gets or sets the TextRun object at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the TextRun to get or set.</param>
        /// <returns>The TextRun object at the specified index.</returns>
        public TextRun this[int index]
        {
            get
            {
                return (TextRun)_textRuns[index];
            }

            set
            {
                _textRuns[index] = value;
                _textFlow.InvalidateMeasure();
            }
        }

        #region ICollection Members

        /// <summary>
        /// Gets a value indicating whether access to the TextRunCollection is synchronized (thread safe). 
        /// </summary>
        public bool IsSynchronized
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        public void CopyTo(Array array, int index)
        {
            _textRuns.CopyTo(array, index);
        }

        /// <summary>
        /// Gets an object that can be used to synchronize access to the collection.
        /// </summary>
        public object SyncRoot
        {
            get
            {
                return null;
            }
        }

        #endregion

        #region IEnumerable Members

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator that iterates over the collection.</returns>
        public IEnumerator GetEnumerator()
        {
            return _textRuns.GetEnumerator();
        }

        #endregion
    }
}
