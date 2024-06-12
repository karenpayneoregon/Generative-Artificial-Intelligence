using static ConsoleApp2.Helpers;

namespace ConsoleApp2;

/// <summary>
/// Copilot question
/// create a method which accepts two letters like AB and increment the second letter if it is Z then increment the first letter
/// Karen modifications
///   Add a list of strings to exclude from the result
///   ToUpperCase the input
///   Length check
/// </summary>
internal class Program
{
    static void Main(string[] args)
    {
 

        Console.WriteLine(IncrementString("AA-W01"));
        Console.WriteLine(NextValue("AA-W01"));
        Console.ReadLine();
    }



    public static (bool, string) IncrementLetters(string letters, string[] exclude)
    {
        letters = letters.ToUpper();

        if (letters.Length != 2)
        {
            throw new ArgumentException("The input must be two letters");
        }

        var firstLetter = letters[0];
        var secondLetter = letters[1];

        if (secondLetter == 'Z')
        {
            secondLetter = 'A';
            firstLetter++;
        }
        else
        {
            secondLetter++;
        }

        var result = $"{firstLetter}{secondLetter}";
        return exclude.Contains(result) ? (false, result) : (true, result);
    }
    public static char IncrementChar(char c)
    {
        if (c == 'Z')
        {
            return 'A';
        }
        else
        {
            return (char)(c + 1);
        }
    }
    public static string IncrementString(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            throw new ArgumentException("Input string cannot be null or empty");
        }

        int lastIndex = input.Length - 1;
        char lastChar = input[lastIndex];

        if (!char.IsDigit(lastChar))
        {
            throw new ArgumentException("Input string must end with a number");
        }

        int number = int.Parse(lastChar.ToString());
        number++;

        string incrementedString = input.Substring(0, lastIndex) + number.ToString();
        return incrementedString;
    }
}
