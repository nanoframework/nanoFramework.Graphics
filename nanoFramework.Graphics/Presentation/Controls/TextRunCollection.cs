//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using nanoFramework.Presentation.Media;
using System;
using System.Collections;
using nanoFramework.UI;

namespace nanoFramework.Presentation.Controls
{ 

    /// <summary>
    /// 
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
    /// 
    /// </summary>
    public int Count
    {
        get
        {
            return _textRuns.Count;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="text"></param>
    /// <param name="font"></param>
    /// <param name="foreColor"></param>
    /// <returns></returns>
    public int Add(string text, Font font, Color foreColor)
    {
        return Add(new TextRun(text, font, foreColor));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="textRun"></param>
    /// <returns></returns>
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
    /// 
    /// </summary>
    public void Clear()
    {
        _textRuns.Clear();
        _textFlow.InvalidateMeasure();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="run"></param>
    /// <returns></returns>
    public bool Contains(TextRun run)
    {
        return _textRuns.Contains(run);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="run"></param>
    /// <returns></returns>
    public int IndexOf(TextRun run)
    {
        return _textRuns.IndexOf(run);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="index"></param>
    /// <param name="run"></param>
    public void Insert(int index, TextRun run)
    {
        _textRuns.Insert(index, run);
        _textFlow.InvalidateMeasure();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="run"></param>
    public void Remove(TextRun run)
    {
        _textRuns.Remove(run);
        _textFlow.InvalidateMeasure();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="index"></param>
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
    /// 
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
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
    /// 
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
    /// 
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
    /// 
    /// </summary>
    /// <returns></returns>
    public IEnumerator GetEnumerator()
    {
        return _textRuns.GetEnumerator();
    }

    #endregion
}
}


