// Created: 9th September 2026
// Updated: 9th September 2026

namespace Woad;

/// <summary>
///  Minimal ANSI terminal colour codes (SGR sequences) for .NET.
/// </summary>
public static class AnsiCodes
{
    // Reset

    /// <summary>Reset all attributes.</summary>
    public const string Reset = "\x1b[0m";

    // Foreground (standard)

    /// <summary>Foreground black.</summary>
    public const string FgBlack = "\x1b[30m";

    /// <summary>Foreground red.</summary>
    public const string FgRed = "\x1b[31m";

    /// <summary>Foreground green.</summary>
    public const string FgGreen = "\x1b[32m";

    /// <summary>Foreground yellow.</summary>
    public const string FgYellow = "\x1b[33m";

    /// <summary>Foreground blue.</summary>
    public const string FgBlue = "\x1b[34m";

    /// <summary>Foreground magenta.</summary>
    public const string FgMagenta = "\x1b[35m";

    /// <summary>Foreground cyan.</summary>
    public const string FgCyan = "\x1b[36m";

    /// <summary>Foreground white.</summary>
    public const string FgWhite = "\x1b[37m";

    // Foreground (bright)

    /// <summary>Foreground bright black.</summary>
    public const string FgBrightBlack = "\x1b[90m";

    /// <summary>Foreground bright red.</summary>
    public const string FgBrightRed = "\x1b[91m";

    /// <summary>Foreground bright green.</summary>
    public const string FgBrightGreen = "\x1b[92m";

    /// <summary>Foreground bright yellow.</summary>
    public const string FgBrightYellow = "\x1b[93m";

    /// <summary>Foreground bright blue.</summary>
    public const string FgBrightBlue = "\x1b[94m";

    /// <summary>Foreground bright magenta.</summary>
    public const string FgBrightMagenta = "\x1b[95m";

    /// <summary>Foreground bright cyan.</summary>
    public const string FgBrightCyan = "\x1b[96m";

    /// <summary>Foreground bright white.</summary>
    public const string FgBrightWhite = "\x1b[97m";

    // Background (standard)

    /// <summary>Background black.</summary>
    public const string BgBlack = "\x1b[40m";

    /// <summary>Background red.</summary>
    public const string BgRed = "\x1b[41m";

    /// <summary>Background green.</summary>
    public const string BgGreen = "\x1b[42m";

    /// <summary>Background yellow.</summary>
    public const string BgYellow = "\x1b[43m";

    /// <summary>Background blue.</summary>
    public const string BgBlue = "\x1b[44m";

    /// <summary>Background magenta.</summary>
    public const string BgMagenta = "\x1b[45m";

    /// <summary>Background cyan.</summary>
    public const string BgCyan = "\x1b[46m";

    /// <summary>Background white.</summary>
    public const string BgWhite = "\x1b[47m";

    // Background (bright)

    /// <summary>Background bright black.</summary>
    public const string BgBrightBlack = "\x1b[100m";

    /// <summary>Background bright red.</summary>
    public const string BgBrightRed = "\x1b[101m";

    /// <summary>Background bright green.</summary>
    public const string BgBrightGreen = "\x1b[102m";

    /// <summary>Background bright yellow.</summary>
    public const string BgBrightYellow = "\x1b[103m";

    /// <summary>Background bright blue.</summary>
    public const string BgBrightBlue = "\x1b[104m";

    /// <summary>Background bright magenta.</summary>
    public const string BgBrightMagenta = "\x1b[105m";

    /// <summary>Background bright cyan.</summary>
    public const string BgBrightCyan = "\x1b[106m";

    /// <summary>Background bright white.</summary>
    public const string BgBrightWhite = "\x1b[107m";

    // --- Upper-case aliases for cross-language / woad family consistency ---

    /// <summary>Reset all attributes (alias for <see cref="Reset"/>).</summary>
    public const string RESET = Reset;

    /// <summary>Foreground black (alias for <see cref="FgBlack"/>).</summary>
    public const string FG_BLACK = FgBlack;

    /// <summary>Foreground red (alias for <see cref="FgRed"/>).</summary>
    public const string FG_RED = FgRed;

    /// <summary>Foreground green (alias for <see cref="FgGreen"/>).</summary>
    public const string FG_GREEN = FgGreen;

    /// <summary>Foreground yellow (alias for <see cref="FgYellow"/>).</summary>
    public const string FG_YELLOW = FgYellow;

    /// <summary>Foreground blue (alias for <see cref="FgBlue"/>).</summary>
    public const string FG_BLUE = FgBlue;

    /// <summary>Foreground magenta (alias for <see cref="FgMagenta"/>).</summary>
    public const string FG_MAGENTA = FgMagenta;

    /// <summary>Foreground cyan (alias for <see cref="FgCyan"/>).</summary>
    public const string FG_CYAN = FgCyan;

    /// <summary>Foreground white (alias for <see cref="FgWhite"/>).</summary>
    public const string FG_WHITE = FgWhite;

    /// <summary>Foreground bright black (alias for <see cref="FgBrightBlack"/>).</summary>
    public const string FG_BRIGHT_BLACK = FgBrightBlack;

    /// <summary>Foreground bright red (alias for <see cref="FgBrightRed"/>).</summary>
    public const string FG_BRIGHT_RED = FgBrightRed;

    /// <summary>Foreground bright green (alias for <see cref="FgBrightGreen"/>).</summary>
    public const string FG_BRIGHT_GREEN = FgBrightGreen;

    /// <summary>Foreground bright yellow (alias for <see cref="FgBrightYellow"/>).</summary>
    public const string FG_BRIGHT_YELLOW = FgBrightYellow;

    /// <summary>Foreground bright blue (alias for <see cref="FgBrightBlue"/>).</summary>
    public const string FG_BRIGHT_BLUE = FgBrightBlue;

    /// <summary>Foreground bright magenta (alias for <see cref="FgBrightMagenta"/>).</summary>
    public const string FG_BRIGHT_MAGENTA = FgBrightMagenta;

    /// <summary>Foreground bright cyan (alias for <see cref="FgBrightCyan"/>).</summary>
    public const string FG_BRIGHT_CYAN = FgBrightCyan;

    /// <summary>Foreground bright white (alias for <see cref="FgBrightWhite"/>).</summary>
    public const string FG_BRIGHT_WHITE = FgBrightWhite;

    /// <summary>Background black (alias for <see cref="BgBlack"/>).</summary>
    public const string BG_BLACK = BgBlack;

    /// <summary>Background red (alias for <see cref="BgRed"/>).</summary>
    public const string BG_RED = BgRed;

    /// <summary>Background green (alias for <see cref="BgGreen"/>).</summary>
    public const string BG_GREEN = BgGreen;

    /// <summary>Background yellow (alias for <see cref="BgYellow"/>).</summary>
    public const string BG_YELLOW = BgYellow;

    /// <summary>Background blue (alias for <see cref="BgBlue"/>).</summary>
    public const string BG_BLUE = BgBlue;

    /// <summary>Background magenta (alias for <see cref="BgMagenta"/>).</summary>
    public const string BG_MAGENTA = BgMagenta;

    /// <summary>Background cyan (alias for <see cref="BgCyan"/>).</summary>
    public const string BG_CYAN = BgCyan;

    /// <summary>Background white (alias for <see cref="BgWhite"/>).</summary>
    public const string BG_WHITE = BgWhite;

    /// <summary>Background bright black (alias for <see cref="BgBrightBlack"/>).</summary>
    public const string BG_BRIGHT_BLACK = BgBrightBlack;

    /// <summary>Background bright red (alias for <see cref="BgBrightRed"/>).</summary>
    public const string BG_BRIGHT_RED = BgBrightRed;

    /// <summary>Background bright green (alias for <see cref="BgBrightGreen"/>).</summary>
    public const string BG_BRIGHT_GREEN = BgBrightGreen;

    /// <summary>Background bright yellow (alias for <see cref="BgBrightYellow"/>).</summary>
    public const string BG_BRIGHT_YELLOW = BgBrightYellow;

    /// <summary>Background bright blue (alias for <see cref="BgBrightBlue"/>).</summary>
    public const string BG_BRIGHT_BLUE = BgBrightBlue;

    /// <summary>Background bright magenta (alias for <see cref="BgBrightMagenta"/>).</summary>
    public const string BG_BRIGHT_MAGENTA = BgBrightMagenta;

    /// <summary>Background bright cyan (alias for <see cref="BgBrightCyan"/>).</summary>
    public const string BG_BRIGHT_CYAN = BgBrightCyan;

    /// <summary>Background bright white (alias for <see cref="BgBrightWhite"/>).</summary>
    public const string BG_BRIGHT_WHITE = BgBrightWhite;
}
