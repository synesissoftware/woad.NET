using Woad;

using Xunit;

namespace Woad.Tests;

public sealed class ColourPolicyTests : IDisposable
{
    private static readonly string[] Names =
    [
        "CLICOLOR",
        "CLICOLOR_FORCE",
        "FORCE_COLOR",
        "NO_COLOR",
        "TERM",
        "WOAD_COLOR",
        "WOAD_COLOUR",
    ];

    private readonly string?[] saved;

    public ColourPolicyTests()
    {
        saved = new string?[Names.Length];

        for (int i = 0; i < Names.Length; i++)
        {
            saved[i] = Environment.GetEnvironmentVariable(Names[i]);
            Environment.SetEnvironmentVariable(Names[i], null);
        }

        Colour.Refresh();
    }

    public void Dispose()
    {
        for (int i = 0; i < Names.Length; i++)
        {
            Environment.SetEnvironmentVariable(Names[i], saved[i]);
        }

        Colour.Refresh();
    }

    [Fact]
    public void Row_01_none_terminal_auto_yes()
    {
        AssertRow(attached: true, Colour.PolicyAuto, expectedColour: true);
    }

    [Fact]
    public void Row_02_none_not_terminal_auto_no()
    {
        AssertRow(attached: false, Colour.PolicyAuto, expectedColour: false);
    }

    [Fact]
    public void Row_03_term_dumb_terminal_auto_no()
    {
        Environment.SetEnvironmentVariable("TERM", "dumb");
        Colour.Refresh();
        AssertRow(attached: true, Colour.PolicyAuto, expectedColour: false);
    }

    [Fact]
    public void Row_04_term_DUMB_terminal_auto_no()
    {
        Environment.SetEnvironmentVariable("TERM", "DUMB");
        Colour.Refresh();
        AssertRow(attached: true, Colour.PolicyAuto, expectedColour: false);
    }

    [Fact]
    public void Row_05_woad_colour_1_not_terminal_force_yes()
    {
        Environment.SetEnvironmentVariable("WOAD_COLOUR", "1");
        Colour.Refresh();
        AssertRow(attached: false, Colour.PolicyForce, expectedColour: true);
    }

    [Fact]
    public void Row_06_woad_color_always_not_terminal_force_yes()
    {
        Environment.SetEnvironmentVariable("WOAD_COLOR", "always");
        Colour.Refresh();
        AssertRow(attached: false, Colour.PolicyForce, expectedColour: true);
    }

    [Fact]
    public void Row_07_woad_colour_never_terminal_inhibit_no()
    {
        Environment.SetEnvironmentVariable("WOAD_COLOUR", "never");
        Colour.Refresh();
        AssertRow(attached: true, Colour.PolicyInhibit, expectedColour: false);
    }

    [Fact]
    public void Row_08_woad_colour_auto_terminal_auto_yes()
    {
        Environment.SetEnvironmentVariable("WOAD_COLOUR", "auto");
        Colour.Refresh();
        AssertRow(attached: true, Colour.PolicyAuto, expectedColour: true);
    }

    [Fact]
    public void Row_09_woad_colour_auto_not_terminal_auto_no()
    {
        Environment.SetEnvironmentVariable("WOAD_COLOUR", "auto");
        Colour.Refresh();
        AssertRow(attached: false, Colour.PolicyAuto, expectedColour: false);
    }

    [Fact]
    public void Row_10_woad_colour_purple_terminal_auto_yes()
    {
        Environment.SetEnvironmentVariable("WOAD_COLOUR", "purple");
        Colour.Refresh();
        AssertRow(attached: true, Colour.PolicyAuto, expectedColour: true);
    }

    [Fact]
    public void Row_11_no_color_outranks_clicolor_force()
    {
        Environment.SetEnvironmentVariable("NO_COLOR", "1");
        Environment.SetEnvironmentVariable("CLICOLOR_FORCE", "1");
        Colour.Refresh();
        AssertRow(attached: true, Colour.PolicyInhibit, expectedColour: false);
    }

    [Fact]
    public void Row_12_clicolor_force_1_not_terminal_force_yes()
    {
        Environment.SetEnvironmentVariable("CLICOLOR_FORCE", "1");
        Colour.Refresh();
        AssertRow(attached: false, Colour.PolicyForce, expectedColour: true);
    }

    [Fact]
    public void Row_13_clicolor_force_0_then_clicolor_0()
    {
        Environment.SetEnvironmentVariable("CLICOLOR_FORCE", "0");
        Environment.SetEnvironmentVariable("CLICOLOR", "0");
        Colour.Refresh();
        AssertRow(attached: true, Colour.PolicyInhibit, expectedColour: false);
    }

    [Fact]
    public void Row_14_force_color_1_not_terminal_force_yes()
    {
        Environment.SetEnvironmentVariable("FORCE_COLOR", "1");
        Colour.Refresh();
        AssertRow(attached: false, Colour.PolicyForce, expectedColour: true);
    }

    [Fact]
    public void Row_15_force_color_false_then_clicolor_0()
    {
        Environment.SetEnvironmentVariable("FORCE_COLOR", "false");
        Environment.SetEnvironmentVariable("CLICOLOR", "0");
        Colour.Refresh();
        AssertRow(attached: true, Colour.PolicyInhibit, expectedColour: false);
    }

    [Fact]
    public void Row_16_force_color_FALSE_not_terminal_auto_no()
    {
        Environment.SetEnvironmentVariable("FORCE_COLOR", "FALSE");
        Colour.Refresh();
        AssertRow(attached: false, Colour.PolicyAuto, expectedColour: false);
    }

    [Fact]
    public void Row_17_force_color_0_terminal_auto_yes()
    {
        Environment.SetEnvironmentVariable("FORCE_COLOR", "0");
        Colour.Refresh();
        AssertRow(attached: true, Colour.PolicyAuto, expectedColour: true);
    }

    [Fact]
    public void Row_18_clicolor_0_terminal_inhibit_no()
    {
        Environment.SetEnvironmentVariable("CLICOLOR", "0");
        Colour.Refresh();
        AssertRow(attached: true, Colour.PolicyInhibit, expectedColour: false);
    }

    [Fact]
    public void Row_19_clicolor_1_terminal_auto_yes()
    {
        Environment.SetEnvironmentVariable("CLICOLOR", "1");
        Colour.Refresh();
        AssertRow(attached: true, Colour.PolicyAuto, expectedColour: true);
    }

    [Fact]
    public void Row_20_empty_woad_colour_is_absent()
    {
        Environment.SetEnvironmentVariable("WOAD_COLOUR", "");
        Environment.SetEnvironmentVariable("NO_COLOR", "1");
        Colour.Refresh();
        AssertRow(attached: true, Colour.PolicyInhibit, expectedColour: false);
    }

    [Fact]
    public void Row_21_empty_no_color_is_absent()
    {
        Environment.SetEnvironmentVariable("NO_COLOR", "");
        Colour.Refresh();
        AssertRow(attached: true, Colour.PolicyAuto, expectedColour: true);
    }

    [Fact]
    public void Row_22_refresh_drops_the_cache()
    {
        Environment.SetEnvironmentVariable("WOAD_COLOUR", "1");
        Colour.Refresh();
        Assert.Equal(Colour.PolicyForce, Colour.ColourPolicy());

        Environment.SetEnvironmentVariable("WOAD_COLOUR", null);
        Environment.SetEnvironmentVariable("NO_COLOR", "1");
        Colour.Refresh();
        AssertRow(attached: true, Colour.PolicyInhibit, expectedColour: false);
    }

    [Fact]
    public void SeqFor_null_sequence_is_empty()
    {
        Environment.SetEnvironmentVariable("WOAD_COLOUR", "1");
        Colour.Refresh();
        Assert.Equal("", Colour.SeqFor(new StringWriter(), null));
    }

    [Fact]
    public void StringWriter_is_not_a_terminal()
    {
        Assert.False(Colour.SupportsColour(new StringWriter()));
        Assert.Equal("", Colour.SeqFor(new StringWriter(), AnsiCodes.FgRed));
    }

    [Fact]
    public void Console_out_matches_output_redirection()
    {
        bool attached = !Console.IsOutputRedirected;

        Assert.Equal(attached, Colour.SupportsColour(Console.Out));
        Assert.Equal(
            attached ? AnsiCodes.FgGreen : "",
            Colour.SeqFor(Console.Out, AnsiCodes.FgGreen));
    }

    private static void AssertRow(bool attached, int expectedPolicy, bool expectedColour)
    {
        Assert.Equal(expectedPolicy, Colour.ColourPolicy());
        Assert.Equal(expectedColour, Colour.SupportsColour(attached));
        Assert.Equal(
            expectedColour ? AnsiCodes.FgRed : "",
            Colour.SeqFor(attached, AnsiCodes.FgRed));
    }
}
