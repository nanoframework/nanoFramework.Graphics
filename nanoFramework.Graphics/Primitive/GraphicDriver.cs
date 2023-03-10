
namespace nanoFramework.UI
{
    /// <summary>
    /// The generic graphic driver.
    /// </summary>
    public class GraphicDriver
    {
#pragma warning disable S4487 // nanoFramework doesn't support auto-properties
        private uint _width;
        private uint _height;
        private byte _bitsPerPixel;
        private byte[] _initializationSequence;
        private byte _memoryWrite;
        private byte _setColumnAddress;
        private byte _setRowAddress;
        private byte[] _powerModeNormal;
        private byte[] _powerModeSleep;
        private byte[] _orientationPortrait;
        private byte[] _orientationPortrait180;
        private byte[] _orientationLandscape;
        private byte[] _orientationLandscape180;
        private byte[] _clear;
        private byte _brightness;
        private DisplayOrientation _defaultOrientation;

        /// <summary>
        /// Gets or sets the width of the driver, it does override the Screen one if specified.
        /// </summary>
        public uint Width { get => _width; set => _width = value; }

        /// <summary>
        /// Gets or sets the height of the driver, it does override the Screen one if specified.
        /// </summary>
        public uint Height { get => _height; set => _height = value; }

        /// <summary>
        /// Gets or sets the bits per pixel of the driver, it does override the Screen one if specified.
        /// </summary>
        public byte BitsPerPixel { get => _bitsPerPixel; set => _bitsPerPixel = value; }

        /// <summary>
        /// Gets or sets the initialization sequence of the driver.
        /// </summary>
        /// <remarks>See <see cref="GraphicDriverCommandType"/> for more information. Format is the following:
        /// (byte)GraphicDriverCommandType.Command, N, n0, n1..., nN-1,
        /// where N is the number of bytes to send and n0, n1, ..., nN-1 are the bytes to send.
        /// (byte)GraphicDriverCommandType.Sleep, T,
        /// where T is the time to sleep in 10 of milliseconds.
        /// </remarks>
        public byte[] InitializationSequence { get => _initializationSequence; set => _initializationSequence = value; }

        /// <summary>
        /// Gets or sets the Memory Write command.
        /// </summary>
        public byte MemoryWrite { get => _memoryWrite; set => _memoryWrite = value; }

        /// <summary>
        /// Gets or sets the Set Column Address command.
        /// </summary>
        public byte SetColumnAddress { get => _setColumnAddress; set => _setColumnAddress = value; }

        /// <summary>
        /// Gets or sets the Set Row Address command.
        /// </summary>
        public byte SetRowAddress { get => _setRowAddress; set => _setRowAddress = value; }

        /// <summary>
        /// Gets or sets the Power Mode Normal command.
        /// </summary>
        /// <remarks>See <see cref="GraphicDriverCommandType"/> for more information. Format is the following:
        /// (byte)GraphicDriverCommandType.Command, N, n0, n1..., nN-1,
        /// where N is the number of bytes to send and n0, n1, ..., nN-1 are the bytes to send.
        /// (byte)GraphicDriverCommandType.Sleep, T,
        /// where T is the time to sleep in 10 of milliseconds.
        /// </remarks>
        public byte[] PowerModeNormal { get => _powerModeNormal; set => _powerModeNormal = value; }

        /// <summary>
        /// Gets or sets the Power Mode Sleep command.
        /// </summary>
        /// <remarks>See <see cref="GraphicDriverCommandType"/> for more information. Format is the following:
        /// (byte)GraphicDriverCommandType.Command, N, n0, n1..., nN-1,
        /// where N is the number of bytes to send and n0, n1, ..., nN-1 are the bytes to send.
        /// (byte)GraphicDriverCommandType.Sleep, T,
        /// where T is the time to sleep in 10 of milliseconds.
        /// </remarks>
        public byte[] PowerModeSleep { get => _powerModeSleep; set => _powerModeSleep = value; }

        /// <summary>
        /// Gets or sets the Orientation Portrait command. If not specifyed, nothing will be applied.
        /// </summary>
        /// <remarks>See <see cref="GraphicDriverCommandType"/> for more information. Format is the following:
        /// (byte)GraphicDriverCommandType.Command, N, n0, n1..., nN-1,
        /// where N is the number of bytes to send and n0, n1, ..., nN-1 are the bytes to send.
        /// (byte)GraphicDriverCommandType.Sleep, T,
        /// where T is the time to sleep in 10 of milliseconds.
        /// </remarks>
        public byte[] OrientationPortrait { get => _orientationPortrait; set => _orientationPortrait = value; }

        /// <summary>
        /// Gets or sets the Orientation Portrait 180 command. If not specifyed, nothing will be applied.
        /// </summary>
        /// <remarks>See <see cref="GraphicDriverCommandType"/> for more information. Format is the following:
        /// (byte)GraphicDriverCommandType.Command, N, n0, n1..., nN-1,
        /// where N is the number of bytes to send and n0, n1, ..., nN-1 are the bytes to send.
        /// (byte)GraphicDriverCommandType.Sleep, T,
        /// where T is the time to sleep in 10 of milliseconds.
        /// </remarks>
        public byte[] OrientationPortrait180 { get => _orientationPortrait180; set => _orientationPortrait180 = value; }

        /// <summary>
        /// Gets or sets the Orientation Landscape command. If not specifyed, nothing will be applied.
        /// </summary>
        /// <remarks>See <see cref="GraphicDriverCommandType"/> for more information. Format is the following:
        /// (byte)GraphicDriverCommandType.Command, N, n0, n1..., nN-1,
        /// where N is the number of bytes to send and n0, n1, ..., nN-1 are the bytes to send.
        /// (byte)GraphicDriverCommandType.Sleep, T,
        /// where T is the time to sleep in 10 of milliseconds.
        /// </remarks>
        public byte[] OrientationLandscape { get => _orientationLandscape; set => _orientationLandscape = value; }

        /// <summary>
        /// Gets or sets the Orientation Landscape 180 command. If not specifyed, nothing will be applied.
        /// </summary>
        /// <remarks>See <see cref="GraphicDriverCommandType"/> for more information. Format is the following:
        /// (byte)GraphicDriverCommandType.Command, N, n0, n1..., nN-1,
        /// where N is the number of bytes to send and n0, n1, ..., nN-1 are the bytes to send.
        /// (byte)GraphicDriverCommandType.Sleep, T,
        /// where T is the time to sleep in 10 of milliseconds.
        /// </remarks>
        public byte[] OrientationLandscape180 { get => _orientationLandscape180; set => _orientationLandscape180 = value; }

        /// <summary>
        /// Gets or sets the Clear command. If not specified, a default behavior will apply with a manual feel of the screen.
        /// </summary>
        /// <remarks>See <see cref="GraphicDriverCommandType"/> for more information. Format is the following:
        /// (byte)GraphicDriverCommandType.Command, N, n0, n1..., nN-1,
        /// where N is the number of bytes to send and n0, n1, ..., nN-1 are the bytes to send.
        /// (byte)GraphicDriverCommandType.Sleep, T,
        /// where T is the time to sleep in 10 of milliseconds.
        /// </remarks>
        public byte[] Clear { get => _clear; set => _clear = value; }

        /// <summary>
        /// Gets or sets the Brighness command.
        /// </summary>
        public byte Brightness { get => _brightness; set => _brightness = value; }

        /// <summary>
        /// Gets or sets the default orientation.
        /// </summary>
        public DisplayOrientation DefaultOrientation { get => _defaultOrientation; set => _defaultOrientation = value; }
#pragma warning restore S4487
    }
}
