namespace ConsoleApp2;

/// <summary>
/// create a method which accepts two letters like AB and increment the second letter if it is Z then increment the first letter
/// </summary>
internal class Program
{
    static void Main(string[] args)
    {
        string[] exclude = ["AJ", "AK"];
        string result = "AA";

        for (int index = 0; index < 100; index++)
        {
            var (good, data) = IncrementLetters(result,exclude);
            result = data;
            Console.WriteLine(good ? data : $"\t{data}");
        }
        Console.ReadLine();
    }

    public static (bool, string result) IncrementLetters(string letters, string[] exclude)
    {
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
}
