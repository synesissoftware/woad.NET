// Created: 17th November 2026
// Updated: 17th November 2026

using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Woad.NET.Tests")]

namespace Woad;

/// <summary>
///  Portable colour policy from the woad 0.3.0 contract. Unix terminals
///  that are not <c>TERM=dumb</c> support colour. Windows virtual-terminal
///  gating and mintty recognition are not in this alpha.
/// </summary>
public static class Colour
{
    /// <summary>Colour depends on the writer. Value 0.</summary>
    public const int PolicyAuto = 0;

    /// <summary>Colour for every writer. Value 1.</summary>
    public const int PolicyForce = 1;

    /// <summary>Colour for no writer. Value 2.</summary>
    public const int PolicyInhibit = 2;

    private static readonly string[] Truey =
    [
        "1",
        "always",
        "force",
        "on",
        "true",
        "yes",
    ];

    private static readonly string[] Falsey =
    [
        "0",
        "false",
        "never",
        "no",
        "none",
        "off",
    ];

    private static readonly object Gate = new object();

    private static bool determined;

    private static int policy;

    private static bool termIsDumb;

    /// <summary>
    ///  Cached colour policy: <see cref="PolicyAuto"/>, <see cref="PolicyForce"/>,
    ///  or <see cref="PolicyInhibit"/>. The next call after <see cref="Refresh"/>
    ///  reads the environment again.
    /// </summary>
    /// <returns>0, 1, or 2.</returns>
    public static int ColourPolicy()
    {
        lock (Gate)
        {
            Ensure();

            return policy;
        }
    }

    /// <summary>
    ///  Drops the cached policy and the cached <c>TERM=dumb</c> flag.
    /// </summary>
    public static void Refresh()
    {
        lock (Gate)
        {
            determined = false;
        }
    }

    /// <summary>
    ///  Whether colour should be emitted for <paramref name="writer"/>.
    ///  A writer is a terminal only when it is <see cref="Console.Out"/> or
    ///  <see cref="Console.Error"/> and the matching
    ///  <see cref="Console.IsOutputRedirected"/> or
    ///  <see cref="Console.IsErrorRedirected"/> property is false.
    ///  Standard input is a <see cref="TextReader"/> and is not a terminal
    ///  for this query. Every other writer is not a terminal.
    /// </summary>
    /// <param name="writer">Destination to classify.</param>
    /// <returns>True when the sequence should be emitted.</returns>
    public static bool SupportsColour(TextWriter? writer)
    {
        return SupportsColour(IsTerminal(writer));
    }

    /// <summary>
    ///  <paramref name="sequence"/> when <paramref name="writer"/> supports
    ///  colour; otherwise <see cref="string.Empty"/>. A null sequence yields
    ///  <see cref="string.Empty"/>.
    /// </summary>
    /// <param name="writer">Destination to classify.</param>
    /// <param name="sequence">SGR sequence, or null.</param>
    /// <returns>The sequence, or the empty string.</returns>
    public static string SeqFor(TextWriter? writer, string? sequence)
    {
        if (sequence == null || !SupportsColour(writer))
        {
            return "";
        }

        return sequence;
    }

    internal static bool SupportsColour(bool attached)
    {
        lock (Gate)
        {
            Ensure();

            if (policy == PolicyForce)
            {
                return true;
            }

            if (policy == PolicyInhibit)
            {
                return false;
            }

            return attached && !termIsDumb;
        }
    }

    internal static string SeqFor(bool attached, string? sequence)
    {
        if (sequence == null || !SupportsColour(attached))
        {
            return "";
        }

        return sequence;
    }

    private static bool IsTerminal(TextWriter? writer)
    {
        if (writer == null)
        {
            return false;
        }

        if (ReferenceEquals(writer, Console.Out))
        {
            return !Console.IsOutputRedirected;
        }

        if (ReferenceEquals(writer, Console.Error))
        {
            return !Console.IsErrorRedirected;
        }

        return false;
    }

    private static void Ensure()
    {
        if (!determined)
        {
            policy = PolicyFromEnvironment();
            termIsDumb = TermIsDumbFromEnvironment();
            determined = true;
        }
    }

    private static string? Nonempty(string name)
    {
        string? value = Environment.GetEnvironmentVariable(name);

        if (string.IsNullOrEmpty(value))
        {
            return null;
        }

        return value;
    }

    private static bool Listed(string value, string[] tokens)
    {
        foreach (string token in tokens)
        {
            if (string.Equals(value, token, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
        }

        return false;
    }

    private static int PolicyFromEnvironment()
    {
        string? value = Nonempty("WOAD_COLOUR");

        if (value == null)
        {
            value = Nonempty("WOAD_COLOR");
        }

        if (value != null)
        {
            if (Listed(value, Truey))
            {
                return PolicyForce;
            }

            if (Listed(value, Falsey))
            {
                return PolicyInhibit;
            }

            return PolicyAuto;
        }

        if (Nonempty("NO_COLOR") != null)
        {
            return PolicyInhibit;
        }

        value = Nonempty("CLICOLOR_FORCE");

        if (value != null && value != "0")
        {
            return PolicyForce;
        }

        value = Nonempty("FORCE_COLOR");

        if (value != null &&
            value != "0" &&
            !string.Equals(value, "false", StringComparison.OrdinalIgnoreCase))
        {
            return PolicyForce;
        }

        value = Nonempty("CLICOLOR");

        if (value != null && value == "0")
        {
            return PolicyInhibit;
        }

        return PolicyAuto;
    }

    private static bool TermIsDumbFromEnvironment()
    {
        string? value = Nonempty("TERM");

        if (value == null)
        {
            return false;
        }

        return string.Equals(value, "dumb", StringComparison.OrdinalIgnoreCase);
    }
}
