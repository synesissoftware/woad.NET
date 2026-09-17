using Woad;

using Xunit;

namespace Woad.Tests;

public sealed class AnsiCodesTests
{
    private static readonly string[] AllCodes =
    [
        AnsiCodes.Reset,
        AnsiCodes.FgBlack,
        AnsiCodes.FgRed,
        AnsiCodes.FgGreen,
        AnsiCodes.FgYellow,
        AnsiCodes.FgBlue,
        AnsiCodes.FgMagenta,
        AnsiCodes.FgCyan,
        AnsiCodes.FgWhite,
        AnsiCodes.FgBrightBlack,
        AnsiCodes.FgBrightRed,
        AnsiCodes.FgBrightGreen,
        AnsiCodes.FgBrightYellow,
        AnsiCodes.FgBrightBlue,
        AnsiCodes.FgBrightMagenta,
        AnsiCodes.FgBrightCyan,
        AnsiCodes.FgBrightWhite,
        AnsiCodes.BgBlack,
        AnsiCodes.BgRed,
        AnsiCodes.BgGreen,
        AnsiCodes.BgYellow,
        AnsiCodes.BgBlue,
        AnsiCodes.BgMagenta,
        AnsiCodes.BgCyan,
        AnsiCodes.BgWhite,
        AnsiCodes.BgBrightBlack,
        AnsiCodes.BgBrightRed,
        AnsiCodes.BgBrightGreen,
        AnsiCodes.BgBrightYellow,
        AnsiCodes.BgBrightBlue,
        AnsiCodes.BgBrightMagenta,
        AnsiCodes.BgBrightCyan,
        AnsiCodes.BgBrightWhite,
    ];

    [Fact]
    public void Reset_is_escape_bracket_zero_m()
    {
        Assert.Equal("\x1b[0m", AnsiCodes.Reset);
        Assert.Equal(AnsiCodes.Reset, AnsiCodes.RESET);
    }

    [Fact]
    public void FgRed_is_escape_bracket_31_m()
    {
        Assert.Equal("\x1b[31m", AnsiCodes.FgRed);
        Assert.Equal(AnsiCodes.FgRed, AnsiCodes.FG_RED);
    }

    [Fact]
    public void BgBlue_is_escape_bracket_44_m()
    {
        Assert.Equal("\x1b[44m", AnsiCodes.BgBlue);
        Assert.Equal(AnsiCodes.BgBlue, AnsiCodes.BG_BLUE);
    }

    [Fact]
    public void All_codes_start_with_csi_and_end_with_m()
    {
        foreach (string code in AllCodes)
        {
            Assert.StartsWith("\x1b[", code);
            Assert.EndsWith("m", code);
        }
    }

    [Fact]
    public void Aliases_match_pascal_case_constants()
    {
        Assert.Equal(AnsiCodes.FgBlack, AnsiCodes.FG_BLACK);
        Assert.Equal(AnsiCodes.FgGreen, AnsiCodes.FG_GREEN);
        Assert.Equal(AnsiCodes.FgYellow, AnsiCodes.FG_YELLOW);
        Assert.Equal(AnsiCodes.FgMagenta, AnsiCodes.FG_MAGENTA);
        Assert.Equal(AnsiCodes.FgCyan, AnsiCodes.FG_CYAN);
        Assert.Equal(AnsiCodes.FgWhite, AnsiCodes.FG_WHITE);

        Assert.Equal(AnsiCodes.FgBrightBlack, AnsiCodes.FG_BRIGHT_BLACK);
        Assert.Equal(AnsiCodes.FgBrightRed, AnsiCodes.FG_BRIGHT_RED);
        Assert.Equal(AnsiCodes.FgBrightGreen, AnsiCodes.FG_BRIGHT_GREEN);
        Assert.Equal(AnsiCodes.FgBrightYellow, AnsiCodes.FG_BRIGHT_YELLOW);
        Assert.Equal(AnsiCodes.FgBrightBlue, AnsiCodes.FG_BRIGHT_BLUE);
        Assert.Equal(AnsiCodes.FgBrightMagenta, AnsiCodes.FG_BRIGHT_MAGENTA);
        Assert.Equal(AnsiCodes.FgBrightCyan, AnsiCodes.FG_BRIGHT_CYAN);
        Assert.Equal(AnsiCodes.FgBrightWhite, AnsiCodes.FG_BRIGHT_WHITE);

        Assert.Equal(AnsiCodes.BgBlack, AnsiCodes.BG_BLACK);
        Assert.Equal(AnsiCodes.BgRed, AnsiCodes.BG_RED);
        Assert.Equal(AnsiCodes.BgGreen, AnsiCodes.BG_GREEN);
        Assert.Equal(AnsiCodes.BgYellow, AnsiCodes.BG_YELLOW);
        Assert.Equal(AnsiCodes.BgMagenta, AnsiCodes.BG_MAGENTA);
        Assert.Equal(AnsiCodes.BgCyan, AnsiCodes.BG_CYAN);
        Assert.Equal(AnsiCodes.BgWhite, AnsiCodes.BG_WHITE);

        Assert.Equal(AnsiCodes.BgBrightBlack, AnsiCodes.BG_BRIGHT_BLACK);
        Assert.Equal(AnsiCodes.BgBrightRed, AnsiCodes.BG_BRIGHT_RED);
        Assert.Equal(AnsiCodes.BgBrightGreen, AnsiCodes.BG_BRIGHT_GREEN);
        Assert.Equal(AnsiCodes.BgBrightYellow, AnsiCodes.BG_BRIGHT_YELLOW);
        Assert.Equal(AnsiCodes.BgBrightBlue, AnsiCodes.BG_BRIGHT_BLUE);
        Assert.Equal(AnsiCodes.BgBrightMagenta, AnsiCodes.BG_BRIGHT_MAGENTA);
        Assert.Equal(AnsiCodes.BgBrightCyan, AnsiCodes.BG_BRIGHT_CYAN);
        Assert.Equal(AnsiCodes.BgBrightWhite, AnsiCodes.BG_BRIGHT_WHITE);
    }
}
