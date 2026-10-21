# woad.NET - Contributing <!-- omit in toc -->

Thank you for your interest in contributing.


## Table of Contents <!-- omit in toc -->

- [Code of conduct](#code-of-conduct)
- [Reporting issues](#reporting-issues)
- [Getting started](#getting-started)
- [Project layout](#project-layout)
- [Coding standards](#coding-standards)
- [Documentation](#documentation)
- [Pull requests](#pull-requests)
- [Releases](#releases)
- [License](#license)


## Code of conduct

Be respectful and constructive. Defect reports, feature requests, and pull
requests are welcome on [GitHub](https://github.com/synesissoftware/woad.NET).


## Reporting issues

Use [GitHub Issues](https://github.com/synesissoftware/woad.NET/issues). Include:

* **woad.NET** version (NuGet package version or release tag);
* Target framework (`net8.0`, `netstandard2.0`, or consumer TFM);
* Operating system and architecture;
* .NET runtime or SDK version;
* Minimal reproduction steps or a link to a branch;

For build failures, attach the `dotnet build` / `dotnet test` log. For
behavioural issues, show expected vs actual results.


## Getting started

1. Install the [.NET SDK](https://dotnet.microsoft.com/download) version pinned in `global.json`;
2. Clone the repository and restore dependencies:

   ```bash
   dotnet restore woad.NET.sln
   ```

3. Build and test:

   ```bash
   dotnet build woad.NET.sln
   dotnet test woad.NET.sln
   ```

   Or use the cross-platform build scripts:

   ```bash
   ./build.sh        # Linux / macOS
   ./build.ps1       # Windows PowerShell
   ```


## Project layout

```text
woad.NET/
  Directory.Build.props      # Shared MSBuild metadata and properties
  Directory.Packages.props   # Central package version management
  global.json                # Pinned .NET SDK version
  nuget.config               # Upstream package feeds
  woad.NET.sln               # Solution file
  build.sh                   # Linux/macOS build driver
  build.ps1                  # Windows PowerShell build driver
  src/
    Woad.NET/                # Main multi-target library project
      Woad.NET.csproj
      AnsiCodes.cs
      LibraryVersion.cs
  tests/
    Woad.NET.Tests/          # Unit test project (xUnit)
      Woad.NET.Tests.csproj
      AnsiCodesTests.cs
      VersionTests.cs
  samples/
    Woad.NET.QuickStart/     # Sample console application
      Woad.NET.QuickStart.csproj
      Program.cs
```


## Coding standards

* **C# code style:** Follow the repository `.editorconfig`.
* **Line length / rulers:** Rulers at column 76; wrap comments greedily where practical.
* **Lexicographic sorting:** Keep using directives, project properties, and package definitions ordered lexicographically.
* **TreatWarningsAsErrors:** Library code must build warning-free with `TreatWarningsAsErrors=true`.


## Documentation

Follow the workspace Markdown style guide (**markdown-standards**):

* Asterisks (`*`) for content list items;
* Level-1 ATX title forms with `<!-- omit in toc -->`;
* Version-first headings in **CHANGES.md**;
* Trailing semicolons on list items;
* End-of-file comment marker on all Markdown documents.


## Pull requests

1. Fork and create a branch from `dev` (or `master`);
2. Add or update tests for any changed behaviour;
3. Ensure `./build.sh` runs clean;
4. Open a pull request against `master`;


## Releases

Releases are tagged on `master` and published to NuGet.org via the
GitHub Actions release workflow.


## License

**woad.NET** is released under the **BSD 3-Clause License**. See [LICENSE](./LICENSE).


<!-- ########################### end of file ########################### -->
