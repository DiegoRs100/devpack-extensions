using Devpack.Extensions.Types;
using System.Text.RegularExpressions;

namespace Devpack.Extensions.Helpers
{
    public static class UrlHelper
    {
        private static readonly Regex UrlFormatRegex = new(@"[^a-zA-Z0-9-]",
            RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Multiline);

        private static readonly Regex TagsHtmlRegex = new(@"<.*?>",
            RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Multiline);

        public static string UseEndpointFormat(string text)
        {
            if (text.IsNullOrEmpty())
                return string.Empty;

            return text.RemoveGrammarAccents()
                .Replace(" ", "-")
                .Replace("--", "-")
                .RemoveText(TagsHtmlRegex, UrlFormatRegex)
                .ToLower();
        }

        public static string Combine(params string[] values)
        {
            values = values.Select(t => t.EndsWith('/') ? t[0..^2] : t).ToArray();
            return string.Join("/", values);
        }
    }
}