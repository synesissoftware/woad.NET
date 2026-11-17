using Woad;

Console.WriteLine($"woad.NET {LibraryVersion.VersionString}");
Console.WriteLine($"{AnsiCodes.FgGreen}Success: All systems operational{AnsiCodes.Reset}");
Console.WriteLine($"{AnsiCodes.FgYellow}Warning: Disk space reaching threshold{AnsiCodes.Reset}");
Console.WriteLine($"{AnsiCodes.FgRed}Error: Failed to connect to service{AnsiCodes.Reset}");
Console.WriteLine($"{AnsiCodes.BgBlue}{AnsiCodes.FgBrightWhite} Info banner {AnsiCodes.Reset}");
