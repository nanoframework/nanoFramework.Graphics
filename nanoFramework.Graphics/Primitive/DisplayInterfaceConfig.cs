using System;

namespace nanoFramework.UI
{
    public struct SpiConfiguration
    {
        private byte _spiBus;
        private int _chipSelect;
        private int _dataCommand;
        private int _reset;
        private int _backLight;

        public byte SpiBus { get => _spiBus; set => _spiBus = value; }

        public int ChipSelect { get => _chipSelect; set => _chipSelect = value; }
        public int DataCommand { get => _dataCommand; set => _dataCommand = value; }
        public int Reset { get => _reset; set => _reset = value; }

        public int BackLight { get => _backLight; set => _backLight = value; }
    }

    public struct I2cConfiguration
    {
        private byte _i2cBus;
        private byte _address;
        private bool _fastMode;

        public byte I2cBus { get => _i2cBus; set => _i2cBus = value; }
        public byte Address { get => _address; set => _address = value; }
        public bool FastMode { get => _fastMode; set => _fastMode = value; }
    }
}
