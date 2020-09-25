//
// Copyright (c) .NET Foundation and Contributors
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

        static DisplayControl dc;
         static DisplayControl()
        {
            dc = new DisplayControl();
        }

        /// <summary>
        /// 
        /// </summary>
        public static int ScreenWidth
        {
            get
            {
                //return dc.Width;
                return 800;
            }
        }
        // Gets the height of the screen
        /// <summary>
        /// 
        /// </summary>
        public static int ScreenHeight
        {
            get
            {
                //return dc.Height;
                return 480;
            }
        }




        /// <summary>
        /// The screens number of pixel for the longer side.
        /// </summary>
        extern public int LongerSide
        {
            [MethodImplAttribute(MethodImplOptions.InternalCall)]
            get;
        }

        /// <summary>
        /// The screens number of pixel for the shorter side.
        /// </summary>
        extern public int ShorterSide
        {
            [MethodImplAttribute(MethodImplOptions.InternalCall)]
            get;
        }

        /// <summary>
        /// The screens number of pixel for the width based on the orientation.
        /// </summary>
        extern public int Width
        {
            [MethodImplAttribute(MethodImplOptions.InternalCall)]
            get;
        }

        /// <summary>
        /// The screens number of pixel for the height based on the orientation.
        /// </summary>
        extern public int Height
        {
            [MethodImplAttribute(MethodImplOptions.InternalCall)]
            get;
        }

        /// <summary>
        /// Currently 16 bits in RBG565 format. ( There is some 1 bit code available but untested )
        /// </summary>
        extern public int BitsPerPixel
        {
            [MethodImplAttribute(MethodImplOptions.InternalCall)]
            get;
        }

        /// <summary>
        /// The orientation landscape, portrain
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
        /// Release resources
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

