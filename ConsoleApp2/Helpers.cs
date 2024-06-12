﻿using System.Text.RegularExpressions;

namespace ConsoleApp2;

public partial class Helpers
{

    public static string NextValue(string sender, int incrementBy = 1)
    {
        string value = NumbersPattern().Match(sender).Value;

        return sender[..^value.Length] + (long.Parse(value) + incrementBy)
            .ToString().PadLeft(value.Length, '0');
    }

    [GeneratedRegex("[0-9]+$")]
    private static partial Regex NumbersPattern();
}
