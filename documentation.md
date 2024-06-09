## Documenting code

Developers here tend not to document code which in some cases means that other developers may not understand the purpose of a class or method. Even when a method name is meaningful the method should be documented for several reasons, first, when a code base will have help generated from XML documentation and for clarification of usage and meaning of parameters and return types are a few reasons to document code.

### Example 1

Here is a method which is easy to understand.

```csharp
public static class DateTimeExtensions
{
    public static DateOnly FirstDateOfWeek(this DateTime sender, DayOfWeek startOfWeek = DayOfWeek.Sunday)
        => DateOnly.FromDateTime(sender.AddDays(-1 * (7 + (sender.DayOfWeek - startOfWeek)) % 7));
}
```

When using the above method this is what is shown with Intellisense.

![d1](assets/D1.png)

Using /doc feature of GitHub Copilot

```csharp
public static class DateTimeExtensions
{

    /// <summary>
    /// Calculates the first date of the week based on a given start day of the week.
    /// </summary>
    /// <param name="sender">The DateTime object representing the current date.</param>
    /// <param name="startOfWeek">The start day of the week (default is Sunday).</param>
    /// <returns>The first date of the week.</returns>
    public static DateOnly FirstDateOfWeek(this DateTime sender, DayOfWeek startOfWeek = DayOfWeek.Sunday)
        => DateOnly.FromDateTime(sender.AddDays(-1 * (7 + (sender.DayOfWeek - startOfWeek)) % 7));
}
```

Much better with proper documentation from Copilot.

![d2](assets/D2.png)

### Example 2


