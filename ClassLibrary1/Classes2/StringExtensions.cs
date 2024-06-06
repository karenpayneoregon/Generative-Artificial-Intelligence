using System.Diagnostics;

namespace ClassLibrary1.Classes2;
/// <summary>
/// This class is a demonstration of using GitHub Copilot phrasing
/// - What to create
/// - Ensure code is optimized
/// </summary>
/// <remarks>
/// Notice in the two extensions similar code pattern
/// </remarks>
public static class StringExtensions
{
    /// <summary>
    /// Split text at each capital letter
    /// </summary>
    /// <param name="input">string to work on</param>
    /// <returns>
    /// <para>An empty string, if the input is null or empty.</para>
    /// <para>Same as original if nothing affected</para>
    /// <para>String split on each uppercase token</para>
    /// <para>SSMS would become S S M S</para>
    /// </returns>
    [DebuggerStepThrough]
    public static string SplitCamelCase(this string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }

        Span<char> result = stackalloc char[input.Length * 2];
        var resultIndex = 0;

        for (var index = 0; index < input.Length; index++)
        {
            var currentChar = input[index];

            if (index > 0 && char.IsUpper(currentChar))
            {
                result[resultIndex++] = ' ';
            }

            result[resultIndex++] = currentChar;
        }

        return result[..resultIndex].ToString();
    }

    /// <summary>
    /// Remove extra whitespace and trim whitespace from start and end of the string
    /// </summary>
    /// <param name="input">string to work on</param>
    /// <returns>The string with extra whitespace removed and whitespace trimmed from start and end</returns>
    [DebuggerStepThrough]
    public static string RemoveExtraWhitespace(this string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }

        Span<char> result = stackalloc char[input.Length];
        var resultIndex = 0;
        var isWhitespace = false;

        foreach (var currentChar in input)
        {
            if (char.IsWhiteSpace(currentChar))
            {
                if (!isWhitespace)
                {
                    result[resultIndex++] = ' ';
                    isWhitespace = true;
                }
            }
            else
            {
                result[resultIndex++] = currentChar;
                isWhitespace = false;
            }
        }

        return result[..resultIndex].ToString().Trim();
    }
}
