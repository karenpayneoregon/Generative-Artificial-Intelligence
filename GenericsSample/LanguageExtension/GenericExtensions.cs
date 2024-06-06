namespace GenericsSample.LanguageExtension;

/*
 * Question given to Copilot
 *
 * Create a generic language extension method with a constraint for
 * IComparable<T> and struct which determines if a value is between two values
 *
 * Notes:
 * It comes from experience to include the constraints and also which constraints.
 */
public static class GenericExtensions
{
    /// <summary>
    /// Determine if <paramref name="value"/> is between <paramref name="minValue"/> and <paramref name="maxValue"/>
    /// </summary>
    /// <typeparam name="T">Type</typeparam>
    /// <param name="value">value to work with</param>
    /// <param name="minValue">minimum value</param>
    /// <param name="maxValue">maximum value</param>
    /// <returns></returns>
    public static bool IsBetweenCopilot<T>(this T value, T minValue, T maxValue) where T : struct, IComparable<T> 
        => value.CompareTo(minValue) >= 0 && value.CompareTo(maxValue) <= 0;

    public static bool IsBetweenKaren<T>(this T value, T lowerValue, T upperValue) where T : struct, IComparable<T>
        => Comparer<T>.Default.Compare(value, lowerValue) >= 0 && Comparer<T>.Default.Compare(value, upperValue) <= 0;
}