using GenericsSample.LanguageExtension;

namespace GenericsSample;

internal class Program
{
    static void Main(string[] args)
    {
        BetweenSample();
    }
    private static void BetweenSample()
    {
        {
            var result = new DateOnly(2020, 1, 10).IsBetweenCopilot(
                new DateOnly(2020, 1, 1),
                new DateOnly(2020, 1, 13));
            Console.WriteLine(result.ToYesNo());
        }

        {
            var result = 10.IsBetweenCopilot(8, 12);
            Console.WriteLine(result.ToYesNo());
        }

        {
            var result = 20.IsBetweenCopilot(8, 12);
            Console.WriteLine(result.ToYesNo());
        }

        Console.ReadLine();
    }
}
