
using Translate1.Classes;

namespace Translate1;
internal partial class Program
{
    static async Task Main(string[] args)
    {
        await Setup();
        ExitPrompt();
    }
}