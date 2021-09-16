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
    }

    /// <summary>
    /// The screen configuration in the driver.
    /// </summary>
    public struct ScreenConfiguration
    {
        private ushort _x;
        private ushort _y;
        private ushort _width;
        private ushort _height;

        /// <summary>
        /// Creates a screen configuration.
        /// </summary>
        /// <param name="x">The x position the screen starts in the driver.</param>
        /// <param name="y">The y position the screen starts in the driver.</param>
        /// <param name="width">The width of the screen starts in the driver.</param>
        /// <param name="height">The height of the screen starts in the driver.</param>
        public ScreenConfiguration(ushort x, ushort y, ushort width, ushort height)
        {
            _x = x;
            _y = y;
            _width = width;
            _height = height;
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

    }
}
