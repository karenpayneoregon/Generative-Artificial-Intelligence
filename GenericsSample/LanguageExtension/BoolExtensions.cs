namespace GenericsSample.LanguageExtension
{
    public static class BoolExtensions
    {
        public static string ToYesNo(this bool value) => value ? "Yes" : "No";
    }
}
