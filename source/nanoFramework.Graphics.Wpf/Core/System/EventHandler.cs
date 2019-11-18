//
// Copyright (c) 2019 The nanoFramework project contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//


// need move this into mscorlib, also get the real implementation.
using System;
using nanoFramework.Runtime.Events;

namespace nanoFramework.UI
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void EventHandler(object sender, EventArgs e);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void CancelEventHandler(object sender, CancelEventArgs e);

    /// <summary>
    /// 
    /// </summary>
    public class CancelEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        public bool Cancel;
    }
}


