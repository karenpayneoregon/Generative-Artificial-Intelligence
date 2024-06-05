using DebuggingWithCopilot.Classes;

namespace DebuggingWithCopilot;

internal partial class Program
{
    static async Task Main(string[] args)
    {
        SpectreConsoleHelpers.HereWeGo();
        await Task.Delay(2000);

        var fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "NoSuchFile.txt");
        var lines = await File.ReadAllLinesAsync(fileName);
        Console.ReadLine();
    }
}