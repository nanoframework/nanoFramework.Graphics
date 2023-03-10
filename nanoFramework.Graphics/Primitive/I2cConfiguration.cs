//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace nanoFramework.UI
{
    /// <summary>
    /// I2C configuration.
    /// </summary>
    public struct I2cConfiguration
    {
#pragma warning disable S4487 // nanoFramework doesn't support auto-properties
        private byte _i2cBus;
        private byte _address;
        private bool _fastMode;

        /// <summary>
        /// Creates an I2C configuration.
        /// </summary>
        /// <param name="i2cBus">I2C bus.</param>
        /// <param name="address">Address.</param>
        /// <param name="fastMode">True for I2C fast mode.</param>
        public I2cConfiguration(byte i2cBus, byte address, bool fastMode)
        {
            _i2cBus = i2cBus;
            _address = address;
            _fastMode = fastMode;
        }

        /// <summary>
        /// I2C bus.
        /// </summary>
        public byte I2cBus { get => _i2cBus; set => _i2cBus = value; }

        /// <summary>
        /// Address.
        /// </summary>
        public byte Address { get => _address; set => _address = value; }

        /// <summary>
        /// True for I2C fast mode.
        /// </summary>
        public bool FastMode { get => _fastMode; set => _fastMode = value; }
#pragma warning restore S4487
    }
}
