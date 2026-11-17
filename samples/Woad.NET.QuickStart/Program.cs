using Woad;

string green = Colour.SeqFor(Console.Out, AnsiCodes.FgGreen);
string reset = Colour.SeqFor(Console.Out, AnsiCodes.Reset);

Console.WriteLine($"woad.NET {LibraryVersion.VersionString}");
Console.WriteLine($"{green}ok{reset}");
