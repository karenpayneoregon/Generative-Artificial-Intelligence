
// create a language extension to remove double whitespace from a string and use GeneratedRegexAttribute for pattern as a static field
// 

using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    public static partial class StringExtensions
    {
        /*
         * Copilot
         * Create a method which accepts a social security value as a string and returns social security
         * value with the first five digits masked with an X character
         *
         * Remarks: This works but could be better, see Karen's version MaskSsn below
         */
        public static string MaskSocialSecurity(this string socialSecurity)
        {
            if (string.IsNullOrEmpty(socialSecurity))
            {
                return socialSecurity;
            }

            // Use regular expression to match the first five digits of the social security value
            Regex regex = new(@"^\d{5}");

            // Replace the first five digits with X characters
            string maskedSocialSecurity = regex.Replace(socialSecurity, "XXXXX");

            return maskedSocialSecurity;
        }

        public static string MaskSsn(this string ssn, int digitsToShow = 4, char maskCharacter = 'X')
        {
            if (string.IsNullOrWhiteSpace(ssn)) return string.Empty;
            if (ssn.Contains("-")) ssn = ssn.Replace("-", string.Empty);
            if (ssn.Length != 9) throw new ArgumentException("SSN invalid length");
            if (ssn.IsNotInteger()) throw new ArgumentException("SSN not valid");

            const int ssnLength = 9;
            const string separator = "-";
            int maskLength = ssnLength - digitsToShow;

            int output = int.Parse(ssn.Replace(separator, string.Empty).Substring(maskLength, digitsToShow));

            string format = string.Empty;
            for (int index = 0; index < maskLength; index++) format += maskCharacter;
            for (int index = 0; index < digitsToShow; index++) format += "0";

            format = format.Insert(3, separator).Insert(6, separator);
            format = $"{{0:{format}}}";

            return string.Format(format, output);
        }
        public static bool IsInteger(this string sender)
        {
            foreach (var c in sender)
                if (c is < '0' or > '9') return false;

            return true;
        }

        public static bool IsNotInteger(this string sender)
            => sender.IsInteger() == false;

    }
}
