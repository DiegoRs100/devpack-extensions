using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Devpack.Extensions.Types
{
    public static class StringExtensions
    {
        private static readonly Regex RegexOnlyAlphanumeric = new(@"[^a-zA-Zá-úÁ-Ú0-9 ]",
            RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Multiline);

        public static bool Match(this string value, string compare)
        {
            return string.Compare(value, compare, StringComparison.OrdinalIgnoreCase) == 0;
        }

        public static string GetOnlyAlphanumeric(this string str)
        {
            return RegexOnlyAlphanumeric.Replace(str ?? string.Empty, " ").Trim();
        }

        public static string RemoveAllSpaces(this string text)
        {
            return text.RemoveText(" ");
        }

        public static string RemoveText(this string text, params string[] removeValues)
        {
            foreach (var item in removeValues)
                text = text.Replace(item, string.Empty);

            return text;
        }

        public static string RemoveText(this string text, params Regex[] removeValues)
        {
            foreach (var item in removeValues)
                text = item.Replace(text, string.Empty);

            return text;
        }

        public static string RemoveFirstOccurence(this string text, Regex removeRegex)
        {
            return removeRegex.Replace(text, string.Empty, 1);
        }

        public static string RemoveGrammarAccents(this string text)
        {
            return new string(text
                .Normalize(NormalizationForm.FormD)
                    .Where(ch => CharUnicodeInfo.GetUnicodeCategory(ch) != UnicodeCategory.NonSpacingMark).ToArray())
                .Normalize(NormalizationForm.FormC);
        }

        public static string RemoveLineBreaks(this string value, string replaceWith = " ")
        {
            return (value ?? string.Empty).ReplaceAll(new[] { Environment.NewLine, "\r", "\n", "\t", "\f" }, replaceWith);
        }

        public static string ReplaceAll(this string text, string[] replaceArguments, string replaceWith)
        {
            foreach (var argument in replaceArguments)
                text = text.Replace(argument, replaceWith);

            return text;
        }

        public static string NullAsEmpty(this string text)
        {
            return text ?? string.Empty;
        }

        public static string? EmptyAsNull(this string text)
        {
            return text == string.Empty ? null : text;
        }

        public static string Captalize(this string text)
        {
            if (text is null)
                return string.Empty;

            return new CultureInfo("pt-br").TextInfo.ToTitleCase(text)
                .Replace(" A ", " a ")
                .Replace(" E ", " e ")
                .Replace(" I ", " i ")
                .Replace(" O ", " o ")
                .Replace(" U ", " u ")
                .Replace(" Da ", " da ")
                .Replace(" De ", " de ")
                .Replace(" Do ", " do ")
                .Replace(" Ou ", " ou ")
                .Replace(" Em ", " em ")
                .Replace(" Com ", " com ")
                .Replace(" Sem ", " sem ")
                .Replace(" Por ", " por ")
                .Replace(" Para ", " para ")
                .Replace(" Das ", " das ")
                .Replace(" Até ", " até ")
                .Trim();
        }

        public static string ToBase64(this string obj)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(obj));
        }

        public static string MaskCharacters(this string text, char maskChar, int numCharacters = 0)
        {
            if (text is null)
                return string.Empty;
            var maskRegex = new Regex(@"[\d\w]");
            if (numCharacters == 0)
                text = maskRegex.Replace(text, maskChar.ToString());
            else
                text = maskRegex.Replace(text, maskChar.ToString(), numCharacters);
            return text;
        }

        public static bool IsNullOrEmpty(this string text)
        {
            return string.IsNullOrEmpty(text);
        }

        public static bool IsNullOrWhiteSpace(this string text)
        {
            return string.IsNullOrWhiteSpace(text?.Trim());
        }

        public static bool HasOnlyDigits(this string source)
        {
            if (source.IsNullOrEmpty())
                return false;

            return source.All(char.IsDigit);
        }

        public static bool HasOnlyLetters(this string source)
        {
            if (source.IsNullOrEmpty())
                return false;

            return source.All(char.IsLetter);
        }
    }
}