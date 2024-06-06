using System.Diagnostics;
using System.Text.RegularExpressions;

namespace ClassLibrary1.Classes1;

/// <summary>
/// Code not using GitHub Copilot.
/// - Code was written years ago
/// - Optimized using static Regex for NET8
/// </summary>
public static class StringExtensions
{
    private static readonly Regex CamelCaseRegex = new(@"([A-Z][a-z]+)");
    /// <summary>
    /// KarenPayne => Karen Payne
    /// </summary>
    [DebuggerStepThrough]
    public static string SplitCamelCase(this string sender) =>
        string.Join(" ", CamelCaseRegex.Matches(sender)
            .Select(m => m.Value));
}