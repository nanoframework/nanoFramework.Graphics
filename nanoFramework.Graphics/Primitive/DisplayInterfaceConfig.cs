using System;

namespace nanoFramework.UI
{
    /// <summary>
    /// The Spi configuration for the scressn
    /// </summary>
    public struct SpiConfiguration
    {
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
    }

    /// <summary>
    /// I2C configuration.
    /// </summary>
    public struct I2cConfiguration
    {
        private byte _i2cBus;
        private byte _address;
        private bool _fastMode;

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
    }
}
