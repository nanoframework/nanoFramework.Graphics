//
// Copyright (c) 2019 The nanoFramework project contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using System;
using System.Runtime.CompilerServices;

namespace nanoFramework.UI
{
    /// <summary>
    /// 
    /// </summary>
    public enum DisplayOrientation : int
    {
        /// <summary>
        ///     Portrain
        /// </summary>
        PORTRAIT,
        /// <summary>
        ///     Portrait 180
        /// </summary>
        PORTRAIT180,
        /// <summary>
        ///     Landscape
        /// </summary>
        LANDSCAPE,
        /// <summary>
        ///     Landscape 180
        /// </summary>
        LANDSCAPE180
    };

    /// <summary>
    /// 
    /// </summary>
    public sealed class DisplayControl : MarshalByRefObject, IDisposable
    {
        static DisplayControl()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        extern public int LongerSide
        {
            [MethodImplAttribute(MethodImplOptions.InternalCall)]
            get;
        }

        /// <summary>
        /// 
        /// </summary>
        extern public int ShorterSide
        {
            [MethodImplAttribute(MethodImplOptions.InternalCall)]
            get;
        }

        /// <summary>
        /// 
        /// </summary>
        extern public int BitsPerPixel
        {
            [MethodImplAttribute(MethodImplOptions.InternalCall)]
            get;
        }

        /// <summary>
        /// 
        /// </summary>
        extern public int Orientation
        {
            [MethodImplAttribute(MethodImplOptions.InternalCall)]
            get;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Orientation"></param>
        /// <returns></returns>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        extern public bool ChangeOrientation(ref int Orientation);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        extern private void Dispose(bool disposing);

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}

