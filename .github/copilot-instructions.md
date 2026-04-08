# Copilot Instructions for nanoFramework.Graphics

## Repository Overview

This is a **.NET nanoFramework** class library that provides graphics support for embedded/IoT devices. It targets `TargetFrameworkVersion v1.0` (nanoFramework), **not** standard .NET. Code runs on resource-constrained microcontrollers (ESP32, STM32, etc.) via the nanoFramework runtime.

Key NuGet packages published from this repo:
- `nanoFramework.Graphics` – full library with input, presentation, UI controls, windowing
- `nanoFramework.Graphics.Core` – lightweight core types (`Color`, `Point`, `Rectangle`, `Size`, `IFont`, `DisplayOrientation`)
- `nanoFramework.Graphics.Gc9A01`, `.Ili9341`, `.Ili9342`, `.Otm8009A`, `.Ssd1306`, `.Ssd1331`, `.St7735`, `.St7789` – pre-built managed display drivers

## Repository Structure

```
nanoFramework.Graphics/           # Main library project (nfproj)
  Input/                          # Button, touch input handling
  Presentation/                   # UI layer: UIElement, Window, controls, media
    Controls/                     # Canvas, Border, StackPanel, ListBox, Text, etc.
    Media/                        # Brush, Pen, DrawingContext, LinearGradientBrush, etc.
    Shapes/                       # Ellipse, Line, Rectangle, Polygon shapes
  Primitive/                      # Core primitives: Bitmap, DisplayControl, Font, GraphicDriver, SpiConfiguration, etc.
    Touch/                        # Touch input primitives
  System/                         # Application, RoutedEvent, Dispatcher-related types
  Threading/                      # Dispatcher, DispatcherTimer, DispatcherFrame

nanoFramework.Graphics.Core/      # Core types project (nfproj)
  System/Drawing/                 # Color, Point, Rectangle, Size, ColorOrder, ContentAlignment
  nanoFramework/UI/               # DisplayOrientation, IFont, Point

nanoFramework.Graphics.Core.UnitTests/   # Unit tests (nfproj, nanoFramework test framework)
  System/Drawing/                 # Tests for Color, Point, Rectangle, Size

ManagedDrivers/                   # Managed (C#) implementations of display drivers
  Gc9A01/Gc9A01.cs
  Ili9341/Ili9341.cs
  Ili9342/Ili9342.cs
  Otm8009A/Otm8009A.cs
  Ssd1306/Ssd1306.cs
  Ssd1331/Ssd1331.cs
  St7735/St7735.cs
  St7789/St7789.cs

*.nuspec                          # NuGet packaging specs for each package
*.nfproj                          # nanoFramework project files (MSBuild-based, extension .nfproj)
nanoFramework.Graphics.sln        # Solution file
azure-pipelines.yml               # CI/CD (Azure Pipelines)
version.json                      # Nerdbank.GitVersioning config (semver 2.0)
```

## Project File Format (.nfproj)

All projects use `.nfproj` files (not `.csproj`). These are MSBuild XML files with:
- `ProjectTypeGuids` including `{11A8DD76-328B-46DF-9F39-F559912D0360}` (nanoFramework)
- `<TargetFrameworkVersion>v1.0</TargetFrameworkVersion>`
- `<NanoFrameworkProjectSystemPath>$(MSBuildExtensionsPath)\nanoFramework\v1.0\</NanoFrameworkProjectSystemPath>`
- Imports from the nanoFramework project system
- `<RestorePackagesWithLockFile>true</RestorePackagesWithLockFile>` – lock files are committed
- File references use `<Compile Include="..." />` entries (not globbing)

**Important**: When adding new `.cs` files, you must also add `<Compile Include="..." />` entries to the corresponding `.nfproj` file. The project system does not auto-discover files.

## Key Namespaces

| Namespace | Location | Purpose |
|---|---|---|
| `nanoFramework.UI` | `nanoFramework.Graphics/Primitive/` | `Bitmap`, `DisplayControl`, `Font`, `GraphicDriver`, `SpiConfiguration`, `I2cConfiguration`, `ScreenConfiguration` |
| `nanoFramework.UI.GraphicDrivers` | `ManagedDrivers/*/` | Pre-built managed SPI drivers |
| `nanoFramework.Presentation` | `nanoFramework.Graphics/Presentation/` | `UIElement`, `Window`, `WindowManager`, `LayoutManager` |
| `nanoFramework.Presentation.Controls` | `Presentation/Controls/` | UI controls |
| `nanoFramework.Presentation.Media` | `Presentation/Media/` | `DrawingContext`, `Brush`, `Pen`, etc. |
| `System.Drawing` | `nanoFramework.Graphics.Core/System/Drawing/` | `Color`, `Point`, `Rectangle`, `Size` |

## nanoFramework Constraints

- **No LINQ**, no `System.Collections.Generic` (use `nanoFramework.System.Collections` from NuGet), no reflection APIs beyond basics
- **No auto-properties** in some cases – the codebase uses backing fields with `#pragma warning disable S4487` to work around nanoFramework limitations
- **`[MethodImpl(MethodImplOptions.InternalCall)]`** marks methods implemented natively in the firmware; these have no C# body
- **`MarshalByRefObject`** is the base for `Bitmap` and other native-bound types
- Memory is constrained – buffer sizes matter; `DisplayControl.Initialize()` takes an explicit `bufferSize` parameter
- `System.Runtime.CompilerServices.RuntimeHelpers` and `System.Runtime.InteropServices` are available but limited

## Display Driver Architecture

There are two types of drivers:
1. **Native drivers** – built into the firmware image (e.g., `Ili9341`, `St7789`). Preferred when available.
2. **Generic managed driver** (`GraphicDriver` class) – lets you define a driver entirely in managed C# code by providing initialization command byte sequences. Uses `GraphicDriverCommandType.Command` and `GraphicDriverCommandType.Sleep` to build byte arrays.

The `GraphicDriver` command byte array format:
```
(byte)GraphicDriverCommandType.Command, N, n0, n1, ..., nN-1
(byte)GraphicDriverCommandType.Sleep, T   // T * 10 milliseconds
```

`DisplayControl.Initialize(SpiConfiguration, ScreenConfiguration, bufferSize)` must be called before creating any `Bitmap` or rendering anything.

## Building

The build uses **Azure Pipelines** (see `azure-pipelines.yml`) on `windows-latest` with the nanoFramework build templates from the `nanoframework/nf-tools` repo. The solution file is `nanoFramework.Graphics.sln`.

**You cannot build this project locally** in the agent sandbox without the nanoFramework project system MSBuild extensions installed on Windows. Do not attempt to run `dotnet build` or `msbuild` — it will fail.

## Testing

- Unit tests are in `nanoFramework.Graphics.Core.UnitTests/` using **nanoFramework.TestFramework**
- Test classes use `[TestClass]` / `[TestMethod]` / `[DataRow]` attributes (similar to MSTest but nanoFramework-specific)
- `Assert` class is from `nanoFramework.TestFramework`
- Tests run on a nanoFramework device or emulator — **not** on the host machine
- The `nano.runsettings` file configures the test runner
- **You cannot run tests locally** in the sandbox

## NuGet Packages and Dependencies

- `packages.config` lists dependencies per project
- `packages.lock.json` files are committed and must be updated when dependencies change
- Packages are restored from NuGet.org (see `NuGet.Config`)
- Versioning uses **Nerdbank.GitVersioning** (`version.json`); version is `1.2.x` with build number from git history
- Each NuGet package has a corresponding `.nuspec` file at the root

## Code Style Conventions

- Copyright header on every file:
  ```csharp
  // Copyright (c) .NET Foundation and Contributors
  // Portions Copyright (c) Microsoft Corporation.  All rights reserved.
  // See LICENSE file in the project root for full license information.
  ```
- XML doc comments (`///`) on all public members
- No auto-properties in classes that interact with native/marshal code; use explicit backing fields
- Use `#pragma warning disable` for nanoFramework-specific limitations rather than restructuring code
- Enums representing hardware register values are typically `private` inside the driver class
- `[Flags]` enum for orientation bitmasks

## Adding a New Managed Driver

1. Create `ManagedDrivers/<DriverName>/<DriverName>.cs` in namespace `nanoFramework.UI.GraphicDrivers`
2. Add a static `GraphicDriver` property that returns a pre-configured `GraphicDriver` instance
3. Add a corresponding `.nuspec` file at the repo root following the pattern of existing nuspec files
4. Add the project to `nanoFramework.Graphics.sln`
5. Add a `class-lib-package.yml` step in `azure-pipelines.yml`

## CI/CD

- **Azure Pipelines**: `azure-pipelines.yml` — builds on `main`/`develop`/`release-*`, publishes NuGet packages
- **GitHub Actions** (`.github/workflows/`):
  - `pr-checks.yml` – checks `packages.lock.json` consistency and NuGet package currency
  - `update-dependencies.yml` / `update-dependencies-develop.yml` – automated dependency updates
  - `generate-changelog.yml` – changelog generation

## Common Pitfalls

- **Do not use `dotnet build` or standard MSBuild** – these projects require the nanoFramework project system extension
- **Always add `<Compile Include="..." />` to `.nfproj`** when creating new `.cs` files
- **Do not use LINQ** or unsupported BCL APIs – nanoFramework has a significantly reduced BCL
- **`packages.lock.json` must stay consistent** – the PR check workflow validates this
- The `MISO` pin must be configured even when not physically used (SPI constraint on ESP32)
- `DisplayControl.Initialize()` must be called before instantiating `Bitmap`
- Screen physical offset (`x`, `y` in `ScreenConfiguration`) differs from driver logical origin
