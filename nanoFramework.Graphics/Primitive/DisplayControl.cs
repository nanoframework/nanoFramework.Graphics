//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using System.Runtime.CompilerServices;

namespace nanoFramework.UI
{
    /// <summary>
    /// Display orientation. No all display drivers support every orientation.
    /// </summary>
    public enum DisplayOrientation : int
    {
        /// <summary>
        ///     Portrait
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
    /// Display Control.  
    /// </summary>
    public static class DisplayControl
    {
        static Bitmap _fullScreen = null;

        /// <summary>
        /// Returns a bitmap the size of the current display. 
        /// </summary>
        public static Bitmap FullScreen
        {
            get
            {
                if (_fullScreen == null)
                {
                    _fullScreen = new Bitmap(ScreenWidth, ScreenHeight);
                }
                return _fullScreen;
            }
        }

        /// <summary>
        /// The screens number of pixels for the longer side.
        /// </summary>
        extern static public int LongerSide
        {
            [MethodImplAttribute(MethodImplOptions.InternalCall)]
            get;
        }

        /// <summary>
        /// The screens number of pixels for the shorter side.
        /// </summary>
        extern static public int ShorterSide
        {
            [MethodImplAttribute(MethodImplOptions.InternalCall)]
            get;
        }

        /// <summary>
        /// The displays number of pixel for the width based on the orientation.
        /// </summary>
        extern static public int ScreenWidth
        {
            [MethodImplAttribute(MethodImplOptions.InternalCall)]
            get;
        }

        /// <summary>
        /// The displays number of pixel for the height based on the orientation.
        /// </summary>
        extern static public int ScreenHeight
        {
            [MethodImplAttribute(MethodImplOptions.InternalCall)]
            get;
        }

        /// <summary>
        /// Currently 16 bits in RBG565 format. ( There is some 1 bit code available but untested )
        /// </summary>
        extern static public int BitsPerPixel
        {
            [MethodImplAttribute(MethodImplOptions.InternalCall)]
            get;
        }

        /// <summary>
        /// Return the current display orientation landscape, portrait.
        /// </summary>
        extern static public DisplayOrientation Orientation
        {
            [MethodImplAttribute(MethodImplOptions.InternalCall)]
            get;
        }

        /// <summary>
        /// Change the orientation of the display.
        /// </summary>
        /// <remarks>
        /// When the orientation is changed the display canvas is disposed and recreated with the new dimensions
        /// when DisplayControl.FullScreen is next called.
        /// </remarks>
        /// <param name="Orientation">New Orientation</param>
        /// <returns>True if the orientation was supported and changed.</returns>
        static public bool ChangeOrientation(DisplayOrientation Orientation)
        {
            bool result = NativeChangeOrientation(Orientation);
            // if change happened then destroy bitmap as it needs to be recreated with new dimensions.
            if (result && _fullScreen != null)
            {
                _fullScreen.Dispose();
                _fullScreen = null;
            }
            return result;
        }

        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        private extern static bool NativeChangeOrientation(DisplayOrientation Orientation);
    }
}

