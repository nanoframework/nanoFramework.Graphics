//
// Copyright (c) 2019 The nanoFramework project contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace nanoFramework.UI
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class SystemMetrics
    {
        // Gets the color depth of the screen
        // color depth isn't the whole story, this needs to be improved.
        /// <summary>
        /// 
        /// </summary>
        public static int ScreenColorDepth
        {
            get
            {
 //               int bpp, orientation, height, width;
 // NetMF         Microsoft.SPOT.Hardware.HardwareProvider hwProvider = Microsoft.SPOT.Hardware.HardwareProvider.HwProvider;
 //               hwProvider.GetLCDMetrics(out width, out height, out bpp, out orientation);

// New
                DisplayControl dc = new DisplayControl();
                int bpp = dc.BitsPerPixel;
                
                return bpp;
            }
        }
        // Gets the width of the screen
        /// <summary>
        /// 
        /// </summary>
        public static int ScreenWidth
        {
            get
            {
//           int bpp, orientation, height, width;
// NetMF     Microsoft.SPOT.Hardware.HardwareProvider hwProvider = Microsoft.SPOT.Hardware.HardwareProvider.HwProvider;
//           hwProvider.GetLCDMetrics(out width, out height, out bpp, out orientation);           
                

// New
                DisplayControl dc = new DisplayControl();
                int width = dc.LongerSide;
                return width;
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
//          int bpp, orientation, height, width;
// NetMf    HardwareProvider hwProvider = HardwareProvider.HwProvider;
//          hwProvider.GetLCDMetrics(out width, out height, out bpp, out orientation);

// New
                int height;
                DisplayControl dc = new DisplayControl();
                height = dc.ShorterSide;
                
                return height;
            }
        }
    }
}


