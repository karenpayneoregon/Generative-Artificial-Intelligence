using System.Diagnostics;

namespace GenericsSample.LanguageExtension;
/// <summary>
/// Here I asked GitHub copilot to create an extension method that removes extra whitespace
/// - First works but not optimal
/// - Second works and is optimal
///
/// Since both work, which one to use? It depends, for say working with a simple string,
/// either but with say working on a file with a thousand of lines, go with the second.
/// </summary>
public static class StringExtensions
{
    // Copilot 1
    // create a language extension to remove double whitespace from a string
    // Karen formated code and set as an expression body
    [DebuggerStepThrough]
    public static string RemoveDoubleWhitespace(this string input) 
        => string.Join(" ", 
            input.Split(' ', 
                StringSplitOptions.RemoveEmptyEntries));

    // Copilot 2
    // create a language extension to remove extra whitespace from a string
    // Uses Span<char> to avoid creating a new string (but does on return)
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
