# woad.NET <!-- omit in toc -->

Minimal ANSI terminal colour codes, for .NET

![Language](https://img.shields.io/badge/.NET-512BD4?style=flat&logo=dotnet&logoColor=white)
[![License](https://img.shields.io/badge/License-BSD_3--Clause-blue.svg)](https://opensource.org/licenses/BSD-3-Clause)
[![GitHub release](https://img.shields.io/github/v/release/synesissoftware/woad.NET.svg)](https://github.com/synesissoftware/woad.NET/releases/latest)
[![Last Commit](https://img.shields.io/github/last-commit/synesissoftware/woad.NET)](https://github.com/synesissoftware/woad.NET/commits/master)
[![CI](https://github.com/synesissoftware/woad.NET/actions/workflows/ci.yml/badge.svg)](https://github.com/synesissoftware/woad.NET/actions/workflows/ci.yml)
[![NuGet](https://img.shields.io/nuget/v/Woad.svg)](https://www.nuget.org/packages/Woad/)
![TFM](https://img.shields.io/badge/TFM-net8.0%20%7C%20netstandard2.0-lightgrey)


## Table of Contents <!-- omit in toc -->

- [Introduction](#introduction)
- [Developer Experience](#developer-experience)
- [Installation](#installation)
- [Quick start](#quick-start)
- [Components](#components)
- [Platform support](#platform-support)
- [Repository layout](#repository-layout)
- [Building from source](#building-from-source)
- [Examples](#examples)
- [Project Information](#project-information)
  - [Where to get help](#where-to-get-help)
  - [Contribution guidelines](#contribution-guidelines)
  - [Dependencies](#dependencies)
    - [Efferent (fan-out)](#efferent-fan-out)
    - [Afferent (fan-in)](#afferent-fan-in)
  - [Related projects](#related-projects)
  - [License](#license)


## Introduction

**woad** provides the smallest useful set of fixed ANSI SGR colour sequences
for library authors. It is not a console or TUI framework.

**woad.NET** is the **.NET** implementation.

This repository ships an SDK-style multi-target library (`net8.0`,
`netstandard2.0`) with CI and NuGet packaging. It has **no runtime
dependencies** on any non-framework library. The package is not published
to NuGet.


## Developer Experience

The .NET SDK named in **global.json** is enough. From a checkout:

```bash
dotnet test woad.NET.sln
dotnet run --project samples/Woad.NET.QuickStart
```

A sequence is emitted only when the writer supports colour:

```csharp
using Woad;

string green = Colour.SeqFor(Console.Out, AnsiCodes.FgGreen);
string reset = Colour.SeqFor(Console.Out, AnsiCodes.Reset);

Console.WriteLine($"{green}ok{reset}");
```

See [INSTALL.md](./INSTALL.md) for restore and pack, and
[`samples/Woad.NET.QuickStart`](./samples/Woad.NET.QuickStart) for the
same program. Windows virtual-terminal gating is not in **0.1.0-alpha1**.


## Installation

```bash
dotnet add package Woad
```

See [INSTALL.md](./INSTALL.md) for source checkout restore, build, and test.


## Quick start

The conditional program in **Developer Experience** is the shortest use.
Fixed sequences are also available on their own, for a caller that has
already decided to emit colour:

```csharp
using Woad;

Console.WriteLine($"{AnsiCodes.FgGreen}Success!{AnsiCodes.Reset}");
Console.WriteLine($"{AnsiCodes.FgRed}Error!{AnsiCodes.Reset}");
```


## Components

The **0.1.0-alpha1** release provides:

* **`AnsiCodes`** — ANSI SGR escape sequences:
  * Reset (`Reset` / `RESET`);
  * Bold (`Bold` / `BOLD`) and blinking (`Blinking` / `BLINKING`);
  * Standard foreground colours (`FgBlack`, `FgRed`, `FgGreen`, `FgYellow`, `FgBlue`, `FgMagenta`, `FgCyan`, `FgWhite`);
  * Bright foreground colours (`FgBrightBlack`, `FgBrightRed`, `FgBrightGreen`, `FgBrightYellow`, `FgBrightBlue`, `FgBrightMagenta`, `FgBrightCyan`, `FgBrightWhite`);
  * Standard background colours (`BgBlack`, `BgRed`, `BgGreen`, `BgYellow`, `BgBlue`, `BgMagenta`, `BgCyan`, `BgWhite`);
  * Bright background colours (`BgBrightBlack`, `BgBrightRed`, `BgBrightGreen`, `BgBrightYellow`, `BgBrightBlue`, `BgBrightMagenta`, `BgBrightCyan`, `BgBrightWhite`);
  * Upper-case aliases (`FG_RED`, `BG_BLUE`, etc.) matching sibling woad libraries across C, C++, Go, Python, Ruby, and Rust;
* **`LibraryVersion`** — Major, Minor, Patch, PreRelease, and VersionString (`0.1.0-alpha1`);
* **`Colour`** — cached policy (`ColourPolicy` returns 0, 1, or 2), `Refresh`, `SupportsColour`, and `SeqFor` on a `TextWriter`;


## Platform support

* **.NET 8.0+** (`net8.0`);
* **.NET Standard 2.0+** (`netstandard2.0` — .NET Framework 4.6.1+, .NET Core 2.0+, Mono 5.4+);
* Fully AOT-compatible under .NET 8.0+;
* Unix: a console stream that is not redirected supports colour unless the policy inhibits it or `TERM` is `dumb`. Windows virtual-terminal gating and mintty recognition are not in this alpha;


## Repository layout

* **`src/Woad.NET/`** — main library, multi-targeting `net8.0` and `netstandard2.0`;
* **`tests/Woad.NET.Tests/`** — unit tests (xUnit);
* **`samples/Woad.NET.QuickStart/`** — sample console application;
* **`build.sh`** / **`build.ps1`** — driver scripts for restore, build, test, and pack;


## Building from source

```bash
dotnet restore woad.NET.sln
dotnet build woad.NET.sln --configuration Release
dotnet test woad.NET.sln --configuration Release
```

Or `./build.sh` (Linux / macOS) / `./build.ps1` (Windows PowerShell).


## Examples

See [EXAMPLES.md](./EXAMPLES.md) and [`samples/Woad.NET.QuickStart`](./samples/Woad.NET.QuickStart).


## Project Information


### Where to get help

GitHub [Issues](https://github.com/synesissoftware/woad.NET/issues).


### Contribution guidelines

See [CONTRIBUTING.md](./CONTRIBUTING.md).


### Dependencies


#### Efferent (fan-out)

**Runtime:** None (standard library / framework only).

**Development / Build:**
* **`Microsoft.CodeAnalysis.NetAnalyzers`**;
* **`Microsoft.SourceLink.GitHub`**;
* **`xunit`**;
* **`xunit.runner.visualstudio`**;
* **`coverlet.collector`**;


#### Afferent (fan-in)

None currently. Expected integration into .NET CLI tools and diagnostic libraries.


### Related projects

* [**woad**](https://github.com/synesissoftware/woad) — C/C++ implementation;
* [**woad.Go**](https://github.com/synesissoftware/woad.Go) — Go implementation;
* [**woad.Python**](https://github.com/synesissoftware/woad.Python) — Python implementation;
* [**woad.Ruby**](https://github.com/synesissoftware/woad.Ruby) — Ruby implementation;
* [**woad.Rust**](https://github.com/synesissoftware/woad.Rust) — Rust implementation;


### License

**woad.NET** is released under the **BSD 3-Clause License**. See [LICENSE](./LICENSE).


<!-- ########################### end of file ########################### -->
