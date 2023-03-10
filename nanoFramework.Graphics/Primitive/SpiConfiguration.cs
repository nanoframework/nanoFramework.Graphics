//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace nanoFramework.UI
{
    /// <summary>
    /// The Spi configuration for the scressn
    /// </summary>
    public struct SpiConfiguration
    {
#pragma warning disable S4487 // nanoFramework doesn't support auto-properties
        private byte _spiBus;
        private int _chipSelect;
        private int _dataCommand;
        private int _reset;
        private int _backLight;

        /// <summary>
        /// Creates a Spi configuration.
        /// </summary>
        /// <param name="spiBus">Spi bus.</param>
        /// <param name="chipselect">Chip select.</param>
        /// <param name="dataCommand">Data command.</param>
        /// <param name="reset">Reset.</param>
        /// <param name="backLight">Back light.</param>
        public SpiConfiguration(byte spiBus, int chipselect, int dataCommand, int reset, int backLight)
        {
            _spiBus = spiBus;
            _chipSelect = chipselect;
            _dataCommand = dataCommand;
            _reset = reset;
            _backLight = backLight;
        }

        /// <summary>Z
        /// Spi bus.
        /// </summary>
        public byte SpiBus { get => _spiBus; set => _spiBus = value; }

        /// <summary>
        /// Chip select.
        /// </summary>
        public int ChipSelect { get => _chipSelect; set => _chipSelect = value; }

        /// <summary>
        /// Data command.
        /// </summary>
        public int DataCommand { get => _dataCommand; set => _dataCommand = value; }

        /// <summary>
        /// Reset.
        /// </summary>
        public int Reset { get => _reset; set => _reset = value; }

        /// <summary>
        /// Back light
        /// </summary>
        public int BackLight { get => _backLight; set => _backLight = value; }
#pragma warning restore S4487
    }
}
