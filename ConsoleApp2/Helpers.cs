using System.Text.RegularExpressions;

namespace ConsoleApp2;
public partial class Helpers
{

    /// <summary>
    /// Generates the next value based on the given sender string and incrementBy value.
    /// </summary>
    /// <param name="sender">The sender string.</param>
    /// <param name="incrementBy">The value to increment by (default is 1).</param>
    /// <returns>The next value.</returns>
    public static string NextValue(string sender, int incrementBy = 1)
    {
        string value = NumbersPattern().Match(sender).Value;

        return sender[..^value.Length] + (long.Parse(value) + incrementBy)
            .ToString().PadLeft(value.Length, '0');
    }

    [GeneratedRegex("[0-9]+$")]
    private static partial Regex NumbersPattern();
}
