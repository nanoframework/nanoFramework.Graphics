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
