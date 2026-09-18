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
dependencies** on any non-framework library.


## Installation

```bash
dotnet add package Woad
```

See [INSTALL.md](./INSTALL.md) for source checkout restore, build, and test.


## Quick start

```csharp
using Woad;

Console.WriteLine($"{AnsiCodes.FgGreen}Success!{AnsiCodes.Reset}");
Console.WriteLine($"{AnsiCodes.FgRed}Error!{AnsiCodes.Reset}");
```


## Components

The **0.0.1** release provides:

* **`AnsiCodes`** — ANSI SGR escape sequences:
  * Reset (`Reset` / `RESET`);
  * Standard foreground colours (`FgBlack`, `FgRed`, `FgGreen`, `FgYellow`, `FgBlue`, `FgMagenta`, `FgCyan`, `FgWhite`);
  * Bright foreground colours (`FgBrightBlack`, `FgBrightRed`, `FgBrightGreen`, `FgBrightYellow`, `FgBrightBlue`, `FgBrightMagenta`, `FgBrightCyan`, `FgBrightWhite`);
  * Standard background colours (`BgBlack`, `BgRed`, `BgGreen`, `BgYellow`, `BgBlue`, `BgMagenta`, `BgCyan`, `BgWhite`);
  * Bright background colours (`BgBrightBlack`, `BgBrightRed`, `BgBrightGreen`, `BgBrightYellow`, `BgBrightBlue`, `BgBrightMagenta`, `BgBrightCyan`, `BgBrightWhite`);
  * Upper-case aliases (`FG_RED`, `BG_BLUE`, etc.) matching sibling woad libraries across C, C++, Go, Python, Ruby, and Rust;
* **`LibraryVersion`** — Major, Minor, Patch, and VersionString;


## Platform support

* **.NET 8.0+** (`net8.0`);
* **.NET Standard 2.0+** (`netstandard2.0` — .NET Framework 4.6.1+, .NET Core 2.0+, Mono 5.4+);
* Fully AOT-compatible under .NET 8.0+;


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
