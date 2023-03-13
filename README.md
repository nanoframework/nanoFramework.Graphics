[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=nanoframework_lib-nanoFramework.Graphics&metric=alert_status)](https://sonarcloud.io/dashboard?id=nanoframework_lib-nanoFramework.Graphics) [![Reliability Rating](https://sonarcloud.io/api/project_badges/measure?project=nanoframework_lib-nanoFramework.Graphics&metric=reliability_rating)](https://sonarcloud.io/dashboard?id=nanoframework_lib-nanoFramework.Graphics) [![License](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE) [![NuGet](https://img.shields.io/nuget/dt/nanoFramework.Graphics.svg?label=NuGet&style=flat&logo=nuget)](https://www.nuget.org/packages/nanoFramework.Graphics/) [![#yourfirstpr](https://img.shields.io/badge/first--timers--only-friendly-blue.svg)](https://github.com/nanoframework/Home/blob/master/CONTRIBUTING.md)
[![Discord](https://img.shields.io/discord/478725473862549535.svg?logo=discord&logoColor=white&label=Discord&color=7289DA)](https://discord.gg/gCyBu8T)

![nanoFramework logo](https://raw.githubusercontent.com/nanoframework/Home/main/resources/logo/nanoFramework-repo-logo.png)

-----

### Welcome to the .NET **nanoFramework** Graphics repository

## Build status

| Component | Build Status | NuGet Package |
|:-|---|---|
| nanoFramework.Graphics | [![Build Status](https://dev.azure.com/nanoframework/nanoframework.Graphics/_apis/build/status/nanoFramework.Graphics?repoName=nanoframework%2FnanoFramework.Graphics&branchName=main)](https://dev.azure.com/nanoframework/nanoframework.Graphics/_build/latest?definitionId=58&repoName=nanoframework%2FnanoFramework.Graphics&branchName=main) | [![NuGet](https://img.shields.io/nuget/v/nanoFramework.Graphics.svg?label=NuGet&style=flat&logo=nuget)](https://www.nuget.org/packages/nanoFramework.Graphics/)  |

## Usage

**Important**:

- This library is still work in progress. There may be breaking changes happening while work on this library progresses.
- So far only SPI interface has been implemented.

Check the [samples](https://github.com/nanoframework/Samples#graphics-for-screens) for more detailed usage.

### Initializing the screen

It is important to understand that the driver will be loaded when the screen routing will be initialized from the managed code. Also keep in mind that most screens are actually smaller than the size the driver is capable of handling, also that the real screen can start at a position that is not the typical origin (0,0).

You **must** initialize the screen before being able to create a bitmap or display anything.

This code snippet works with the ESP32 WROVER KIT pinout, in this case, the screen size matches the driver size:

```csharp

const int backLightPin = 5;
const int chipSelect = 22;
const int dataCommand = 21;
const int reset = 18;
const int screenWidth = 320;
const int screenHeight = 240;
DisplayControl.Initialize(new SpiConfiguration(1, chipSelect, dataCommand, reset, backLightPin), new ScreenConfiguration(0, 0, screenWidth, screenHeight), screenBufferSize);
```

This code snippet is for a M5 Stick where the screen size is smaller than the driver size and starts an offset position of X=26 and Y=1 coordinate:

```csharp
int backLightPin = -1; // Not managed thru ESP32 but thru AXP192
int chipSelect = 5;
int dataCommand = 23;
int reset = 18;
Configuration.SetPinFunction(4, DeviceFunction.SPI1_MISO); // 4 is unused but necessary
Configuration.SetPinFunction(15, DeviceFunction.SPI1_MOSI);
Configuration.SetPinFunction(13, DeviceFunction.SPI1_CLOCK);
DisplayControl.Initialize(new SpiConfiguration(1, chipSelect, dataCommand, reset, backLightPin), new ScreenConfiguration(26, 1, 80, 160), 10 * 1024);
```

Note that depending on your target, especially for ESP32, you may have to setup the pins. Even if physically not used, the MISO pin **must** be setup to a valid pin.

As you can see it is possible as well not to define the backlight pin. It is the same for the rest pins. Both can be set to -1. Note that in most of the cases, both are connected and needed. In the case of the M5 Stick, the backlight pin is managed thru an AXP192. If you don't switch on the backlight pin, your screen will always be black. It is important to check how this pin can be switched on.

## Using generic graphic SPI drivers

It's now possible to use generic graphic SPI drivers. It does require to build an image with the `Generic_SPI.cpp` driver. Once the image is flashed on the device, you can give the driver commands directly from a class in managed code. When building with a specific driver, the generic driver will be ignored even if you provide it.

Here is an example based on the ST7735S driver, we've been using enum for the registers:

```csharp
private enum St7735
{
    NOP = 0x00,
    SOFTWARE_RESET = 0x01,
    POWER_STATE = 0x10,
    Sleep_Out = 0x11,
    Invertion_Off = 0x20,
    Invertion_On = 0x21,
    Gamma_Set = 0x26,
    Display_OFF = 0x28,
    Display_ON = 0x29,
    Column_Address_Set = 0x2A,
    Page_Address_Set = 0x2B,
    Memory_Write = 0x2C,
    Colour_Set = 0x2D,
    Memory_Read = 0x2E,
    Partial_Area = 0x30,
    Memory_Access_Control = 0x36,
    Pixel_Format_Set = 0x3A,
    Memory_Write_Continue = 0x3C,
    Write_Display_Brightness = 0x51,
    Frame_Rate_Control_Normal = 0xB1,
    Frame_Rate_Control_2 = 0xB2,
    Frame_Rate_Control_3 = 0xB3,
    Invert_On = 0xB4,
    Display_Function_Control = 0xB6,
    Entry_Mode_Set = 0xB7,
    Power_Control_1 = 0xC0,
    Power_Control_2 = 0xC1,
    Power_Control_3 = 0xC2,
    Power_Control_4 = 0xC3,
    Power_Control_5 = 0xC4,
    VCOM_Control_1 = 0xC5,
    VCOM_Control_2 = 0xC7,
    Power_Control_A = 0xCB,
    Power_Control_B = 0xCF,
    Positive_Gamma_Correction = 0xE0,
    Negative_Gamma_Correction = 0XE1,
    Driver_Timing_Control_A = 0xE8,
    Driver_Timing_Control_B = 0xEA,
    Power_On_Sequence = 0xED,
    Enable_3G = 0xF2,
    Pump_Ratio_Control = 0xF7,
    Power_Control_6 = 0xFC,
};

[Flags]
private enum St7735Orientation
{
    MADCTL_MH = 0x04, // sets the Horizontal Refresh, 0=Left-Right and 1=Right-Left
    MADCTL_ML = 0x10, // sets the Vertical Refresh, 0=Top-Bottom and 1=Bottom-Top
    MADCTL_MV = 0x20, // sets the Row/Column Swap, 0=Normal and 1=Swapped
    MADCTL_MX = 0x40, // sets the Column Order, 0=Left-Right and 1=Right-Left
    MADCTL_MY = 0x80, // sets the Row Order, 0=Top-Bottom and 1=Bottom-Top

    MADCTL_BGR = 0x08 // Blue-Green-Red pixel order
};
```

And build the driver like this:

```csharp
// This is your SPI configuration
var displaySpiConfig = new SpiConfiguration(
    1,
    ChipSelect,
    DataCommand,
    Reset,
    -1);

// Here we create the driver
GraphicDriver graphicDriver = new GraphicDriver()
{
    MemoryWrite = 0x2C,
    SetColumnAddress = 0x2A,
    SetRowAddress = 0x2B,
    InitializationSequence = new byte[]
    {
        (byte)GraphicDriverCommandType.Command, 1, (byte)St7735.SOFTWARE_RESET,
        // Sleep for 50 ms
        (byte)GraphicDriverCommandType.Sleep, 5,
        (byte)GraphicDriverCommandType.Command, 1, (byte)St7735.Sleep_Out,
        // Sleep for 500 ms
        (byte)GraphicDriverCommandType.Sleep, 50,
        (byte)GraphicDriverCommandType.Command, 4, (byte)St7735.Frame_Rate_Control_Normal, 0x01, 0x2C, 0x2D,
        (byte)GraphicDriverCommandType.Command, 4, (byte)St7735.Frame_Rate_Control_2, 0x01, 0x2C, 0x2D,
        (byte)GraphicDriverCommandType.Command, 7, (byte)St7735.Frame_Rate_Control_3, 0x01, 0x2C, 0x2D, 0x01, 0x2C, 0x2D,
        (byte)GraphicDriverCommandType.Command, 2, (byte)St7735.Invert_On, 0x07,
        (byte)GraphicDriverCommandType.Command, 1, (byte)St7735.Invertion_On,
        // 0x55 -> 16 bit
        (byte)GraphicDriverCommandType.Command, 2, (byte)St7735.Pixel_Format_Set, 0x55,
        (byte)GraphicDriverCommandType.Command, 4, (byte)St7735.Power_Control_1, 0xA2, 0x02, 0x84,
        (byte)GraphicDriverCommandType.Command, 2, (byte)St7735.Power_Control_2, 0xC5,
        (byte)GraphicDriverCommandType.Command, 3, (byte)St7735.Power_Control_3, 0x0A, 0x00,
        (byte)GraphicDriverCommandType.Command, 3, (byte)St7735.Power_Control_4, 0x8A, 0x2A,
        (byte)GraphicDriverCommandType.Command, 3, (byte)St7735.Power_Control_5, 0x8A, 0xEE,
        (byte)GraphicDriverCommandType.Command, 4, (byte)St7735.VCOM_Control_1, 0x0E, 0xFF, 0xFF,
        (byte)GraphicDriverCommandType.Command, 17, (byte)St7735.Positive_Gamma_Correction, 0x02, 0x1c, 0x7, 0x12, 0x37, 0x32, 0x29, 0x2d, 0x29, 0x25, 0x2B, 0x39, 0x00, 0x01, 0x03, 0x10,
        (byte)GraphicDriverCommandType.Command, 17, (byte)St7735.Negative_Gamma_Correction, 0x03, 0x1d, 0x07, 0x06, 0x2E, 0x2C, 0x29, 0x2D, 0x2E, 0x2E, 0x37, 0x3F, 0x00, 0x00, 0x02, 0x1,
        (byte)GraphicDriverCommandType.Command, 1, (byte)St7735.Sleep_Out,
        (byte)GraphicDriverCommandType.Command, 1, (byte)St7735.Display_ON,
        // Sleep 100 ms
        (byte)GraphicDriverCommandType.Sleep, 10,
        (byte)GraphicDriverCommandType.Command, 1, (byte)St7735.NOP,
        // Sleep 20 ms
        (byte)GraphicDriverCommandType.Sleep, 2,
    },
    OrientationLandscape = new byte[]
    {
        (byte)GraphicDriverCommandType.Command, 2, (byte)St7735.Memory_Access_Control, (byte)(St7735Orientation.MADCTL_MY | St7735Orientation.MADCTL_MX | St7735Orientation.MADCTL_BGR),
    },
    PowerModeNormal = new byte[]
    {
        (byte)GraphicDriverCommandType.Command, 3, (byte)St7735.POWER_STATE, 0x00, 0x00,
    },
    PowerModeSleep = new byte[]
    {
        (byte)GraphicDriverCommandType.Command, 3, (byte)St7735.POWER_STATE, 0x00, 0x01,
    },
    DefaultOrientation = DisplayOrientation.Landscape,
    Brightness = (byte)St7735.Write_Display_Brightness,
};

// And the screen configuration:
var screenConfig = new ScreenConfiguration(
    26,
    1,
    80,
    160,
    graphicDriver);

// And finally initialize the driver and the screen
var init = DisplayControl.Initialize(
    displaySpiConfig,
    screenConfig,
    1024);
```

Note that the initialization commands are mandatory. The rest of the commands are not mandatory. Now, some may be needed for a good usage of your driver.

All commands are following the same rule:

- (byte)GraphicDriverCommandType.Command, N, n0, n1, nN-1
- (byte)GraphicDriverCommandType.Sleep, T

Where N is the number of bytes to send as a command, meaning the first element n0 is always a command and then the bytes from n1 to nN-1.

It is as well possible to insert sleep time where T represent a set of 10 milliseconds. So to wait 50 milliseconds, T must be 5.

### Availability of drivers

Different drivers for different screens are available as nuget. Each nuget is named `nanoFramework.Graphics.DriverName` where `DriverName` is the name of the driver. For example `St7735`. Those nugets contains the driver(s) and also all the `nanoFramework.Graphics` library.

UIsage is quite straight forward:

```csharp
var displaySpiConfig = new SpiConfiguration(1, ChipSelect, DataCommand, Reset, -1);

// Get the predefined driver
GraphicDriver graphicDriver = St7735.GraphicDriver;

// You can adjust anything here for example:
graphicDriver.OrientationLandscape180 = new byte[]
{
    ((byte)GraphicDriverCommandType.Command, 2, (byte)St7735Reg.Memory_Access_Control, (byte)(St7735Orientation.MADCTL_MX | St7735Orientation.MADCTL_BGR),
};

var screenConfig = new ScreenConfiguration(26, 1, 80, 160, graphicDriver);

var init = DisplayControl.Initialize(displaySpiConfig, screenConfig, 1024);
```

Prefer the native implementation when it's available. Use the generic one when you don't have the competencies to rebuild your own image or you want to adjust the native driver.

The generic driver is also a great way to test and implement new drivers. It does not require to rebuild an image every time you want to test something new instead, you just adjust your managed code.

### Generic display driver limitations

The main limitation is related to the way all those SPI drivers are working with a notion of commands and data sent after with the exact same behavior to flash a buffer. If your driver is not following this pattern, there are changes that this will not work.

There is the possibility to add more behaviors like flashing directly buffers or adjust the way things are working. Please open issues or provide a PR to improve all this.

## Feedback and documentation

For documentation, providing feedback, issues and finding out how to contribute please refer to the [Home repo](https://github.com/nanoframework/Home).

Join our Discord community [here](https://discord.gg/gCyBu8T).

## Credits

The list of contributors to this project can be found at [CONTRIBUTORS](https://github.com/nanoframework/Home/blob/master/CONTRIBUTORS.md).

## License

The **nanoFramework** Class Libraries are licensed under the [MIT license](LICENSE.md).

## Code of Conduct

This project has adopted the code of conduct defined by the Contributor Covenant to clarify expected behaviour in our community.
For more information see the [.NET Foundation Code of Conduct](https://dotnetfoundation.org/code-of-conduct).

### .NET Foundation

This project is supported by the [.NET Foundation](https://dotnetfoundation.org).
