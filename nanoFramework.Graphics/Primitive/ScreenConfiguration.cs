//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace nanoFramework.UI
{    
    /// <summary>
    /// The screen configuration in the driver.
    /// </summary>
    public struct ScreenConfiguration
    {
        private ushort _x;
        private ushort _y;
        private ushort _width;
        private ushort _height;
        private GraphicDriver _graphicDriver;

        /// <summary>
        /// Creates a screen configuration.
        /// </summary>
        /// <param name="x">The x position the screen starts in the driver.</param>
        /// <param name="y">The y position the screen starts in the driver.</param>
        /// <param name="width">The width of the screen starts in the driver.</param>
        /// <param name="height">The height of the screen starts in the driver.</param>
        /// <param name="graphicDriver">The driver to use.</param>
        public ScreenConfiguration(ushort x, ushort y, ushort width, ushort height, GraphicDriver graphicDriver = null)
        {
            _x = x;
            _y = y;
            _width = width;
            _height = height;
            _graphicDriver = graphicDriver;
        }

        /// <summary>
        /// The x position the screen starts in the driver.
        /// </summary>
        public ushort X { get => _x; set => _x = value; }

        /// <summary>
        /// The y position the screen starts in the driver.
        /// </summary>
        public ushort Y { get => _y; set => _y = value; }

        /// <summary>
        /// The width of the screen starts in the driver.
        /// </summary>
        public ushort Width { get => _width; set => _width = value; }

        /// <summary>
        /// The height of the screen starts in the driver.
        /// </summary>
        public ushort Height { get => _height; set => _height = value; }

        /// <summary>
        /// The graphic driver.
        /// </summary>
        public GraphicDriver GraphicDriver { get => _graphicDriver; set => _graphicDriver = value; }
    }
}
